using Npgsql;
using KoiSmart.Database;
using KoiSmart.Helpers;
using KoiSmart.Models.Review;
using System;
using System.Collections.Generic;

namespace KoiSmart.Controllers
{
    public class ReviewController
    {
        private DbContext _db;

        public ReviewController()
        {
            _db = new DbContext();
        }

        // ================================
        // CUSTOMER: TAMBAH REVIEW BARU
        // ================================
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
                            INSERT INTO review (isi_review, gambar)
                            VALUES (@isi, @gambar)
                            RETURNING id_review;
                        ";

                        int idReview;
                        using (var cmd = new NpgsqlCommand(q1, conn))
                        {
                            cmd.Parameters.AddWithValue("@isi", isi);
                            cmd.Parameters.AddWithValue("@gambar", (object)gambar ?? DBNull.Value);

                            idReview = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string q2 = @"
                            UPDATE transaksi 
                            SET id_review = @id
                            WHERE id_transaksi = @trans
                        ";

                        using (var cmd = new NpgsqlCommand(q2, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idReview);
                            cmd.Parameters.AddWithValue("@trans", idTransaksi);
                            cmd.ExecuteNonQuery();
                        }

                        trx.Commit();
                        return true;
                    }
                    catch
                    {
                        trx.Rollback();
                        return false;
                    }
                }
            }
        }

        // ================================
        // CUSTOMER: CEK APAKAH BISA REVIEW
        // ================================
        public bool CanReview(int idTransaksi)
        {
            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = "SELECT id_review FROM transaksi WHERE id_transaksi = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idTransaksi);
                    var result = cmd.ExecuteScalar();
                    return result == DBNull.Value || result == null;
                }
            }
        }

        // ================================
        // ADMIN: GET SEMUA REVIEW
        // ================================
        public List<ReviewData> GetAllReview()
        {
            var list = new List<ReviewData>();

            using (var conn = new NpgsqlConnection(_db.connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        r.id_review,
                        a.nama_depan || ' ' || a.nama_belakang AS nama,
                        r.isi_review,
                        r.gambar,
                        t.id_transaksi
                    FROM review r
                    JOIN transaksi t ON t.id_review = r.id_review
                    JOIN akun a ON a.id_akun = t.id_akun
                    ORDER BY r.id_review DESC
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
                            IdTransaksi = reader.GetInt32(4)
                        });
                    }
                }
            }

            return list;
        }
    }
}