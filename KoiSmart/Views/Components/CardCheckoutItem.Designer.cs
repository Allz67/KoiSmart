namespace KoiSmart.Views.Components
{
    partial class CardCheckoutItem
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
            LblDetail = new Label();
            LblHargaSatuan = new Label();
            LblQty = new Label();
            LblSubtotal = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)PbGambar).BeginInit();
            SuspendLayout();
            // 
            // PbGambar
            // 
            PbGambar.Location = new Point(32, 31);
            PbGambar.Name = "PbGambar";
            PbGambar.Size = new Size(234, 141);
            PbGambar.TabIndex = 0;
            PbGambar.TabStop = false;
            // 
            // LblNama
            // 
            LblNama.AutoSize = true;
            LblNama.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblNama.ForeColor = Color.FromArgb(64, 64, 64);
            LblNama.Location = new Point(289, 62);
            LblNama.Name = "LblNama";
            LblNama.Size = new Size(234, 31);
            LblNama.TabIndex = 1;
            LblNama.Text = "Koi Tancho (Grade A)";
            // 
            // LblDetail
            // 
            LblDetail.AutoSize = true;
            LblDetail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDetail.ForeColor = Color.Gray;
            LblDetail.Location = new Point(289, 109);
            LblDetail.Name = "LblDetail";
            LblDetail.Size = new Size(146, 31);
            LblDetail.TabIndex = 2;
            LblDetail.Text = "Jantan, 50cm";
            // 
            // LblHargaSatuan
            // 
            LblHargaSatuan.AutoSize = true;
            LblHargaSatuan.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblHargaSatuan.ForeColor = Color.FromArgb(64, 64, 64);
            LblHargaSatuan.Location = new Point(636, 83);
            LblHargaSatuan.Name = "LblHargaSatuan";
            LblHargaSatuan.Size = new Size(131, 31);
            LblHargaSatuan.TabIndex = 3;
            LblHargaSatuan.Text = "Rp 700.000";
            // 
            // LblQty
            // 
            LblQty.AutoSize = true;
            LblQty.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblQty.ForeColor = Color.FromArgb(64, 64, 64);
            LblQty.Location = new Point(937, 83);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(27, 31);
            LblQty.TabIndex = 4;
            LblQty.Text = "2";
            // 
            // LblSubtotal
            // 
            LblSubtotal.AutoSize = true;
            LblSubtotal.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblSubtotal.ForeColor = Color.FromArgb(64, 64, 64);
            LblSubtotal.Location = new Point(1151, 83);
            LblSubtotal.Name = "LblSubtotal";
            LblSubtotal.Size = new Size(147, 31);
            LblSubtotal.TabIndex = 5;
            LblSubtotal.Text = "Rp 1.400.000";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 1);
            panel1.TabIndex = 6;
            // 
            // CardCheckoutItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(LblSubtotal);
            Controls.Add(LblQty);
            Controls.Add(LblHargaSatuan);
            Controls.Add(LblDetail);
            Controls.Add(LblNama);
            Controls.Add(PbGambar);
            Margin = new Padding(0);
            Name = "CardCheckoutItem";
            Size = new Size(1350, 200);
            ((System.ComponentModel.ISupportInitialize)PbGambar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PbGambar;
        private Label LblNama;
        private Label LblDetail;
        private Label LblHargaSatuan;
        private Label LblQty;
        private Label LblSubtotal;
        private Panel panel1;
    }
}
