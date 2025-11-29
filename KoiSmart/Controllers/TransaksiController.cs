using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using KoiSmart.Database;
using KoiSmart.Models;
using KoiSmart.Helpers;
using Npgsql;
using NpgsqlTypes;
using System.Windows.Forms; 
using System.Data;

namespace KoiSmart.Controllers
{
    public class TransaksiController
    {
        private DbContext _dbContext;
        private const int DefaultCommandTimeoutSeconds = 60; // increase for large payloads

        public TransaksiController()
        {
            _dbContext = new DbContext();
        }

        // =========================================================
        // BAGIAN 1: CREATE (Buat Pesanan) - LOGIC INSERT & ROLLBACK
        // =========================================================
        public bool BuatPesanan(int idAkun, byte[] buktiPembayaran, IReadOnlyList<CartItem> items)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. INSERT HEADER TRANSAKSI
                        string queryHeader = @"
                            INSERT INTO transaksi (id_akun, tanggal_transaksi, total_harga, bukti_pembayaran, status_transaksi)
                            VALUES (@idAkun, @tanggal, @total, @bukti, 'Pending')
                            RETURNING id_transaksi";

                        int idTransaksiBaru = 0;

                        using (var cmdHeader = new NpgsqlCommand(queryHeader, conn, trans))
                        {
                            cmdHeader.CommandTimeout = DefaultCommandTimeoutSeconds;
                            cmdHeader.Parameters.AddWithValue("@idAkun", idAkun);
                            cmdHeader.Parameters.AddWithValue("@tanggal", DateTime.Now);
                            cmdHeader.Parameters.AddWithValue("@total", CartSession.GetTotal());

                            // Explicitly specify bytea type to avoid ambiguous parameter handling and large-write surprises
                            var buktiParam = new NpgsqlParameter("@bukti", NpgsqlDbType.Bytea);
                            buktiParam.Value = buktiPembayaran ?? (object)DBNull.Value;
                            cmdHeader.Parameters.Add(buktiParam);

                            idTransaksiBaru = (int)cmdHeader.ExecuteScalar();
                        }

                        // 2. INSERT DETAIL TRANSAKSI & UPDATE STOK IKAN
                        foreach (var item in items)
                        {
                            // A. Insert Detail
                            string queryDetail = @"
                                INSERT INTO detail_transaksi (id_transaksi, id_ikan, jumlah_pembelian, subtotal)
                                VALUES (@idTrans, @idIkan, @qty, @subtotal)";

                            using (var cmdDetail = new NpgsqlCommand(queryDetail, conn, trans))
                            {
                                cmdDetail.CommandTimeout = DefaultCommandTimeoutSeconds;
                                cmdDetail.Parameters.AddWithValue("@idTrans", idTransaksiBaru);
                                cmdDetail.Parameters.AddWithValue("@idIkan", item.Ikan.IdIkan);
                                cmdDetail.Parameters.AddWithValue("@qty", item.Quantity);
                                cmdDetail.Parameters.AddWithValue("@subtotal", item.Subtotal);
                                cmdDetail.ExecuteNonQuery();
                            }

                            // B. Update Stok Ikan (Kurangi Stok)
                            string queryStok = "UPDATE ikan SET stok = stok - @qty WHERE id_ikan = @idIkan";
                            using (var cmdStok = new NpgsqlCommand(queryStok, conn, trans))
                            {
                                cmdStok.CommandTimeout = DefaultCommandTimeoutSeconds;
                                cmdStok.Parameters.AddWithValue("@qty", item.Quantity);
                                cmdStok.Parameters.AddWithValue("@idIkan", item.Ikan.IdIkan);
                                cmdStok.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Safe rollback: transaction/connection may already be disposed if a low-level network error occurred.
                        try
                        {
                            if (trans != null && trans.Connection != null && trans.Connection.State == ConnectionState.Open)
                            {
                                trans.Rollback();
                            }
                            else
                            {
                                Debug.WriteLine("Rollback skipped: transaction or connection not available.");
                            }
                        }
                        catch (Exception rbEx)
                        {
                            // Log rollback failure but continue to handle original error
                            Debug.WriteLine("Rollback failed: " + rbEx);
                        }

                        Debug.WriteLine("BuatPesanan Error: " + ex);
                        MessageBox.Show("Gagal membuat pesanan: " + ex.Message, "Database Error");
                        return false;
                    }
                }
            }
        }

        // =========================================================
        // BAGIAN 2: READ (Ambil Riwayat Transaksi) - LOGIC UTAMA
        // =========================================================

        public List<RiwayatTransaksi> GetRiwayat(int idUser)
        {
            return GetRiwayat(idUser, null);
        }

        public List<RiwayatTransaksi> GetRiwayat(int idUser, List<string> statusList)
        {
            var listRiwayat = new List<RiwayatTransaksi>();
            string statusParamsSql = string.Empty;
            string statusFilterClause = string.Empty;

            if (statusList != null && statusList.Count > 0)
            {
                statusParamsSql = string.Join(",", statusList.Select((s, i) => $"@status{i}"));
                statusFilterClause = $" AND t.status IN ({statusParamsSql})";
            }

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();

                    string query = $@"
                        SELECT t.id_transaksi, t.tanggal_transaksi, t.status_transaksi, t.total_harga,
                               d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal
                        FROM transaksi t
                        JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                        JOIN ikan i ON d.id_ikan = i.id_ikan
                        WHERE t.id_akun = @uid
                        {statusFilterClause}
                        ORDER BY t.tanggal_transaksi DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = DefaultCommandTimeoutSeconds;
                        cmd.Parameters.AddWithValue("@uid", idUser);

                        if (!string.IsNullOrEmpty(statusParamsSql))
                        {
                            for (int i = 0; i < statusList.Count; i++)
                            {
                                cmd.Parameters.AddWithValue($"@status{i}", statusList[i]);
                            }
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idTrx = Convert.ToInt32(reader["id_transaksi"]);

                                var trx = listRiwayat.FirstOrDefault(x => x.IdTransaksi == idTrx);

                                if (trx == null)
                                {
                                    trx = new RiwayatTransaksi
                                    {
                                        IdTransaksi = idTrx,
                                        Tanggal = reader.IsDBNull(reader.GetOrdinal("tanggal_transaksi")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_transaksi")),
                                        Status = reader["status"].ToString(),
                                        TotalBelanja = reader.IsDBNull(reader.GetOrdinal("total_harga")) ? 0m : Convert.ToDecimal(reader["total_harga"]),
                                        Items = new List<RiwayatItem>()
                                    };
                                    listRiwayat.Add(trx);
                                }

                                trx.Items.Add(new RiwayatItem
                                {
                                    NamaIkan = reader["jenis_ikan"].ToString(),
                                    Qty = reader.IsDBNull(reader.GetOrdinal("jumlah_pembelian")) ? 0 : Convert.ToInt32(reader["jumlah_pembelian"]),
                                    HargaSatuan = reader.IsDBNull(reader.GetOrdinal("harga")) ? 0m : Convert.ToDecimal(reader["harga"]),
                                    Gambar = reader["gambar_ikan"] == DBNull.Value ? null : (byte[])reader["gambar_ikan"]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "DEBUG DATABASE FAILURE");
                }
            }
            return listRiwayat;
        }
    }
}