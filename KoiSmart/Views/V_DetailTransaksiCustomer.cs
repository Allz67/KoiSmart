using System;
using System.Collections.Generic;
using System.ComponentModel;
using KoiSmart.Controllers;
using KoiSmart.Models;
using KoiSmart.Views.Components;
using KoiSmart.Helpers; 

namespace KoiSmart.Views
{
    public partial class V_DetailTransaksiCustomer : Form
    {
        private readonly TransaksiController _transaksiController;
        private RiwayatTransaksi _currentTransaksi;

        public int TransaksiId { get; private set; }
        public V_DetailTransaksiCustomer(int transaksiId)
        {
            InitializeComponent();
            _transaksiController = new TransaksiController();
            TransaksiId = transaksiId;
            LoadDetailTransaksi(TransaksiId);
        }

        private void LoadDetailTransaksi(int idTransaksi)
        {
            FlpDetailTransaksi.Controls.Clear();
            _currentTransaksi = _transaksiController.GetDetailTransaksi(idTransaksi);

            if (_currentTransaksi != null)
            {
                LblTanggalTransaksi.Text = _currentTransaksi.Tanggal.ToShortDateString();
                LblStatus.Text = _currentTransaksi.Status;
                LblTotalHarga.Text = "Rp " + _currentTransaksi.TotalBelanja.ToString("N0");
                SetCustomerViewStatus(_currentTransaksi.Status);
                foreach (var item in _currentTransaksi.Items)
                {
                    var card = new CardCheckoutItem();
                    card.SetDataRiwayat(item);

                    card.Width = FlpDetailTransaksi.ClientSize.Width;
                    FlpDetailTransaksi.Controls.Add(card);
                }
            }
            else
            {
                MessageBox.Show($"Detail transaksi ID {idTransaksi} tidak ditemukan.", "Error");
            }
        }
        private void SetCustomerViewStatus(string status)
        {
            bool canCancel = status == Status.Pending.ToString();

            if (status == Status.PengajuanPembatalan.ToString())
            {
                BtnBatalkanPesanan.Text = "Menunggu Konfirmasi Admin";
                BtnBatalkanPesanan.Enabled = false;
                BtnBatalkanPesanan.BackColor = Color.Gray;
            }
            else if (canCancel)
            {
                BtnBatalkanPesanan.Enabled = true;
                BtnBatalkanPesanan.Text = "Batalkan Pesanan";
                BtnBatalkanPesanan.BackColor = Color.Red;
            }
            else
            {
                BtnBatalkanPesanan.Enabled = false;
                BtnBatalkanPesanan.Text = $"Status: {status}";
                BtnBatalkanPesanan.BackColor = Color.DarkGray;
            }
        }
        private void BtnBatalkanPesanan_Click(object sender, EventArgs e)
        {
            if (_currentTransaksi == null || _currentTransaksi.Status != Status.Pending.ToString())
            {
                MessageBox.Show("Pesanan tidak dapat dibatalkan saat ini.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin mengajukan pembatalan pesanan ini?", "Konfirmasi Pembatalan",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string newStatus = Status.PengajuanPembatalan.ToString();
                if (_transaksiController.UpdateStatusTransaksi(_currentTransaksi.IdTransaksi, newStatus))
                {
                    MessageBox.Show("Pengajuan pembatalan berhasil, menunggu konfirmasi Admin.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDetailTransaksi(_currentTransaksi.IdTransaksi); 
                }
                else
                {
                    MessageBox.Show("Gagal mengajukan pembatalan. Silakan coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnBukti_Click(object sender, EventArgs e)
        {
            if (_currentTransaksi == null || _currentTransaksi.BuktiPembayaran == null || _currentTransaksi.BuktiPembayaran.Length == 0)
            {
                MessageBox.Show("Bukti pembayaran tidak tersedia.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Image image = ImageHelper.BinaryToImage(_currentTransaksi.BuktiPembayaran);

                Form imageForm = new Form();
                imageForm.Text = $"Bukti Transaksi ID {_currentTransaksi.IdTransaksi}";
                imageForm.StartPosition = FormStartPosition.CenterScreen;

                PictureBox pb = new PictureBox();
                pb.Image = image;
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Cursor = Cursors.Hand;

                imageForm.Controls.Add(pb);
                imageForm.ClientSize = new Size(Math.Min(image.Width + 20, 800), Math.Min(image.Height + 40, 600));

                imageForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan gambar: " + ex.Message, "Error Gambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadDetailTransaksi(this.TransaksiId);
            MessageBox.Show("Data transaksi berhasil diperbarui.", "Refresh");
        }
    }
}