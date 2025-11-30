using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Controllers;       
using KoiSmart.Helpers;         
using KoiSmart.Models;            
using KoiSmart.Views.Components;  

namespace KoiSmart.Views
{
    public partial class V_DetailPesanan : Form
    {
        private byte[] _buktiBayarBytes = null;
        private TransaksiController _transaksiController;

        public V_DetailPesanan()
        {
            InitializeComponent();
            _transaksiController = new TransaksiController();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            LoadDataKeranjang();
        }

        private void V_DetailPesanan_Load(object sender, EventArgs e)
        {
        }

        private void LoadDataKeranjang()
        {
            FlpItems.Controls.Clear();

            if (CartSession.Items == null || CartSession.Items.Count == 0)
            {
                LblTotalBayar.Text = "Rp 0";
                BtnBuatPesanan.Enabled = false;
                return;
            }

            foreach (var item in CartSession.Items)
            {
                CardCheckoutItem card = new CardCheckoutItem();
                card.SetData(item);
                FlpItems.Controls.Add(card);
            }

            LblTotalBayar.Text = "Rp " + CartSession.GetTotal().ToString("N0");
            BtnBuatPesanan.Enabled = true;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(opf.FileName, FileMode.Open, FileAccess.Read))
                {
                    Image uploadedImage = Image.FromStream(stream);

                    PbBuktiBayar.Image = uploadedImage;
                    PbBuktiBayar.SizeMode = PictureBoxSizeMode.Zoom;

                    _buktiBayarBytes = ImageHelper.ImageToBinary(uploadedImage);
                }
            }
        }
        private void BtnBuatPesanan_Click(object sender, EventArgs e)
        {
            if (_buktiBayarBytes == null)
            {
                MessageBox.Show("Mohon unggah bukti pembayaran (Struk Transfer) terlebih dahulu!",
                                 "Bukti Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CartSession.Items.Count == 0)
            {
                MessageBox.Show("Keranjang belanja kosong. Silakan kembali ke katalog.", "Error");
                this.Close();
                return;
            }
            int idUser = AppSession.CurrentUser.IdAkun;

            bool sukses = _transaksiController.BuatPesanan(
                idAkun: idUser,
                buktiPembayaran: _buktiBayarBytes,
                items: CartSession.Items
            );

            if (sukses)
            {
                MessageBox.Show("Pesanan Berhasil Dibuat! Status saat ini: PENDING.",
                                 "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CartSession.Clear();
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal membuat pesanan. Periksa log database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}