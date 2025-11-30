using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;

namespace KoiSmart.Views
{
    public partial class V_KonfirmasiPembelian : Form
    {
        private readonly RiwayatTransaksi _trx;

        public V_KonfirmasiPembelian()
        {
            InitializeComponent();
        }

        // New constructor to receive transaction
        public V_KonfirmasiPembelian(RiwayatTransaksi trx) : this()
        {
            _trx = trx ?? throw new ArgumentNullException(nameof(trx));
            PopulateFromTransaction();
            BtnBukti.Click += BtnBukti_Click;
            BtnBack.Click += (s, e) => this.Close();
        }

        private void PopulateFromTransaction()
        {
            // Use first item in transaction for ikan-specific labels
            var item = _trx.Items != null && _trx.Items.Count > 0 ? _trx.Items[0] : null;

            if (item != null)
            {
                LblJenis.Text = item.NamaIkan ?? "—";
                LblGender.Text = string.IsNullOrEmpty(item.Gender) ? "—" : item.Gender;
                LblPanjang.Text = item.Panjang > 0 ? item.Panjang + " cm" : "—";
                LblGrade.Text = string.IsNullOrEmpty(item.Grade) ? "—" : item.Grade;

                // Show ikan image if available
                if (item.Gambar != null && item.Gambar.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(item.Gambar))
                        {
                            PbxGambarIkan.Image = Image.FromStream(ms);
                            PbxGambarIkan.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch
                    {
                        PbxGambarIkan.BackColor = Color.Gray;
                    }
                }
            }
            else
            {
                LblJenis.Text = "—";
                LblGender.Text = "—";
                LblPanjang.Text = "—";
                LblGrade.Text = "—";
                PbxGambarIkan.BackColor = Color.Gray;
            }

            // Header/time/id/total from trx
            LblId.Text = "TRX-" + _trx.IdTransaksi.ToString("D5");
            LblWaktu.Text = _trx.Tanggal.ToString("dd MMM yyyy, HH:mm");
            LblTotal.Text = "Rp " + _trx.TotalBelanja.ToString("N0");
        }

        // Show bukti pembayaran in popup
        private void BtnBukti_Click(object sender, EventArgs e)
        {
            if (_trx?.BuktiPembayaran == null || _trx.BuktiPembayaran.Length == 0)
            {
                MessageBox.Show("Bukti pembayaran tidak tersedia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var ms = new MemoryStream(_trx.BuktiPembayaran))
                {
                    Image img = Image.FromStream(ms);

                    Form frm = new Form
                    {
                        Text = "Bukti Pembayaran",
                        StartPosition = FormStartPosition.CenterParent,
                        Size = new Size(600, 800),
                        MinimumSize = new Size(300, 300)
                    };

                    PictureBox pb = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        Image = img,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    frm.Controls.Add(pb);
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan bukti: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblHarga_Click(object sender, EventArgs e)
        {
            // keep designer hook if present
        }
    }
}
