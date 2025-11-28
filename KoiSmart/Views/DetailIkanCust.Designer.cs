namespace KoiSmart.Views
{
    partial class DetailIkanCust
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
            PbGambar = new PictureBox();
            LblNamaIkan = new Label();
            LblStok = new Label();
            BtnMinus = new Button();
            BtnPlus = new Button();
            LblQty = new Label();
            BtnBeli = new Button();
            LblJenis = new Label();
            LblGender = new Label();
            LblPanjang = new Label();
            LblGrade = new Label();
            LblHarga = new Label();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)PbGambar).BeginInit();
            SuspendLayout();
            // 
            // PbGambar
            // 
            PbGambar.Location = new Point(143, 239);
            PbGambar.Name = "PbGambar";
            PbGambar.Size = new Size(421, 240);
            PbGambar.TabIndex = 21;
            PbGambar.TabStop = false;
            // 
            // LblNamaIkan
            // 
            LblNamaIkan.AutoSize = true;
            LblNamaIkan.BackColor = SystemColors.Window;
            LblNamaIkan.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblNamaIkan.Location = new Point(134, 149);
            LblNamaIkan.Margin = new Padding(2, 0, 2, 0);
            LblNamaIkan.Name = "LblNamaIkan";
            LblNamaIkan.Size = new Size(264, 62);
            LblNamaIkan.TabIndex = 22;
            LblNamaIkan.Text = "Nama Ikan";
            // 
            // LblStok
            // 
            LblStok.AutoSize = true;
            LblStok.BackColor = SystemColors.Window;
            LblStok.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblStok.Location = new Point(282, 501);
            LblStok.Margin = new Padding(2, 0, 2, 0);
            LblStok.Name = "LblStok";
            LblStok.Size = new Size(69, 31);
            LblStok.TabIndex = 23;
            LblStok.Text = "Stok:";
            // 
            // BtnMinus
            // 
            BtnMinus.BackColor = Color.FromArgb(0, 192, 0);
            BtnMinus.BackgroundImage = Properties.Resources.minus;
            BtnMinus.BackgroundImageLayout = ImageLayout.Zoom;
            BtnMinus.FlatStyle = FlatStyle.Flat;
            BtnMinus.ForeColor = SystemColors.ControlLightLight;
            BtnMinus.Location = new Point(233, 591);
            BtnMinus.Name = "BtnMinus";
            BtnMinus.Size = new Size(52, 35);
            BtnMinus.TabIndex = 24;
            BtnMinus.UseVisualStyleBackColor = false;
            BtnMinus.Click += BtnMinus_Click;
            // 
            // BtnPlus
            // 
            BtnPlus.BackColor = Color.FromArgb(0, 192, 0);
            BtnPlus.BackgroundImage = Properties.Resources.plus;
            BtnPlus.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPlus.FlatStyle = FlatStyle.Flat;
            BtnPlus.ForeColor = SystemColors.ControlLightLight;
            BtnPlus.Location = new Point(364, 591);
            BtnPlus.Name = "BtnPlus";
            BtnPlus.Size = new Size(52, 35);
            BtnPlus.TabIndex = 25;
            BtnPlus.UseVisualStyleBackColor = false;
            BtnPlus.Click += BtnPlus_Click;
            // 
            // LblQty
            // 
            LblQty.AutoSize = true;
            LblQty.BackColor = Color.Transparent;
            LblQty.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblQty.Location = new Point(312, 591);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(27, 31);
            LblQty.TabIndex = 26;
            LblQty.Text = "2";
            // 
            // BtnBeli
            // 
            BtnBeli.BackColor = Color.FromArgb(0, 192, 0);
            BtnBeli.FlatStyle = FlatStyle.Flat;
            BtnBeli.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBeli.ForeColor = Color.Transparent;
            BtnBeli.Location = new Point(744, 591);
            BtnBeli.Name = "BtnBeli";
            BtnBeli.Size = new Size(245, 56);
            BtnBeli.TabIndex = 27;
            BtnBeli.Text = "Beli Sekarang";
            BtnBeli.UseVisualStyleBackColor = false;
            BtnBeli.Click += BtnBeli_Click;
            // 
            // LblJenis
            // 
            LblJenis.AutoSize = true;
            LblJenis.BackColor = Color.Transparent;
            LblJenis.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblJenis.Location = new Point(868, 222);
            LblJenis.Name = "LblJenis";
            LblJenis.Size = new Size(55, 23);
            LblJenis.TabIndex = 28;
            LblJenis.Text = "label2";
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.BackColor = Color.Transparent;
            LblGender.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblGender.Location = new Point(868, 276);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(55, 23);
            LblGender.TabIndex = 29;
            LblGender.Text = "label3";
            // 
            // LblPanjang
            // 
            LblPanjang.AutoSize = true;
            LblPanjang.BackColor = Color.Transparent;
            LblPanjang.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPanjang.Location = new Point(868, 331);
            LblPanjang.Name = "LblPanjang";
            LblPanjang.Size = new Size(56, 23);
            LblPanjang.TabIndex = 30;
            LblPanjang.Text = "label4";
            // 
            // LblGrade
            // 
            LblGrade.AutoSize = true;
            LblGrade.BackColor = Color.Transparent;
            LblGrade.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblGrade.Location = new Point(868, 388);
            LblGrade.Name = "LblGrade";
            LblGrade.Size = new Size(55, 23);
            LblGrade.TabIndex = 31;
            LblGrade.Text = "label5";
            // 
            // LblHarga
            // 
            LblHarga.AutoSize = true;
            LblHarga.BackColor = Color.Transparent;
            LblHarga.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblHarga.Location = new Point(868, 438);
            LblHarga.Name = "LblHarga";
            LblHarga.Size = new Size(55, 23);
            LblHarga.TabIndex = 32;
            LblHarga.Text = "label6";
            // 
            // BtnBack
            // 
            BtnBack.BackColor = Color.Transparent;
            BtnBack.BackgroundImage = Properties.Resources.balik;
            BtnBack.BackgroundImageLayout = ImageLayout.Center;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.ForeColor = Color.Transparent;
            BtnBack.Location = new Point(23, 27);
            BtnBack.Margin = new Padding(2);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(90, 38);
            BtnBack.TabIndex = 33;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // DetailIkanCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.detail_ikan1;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1156, 705);
            Controls.Add(BtnBack);
            Controls.Add(LblHarga);
            Controls.Add(LblGrade);
            Controls.Add(LblPanjang);
            Controls.Add(LblGender);
            Controls.Add(LblJenis);
            Controls.Add(BtnBeli);
            Controls.Add(LblQty);
            Controls.Add(BtnPlus);
            Controls.Add(BtnMinus);
            Controls.Add(LblStok);
            Controls.Add(LblNamaIkan);
            Controls.Add(PbGambar);
            DoubleBuffered = true;
            Name = "DetailIkanCust";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetailIkanCust";
            Load += DetailIkanCust_Load;
            ((System.ComponentModel.ISupportInitialize)PbGambar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox PbGambar;
        private Label LblNamaIkan;
        private Label LblStok;
        private Button BtnMinus;
        private Button BtnPlus;
        private Label LblQty;
        private Button BtnBeli;
        private Label LblJenis;
        private Label LblGender;
        private Label LblPanjang;
        private Label LblGrade;
        private Label LblHarga;
        private Button BtnBack;
    }
}