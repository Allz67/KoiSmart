using Npgsql;
using KoiSmart.Database;
using KoiSmart.Models;
using KoiSmart.Helpers;

namespace KoiSmart.Controllers
{
    public class AuthController
    {
        private DbContext _dbContext;

        public AuthController()
        {
            _dbContext = new DbContext();
        }

        // LOGIN 
        public Akun Login(string email, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();

                    string query = @"SELECT id_akun, nama_depan, nama_belakang, username, password, role, email, no_telp
                             FROM akun 
                             WHERE email = @Email";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (var read = cmd.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                string storedPassword = read.GetString(4);

                                if (PasswordHelper.VerifyPassword(password, storedPassword))
                                {
                                    return new Akun
                                    {
                                        IdAkun = read.GetInt32(0),
                                        NamaDepan = read.GetString(1),
                                        NamaBelakang = read.GetString(2),
                                        Username = read.GetString(3),
                                        Password = storedPassword,
                                        Role = Enum.Parse<AkunRole>(read.GetString(5)),
                                        Email = read.GetString(6),
                                        NoTelepon = read.IsDBNull(7) ? "" : read.GetString(7)
                                    };
                                }
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LOGIN ERROR: {ex.Message}", "Error");
                return null;
            }
        }

        // REGISTER 
        public bool Register(Akun akun)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO akun 
                                    (nama_depan, nama_belakang, username, password, role, email, no_telp)
                                    VALUES (@namaDepan, @namaBelakang, @username, @password, @role, @Email, @NoTelp)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        string hashedPassword = PasswordHelper.HashPassword(akun.Password);

                        cmd.Parameters.AddWithValue("@namaDepan", akun.NamaDepan);
                        cmd.Parameters.AddWithValue("@namaBelakang", akun.NamaBelakang);
                        cmd.Parameters.AddWithValue("@username", akun.Username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        // Default role customer
                        cmd.Parameters.AddWithValue("@role", AkunRole.customer.ToString());

                        cmd.Parameters.AddWithValue("@Email", akun.Email);
                        cmd.Parameters.AddWithValue("@NoTelp", akun.NoTelepon);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"REGISTER ERROR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
