using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;

namespace KoiSmart.Views.Components
{
    public partial class CardIkanCust : UserControl
    {
        public Ikan DataIkan { get; private set; }

        public Button BtnLihat => BttnCardLihat;

        public CardIkanCust()
        {
            InitializeComponent();
        }

        public void SetData(Ikan ikan)
        {
            DataIkan = ikan;


            LbCardNamaIkan.BackColor = Color.Transparent; 
            LbCardHargaIkan.BackColor = Color.Transparent;
            LbStok.BackColor = Color.Transparent;

            LbCardNamaIkan.ForeColor = Color.Black;
            LbCardHargaIkan.ForeColor = Color.Black; 
            LbStok.ForeColor = Color.Black;

            LbCardNamaIkan.Text = ikan.jenis_ikan;
            LbCardHargaIkan.Text = "Rp " + ikan.harga.ToString("N0");
            LbStok.Text = "Stok: " + ikan.stok.ToString();

            if (ikan.stok > 0)
                LbStok.Text = "Stok : " + ikan.stok.ToString();
            else
            {
                LbStok.Text = "Stok Habis";
                LbStok.ForeColor = Color.Red;
            }

            if (ikan.gambar_ikan != null && ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(ikan.gambar_ikan))
                    {
                        PBCardIkan.Image = Image.FromStream(ms);
                        PBCardIkan.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    PBCardIkan.Image = null;
                    PBCardIkan.BackColor = Color.Gray;
                }
            }
            else
            {
                PBCardIkan.Image = null;
                PBCardIkan.BackColor = Color.LightGray; 
            }
        }

        private void BttnCardLihat_Click(object sender, EventArgs e)
        {

        }
    }
}