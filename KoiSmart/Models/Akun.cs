using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models
{
    public class Akun
    {
        public int IdAkun { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NoTelepon { get; set; }
        public AkunRole Role { get; set; }
    }

    public enum AkunRole
    {
        admin, customer
    }
}