namespace KoiSmart.Views.Components
{
    partial class CardKeranjang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            LblQty = new Label();
            LblHarga = new Label();
            LblNama = new Label();
            PbGambar = new PictureBox();
            BtnMinus = new Button();
            BtnPlus = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbGambar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(LblQty);
            panel1.Controls.Add(LblHarga);
            panel1.Controls.Add(LblNama);
            panel1.Controls.Add(PbGambar);
            panel1.Location = new Point(45, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(179, 142);
            panel1.TabIndex = 0;
            // 
            // LblQty
            // 
            LblQty.AutoSize = true;
            LblQty.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblQty.Location = new Point(146, 111);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(23, 20);
            LblQty.TabIndex = 6;
            LblQty.Text = "1x";
            // 
            // LblHarga
            // 
            LblHarga.AutoSize = true;
            LblHarga.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblHarga.Location = new Point(19, 110);
            LblHarga.Name = "LblHarga";
            LblHarga.Size = new Size(45, 17);
            LblHarga.TabIndex = 5;
            LblHarga.Text = "Harga";
            // 
            // LblNama
            // 
            LblNama.AutoSize = true;
            LblNama.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblNama.Location = new Point(12, 88);
            LblNama.Name = "LblNama";
            LblNama.Size = new Size(83, 20);
            LblNama.TabIndex = 4;
            LblNama.Text = "Nama ikan";
            // 
            // PbGambar
            // 
            PbGambar.BackgroundImageLayout = ImageLayout.Zoom;
            PbGambar.Location = new Point(12, 9);
            PbGambar.Name = "PbGambar";
            PbGambar.Size = new Size(157, 76);
            PbGambar.TabIndex = 0;
            PbGambar.TabStop = false;
            // 
            // BtnMinus
            // 
            BtnMinus.BackColor = Color.MidnightBlue;
            BtnMinus.BackgroundImage = Properties.Resources.minus;
            BtnMinus.BackgroundImageLayout = ImageLayout.Zoom;
            BtnMinus.FlatStyle = FlatStyle.Flat;
            BtnMinus.Location = new Point(2, 63);
            BtnMinus.Name = "BtnMinus";
            BtnMinus.Size = new Size(25, 25);
            BtnMinus.TabIndex = 1;
            BtnMinus.UseVisualStyleBackColor = false;
            BtnMinus.Click += BtnMinus_Click;
            // 
            // BtnPlus
            // 
            BtnPlus.BackColor = Color.MidnightBlue;
            BtnPlus.BackgroundImage = Properties.Resources.plus;
            BtnPlus.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPlus.FlatStyle = FlatStyle.Flat;
            BtnPlus.Location = new Point(242, 63);
            BtnPlus.Name = "BtnPlus";
            BtnPlus.Size = new Size(25, 25);
            BtnPlus.TabIndex = 2;
            BtnPlus.UseVisualStyleBackColor = false;
            BtnPlus.Click += BtnPlus_Click;
            // 
            // CardKeranjang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(BtnPlus);
            Controls.Add(BtnMinus);
            Controls.Add(panel1);
            Name = "CardKeranjang";
            Size = new Size(270, 167);
            Load += CardKeranjang_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbGambar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnMinus;
        private Button BtnPlus;
        private PictureBox PbGambar;
        private Label LblHarga;
        private Label LblNama;
        private Label LblQty;
    }
}
