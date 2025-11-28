using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KoiSmart.Controllers;       // Akses Database
using KoiSmart.Models;            // Akses Model Ikan & CartItem
using KoiSmart.Helpers;           // Akses CartSession
using KoiSmart.Views.Components;  // Akses CardIkanCust & CardKeranjang

namespace KoiSmart.Views
{
    public partial class V_HalUtamaCust : Form
    {
        // --- 1. CONFIG SIDEBAR ---
        private bool _isSidebarOpen = false;
        private const int MinWidth = 60;
        private const int MaxWidth = 300;    // Lebar Sidebar Terbuka
        private const int Speed = 30;

        // --- 2. CONTROLLER ---
        private IkanController _ikanController;
        private AuthController _auth;

        public V_HalUtamaCust()
        {
            InitializeComponent();
            _ikanController = new IkanController();
            _auth = new AuthController();

            // Set Sidebar ke posisi Menciut (60px) pas awal
            PanelSidebar.Width = MinWidth;
            SetCartVisibility(false);
        }

        private void V_HalUtamaCust_Load(object sender, EventArgs e)
        {
            // Tampilkan Username (SUDAH DIAKTIFKAN)
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = "Halo, " + AppSession.CurrentUser.Username;
            }

            LoadKatalogProduk();
            UpdateTampilanKeranjang();
        }

        // ====================================================
        // BAGIAN 1: KATALOG PRODUK (TENGAH)
        // ====================================================

        private void LoadKatalogProduk()
        {
            FlpHalUtama.Controls.Clear();

            // Ambil semua ikan dari database
            List<Ikan> listIkan = _ikanController.AmbilSemuaIkan();

            foreach (var ikan in listIkan)
            {
                // 1. Buat Card
                CardIkanCust kartu = new CardIkanCust();
                kartu.SetData(ikan);

                // 2. Logic Tombol LIHAT
                kartu.BtnLihat.Click += (s, e) =>
                {
                    BukaDetailProduk(ikan);
                };

                // 3. Masukkan ke Panel Tengah
                FlpHalUtama.Controls.Add(kartu);
            }
        }

        private void BukaDetailProduk(Ikan ikan)
        {
            // Buka Form Detail (Popup)
            DetailIkanCust detailForm = new DetailIkanCust(ikan);

            // Kalau user klik "Beli Sekarang" (DialogResult.OK)
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh Keranjang di Sidebar
                UpdateTampilanKeranjang();

                // Buka Sidebar Otomatis (Slide Out)
                BukaSidebarOtomatis();
            }
        }

        // ====================================================
        // BAGIAN 2: KERANJANG BELANJA (SIDEBAR KANAN)
        // ====================================================

        private void UpdateTampilanKeranjang()
        {
            FlpKeranjang.Controls.Clear();

            // Loop semua item di CartSession
            foreach (var item in CartSession.Items)
            {
                CardKeranjang card = new CardKeranjang();
                card.SetData(item);

                // Event Listener: Kalau jumlah berubah atau item dihapus via tombol (+/-)
                card.OnQtyChanged += (s, e) =>
                {
                    // Update Label Total Harga
                    UpdateInfoTotal();

                    // Kalau itemnya jadi 0 (dihapus), refresh layout biar kartunya hilang
                    if (CartSession.Items.Count != FlpKeranjang.Controls.Count)
                    {
                        UpdateTampilanKeranjang();
                    }
                };

                FlpKeranjang.Controls.Add(card);
            }

            UpdateInfoTotal();
        }

        private void UpdateInfoTotal()
        {
            decimal total = CartSession.GetTotal();
            LblTotal.Text = "Total: Rp " + total.ToString("N0");

            // Matikan tombol bayar kalau keranjang kosong
            BtnBayar.Enabled = CartSession.Items.Count > 0;
        }

        // ====================================================
        // BAGIAN 3: ANIMASI SIDEBAR (SLIDING)
        // ====================================================

        private void BtnToggleMenu_Click(object sender, EventArgs e)
        {
            _isSidebarOpen = !_isSidebarOpen;
            SidebarTimer.Start();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (_isSidebarOpen)
            {
                // MEMBUKA
                PanelSidebar.Width += Speed;

                // Munculin Footer kalau udah agak lebar
                if (PanelSidebar.Width > 200)
                {
                    PanelFooter.Visible = true;
                }

                if (PanelSidebar.Width >= MaxWidth)
                {
                    PanelSidebar.Width = MaxWidth;
                    SidebarTimer.Stop();
                    SetCartVisibility(true);
                }
            }
            else
            {
                // MENUTUP
                PanelSidebar.Width -= Speed;

                // Umpetin Footer pas mulai nutup
                if (PanelSidebar.Width < 200)
                {
                    PanelFooter.Visible = false;
                }

                if (PanelSidebar.Width <= MinWidth)
                {
                    PanelSidebar.Width = MinWidth;
                    SidebarTimer.Stop();
                    SetCartVisibility(false);
                }
            }
        }

        private void BukaSidebarOtomatis()
        {
            if (!_isSidebarOpen)
            {
                _isSidebarOpen = true;
                SidebarTimer.Start();
            }
        }

        private void SetCartVisibility(bool isVisible)
        {
            // Sembunyikan elemen biar rapi pas sidebar lagi ciut
            if (PanelFooter != null) PanelFooter.Visible = isVisible;
            if (FlpKeranjang != null) FlpKeranjang.Visible = isVisible;
        }

        // ====================================================
        // BAGIAN 4: NAVIGASI LAIN
        // ====================================================

        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadKatalogProduk();
            UpdateTampilanKeranjang();
        }

        // --- TOMBOL BAYAR (SUDAH DIAKTIFKAN) ---
        private void BtnBayar_Click(object sender, EventArgs e)
        {
            if (CartSession.Items.Count == 0) return;

            // Buka Form Checkout
            V_DetailPesanan checkoutForm = new V_DetailPesanan();

            // Kalau user sukses bayar (OK)
            if (checkoutForm.ShowDialog() == DialogResult.OK)
            {
                // Keranjang di Session udah dibersihin di form checkout,
                // sekarang tinggal refresh tampilan sidebar biar kosong
                UpdateTampilanKeranjang();

                // Opsional: Tutup sidebar otomatis
                // BtnToggleMenu_Click(sender, e);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _auth.Logout();
                CartSession.Clear(); // Bersihkan cart
                new V_Login().Show();
                this.Close();
            }
        }

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            LoadKatalogProduk();
        }

        // Kosongan
        private void BttnTransaksiPembelian_Click(object sender, EventArgs e) { }
        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e) { }
        private void BttnReview_Click(object sender, EventArgs e) { }
    }
}