namespace KoiSmart.Views
{
    partial class V_HalTransaksi
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
            LblUsername = new Label();
            BtnLogout = new Button();
            BttnHalUtama = new Button();
            BttnReview = new Button();
            BttnRiwayatTransaksi = new Button();
            BttnTransaksiPembelian = new Button();
            FlpContent = new FlowLayoutPanel();
            BttnRefresh = new Button();
            SuspendLayout();
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.ForeColor = Color.Black;
            LblUsername.Location = new Point(139, 98);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 12;
            LblUsername.Text = "Username";
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(66, 618);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(228, 57);
            BtnLogout.TabIndex = 17;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // BttnHalUtama
            // 
            BttnHalUtama.BackgroundImage = Properties.Resources.btnhalutamawhite2;
            BttnHalUtama.Location = new Point(66, 220);
            BttnHalUtama.Margin = new Padding(2);
            BttnHalUtama.Name = "BttnHalUtama";
            BttnHalUtama.Size = new Size(228, 59);
            BttnHalUtama.TabIndex = 16;
            BttnHalUtama.UseVisualStyleBackColor = true;
            BttnHalUtama.Click += BttnHalUtama_Click;
            // 
            // BttnReview
            // 
            BttnReview.BackgroundImage = Properties.Resources.btn_review;
            BttnReview.Location = new Point(66, 461);
            BttnReview.Name = "BttnReview";
            BttnReview.Size = new Size(228, 55);
            BttnReview.TabIndex = 15;
            BttnReview.UseVisualStyleBackColor = true;
            BttnReview.Click += BttnReview_Click;
            // 
            // BttnRiwayatTransaksi
            // 
            BttnRiwayatTransaksi.BackgroundImage = Properties.Resources.btn_riwayat;
            BttnRiwayatTransaksi.Location = new Point(66, 378);
            BttnRiwayatTransaksi.Name = "BttnRiwayatTransaksi";
            BttnRiwayatTransaksi.Size = new Size(228, 59);
            BttnRiwayatTransaksi.TabIndex = 14;
            BttnRiwayatTransaksi.UseVisualStyleBackColor = true;
            BttnRiwayatTransaksi.Click += BttnRiwayatTransaksi_Click;
            // 
            // BttnTransaksiPembelian
            // 
            BttnTransaksiPembelian.BackColor = Color.Transparent;
            BttnTransaksiPembelian.BackgroundImage = Properties.Resources.btntransaksipembelianblue;
            BttnTransaksiPembelian.BackgroundImageLayout = ImageLayout.Stretch;
            BttnTransaksiPembelian.FlatStyle = FlatStyle.Flat;
            BttnTransaksiPembelian.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnTransaksiPembelian.ForeColor = Color.Transparent;
            BttnTransaksiPembelian.Location = new Point(66, 298);
            BttnTransaksiPembelian.Name = "BttnTransaksiPembelian";
            BttnTransaksiPembelian.Size = new Size(250, 55);
            BttnTransaksiPembelian.TabIndex = 13;
            BttnTransaksiPembelian.UseVisualStyleBackColor = false;
            BttnTransaksiPembelian.Click += BttnTransaksiPembelian_Click;
            // 
            // FlpContent
            // 
            FlpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FlpContent.AutoScroll = true;
            FlpContent.BackColor = SystemColors.Window;
            FlpContent.FlowDirection = FlowDirection.TopDown;
            FlpContent.Location = new Point(376, 98);
            FlpContent.Name = "FlpContent";
            FlpContent.Size = new Size(980, 606);
            FlpContent.TabIndex = 18;
            FlpContent.WrapContents = false;
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1306, 37);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 19;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // V_HalTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.halTransaksi;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(BttnRefresh);
            Controls.Add(FlpContent);
            Controls.Add(BtnLogout);
            Controls.Add(BttnHalUtama);
            Controls.Add(BttnReview);
            Controls.Add(BttnRiwayatTransaksi);
            Controls.Add(BttnTransaksiPembelian);
            Controls.Add(LblUsername);
            DoubleBuffered = true;
            Name = "V_HalTransaksi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_HalTransaksi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblUsername;
        private Button BtnLogout;
        private Button BttnHalUtama;
        private Button BttnReview;
        private Button BttnRiwayatTransaksi;
        private Button BttnTransaksiPembelian;
        private FlowLayoutPanel FlpContent;
        private Button BttnRefresh;
    }
}