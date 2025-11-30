namespace KoiSmart.Views
{
    partial class V_ReviewCust
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
            BtnLogout = new Button();
            BttnHalUtama = new Button();
            BttnReview = new Button();
            BttnRiwayatTransaksi = new Button();
            LblUsername = new Label();
            FlpReview = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1303, 34);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 26;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(54, 626);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(228, 57);
            BtnLogout.TabIndex = 25;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // BttnHalUtama
            // 
            BttnHalUtama.BackgroundImage = Properties.Resources.btnhalutamawhite2;
            BttnHalUtama.Location = new Point(54, 228);
            BttnHalUtama.Margin = new Padding(2);
            BttnHalUtama.Name = "BttnHalUtama";
            BttnHalUtama.Size = new Size(228, 59);
            BttnHalUtama.TabIndex = 24;
            BttnHalUtama.UseVisualStyleBackColor = true;
            BttnHalUtama.Click += BttnHalUtama_Click;
            // 
            // BttnReview
            // 
            BttnReview.BackgroundImage = Properties.Resources.sidebar;
            BttnReview.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnReview.ForeColor = Color.White;
            BttnReview.Location = new Point(54, 469);
            BttnReview.Name = "BttnReview";
            BttnReview.Padding = new Padding(20, 0, 0, 0);
            BttnReview.Size = new Size(228, 55);
            BttnReview.TabIndex = 23;
            BttnReview.Text = "Review";
            BttnReview.TextAlign = ContentAlignment.MiddleLeft;
            BttnReview.UseVisualStyleBackColor = true;
            // 
            // BttnRiwayatTransaksi
            // 
            BttnRiwayatTransaksi.BackgroundImage = Properties.Resources.btn_riwayat;
            BttnRiwayatTransaksi.Location = new Point(54, 386);
            BttnRiwayatTransaksi.Name = "BttnRiwayatTransaksi";
            BttnRiwayatTransaksi.Size = new Size(228, 59);
            BttnRiwayatTransaksi.TabIndex = 22;
            BttnRiwayatTransaksi.UseVisualStyleBackColor = true;
            BttnRiwayatTransaksi.Click += BttnRiwayatTransaksi_Click;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.ForeColor = Color.Black;
            LblUsername.Location = new Point(135, 97);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 20;
            LblUsername.Text = "Username";
            // 
            // FlpReview
            // 
            FlpReview.AutoScroll = true;
            FlpReview.BackColor = Color.White;
            FlpReview.Location = new Point(375, 97);
            FlpReview.Name = "FlpReview";
            FlpReview.Size = new Size(978, 613);
            FlpReview.TabIndex = 40;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.btn_transaksipembelian2;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(54, 310);
            button1.Name = "button1";
            button1.Size = new Size(250, 55);
            button1.TabIndex = 41;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // V_ReviewCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.reviewcust;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(button1);
            Controls.Add(FlpReview);
            Controls.Add(BttnRefresh);
            Controls.Add(BtnLogout);
            Controls.Add(BttnHalUtama);
            Controls.Add(BttnReview);
            Controls.Add(BttnRiwayatTransaksi);
            Controls.Add(LblUsername);
            DoubleBuffered = true;
            Name = "V_ReviewCust";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_ReviewCust";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BttnRefresh;
        private Button BtnLogout;
        private Button BttnHalUtama;
        private Button BttnReview;
        private Button BttnRiwayatTransaksi;
        private Label LblUsername;
        private FlowLayoutPanel FlpReview;
        private Button button1;
    }
}