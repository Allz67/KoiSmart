using KoiSmart.Database;
using KoiSmart.Helpers;
using KoiSmart.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Diagnostics;

namespace KoiSmart.Controllers
{
    public interface IDbController<T> where T : Models.Transaksi
    {
        T GetById(int id);
    }

    public class TransaksiController : IDbController<Transaksi>
    {
        private readonly DbContext _dbContext;
        private const int DefaultCommandTimeoutSeconds = 60;
        private static readonly List<string> StatusFinal = new List<string> { "Dibatalkan", "Ditolak", "Selesai" };

        public TransaksiController()
        {
            _dbContext = new DbContext();
        }
        public Transaksi GetById(int id)
        {
            return GetDetailTransaksi(id);
        }
        public Transaksi GetDetailTransaksi(int idTransaksi)
        {
            Transaksi trx = null;

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();
                    string query = $@"
                        SELECT t.id_transaksi, t.tanggal_transaksi, t.status_transaksi, t.total_harga, t.bukti_pembayaran, t.id_akun,
                               a.username,
                               d.id_ikan, d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal,
                               i.panjang, i.gender, i.grade
                        FROM transaksi t
                        JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                        JOIN ikan i ON d.id_ikan = i.id_ikan
                        JOIN akun a ON t.id_akun = a.id_akun 
                        WHERE t.id_transaksi = @idTrx";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = DefaultCommandTimeoutSeconds;
                        cmd.Parameters.AddWithValue("@idTrx", idTransaksi);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (trx == null)
                                {
                                    trx = new Transaksi
                                    {
                                        IdTransaksi = idTransaksi,
                                        IdAkun = Convert.ToInt32(reader["id_akun"]),
                                        Username = reader["username"].ToString(),
                                        Tanggal = reader.IsDBNull(reader.GetOrdinal("tanggal_transaksi")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("tanggal_transaksi")),
                                        Status = reader["status_transaksi"].ToString(),
                                        TotalBelanja = reader.IsDBNull(reader.GetOrdinal("total_harga")) ? 0m : Convert.ToDecimal(reader["total_harga"]),
                                        BuktiPembayaran = reader["bukti_pembayaran"] == DBNull.Value ? null : (byte[])reader["bukti_pembayaran"],
                                        Items = new List<TransaksiItem>()
                                    };
                                }
                                trx.Items.Add(new TransaksiItem
                                {
                                    IdIkan = Convert.ToInt32(reader["id_ikan"]),
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
                    System.Diagnostics.Debug.WriteLine("Gagal memuat detail transaksi: " + ex.Message);
                    MessageBox.Show("Gagal memuat detail transaksi: " + ex.Message, "Database Error");
                }
            }
            return trx;
        }
        public List<Transaksi> GetActiveTransactions(int idUser)
        {
            string statusExclusionClause = $" AND t.status_transaksi NOT IN ('{string.Join("','", StatusFinal)}')";
            return GetFilteredTransactions(idUser, statusExclusionClause, true);
        }
        public List<Transaksi> GetHistoricalTransactions(int idUser)
        {
            string statusInclusionClause = $" AND t.status_transaksi IN ('{string.Join("','", StatusFinal)}')";
            return GetFilteredTransactions(idUser, statusInclusionClause, true);
        }
        public List<Transaksi> GetAllTransactions(List<string> statusList = null)
        {
            string statusFilterClause = string.Empty;
            if (statusList != null && statusList.Count > 0)
            {
                string statusParamsSql = string.Join(",", statusList.Select((s, i) => $"@status_transaksi{i}"));
                statusFilterClause = $" AND t.status_transaksi IN ({statusParamsSql})";
            }
            return GetFilteredTransactions(0, statusFilterClause, false, statusList);
        }
        private List<Transaksi> GetFilteredTransactions(int idUser, string filterClause, bool isUserSpecific, List<string> statusList = null)
        {
            var listTrx = new List<Transaksi>();

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();
                    string joinAccount = !isUserSpecific ? "JOIN akun a ON t.id_akun = a.id_akun" : "";
                    string userWhereClause = isUserSpecific ? "t.id_akun = @uid" : "1=1";

                    string query = $@"
                        SELECT t.id_transaksi, t.tanggal_transaksi, t.status_transaksi, t.total_harga, t.bukti_pembayaran, t.id_akun,
                                {(isUserSpecific ? "'' AS username," : "a.username,")}
                                d.id_ikan, d.jumlah_pembelian, i.jenis_ikan, i.harga, i.gambar_ikan, d.subtotal,
                                i.panjang, i.gender, i.grade
                        FROM transaksi t
                        JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                        JOIN ikan i ON d.id_ikan = i.id_ikan
                        {joinAccount}
                        WHERE {userWhereClause}
                        {filterClause} 
                        ORDER BY t.tanggal_transaksi DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = DefaultCommandTimeoutSeconds;
                        if (isUserSpecific)
                        {
                            cmd.Parameters.AddWithValue("@uid", idUser);
                        }

                        if (statusList != null && statusList.Count > 0)
                        {
                            for (int i = 0; i < statusList.Count; i++)
                            {
                                cmd.Parameters.AddWithValue($"@status_transaksi{i}", statusList[i]);
                            }
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idTrx = Convert.ToInt32(reader["id_transaksi"]);
                                var trx = listTrx.FirstOrDefault(x => x.IdTransaksi == idTrx);

                                if (trx == null)
                                {
                                    trx = new Transaksi
                                    {
                                        IdTransaksi = idTrx,
                                        IdAkun = Convert.ToInt32(reader["id_akun"]),
                                        Username = isUserSpecific ? "Pengguna" : reader["username"].ToString(),
                                        Tanggal = reader.GetDateTime(reader.GetOrdinal("tanggal_transaksi")),
                                        Status = reader["status_transaksi"].ToString(),
                                        TotalBelanja = Convert.ToDecimal(reader["total_harga"]),
                                        BuktiPembayaran = reader["bukti_pembayaran"] == DBNull.Value ? null : (byte[])reader["bukti_pembayaran"],
                                        Items = new List<TransaksiItem>()
                                    };
                                    listTrx.Add(trx);
                                }
                                trx.Items.Add(new TransaksiItem
                                {
                                    IdIkan = Convert.ToInt32(reader["id_ikan"]),
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
                    System.Diagnostics.Debug.WriteLine("Gagal memuat list transaksi: " + ex.Message);
                    MessageBox.Show("Gagal memuat list transaksi: " + ex.Message, "Database Error");
                }
            }
            return listTrx;
        }

        public bool UpdateStatusTransaksi(int idTransaksi, string newStatus)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE transaksi SET status_transaksi = @status WHERE id_transaksi = @idTrans";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = DefaultCommandTimeoutSeconds;
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@idTrans", idTransaksi);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal update status transaksi: " + ex.Message, "Database Error");
                    return false;
                }
            }
        }

        public bool BuatPesanan(int idAkun, byte[] buktiPembayaran, IReadOnlyList<CartItem> items)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
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
                            var buktiParam = new NpgsqlParameter("@bukti", NpgsqlDbType.Bytea);
                            buktiParam.Value = buktiPembayaran ?? (object)DBNull.Value;
                            cmdHeader.Parameters.Add(buktiParam);

                            idTransaksiBaru = (int)cmdHeader.ExecuteScalar();
                        }

                        foreach (var item in items)
                        {
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
                            Debug.WriteLine("Rollback failed: " + rbEx);
                        }

                        Debug.WriteLine("BuatPesanan Error: " + ex);
                        MessageBox.Show("Gagal membuat pesanan: " + ex.Message, "Database Error");
                        return false;
                    }
                }
            }
        }
    }
}