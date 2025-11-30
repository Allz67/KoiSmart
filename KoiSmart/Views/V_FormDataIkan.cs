using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;
using KoiSmart.Controllers;

namespace KoiSmart.Views
{
    public partial class V_FormDataIkan : Form
    {
        private byte[] _gambarIkanBytes = null;
        private IkanController _controller;

        public V_FormDataIkan()
        {
            InitializeComponent();
            _controller = new IkanController();

            CmbGender.DataSource = Enum.GetValues(typeof(GenderIkan));
            CmbGrade.DataSource = Enum.GetValues(typeof(GradeIkan));
        }

        private void BttnUploadIkan_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                PBUploadIkan.Image = Image.FromFile(opf.FileName);

                using (MemoryStream ms = new MemoryStream())
                {
                    PBUploadIkan.Image.Save(ms, PBUploadIkan.Image.RawFormat);
                    _gambarIkanBytes = ms.ToArray();
                }
            }
        }

        private void BttnBatalBuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BttnSimpanBuat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbBuatJenis.Text) ||
                string.IsNullOrWhiteSpace(TbPanjangIkan.Text) ||
                string.IsNullOrWhiteSpace(TbHargaIkan.Text) ||
                string.IsNullOrWhiteSpace(TbStokIkan.Text))
            {
                MessageBox.Show("Semua data (Jenis, Panjang, Harga, Stok) wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_gambarIkanBytes == null)
            {
                MessageBox.Show("Jangan lupa upload gambar ikannya!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Ikan ikanBaru = new Ikan();
                ikanBaru.jenis_ikan = TbBuatJenis.Text;

                ikanBaru.panjang = Convert.ToInt32(TbPanjangIkan.Text);
                ikanBaru.harga = Convert.ToDecimal(TbHargaIkan.Text);
                ikanBaru.stok = Convert.ToInt32(TbStokIkan.Text);

                ikanBaru.gender = (GenderIkan)CmbGender.SelectedItem;
                ikanBaru.grade = (GradeIkan)CmbGrade.SelectedItem;

                ikanBaru.gambar_ikan = _gambarIkanBytes;

                bool berhasil = _controller.TambahIkan(ikanBaru);

                if (berhasil)
                {
                    MessageBox.Show("Sukses! Data ikan berhasil disimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan ke database. Cek koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format Salah! Harga, Stok, dan Panjang harus angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}