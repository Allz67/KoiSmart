using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models
{
    public class Ikan
    {
        public int IdIkan { get; set; }
        public int panjang { get; set; }
        public byte[] gambar_ikan { get; set; }
        public string jenis_ikan { get; set; }
        public decimal harga { get; set; }
        public int stok { get; set; }
        public GenderIkan gender { get; set; }
        public GradeIkan grade { get; set; }
    }
    public enum GenderIkan
    {
        Jantan, Betina
    }
    public enum GradeIkan
    {
        A, B, C
    }
}
