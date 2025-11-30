using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;         
using KoiSmart.Views.Components;  
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        private void V_HalUtamaAdmin_Load(object sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated || AppSession.CurrentUser.Role != Models.AkunRole.admin)
            {
                MessageBox.Show("Akses ditolak! Hanya admin yang bisa mengakses halaman ini.");
                this.Close();
                return;
            }

            this.Text = $"Dashboard Admin - {AppSession.CurrentUser.NamaDepan} {AppSession.CurrentUser.NamaBelakang}";

            LoadDataIkan();
        }
        private void LoadDataIkan()
        {
            FlpHalUtama.Controls.Clear();

            List<Ikan> listIkan = _ikanController.AmbilSemuaIkan();

            foreach (var data in listIkan)
            {
                CardIkan kartu = new CardIkan();
                kartu.SetData(data);

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

                V_Login loginForm = new V_Login();
                loginForm.Show();

                this.Close();
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
            V_TransaksiPenjualan frm = new V_TransaksiPenjualan();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void BtnRiwayatTransaksi_Click(object sender, EventArgs e) { }

        private void BtnLaporanTransaksi_Click(object sender, EventArgs e) { }

        private void BtnReviewCust_Click(object sender, EventArgs e) { }
    }
}