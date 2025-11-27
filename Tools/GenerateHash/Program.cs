using System;
using KoiSmart.Helpers;

class Program
{
    static void Main()
    {
        // Ganti "admin123" dengan password yang ingin Anda pakai
        var hash = PasswordHelper.HashPassword("admin123");
        Console.WriteLine(hash);
        Console.WriteLine();
        Console.WriteLine("Tekan Enter untuk keluar...");
        Console.ReadLine();
    }
}