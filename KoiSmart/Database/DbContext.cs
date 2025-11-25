using DotNetEnv;

namespace KoiSmart.Database
{
    public class DbContext
    {
        public string connStr;

        public DbContext()
        {
            // Load .env
            Env.Load(".env");


            string host = Environment.GetEnvironmentVariable("DB_HOST");
            string port = Environment.GetEnvironmentVariable("DB_PORT");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string name = Environment.GetEnvironmentVariable("DB_NAME");
            string ssl = Environment.GetEnvironmentVariable("SSL_Mode") ?? "VerifyFull";

            // Channel_Binding TIDAK BOLEH dimasukkan → hapus!
            connStr =
                $"Host={host};Port={port};Username={user};Password={password};Database={name};SSL Mode={ssl};Trust Server Certificate=true;";
        }
    }
}
