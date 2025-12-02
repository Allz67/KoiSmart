namespace KoiSmart.Views
{
    partial class V_HalUtamaCust
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_HalUtamaCust));
            LbUsernameDb = new Label();
            BttnTransaksiPembelian = new Button();
            BttnRiwayatTransaksi = new Button();
            BttnReview = new Button();
            BttnHalUtama = new Button();
            BtnLogout = new Button();
            FlpHalUtama = new FlowLayoutPanel();
            BttnRefresh = new Button();
            PanelSidebar = new Panel();
            PanelFooter = new Panel();
            BtnBayar = new Button();
            LblTotal = new Label();
            FlpKeranjang = new FlowLayoutPanel();
            BtnToggleMenu = new Button();
            SidebarTimer = new System.Windows.Forms.Timer(components);
            LblUsername = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            PanelSidebar.SuspendLayout();
            PanelFooter.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // LbUsernameDb
            // 
            LbUsernameDb.AutoSize = true;
            LbUsernameDb.BackColor = Color.Transparent;
            LbUsernameDb.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbUsernameDb.Location = new Point(137, 99);
            LbUsernameDb.Name = "LbUsernameDb";
            LbUsernameDb.Size = new Size(104, 28);
            LbUsernameDb.TabIndex = 0;
            LbUsernameDb.Text = "Username";
            // 
            // BttnTransaksiPembelian
            // 
            BttnTransaksiPembelian.BackColor = Color.Transparent;
            BttnTransaksiPembelian.BackgroundImage = (Image)resources.GetObject("BttnTransaksiPembelian.BackgroundImage");
            BttnTransaksiPembelian.BackgroundImageLayout = ImageLayout.Center;
            BttnTransaksiPembelian.FlatStyle = FlatStyle.Flat;
            BttnTransaksiPembelian.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnTransaksiPembelian.ForeColor = Color.Transparent;
            BttnTransaksiPembelian.Location = new Point(3, 75);
            BttnTransaksiPembelian.Name = "BttnTransaksiPembelian";
            BttnTransaksiPembelian.Size = new Size(250, 48);
            BttnTransaksiPembelian.TabIndex = 2;
            BttnTransaksiPembelian.UseVisualStyleBackColor = false;
            BttnTransaksiPembelian.Click += BttnTransaksiPembelian_Click;
            // 
            // BttnRiwayatTransaksi
            // 
            BttnRiwayatTransaksi.BackgroundImage = (Image)resources.GetObject("BttnRiwayatTransaksi.BackgroundImage");
            BttnRiwayatTransaksi.BackgroundImageLayout = ImageLayout.Center;
            BttnRiwayatTransaksi.FlatStyle = FlatStyle.Flat;
            BttnRiwayatTransaksi.Location = new Point(3, 129);
            BttnRiwayatTransaksi.Name = "BttnRiwayatTransaksi";
            BttnRiwayatTransaksi.Size = new Size(228, 47);
            BttnRiwayatTransaksi.TabIndex = 3;
            BttnRiwayatTransaksi.UseVisualStyleBackColor = true;
            BttnRiwayatTransaksi.Click += BttnRiwayatTransaksi_Click;
            // 
            // BttnReview
            // 
            BttnReview.BackgroundImage = (Image)resources.GetObject("BttnReview.BackgroundImage");
            BttnReview.BackgroundImageLayout = ImageLayout.Center;
            BttnReview.FlatStyle = FlatStyle.Flat;
            BttnReview.Location = new Point(3, 182);
            BttnReview.Name = "BttnReview";
            BttnReview.Size = new Size(118, 50);
            BttnReview.TabIndex = 4;
            BttnReview.UseVisualStyleBackColor = true;
            BttnReview.Click += BttnReview_Click;
            // 
            // BttnHalUtama
            // 
            BttnHalUtama.BackgroundImage = Properties.Resources.Btn_Halaman_Utama_Adm_Hal_Utama_1;
            BttnHalUtama.BackgroundImageLayout = ImageLayout.Center;
            BttnHalUtama.FlatStyle = FlatStyle.Flat;
            BttnHalUtama.Location = new Point(2, 2);
            BttnHalUtama.Margin = new Padding(2);
            BttnHalUtama.Name = "BttnHalUtama";
            BttnHalUtama.Size = new Size(277, 68);
            BttnHalUtama.TabIndex = 6;
            BttnHalUtama.UseVisualStyleBackColor = true;
            BttnHalUtama.Click += BttnHalUtama_Click;
            // 
            // BtnLogout
            // 
            BtnLogout.BackgroundImage = Properties.Resources.Btn_Logout_Adm_Hal_Utama_1;
            BtnLogout.Location = new Point(70, 624);
            BtnLogout.Margin = new Padding(2);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(228, 57);
            BtnLogout.TabIndex = 7;
            BtnLogout.UseVisualStyleBackColor = true;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // FlpHalUtama
            // 
            FlpHalUtama.AutoScroll = true;
            FlpHalUtama.BackColor = Color.White;
            FlpHalUtama.BackgroundImageLayout = ImageLayout.Zoom;
            FlpHalUtama.Location = new Point(352, 92);
            FlpHalUtama.Name = "FlpHalUtama";
            FlpHalUtama.Size = new Size(978, 613);
            FlpHalUtama.TabIndex = 8;
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1271, 37);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 9;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // PanelSidebar
            // 
            PanelSidebar.BackColor = Color.Transparent;
            PanelSidebar.BackgroundImage = Properties.Resources.sidebar;
            PanelSidebar.Controls.Add(PanelFooter);
            PanelSidebar.Controls.Add(FlpKeranjang);
            PanelSidebar.Controls.Add(BtnToggleMenu);
            PanelSidebar.Dock = DockStyle.Right;
            PanelSidebar.Location = new Point(1338, 0);
            PanelSidebar.Name = "PanelSidebar";
            PanelSidebar.Size = new Size(60, 729);
            PanelSidebar.TabIndex = 10;
            // 
            // PanelFooter
            // 
            PanelFooter.Controls.Add(BtnBayar);
            PanelFooter.Controls.Add(LblTotal);
            PanelFooter.Dock = DockStyle.Bottom;
            PanelFooter.Location = new Point(0, 612);
            PanelFooter.Name = "PanelFooter";
            PanelFooter.Size = new Size(60, 117);
            PanelFooter.TabIndex = 2;
            // 
            // BtnBayar
            // 
            BtnBayar.BackColor = Color.Lime;
            BtnBayar.FlatStyle = FlatStyle.Flat;
            BtnBayar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBayar.ForeColor = SystemColors.ActiveCaptionText;
            BtnBayar.Location = new Point(76, 52);
            BtnBayar.Name = "BtnBayar";
            BtnBayar.Size = new Size(166, 41);
            BtnBayar.TabIndex = 3;
            BtnBayar.Text = "Bayar";
            BtnBayar.UseVisualStyleBackColor = false;
            BtnBayar.Click += BtnBayar_Click;
            // 
            // LblTotal
            // 
            LblTotal.Dock = DockStyle.Top;
            LblTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTotal.Location = new Point(0, 0);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(60, 28);
            LblTotal.TabIndex = 2;
            LblTotal.Text = "Total";
            LblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FlpKeranjang
            // 
            FlpKeranjang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FlpKeranjang.AutoScroll = true;
            FlpKeranjang.FlowDirection = FlowDirection.TopDown;
            FlpKeranjang.Location = new Point(16, 82);
            FlpKeranjang.Name = "FlpKeranjang";
            FlpKeranjang.Size = new Size(32, 509);
            FlpKeranjang.TabIndex = 1;
            FlpKeranjang.WrapContents = false;
            // 
            // BtnToggleMenu
            // 
            BtnToggleMenu.BackgroundImage = Properties.Resources.btn_titiktiga;
            BtnToggleMenu.BackgroundImageLayout = ImageLayout.Zoom;
            BtnToggleMenu.FlatStyle = FlatStyle.Flat;
            BtnToggleMenu.ForeColor = Color.MidnightBlue;
            BtnToggleMenu.Location = new Point(9, 37);
            BtnToggleMenu.Name = "BtnToggleMenu";
            BtnToggleMenu.Size = new Size(41, 32);
            BtnToggleMenu.TabIndex = 0;
            BtnToggleMenu.UseVisualStyleBackColor = true;
            BtnToggleMenu.Click += BtnToggleMenu_Click;
            // 
            // SidebarTimer
            // 
            SidebarTimer.Tick += SidebarTimer_Tick;
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.ForeColor = Color.Black;
            LblUsername.Location = new Point(137, 99);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 11;
            LblUsername.Text = "Username";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BttnReview, 0, 3);
            tableLayoutPanel1.Controls.Add(BttnRiwayatTransaksi, 0, 2);
            tableLayoutPanel1.Controls.Add(BttnTransaksiPembelian, 0, 1);
            tableLayoutPanel1.Controls.Add(BttnHalUtama, 0, 0);
            tableLayoutPanel1.Location = new Point(40, 214);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.06383F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4042549F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.9787235F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4042549F));
            tableLayoutPanel1.Size = new Size(286, 235);
            tableLayoutPanel1.TabIndex = 43;
            // 
            // V_HalUtamaCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.HalUtama_cust;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1398, 729);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LblUsername);
            Controls.Add(PanelSidebar);
            Controls.Add(BttnRefresh);
            Controls.Add(FlpHalUtama);
            Controls.Add(BtnLogout);
            Controls.Add(LbUsernameDb);
            DoubleBuffered = true;
            ForeColor = Color.Transparent;
            Name = "V_HalUtamaCust";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_HalUtamaCust";
            Load += V_HalUtamaCust_Load;
            PanelSidebar.ResumeLayout(false);
            PanelFooter.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbUsernameDb;
        private Button BttnTransaksiPembelian;
        private Button BttnRiwayatTransaksi;
        private Button BttnReview;
        private Button BttnHalUtama;
        private Button BtnLogout;
        private FlowLayoutPanel FlpHalUtama;
        private Button BttnRefresh;
        private Panel PanelSidebar;
        private Button BtnToggleMenu;
        private Button BtnBayar;
        private Label LblTotal;
        private FlowLayoutPanel FlpKeranjang;
        private System.Windows.Forms.Timer SidebarTimer;
        private Label LblUsername;
        private Panel PanelFooter;
        private TableLayoutPanel tableLayoutPanel1;
    }
}