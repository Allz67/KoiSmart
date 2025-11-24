using KoiSmart.Models;

namespace KoiSmart.Helpers
{
    public static class AppSession
    {
        // Menyimpan data user yang sedang login
        public static Akun CurrentUser { get; private set; }

        // Mengecek apakah user sedang login
        public static bool IsAuthenticated => CurrentUser != null;

        // Dipanggil setelah login berhasil
        public static void SetUser(Akun user)
        {
            CurrentUser = user;
        }

        // Logout -> reset session
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}