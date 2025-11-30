namespace KoiSmart.Views
{
    partial class V_BuatReview
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
            label1 = new Label();
            label2 = new Label();
            TxtIsiReview = new TextBox();
            PbGambarReview = new PictureBox();
            label3 = new Label();
            BtnUploadGambar = new Button();
            BtnUploadReview = new Button();
            ((System.ComponentModel.ISupportInitialize)PbGambarReview).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(200, 31);
            label1.TabIndex = 0;
            label1.Text = "Form Buat Review";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 80);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 2;
            label2.Text = "Ulasan Anda:";
            // 
            // TxtIsiReview
            // 
            TxtIsiReview.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtIsiReview.Location = new Point(24, 120);
            TxtIsiReview.Multiline = true;
            TxtIsiReview.Name = "TxtIsiReview";
            TxtIsiReview.ScrollBars = ScrollBars.Both;
            TxtIsiReview.Size = new Size(874, 154);
            TxtIsiReview.TabIndex = 3;
            // 
            // PbGambarReview
            // 
            PbGambarReview.BackColor = Color.White;
            PbGambarReview.Location = new Point(24, 353);
            PbGambarReview.Name = "PbGambarReview";
            PbGambarReview.Size = new Size(157, 98);
            PbGambarReview.TabIndex = 4;
            PbGambarReview.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 316);
            label3.Name = "label3";
            label3.Size = new Size(142, 25);
            label3.TabIndex = 5;
            label3.Text = "Upload Gambar:";
            // 
            // BtnUploadGambar
            // 
            BtnUploadGambar.BackColor = Color.Transparent;
            BtnUploadGambar.BackgroundImage = Properties.Resources.sidebar;
            BtnUploadGambar.FlatStyle = FlatStyle.Flat;
            BtnUploadGambar.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnUploadGambar.ForeColor = Color.White;
            BtnUploadGambar.Location = new Point(208, 411);
            BtnUploadGambar.Name = "BtnUploadGambar";
            BtnUploadGambar.Size = new Size(136, 40);
            BtnUploadGambar.TabIndex = 6;
            BtnUploadGambar.Text = "Upload Gambar";
            BtnUploadGambar.UseVisualStyleBackColor = false;
            BtnUploadGambar.Click += BtnUploadGambar_Click;
            // 
            // BtnUploadReview
            // 
            BtnUploadReview.BackColor = Color.Transparent;
            BtnUploadReview.BackgroundImage = Properties.Resources.sidebar;
            BtnUploadReview.FlatStyle = FlatStyle.Flat;
            BtnUploadReview.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnUploadReview.ForeColor = Color.White;
            BtnUploadReview.Location = new Point(747, 411);
            BtnUploadReview.Name = "BtnUploadReview";
            BtnUploadReview.Size = new Size(151, 40);
            BtnUploadReview.TabIndex = 7;
            BtnUploadReview.Text = "Upload Review";
            BtnUploadReview.UseVisualStyleBackColor = false;
            BtnUploadReview.Click += BtnUploadReview_Click;
            // 
            // V_BuatReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(936, 487);
            Controls.Add(BtnUploadReview);
            Controls.Add(BtnUploadGambar);
            Controls.Add(label3);
            Controls.Add(PbGambarReview);
            Controls.Add(TxtIsiReview);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "V_BuatReview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_BuatReview";
            ((System.ComponentModel.ISupportInitialize)PbGambarReview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxtIsiReview;
        private PictureBox PbGambarReview;
        private Label label3;
        private Button BtnUploadGambar;
        private Button BtnUploadReview;
    }
}