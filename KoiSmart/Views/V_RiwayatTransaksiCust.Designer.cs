namespace KoiSmart.Views
{
    partial class V_RiwayatTransaksiCust
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
            BttnRefresh = new Button();
            FlpContent = new FlowLayoutPanel();
            BtnLogout = new Button();
            BttnHalUtama = new Button();
            BttnReview = new Button();
            LblUsername = new Label();
            BttnTransaksiPembelian = new Button();
            BttnRiwayatTransaksi = new Button();
            SuspendLayout();
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1294, 31);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 25;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // FlpContent
            // 
            FlpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FlpContent.AutoScroll = true;
            FlpContent.BackColor = SystemColors.Window;
            FlpContent.FlowDirection = FlowDirection.TopDown;
            FlpContent.Location = new Point(364, 92);
            FlpContent.Name = "FlpContent";
            FlpContent.Size = new Size(980, 606);
            FlpContent.TabIndex = 24;
            FlpContent.WrapContents = false;
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(54, 612);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(228, 57);
            BtnLogout.TabIndex = 23;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // BttnHalUtama
            // 
            BttnHalUtama.BackgroundImage = Properties.Resources.btnhalutamawhite2;
            BttnHalUtama.Location = new Point(54, 214);
            BttnHalUtama.Margin = new Padding(2);
            BttnHalUtama.Name = "BttnHalUtama";
            BttnHalUtama.Size = new Size(228, 59);
            BttnHalUtama.TabIndex = 22;
            BttnHalUtama.UseVisualStyleBackColor = true;
            BttnHalUtama.Click += BttnHalUtama_Click;
            // 
            // BttnReview
            // 
            BttnReview.BackgroundImage = Properties.Resources.btn_review;
            BttnReview.Location = new Point(54, 455);
            BttnReview.Name = "BttnReview";
            BttnReview.Size = new Size(228, 55);
            BttnReview.TabIndex = 21;
            BttnReview.UseVisualStyleBackColor = true;
            BttnReview.Click += BttnReview_Click;
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
            LblUsername.TabIndex = 20;
            LblUsername.Text = "Username";
            // 
            // BttnTransaksiPembelian
            // 
            BttnTransaksiPembelian.BackColor = Color.Transparent;
            BttnTransaksiPembelian.BackgroundImage = Properties.Resources.btn_transaksipembelian2;
            BttnTransaksiPembelian.BackgroundImageLayout = ImageLayout.Stretch;
            BttnTransaksiPembelian.FlatStyle = FlatStyle.Flat;
            BttnTransaksiPembelian.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnTransaksiPembelian.ForeColor = Color.Transparent;
            BttnTransaksiPembelian.Location = new Point(54, 300);
            BttnTransaksiPembelian.Name = "BttnTransaksiPembelian";
            BttnTransaksiPembelian.Size = new Size(250, 55);
            BttnTransaksiPembelian.TabIndex = 26;
            BttnTransaksiPembelian.UseVisualStyleBackColor = false;
            BttnTransaksiPembelian.Click += BttnTransaksiPembelian_Click;
            // 
            // BttnRiwayatTransaksi
            // 
            BttnRiwayatTransaksi.BackgroundImage = Properties.Resources.Btn_Riwayat_Transaksi_Adm_Hal_Utama_11;
            BttnRiwayatTransaksi.BackgroundImageLayout = ImageLayout.Center;
            BttnRiwayatTransaksi.Location = new Point(54, 372);
            BttnRiwayatTransaksi.Name = "BttnRiwayatTransaksi";
            BttnRiwayatTransaksi.Size = new Size(228, 59);
            BttnRiwayatTransaksi.TabIndex = 27;
            BttnRiwayatTransaksi.UseVisualStyleBackColor = true;
            BttnRiwayatTransaksi.Click += BttnRiwayatTransaksi_Click;
            // 
            // V_RiwayatTransaksiCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HalRiwayatAdm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(BttnRiwayatTransaksi);
            Controls.Add(BttnTransaksiPembelian);
            Controls.Add(BttnRefresh);
            Controls.Add(FlpContent);
            Controls.Add(BtnLogout);
            Controls.Add(BttnHalUtama);
            Controls.Add(BttnReview);
            Controls.Add(LblUsername);
            DoubleBuffered = true;
            Name = "V_RiwayatTransaksiCust";
            Text = "V_RiwayatTransaksiCust";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BttnRefresh;
        private FlowLayoutPanel FlpContent;
        private Button BtnLogout;
        private Button BttnHalUtama;
        private Button BttnReview;
        private Label LblUsername;
        private Button BttnTransaksiPembelian;
        private Button BttnRiwayatTransaksi;
    }
}