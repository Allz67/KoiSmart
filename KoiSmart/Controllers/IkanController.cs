using KoiSmart.Database;
using KoiSmart.Interfaces;
using KoiSmart.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace KoiSmart.Controllers
{
    public class IkanController : IIkan
    {
        private DbContext _dbContext;

        public IkanController()
        {
            _dbContext = new DbContext();
        }

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
            catch (Exception ex)
            {
                Debug.WriteLine("TambahIkan error: " + ex);
                MessageBox.Show("Gagal menyimpan ke database. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }

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
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateIkan error: " + ex);
                MessageBox.Show("Gagal mengupdate ke database. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
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
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteIkan error: " + ex);
                MessageBox.Show("Gagal menghapus dari database. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<Ikan> AmbilSemuaIkan()
        {
            var list = new List<Ikan>();

            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();

                    // Prefer to fetch only non-deleted rows if column exists.
                    // If the database does not have is_delete column, fallback to selecting all rows.
                    string preferQuery = "SELECT * FROM ikan WHERE is_delete = false ORDER BY id_ikan DESC";
                    string fallbackQuery = "SELECT * FROM ikan ORDER BY id_ikan DESC";

                    string queryToUse = preferQuery;
                    try
                    {
                        using (var cmd = new NpgsqlCommand(queryToUse, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Ikan
                                {
                                    IdIkan = Convert.ToInt32(reader["id_ikan"]), 
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
                    catch (PostgresException pex)
                    {
                        // Likely column is_delete doesn't exist — fallback to simple query
                        Debug.WriteLine("AmbilSemuaIkan: preferQuery failed, falling back. PostgresException: " + pex.Message);
                        queryToUse = fallbackQuery;

                        using (var cmd = new NpgsqlCommand(queryToUse, conn))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Ikan
                                {
                                    IdIkan = Convert.ToInt32(reader["id_ikan"]), 
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AmbilSemuaIkan error: " + ex);
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