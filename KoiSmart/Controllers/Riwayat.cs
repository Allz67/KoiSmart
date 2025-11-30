
using KoiSmart.Database;
using KoiSmart.Models; 
using Npgsql;
using System.Diagnostics;

namespace KoiSmart.Controllers
{
    public class RiwayatTransaksiController
    {
        private DbContext _dbContext;
        private const int DefaultCommandTimeoutSeconds = 60;

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
                        SELECT t.id_transaksi, t.tanggal_transaksi, t.status, t.total_harga, t.bukti_pembayaran, t.id_akun,
                               d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal,
                               i.panjang, i.gender, i.grade
                        FROM transaksi t
                        JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                        JOIN ikan i ON i.id_ikan = d.id_ikan
                        WHERE t.id_akun = @uid
                        ORDER BY t.tanggal_transaksi DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = DefaultCommandTimeoutSeconds;
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
                                        IdAkun = Convert.ToInt32(reader["id_akun"]),
                                        Tanggal = Convert.ToDateTime(reader["tanggal_transaksi"]),
                                        Status = reader["status"].ToString(),
                                        TotalBelanja = Convert.ToDecimal(reader["total_harga"]),
                                        BuktiPembayaran = reader["bukti_pembayaran"] == DBNull.Value ? null : (byte[])reader["bukti_pembayaran"],
                                        Items = new List<TransaksiItem>()
                                    };
                                    listRiwayat.Add(trx);
                                }

                                trx.Items.Add(new TransaksiItem
                                {
                                    NamaIkan = reader["jenis_ikan"].ToString(),
                                    Qty = Convert.ToInt32(reader["jumlah_pembelian"]),
                                    HargaSatuan = Convert.ToDecimal(reader["harga"]),
                                    Subtotal = Convert.ToDecimal(reader["subtotal"]),
                                    Gambar = reader["gambar_ikan"] == DBNull.Value ? null : (byte[])reader["gambar_ikan"],
                                    Panjang = Convert.ToInt32(reader["panjang"]),
                                    Gender = reader["gender"].ToString(),
                                    Grade = reader["grade"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("GetRiwayat Error: " + ex);
                    MessageBox.Show("Gagal memuat riwayat transaksi. Cek koneksi atau nama kolom DB.\nError: " + ex.Message, "Database Error");
                }
            }
            return listRiwayat;
        }
    }
}