using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models; // Wajib: Akses Model RiwayatItem

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
            // 1. SET NAMA PRODUK (LblNama)
            // Asumsi ini label di atas
            LblNama.Text = item.NamaIkan;

            // 2. SET JUMLAH (LblJumlah)
            // Asumsi ini label di bawah nama, formatnya "x2"
            LblQty.Text = $"x{item.Qty}";

            // 3. SET HARGA SATUAN (LblHargaSatuan)
            // Ini adalah kolom paling kanan (Harga per ekor)
            LblHargaSatuan.Text = "Rp " + item.HargaSatuan.ToString("N0");

            // 4. SET GAMBAR
            if (item.Gambar != null && item.Gambar.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(item.Gambar))
                    {
                        PbGambar.Image = Image.FromStream(ms);
                        PbGambar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    PbGambar.BackColor = Color.Gray;
                }
            }
            else
            {
                PbGambar.BackColor = Color.LightGray;
            }
        }
    }
}