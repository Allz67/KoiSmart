using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;
using KoiSmart.Helpers; 

namespace KoiSmart.Views.Components
{
    public partial class CardKeranjang : UserControl
    {
        private CartItem _item;

        public event EventHandler OnQtyChanged;

        public CardKeranjang()
        {
            InitializeComponent();
        }

        public void SetData(CartItem item)
        {
            _item = item;

            UpdateTampilan();
            LoadGambar();
        }

        private void UpdateTampilan()
        {
            if (_item == null || _item.Ikan == null) return;

            LblNama.ForeColor = Color.Black;

            LblHarga.ForeColor = Color.DimGray;

            LblQty.ForeColor = Color.Black;

            LblNama.Text = _item.Ikan.jenis_ikan;

            LblHarga.Text = "Rp " + _item.Ikan.harga.ToString("N0");

            LblQty.Text = _item.Quantity.ToString() + "x";
        }

        private void LoadGambar()
        {
            if (_item.Ikan.gambar_ikan != null && _item.Ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(_item.Ikan.gambar_ikan))
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
            else
            {
                PbGambar.BackColor = Color.LightGray;
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (_item.Quantity < _item.Ikan.stok)
            {
                _item.Quantity++;

                UpdateTampilan();

                OnQtyChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Stok mentok bos! Gak bisa nambah lagi.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            if (_item.Quantity > 1)
            {
                _item.Quantity--;
                UpdateTampilan();

                OnQtyChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                var confirm = MessageBox.Show("Hapus item ini dari keranjang?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    CartSession.RemoveItem(_item.Ikan.IdIkan);

                    OnQtyChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void CardKeranjang_Load(object sender, EventArgs e)
        {

        }
    }
}