using KoiSmart.Database;
using KoiSmart.Interfaces;
using KoiSmart.Models;
using Npgsql;

namespace KoiSmart.Controllers
{
    public class IkanController : IIkan
    {
        private DbContext _dbContext;

        public IkanController()
        {
            _dbContext = new DbContext();
        }

        public void CreateIkan(Ikan ikan)
        {
            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();

                var query = @"INSERT INTO ikan (panjang, gambar_ikan, jenis_ikan, harga, stok, gender, grade)
                              VALUES (@panjang, @gambar, @jenis, @harga, @stok, @gender, @grade)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@panjang", ikan.panjang);
                    cmd.Parameters.AddWithValue("@gambar", ikan.gambar_ikan);
                    cmd.Parameters.AddWithValue("@jenis", ikan.jenis_ikan);
                    cmd.Parameters.AddWithValue("@harga", ikan.harga);
                    cmd.Parameters.AddWithValue("@stok", ikan.stok);
                    cmd.Parameters.AddWithValue("@gender", ikan.gender.ToString());
                    cmd.Parameters.AddWithValue("@grade", ikan.grade.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateIkan(Ikan ikan)
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
                    cmd.Parameters.AddWithValue("@gambar", ikan.gambar_ikan);
                    cmd.Parameters.AddWithValue("@jenis", ikan.jenis_ikan);
                    cmd.Parameters.AddWithValue("@harga", ikan.harga);
                    cmd.Parameters.AddWithValue("@stok", ikan.stok);
                    cmd.Parameters.AddWithValue("@gender", ikan.gender.ToString());
                    cmd.Parameters.AddWithValue("@grade", ikan.grade.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteIkan(int id)
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
        }

        public List<Ikan> GetAllIkan()
        {
            var list = new List<Ikan>();

            using (var conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();

                string query = "SELECT * FROM ikan";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Ikan
                        {
                            IdIkan = reader.GetInt32(0),
                            panjang = reader.GetInt32(1),
                            gambar_ikan = reader["gambar_ikan"] as byte[],
                            jenis_ikan = reader.GetString(3),
                            harga = Convert.ToDecimal(reader[4]),
                            stok = reader.GetInt32(5),
                            gender = Enum.Parse<GenderIkan>(reader.GetString(6)),
                            grade = Enum.Parse<GradeIkan>(reader.GetString(7))
                        });
                    }
                }
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
                                IdIkan = reader.GetInt32(0),
                                panjang = reader.GetInt32(1),
                                gambar_ikan = reader["gambar_ikan"] as byte[],
                                jenis_ikan = reader.GetString(3),
                                harga = Convert.ToDecimal(reader[4]),
                                stok = reader.GetInt32(5),
                                gender = Enum.Parse<GenderIkan>(reader.GetString(6)),
                                grade = Enum.Parse<GradeIkan>(reader.GetString(7))
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
