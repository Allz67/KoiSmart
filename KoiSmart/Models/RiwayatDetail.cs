using System;
using System.Collections.Generic;

namespace KoiSmart.Models
{
    public class RiwayatDetail
    {
        public int IdTransaksi { get; set; }
        public string NamaCustomer { get; set; }
        public string NoTelp { get; set; }
        public string Alamat { get; set; }
        public string JenisPembelian { get; set; }
        public int Jumlah { get; set; }
        public decimal Subtotal { get; set; }
        public string Status { get; set; }
        public DateTime TanggalTransaksi { get; set; }
    }
}