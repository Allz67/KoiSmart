using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
using KoiSmart.Views.Components;

namespace KoiSmart.Views
{
    public partial class V_RiwayatTransaksiCust : Form
    {
        private TransaksiController _controller;
        private AuthController _auth;

        public V_RiwayatTransaksiCust()
        {
            InitializeComponent();
            _controller = new TransaksiController();
            _auth = new AuthController();
            LoadUserInfo();
            LoadRiwayatTransaksi(); 
        }

        private void V_RiwayatTransaksiCust_Load(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
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
            if (!AppSession.IsAuthenticated) return;
            FlpContent.Controls.Clear();

            int idUser = AppSession.CurrentUser.IdAkun;
            List<Transaksi> listTrx = _controller.GetHistoricalTransactions(idUser);

            if (listTrx == null || listTrx.Count == 0)
            {
                Label lblKosong = new Label();
                lblKosong.Text = "Anda belum memiliki riwayat transaksi yang selesai atau dibatalkan.";
                lblKosong.AutoSize = true;
                lblKosong.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblKosong.Margin = new Padding(20);
                FlpContent.Controls.Add(lblKosong);
                return;
            }

            foreach (var trx in listTrx)
            {
                CardTransaksi card = new CardTransaksi();
                card.SetData(trx);

                card.OnViewDetails += (s, e) =>
                {
                    OpenDetailReceipt(card.DataTrx);
                };

                card.Width = FlpContent.Width - 30; 
                FlpContent.Controls.Add(card);
            }
        }

        private void OpenDetailReceipt(Transaksi trx)
        {
            if (trx == null)
            {
                MessageBox.Show("Data transaksi tidak tersedia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var frm = new V_DetailTransaksiCustomer(trx.IdTransaksi)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                frm.ShowDialog(this);
                LoadRiwayatTransaksi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka detail transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaCust homeForm = new V_HalUtamaCust();
            homeForm.Show();
            this.Close();
        }

        private void BttnTransaksiPembelian_Click(object sender, EventArgs e)
        {
            V_HalTransaksiCust aktifForm = new V_HalTransaksiCust();
            aktifForm.Show();
            this.Close();
        }

        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            LoadRiwayatTransaksi();
        }

        private void BttnReview_Click(object sender, EventArgs e) 
        {
            V_ReviewCust reviewForm = new V_ReviewCust();
            reviewForm.Show();
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
    }
}