using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;
using KoiSmart.Controllers;

namespace KoiSmart.Views
{
    public partial class V_FormUbahIkan : Form
    {
        // Variabel Global
        private byte[]? _gambarIkanBytes = null;
        private IkanController _controller;

        // Edit mode
        private bool _isEditMode = false;
        private int _editingId = 0;

        public V_FormUbahIkan()
        {
            InitializeComponent();
            _controller = new IkanController();

            // Isi Pilihan Enum ke ComboBox
            CmbGender.DataSource = Enum.GetValues(typeof(GenderIkan));
            CmbGrade.DataSource = Enum.GetValues(typeof(GradeIkan));
        }

        // Overload: buka form dalam mode edit dengan object Ikan
        public V_FormUbahIkan(Ikan ikan) : this()
        {
            if (ikan == null) throw new ArgumentNullException(nameof(ikan));

            _isEditMode = true;
            _editingId = ikan.IdIkan;

            // isi kontrol dengan data ikan
            TbBuatJenis.Text = ikan.jenis_ikan;
            TbPanjangIkan.Text = ikan.panjang.ToString();
            TbHargaIkan.Text = ikan.harga.ToString();
            TbStokIkan.Text = ikan.stok.ToString();

            CmbGender.SelectedItem = ikan.gender;
            CmbGrade.SelectedItem = ikan.grade;

            _gambarIkanBytes = ikan.gambar_ikan;
            if (_gambarIkanBytes != null && _gambarIkanBytes.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(_gambarIkanBytes);
                    PBUploadIkan.Image = Image.FromStream(ms);
                    PBUploadIkan.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    PBUploadIkan.Image = null;
                    PBUploadIkan.BackColor = Color.LightGray;
                }
            }

            BttnSimpanBuat.Text = "Update";
        }

        // --- TOMBOL UPLOAD GAMBAR ---
        private void BttnUploadIkan_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // Tampilkan Preview
                PBUploadIkan.Image = Image.FromFile(opf.FileName);

                // Ubah ke byte[] buat database
                using (MemoryStream ms = new MemoryStream())
                {
                    PBUploadIkan.Image.Save(ms, PBUploadIkan.Image.RawFormat);
                    _gambarIkanBytes = ms.ToArray();
                }
            }
        }

        // --- TOMBOL BATAL ---
        private void BttnBatalBuat_Click(object sender, EventArgs e)
        {
            this.Close(); // Balik ke halaman utama tanpa simpan
        }

        // --- TOMBOL SIMPAN / UPDATE ---
        private void BttnSimpanBuat_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input (Gak boleh ada yang kosong)
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
                // 2. Masukkan data ke Object Ikan
                Ikan ikanObj = new Ikan();
                ikanObj.jenis_ikan = TbBuatJenis.Text;

                // Konversi Text ke Angka
                ikanObj.panjang = Convert.ToInt32(TbPanjangIkan.Text);
                ikanObj.harga = Convert.ToDecimal(TbHargaIkan.Text);
                ikanObj.stok = Convert.ToInt32(TbStokIkan.Text);

                // Ambil Enum
                ikanObj.gender = (GenderIkan)CmbGender.SelectedItem;
                ikanObj.grade = (GradeIkan)CmbGrade.SelectedItem;

                // Masukkan Gambar (bisa tetap dari DB jika tidak diubah)
                ikanObj.gambar_ikan = _gambarIkanBytes;

                if (_isEditMode)
                {
                    // Update existing record
                    ikanObj.IdIkan = _editingId;
                    bool berhasil = _controller.UpdateIkan(ikanObj);

                    if (berhasil)
                    {
                        MessageBox.Show("Sukses! Data ikan berhasil diupdate.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengupdate data ikan. Cek koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new record (fallback)
                    bool berhasil = _controller.TambahIkan(ikanObj);

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