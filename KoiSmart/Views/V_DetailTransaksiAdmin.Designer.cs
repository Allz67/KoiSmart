namespace KoiSmart.Views
{
    partial class V_DetailTransaksiAdmin
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
            BtnBack = new Button();
            label1 = new Label();
            LblUsername = new Label();
            LblStatus = new Label();
            BtnBukti = new Button();
            CmbStatus = new ComboBox();
            BttnRefresh = new Button();
            LblTotalHarga = new Label();
            LblTanggalTransaksi = new Label();
            FlpDetailTransaksi = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.BackColor = Color.Transparent;
            BtnBack.BackgroundImage = Properties.Resources.balik;
            BtnBack.BackgroundImageLayout = ImageLayout.Center;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.ForeColor = Color.Transparent;
            BtnBack.Location = new Point(21, 22);
            BtnBack.Margin = new Padding(2);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(90, 38);
            BtnBack.TabIndex = 35;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(116, 22);
            label1.Name = "label1";
            label1.Size = new Size(233, 41);
            label1.TabIndex = 36;
            label1.Text = "Detail Transaksi";
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.BackColor = Color.Transparent;
            LblUsername.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.Location = new Point(30, 84);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(118, 31);
            LblUsername.TabIndex = 4;
            LblUsername.Text = "Username";
            // 
            // LblStatus
            // 
            LblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LblStatus.AutoSize = true;
            LblStatus.BackColor = Color.Transparent;
            LblStatus.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblStatus.Location = new Point(1294, 84);
            LblStatus.Name = "LblStatus";
            LblStatus.Size = new Size(77, 31);
            LblStatus.TabIndex = 39;
            LblStatus.Text = "Status";
            // 
            // BtnBukti
            // 
            BtnBukti.BackColor = Color.Transparent;
            BtnBukti.BackgroundImage = Properties.Resources.button_pembayaran;
            BtnBukti.BackgroundImageLayout = ImageLayout.Center;
            BtnBukti.FlatStyle = FlatStyle.Flat;
            BtnBukti.ForeColor = Color.Transparent;
            BtnBukti.Location = new Point(24, 650);
            BtnBukti.Margin = new Padding(2);
            BtnBukti.Name = "BtnBukti";
            BtnBukti.Size = new Size(236, 58);
            BtnBukti.TabIndex = 42;
            BtnBukti.UseVisualStyleBackColor = false;
            BtnBukti.Click += BtnBukti_Click;
            // 
            // CmbStatus
            // 
            CmbStatus.BackColor = Color.MidnightBlue;
            CmbStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbStatus.ForeColor = SystemColors.Window;
            CmbStatus.FormattingEnabled = true;
            CmbStatus.Items.AddRange(new object[] { "Konfirmasi", "Tolak" });
            CmbStatus.Location = new Point(1144, 659);
            CmbStatus.Name = "CmbStatus";
            CmbStatus.Size = new Size(227, 36);
            CmbStatus.TabIndex = 43;
            CmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            // 
            // BttnRefresh
            // 
            BttnRefresh.BackColor = Color.MidnightBlue;
            BttnRefresh.BackgroundImage = Properties.Resources.refresh1;
            BttnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            BttnRefresh.Location = new Point(1321, 29);
            BttnRefresh.Margin = new Padding(2);
            BttnRefresh.Name = "BttnRefresh";
            BttnRefresh.Size = new Size(50, 40);
            BttnRefresh.TabIndex = 44;
            BttnRefresh.UseVisualStyleBackColor = false;
            BttnRefresh.Click += BttnRefresh_Click;
            // 
            // LblTotalHarga
            // 
            LblTotalHarga.AutoSize = true;
            LblTotalHarga.BackColor = Color.Transparent;
            LblTotalHarga.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            LblTotalHarga.Location = new Point(1112, 609);
            LblTotalHarga.Name = "LblTotalHarga";
            LblTotalHarga.Size = new Size(75, 38);
            LblTotalHarga.TabIndex = 40;
            LblTotalHarga.Text = "Rp 0";
            // 
            // LblTanggalTransaksi
            // 
            LblTanggalTransaksi.AutoSize = true;
            LblTanggalTransaksi.BackColor = Color.Transparent;
            LblTanggalTransaksi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTanggalTransaksi.Location = new Point(21, 609);
            LblTanggalTransaksi.Name = "LblTanggalTransaksi";
            LblTanggalTransaksi.Size = new Size(162, 28);
            LblTanggalTransaksi.TabIndex = 4;
            LblTanggalTransaksi.Text = "Tanggal Transaksi";
            // 
            // FlpDetailTransaksi
            // 
            FlpDetailTransaksi.AutoScroll = true;
            FlpDetailTransaksi.FlowDirection = FlowDirection.TopDown;
            FlpDetailTransaksi.Location = new Point(21, 178);
            FlpDetailTransaksi.Name = "FlpDetailTransaksi";
            FlpDetailTransaksi.Size = new Size(1350, 418);
            FlpDetailTransaksi.TabIndex = 38;
            FlpDetailTransaksi.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(68, 10);
            label2.Name = "label2";
            label2.Size = new Size(130, 28);
            label2.TabIndex = 0;
            label2.Text = "Ikan Dipesan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(611, 10);
            label3.Name = "label3";
            label3.Size = new Size(134, 28);
            label3.TabIndex = 1;
            label3.Text = "Harga Satuan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(889, 10);
            label4.Name = "label4";
            label4.Size = new Size(77, 28);
            label4.TabIndex = 2;
            label4.Text = "Jumlah";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(1196, 10);
            label5.Name = "label5";
            label5.Size = new Size(88, 28);
            label5.TabIndex = 3;
            label5.Text = "Subtotal";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(21, 127);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 45);
            panel1.TabIndex = 37;
            // 
            // V_DetailTransaksiAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1399, 731);
            Controls.Add(BttnRefresh);
            Controls.Add(CmbStatus);
            Controls.Add(BtnBukti);
            Controls.Add(LblTotalHarga);
            Controls.Add(LblTanggalTransaksi);
            Controls.Add(LblStatus);
            Controls.Add(FlpDetailTransaksi);
            Controls.Add(LblUsername);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(BtnBack);
            DoubleBuffered = true;
            Name = "V_DetailTransaksiAdmin";
            Text = "V_DetailTransaksiAdmin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnBack;
        private Label label1;
        private Label LblUsername;
        private Label LblStatus;
        private Button BtnBukti;
        private ComboBox CmbStatus;
        private Button BttnRefresh;
        private Label LblTotalHarga;
        private Label LblTanggalTransaksi;
        private FlowLayoutPanel FlpDetailTransaksi;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
    }
}