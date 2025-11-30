namespace KoiSmart.Views
{
    partial class V_ReviewAdm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_ReviewAdm));
            BttnRefresh = new Button();
            LblUsername = new Label();
            BtnHalamanUtama = new Button();
            FlpReview = new FlowLayoutPanel();
            BtnLogout = new Button();
            BtnReview = new Button();
            BtnLaporanTransaksi = new Button();
            BtnRiwayatTransaksi = new Button();
            BtnTransaksiPenjualan = new Button();
            SuspendLayout();
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1309, 26);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 42;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.White;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.ForeColor = Color.Black;
            LblUsername.Location = new Point(135, 91);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 41;
            LblUsername.Text = "Username";
            // 
            // BtnHalamanUtama
            // 
            BtnHalamanUtama.BackColor = Color.Transparent;
            BtnHalamanUtama.BackgroundImage = (Image)resources.GetObject("BtnHalamanUtama.BackgroundImage");
            BtnHalamanUtama.BackgroundImageLayout = ImageLayout.Center;
            BtnHalamanUtama.FlatStyle = FlatStyle.Flat;
            BtnHalamanUtama.ForeColor = Color.Transparent;
            BtnHalamanUtama.Location = new Point(40, 214);
            BtnHalamanUtama.Margin = new Padding(2);
            BtnHalamanUtama.Name = "BtnHalamanUtama";
            BtnHalamanUtama.Size = new Size(217, 40);
            BtnHalamanUtama.TabIndex = 40;
            BtnHalamanUtama.UseVisualStyleBackColor = false;
            BtnHalamanUtama.Click += BtnHalamanUtama_Click;
            // 
            // FlpReview
            // 
            FlpReview.AutoScroll = true;
            FlpReview.BackColor = Color.White;
            FlpReview.Location = new Point(381, 89);
            FlpReview.Name = "FlpReview";
            FlpReview.Size = new Size(978, 613);
            FlpReview.TabIndex = 39;
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.Transparent;
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.BackgroundImageLayout = ImageLayout.Center;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.ForeColor = Color.Transparent;
            BtnLogout.Location = new Point(65, 616);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(229, 57);
            BtnLogout.TabIndex = 38;
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // BtnReview
            // 
            BtnReview.BackColor = Color.Transparent;
            BtnReview.BackgroundImage = Properties.Resources.Btn_Review_Pelanggan_Adm_Hal_Utama_11;
            BtnReview.FlatStyle = FlatStyle.Flat;
            BtnReview.ForeColor = Color.Transparent;
            BtnReview.Location = new Point(52, 483);
            BtnReview.Margin = new Padding(2);
            BtnReview.Name = "BtnReview";
            BtnReview.Size = new Size(219, 44);
            BtnReview.TabIndex = 37;
            BtnReview.UseVisualStyleBackColor = false;
            // 
            // BtnLaporanTransaksi
            // 
            BtnLaporanTransaksi.BackColor = Color.Transparent;
            BtnLaporanTransaksi.BackgroundImage = Properties.Resources.Btn_Laporan_Transaksi_Adm_Hal_Utama_1;
            BtnLaporanTransaksi.FlatStyle = FlatStyle.Flat;
            BtnLaporanTransaksi.ForeColor = Color.Transparent;
            BtnLaporanTransaksi.Location = new Point(52, 414);
            BtnLaporanTransaksi.Margin = new Padding(2);
            BtnLaporanTransaksi.Name = "BtnLaporanTransaksi";
            BtnLaporanTransaksi.Size = new Size(219, 42);
            BtnLaporanTransaksi.TabIndex = 36;
            BtnLaporanTransaksi.UseVisualStyleBackColor = false;
            BtnLaporanTransaksi.Click += BtnLaporanTransaksi_Click;
            // 
            // BtnRiwayatTransaksi
            // 
            BtnRiwayatTransaksi.BackColor = Color.Transparent;
            BtnRiwayatTransaksi.BackgroundImage = Properties.Resources.Btn_Riwayat_Transaksi_Adm_Hal_Utama_1;
            BtnRiwayatTransaksi.FlatStyle = FlatStyle.Flat;
            BtnRiwayatTransaksi.ForeColor = Color.Transparent;
            BtnRiwayatTransaksi.Location = new Point(52, 346);
            BtnRiwayatTransaksi.Margin = new Padding(2);
            BtnRiwayatTransaksi.Name = "BtnRiwayatTransaksi";
            BtnRiwayatTransaksi.Size = new Size(217, 42);
            BtnRiwayatTransaksi.TabIndex = 35;
            BtnRiwayatTransaksi.UseVisualStyleBackColor = false;
            BtnRiwayatTransaksi.Click += BtnRiwayatTransaksi_Click;
            // 
            // BtnTransaksiPenjualan
            // 
            BtnTransaksiPenjualan.BackColor = Color.Transparent;
            BtnTransaksiPenjualan.BackgroundImage = Properties.Resources.Btn_Transaksi_Penjualan_Adm_Hal_Utama_1;
            BtnTransaksiPenjualan.FlatStyle = FlatStyle.Flat;
            BtnTransaksiPenjualan.ForeColor = Color.Transparent;
            BtnTransaksiPenjualan.Location = new Point(52, 278);
            BtnTransaksiPenjualan.Margin = new Padding(2);
            BtnTransaksiPenjualan.Name = "BtnTransaksiPenjualan";
            BtnTransaksiPenjualan.Size = new Size(228, 40);
            BtnTransaksiPenjualan.TabIndex = 43;
            BtnTransaksiPenjualan.UseVisualStyleBackColor = false;
            BtnTransaksiPenjualan.Click += BtnTransaksiPenjualan_Click;
            // 
            // V_ReviewAdm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.reviewadm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(BtnTransaksiPenjualan);
            Controls.Add(BttnRefresh);
            Controls.Add(LblUsername);
            Controls.Add(BtnHalamanUtama);
            Controls.Add(FlpReview);
            Controls.Add(BtnLogout);
            Controls.Add(BtnReview);
            Controls.Add(BtnLaporanTransaksi);
            Controls.Add(BtnRiwayatTransaksi);
            DoubleBuffered = true;
            Name = "V_ReviewAdm";
            Text = "V_Review";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BttnRefresh;
        private Label LblUsername;
        private Button BtnHalamanUtama;
        private FlowLayoutPanel FlpReview;
        private Button BtnLogout;
        private Button BtnReview;
        private Button BtnLaporanTransaksi;
        private Button BtnRiwayatTransaksi;
        private Button BtnTransaksiPenjualan;
    }
}