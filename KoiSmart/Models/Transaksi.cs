using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models
{
    public class Transaksi
    {
        public int IdTransaksi { get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public int IdAkun { get; set; }
        public int IdReview { get; set; }
        public Status StatusTransaksi { get; set; }
        public decimal TotalHarga { get; set; }
    }
    public enum Status
    {
        Pending, Selesai, Dibatalkan
    }
}