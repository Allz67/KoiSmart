using KoiSmart.Database;
using KoiSmart.Interfaces;
using KoiSmart.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace KoiSmart.Controllers
{
    // Pastikan Interface IIkan kamu juga disesuaikan ya (kalo pake interface)
    public class IkanController : IIkan
    {
        private DbContext _dbContext;

        public IkanController()
        {
            _dbContext = new DbContext();
        }

        // --- UBAH 1: Ganti nama jadi 'TambahIkan' & return 'bool' ---
        public bool TambahIkan(Ikan ikan)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();

                    var query = @"INSERT INTO ikan (panjang, gambar_ikan, jenis_ikan, harga, stok, gender, grade)
                                  VALUES (@panjang, @gambar, @jenis, @harga, @stok, @gender, @grade)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@panjang", ikan.panjang);
                        // Handle gambar null biar gak error di DB
                        cmd.Parameters.AddWithValue("@gambar", ikan.gambar_ikan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@jenis", ikan.jenis_ikan);
                        cmd.Parameters.AddWithValue("@harga", ikan.harga);
                        cmd.Parameters.AddWithValue("@stok", ikan.stok);
                        cmd.Parameters.AddWithValue("@gender", ikan.gender.ToString()); // Masuk DB sebagai String
                        cmd.Parameters.AddWithValue("@grade", ikan.grade.ToString());   // Masuk DB sebagai String

                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Berhasil
            }
            catch (Exception ex)
            {
                // Kalau mau debugging, bisa Console.WriteLine(ex.Message);
                return false; // Gagal
            }
        }

        // --- UBAH 2: Sesuaikan Update (Opsional, buat nanti) ---
        public bool UpdateIkan(Ikan ikan)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();

                    var query = @"UPDATE ikan SET panjang=@panjang, gambar_ikan=@gambar, jenis_ikan=@jenis,
                                  harga=@harga, stok=@stok, gender=@gender, grade=@grade
                                  WHERE id_ikan=@id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ikan.IdIkan);
                        cmd.Parameters.AddWithValue("@panjang", ikan.panjang);
                        cmd.Parameters.AddWithValue("@gambar", ikan.gambar_ikan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@jenis", ikan.jenis_ikan);
                        cmd.Parameters.AddWithValue("@harga", ikan.harga);
                        cmd.Parameters.AddWithValue("@stok", ikan.stok);
                        cmd.Parameters.AddWithValue("@gender", ikan.gender.ToString());
                        cmd.Parameters.AddWithValue("@grade", ikan.grade.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // --- UBAH 3: Delete juga return bool ---
        public bool DeleteIkan(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    var query = "DELETE FROM ikan WHERE id_ikan=@id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // --- UBAH 4: Ganti nama jadi 'AmbilSemuaIkan' biar sama kayak Dashboard ---
        public List<Ikan> AmbilSemuaIkan()
        {
            var list = new List<Ikan>();

            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM ikan ORDER BY id_ikan DESC"; // Tambahin ORDER BY biar yg baru nongol diatas

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Ikan
                            {
                                // Pastikan urutan index ini (0,1,2..) SESUAI dengan urutan kolom di Tabel PostgreSQL kamu
                                IdIkan = Convert.ToInt32(reader["id_ikan"]), // Lebih aman pake nama kolom
                                panjang = Convert.ToInt32(reader["panjang"]),
                                gambar_ikan = reader["gambar_ikan"] == DBNull.Value ? null : (byte[])reader["gambar_ikan"],
                                jenis_ikan = reader["jenis_ikan"].ToString(),
                                harga = Convert.ToDecimal(reader["harga"]),
                                stok = Convert.ToInt32(reader["stok"]),
                                gender = Enum.Parse<GenderIkan>(reader["gender"].ToString()),
                                grade = Enum.Parse<GradeIkan>(reader["grade"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error koneksi dll
                // Console.WriteLine(ex.Message);
            }

            return list;
        }

        public Ikan GetById(int id)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();
                string query = "SELECT * FROM ikan WHERE id_ikan=@id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Ikan
                            {
                                IdIkan = Convert.ToInt32(reader["id_ikan"]),
                                panjang = Convert.ToInt32(reader["panjang"]),
                                gambar_ikan = reader["gambar_ikan"] == DBNull.Value ? null : (byte[])reader["gambar_ikan"],
                                jenis_ikan = reader["jenis_ikan"].ToString(),
                                harga = Convert.ToDecimal(reader["harga"]),
                                stok = Convert.ToInt32(reader["stok"]),
                                gender = Enum.Parse<GenderIkan>(reader["gender"].ToString()),
                                grade = Enum.Parse<GradeIkan>(reader["grade"].ToString())
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}