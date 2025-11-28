using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;

namespace KoiSmart.Views.Components
{
    public partial class CardTransaksiItem : UserControl
    {
        public CardTransaksiItem()
        {
            InitializeComponent();
        }

        // Method ini menerima data satu baris item dari Controller
        public void SetData(RiwayatItem item)
        {
            // 1. SET KOLOM PRODUK (NAMA)
            LblNama.Text = item.NamaIkan;

            // 2. SET KOLOM QTY (DITARUH DI BAWAH NAMA)
            // Asumsi Labelnya bernama LblJumlah (atau LblDetail yang diubah namanya)
            LblQty.Text = $"x{item.Qty}";

            // 3. SET KOLOM HARGA SATUAN (INI KOLOM PALING KANAN)
            LblHargaSatuan.Text = "Rp " + item.HargaSatuan.ToString("N0");

            // Catatan: LblSubtotal diabaikan / dihapus di Designer

            // 4. SET GAMBAR
            if (item.Gambar != null && item.Gambar.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(item.Gambar))
                    {
                        PbGambar.Image = Image.FromStream(ms);
                        PbGambar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch { PbGambar.BackColor = Color.Gray; }
            }
            else
            {
                PbGambar.BackColor = Color.LightGray;
            }
        }
    }
}