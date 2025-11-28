namespace KoiSmart.Views.Components
{
    partial class DetailDataIkan
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
            tableLayoutPanel1 = new TableLayoutPanel();
            LblGender = new Label();
            LblPanjang = new Label();
            LblGrade = new Label();
            LblHarga = new Label();
            LblJenis = new Label();
            BtnBalik = new Button();
            LblNama = new Label();
            LblStok = new Label();
            BtnHapus = new Button();
            BtnEdit = new Button();
            PbxInputIkan = new PictureBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbxInputIkan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.show_hal_detail_ikan2;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(BtnBalik);
            panel1.Controls.Add(LblNama);
            panel1.Controls.Add(LblStok);
            panel1.Controls.Add(BtnHapus);
            panel1.Controls.Add(BtnEdit);
            panel1.Controls.Add(PbxInputIkan);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1260, 772);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(LblGender, 0, 1);
            tableLayoutPanel1.Controls.Add(LblPanjang, 0, 2);
            tableLayoutPanel1.Controls.Add(LblGrade, 0, 3);
            tableLayoutPanel1.Controls.Add(LblHarga, 0, 4);
            tableLayoutPanel1.Controls.Add(LblJenis, 0, 0);
            tableLayoutPanel1.Location = new Point(943, 245);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(169, 265);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.BackColor = Color.FromArgb(233, 245, 254);
            LblGender.Location = new Point(2, 60);
            LblGender.Margin = new Padding(2, 0, 2, 0);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(88, 20);
            LblGender.TabIndex = 12;
            LblGender.Text = "Gender Ikan";
            // 
            // LblPanjang
            // 
            LblPanjang.AutoSize = true;
            LblPanjang.BackColor = Color.FromArgb(233, 245, 254);
            LblPanjang.Location = new Point(2, 120);
            LblPanjang.Margin = new Padding(2, 0, 2, 0);
            LblPanjang.Name = "LblPanjang";
            LblPanjang.Size = new Size(92, 20);
            LblPanjang.TabIndex = 13;
            LblPanjang.Text = "Panjang Ikan";
            // 
            // LblGrade
            // 
            LblGrade.AutoSize = true;
            LblGrade.BackColor = Color.FromArgb(233, 245, 254);
            LblGrade.Location = new Point(2, 180);
            LblGrade.Margin = new Padding(2, 0, 2, 0);
            LblGrade.Name = "LblGrade";
            LblGrade.Size = new Size(80, 20);
            LblGrade.TabIndex = 14;
            LblGrade.Text = "Grade Ikan";
            // 
            // LblHarga
            // 
            LblHarga.AutoSize = true;
            LblHarga.BackColor = Color.FromArgb(233, 245, 254);
            LblHarga.Location = new Point(2, 240);
            LblHarga.Margin = new Padding(2, 0, 2, 0);
            LblHarga.Name = "LblHarga";
            LblHarga.Size = new Size(81, 20);
            LblHarga.TabIndex = 15;
            LblHarga.Text = "Harga Ikan";
            // 
            // LblJenis
            // 
            LblJenis.AutoSize = true;
            LblJenis.BackColor = Color.FromArgb(233, 245, 254);
            LblJenis.Location = new Point(2, 0);
            LblJenis.Margin = new Padding(2, 0, 2, 0);
            LblJenis.Name = "LblJenis";
            LblJenis.Size = new Size(71, 20);
            LblJenis.TabIndex = 11;
            LblJenis.Text = "Jenis Ikan";
            // 
            // BtnBalik
            // 
            BtnBalik.BackColor = Color.Transparent;
            BtnBalik.BackgroundImage = Properties.Resources.balik;
            BtnBalik.BackgroundImageLayout = ImageLayout.Center;
            BtnBalik.FlatStyle = FlatStyle.Flat;
            BtnBalik.ForeColor = Color.Transparent;
            BtnBalik.Location = new Point(54, 34);
            BtnBalik.Margin = new Padding(2);
            BtnBalik.Name = "BtnBalik";
            BtnBalik.Size = new Size(90, 38);
            BtnBalik.TabIndex = 18;
            BtnBalik.UseVisualStyleBackColor = false;
            // 
            // LblNama
            // 
            LblNama.AutoSize = true;
            LblNama.BackColor = SystemColors.Window;
            LblNama.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblNama.Location = new Point(225, 172);
            LblNama.Margin = new Padding(2, 0, 2, 0);
            LblNama.Name = "LblNama";
            LblNama.Size = new Size(264, 62);
            LblNama.TabIndex = 17;
            LblNama.Text = "Nama Ikan";
            // 
            // LblStok
            // 
            LblStok.AutoSize = true;
            LblStok.BackColor = SystemColors.Window;
            LblStok.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblStok.Location = new Point(401, 485);
            LblStok.Margin = new Padding(2, 0, 2, 0);
            LblStok.Name = "LblStok";
            LblStok.Size = new Size(69, 31);
            LblStok.TabIndex = 16;
            LblStok.Text = "Stok:";
            // 
            // BtnHapus
            // 
            BtnHapus.BackColor = Color.Transparent;
            BtnHapus.BackgroundImage = Properties.Resources.Btn_Hapus_Adm_Hal_Utama_3;
            BtnHapus.BackgroundImageLayout = ImageLayout.Center;
            BtnHapus.ForeColor = Color.Transparent;
            BtnHapus.Location = new Point(788, 612);
            BtnHapus.Margin = new Padding(2);
            BtnHapus.Name = "BtnHapus";
            BtnHapus.Size = new Size(151, 58);
            BtnHapus.TabIndex = 10;
            BtnHapus.UseVisualStyleBackColor = false;
            // 
            // BtnEdit
            // 
            BtnEdit.BackColor = Color.Transparent;
            BtnEdit.BackgroundImage = Properties.Resources.Btn_Edit_Adm_Hal_Utama_3;
            BtnEdit.BackgroundImageLayout = ImageLayout.Center;
            BtnEdit.ForeColor = Color.Transparent;
            BtnEdit.Location = new Point(943, 612);
            BtnEdit.Margin = new Padding(2);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(154, 58);
            BtnEdit.TabIndex = 9;
            BtnEdit.UseVisualStyleBackColor = false;
            // 
            // PbxInputIkan
            // 
            PbxInputIkan.BackColor = Color.Transparent;
            PbxInputIkan.Location = new Point(225, 236);
            PbxInputIkan.Margin = new Padding(2);
            PbxInputIkan.Name = "PbxInputIkan";
            PbxInputIkan.Size = new Size(421, 240);
            PbxInputIkan.TabIndex = 0;
            PbxInputIkan.TabStop = false;
            // 
            // DetailDataIkan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "DetailDataIkan";
            Size = new Size(1260, 772);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbxInputIkan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox PbxInputIkan;
        private Button BtnEdit;
        private Button BtnHapus;
        private Label LblGender;
        private Label LblJenis;
        private Label LblPanjang;
        private Label LblNama;
        private Label LblStok;
        private Label LblHarga;
        private Label LblGrade;
        private Button BtnBalik;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
