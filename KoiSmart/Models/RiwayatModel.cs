using System;
using System.Collections.Generic;

namespace KoiSmart.Models
{
    // [1] KELAS BAPAK: RiwayatTransaksi (Wadah Besarnya)
    public class RiwayatTransaksi
    {
        public int IdTransaksi { get; set; }
        public DateTime Tanggal { get; set; }
        public string Status { get; set; }
        public decimal TotalBelanja { get; set; }

        // List Anak-anaknya
        public List<RiwayatItem> Items { get; set; } = new List<RiwayatItem>();
    }

    // [2] KELAS ANAK: RiwayatItem (Detail Barang per Baris)
    public class RiwayatItem
    {
        public string NamaIkan { get; set; }
        public int Qty { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal Subtotal => Qty * HargaSatuan;
        public byte[] Gambar { get; set; }

        // Untuk syarat Overriding
        public override string ToString()
        {
            return $"{NamaIkan} x {Qty}";
        }
    }
}