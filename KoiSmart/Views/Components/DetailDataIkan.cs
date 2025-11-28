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
        // Controller buat ambil data terbaru
        private IkanController _controller;

        public DetailDataIkan()
        {
            InitializeComponent();
            _controller = new IkanController();

            // --- INI STYLE "KOTOR" (Manual Wiring) BIAR TOMBOL LANGSUNG JALAN ---
            // Gak perlu setting di Designer, langsung tembak sini
            BtnBalik.Click += BtnBalik_Click;
            BtnEdit.Click += BtnEdit_Click;
            BtnHapus.Click += BtnHapus_Click;

            // Pastikan tombol nyala
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

            // Mapping Text
            LblJenis.Text = ikan.jenis_ikan;
            LblGender.Text = ikan.gender.ToString();
            LblPanjang.Text = ikan.panjang.ToString() + " cm";
            LblGrade.Text = ikan.grade.ToString();
            LblHarga.Text = "Rp " + ikan.harga.ToString("N0");
            LblStok.Text = $"Stok: {ikan.stok}";
            LblNama.Text = ikan.jenis_ikan;

            // Mapping Gambar
            SetPictureFromBytes(ikan.gambar_ikan);
        }

        // --- METHOD BARU: REFRESH SETELAH EDIT ---
        private void RefreshData()
        {
            // Tarik data terbaru dari DB berdasarkan ID
            var ikanTerbaru = _controller.GetById(_currentIkan.IdIkan);

            if (ikanTerbaru != null)
            {
                // Update tampilan layar dengan data baru
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

        // --- LOGIKA TOMBOL ---

        // 1. EDIT (LOGIKA SUDAH DIPERBAIKI)
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_currentIkan == null) return;

            // Buka form ubah
            using (var form = new V_FormUbahIkan(_currentIkan))
            {
                // Kalau user klik Simpan (OK)
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // DULU: Close Parent
                    // SEKARANG: Refresh Data aja, jangan ditutup
                    RefreshData();

                    MessageBox.Show("Data berhasil diperbarui!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 2. HAPUS (LOGIKA TETAP: KELUAR SETELAH HAPUS)
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

                    // Kasih tau Dashboard buat refresh
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

        // 3. BALIK (LOGIKA TETAP)
        private void BtnBalik_Click(object sender, EventArgs e)
        {
            var parent = this.FindForm();
            if (parent != null)
            {
                // Kita anggap balik itu juga refresh dashboard (biar aman)
                parent.DialogResult = DialogResult.OK;
                parent.Close();
            }
        }

        // Method kosong buat ngilangin error designer panel1_Paint
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}