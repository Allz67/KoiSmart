using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiSmart.Models
{
    public class LaporanTransaksiData
    {
        public int IdTransaksi { get; set; }
        public string NamaPelanggan { get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public decimal TotalHarga { get; set; }
        public int TotalItem { get; set; }
        public string Status { get; set; }
    }

    public class LaporanResult
    {
        public DateTime WaktuLaporan { get; set; }
        public decimal TotalPemasukan { get; set; }
        public decimal TotalPengeluaran { get; set; }
        public string IkanTerlaris { get; set; }
    }
}
