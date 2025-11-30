using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Controllers;
using KoiSmart.Helpers;

namespace KoiSmart.Views
{
    public partial class V_BuatReview : Form
    {

        private readonly ReviewController _reviewController;
        private readonly int _idTransaksi;
        private byte[] _gambarReview; 
        public V_BuatReview(int idTransaksi)
        {
            InitializeComponent();
            _reviewController = new ReviewController();
            _idTransaksi = idTransaksi;
            TxtIsiReview.Multiline = true;
            TxtIsiReview.ScrollBars = ScrollBars.Vertical;
            TxtIsiReview.WordWrap = true;

            this.Text = $"Buat Review untuk Transaksi #{_idTransaksi}";
        }
        public V_BuatReview() : this(0)
        {
        }
        private void BtnUploadGambar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image originalImage = Image.FromFile(ofd.FileName);

                        PbGambarReview.Image = originalImage;
                        PbGambarReview.SizeMode = PictureBoxSizeMode.Zoom;

                        _gambarReview = ImageHelper.ImageToBinary(originalImage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat gambar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnUploadReview_Click(object sender, EventArgs e)
        {
            string isiReview = TxtIsiReview.Text;

            if (string.IsNullOrWhiteSpace(isiReview) && _gambarReview == null)
            {
                MessageBox.Show("Review atau gambar tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_reviewController.AddReview(_idTransaksi, isiReview, _gambarReview))
            {
                MessageBox.Show("Review berhasil disimpan! Terima kasih atas ulasan Anda.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan review. Mohon coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}