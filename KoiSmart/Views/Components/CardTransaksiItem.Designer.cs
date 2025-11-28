namespace KoiSmart.Views.Components
{
    partial class CardTransaksiItem
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
            PbGambar = new PictureBox();
            LblNama = new Label();
            LblQty = new Label();
            LblHargaSatuan = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)PbGambar).BeginInit();
            SuspendLayout();
            // 
            // PbGambar
            // 
            PbGambar.Location = new Point(12, 12);
            PbGambar.Name = "PbGambar";
            PbGambar.Size = new Size(157, 74);
            PbGambar.TabIndex = 0;
            PbGambar.TabStop = false;
            // 
            // LblNama
            // 
            LblNama.AutoSize = true;
            LblNama.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblNama.ForeColor = Color.Black;
            LblNama.Location = new Point(183, 20);
            LblNama.Name = "LblNama";
            LblNama.Size = new Size(99, 25);
            LblNama.TabIndex = 1;
            LblNama.Text = "Nama Ikan";
            // 
            // LblQty
            // 
            LblQty.AutoSize = true;
            LblQty.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblQty.ForeColor = Color.Black;
            LblQty.Location = new Point(187, 52);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(58, 20);
            LblQty.TabIndex = 2;
            LblQty.Text = "Jumlah";
            // 
            // LblHargaSatuan
            // 
            LblHargaSatuan.AutoSize = true;
            LblHargaSatuan.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblHargaSatuan.ForeColor = Color.Black;
            LblHargaSatuan.Location = new Point(790, 36);
            LblHargaSatuan.Name = "LblHargaSatuan";
            LblHargaSatuan.Size = new Size(100, 25);
            LblHargaSatuan.TabIndex = 3;
            LblHargaSatuan.Text = "Harga Ikan";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 1);
            panel1.TabIndex = 4;
            // 
            // CardTransaksiItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(LblHargaSatuan);
            Controls.Add(LblQty);
            Controls.Add(LblNama);
            Controls.Add(PbGambar);
            Name = "CardTransaksiItem";
            Size = new Size(920, 100);
            ((System.ComponentModel.ISupportInitialize)PbGambar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PbGambar;
        private Label LblNama;
        private Label LblQty;
        private Label LblHargaSatuan;
        private Panel panel1;
    }
}
