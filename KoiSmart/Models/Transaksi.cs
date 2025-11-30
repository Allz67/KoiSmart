using System;
using System.Collections.Generic;

namespace KoiSmart.Models
{

    public abstract class BaseModel
    {
        public abstract int Id { get; set; }

        public abstract string GetTableName();
    }
    public enum Status
    {
        Pending, Selesai, Dibatalkan, Terkonfirmasi, Ditolak, PengajuanPembatalan
    }
    public class TransaksiHeader : BaseModel
    {
        public override int Id { get; set; }

        public int IdTransaksi { get => Id; set => Id = value; } 
        public DateTime TanggalTransaksi { get; set; }
        public int IdAkun { get; set; }
        public int? IdReview { get; set; }
        public Status StatusTransaksi { get; set; }
        public decimal TotalHarga { get; set; }
        public byte[] BuktiPembayaran { get; set; }

        public override string GetTableName()
        {
            return "transaksi";
        }
    }
    public class TransaksiItem
    {
        public int IdDetailTransaksi { get; set; }
        public int IdTransaksi { get; set; }
        public int IdIkan { get; set; }
        public int Qty { get; set; }
        public decimal Subtotal { get; set; }
        public string NamaIkan { get; set; }
        public decimal HargaSatuan { get; set; }
        public byte[] Gambar { get; set; }
        public int Panjang { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }

        public override string ToString() => $"{NamaIkan} x {Qty}";
    }
    public class RiwayatTransaksi
    {
        public int IdTransaksi { get; set; }
        public int IdAkun { get; set; }
        public string Username { get; set; } 
        public DateTime Tanggal { get; set; }
        public string Status { get; set; }
        public decimal TotalBelanja { get; set; }
        public byte[] BuktiPembayaran { get; set; }
        public List<TransaksiItem> Items { get; set; } = new List<TransaksiItem>();
    }
}