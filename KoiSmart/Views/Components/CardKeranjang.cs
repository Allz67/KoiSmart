using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KoiSmart.Models;
using KoiSmart.Helpers; // Akses CartSession

namespace KoiSmart.Views.Components
{
    public partial class CardKeranjang : UserControl
    {
        // Variabel lokal buat nyimpen data item ini
        private CartItem _item;

        // EVENT PENTING:
        // Buat ngabarin Dashboard: "Eh, jumlahnya berubah nih, update total harga dong!"
        public event EventHandler OnQtyChanged;

        public CardKeranjang()
        {
            InitializeComponent();
        }

        // --- 1. METHOD ISI DATA (Dipanggil Dashboard) ---
        public void SetData(CartItem item)
        {
            _item = item;

            // Tampilkan data awal
            UpdateTampilan();
            LoadGambar();
        }

        // Helper: Update teks biar gak numpuk codingan
        private void UpdateTampilan()
        {
            // Safety check: Kalau datanya null, jangan ngapa-ngapain
            if (_item == null || _item.Ikan == null) return;

            // 1. SET WARNA JADI HITAM (Biar Jelas)
            LblNama.ForeColor = Color.Black;

            // Harga dikasih warna abu tua atau hitam biar elegan
            LblHarga.ForeColor = Color.DimGray;

            // Qty dikasih warna hitam tebal (kalau font di designer udah bold)
            LblQty.ForeColor = Color.Black;

            // 2. ISI DATANYA
            LblNama.Text = _item.Ikan.jenis_ikan;

            // Format Rupiah (Rp 700.000)
            LblHarga.Text = "Rp " + _item.Ikan.harga.ToString("N0");

            // Format Quantity (2x)
            LblQty.Text = _item.Quantity.ToString() + "x";
        }

        // Helper: Load Gambar
        private void LoadGambar()
        {
            if (_item.Ikan.gambar_ikan != null && _item.Ikan.gambar_ikan.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(_item.Ikan.gambar_ikan))
                    {
                        PbGambar.Image = Image.FromStream(ms);
                        PbGambar.SizeMode = PictureBoxSizeMode.Zoom; // Wajib Zoom biar rapi
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

        // --- 2. LOGIKA TOMBOL PLUS (+) ---
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            // Cek Stok Gudang dulu, jangan sampe beli lebih dari stok
            if (_item.Quantity < _item.Ikan.stok)
            {
                // Tambah Quantity di data
                _item.Quantity++;

                // Update tampilan angka di kartu ini
                UpdateTampilan();

                // Kabari Dashboard buat update Total Harga
                OnQtyChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Stok mentok bos! Gak bisa nambah lagi.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- 3. LOGIKA TOMBOL MINUS (-) ---
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            // Kalau jumlahnya masih lebih dari 1, kurangi biasa
            if (_item.Quantity > 1)
            {
                _item.Quantity--;
                UpdateTampilan();

                // Kabari Dashboard
                OnQtyChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // KASUS KHUSUS: Kalau jumlahnya 1 terus dikurangi -> HAPUS
                var confirm = MessageBox.Show("Hapus item ini dari keranjang?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Hapus dari CartSession (Memory)
                    CartSession.RemoveItem(_item.Ikan.IdIkan);

                    // Kabari Dashboard (Nanti dashboard bakal nge-reload keranjang dan kartu ini hilang)
                    OnQtyChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void CardKeranjang_Load(object sender, EventArgs e)
        {

        }
    }
}