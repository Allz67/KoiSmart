using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;         
using KoiSmart.Views.Components;  
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace KoiSmart.Views
{
    public partial class V_HalUtamaAdmin : Form
    {
        private AuthController _auth;
        private IkanController _ikanController;

        public V_HalUtamaAdmin()
        {
            InitializeComponent();
            _auth = new AuthController();
            _ikanController = new IkanController();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDataIkan();
        }

        private void V_HalUtamaAdmin_Load(object sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated || AppSession.CurrentUser.Role != Models.AkunRole.admin)
            {
                MessageBox.Show("Akses ditolak! Hanya admin yang bisa mengakses halaman ini.");
                this.Close();
                return;
            }

            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }

            this.Text = $"Dashboard Admin - {AppSession.CurrentUser.NamaDepan} {AppSession.CurrentUser.NamaBelakang}";
        }

        private void LoadDataIkan()
        {
            try
            {
                if (FlpHalUtama == null)
                {
                    MessageBox.Show("FlowLayoutPanel 'FlpHalUtama' tidak ditemukan. Periksa Designer nama kontrol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FlpHalUtama.Controls.Clear();
                FlpHalUtama.FlowDirection = FlowDirection.LeftToRight;
                FlpHalUtama.WrapContents = true;
                FlpHalUtama.AutoScroll = true;

                List<Ikan> listIkan = _ikanController.AmbilSemuaIkan();

                Debug.WriteLine($"LoadDataIkan: fetched {listIkan?.Count ?? 0} items.");

                if (listIkan == null || listIkan.Count == 0)
                {
                    MessageBox.Show("Tidak ada data ikan yang dimuat. Periksa koneksi DB, query, atau kolom is_delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int desiredColumns = 3;
                int minCardWidth = 200; 
                int gap = 10;
                int panelWidth = FlpHalUtama.ClientSize.Width > 0 ? FlpHalUtama.ClientSize.Width : FlpHalUtama.Width;
                int paddingH = FlpHalUtama.Padding.Left + FlpHalUtama.Padding.Right;
                int vsb = SystemInformation.VerticalScrollBarWidth;
                int available = Math.Max(0, panelWidth - paddingH - (gap * (desiredColumns - 1)) - vsb - 8);
                int cardWidth = available / desiredColumns;
                cardWidth = Math.Max(minCardWidth, cardWidth - 16);
                int maxCardWidth = 340;
                if (cardWidth > maxCardWidth) cardWidth = maxCardWidth;

                foreach (var data in listIkan)
                {
                    CardIkan kartu = new CardIkan();
                    kartu.SetData(data);
                    kartu.Width = cardWidth;
                    kartu.Margin = new Padding(gap / 2, gap, gap / 2, gap);

                    FlpHalUtama.Controls.Add(kartu);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LoadDataIkan error: " + ex);
                MessageBox.Show("Gagal memuat data ikan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTambahIkan_Click(object sender, EventArgs e)
        {
            V_FormDataIkan formDataIkan = new V_FormDataIkan();

            if (formDataIkan.ShowDialog() == DialogResult.OK)
            {
                LoadDataIkan();
            }
        }

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIkan();
        }

        private void BtnHalUtama_Click(object sender, EventArgs e)
        {
            LoadDataIkan();
        }
        private void BtnTransaksiPenjualan_Click(object sender, EventArgs e)
        {
            V_HalTransaksiAdm frm = new V_HalTransaksiAdm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
        }

        private void BtnRiwayatTransaksi_Click(object sender, EventArgs e)
        {
            V_RiwayatTransaksiAdm frm = new V_RiwayatTransaksiAdm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
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