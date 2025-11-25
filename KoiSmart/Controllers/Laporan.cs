using Npgsql;
using KoiSmart.Database;
using KoiSmart.Models;
using System;
using System.Collections.Generic;

namespace KoiSmart.Controllers
{
    public class LaporanController
    {
        private DbContext _db;

        public LaporanController()
        {
            _db = new DbContext();
        }

        // ============================
        // GET WAKTU LAPORAN TERAKHIR
        // ============================
        public DateTime? GetLastReportTime()
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = "SELECT MAX(waktu_laporan) FROM laporan";

                var result = cmdScalar(conn, query);
                if (result == DBNull.Value || result == null)
                    return null;

                return Convert.ToDateTime(result);
            }
        }

        // ===============================================================
        // GET DATA LAPORAN SEJAK LAPORAN TERAKHIR (TRANSAKSI BARU SAJA)
        // ===============================================================
        public List<LaporanTransaksiData> GetTransaksiSetelahLaporan()
        {
            List<LaporanTransaksiData> list = new List<LaporanTransaksiData>();
            DateTime? last = GetLastReportTime();

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();    

                string condition = last != null ? "WHERE t.tanggal_transaksi > @last" : "";

                string query = $@"
                    SELECT 
                        t.id_transaksi,
                        a.nama_depan || ' ' || a.nama_belakang AS nama_pelanggan,
                        t.tanggal_transaksi,
                        SUM(dt.subtotal),
                        SUM(dt.jumlah_pembelian),
                        t.status_transaksi
                    FROM transaksi t
                    JOIN akun a ON t.id_akun = a.id_akun
                    JOIN detail_transaksi dt ON t.id_transaksi = dt.id_transaksi
                    {condition}
                    GROUP BY t.id_transaksi, a.nama_depan, a.nama_belakang
                    ORDER BY t.tanggal_transaksi ASC
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (last != null)
                        cmd.Parameters.AddWithValue("@last", last.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new LaporanTransaksiData
                            {
                                IdTransaksi = reader.GetInt32(0),
                                NamaPelanggan = reader.GetString(1),
                                TanggalTransaksi = reader.GetDateTime(2),
                                TotalHarga = Convert.ToDecimal(reader[3]),
                                TotalItem = reader.GetInt32(4),
                                Status = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return list;
        }

        // ===========================
        // GET TOTAL PEMASUKAN
        // ===========================
        public decimal GetTotalPemasukan(DateTime? last)
        {
            string filter = last != null ? "WHERE t.tanggal_transaksi > @last" : "";

            string query = $@"
                SELECT COALESCE(SUM(dt.subtotal), 0)
                FROM transaksi t
                JOIN detail_transaksi dt ON dt.id_transaksi = t.id_transaksi
                {filter}
            ";

            return Convert.ToDecimal(cmdScalar(_db.connStr, query, last));
        }

        // ===========================
        // GET TOTAL PENGELUARAN
        // ===========================
        public decimal GetTotalPengeluaran(DateTime? last)
        {
            string filter = last != null ? "WHERE tanggal_pengeluaran > @last" : "";

            string query = $@"
                SELECT COALESCE(SUM(jumlah), 0)
                FROM pengeluaran
                {filter}
            ";

            return Convert.ToDecimal(cmdScalar(_db.connStr, query, last));
        }

        // ===========================
        // GET IKAN TERLARIS
        // ===========================
        public string GetIkanTerlaris(DateTime? last)
        {
            string filter = last != null ? "WHERE t.tanggal_transaksi > @last" : "";

            string query = $@"
                SELECT i.jenis_ikan, SUM(dt.jumlah_pembelian) AS total
                FROM detail_transaksi dt
                JOIN transaksi t ON t.id_transaksi = dt.id_transaksi
                JOIN ikan i ON i.id_ikan = dt.id_ikan
                {filter}
                GROUP BY i.jenis_ikan
                ORDER BY total DESC
                LIMIT 1
            ";

            var result = cmdScalar(_db.connStr, query, last);
            return result == null ? "Tidak Ada Penjualan" : result.ToString();
        }

        // ===========================
        // SIMPAN LAPORAN BARU
        // ===========================
        public bool SimpanLaporan(LaporanResult data)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = @"
                    INSERT INTO laporan
                    (waktu_laporan, total_pemasukan, total_pengeluaran, ikan_terlaris)
                    VALUES (@waktu, @pemasukan, @pengeluaran, @ikan)
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@waktu", data.WaktuLaporan);
                    cmd.Parameters.AddWithValue("@pemasukan", data.TotalPemasukan);
                    cmd.Parameters.AddWithValue("@pengeluaran", data.TotalPengeluaran);
                    cmd.Parameters.AddWithValue("@ikan", data.IkanTerlaris);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ===========================
        // HELPER METHOD CMD SCALAR
        // ===========================
        private object cmdScalar(NpgsqlConnection conn, string query)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                return cmd.ExecuteScalar();
            }
        }

        private object cmdScalar(string connStr, string query, DateTime? last)
        {
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    if (last != null)
                        cmd.Parameters.AddWithValue("@last", last.Value);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
