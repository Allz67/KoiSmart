using System;
using System.Drawing;
using System.Windows.Forms;
using KoiSmart.Controllers;
using KoiSmart.Models.Review;
using KoiSmart.Helpers;

namespace KoiSmart.Views
{
    public partial class V_LihatReview : Form
    {

        private readonly ReviewController _reviewController;
        private readonly int _idReview;
        private ReviewData _reviewData;
        public V_LihatReview(int idReview)
        {
            InitializeComponent();
            _reviewController = new ReviewController();
            _idReview = idReview;

            LoadReview();
            this.Text = $"Lihat Review #{_idReview}";
        }
        public V_LihatReview() : this(0)
        {
        }

        private void LoadReview()
        {
            _reviewData = _reviewController.GetReviewById(_idReview);

            if (_reviewData != null)
            {
                LblIsiReview.Text = _reviewData.IsiReview;

                if (_reviewData.Gambar != null && _reviewData.Gambar.Length > 0)
                {
                    PbGambarReview.Image = ImageHelper.BinaryToImage(_reviewData.Gambar);
                    PbGambarReview.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    PbGambarReview.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Data review tidak ditemukan.", "Error");
                this.Close();
            }
        }
        private void BtnHapusReview_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus review ini secara permanen?", "Konfirmasi Hapus",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_reviewController.DeleteReview(_idReview))
                {
                    MessageBox.Show("Review berhasil dihapus.", "Sukses");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus review.", "Error");
                }
            }
        }
    }
}