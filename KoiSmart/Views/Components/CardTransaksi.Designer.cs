namespace KoiSmart.Views.Components
{
    partial class CardTransaksi
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
            PnlHeader = new Panel();
            LblTanggal = new Label();
            LblTotal = new Label();
            LblStatus = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            FlpBarang = new FlowLayoutPanel();
            PnlFooter = new Panel();
            PnlHeader.SuspendLayout();
            PnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // PnlHeader
            // 
            PnlHeader.Controls.Add(LblTanggal);
            PnlHeader.Controls.Add(LblTotal);
            PnlHeader.Dock = DockStyle.Bottom;
            PnlHeader.Location = new Point(5, 194);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(930, 40);
            PnlHeader.TabIndex = 0;
            // 
            // LblTanggal
            // 
            LblTanggal.AutoSize = true;
            LblTanggal.BackColor = Color.Transparent;
            LblTanggal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTanggal.Location = new Point(5, 10);
            LblTanggal.Name = "LblTanggal";
            LblTanggal.Size = new Size(218, 20);
            LblTanggal.TabIndex = 1;
            LblTanggal.Text = "Id Transaksi | Tanggal transaksi";
            // 
            // LblTotal
            // 
            LblTotal.AutoSize = true;
            LblTotal.BackColor = Color.Transparent;
            LblTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTotal.ForeColor = Color.Black;
            LblTotal.Location = new Point(796, 10);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(88, 20);
            LblTotal.TabIndex = 3;
            LblTotal.Text = "Total Harga";
            // 
            // LblStatus
            // 
            LblStatus.AutoSize = true;
            LblStatus.BackColor = Color.Transparent;
            LblStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblStatus.ForeColor = Color.MidnightBlue;
            LblStatus.Location = new Point(804, 8);
            LblStatus.Name = "LblStatus";
            LblStatus.Size = new Size(116, 20);
            LblStatus.TabIndex = 2;
            LblStatus.Text = "Status Transaksi";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Location = new Point(5, 55);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // FlpBarang
            // 
            FlpBarang.AutoScroll = true;
            FlpBarang.AutoSize = true;
            FlpBarang.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FlpBarang.Dock = DockStyle.Fill;
            FlpBarang.FlowDirection = FlowDirection.TopDown;
            FlpBarang.Location = new Point(5, 31);
            FlpBarang.Name = "FlpBarang";
            FlpBarang.Size = new Size(930, 163);
            FlpBarang.TabIndex = 2;
            // 
            // PnlFooter
            // 
            PnlFooter.Controls.Add(LblStatus);
            PnlFooter.Dock = DockStyle.Top;
            PnlFooter.Location = new Point(5, 5);
            PnlFooter.Name = "PnlFooter";
            PnlFooter.Size = new Size(930, 26);
            PnlFooter.TabIndex = 3;
            // 
            // CardTransaksi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(FlpBarang);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(PnlHeader);
            Controls.Add(PnlFooter);
            Name = "CardTransaksi";
            Padding = new Padding(5);
            Size = new Size(940, 239);
            PnlHeader.ResumeLayout(false);
            PnlHeader.PerformLayout();
            PnlFooter.ResumeLayout(false);
            PnlFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlHeader;
        private Label LblStatus;
        private Label LblTanggal;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel FlpBarang;
        private Label LblTotal;
        private Panel PnlFooter;
    }
}
