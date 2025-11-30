using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KoiSmart.Controllers;
using KoiSmart.Models;
using KoiSmart.Views;

namespace KoiSmart.Views.Components
{
    public partial class DetailDataIkan : UserControl
    {
        private Ikan _currentIkan;
        private IkanController _controller;

        public DetailDataIkan()
        {
            InitializeComponent();
            _controller = new IkanController();

            BtnBalik.Click += BtnBalik_Click;
            BtnEdit.Click += BtnEdit_Click;
            BtnHapus.Click += BtnHapus_Click;

            BtnEdit.Enabled = true;
            BtnHapus.Enabled = true;
            BtnEdit.Visible = true;
            BtnHapus.Visible = true;
            BtnEdit.BringToFront();
            BtnHapus.BringToFront();
        }

        public void SetData(Ikan ikan)
        {
            if (ikan == null) return;

            _currentIkan = ikan;

            LblJenis.Text = ikan.jenis_ikan;
            LblGender.Text = ikan.gender.ToString();
            LblPanjang.Text = ikan.panjang.ToString() + " cm";
            LblGrade.Text = ikan.grade.ToString();
            LblHarga.Text = "Rp " + ikan.harga.ToString("N0");
            LblStok.Text = $"Stok: {ikan.stok}";
            LblNama.Text = ikan.jenis_ikan;

            SetPictureFromBytes(ikan.gambar_ikan);
        }

        private void RefreshData()
        {
            var ikanTerbaru = _controller.GetById(_currentIkan.IdIkan);

            if (ikanTerbaru != null)
            {
                SetData(ikanTerbaru);
            }
        }

        private void SetPictureFromBytes(byte[] bytes)
        {
            try
            {
                if (PbxInputIkan.Image != null) PbxInputIkan.Image.Dispose();

                if (bytes == null || bytes.Length == 0)
                {
                    PbxInputIkan.Image = null;
                    PbxInputIkan.BackColor = Color.LightGray;
                    return;
                }

                using (var ms = new MemoryStream(bytes))
                {
                    PbxInputIkan.Image = Image.FromStream(ms);
                    PbxInputIkan.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                PbxInputIkan.BackColor = Color.Gray;
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_currentIkan == null) return;

            using (var form = new V_FormUbahIkan(_currentIkan))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();

                    MessageBox.Show("Data berhasil diperbarui!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            if (_currentIkan == null) return;

            var confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool berhasil = _controller.DeleteIkan(_currentIkan.IdIkan);

                if (berhasil)
                {
                    MessageBox.Show("Data berhasil dihapus.", "Info");

                    var parent = this.FindForm();
                    if (parent != null)
                    {
                        parent.DialogResult = DialogResult.OK;
                        parent.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Gagal menghapus.", "Error");
                }
            }
        }

        private void BtnBalik_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if (parent != null)
            {
                parent.DialogResult = DialogResult.OK;
                parent.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}