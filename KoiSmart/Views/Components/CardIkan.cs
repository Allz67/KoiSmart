using System;
using System.Drawing;
using System.IO; 
using System.Windows.Forms;
using KoiSmart.Models; // 
using KoiSmart.Controllers;
using KoiSmart.Views.Components;

namespace KoiSmart.Views.Components
{
    public partial class CardIkan : UserControl
    {
        private int _idIkan;

        public CardIkan()
        {
            InitializeComponent();
        }

        public void SetData(Ikan ikan)
        {
            _idIkan = ikan.IdIkan;

            LbCardNamaIkan.Text = ikan.jenis_ikan;
            LbCardHargaIkan.Text = "Rp " + ikan.harga.ToString("N0");
            LbStok.Text = "Stok : " + ikan.stok.ToString();

            if (ikan.gambar_ikan != null && ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(ikan.gambar_ikan))
                    {
                        PBCardIkan.Image = Image.FromStream(ms);

                        PBCardIkan.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    PBCardIkan.Image = null;
                    PBCardIkan.BackColor = Color.Gray;
                }
            }
            else
            {
                PBCardIkan.Image = null;
                PBCardIkan.BackColor = Color.LightGray;
            }
        } 
       
        private void BttnCardLihat_Click(object sender, EventArgs e)
        {
            try
            {
                var controller = new IkanController();
                var ikan = controller.GetById(_idIkan);
                if (ikan == null)
                {
                    MessageBox.Show("Data ikan tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var popup = new Form();
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.FormBorderStyle = FormBorderStyle.FixedDialog;
                popup.ShowInTaskbar = false;
                popup.MinimizeBox = false;
                popup.MaximizeBox = false;
                popup.ClientSize = new Size(1260, 772); 
                popup.Text = "Detail Ikan";

                var detail = new DetailDataIkan
                {
                    Dock = DockStyle.Fill
                };

                // Isi data ke kontrol detail
                detail.SetData(ikan);

                popup.Controls.Add(detail);

                // Tampilkan modal
                popup.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka detail ikan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}