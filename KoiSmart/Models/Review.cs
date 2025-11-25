using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models.Review
    {
        public class ReviewData
        {
            public int IdReview { get; set; }
            public string NamaPembeli { get; set; }
            public string IsiReview { get; set; }
            public byte[] Gambar { get; set; }
            public int IdTransaksi { get; set; }
        }
    }