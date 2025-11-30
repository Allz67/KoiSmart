using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;  
using KoiSmart.Helpers;

namespace KoiSmart.Views
{
    public partial class DetailIkanCust : Form
    {
        private Ikan _ikanTerpilih;
        private int _qtyBeli = 1;

        public DetailIkanCust(Ikan ikan)
        {
            InitializeComponent();
            _ikanTerpilih = ikan;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }


        private void DetailIkanCust_Load(object sender, EventArgs e)
        {
            LblNamaIkan.Text = _ikanTerpilih.jenis_ikan; 

            LblJenis.Text = _ikanTerpilih.jenis_ikan;
            LblGender.Text = _ikanTerpilih.gender.ToString();
            LblPanjang.Text = _ikanTerpilih.panjang + " cm";
            LblGrade.Text = _ikanTerpilih.grade.ToString();
            LblHarga.Text = "Rp " + _ikanTerpilih.harga.ToString("N0");

            LblStok.Text = "Stok: " + _ikanTerpilih.stok;

            if (_ikanTerpilih.gambar_ikan != null && _ikanTerpilih.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(_ikanTerpilih.gambar_ikan))
                    {
                        PbGambar.Image = Image.FromStream(ms);
                        PbGambar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch
                {
                    PbGambar.BackColor = Color.Gray;
                }
            }

            if (_ikanTerpilih.stok <= 0)
            {
                _qtyBeli = 0;
                LblQty.Text = "0";
                BtnBeli.Enabled = false;
                BtnBeli.Text = "Stok Habis";
                BtnBeli.BackColor = Color.Gray;
                BtnPlus.Enabled = false;
                BtnMinus.Enabled = false;
            }
            else
            {
                _qtyBeli = 1;
                LblQty.Text = "1";
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (_qtyBeli > 1)
            {
                _qtyBeli--;
                LblQty.Text = _qtyBeli.ToString();
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (_qtyBeli < _ikanTerpilih.stok)
            {
                _qtyBeli++;
                LblQty.Text = _qtyBeli.ToString();
            }
            else
            {
                MessageBox.Show("Stok mentok bos! Cuma ada " + _ikanTerpilih.stok, "Info");
            }
        }
        private void BtnBeli_Click(object sender, EventArgs e)
        {
            CartSession.AddToCart(_ikanTerpilih, _qtyBeli);
            MessageBox.Show("Berhasil masuk keranjang!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}