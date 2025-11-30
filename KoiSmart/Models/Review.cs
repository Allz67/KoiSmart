using System;
using System.Collections.Generic;

namespace KoiSmart.Models.Review
{
    public class ReviewBaseData
    {
        public int IdReview { get; set; }
        public string NamaPembeli { get; set; }
        public string IsiReview { get; set; }
        public byte[] Gambar { get; set; }
        public int IdTransaksi { get; set; }
    }
    public class ReviewData : ReviewBaseData
    {
        public DateTime TanggalReview { get; set; }
    }
    public class ReviewAdmData : ReviewBaseData
    {
        public DateTime TanggalReview { get; set; }
        public byte[] GambarReview { get => Gambar; set => Gambar = value; } 
        public List<Models.TransaksiItem> ItemsDibeli { get; set; } = new List<Models.TransaksiItem>();
    }
}