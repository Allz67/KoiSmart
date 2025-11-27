namespace KoiSmart.Views
{
    partial class V_HalUtamaAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnHalUtama = new Button();
            BtnTransaksiPenjualan = new Button();
            BtnRiwayatTransaksi = new Button();
            BtnLaporanTransaksi = new Button();
            BtnReviewCust = new Button();
            BtnLogout = new Button();
            BtnTambahIkan = new Button();
            SuspendLayout();
            // 
            // BtnHalUtama
            // 
            BtnHalUtama.BackgroundImage = Properties.Resources.Btn_Halaman_Utama_Adm_Hal_Utama_1;
            BtnHalUtama.Location = new Point(55, 235);
            BtnHalUtama.Name = "BtnHalUtama";
            BtnHalUtama.Size = new Size(271, 70);
            BtnHalUtama.TabIndex = 0;
            BtnHalUtama.UseVisualStyleBackColor = true;
            // 
            // BtnTransaksiPenjualan
            // 
            BtnTransaksiPenjualan.BackgroundImage = Properties.Resources.Btn_Transaksi_Penjualan_Adm_Hal_Utama_1;
            BtnTransaksiPenjualan.Location = new Point(72, 332);
            BtnTransaksiPenjualan.Name = "BtnTransaksiPenjualan";
            BtnTransaksiPenjualan.Size = new Size(241, 43);
            BtnTransaksiPenjualan.TabIndex = 1;
            BtnTransaksiPenjualan.UseVisualStyleBackColor = true;
            // 
            // BtnRiwayatTransaksi
            // 
            BtnRiwayatTransaksi.BackgroundImage = Properties.Resources.Btn_Riwayat_Transaksi_Adm_Hal_Utama_1;
            BtnRiwayatTransaksi.Location = new Point(72, 393);
            BtnRiwayatTransaksi.Name = "BtnRiwayatTransaksi";
            BtnRiwayatTransaksi.Size = new Size(241, 43);
            BtnRiwayatTransaksi.TabIndex = 2;
            BtnRiwayatTransaksi.UseVisualStyleBackColor = true;
            // 
            // BtnLaporanTransaksi
            // 
            BtnLaporanTransaksi.BackgroundImage = Properties.Resources.Btn_Laporan_Transaksi_Adm_Hal_Utama_1;
            BtnLaporanTransaksi.Location = new Point(72, 459);
            BtnLaporanTransaksi.Name = "BtnLaporanTransaksi";
            BtnLaporanTransaksi.Size = new Size(241, 43);
            BtnLaporanTransaksi.TabIndex = 3;
            BtnLaporanTransaksi.UseVisualStyleBackColor = true;
            // 
            // BtnReviewCust
            // 
            BtnReviewCust.BackgroundImage = Properties.Resources.Btn_Review_Pelanggan_Adm_Hal_Utama_1;
            BtnReviewCust.Location = new Point(72, 524);
            BtnReviewCust.Name = "BtnReviewCust";
            BtnReviewCust.Size = new Size(241, 43);
            BtnReviewCust.TabIndex = 4;
            BtnReviewCust.UseVisualStyleBackColor = true;
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(72, 696);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(229, 59);
            BtnLogout.TabIndex = 5;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // BtnTambahIkan
            // 
            BtnTambahIkan.BackgroundImage = Properties.Resources.Btn_Tambah_Ikan_Adm_Hal_Utama_1;
            BtnTambahIkan.Location = new Point(1214, 26);
            BtnTambahIkan.Name = "BtnTambahIkan";
            BtnTambahIkan.Size = new Size(181, 54);
            BtnTambahIkan.TabIndex = 6;
            BtnTambahIkan.UseVisualStyleBackColor = true;
            BtnTambahIkan.Click += BtnTambahIkan_Click;
            // 
            // V_HalUtamaAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HalUtama_Adm;
            ClientSize = new Size(1418, 776);
            Controls.Add(BtnTambahIkan);
            Controls.Add(BtnLogout);
            Controls.Add(BtnReviewCust);
            Controls.Add(BtnLaporanTransaksi);
            Controls.Add(BtnRiwayatTransaksi);
            Controls.Add(BtnTransaksiPenjualan);
            Controls.Add(BtnHalUtama);
            Name = "V_HalUtamaAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HalUtamaAdmin";
            Load += V_HalUtamaAdmin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnHalUtama;
        private Button BtnTransaksiPenjualan;
        private Button BtnRiwayatTransaksi;
        private Button BtnLaporanTransaksi;
        private Button BtnReviewCust;
        private Button BtnLogout;
        private Button BtnTambahIkan;
    }
}