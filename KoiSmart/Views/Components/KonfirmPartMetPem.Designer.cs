namespace KoiSmart.Views.Components
{
    partial class KonfirmPartMetPem
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
            LblWaktu = new Label();
            LblBank = new Label();
            FooterKonfirm = new TableLayoutPanel();
            LblMetpem = new Label();
            LblTotHar = new Label();
            HeaderKonfirm = new TableLayoutPanel();
            LblPending = new Label();
            LblDetailTrans = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            CbxKonfTolak = new ComboBox();
            BtnBukti = new Button();
            FooterKonfirm.SuspendLayout();
            HeaderKonfirm.SuspendLayout();
            SuspendLayout();
            // 
            // LblWaktu
            // 
            LblWaktu.AutoSize = true;
            LblWaktu.ForeColor = SystemColors.ControlDarkDark;
            LblWaktu.Location = new Point(3, 37);
            LblWaktu.Name = "LblWaktu";
            LblWaktu.Size = new Size(50, 20);
            LblWaktu.TabIndex = 0;
            LblWaktu.Text = "Waktu";
            // 
            // LblBank
            // 
            LblBank.AutoSize = true;
            LblBank.Location = new Point(719, 0);
            LblBank.Name = "LblBank";
            LblBank.Size = new Size(41, 20);
            LblBank.TabIndex = 1;
            LblBank.Text = "BCA ";
            // 
            // FooterKonfirm
            // 
            FooterKonfirm.ColumnCount = 3;
            FooterKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 199F));
            FooterKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 517F));
            FooterKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            FooterKonfirm.Controls.Add(LblBank, 2, 0);
            FooterKonfirm.Controls.Add(LblMetpem, 0, 0);
            FooterKonfirm.Controls.Add(LblWaktu, 0, 1);
            FooterKonfirm.Controls.Add(LblTotHar, 2, 1);
            FooterKonfirm.Location = new Point(14, 243);
            FooterKonfirm.Name = "FooterKonfirm";
            FooterKonfirm.RowCount = 2;
            FooterKonfirm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FooterKonfirm.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            FooterKonfirm.Size = new Size(891, 70);
            FooterKonfirm.TabIndex = 2;
            // 
            // LblMetpem
            // 
            LblMetpem.AutoSize = true;
            LblMetpem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            LblMetpem.Location = new Point(3, 0);
            LblMetpem.Name = "LblMetpem";
            LblMetpem.Size = new Size(188, 25);
            LblMetpem.TabIndex = 2;
            LblMetpem.Text = "Metode Pembayaran";
            // 
            // LblTotHar
            // 
            LblTotHar.AutoSize = true;
            LblTotHar.Location = new Point(719, 37);
            LblTotHar.Name = "LblTotHar";
            LblTotHar.Size = new Size(75, 20);
            LblTotHar.TabIndex = 3;
            LblTotHar.Text = "Rp300000";
            // 
            // HeaderKonfirm
            // 
            HeaderKonfirm.ColumnCount = 3;
            HeaderKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 163F));
            HeaderKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 553F));
            HeaderKonfirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            HeaderKonfirm.Controls.Add(LblPending, 2, 0);
            HeaderKonfirm.Controls.Add(LblDetailTrans, 0, 0);
            HeaderKonfirm.Location = new Point(14, 17);
            HeaderKonfirm.Name = "HeaderKonfirm";
            HeaderKonfirm.RowCount = 1;
            HeaderKonfirm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HeaderKonfirm.Size = new Size(891, 30);
            HeaderKonfirm.TabIndex = 3;
            // 
            // LblPending
            // 
            LblPending.AutoSize = true;
            LblPending.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPending.ForeColor = Color.DarkOrange;
            LblPending.Location = new Point(719, 0);
            LblPending.Name = "LblPending";
            LblPending.Size = new Size(65, 20);
            LblPending.TabIndex = 1;
            LblPending.Text = "Pending";
            // 
            // LblDetailTrans
            // 
            LblDetailTrans.AutoSize = true;
            LblDetailTrans.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            LblDetailTrans.Location = new Point(3, 0);
            LblDetailTrans.Name = "LblDetailTrans";
            LblDetailTrans.Size = new Size(146, 25);
            LblDetailTrans.TabIndex = 2;
            LblDetailTrans.Text = "Detail Transaksi";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(14, 53);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(891, 180);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // CbxKonfTolak
            // 
            CbxKonfTolak.BackColor = SystemColors.MenuHighlight;
            CbxKonfTolak.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CbxKonfTolak.ForeColor = SystemColors.Window;
            CbxKonfTolak.FormattingEnabled = true;
            CbxKonfTolak.Items.AddRange(new object[] { "Konfirmasi", "Tolak" });
            CbxKonfTolak.Location = new Point(754, 340);
            CbxKonfTolak.Name = "CbxKonfTolak";
            CbxKonfTolak.Size = new Size(151, 28);
            CbxKonfTolak.TabIndex = 5;
            // 
            // BtnBukti
            // 
            BtnBukti.BackColor = Color.Transparent;
            BtnBukti.BackgroundImage = Properties.Resources.button_pembayaran;
            BtnBukti.BackgroundImageLayout = ImageLayout.Center;
            BtnBukti.FlatStyle = FlatStyle.Flat;
            BtnBukti.ForeColor = Color.Transparent;
            BtnBukti.Location = new Point(8, 324);
            BtnBukti.Margin = new Padding(2);
            BtnBukti.Name = "BtnBukti";
            BtnBukti.Size = new Size(236, 58);
            BtnBukti.TabIndex = 25;
            BtnBukti.UseVisualStyleBackColor = false;
            // 
            // KonfirmPartMetPem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(BtnBukti);
            Controls.Add(CbxKonfTolak);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(HeaderKonfirm);
            Controls.Add(FooterKonfirm);
            Name = "KonfirmPartMetPem";
            Size = new Size(940, 394);
            FooterKonfirm.ResumeLayout(false);
            FooterKonfirm.PerformLayout();
            HeaderKonfirm.ResumeLayout(false);
            HeaderKonfirm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LblWaktu;
        private Label LblBank;
        private TableLayoutPanel FooterKonfirm;
        private Label LblMetpem;
        private Label LblTotHar;
        private TableLayoutPanel HeaderKonfirm;
        private Label LblPending;
        private Label LblDetailTrans;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox CbxKonfTolak;
        private Button BtnBukti;
    }
}
