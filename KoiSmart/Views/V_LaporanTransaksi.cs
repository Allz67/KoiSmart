using KoiSmart.Controllers;
using KoiSmart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_LaporanTransaksi : Form
    {

        private LaporanController _controller;
        private TransaksiController _transaksiController; 
        private Dictionary<int, string> _bulanMap;
        private AuthController _auth;

        public V_LaporanTransaksi()
        {
            InitializeComponent();
            _controller = new LaporanController();
            _transaksiController = new TransaksiController();
            _auth = new AuthController();

            InitializeBulanMap();
            LoadPeriodSelectors();
            if (CmbBulan.SelectedValue != null && CmbTahun.SelectedValue != null)
            {
                BtnGenerateLaporan_Click(this, EventArgs.Empty);
            }
        }

        private void InitializeBulanMap()
        {
            _bulanMap = new Dictionary<int, string>();
            for (int i = 1; i <= 12; i++)
            {
                _bulanMap.Add(i, new DateTime(2000, i, 1).ToString("MMMM"));
            }
        }

        private void LoadPeriodSelectors()
        {
            var periods = _controller.GetAvailableReportPeriods();

            if (periods == null || periods.Count == 0)
            {
                MessageBox.Show("Tidak ada data transaksi untuk dibuat laporan.", "Informasi");
                CmbBulan.Enabled = false;
                CmbTahun.Enabled = false;
                BtnGenerateLaporan.Enabled = false;
                return;
            }
            var uniqueYears = periods.Select(p => p.Tahun).Distinct().OrderByDescending(y => y).ToList();
            CmbTahun.DataSource = uniqueYears;
            if (uniqueYears.Any())
            {
                CmbTahun.SelectedItem = uniqueYears.First();
            }

            UpdateBulanComboBox();
        }

        private void UpdateBulanComboBox()
        {
            if (CmbTahun.SelectedItem == null) return;

            int selectedYear = (int)CmbTahun.SelectedItem;
            var periods = _controller.GetAvailableReportPeriods();
            var availableMonths = periods
                .Where(p => p.Tahun == selectedYear)
                .Select(p => new { Name = p.NamaBulan, p.Bulan })
                .OrderByDescending(p => p.Bulan)
                .ToList();

            CmbBulan.DataSource = availableMonths;
            CmbBulan.DisplayMember = "Name";
            CmbBulan.ValueMember = "Bulan";
            if (availableMonths.Any())
            {
                CmbBulan.SelectedIndex = 0;
            }
        }

        private void LoadReportData(int bulan, int tahun)
        {
            string namaBulan = _bulanMap.ContainsKey(bulan) ? _bulanMap[bulan] : "Unknown";
            LblPeriode.Text = $"{namaBulan} {tahun}";

            try
            {
                decimal totalPemasukan = _controller.GetTotalPemasukan(bulan, tahun);
                string ikanTerlaris = _controller.GetIkanTerlaris(bulan, tahun);
                decimal totalIkanTerjual = _controller.GetTotalItemTerjual(bulan, tahun);

                LblTotalPendapatan.Text = "Rp " + totalPemasukan.ToString("N0");
                LblIkanTerlaris.Text = ikanTerlaris;
                LblTotalIkanTerjual.Text = totalIkanTerjual.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data laporan: " + ex.Message, "Database Error");
            }
        }
        private void CmbTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBulanComboBox();
        }

        private void CmbBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnGenerateLaporan_Click(object sender, EventArgs e)
        {
            if (CmbBulan.SelectedValue == null || CmbTahun.SelectedValue == null)
            {
                MessageBox.Show("Pilih Bulan dan Tahun terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedBulan = Convert.ToInt32(CmbBulan.SelectedValue);
            int selectedTahun = Convert.ToInt32(CmbTahun.SelectedValue);

            LoadReportData(selectedBulan, selectedTahun);
        }

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadPeriodSelectors();
            BtnGenerateLaporan_Click(this, EventArgs.Empty);
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
    }
}