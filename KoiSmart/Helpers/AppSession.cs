using KoiSmart.Models;

namespace KoiSmart.Helpers
{
    public static class AppSession
    {
        public static Akun CurrentUser { get; private set; }

        public static bool IsAuthenticated => CurrentUser != null;

        public static void SetUser(Akun user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}