using Npgsql;
using KoiSmart.Database;
using KoiSmart.Helpers;
using KoiSmart.Models.RiwayatTransaksi;
using System;
using System.Collections.Generic;

namespace KoiSmart.Controllers
{
    public class RiwayatTransaksiController
    {
        private DbContext _db;

        public RiwayatTransaksiController()
        {
            _db = new DbContext();
        }

        // =====================================================
        // ADMIN: FULL RIWAYAT TRANSAKSI
        // =====================================================
        public List<RiwayatDetail> GetAllRiwayat()
        {
            List<RiwayatDetail> list = new List<RiwayatDetail>();

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        t.id_transaksi,
                        a.nama_depan || ' ' || a.nama_belakang,
                        a.no_telp,
                        a.alamat,
                        i.jenis_ikan,
                        dt.jumlah_pembelian,
                        dt.subtotal,
                        t.status_transaksi,
                        t.tanggal_transaksi
                    FROM transaksi t
                    JOIN akun a ON a.id_akun = t.id_akun
                    JOIN detail_transaksi dt ON dt.id_transaksi = t.id_transaksi
                    JOIN ikan i ON i.id_ikan = dt.id_ikan
                    ORDER BY t.tanggal_transaksi DESC
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RiwayatDetail
                        {
                            IdTransaksi = reader.GetInt32(0),
                            NamaCustomer = reader.GetString(1),
                            NoTelp = reader.GetString(2),
                            Alamat = reader.GetString(3),
                            JenisPembelian = reader.GetString(4),
                            Jumlah = reader.GetInt32(5),
                            Subtotal = reader.GetDecimal(6),
                            Status = reader.GetString(7),
                            TanggalTransaksi = reader.GetDateTime(8)
                        });
                    }
                }
            }

            return list;
        }

        // =====================================================
        // RIWAYAT CUSTOMER SENDIRI
        // =====================================================
        public List<RiwayatDetail> GetCustomerRiwayat()
        {
            List<RiwayatDetail> list = new List<RiwayatDetail>();
            int idAkun = AppSession.CurrentUser.IdAkun;

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        t.id_transaksi,
                        i.jenis_ikan,
                        dt.jumlah_pembelian,
                        dt.subtotal,
                        t.status_transaksi,
                        t.tanggal_transaksi
                    FROM transaksi t
                    JOIN detail_transaksi dt ON dt.id_transaksi = t.id_transaksi
                    JOIN ikan i ON i.id_ikan = dt.id_ikan
                    WHERE t.id_akun = @id
                    ORDER BY t.tanggal_transaksi DESC
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAkun);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new RiwayatDetail
                            {
                                IdTransaksi = reader.GetInt32(0),
                                JenisPembelian = reader.GetString(1),
                                Jumlah = reader.GetInt32(2),
                                Subtotal = reader.GetDecimal(3),
                                Status = reader.GetString(4),
                                TanggalTransaksi = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }

            return list;
        }

        // =====================================================
        // TRANSAKSI CUSTOMER YANG BELUM DIREVIEW
        // =====================================================
        public List<int> GetBelumDireview()
        {
            List<int> list = new List<int>();
            int idAkun = AppSession.CurrentUser.IdAkun;

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = @"
                    SELECT id_transaksi
                    FROM transaksi
                    WHERE id_akun = @id
                    AND id_review IS NULL
                    ORDER BY tanggal_transaksi DESC
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAkun);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return list;
        }
    }
}
