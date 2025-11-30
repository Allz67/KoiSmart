namespace KoiSmart.Views
{
    partial class V_LihatReview
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
            BtnHapusReview = new Button();
            label3 = new Label();
            PbGambarReview = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            LblIsiReview = new Label();
            ((System.ComponentModel.ISupportInitialize)PbGambarReview).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnHapusReview
            // 
            BtnHapusReview.BackColor = Color.Red;
            BtnHapusReview.FlatStyle = FlatStyle.Flat;
            BtnHapusReview.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnHapusReview.ForeColor = SystemColors.Window;
            BtnHapusReview.Location = new Point(760, 419);
            BtnHapusReview.Name = "BtnHapusReview";
            BtnHapusReview.Size = new Size(151, 40);
            BtnHapusReview.TabIndex = 12;
            BtnHapusReview.Text = "Hapus Review";
            BtnHapusReview.UseVisualStyleBackColor = false;
            BtnHapusReview.Click += BtnHapusReview_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 324);
            label3.Name = "label3";
            label3.Size = new Size(138, 25);
            label3.TabIndex = 11;
            label3.Text = "Gambar Review:";
            // 
            // PbGambarReview
            // 
            PbGambarReview.BackColor = Color.White;
            PbGambarReview.Location = new Point(37, 361);
            PbGambarReview.Name = "PbGambarReview";
            PbGambarReview.Size = new Size(157, 98);
            PbGambarReview.TabIndex = 10;
            PbGambarReview.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 88);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 9;
            label2.Text = "Ulasan Anda:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 27);
            label1.Name = "label1";
            label1.Size = new Size(202, 31);
            label1.TabIndex = 8;
            label1.Text = "Lihat Review Anda";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(LblIsiReview);
            panel1.Location = new Point(42, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(839, 156);
            panel1.TabIndex = 13;
            // 
            // LblIsiReview
            // 
            LblIsiReview.AutoSize = true;
            LblIsiReview.BackColor = Color.Transparent;
            LblIsiReview.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblIsiReview.Location = new Point(18, 15);
            LblIsiReview.Name = "LblIsiReview";
            LblIsiReview.Size = new Size(124, 25);
            LblIsiReview.TabIndex = 14;
            LblIsiReview.Text = "Isi Teks Ulasan";
            // 
            // V_LihatReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(936, 487);
            Controls.Add(panel1);
            Controls.Add(BtnHapusReview);
            Controls.Add(label3);
            Controls.Add(PbGambarReview);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "V_LihatReview";
            Text = "V_LihatReview";
            ((System.ComponentModel.ISupportInitialize)PbGambarReview).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnHapusReview;
        private Label label3;
        private PictureBox PbGambarReview;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Label LblIsiReview;
    }
}