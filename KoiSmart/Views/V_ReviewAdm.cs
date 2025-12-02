using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models.Review;
using KoiSmart.Views.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_ReviewAdm : Form
    {
        private ReviewController _controller;
        private AuthController _auth;

        public V_ReviewAdm()
        {
            InitializeComponent();
            _controller = new ReviewController();
            LoadReviews();
            _auth = new AuthController();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }
        }

        private void LoadReviews()
        {
            FlpReview.Controls.Clear();
            List<ReviewData> reviews = _controller.GetAllReview();

            if (reviews == null || !reviews.Any())
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Belum ada ulasan yang tersedia.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.Margin = new Padding(20);
                FlpReview.Controls.Add(lblEmpty);
                return;
            }

            foreach (var review in reviews)
            {
                CardReview card = new CardReview();

                var admData = new ReviewAdmData
                {
                    IdReview = review.IdReview,
                    NamaPembeli = review.NamaPembeli,
                    IsiReview = review.IsiReview,
                    Gambar = review.Gambar,
                    IdTransaksi = review.IdTransaksi,
                    TanggalReview = review.TanggalReview
                };

                card.SetData(admData);

                card.Width = FlpReview.ClientSize.Width - 5;
                FlpReview.Controls.Add(card);
            }
        }

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadReviews();
            MessageBox.Show("Daftar ulasan berhasil diperbarui.", "Refresh");
        }

        private void BtnHalamanUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaAdmin home = new V_HalUtamaAdmin();
            home.Show();
            this.Close();
        }

        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e)
        {
            V_HalTransaksiAdm penjualan = new V_HalTransaksiAdm();
            penjualan.Show();
            this.Close();
        }

        private void BtnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            V_RiwayatTransaksiAdm riwayat = new V_RiwayatTransaksiAdm();
            riwayat.Show();
            this.Close();
        }

        private void BtnLaporanTransaksi_Click(object sender, EventArgs e)
        {
            V_LaporanTransaksi laporan = new V_LaporanTransaksi();
            laporan.Show();
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _auth.Logout();

                V_Login loginForm = new V_Login();
                loginForm.Show();

                this.Close();
            }
        }
    }
}