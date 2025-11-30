using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
using KoiSmart.Views.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_RiwayatTransaksiAdm : Form
    {
        private TransaksiController _transController;
        private AuthController _auth;

        public V_RiwayatTransaksiAdm()
        {
            InitializeComponent();
            _transController = new TransaksiController();
            LoadRiwayatTransaksi();
            LoadUserInfo();
            _auth = new AuthController();
        }
        private void LoadUserInfo()
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }
        }
        private void LoadRiwayatTransaksi()
        {
            FlpContent.Controls.Clear();
            List<string> statusHistoris = new List<string> { "Selesai", "Dibatalkan", "Ditolak" };
            List<RiwayatTransaksi> list = _transController.GetAllRiwayat(statusHistoris);

            if (list == null || list.Count == 0)
            {
                Label lblKosong = new Label();
                lblKosong.Text = "Anda belum memiliki riwayat transaksi yang selesai atau dibatalkan.";
                lblKosong.AutoSize = true;
                lblKosong.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblKosong.Margin = new Padding(20);
                FlpContent.Controls.Add(lblKosong);
                return;
            }

            foreach (var trx in list)
            {
                CardTransaksi card = new CardTransaksi();
                card.SetData(trx);

                card.OnViewDetails += (s, e) =>
                {
                    OpenDetailTransaksi(card.DataTrx.IdTransaksi);
                };

                card.Width = FlpContent.Width - 30; 
                FlpContent.Controls.Add(card);
            }
        }
        private void OpenDetailTransaksi(int idTransaksi)
        {
            try
            {
                var detailForm = new V_DetailTransaksiAdmin(idTransaksi)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                detailForm.ShowDialog(this);
                LoadRiwayatTransaksi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnHalamanUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaAdmin home = new V_HalUtamaAdmin();
            home.Show();
            this.Close();
        }

        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e)
        {
            V_HalTransaksiAdm aktif = new V_HalTransaksiAdm();
            aktif.Show();
            this.Close();
        }

        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
        }

        private void BtnLaporanTransaksi_Click(object sender, EventArgs e)
        {
            V_LaporanTransaksi frm = new V_LaporanTransaksi();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
        }

        private void BtnReviewCust_Click(object sender, EventArgs e)
        {
            V_ReviewAdm frm = new V_ReviewAdm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (_auth == null) return;

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

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
        }
    }
}