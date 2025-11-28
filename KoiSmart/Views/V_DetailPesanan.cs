using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Controllers;        // Akses TransaksiController
using KoiSmart.Helpers;            // Akses CartSession & AppSession
using KoiSmart.Models;             // Akses Model
using KoiSmart.Views.Components;   // Akses CardCheckoutItem

namespace KoiSmart.Views
{
    public partial class V_DetailPesanan : Form
    {
        // Variabel buat nyimpen data gambar sementara
        private byte[] _buktiBayarBytes = null;
        private TransaksiController _transaksiController;

        public V_DetailPesanan()
        {
            InitializeComponent();

            _transaksiController = new TransaksiController();

            // Setting Form
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // --- JURUS PAKSA MUAT DATA (Di Constructor) ---
            LoadDataKeranjang();
        }

        private void V_DetailPesanan_Load(object sender, EventArgs e)
        {
            // Event Load Form ini Boleh Kosong karena Logic pemuatan data sudah di Constructor.
        }

        // --- 1. LOAD DATA DARI KERANJANG ---
        private void LoadDataKeranjang()
        {
            FlpItems.Controls.Clear();

            // Pastikan kita dapat data dari CartSession
            if (CartSession.Items == null || CartSession.Items.Count == 0)
            {
                // Tampilkan pesan kosong jika keranjang kosong
                // (Ini penting jika user somehow bisa masuk ke form ini tanpa belanja)
                // Label pesan kosong opsional
                LblTotalBayar.Text = "Rp 0";
                BtnBuatPesanan.Enabled = false;
                return;
            }

            foreach (var item in CartSession.Items)
            {
                CardCheckoutItem card = new CardCheckoutItem();
                card.SetData(item);
                FlpItems.Controls.Add(card);
            }

            // Tampilkan Total Harga
            LblTotalBayar.Text = "Rp " + CartSession.GetTotal().ToString("N0");
            BtnBuatPesanan.Enabled = true; // Aktifkan tombol
        }

        // --- 2. TOMBOL UPLOAD BUKTI ---
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // 1. Tampilkan di Layar
                // Gunakan using statement agar MemoryStream ditutup
                using (var stream = new FileStream(opf.FileName, FileMode.Open, FileAccess.Read))
                {
                    // Membuat salinan gambar agar file tidak terkunci oleh aplikasi
                    Image uploadedImage = Image.FromStream(stream);

                    PbBuktiBayar.Image = uploadedImage;
                    PbBuktiBayar.SizeMode = PictureBoxSizeMode.Zoom;

                    // 2. Simpan ke Variabel Byte[] (Pake Helper)
                    _buktiBayarBytes = ImageHelper.ImageToBinary(uploadedImage);
                }
            }
        }

        // --- 3. TOMBOL BUAT PESANAN (EKSEKUSI) ---
        private void BtnBuatPesanan_Click(object sender, EventArgs e)
        {
            // A. Validasi: Harus upload bukti dulu
            if (_buktiBayarBytes == null)
            {
                MessageBox.Show("Mohon unggah bukti pembayaran (Struk Transfer) terlebih dahulu!",
                                 "Bukti Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // B. Validasi: Cek ulang Cart tidak kosong (double protection)
            if (CartSession.Items.Count == 0)
            {
                MessageBox.Show("Keranjang belanja kosong. Silakan kembali ke katalog.", "Error");
                this.Close();
                return;
            }

            // C. PROSES SIMPAN KE DATABASE
            int idUser = AppSession.CurrentUser.IdAkun;

            bool sukses = _transaksiController.BuatPesanan(
                idUser,
                _buktiBayarBytes,
                CartSession.Items
            );

            if (sukses)
            {
                MessageBox.Show("Pesanan Berhasil Dibuat! Status saat ini: PENDING.",
                                 "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // D. BERSIHKAN KERANJANG & TUTUP FORM
                CartSession.Clear();
                this.DialogResult = DialogResult.OK; // Sinyal sukses ke Dashboard
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal membuat pesanan. Periksa log database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tombol Kembali
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}