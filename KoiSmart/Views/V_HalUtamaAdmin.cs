using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;            // Wajib: Biar kenal class Ikan
using KoiSmart.Views.Components;  // Wajib: Biar kenal CardIkan
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_HalUtamaAdmin : Form
    {
        private AuthController _auth;
        private IkanController _ikanController; // Controller buat ambil data ikan

        public V_HalUtamaAdmin()
        {
            InitializeComponent();
            _auth = new AuthController();
            _ikanController = new IkanController(); // Inisialisasi Controller
        }

        private void V_HalUtamaAdmin_Load(object sender, EventArgs e)
        {
            // 1. Cek apakah user yang login adalah admin (Logic Kating)
            if (!AppSession.IsAuthenticated || AppSession.CurrentUser.Role != Models.AkunRole.admin)
            {
                MessageBox.Show("Akses ditolak! Hanya admin yang bisa mengakses halaman ini.");
                this.Close();
                return;
            }

            // Set title dengan nama user
            this.Text = $"Dashboard Admin - {AppSession.CurrentUser.NamaDepan} {AppSession.CurrentUser.NamaBelakang}";

            // 2. LOAD DATA IKAN (Logic Kita)
            // Pas form dibuka, langsung panggil data dari database
            LoadDataIkan();
        }

        // --- METHOD KHUSUS BUAT NAMPILIN KARTU ---
        private void LoadDataIkan()
        {
            // Ganti flowLayoutPanel1 jadi FlpHalUtama
            FlpHalUtama.Controls.Clear();

            // Panggil Controller
            List<Ikan> listIkan = _ikanController.AmbilSemuaIkan();

            foreach (var data in listIkan)
            {
                CardIkan kartu = new CardIkan();
                kartu.SetData(data);

                // Masukkan kartu ke dalam panel FLP buatanmu
                FlpHalUtama.Controls.Add(kartu);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _auth.Logout();

                // Buka login form
                V_Login loginForm = new V_Login();
                loginForm.Show();

                // Tutup dashboard
                this.Close();
            }
        }

        // --- TOMBOL TAMBAH (AUTO REFRESH) ---
        private void BtnTambahIkan_Click(object sender, EventArgs e)
        {
            V_FormDataIkan formDataIkan = new V_FormDataIkan();

            // Kita pakai ShowDialog() biar dashboard 'nunggu' sampai form input ditutup.
            // Kalau form input ngirim sinyal "OK" (Berhasil Simpan), kita refresh.
            if (formDataIkan.ShowDialog() == DialogResult.OK)
            {
                LoadDataIkan(); // <-- Refresh otomatis di sini!
            }
        }

        // --- TOMBOL REFRESH MANUAL ---
        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIkan();
        }

        // --- TOMBOL HALAMAN UTAMA ---
        private void BtnHalUtama_Click(object sender, EventArgs e)
        {
            // Reload data aja biar fresh
            LoadDataIkan();
        }

        // --- TOMBOL LAINNYA (DIKOSONGIN SESUAI REQUEST) ---
        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e) { }

        private void BtnRiwayatTransaksi_Click(object sender, EventArgs e) { }

        private void BtnLaporanTransaksi_Click(object sender, EventArgs e) { }

        private void BtnReviewCust_Click(object sender, EventArgs e) { }
    }
}