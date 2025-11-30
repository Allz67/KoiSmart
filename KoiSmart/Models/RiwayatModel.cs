using System;
using System.Collections.Generic;

namespace KoiSmart.Models
{
    public class RiwayatTransaksi
    {
        public int IdTransaksi { get; set; }
        public DateTime Tanggal { get; set; }
        public string Status { get; set; }
        public decimal TotalBelanja { get; set; }

        public byte[] BuktiPembayaran { get; set; }

        public List<RiwayatItem> Items { get; set; } = new List<RiwayatItem>();
    }
    public class RiwayatItem
    {
        public int IdIkan { get; set; }             
        public string NamaIkan { get; set; }
        public int Qty { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal Subtotal => Qty * HargaSatuan;
        public byte[] Gambar { get; set; }
        public int Panjang { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public override string ToString()
        {
            return $"{NamaIkan} x {Qty}";
        }
    }
}