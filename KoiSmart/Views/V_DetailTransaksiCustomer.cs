using KoiSmart.Controllers;
using KoiSmart.Models;
using KoiSmart.Views.Components;

namespace KoiSmart.Views
{
    public partial class V_DetailTransaksiCustomer : Form
    {
        private readonly TransaksiController _transaksiController;
        private readonly ReviewController _reviewController; 
        private Transaksi _currentTransaksi;
        private static readonly List<string> StatusFinalArsip = new List<string> { "Selesai", "Dibatalkan", "Ditolak" };
        private int? _existingReviewId;

        public int TransaksiId { get; private set; }

        public V_DetailTransaksiCustomer(int transaksiId)
        {
            InitializeComponent();
            _transaksiController = new TransaksiController();
            _reviewController = new ReviewController();
            TransaksiId = transaksiId;

            LoadDetailTransaksi(TransaksiId);
        }

        private void LoadDetailTransaksi(int idTransaksi)
        {
            FlpDetailTransaksi.Controls.Clear();

            _currentTransaksi = _transaksiController.GetDetailTransaksi(idTransaksi);

            if (_currentTransaksi != null)
            {
                _existingReviewId = _reviewController.GetReviewId(idTransaksi);
                LblTanggalTransaksi.Text = _currentTransaksi.Tanggal.ToShortDateString();
                LblStatus.Text = _currentTransaksi.Status;
                LblTotalHarga.Text = "Rp " + _currentTransaksi.TotalBelanja.ToString("N0");

                SetCustomerViewStatus(_currentTransaksi.Status);
                SetReviewButtonCustStatus(_currentTransaksi);

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

        private void SetReviewButtonCustStatus(Transaksi trx)
        {
            bool isCompleted = trx.Status == Status.Selesai.ToString();
            int? reviewId = _reviewController.GetReviewId(trx.IdTransaksi);
            bool isReviewed = reviewId.HasValue;
            bool isFinalButNotCompleted = trx.Status == "Dibatalkan" || trx.Status == "Ditolak";

            if (isReviewed)
            {
                BtnReview.Enabled = true;
                BtnReview.Text = "Lihat Review";
                BtnReview.BackColor = Color.Yellow;
            }
            else if (isCompleted && !isReviewed)
            {
                BtnReview.Enabled = true;
                BtnReview.Text = "Beri Review";
                BtnReview.BackColor = Color.Orange;
            }
            else
            {
                BtnReview.Enabled = false;
                BtnReview.BackColor = Color.Gray;

                if (isFinalButNotCompleted)
                {
                    BtnReview.Text = "Review Tidak Tersedia"; 
                }
                else if (trx.Status == "PengajuanPembatalan")
                {
                    BtnReview.Text = "Pengajuan Dibatalkan";
                }
                else
                {
                    BtnReview.Text = "Tunggu Selesai";
                }
            }
        }
        private void BtnBatalkanPesanan_Click(object sender, EventArgs e)
        {
            if (_currentTransaksi == null || _currentTransaksi.Status != Status.Pending.ToString())
            {
                MessageBox.Show("Pesanan tidak dapat diajukan pembatalan saat ini.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Image image = KoiSmart.Helpers.ImageHelper.BinaryToImage(_currentTransaksi.BuktiPembayaran);
                Form imageForm = new Form();
                PictureBox pb = new PictureBox();
                pb.Image = image;
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                imageForm.Controls.Add(pb); 

                imageForm.Text = $"Bukti Transaksi ID {_currentTransaksi.IdTransaksi}";
                imageForm.StartPosition = FormStartPosition.CenterScreen;
                imageForm.ClientSize = new Size(Math.Min(image.Width + 20, 800), Math.Min(image.Height + 40, 600)); // Atur ukuran

                imageForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan gambar: " + ex.Message, "Error Gambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReview_Click(object sender, EventArgs e)
        {
            if (_currentTransaksi == null || !BtnReview.Enabled)
            {
                MessageBox.Show("Aksi tidak diizinkan saat ini.", "Peringatan");
                return;
            }

            try
            {
                if (_existingReviewId.HasValue)
                {
                    var formLihatReview = new V_LihatReview(_existingReviewId.Value)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    formLihatReview.ShowDialog(this);
                }
                else
                {
                    var formBuatReview = new V_BuatReview(_currentTransaksi.IdTransaksi)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (formBuatReview.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadDetailTransaksi(this.TransaksiId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menjalankan aksi review: " + ex.Message, "Error");
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