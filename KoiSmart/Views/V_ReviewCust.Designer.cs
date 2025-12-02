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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_ReviewCust));
            BttnRefresh = new Button();
            BtnLogout = new Button();
            BttnHalUtama = new Button();
            BttnReview = new Button();
            BttnRiwayatTransaksi = new Button();
            LblUsername = new Label();
            FlpReview = new FlowLayoutPanel();
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
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
            BttnHalUtama.BackgroundImage = (Image)resources.GetObject("BttnHalUtama.BackgroundImage");
            BttnHalUtama.BackgroundImageLayout = ImageLayout.Center;
            BttnHalUtama.FlatStyle = FlatStyle.Flat;
            BttnHalUtama.ForeColor = Color.Transparent;
            BttnHalUtama.Location = new Point(2, 2);
            BttnHalUtama.Margin = new Padding(2);
            BttnHalUtama.Name = "BttnHalUtama";
            BttnHalUtama.Size = new Size(210, 50);
            BttnHalUtama.TabIndex = 24;
            BttnHalUtama.UseVisualStyleBackColor = true;
            BttnHalUtama.Click += BttnHalUtama_Click;
            // 
            // BttnReview
            // 
            BttnReview.BackgroundImage = (Image)resources.GetObject("BttnReview.BackgroundImage");
            BttnReview.BackgroundImageLayout = ImageLayout.Center;
            BttnReview.FlatStyle = FlatStyle.Flat;
            BttnReview.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnReview.ForeColor = Color.Transparent;
            BttnReview.Location = new Point(3, 165);
            BttnReview.Name = "BttnReview";
            BttnReview.Padding = new Padding(20, 0, 0, 0);
            BttnReview.Size = new Size(280, 67);
            BttnReview.TabIndex = 23;
            BttnReview.TextAlign = ContentAlignment.MiddleLeft;
            BttnReview.UseVisualStyleBackColor = true;
            // 
            // BttnRiwayatTransaksi
            // 
            BttnRiwayatTransaksi.BackgroundImage = (Image)resources.GetObject("BttnRiwayatTransaksi.BackgroundImage");
            BttnRiwayatTransaksi.BackgroundImageLayout = ImageLayout.Center;
            BttnRiwayatTransaksi.FlatStyle = FlatStyle.Flat;
            BttnRiwayatTransaksi.ForeColor = Color.Transparent;
            BttnRiwayatTransaksi.Location = new Point(3, 114);
            BttnRiwayatTransaksi.Name = "BttnRiwayatTransaksi";
            BttnRiwayatTransaksi.Size = new Size(228, 45);
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
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(3, 57);
            button1.Name = "button1";
            button1.Size = new Size(253, 48);
            button1.TabIndex = 41;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Controls.Add(BttnReview, 0, 3);
            tableLayoutPanel1.Controls.Add(BttnRiwayatTransaksi, 0, 2);
            tableLayoutPanel1.Controls.Add(BttnHalUtama, 0, 0);
            tableLayoutPanel1.Location = new Point(39, 212);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.9787235F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.25532F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.7021275F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.4147472F));
            tableLayoutPanel1.Size = new Size(286, 235);
            tableLayoutPanel1.TabIndex = 42;
            // 
            // V_ReviewCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.reviewcust;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(FlpReview);
            Controls.Add(BttnRefresh);
            Controls.Add(BtnLogout);
            Controls.Add(LblUsername);
            DoubleBuffered = true;
            Name = "V_ReviewCust";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_ReviewCust";
            tableLayoutPanel1.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}