using KoiSmart.Helpers;
using KoiSmart.Models;
using Npgsql;
using KoiSmart.Database;

namespace KoiSmart.Controllers
{
    public class TransaksiController
    {
        private DbContext _db;

        public TransaksiController()
        {
            _db = new DbContext();
        }

        public int CreateTransaksi()
        {
            int transaksiId = 0;
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert ke transaksi
                        string queryTransaksi = @"INSERT INTO transaksi (tanggal_transaksi, id_akun, status, total_harga)
                                                  VALUES (@tanggal, @akun, @status, @total)
                                                  RETURNING id_transaksi";

                        using (var cmd = new NpgsqlCommand(queryTransaksi, conn))
                        {
                            cmd.Parameters.AddWithValue("@tanggal", DateTime.Now);
                            cmd.Parameters.AddWithValue("@akun", AppSession.CurrentUser.IdAkun);
                            cmd.Parameters.AddWithValue("@status", "Pending");
                            cmd.Parameters.AddWithValue("@total", CartSession.GetTotal());

                            transaksiId = (int)cmd.ExecuteScalar();
                        }

                        // 2. Insert detail transaksi sesuai item di cart
                        foreach (var item in CartSession.Items)
                        {
                            string queryDetail = @"INSERT INTO detail_transaksi (id_transaksi, id_ikan, jumlah_pembelian, subtotal)
                                                   VALUES (@transaksi, @ikan, @jumlah, @subtotal)";

                            using (var cmd = new NpgsqlCommand(queryDetail, conn))
                            {
                                cmd.Parameters.AddWithValue("@transaksi", transaksiId);
                                cmd.Parameters.AddWithValue("@ikan", item.Ikan.IdIkan);
                                cmd.Parameters.AddWithValue("@jumlah", item.Quantity);
                                cmd.Parameters.AddWithValue("@subtotal", item.Subtotal);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Update stok ikan
                            string updateStok = "UPDATE ikan SET stok = stok - @jumlah WHERE id_ikan = @ikan";

                            using (var cmd = new NpgsqlCommand(updateStok, conn))
                            {
                                cmd.Parameters.AddWithValue("@jumlah", item.Quantity);
                                cmd.Parameters.AddWithValue("@ikan", item.Ikan.IdIkan);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        CartSession.Clear();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return transaksiId;
        }
    }
}