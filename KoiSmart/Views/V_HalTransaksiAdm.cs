using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
using KoiSmart.Views.Components;
using System.Diagnostics;

namespace KoiSmart.Views
{
    public partial class V_HalTransaksiAdm : Form
    {
        private TransaksiController _transController;
        private AuthController _auth;


        public V_HalTransaksiAdm()
        {
            InitializeComponent();
            _transController = new TransaksiController();
            LoadTransaksiPenjualan();
            _auth = new AuthController();
        }

        private void LoadTransaksiPenjualan()
        {
            FlpTransPenjualan.Controls.Clear();
            List<string> statusAktif = new List<string> { "Pending", "Terkonfirmasi", "PengajuanPembatalan" };
            List<Transaksi> list = _transController.GetAllTransactions(statusAktif);

            if (list == null || list.Count == 0)
            {
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

                card.Width = Math.Max(FlpTransPenjualan.Width - 30, 300);
                FlpTransPenjualan.Controls.Add(card);
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
                LoadTransaksiPenjualan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void V_TransaksiPenjualan_Load(object sender, EventArgs e)
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }
        }

        private async void BttnRefresh_Click(object sender, EventArgs e)
        {
            var prevCursor = Cursor;
            try
            {
                BttnRefresh.Enabled = false;
                Cursor = Cursors.WaitCursor;

                await Task.Delay(150);
                LoadTransaksiPenjualan();
                await Task.Delay(100);
                MessageBox.Show("Daftar transaksi berhasil diperbarui.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("BttnRefresh_Click error: " + ex);
                MessageBox.Show("Gagal melakukan refresh: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = prevCursor;
                BttnRefresh.Enabled = true;
            }
        }

        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void BtnHalamanUtama_Click(object sender, EventArgs e)
        {
            V_HalUtamaAdmin home = new V_HalUtamaAdmin();
            home.Show();
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

        private void BtnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            V_RiwayatTransaksiAdm frm = new V_RiwayatTransaksiAdm();
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

        private void BtnLaporanTransaksi_Click(object sender, EventArgs e)
        {
            var frm = new V_LaporanTransaksi
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
            this.Close();
        }
    }
}