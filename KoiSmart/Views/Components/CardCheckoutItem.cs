using KoiSmart.Models;
using System;
using System.Drawing;
using System.IO; 
using System.Windows.Forms;

namespace KoiSmart.Views.Components
{
    public partial class CardCheckoutItem : UserControl
    {
        public CardCheckoutItem()
        {
            InitializeComponent();
        }

        public void SetData(CartItem item)
        {
            LblNama.Text = item.Ikan.jenis_ikan;
            LblDetail.Text = $"{item.Ikan.gender}, {item.Ikan.grade}, {item.Ikan.panjang} cm";

            LblHargaSatuan.Text = "Rp " + item.Ikan.harga.ToString("N0");

            LblQty.Text = item.Quantity.ToString();

            LblSubtotal.Text = "Rp " + item.Subtotal.ToString("N0");

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
                    PbGambar.BackColor = Color.Gray;
                }
            }
            else
            {
                PbGambar.BackColor = Color.LightGray;
            }
        }
        public void SetDataRiwayat(TransaksiItem item)
        {

            LblNama.Text = item.NamaIkan;
            LblDetail.Text = $"{item.Gender}, {item.Grade}, {item.Panjang} cm";

            LblHargaSatuan.Text = "Rp " + item.HargaSatuan.ToString("N0");

            LblQty.Text = item.Qty.ToString();
            LblSubtotal.Text = "Rp " + item.Subtotal.ToString("N0");
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