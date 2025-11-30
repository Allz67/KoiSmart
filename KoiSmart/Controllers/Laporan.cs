using Npgsql;
using KoiSmart.Database;
using KoiSmart.Models;

namespace KoiSmart.Controllers
{
    public class LaporanController
    {
        private DbContext _db;

        public LaporanController()
        {
            _db = new DbContext();
        }
        public List<PeriodeLaporanDTO> GetAvailableReportPeriods()
        {
            var availablePeriods = new List<PeriodeLaporanDTO>();

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT 
                            EXTRACT(YEAR FROM tanggal_transaksi) AS tahun,
                            EXTRACT(MONTH FROM tanggal_transaksi) AS bulan
                        FROM transaksi
                        WHERE status_transaksi IN ('Selesai', 'Terkonfirmasi') -- Hanya hitung transaksi yang berhasil
                        ORDER BY tahun DESC, bulan DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int tahun = Convert.ToInt32(reader["tahun"]);
                                int bulan = Convert.ToInt32(reader["bulan"]);

                                availablePeriods.Add(new PeriodeLaporanDTO
                                {
                                    Tahun = tahun,
                                    Bulan = bulan,
                                    NamaBulan = new DateTime(tahun, bulan, 1).ToString("MMMM") 
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Gagal memuat periode laporan: " + ex.Message);
                }
            }
            return availablePeriods;
        }
        private (string Filter, NpgsqlParameter[] Parameters) GetPeriodFilter(int? bulan, int? tahun)
        {
            if (bulan.HasValue && tahun.HasValue)
            {
                DateTime startDate = new DateTime(tahun.Value, bulan.Value, 1);
                DateTime endDate = startDate.AddMonths(1);

                string filter = "WHERE t.tanggal_transaksi >= @startDate AND t.tanggal_transaksi < @endDate";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@startDate", startDate),
                    new NpgsqlParameter("@endDate", endDate)
                };
                return (filter, parameters);
            }
            return (string.Empty, Array.Empty<NpgsqlParameter>());
        }
        public List<LaporanTransaksiData> GetTransaksiDataByPeriod(int bulan, int tahun)
        {
            List<LaporanTransaksiData> list = new List<LaporanTransaksiData>();
            var filterResult = GetPeriodFilter(bulan, tahun);

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = $@"
                     SELECT 
                         t.id_transaksi,
                         a.username AS nama_pelanggan, -- Ganti a.nama_depan || ' ' || a.nama_belakang jika kolom tidak ada
                         t.tanggal_transaksi,
                         t.total_harga, -- Lebih baik pakai kolom total_harga dari header jika sudah benar
                         SUM(dt.jumlah_pembelian) AS total_item,
                         t.status_transaksi
                     FROM transaksi t
                     JOIN akun a ON t.id_akun = a.id_akun
                     JOIN detail_transaksi dt ON t.id_transaksi = dt.id_transaksi
                     {filterResult.Filter}
                     GROUP BY t.id_transaksi, a.username, t.tanggal_transaksi, t.total_harga, t.status_transaksi
                     ORDER BY t.tanggal_transaksi ASC
                 ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(filterResult.Parameters);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new LaporanTransaksiData
                            {
                                IdTransaksi = reader.GetInt32(0),
                                NamaPelanggan = reader["nama_pelanggan"].ToString(),
                                TanggalTransaksi = reader.GetDateTime(2),
                                TotalHarga = Convert.ToDecimal(reader["total_harga"]), 
                                TotalItem = Convert.ToInt32(reader["total_item"]),
                                Status = reader["status_transaksi"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        private object cmdScalarByPeriod(string queryTemplate, int? bulan, int? tahun, string countColumn = null)
        {
            var filterResult = GetPeriodFilter(bulan, tahun);
            string finalQuery = queryTemplate.Replace("{filter}", filterResult.Filter);

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(finalQuery, conn))
                {
                    cmd.Parameters.AddRange(filterResult.Parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public decimal GetTotalPemasukan(int? bulan, int? tahun)
        {
            string query = $@"
                SELECT COALESCE(SUM(t.total_harga), 0)
                FROM transaksi t
                {{filter}}
                AND t.status_transaksi IN ('Selesai', 'Terkonfirmasi')
            ";
            return Convert.ToDecimal(cmdScalarByPeriod(query, bulan, tahun));
        }

        public decimal GetTotalPengeluaran(int? bulan, int? tahun)
        {
            string query = $@"
                SELECT COALESCE(SUM(jumlah), 0)
                FROM pengeluaran p
                {{filter}}
            ";
            return Convert.ToDecimal(cmdScalarByPeriod(query, bulan, tahun));
        }

        public string GetIkanTerlaris(int? bulan, int? tahun)
        {
            string query = $@"
                SELECT i.jenis_ikan
                FROM detail_transaksi dt
                JOIN transaksi t ON t.id_transaksi = dt.id_transaksi
                JOIN ikan i ON i.id_ikan = dt.id_ikan
                {{filter}}
                AND t.status_transaksi IN ('Selesai', 'Terkonfirmasi')
                GROUP BY i.jenis_ikan
                ORDER BY SUM(dt.jumlah_pembelian) DESC
                LIMIT 1
            ";

            var result = cmdScalarByPeriod(query, bulan, tahun);
            return result == null || result == DBNull.Value ? "Tidak Ada Penjualan" : result.ToString();
        }
        public decimal GetTotalItemTerjual(int? bulan, int? tahun)
        {
            string query = $@"
        SELECT COALESCE(SUM(dt.jumlah_pembelian), 0)
        FROM detail_transaksi dt
        JOIN transaksi t ON t.id_transaksi = dt.id_transaksi
        {{filter}}
        AND t.status_transaksi IN ('Selesai', 'Terkonfirmasi')
    ";
            return Convert.ToDecimal(cmdScalarByPeriod(query, bulan, tahun));
        }
    }
}