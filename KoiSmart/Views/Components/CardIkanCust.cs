using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;

namespace KoiSmart.Views.Components
{
    public partial class CardIkanCust : UserControl
    {
        // Property biar Dashboard bisa akses data ikan di card ini
        public Ikan DataIkan { get; private set; }

        // Property biar Dashboard bisa akses tombol 'Lihat'
        public Button BtnLihat => BttnCardLihat;

        public CardIkanCust()
        {
            InitializeComponent();
        }

        // --- METHOD PENTING: ISI DATA KE KARTU ---
        public void SetData(Ikan ikan)
        {
            DataIkan = ikan;

            // 1. KEMBALIKAN TAMPILAN NORMAL (Hapus kuning-kuning)

            // Reset Warna
            LbCardNamaIkan.BackColor = Color.Transparent; // Atau Color.White
            LbCardHargaIkan.BackColor = Color.Transparent;
            LbStok.BackColor = Color.Transparent;

            LbCardNamaIkan.ForeColor = Color.Black;
            LbCardHargaIkan.ForeColor = Color.Black; // Atau warna harga (misal OrangeRed)
            LbStok.ForeColor = Color.Black;

            // Isi Teks
            LbCardNamaIkan.Text = ikan.jenis_ikan;
            LbCardHargaIkan.Text = "Rp " + ikan.harga.ToString("N0");
            LbStok.Text = "Stok: " + ikan.stok.ToString();

            // Cek stok, kalau 0 tulis Habis
            if (ikan.stok > 0)
                LbStok.Text = "Stok : " + ikan.stok.ToString();
            else
            {
                LbStok.Text = "Stok Habis";
                LbStok.ForeColor = Color.Red;
            }

            // 2. LOGIC GAMBAR (Debug Gambar Hilang)
            // Kita cek dulu apakah byte-nya ada isinya
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
                    // Kalau file gambarnya rusak (corrupt)
                    PBCardIkan.Image = null;
                    PBCardIkan.BackColor = Color.Gray;
                }
            }
            else
            {
                // Kalau di database emang NULL (Gak ada gambar)
                PBCardIkan.Image = null;
                PBCardIkan.BackColor = Color.LightGray; // Kasih warna abu muda biar ketahuan
            }
        }

        // Event Klik dikosongin aja, nanti diatur di Dashboard
        private void BttnCardLihat_Click(object sender, EventArgs e)
        {

        }
    }
}