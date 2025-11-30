namespace KoiSmart.Views.Components
{
    partial class KonfirmPartIkan
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
            PbxIkanKonfirm = new PictureBox();
            LblIkan = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblSubTot = new Label();
            LblJumlah = new Label();
            LblHarga = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)PbxIkanKonfirm).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // PbxIkanKonfirm
            // 
            PbxIkanKonfirm.Location = new Point(42, 24);
            PbxIkanKonfirm.Name = "PbxIkanKonfirm";
            PbxIkanKonfirm.Size = new Size(185, 105);
            PbxIkanKonfirm.TabIndex = 0;
            PbxIkanKonfirm.TabStop = false;
            // 
            // LblIkan
            // 
            LblIkan.AutoSize = true;
            LblIkan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblIkan.Location = new Point(254, 67);
            LblIkan.Name = "LblIkan";
            LblIkan.Size = new Size(85, 20);
            LblIkan.TabIndex = 1;
            LblIkan.Text = "Nama Ikan";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.905983F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(LblSubTot, 2, 1);
            tableLayoutPanel1.Controls.Add(LblJumlah, 1, 1);
            tableLayoutPanel1.Controls.Add(LblHarga, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Location = new Point(441, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.4F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 61.6F));
            tableLayoutPanel1.Size = new Size(468, 125);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // LblSubTot
            // 
            LblSubTot.AutoSize = true;
            LblSubTot.Location = new Point(313, 48);
            LblSubTot.Name = "LblSubTot";
            LblSubTot.Size = new Size(75, 20);
            LblSubTot.TabIndex = 8;
            LblSubTot.Text = "Rp300000";
            // 
            // LblJumlah
            // 
            LblJumlah.AutoSize = true;
            LblJumlah.Location = new Point(157, 48);
            LblJumlah.Name = "LblJumlah";
            LblJumlah.Size = new Size(17, 20);
            LblJumlah.TabIndex = 7;
            LblJumlah.Text = "3";
            // 
            // LblHarga
            // 
            LblHarga.AutoSize = true;
            LblHarga.Location = new Point(3, 48);
            LblHarga.Name = "LblHarga";
            LblHarga.Size = new Size(75, 20);
            LblHarga.TabIndex = 6;
            LblHarga.Text = "Rp100000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(313, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 5;
            label4.Text = "Subtotal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(157, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 4;
            label3.Text = "Jumlah Ikan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 3;
            label2.Text = "Harga Satuan";
            // 
            // KonfirmPartIkan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LblIkan);
            Controls.Add(PbxIkanKonfirm);
            Name = "KonfirmPartIkan";
            Size = new Size(940, 164);
            ((System.ComponentModel.ISupportInitialize)PbxIkanKonfirm).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PbxIkanKonfirm;
        private Label LblIkan;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label2;
        private Label LblSubTot;
        private Label LblJumlah;
        private Label LblHarga;
        private Label label4;
    }
}
