using KoiSmart.Models;
using System;
using System.Drawing;
using System.IO; // Wajib ada buat MemoryStream
using System.Windows.Forms;

namespace KoiSmart.Views.Components
{
    public partial class CardCheckoutItem : UserControl
    {
        public CardCheckoutItem()
        {
            InitializeComponent();
        }

        // Method ini HARUS ada DI DALAM kurung kurawal class CardCheckoutItem
        public void SetData(CartItem item)
        {
            // Kolom 1: Produk
            LblNama.Text = item.Ikan.jenis_ikan;
            LblDetail.Text = $"{item.Ikan.gender}, {item.Ikan.grade}, {item.Ikan.panjang} cm";

            // Kolom 2: Harga Satuan
            LblHargaSatuan.Text = "Rp " + item.Ikan.harga.ToString("N0");

            // Kolom 3: Jumlah
            LblQty.Text = item.Quantity.ToString();

            // Kolom 4: Subtotal
            LblSubtotal.Text = "Rp " + item.Subtotal.ToString("N0");

            // Gambar (Dengan Pengaman Try-Catch)
            if (item.Ikan.gambar_ikan != null && item.Ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(item.Ikan.gambar_ikan))
                    {
                        PbGambar.Image = Image.FromStream(ms);
                        PbGambar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    // Kalau gambar error, kasih warna abu-abu aja
                    PbGambar.BackColor = Color.Gray;
                }
            }
            else
            {
                // Kalau gak ada gambar
                PbGambar.BackColor = Color.LightGray;
            }
        }
    } // <--- Tutup Class disini
}