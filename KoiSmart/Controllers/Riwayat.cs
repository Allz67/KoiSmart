using System;
using System.Collections.Generic;
using System.Linq; // Wajib untuk logic grouping
using KoiSmart.Database;
using KoiSmart.Models;
using KoiSmart.Helpers;
using Npgsql;
using System.Windows.Forms;
using System.Diagnostics;

namespace KoiSmart.Controllers
{
    public class RiwayatTransaksiController
    {
        private DbContext _dbContext;

        public RiwayatTransaksiController()
        {
            _dbContext = new DbContext();
        }
        public List<RiwayatTransaksi> GetRiwayat(int idUser)
        {
            var listRiwayat = new List<RiwayatTransaksi>();

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT t.id_transaksi, t.tanggal_transaksi, t.status, t.total_harga,
                               d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal
                        FROM transaksi t
                        JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                        JOIN ikan i ON i.id_ikan = d.id_ikan
                        WHERE t.id_akun = @uid
                        ORDER BY t.tanggal_transaksi DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", idUser);

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
                                        Tanggal = Convert.ToDateTime(reader["tanggal_transaksi"]),
                                        Status = reader["status"].ToString(),
                                        TotalBelanja = Convert.ToDecimal(reader["total_harga"]),
                                        Items = new List<RiwayatItem>()
                                    };
                                    listRiwayat.Add(trx);
                                }

                                trx.Items.Add(new RiwayatItem
                                {
                                    NamaIkan = reader["jenis_ikan"].ToString(),
                                    Qty = Convert.ToInt32(reader["jumlah_pembelian"]),
                                    HargaSatuan = Convert.ToDecimal(reader["harga"]),
                                    Gambar = reader["gambar_ikan"] == DBNull.Value ? null : (byte[])reader["gambar_ikan"]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("GetRiwayat Error: " + ex);
                    System.Windows.Forms.MessageBox.Show("Gagal memuat riwayat transaksi. Cek koneksi atau nama kolom DB.\nError: " + ex.Message, "Database Error");
                }
            }
            return listRiwayat;
        }
    }
}