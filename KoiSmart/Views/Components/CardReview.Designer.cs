namespace KoiSmart.Views.Components
{
    partial class CardReview
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
            LblUsername = new Label();
            panel1 = new Panel();
            LblIsiReview = new Label();
            PbFotoReview = new PictureBox();
            LblIdTransaksi = new Label();
            LblTanggalReview = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbFotoReview).BeginInit();
            SuspendLayout();
            // 
            // LblUsername
            // 
            LblUsername.AutoSize = true;
            LblUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsername.Location = new Point(16, 10);
            LblUsername.Name = "LblUsername";
            LblUsername.Size = new Size(104, 28);
            LblUsername.TabIndex = 0;
            LblUsername.Text = "Username";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(LblIsiReview);
            panel1.Location = new Point(16, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(859, 87);
            panel1.TabIndex = 1;
            // 
            // LblIsiReview
            // 
            LblIsiReview.AutoSize = true;
            LblIsiReview.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblIsiReview.Location = new Point(14, 12);
            LblIsiReview.Name = "LblIsiReview";
            LblIsiReview.Size = new Size(83, 23);
            LblIsiReview.TabIndex = 0;
            LblIsiReview.Text = "Isi Review";
            // 
            // PbFotoReview
            // 
            PbFotoReview.Location = new Point(16, 139);
            PbFotoReview.Name = "PbFotoReview";
            PbFotoReview.Size = new Size(145, 77);
            PbFotoReview.TabIndex = 2;
            PbFotoReview.TabStop = false;
            // 
            // LblIdTransaksi
            // 
            LblIdTransaksi.AutoSize = true;
            LblIdTransaksi.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblIdTransaksi.Location = new Point(777, 10);
            LblIdTransaksi.Name = "LblIdTransaksi";
            LblIdTransaksi.Size = new Size(98, 23);
            LblIdTransaksi.TabIndex = 1;
            LblIdTransaksi.Text = "Id Transaksi";
            // 
            // LblTanggalReview
            // 
            LblTanggalReview.AutoSize = true;
            LblTanggalReview.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTanggalReview.Location = new Point(16, 229);
            LblTanggalReview.Name = "LblTanggalReview";
            LblTanggalReview.Size = new Size(142, 23);
            LblTanggalReview.TabIndex = 3;
            LblTanggalReview.Text = "Tanggal Transaksi";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGray;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 268);
            panel2.Name = "panel2";
            panel2.Size = new Size(900, 1);
            panel2.TabIndex = 4;
            // 
            // CardReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(LblTanggalReview);
            Controls.Add(LblIdTransaksi);
            Controls.Add(PbFotoReview);
            Controls.Add(panel1);
            Controls.Add(LblUsername);
            Name = "CardReview";
            Size = new Size(900, 269);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbFotoReview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblUsername;
        private Panel panel1;
        private Label LblIsiReview;
        private PictureBox PbFotoReview;
        private Label LblIdTransaksi;
        private Label LblTanggalReview;
        private Panel panel2;
    }
}
