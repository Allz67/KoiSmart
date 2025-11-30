namespace KoiSmart.Views
{
    partial class V_RiwayatTransaksiAdm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_RiwayatTransaksiAdm));
            BtnRiwayatTransaksi = new Button();
            BttnRefresh = new Button();
            FlpContent = new FlowLayoutPanel();
            BtnLogout = new Button();
            LblUsername = new Label();
            BtnReviewCust = new Button();
            BtnLaporanTransaksi = new Button();
            BtnHalamanUtama = new Button();
            BtnTransaksiPenjualan = new Button();
            SuspendLayout();
            // 
            // BtnRiwayatTransaksi
            // 
            BtnRiwayatTransaksi.BackgroundImage = Properties.Resources.Btn_Riwayat_Transaksi_Adm_Hal_Utama_11;
            BtnRiwayatTransaksi.BackgroundImageLayout = ImageLayout.Center;
            BtnRiwayatTransaksi.Location = new Point(54, 345);
            BtnRiwayatTransaksi.Name = "BtnRiwayatTransaksi";
            BtnRiwayatTransaksi.Size = new Size(228, 59);
            BtnRiwayatTransaksi.TabIndex = 34;
            BtnRiwayatTransaksi.UseVisualStyleBackColor = true;
            BtnRiwayatTransaksi.Click += BttnRiwayatTransaksi_Click;
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1307, 30);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 33;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // FlpContent
            // 
            FlpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FlpContent.AutoScroll = true;
            FlpContent.BackColor = SystemColors.Window;
            FlpContent.FlowDirection = FlowDirection.TopDown;
            FlpContent.Location = new Point(377, 92);
            FlpContent.Name = "FlpContent";
            FlpContent.Size = new Size(980, 611);
            FlpContent.TabIndex = 32;
            FlpContent.WrapContents = false;
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(54, 612);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(228, 57);
            BtnLogout.TabIndex = 31;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.ForeColor = Color.Black;
            LblUsername.Location = new Point(127, 92);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 28;
            LblUsername.Text = "Username";
            // 
            // BtnReviewCust
            // 
            BtnReviewCust.BackColor = Color.Transparent;
            BtnReviewCust.BackgroundImage = Properties.Resources.Btn_Review_Pelanggan_Adm_Hal_Utama_1;
            BtnReviewCust.FlatStyle = FlatStyle.Flat;
            BtnReviewCust.ForeColor = Color.Transparent;
            BtnReviewCust.Location = new Point(54, 483);
            BtnReviewCust.Margin = new Padding(2);
            BtnReviewCust.Name = "BtnReviewCust";
            BtnReviewCust.Size = new Size(219, 44);
            BtnReviewCust.TabIndex = 36;
            BtnReviewCust.UseVisualStyleBackColor = false;
            BtnReviewCust.Click += BtnReviewCust_Click;
            // 
            // BtnLaporanTransaksi
            // 
            BtnLaporanTransaksi.BackColor = Color.Transparent;
            BtnLaporanTransaksi.BackgroundImage = Properties.Resources.Btn_Laporan_Transaksi_Adm_Hal_Utama_1;
            BtnLaporanTransaksi.FlatStyle = FlatStyle.Flat;
            BtnLaporanTransaksi.ForeColor = Color.Transparent;
            BtnLaporanTransaksi.Location = new Point(54, 424);
            BtnLaporanTransaksi.Margin = new Padding(2);
            BtnLaporanTransaksi.Name = "BtnLaporanTransaksi";
            BtnLaporanTransaksi.Size = new Size(219, 42);
            BtnLaporanTransaksi.TabIndex = 35;
            BtnLaporanTransaksi.UseVisualStyleBackColor = false;
            BtnLaporanTransaksi.Click += BtnLaporanTransaksi_Click;
            // 
            // BtnHalamanUtama
            // 
            BtnHalamanUtama.BackColor = Color.Transparent;
            BtnHalamanUtama.BackgroundImage = (Image)resources.GetObject("BtnHalamanUtama.BackgroundImage");
            BtnHalamanUtama.BackgroundImageLayout = ImageLayout.Center;
            BtnHalamanUtama.FlatStyle = FlatStyle.Flat;
            BtnHalamanUtama.ForeColor = Color.Transparent;
            BtnHalamanUtama.Location = new Point(41, 227);
            BtnHalamanUtama.Margin = new Padding(2);
            BtnHalamanUtama.Name = "BtnHalamanUtama";
            BtnHalamanUtama.Size = new Size(232, 40);
            BtnHalamanUtama.TabIndex = 37;
            BtnHalamanUtama.UseVisualStyleBackColor = false;
            BtnHalamanUtama.Click += BtnHalamanUtama_Click;
            // 
            // BtnTransaksiPenjualan
            // 
            BtnTransaksiPenjualan.BackColor = Color.Transparent;
            BtnTransaksiPenjualan.BackgroundImage = Properties.Resources.Btn_Transaksi_Penjualan_Adm_Hal_Utama_1;
            BtnTransaksiPenjualan.FlatStyle = FlatStyle.Flat;
            BtnTransaksiPenjualan.ForeColor = Color.Transparent;
            BtnTransaksiPenjualan.Location = new Point(54, 285);
            BtnTransaksiPenjualan.Margin = new Padding(2);
            BtnTransaksiPenjualan.Name = "BtnTransaksiPenjualan";
            BtnTransaksiPenjualan.Size = new Size(228, 40);
            BtnTransaksiPenjualan.TabIndex = 38;
            BtnTransaksiPenjualan.UseVisualStyleBackColor = false;
            BtnTransaksiPenjualan.Click += BtnTransaksiPenjualan_Click;
            // 
            // V_RiwayatTransaksiAdm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HalRiwayatAdm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(BtnTransaksiPenjualan);
            Controls.Add(BtnHalamanUtama);
            Controls.Add(BtnReviewCust);
            Controls.Add(BtnLaporanTransaksi);
            Controls.Add(BtnRiwayatTransaksi);
            Controls.Add(BttnRefresh);
            Controls.Add(FlpContent);
            Controls.Add(BtnLogout);
            Controls.Add(LblUsername);
            DoubleBuffered = true;
            Name = "V_RiwayatTransaksiAdm";
            Text = "V_RiwayatTransaksiAdm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnRiwayatTransaksi;
        private Button BttnRefresh;
        private FlowLayoutPanel FlpContent;
        private Button BtnLogout;
        private Label LblUsername;
        private Button BtnReviewCust;
        private Button BtnLaporanTransaksi;
        private Button BtnHalamanUtama;
        private Button BtnTransaksiPenjualan;
    }
}