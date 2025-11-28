using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Controllers;       // Akses TransaksiController
using KoiSmart.Helpers;           // Akses CartSession & AppSession
using KoiSmart.Views.Components;  // Akses CardCheckoutItem

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

            // --- TEMBAK LANGSUNG DISINI ---
            // Ini memaksa data dimuat DETIK ITU JUGA saat form dibuat.
            LoadDataKeranjang();
        }

        private void V_DetailPesanan_Load(object sender, EventArgs e)
        {
            
        }

        // --- 1. LOAD DATA DARI KERANJANG ---
        private void LoadDataKeranjang()
        {
            // --- DEBUGGING: Cek jumlah data ---
            MessageBox.Show("Jumlah barang di keranjang: " + CartSession.Items.Count);
            // ----------------------------------

            FlpItems.Controls.Clear();

            foreach (var item in CartSession.Items)
            {
                // Debug: Cek apakah looping jalan
                // MessageBox.Show("Menambahkan: " + item.Ikan.jenis_ikan);

                CardCheckoutItem card = new CardCheckoutItem();
                card.SetData(item);
                FlpItems.Controls.Add(card);
            }

            LblTotalBayar.Text = "Rp " + CartSession.GetTotal().ToString("N0");
        }

        // --- 2. TOMBOL UPLOAD BUKTI ---
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // 1. Tampilkan di Layar
                PbBuktiBayar.Image = Image.FromFile(opf.FileName);
                PbBuktiBayar.SizeMode = PictureBoxSizeMode.Zoom;

                // 2. Simpan ke Variabel Byte[] (Pake Helper kamu)
                // Gak perlu 'using MemoryStream' lagi, udah diurus Helper
                _buktiBayarBytes = ImageHelper.ImageToBinary(PbBuktiBayar.Image);
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

            // B. Validasi: Harus Login
            if (!AppSession.IsAuthenticated)
            {
                MessageBox.Show("Sesi habis. Silakan login ulang.", "Error");
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
                MessageBox.Show("Pesanan Berhasil Dibuat!\nStatus saat ini: PENDING.\nSilakan tunggu konfirmasi Admin.",
                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // D. BERSIHKAN KERANJANG (Karena udah dibeli)
                CartSession.Clear();

                // E. TUTUP FORM & UPDATE DASHBOARD
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal membuat pesanan. Silakan coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tombol Kembali
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}