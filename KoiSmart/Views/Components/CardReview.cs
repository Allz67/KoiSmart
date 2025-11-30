using System;
using System.Drawing;
using System.Windows.Forms;
using KoiSmart.Models.Review;
using KoiSmart.Helpers;

namespace KoiSmart.Views.Components
{
    public partial class CardReview : UserControl
    {
        public ReviewAdmData DataReview { get; private set; }

        public CardReview()
        {
            InitializeComponent();
        }

        public void SetData(ReviewAdmData data)
        {
            if (data == null) return;
            DataReview = data;
            LblUsername.Text = data.NamaPembeli;
            LblIdTransaksi.Text = $"TRX ID: {data.IdTransaksi}";
            LblIsiReview.Text = data.IsiReview;
            LblTanggalReview.Text = data.TanggalReview.ToString("dd MMM yyyy, HH:mm");
            if (data.GambarReview != null && data.GambarReview.Length > 0)
            {
                try
                {
                    Image image = ImageHelper.BinaryToImage(data.GambarReview);
                    PbFotoReview.Image = image;
                    PbFotoReview.SizeMode = PictureBoxSizeMode.Zoom;
                    PbFotoReview.Visible = true;
                }
                catch
                {
                    PbFotoReview.Visible = false;
                }
            }
            else
            {
                PbFotoReview.Visible = false;
            }
        }
    }
}