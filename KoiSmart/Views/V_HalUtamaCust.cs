using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KoiSmart.Controllers;      
using KoiSmart.Models;            
using KoiSmart.Helpers;          
using KoiSmart.Views.Components; 

namespace KoiSmart.Views
{
    public partial class V_HalUtamaCust : Form
    {
        private bool _isSidebarOpen = false;
        private const int MinWidth = 60;
        private const int MaxWidth = 300;    
        private const int Speed = 30;

        private IkanController _ikanController;
        private AuthController _auth;

        public V_HalUtamaCust()
        {
            InitializeComponent();
            _ikanController = new IkanController();
            _auth = new AuthController();

            PanelSidebar.Width = MinWidth;
            SetCartVisibility(false);
        }

        private void V_HalUtamaCust_Load(object sender, EventArgs e)
        {
            if (AppSession.IsAuthenticated && AppSession.CurrentUser != null)
            {
                LblUsername.Text = AppSession.CurrentUser.NamaDepan + " " + AppSession.CurrentUser.NamaBelakang;
            }

            LoadKatalogProduk();
            UpdateTampilanKeranjang();
        }


        private void LoadKatalogProduk()
        {
            FlpHalUtama.Controls.Clear();

            List<Ikan> listIkan = _ikanController.AmbilSemuaIkan();

            foreach (var ikan in listIkan)
            {
                // create customer card
                CardIkanCust kartu = new CardIkanCust();
                kartu.SetData(ikan);

                kartu.BtnLihat.Click += (s, e) =>
                {
                    BukaDetailProduk(ikan);
                };

                // Only add to flowpanel if produk is considered "Tersedia"
                // CardIkan uses: stok > 0 => Tersedia; otherwise Kosong
                if (ikan.stok > 0)
                {
                    FlpHalUtama.Controls.Add(kartu);
                }
                // else skip adding the card (treat as Kosong)
            }
        }

        private void BukaDetailProduk(Ikan ikan)
        {
            DetailIkanCust detailForm = new DetailIkanCust(ikan);

            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                UpdateTampilanKeranjang();

                BukaSidebarOtomatis();
            }
        }


        private void UpdateTampilanKeranjang()
        {
            FlpKeranjang.Controls.Clear();

            foreach (var item in CartSession.Items)
            {
                CardKeranjang card = new CardKeranjang();
                card.SetData(item);

                card.OnQtyChanged += (s, e) =>
                {
                    UpdateInfoTotal();

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

            BtnBayar.Enabled = CartSession.Items.Count > 0;
        }

        private void BtnToggleMenu_Click(object sender, EventArgs e)
        {
            _isSidebarOpen = !_isSidebarOpen;
            SidebarTimer.Start();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (_isSidebarOpen)
            {
                PanelSidebar.Width += Speed;

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
                PanelSidebar.Width -= Speed;

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
            if (PanelFooter != null) PanelFooter.Visible = isVisible;
            if (FlpKeranjang != null) FlpKeranjang.Visible = isVisible;
        }


        private void BttnRefresh_Click(object sender, EventArgs e)
        {
            LoadKatalogProduk();
            UpdateTampilanKeranjang();
        }

        private void BtnBayar_Click(object sender, EventArgs e)
        {
            if (CartSession.Items.Count == 0) return;

            V_DetailPesanan checkoutForm = new V_DetailPesanan();

            if (checkoutForm.ShowDialog() == DialogResult.OK)
            {
                UpdateTampilanKeranjang();

            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _auth.Logout();
                CartSession.Clear(); 
                new V_Login().Show();
                this.Close();
            }
        }

        private void BttnHalUtama_Click(object sender, EventArgs e)
        {
            LoadKatalogProduk();
        }

        private void BttnTransaksiPembelian_Click(object sender, EventArgs e)
        {
            V_HalTransaksiCust formTransaksi = new V_HalTransaksiCust();
            formTransaksi.Show();

            this.Close();
        }
        private void BttnRiwayatTransaksi_Click(object sender, EventArgs e) 
        {
            V_RiwayatTransaksiCust riwayatForm = new V_RiwayatTransaksiCust();
            riwayatForm.Show();
            this.Close();
        }
        private void BttnReview_Click(object sender, EventArgs e) 
        {
            V_ReviewCust reviewForm = new V_ReviewCust();
            reviewForm.Show();
            this.Close();
        }
    }
}