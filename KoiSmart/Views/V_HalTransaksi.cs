using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KoiSmart.Controllers;       // Akses TransaksiController, AuthController
using KoiSmart.Helpers;           // Akses AppSession, CartSession
using KoiSmart.Models;            // Akses RiwayatTransaksi, Akun
using KoiSmart.Views.Components;  // Akses CardTransaksi

namespace KoiSmart.Views
{
    public partial class V_HalTransaksi : Form
    {
        private TransaksiController _controller;
        private AuthController _auth;

        // File: V_HalTransaksi.cs

        public V_HalTransaksi()
        {
            InitializeComponent();
            _controller = new TransaksiController();
            _auth = new AuthController();

            // --- PERBAIKAN 1: Panggil di Constructor ---
            LoadUserInfo();
        }

        // Tambahkan Method ini (Jika belum ada, atau pastikan sudah ada)
        private void LoadUserInfo()
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                // ASUMSI LblUsername ada di designer
                LblUsername.Text = "Halo, " + AppSession.CurrentUser.Username;
            }
        }

        private void V_HalTransaksi_Load(object sender, EventArgs e)
        {
            // --- PERBAIKAN 2: Hanya LoadRiwayatTransaksi di sini ---
            LoadRiwayatTransaksi();
        }

        // --- METHOD TAMBAHAN: LOAD USER INFO ---

        // --- METHOD UTAMA: LOAD DAN DISPLAY DATA BERJENJANG ---
        private void LoadRiwayatTransaksi()
        {
            // Asumsi FLP tempat kartu utama bernama FlpContent
            FlpContent.Controls.Clear();

            // Cek apakah user sudah login. Jika tidak, tidak bisa ambil riwayat.
            if (!AppSession.IsAuthenticated) return;

            int idUser = AppSession.CurrentUser.IdAkun;

            // Tarik Data dari Database (Sudah di-join dan di-grup di Controller)
            List<RiwayatTransaksi> listTrx = _controller.GetRiwayat(idUser);

            if (listTrx == null || listTrx.Count == 0)
            {
                // Tampilkan pesan jika tidak ada transaksi
                Label lblKosong = new Label();
                lblKosong.Text = "Anda belum memiliki riwayat transaksi.";
                lblKosong.AutoSize = true;
                lblKosong.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblKosong.Margin = new Padding(20);
                FlpContent.Controls.Add(lblKosong);
                return;
            }

            // Looping dan Tempel Kartu Besar (CardTransaksi)
            foreach (var trx in listTrx)
            {
                CardTransaksi card = new CardTransaksi();
                card.SetData(trx);

                // --- EVENT: KLIK KARTU HARUS BUKA DETAIL RESMI ---
                card.OnViewDetails += (s, e) =>
                {
                    OpenDetailReceipt(card.DataTrx);
                };

                // Atur lebar card agar pas (asumsi lebar container 980px)
                card.Width = FlpContent.Width - 30; // Disesuaikan dengan lebar FLP
                FlpContent.Controls.Add(card);
            }
        }

        // --- LOGIC: MEMBUKA DETAIL RECEIPT ---
        private void OpenDetailReceipt(RiwayatTransaksi trx)
        {
            // Untuk sementara, kita tampilkan detail statusnya aja
            MessageBox.Show($"Detail Transaksi #{trx.IdTransaksi}\nStatus: {trx.Status}\nTotal: Rp {trx.TotalBelanja:N0}",
                            "Detail Pesanan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // BAGIAN 2: TOMBOL NAVIGASI
        // ==========================================

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            // Buka halaman utama customer
            V_HalUtamaCust homeForm = new V_HalUtamaCust();
            homeForm.Show();
            this.Close(); // Tutup form riwayat transaksi
        }

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh data di halaman ini
            LoadRiwayatTransaksi();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _auth.Logout();
                CartSession.Clear(); // Bersihkan keranjang
                new V_Login().Show();
                this.Close();
            }
        }

        // Tombol yang tidak perlu implementasi logic di sini
        private void BttnTransaksiPembelian_Click(object sender, EventArgs e) { /* Already here */ }
        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e) { /* Already here */ }
        private void BttnReview_Click(object sender, EventArgs e) { /* Placeholder */ }
    }
}