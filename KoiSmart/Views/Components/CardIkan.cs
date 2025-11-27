using System;
using System.Drawing;
using System.IO; // WAJIB ADA: Buat ngurus Gambar
using System.Windows.Forms;
using KoiSmart.Models; // WAJIB ADA: Biar kenal sama class 'Ikan'

namespace KoiSmart.Views.Components
{
    public partial class CardIkan : UserControl
    {
        // Variabel untuk menyimpan ID Ikan saat ini
        private int _idIkan;

        public CardIkan()
        {
            InitializeComponent();
        }

        // --- METHOD UTAMA: Dipanggil Dashboard buat ngisi data ---
        public void SetData(Ikan ikan)
        {
            // 1. Simpan ID Ikan (biar tombol Lihat tau ini ikan apa)
            _idIkan = ikan.IdIkan;

            // 2. Isi Text ke Label
            LbCardNamaIkan.Text = ikan.jenis_ikan;
            LbCardHargaIkan.Text = "Rp " + ikan.harga.ToString("N0");
            LbStok.Text = "Stok : " + ikan.stok.ToString();

            // 3. Tampilkan Gambar (Convert dari byte[] ke Image)
            if (ikan.gambar_ikan != null && ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(ikan.gambar_ikan))
                    {
                        PBCardIkan.Image = Image.FromStream(ms);

                        // INI YANG BIKIN GAMBARNYA FULL BODY (ZOOM)
                        PBCardIkan.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    // Kalau gambar rusak, kasih warna abu-abu
                    PBCardIkan.Image = null;
                    PBCardIkan.BackColor = Color.Gray;
                }
            }
            else
            {
                // Kalau tidak ada gambar di database
                PBCardIkan.Image = null;
                PBCardIkan.BackColor = Color.LightGray;
            }
        } // <--- Kurung kurawal penutup SetData (Tadi errornya disini karena dobel code)

        // --- EVENT TOMBOL LIHAT ---
        private void BttnCardLihat_Click(object sender, EventArgs e)
        {
            // Nanti di sini kita ganti kode buat buka Form Detail
            MessageBox.Show("Kamu memilih Ikan ID: " + _idIkan);
        }
    }
}