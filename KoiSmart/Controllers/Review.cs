using Npgsql;
using KoiSmart.Database;
using KoiSmart.Models.Review;

namespace KoiSmart.Controllers
{
    public class ReviewController
    {
        private DbContext _db;

        public ReviewController()
        {
            _db = new DbContext();
        }

        public bool AddReview(int idTransaksi, string isi, byte[] gambar)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                using (var trx = conn.BeginTransaction())
                {
                    try
                    {
                        string q1 = @"
                            INSERT INTO review (isi_review, gambar, tanggal_review)
                            VALUES (@isi, @gambar, @tanggal)
                            RETURNING id_review;
                        ";

                        int idReview;
                        using (var cmd = new NpgsqlCommand(q1, conn, trx)) 
                        {
                            cmd.Parameters.AddWithValue("@isi", isi);
                            cmd.Parameters.AddWithValue("@gambar", (object)gambar ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@tanggal", DateTime.Now);
                            idReview = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        string q2 = @"
                            UPDATE transaksi 
                            SET id_review = @id
                            WHERE id_transaksi = @trans";

                        using (var cmd = new NpgsqlCommand(q2, conn, trx)) 
                        {
                            cmd.Parameters.AddWithValue("@id", idReview);
                            cmd.Parameters.AddWithValue("@trans", idTransaksi);
                            cmd.ExecuteNonQuery();
                        }

                        trx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menambahkan review: " + ex.Message, "Database Error");
                        trx.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteReview(int idReview)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                using (var trx = conn.BeginTransaction())
                {
                    try
                    {
                        string q1 = "UPDATE transaksi SET id_review = NULL WHERE id_review = @id";
                        using (var cmd = new NpgsqlCommand(q1, conn, trx))
                        {
                            cmd.Parameters.AddWithValue("@id", idReview);
                            cmd.ExecuteNonQuery();
                        }
                        string q2 = "DELETE FROM review WHERE id_review = @id";
                        using (var cmd = new NpgsqlCommand(q2, conn, trx))
                        {
                            cmd.Parameters.AddWithValue("@id", idReview);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            trx.Commit();
                            return rowsAffected > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal menghapus review: " + ex.Message, "Database Error");
                        trx.Rollback();
                        return false;
                    }
                }
            }
        }
        public int? GetReviewId(int idTransaksi)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_review FROM transaksi WHERE id_transaksi = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        var result = cmd.ExecuteScalar();

                        return result == DBNull.Value || result == null ? (int?)null : Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error saat mendapatkan ID Review: " + ex.Message, "Database Error");
                    return null;
                }
            }
        }
        public ReviewData GetReviewById(int idReview)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                string query = @"
                    SELECT r.id_review,
                           a.username AS nama_pembeli, 
                           r.isi_review,
                           r.gambar,
                           r.tanggal_review, -- Kolom tanggal review
                           t.id_transaksi
                    FROM review r
                    JOIN transaksi t ON t.id_review = r.id_review
                    JOIN akun a ON a.id_akun = t.id_akun
                    WHERE r.id_review = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idReview);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ReviewData
                            {
                                IdReview = reader.GetInt32(0),
                                NamaPembeli = reader.GetString(1),
                                IsiReview = reader.GetString(2),
                                Gambar = reader["gambar"] as byte[],
                                TanggalReview = reader.GetDateTime(4), 
                                IdTransaksi = reader.GetInt32(5)
                            };
                        }
                        return null;
                    }
                }
            }
        }
        public List<ReviewData> GetAllReview()
        {
            var list = new List<ReviewData>();

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        r.id_review,
                        a.username AS nama_pembeli,
                        r.isi_review,
                        r.gambar,
                        r.tanggal_review, -- Kolom tanggal review
                        t.id_transaksi
                    FROM review r
                    JOIN transaksi t ON t.id_review = r.id_review
                    JOIN akun a ON a.id_akun = t.id_akun
                    ORDER BY r.tanggal_review DESC
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ReviewData
                        {
                            IdReview = reader.GetInt32(0),
                            NamaPembeli = reader.GetString(1),
                            IsiReview = reader.GetString(2),
                            Gambar = reader["gambar"] as byte[],
                            TanggalReview = reader.GetDateTime(4), 
                            IdTransaksi = reader.GetInt32(5)
                        });
                    }
                }
            }
            return list;
        }
    }
}