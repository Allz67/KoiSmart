using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
using KoiSmart.Views.Components;

namespace KoiSmart.Views
{
    public partial class V_HalTransaksiCust : Form
    {
        private TransaksiController _controller;
        private AuthController _auth;

        public V_HalTransaksiCust()
        {
            InitializeComponent();
            _controller = new TransaksiController();
            _auth = new AuthController();
            LoadUserInfo();
            LoadTransaksi();
        }

        private void V_HalTransaksi_Load(object sender, EventArgs e)
        {
            LoadTransaksi();
        }

        private void LoadUserInfo()
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }
        }

        private void LoadTransaksi()
        {
            if (!AppSession.IsAuthenticated) return;

            FlpContent.FlowDirection = FlowDirection.TopDown;
            FlpContent.WrapContents = false;
            FlpContent.AutoScroll = true;

            FlpContent.Controls.Clear();

            int idUser = AppSession.CurrentUser.IdAkun;
            List<Transaksi> listTrx = _controller.GetActiveTransactions(idUser);

            if (listTrx == null || listTrx.Count == 0)
            {
                Label lblKosong = new Label();
                lblKosong.Text = "Anda belum memiliki transaksi aktif.";
                lblKosong.AutoSize = true;
                lblKosong.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblKosong.Margin = new Padding(20);
                FlpContent.Controls.Add(lblKosong);
                return;
            }
            int vsb = SystemInformation.VerticalScrollBarWidth;
            int availableWidth = Math.Max(0, FlpContent.ClientSize.Width - vsb - 20);

            foreach (var trx in listTrx)
            {
                CardTransaksi card = new CardTransaksi();
                card.SetData(trx);

                card.OnViewDetails += (s, e) =>
                {
                    OpenDetailReceipt(card.DataTrx);
                };
                card.Width = availableWidth;
                card.Margin = new Padding(8);

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
                LoadTransaksi();
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

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransaksi();
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

        private void BttnTransaksiPembelian_Click(object sender, EventArgs e) 
        {

        }
        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e) 
        {
            V_RiwayatTransaksiCust riwayatForm = new V_RiwayatTransaksiCust();
            riwayatForm.Show();
            this.Close();
        }
        private void BttnReview_Click(object sender, EventArgs e) 
        {
            V_ReviewCust reviewForm = new V_ReviewCust();
            reviewForm.Show();
            this.Close();
        }
    }
}