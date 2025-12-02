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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
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
            LblUsername.Location = new Point(135, 95);
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
            BtnHalamanUtama.Location = new Point(2, 2);
            BtnHalamanUtama.Margin = new Padding(2);
            BtnHalamanUtama.Name = "BtnHalamanUtama";
            BtnHalamanUtama.Size = new Size(191, 40);
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
            BtnReview.BackgroundImageLayout = ImageLayout.Center;
            BtnReview.FlatStyle = FlatStyle.Flat;
            BtnReview.ForeColor = Color.Transparent;
            BtnReview.Location = new Point(2, 199);
            BtnReview.Margin = new Padding(2);
            BtnReview.Name = "BtnReview";
            BtnReview.Size = new Size(267, 47);
            BtnReview.TabIndex = 37;
            BtnReview.UseVisualStyleBackColor = false;
            // 
            // BtnLaporanTransaksi
            // 
            BtnLaporanTransaksi.BackColor = Color.Transparent;
            BtnLaporanTransaksi.BackgroundImage = Properties.Resources.Btn_Laporan_Transaksi_Adm_Hal_Utama_1;
            BtnLaporanTransaksi.FlatStyle = FlatStyle.Flat;
            BtnLaporanTransaksi.ForeColor = Color.Transparent;
            BtnLaporanTransaksi.Location = new Point(2, 151);
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
            BtnRiwayatTransaksi.Location = new Point(2, 99);
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
            BtnTransaksiPenjualan.Location = new Point(2, 50);
            BtnTransaksiPenjualan.Margin = new Padding(2);
            BtnTransaksiPenjualan.Name = "BtnTransaksiPenjualan";
            BtnTransaksiPenjualan.Size = new Size(228, 40);
            BtnTransaksiPenjualan.TabIndex = 43;
            BtnTransaksiPenjualan.UseVisualStyleBackColor = false;
            BtnTransaksiPenjualan.Click += BtnTransaksiPenjualan_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BtnTransaksiPenjualan, 0, 1);
            tableLayoutPanel1.Controls.Add(BtnHalamanUtama, 0, 0);
            tableLayoutPanel1.Controls.Add(BtnRiwayatTransaksi, 0, 2);
            tableLayoutPanel1.Controls.Add(BtnLaporanTransaksi, 0, 3);
            tableLayoutPanel1.Controls.Add(BtnReview, 0, 4);
            tableLayoutPanel1.Location = new Point(41, 209);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5714283F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.9285717F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2290077F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.70229F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.42748F));
            tableLayoutPanel1.Size = new Size(286, 262);
            tableLayoutPanel1.TabIndex = 44;
            // 
            // V_ReviewAdm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.reviewadm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BttnRefresh);
            Controls.Add(LblUsername);
            Controls.Add(FlpReview);
            Controls.Add(BtnLogout);
            DoubleBuffered = true;
            Name = "V_ReviewAdm";
            Text = "V_Review";
            tableLayoutPanel1.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}