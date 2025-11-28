using System;
using System.Collections.Generic;
using KoiSmart.Database;
using KoiSmart.Models;
using KoiSmart.Helpers;
using Npgsql;

namespace KoiSmart.Controllers
{
    public class TransaksiController
    {
        private DbContext _dbContext;

        public TransaksiController()
        {
            _dbContext = new DbContext();
        }

        // Method Gabungan: Terima ID User, Bukti Bayar, dan List Barang
        public bool BuatPesanan(int idAkun, byte[] buktiPembayaran, IReadOnlyList<CartItem> items)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();

                // Gunakan Transaksi SQL (Biar kalau error 1, batal semua)
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. INSERT HEADER TRANSAKSI (Dengan Bukti Pembayaran)
                        string queryHeader = @"
                            INSERT INTO transaksi (id_akun, tanggal_transaksi, total_harga, bukti_pembayaran, status_transaksi)
                            VALUES (@idAkun, @tanggal, @total, @bukti, 'Pending')
                            RETURNING id_transaksi";

                        int idTransaksiBaru = 0;

                        using (var cmdHeader = new NpgsqlCommand(queryHeader, conn, trans))
                        {
                            cmdHeader.Parameters.AddWithValue("@idAkun", idAkun);
                            cmdHeader.Parameters.AddWithValue("@tanggal", DateTime.Now);
                            cmdHeader.Parameters.AddWithValue("@total", CartSession.GetTotal());

                            // Handle Bukti Bayar (Penting!)
                            cmdHeader.Parameters.AddWithValue("@bukti", buktiPembayaran ?? (object)DBNull.Value);

                            // Eksekusi dan ambil ID baru
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
                                cmdStok.Parameters.AddWithValue("@qty", item.Quantity);
                                cmdStok.Parameters.AddWithValue("@idIkan", item.Ikan.IdIkan);
                                cmdStok.ExecuteNonQuery();
                            }
                        }

                        // Kalau semua lancar, simpan permanen
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Kalau ada error, batalkan semua perubahan
                        trans.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error Transaksi: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}