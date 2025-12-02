using KoiSmart.Controllers;
using KoiSmart.Models.Review;
using KoiSmart.Views.Components;
using KoiSmart.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_ReviewCust : Form
    {
        private ReviewController _controller;
        private AuthController _auth;

        public V_ReviewCust()
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

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaCust home = new V_HalUtamaCust();
            home.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V_HalTransaksiCust pembelian = new V_HalTransaksiCust();
            pembelian.Show();
            this.Close();
        }

        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            V_RiwayatTransaksiCust riwayat = new V_RiwayatTransaksiCust();
            riwayat.Show();
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