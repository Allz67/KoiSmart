using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using KoiSmart.Database;
using KoiSmart.Models;
using KoiSmart.Helpers;
using Npgsql;
using System.Windows.Forms;
using System.Data;

namespace KoiSmart.Controllers
{
    // Ini adalah Controller yang mengurus semua interaksi tabel Transaksi
    public class TransaksiController
    {
        private DbContext _dbContext;

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
                        // ... (Kode INSERT HEADER Transaksi dibiarkan sama) ...

                        int idTransaksiBaru = 0;
                        // ... (lanjutan kode cmdHeader) ...

                        // 2. INSERT DETAIL TRANSAKSI & UPDATE STOK IKAN
                        foreach (var item in items)
                        {
                            // A. Insert Detail (tetap sama)
                            // ... (kode cmdDetail) ...

                            // B. Update Stok Ikan (Kurangi Stok)
                            string queryStok = "UPDATE ikan SET stok = stok - @qty WHERE id_ikan = @idIkan";
                            using (var cmdStok = new NpgsqlCommand(queryStok, conn, trans))
                            {
                                cmdStok.Parameters.AddWithValue("@qty", item.Quantity);
                                // --- PERBAIKAN DI SINI ---
                                // HARUSNYA: item.Ikan.IdIkan (ID Ikan), BUKAN item.Ikan.IdAkun
                                cmdStok.Parameters.AddWithValue("@idIkan", item.Ikan.IdIkan);
                                // -------------------------
                                cmdStok.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Debug.WriteLine("BuatPesanan Error: " + ex);
                        MessageBox.Show("Gagal membuat pesanan: " + ex.Message, "Database Error");
                        return false;
                    }
                }
            }
        }

        // =========================================================
        // BAGIAN 2: READ (Ambil Data Transaksi) - LOGIC UTAMA
        // =========================================================

        // [ALGORITMA: OVERLOADING] Method non-filter
        public List<RiwayatTransaksi> GetRiwayat(int idUser)
        {
            return GetRiwayat(idUser, null);
        }

        // [ALGORITMA: JOIN & GROUPING] Method dengan filter status
        public List<RiwayatTransaksi> GetRiwayat(int idUser, List<string> statusList)
        {
            var listRiwayat = new List<RiwayatTransaksi>();
            string statusParamsSql = string.Empty;
            string statusFilterClause = string.Empty;

            if (statusList != null && statusList.Count > 0)
            {
                statusParamsSql = string.Join(",", statusList.Select((s, i) => $"@status{i}"));

                // PERBAIKAN 1 & 2: Gunakan status_transaksi di klausa WHERE
                statusFilterClause = $" AND t.status_transaksi IN ({statusParamsSql})";
            }

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();

                    string query = $@"
                SELECT t.id_transaksi, t.tanggal_transaksi, t.total_harga,
                       t.status_transaksi, -- PERBAIKAN 3: Select kolom status_transaksi
                       d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal
                FROM transaksi t
                JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                JOIN ikan i ON d.id_ikan = i.id_ikan
                WHERE t.id_akun = @uid
                {statusFilterClause}
                ORDER BY t.tanggal_transaksi DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
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
                                        // PERBAIKAN 4: Baca dari kolom status_transaksi
                                        Status = reader["status_transaksi"].ToString(),
                                        TotalBelanja = reader.IsDBNull(reader.GetOrdinal("total_harga")) ? 0m : Convert.ToDecimal(reader["total_harga"]),
                                        Items = new List<RiwayatItem>()
                                    };
                                    listRiwayat.Add(trx);
                                }

                                // Menambahkan Item Barang ke Header tersebut (Logic sama)
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
                    MessageBox.Show("SQL MAPPING ERROR: " + ex.Message, "DEBUG DATABASE FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return listRiwayat;
        }
    }
}