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
        public void SetData(TransaksiItem item)
        {

            LblNama.Text = item.NamaIkan;

            LblQty.Text = $"x{item.Qty}";
            LblHargaSatuan.Text = "Rp " + item.HargaSatuan.ToString("N0");
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