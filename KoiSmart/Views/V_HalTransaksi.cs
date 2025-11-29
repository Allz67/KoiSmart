using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KoiSmart.Controllers;       // Akses TransaksiController
using KoiSmart.Helpers;           // Akses AppSession, CartSession
using KoiSmart.Models;            // Akses RiwayatTransaksi, Akun
using KoiSmart.Views.Components;  // Akses CardTransaksi

namespace KoiSmart.Views
{
    public partial class V_HalTransaksi : Form
    {
        private TransaksiController _controller;
        private AuthController _auth;

        public V_HalTransaksi()
        {
            InitializeComponent();
            _controller = new TransaksiController();
            _auth = new AuthController();
            LoadUserInfo(); // Memuat info user saat form dibuat
        }

        private void V_HalTransaksi_Load(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
        }

        // --- METHOD TAMBAHAN: LOAD USER INFO (Fix agar username muncul) ---
        private void LoadUserInfo()
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                // LblUsername adalah label di sidebar yang menampilkan nama user
                // Asumsi nama label di sidebar bernama LblUsername
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }
        }

        // --- METHOD UTAMA: LOAD DAN DISPLAY DATA BERJENJANG ---
        // File: V_HalTransaksi.cs

        private void LoadRiwayatTransaksi()
        {
            if (!AppSession.IsAuthenticated) return;

            FlpContent.Controls.Clear();

            int idUser = AppSession.CurrentUser.IdAkun;

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

                // Event Klik Kartu
                card.OnViewDetails += (s, e) =>
                {
                    OpenDetailReceipt(card.DataTrx);
                };

                // Atur lebar card agar pas (asumsi lebar container 980px)
                card.Width = FlpContent.Width - 30;
                FlpContent.Controls.Add(card);
            }
        }

        private void OpenDetailReceipt(RiwayatTransaksi trx)
        {
            MessageBox.Show($"Detail Transaksi #{trx.IdTransaksi}\nStatus: {trx.Status}\nTotal: Rp {trx.TotalBelanja:N0}",
                            "Detail Pesanan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // BAGIAN 2: TOMBOL NAVIGASI
        // ==========================================

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaCust homeForm = new V_HalUtamaCust();
            homeForm.Show();
            this.Close();
        }

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _auth.Logout();
                CartSession.Clear();
                new V_Login().Show();
                this.Close();
            }
        }

        // Tombol yang tidak perlu implementasi logic di sini
        private void BttnTransaksiPembelian_Click(object sender, EventArgs e) { }
        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e) { }
        private void BttnReview_Click(object sender, EventArgs e) { /* Placeholder */ }
    }
}