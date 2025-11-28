using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;  // Wajib: Akses Ikan
using KoiSmart.Helpers; // Wajib: Akses CartSession

namespace KoiSmart.Views
{
    public partial class DetailIkanCust : Form
    {
        // Variabel global buat nyimpen data ikan & jumlah beli
        private Ikan _ikanTerpilih;
        private int _qtyBeli = 1;

        // --- PENTING: Constructor diubah biar bisa nerima data Ikan ---
        public DetailIkanCust(Ikan ikan)
        {
            InitializeComponent();
            _ikanTerpilih = ikan;

            // Setting form biar rapi (muncul di tengah)
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        // Kalau ada error di Designer karena constructor diubah, 
        // tambahkan constructor kosong ini (opsional):
        // public DetailIkanCust() { InitializeComponent(); }

        private void DetailIkanCust_Load(object sender, EventArgs e)
        {
            // 1. ISI DATA KE LABEL
            // Pastikan (Name) label di Designer-mu sesuai dengan ini ya:
            LblNamaIkan.Text = _ikanTerpilih.jenis_ikan; // Judul Besar

            // Detail tabel
            LblJenis.Text = _ikanTerpilih.jenis_ikan;
            LblGender.Text = _ikanTerpilih.gender.ToString();
            LblPanjang.Text = _ikanTerpilih.panjang + " cm";
            LblGrade.Text = _ikanTerpilih.grade.ToString();
            LblHarga.Text = "Rp " + _ikanTerpilih.harga.ToString("N0");

            // Label Stok
            LblStok.Text = "Stok: " + _ikanTerpilih.stok;

            // 2. TAMPILKAN GAMBAR
            if (_ikanTerpilih.gambar_ikan != null && _ikanTerpilih.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(_ikanTerpilih.gambar_ikan))
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

            // 3. SETTING AWAL QTY
            if (_ikanTerpilih.stok <= 0)
            {
                // Kalau stok habis, matikan tombol beli
                _qtyBeli = 0;
                LblQty.Text = "0";
                BtnBeli.Enabled = false;
                BtnBeli.Text = "Stok Habis";
                BtnBeli.BackColor = Color.Gray;
                BtnPlus.Enabled = false;
                BtnMinus.Enabled = false;
            }
            else
            {
                _qtyBeli = 1;
                LblQty.Text = "1";
            }
        }

        // --- TOMBOL BACK (KEMBALI) ---
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Tutup form aja
        }

        // --- TOMBOL MINUS (-) ---
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            // Minimal beli 1, gak boleh 0 atau minus
            if (_qtyBeli > 1)
            {
                _qtyBeli--;
                LblQty.Text = _qtyBeli.ToString();
            }
        }

        // --- TOMBOL PLUS (+) ---
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            // Cek stok dulu, gak boleh beli lebih dari stok gudang
            if (_qtyBeli < _ikanTerpilih.stok)
            {
                _qtyBeli++;
                LblQty.Text = _qtyBeli.ToString();
            }
            else
            {
                MessageBox.Show("Stok mentok bos! Cuma ada " + _ikanTerpilih.stok, "Info");
            }
        }

        // --- TOMBOL BELI SEKARANG ---
        private void BtnBeli_Click(object sender, EventArgs e)
        {
            // URUTAN INI PENTING:

            // 1. Masukkan data ke Keranjang DULU
            CartSession.AddToCart(_ikanTerpilih, _qtyBeli);

            // 2. Tampilkan Pesan Sukses
            MessageBox.Show("Berhasil masuk keranjang!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. BARU kasih sinyal OK ke Dashboard (Biar dashboard refresh sidebar)
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}