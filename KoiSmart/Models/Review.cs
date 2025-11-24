using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models
{
    public class Review
    {
        public int IdReview { get; set; }
        public string isi_review { get; set; }
        public byte[] gambar { get; set; }
    }
}