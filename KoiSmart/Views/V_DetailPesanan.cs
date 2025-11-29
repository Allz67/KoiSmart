using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Controllers;        // Akses TransaksiController
using KoiSmart.Helpers;            // Akses CartSession & AppSession, ImageHelper
using KoiSmart.Models;             // Akses Model Data
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

            // Setting Form agar tampil sebagai Dialog Modal
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // --- TEMBAK LANGSUNG MUAT DATA ---
            // Memastikan data dimuat segera tanpa menunggu event Load
            LoadDataKeranjang();
        }

        private void V_DetailPesanan_Load(object sender, EventArgs e)
        {
            // Method ini boleh kosong karena logic pemuatan data sudah dipindah ke Constructor.
        }

        // --- 1. LOAD DATA DARI KERANJANG ---
        private void LoadDataKeranjang()
        {
            // FlpItems adalah FlowLayoutPanel utama untuk list barang
            FlpItems.Controls.Clear();

            // Pastikan kita dapat data dari CartSession
            if (CartSession.Items == null || CartSession.Items.Count == 0)
            {
                LblTotalBayar.Text = "Rp 0";
                BtnBuatPesanan.Enabled = false;
                return;
            }

            foreach (var item in CartSession.Items)
            {
                // Panggil CardCheckoutItem untuk menampilkan per baris
                CardCheckoutItem card = new CardCheckoutItem();
                card.SetData(item);
                FlpItems.Controls.Add(card);
            }

            // Tampilkan Total Harga
            LblTotalBayar.Text = "Rp " + CartSession.GetTotal().ToString("N0");
            BtnBuatPesanan.Enabled = true;
        }

        // --- 2. TOMBOL UPLOAD BUKTI ---
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(opf.FileName, FileMode.Open, FileAccess.Read))
                {
                    // Membuat salinan gambar agar file tidak terkunci
                    Image uploadedImage = Image.FromStream(stream);

                    // 1. Tampilkan Preview
                    PbBuktiBayar.Image = uploadedImage;
                    PbBuktiBayar.SizeMode = PictureBoxSizeMode.Zoom;

                    // 2. Simpan ke Variabel Byte[] menggunakan ImageHelper
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

            // B. Validasi: Cek ulang Cart tidak kosong
            if (CartSession.Items.Count == 0)
            {
                MessageBox.Show("Keranjang belanja kosong. Silakan kembali ke katalog.", "Error");
                this.Close();
                return;
            }

            // C. PROSES SIMPAN KE DATABASE (Memanggil Controller)
            int idUser = AppSession.CurrentUser.IdAkun;

            // FIX: Panggil method BuatPesanan dengan eksplisit naming
            bool sukses = _transaksiController.BuatPesanan(
                idAkun: idUser,
                buktiPembayaran: _buktiBayarBytes,
                items: CartSession.Items
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