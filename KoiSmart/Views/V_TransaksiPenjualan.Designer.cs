namespace KoiSmart.Views
{
    partial class V_TransaksiPenjualan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_TransaksiPenjualan));
            BtnLogout = new Button();
            BtnReviewCust = new Button();
            BtnLaporanTransaksi = new Button();
            BtnRiwayatTransaksi = new Button();
            BtnHalUtama = new Button();
            FlpTransPenjualan = new FlowLayoutPanel();
            BtnHalamanUtama = new Button();
            SuspendLayout();
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.Transparent;
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.BackgroundImageLayout = ImageLayout.Center;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.ForeColor = Color.Transparent;
            BtnLogout.Location = new Point(66, 620);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(229, 57);
            BtnLogout.TabIndex = 11;
            BtnLogout.UseVisualStyleBackColor = false;
            // 
            // BtnReviewCust
            // 
            BtnReviewCust.BackColor = Color.Transparent;
            BtnReviewCust.BackgroundImage = Properties.Resources.Btn_Review_Pelanggan_Adm_Hal_Utama_1;
            BtnReviewCust.FlatStyle = FlatStyle.Flat;
            BtnReviewCust.ForeColor = Color.Transparent;
            BtnReviewCust.Location = new Point(53, 479);
            BtnReviewCust.Margin = new Padding(2);
            BtnReviewCust.Name = "BtnReviewCust";
            BtnReviewCust.Size = new Size(219, 44);
            BtnReviewCust.TabIndex = 10;
            BtnReviewCust.UseVisualStyleBackColor = false;
            // 
            // BtnLaporanTransaksi
            // 
            BtnLaporanTransaksi.BackColor = Color.Transparent;
            BtnLaporanTransaksi.BackgroundImage = Properties.Resources.Btn_Laporan_Transaksi_Adm_Hal_Utama_1;
            BtnLaporanTransaksi.FlatStyle = FlatStyle.Flat;
            BtnLaporanTransaksi.ForeColor = Color.Transparent;
            BtnLaporanTransaksi.Location = new Point(53, 418);
            BtnLaporanTransaksi.Margin = new Padding(2);
            BtnLaporanTransaksi.Name = "BtnLaporanTransaksi";
            BtnLaporanTransaksi.Size = new Size(219, 42);
            BtnLaporanTransaksi.TabIndex = 9;
            BtnLaporanTransaksi.UseVisualStyleBackColor = false;
            // 
            // BtnRiwayatTransaksi
            // 
            BtnRiwayatTransaksi.BackColor = Color.Transparent;
            BtnRiwayatTransaksi.BackgroundImage = Properties.Resources.Btn_Riwayat_Transaksi_Adm_Hal_Utama_1;
            BtnRiwayatTransaksi.FlatStyle = FlatStyle.Flat;
            BtnRiwayatTransaksi.ForeColor = Color.Transparent;
            BtnRiwayatTransaksi.Location = new Point(53, 356);
            BtnRiwayatTransaksi.Margin = new Padding(2);
            BtnRiwayatTransaksi.Name = "BtnRiwayatTransaksi";
            BtnRiwayatTransaksi.Size = new Size(217, 42);
            BtnRiwayatTransaksi.TabIndex = 8;
            BtnRiwayatTransaksi.UseVisualStyleBackColor = false;
            // 
            // BtnHalUtama
            // 
            BtnHalUtama.BackColor = Color.Transparent;
            BtnHalUtama.BackgroundImage = (Image)resources.GetObject("BtnHalUtama.BackgroundImage");
            BtnHalUtama.BackgroundImageLayout = ImageLayout.Center;
            BtnHalUtama.FlatStyle = FlatStyle.Flat;
            BtnHalUtama.ForeColor = Color.Transparent;
            BtnHalUtama.Location = new Point(44, 270);
            BtnHalUtama.Margin = new Padding(2);
            BtnHalUtama.Name = "BtnHalUtama";
            BtnHalUtama.Size = new Size(273, 71);
            BtnHalUtama.TabIndex = 6;
            BtnHalUtama.UseVisualStyleBackColor = false;
            // 
            // FlpTransPenjualan
            // 
            FlpTransPenjualan.AutoScroll = true;
            FlpTransPenjualan.BackColor = Color.White;
            FlpTransPenjualan.Location = new Point(382, 93);
            FlpTransPenjualan.Name = "FlpTransPenjualan";
            FlpTransPenjualan.Size = new Size(978, 613);
            FlpTransPenjualan.TabIndex = 12;
            // 
            // BtnHalamanUtama
            // 
            BtnHalamanUtama.BackColor = Color.Transparent;
            BtnHalamanUtama.BackgroundImage = (Image)resources.GetObject("BtnHalamanUtama.BackgroundImage");
            BtnHalamanUtama.BackgroundImageLayout = ImageLayout.Center;
            BtnHalamanUtama.FlatStyle = FlatStyle.Flat;
            BtnHalamanUtama.ForeColor = Color.Transparent;
            BtnHalamanUtama.Location = new Point(41, 218);
            BtnHalamanUtama.Margin = new Padding(2);
            BtnHalamanUtama.Name = "BtnHalamanUtama";
            BtnHalamanUtama.Size = new Size(217, 40);
            BtnHalamanUtama.TabIndex = 13;
            BtnHalamanUtama.UseVisualStyleBackColor = false;
            BtnHalamanUtama.Click += BtnHalamanUtama_Click;
            // 
            // V_TransaksiPenjualan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(BtnHalamanUtama);
            Controls.Add(FlpTransPenjualan);
            Controls.Add(BtnLogout);
            Controls.Add(BtnReviewCust);
            Controls.Add(BtnLaporanTransaksi);
            Controls.Add(BtnRiwayatTransaksi);
            Controls.Add(BtnHalUtama);
            DoubleBuffered = true;
            Name = "V_TransaksiPenjualan";
            Text = "V_TransaksiPenjualan";
            ResumeLayout(false);
        }

        #endregion
        private Button BtnLogout;
        private Button BtnReviewCust;
        private Button BtnLaporanTransaksi;
        private Button BtnRiwayatTransaksi;
        private Button BtnHalUtama;
        private FlowLayoutPanel FlpTransPenjualan;
        private Button BtnHalamanUtama;
    }
}