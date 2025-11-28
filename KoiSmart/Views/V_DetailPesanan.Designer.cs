namespace KoiSmart.Views
{
    partial class V_DetailPesanan
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
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            FlpItems = new FlowLayoutPanel();
            BtnBuatPesanan = new Button();
            BtnUpload = new Button();
            PbBuktiBayar = new PictureBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            LblTotalBayar = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbBuktiBayar).BeginInit();
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.BackColor = Color.Transparent;
            BtnBack.BackgroundImage = Properties.Resources.balik;
            BtnBack.BackgroundImageLayout = ImageLayout.Center;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.ForeColor = Color.Transparent;
            BtnBack.Location = new Point(23, 29);
            BtnBack.Margin = new Padding(2);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(90, 38);
            BtnBack.TabIndex = 34;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(145, 26);
            label1.Name = "label1";
            label1.Size = new Size(221, 41);
            label1.TabIndex = 35;
            label1.Text = "Detail Pesanan";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(23, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 45);
            panel1.TabIndex = 36;
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
            // FlpItems
            // 
            FlpItems.AutoScroll = true;
            FlpItems.FlowDirection = FlowDirection.TopDown;
            FlpItems.Location = new Point(23, 137);
            FlpItems.Name = "FlpItems";
            FlpItems.Size = new Size(1350, 388);
            FlpItems.TabIndex = 37;
            FlpItems.WrapContents = false;
            // 
            // BtnBuatPesanan
            // 
            BtnBuatPesanan.BackColor = Color.FromArgb(0, 192, 0);
            BtnBuatPesanan.FlatStyle = FlatStyle.Flat;
            BtnBuatPesanan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBuatPesanan.ForeColor = Color.White;
            BtnBuatPesanan.Location = new Point(1168, 630);
            BtnBuatPesanan.Name = "BtnBuatPesanan";
            BtnBuatPesanan.Size = new Size(187, 40);
            BtnBuatPesanan.TabIndex = 38;
            BtnBuatPesanan.Text = "Buat Pesanan";
            BtnBuatPesanan.UseVisualStyleBackColor = false;
            BtnBuatPesanan.Click += BtnBuatPesanan_Click;
            // 
            // BtnUpload
            // 
            BtnUpload.BackgroundImage = Properties.Resources.sidebar;
            BtnUpload.FlatStyle = FlatStyle.Flat;
            BtnUpload.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnUpload.ForeColor = Color.White;
            BtnUpload.Location = new Point(179, 664);
            BtnUpload.Name = "BtnUpload";
            BtnUpload.Size = new Size(171, 40);
            BtnUpload.TabIndex = 39;
            BtnUpload.Text = "Pilih Gambar";
            BtnUpload.UseVisualStyleBackColor = true;
            BtnUpload.Click += BtnUpload_Click;
            // 
            // PbBuktiBayar
            // 
            PbBuktiBayar.BackgroundImageLayout = ImageLayout.Zoom;
            PbBuktiBayar.BorderStyle = BorderStyle.FixedSingle;
            PbBuktiBayar.Location = new Point(23, 601);
            PbBuktiBayar.Name = "PbBuktiBayar";
            PbBuktiBayar.Size = new Size(129, 103);
            PbBuktiBayar.TabIndex = 40;
            PbBuktiBayar.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 558);
            label6.Name = "label6";
            label6.Size = new Size(247, 28);
            label6.TabIndex = 4;
            label6.Text = "Upload Bukti Pembayaran";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(180, 630);
            label7.Name = "label7";
            label7.Size = new Size(147, 20);
            label7.TabIndex = 41;
            label7.Text = "90198239 (KoiSmart)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(179, 601);
            label8.Name = "label8";
            label8.Size = new Size(134, 20);
            label8.TabIndex = 42;
            label8.Text = "Transfer Bank BCA";
            // 
            // LblTotalBayar
            // 
            LblTotalBayar.AutoSize = true;
            LblTotalBayar.BackColor = Color.Transparent;
            LblTotalBayar.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            LblTotalBayar.Location = new Point(1168, 548);
            LblTotalBayar.Name = "LblTotalBayar";
            LblTotalBayar.Size = new Size(75, 38);
            LblTotalBayar.TabIndex = 4;
            LblTotalBayar.Text = "Rp 0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            label9.Location = new Point(899, 548);
            label9.Name = "label9";
            label9.Size = new Size(243, 38);
            label9.TabIndex = 43;
            label9.Text = "Total Pembayaran";
            // 
            // V_DetailPesanan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.background1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1399, 731);
            Controls.Add(label9);
            Controls.Add(LblTotalBayar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(PbBuktiBayar);
            Controls.Add(BtnUpload);
            Controls.Add(BtnBuatPesanan);
            Controls.Add(FlpItems);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(BtnBack);
            DoubleBuffered = true;
            Name = "V_DetailPesanan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_DetailPesanan";
            Click += V_DetailPesanan_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbBuktiBayar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnBack;
        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private FlowLayoutPanel FlpItems;
        private Button BtnBuatPesanan;
        private Button BtnUpload;
        private PictureBox PbBuktiBayar;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label LblTotalBayar;
        private Label label9;
    }
}