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
        private Ikan? _currentIkan;

        public DetailDataIkan()
        {
            InitializeComponent();

            // Hook event BtnBalik (designer already created BtnBalik control)
            BtnBalik.Click += BtnBalik_Click;

            // Hook Edit & Hapus events and ensure they are clickable / visible / on top
            BtnEdit.Click += BtnEdit_Click;
            BtnHapus.Click += BtnHapus_Click;

            BtnEdit.Enabled = true;
            BtnHapus.Enabled = true;
            BtnEdit.Visible = true;
            BtnHapus.Visible = true;

            // Bring buttons to front in case other controls overlap them
            BtnEdit.BringToFront();
            BtnHapus.BringToFront();
        }

        // Set data langsung dari object Ikan (font/size sudah ditentukan di Designer)
        public void SetData(Ikan ikan)
        {
            if (ikan == null) throw new ArgumentNullException(nameof(ikan));

            _currentIkan = ikan;

            // Isi teks sesuai permintaan (font/size dipertahankan dari Designer)
            LblJenis.Text = ikan.jenis_ikan ?? string.Empty;
            LblGender.Text = ikan.gender.ToString();
            LblPanjang.Text = ikan.panjang.ToString();
            LblGrade.Text = ikan.grade.ToString();
            LblHarga.Text = ikan.harga.ToString("N0");
            LblStok.Text = $"Stok: {ikan.stok}";
            LblNama.Text = ikan.jenis_ikan ?? string.Empty;

            // Set gambar ke PbxInputIkan (gunakan MemoryStream agar file tidak terkunci)
            SetPictureFromBytes(ikan.gambar_ikan);
        }

        // Helper: isi PictureBox dari byte[] aman (dispose image lama)
        private void SetPictureFromBytes(byte[]? bytes)
        {
            try
            {
                // dispose image lama jika ada
                if (PbxInputIkan.Image != null)
                {
                    var old = PbxInputIkan.Image;
                    PbxInputIkan.Image = null;
                    old.Dispose();
                }

                if (bytes == null || bytes.Length == 0)
                {
                    PbxInputIkan.Image = null;
                    PbxInputIkan.BackColor = Color.LightGray;
                    return;
                }

                using var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms);
                PbxInputIkan.Image = (Image)img.Clone();
                PbxInputIkan.SizeMode = PictureBoxSizeMode.Zoom;
                PbxInputIkan.BackColor = Color.Transparent;
            }
            catch
            {
                PbxInputIkan.Image = null;
                PbxInputIkan.BackColor = Color.LightGray;
            }
        }

        // Optional: load by id (internal use). Not required if caller passes Ikan object.
        public void LoadById(int id)
        {
            var controller = new IkanController();
            var ikan = controller.GetById(id);
            if (ikan != null)
            {
                SetData(ikan);
            }
            else
            {
                MessageBox.Show("Data ikan tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // BtnEdit: open edit form (V_FormUbahIkan) with current ikan
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_currentIkan == null)
            {
                MessageBox.Show("Tidak ada data ikan yang dipilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var form = new V_FormUbahIkan(_currentIkan);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // close parent form/popup so caller can refresh
                    var parentForm = this.FindForm();
                    parentForm?.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka form ubah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BtnHapus: confirm, delete via controller, close popup on success
        private void BtnHapus_Click(object? sender, EventArgs e)
        {
            if (_currentIkan == null)
            {
                MessageBox.Show("Tidak ada data ikan yang dipilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus data ikan ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var controller = new IkanController();
                bool berhasil = controller.DeleteIkan(_currentIkan.IdIkan);

                if (berhasil)
                {
                    MessageBox.Show("Data ikan berhasil dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var parentForm = this.FindForm();
                    parentForm?.Close();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data ikan. Cek koneksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi error saat menghapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BtnBalik behavior: tutup parent form (jika ada) and show main
        private void BtnBalik_Click(object? sender, EventArgs e)
        {
            try
            {
                // Tutup parent form jika ada (misal popup)
                var parentForm = this.FindForm();
                parentForm?.Close();

                // Jika V_HalUtamaAdmin sudah terbuka, bawa ke depan; jika belum, buka baru.
                var existing = Application.OpenForms.OfType<V_HalUtamaAdmin>().FirstOrDefault();
                if (existing != null)
                {
                    existing.BringToFront();
                }
                else
                {
                    var main = new V_HalUtamaAdmin();
                    main.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal kembali ke halaman utama: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
