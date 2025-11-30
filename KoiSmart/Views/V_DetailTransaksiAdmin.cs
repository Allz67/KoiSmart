using KoiSmart.Controllers;
using KoiSmart.Models;
using KoiSmart.Views.Components;

namespace KoiSmart.Views
{
    public partial class V_DetailTransaksiAdmin : Form
    {
        private readonly TransaksiController _transaksiController;
        private RiwayatTransaksi _currentTransaksi;

        public int TransaksiId { get; private set; }
        private static readonly List<string> StatusFinalArsip = new List<string> { "Selesai", "Dibatalkan", "Ditolak" };

        public V_DetailTransaksiAdmin(int transaksiId)
        {
            InitializeComponent();
            _transaksiController = new TransaksiController();
            TransaksiId = transaksiId;
            CmbStatus.DataSource = Enum.GetNames(typeof(Status));
            CmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadDetailTransaksi(TransaksiId);
        }

        private void LoadDetailTransaksi(int idTransaksi)
        {
            FlpDetailTransaksi.Controls.Clear();
            _currentTransaksi = _transaksiController.GetDetailTransaksi(idTransaksi);

            if (_currentTransaksi != null)
            {
                LblUsername.Text = _currentTransaksi.Username;
                LblTanggalTransaksi.Text = _currentTransaksi.Tanggal.ToShortDateString();
                LblTotalHarga.Text = "Rp " + _currentTransaksi.TotalBelanja.ToString("N0");
                LblStatus.Text = _currentTransaksi.Status;

                CmbStatus.SelectedItem = _currentTransaksi.Status;
                if (StatusFinalArsip.Contains(_currentTransaksi.Status))
                {
                    CmbStatus.Enabled = false; 
                }
                else
                {
                    CmbStatus.Enabled = true; 
                }

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
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CmbStatus.Enabled) return;

            if (_currentTransaksi != null && CmbStatus.SelectedItem != null)
            {
                string newStatus = CmbStatus.SelectedItem.ToString();

                if (newStatus != _currentTransaksi.Status)
                {
                    if (_transaksiController.UpdateStatusTransaksi(_currentTransaksi.IdTransaksi, newStatus))
                    {
                        _currentTransaksi.Status = newStatus;
                        MessageBox.Show($"Status transaksi ID {_currentTransaksi.IdTransaksi} berhasil diubah menjadi {newStatus}.", "Sukses");

                        LoadDetailTransaksi(this.TransaksiId);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan perubahan status.", "Error");
                        CmbStatus.SelectedItem = _currentTransaksi.Status;
                    }
                }
            }
        }

        private void BtnBukti_Click(object sender, EventArgs e)
        {
            if (_currentTransaksi == null || _currentTransaksi.BuktiPembayaran == null || _currentTransaksi.BuktiPembayaran.Length == 0)
            {
                MessageBox.Show("Bukti pembayaran tidak tersedia untuk transaksi ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Image image = KoiSmart.Helpers.ImageHelper.BinaryToImage(_currentTransaksi.BuktiPembayaran);
                Form imageForm = new Form();
                imageForm.Text = $"Bukti Transaksi ID {_currentTransaksi.IdTransaksi}";
                imageForm.StartPosition = FormStartPosition.CenterScreen;
                imageForm.MaximizeBox = false;
                imageForm.MinimizeBox = false;
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