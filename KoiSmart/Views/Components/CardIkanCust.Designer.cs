namespace KoiSmart.Views.Components
{
    partial class CardIkanCust
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
            PanelCardIkan = new Panel();
            PBCardIkan = new PictureBox();
            BttnCardLihat = new Button();
            LbCardHargaIkan = new Label();
            LbStok = new Label();
            LbCardNamaIkan = new Label();
            PanelCardIkan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBCardIkan).BeginInit();
            SuspendLayout();
            // 
            // PanelCardIkan
            // 
            PanelCardIkan.BackgroundImage = Properties.Resources.kotak_ikan;
            PanelCardIkan.BackgroundImageLayout = ImageLayout.Zoom;
            PanelCardIkan.Controls.Add(PBCardIkan);
            PanelCardIkan.Controls.Add(BttnCardLihat);
            PanelCardIkan.Controls.Add(LbCardHargaIkan);
            PanelCardIkan.Controls.Add(LbStok);
            PanelCardIkan.Controls.Add(LbCardNamaIkan);
            PanelCardIkan.Location = new Point(8, 10);
            PanelCardIkan.Name = "PanelCardIkan";
            PanelCardIkan.Size = new Size(295, 285);
            PanelCardIkan.TabIndex = 1;
            // 
            // PBCardIkan
            // 
            PBCardIkan.BackgroundImageLayout = ImageLayout.Zoom;
            PBCardIkan.Location = new Point(24, 16);
            PBCardIkan.Name = "PBCardIkan";
            PBCardIkan.Size = new Size(245, 141);
            PBCardIkan.TabIndex = 0;
            PBCardIkan.TabStop = false;
            // 
            // BttnCardLihat
            // 
            BttnCardLihat.BackColor = Color.MidnightBlue;
            BttnCardLihat.FlatStyle = FlatStyle.Flat;
            BttnCardLihat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnCardLihat.ForeColor = Color.White;
            BttnCardLihat.Location = new Point(176, 231);
            BttnCardLihat.Name = "BttnCardLihat";
            BttnCardLihat.Size = new Size(93, 34);
            BttnCardLihat.TabIndex = 5;
            BttnCardLihat.Text = "Lihat";
            BttnCardLihat.UseVisualStyleBackColor = false;
            BttnCardLihat.Click += BttnCardLihat_Click;
            // 
            // LbCardHargaIkan
            // 
            LbCardHargaIkan.AutoSize = true;
            LbCardHargaIkan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbCardHargaIkan.Location = new Point(27, 231);
            LbCardHargaIkan.Name = "LbCardHargaIkan";
            LbCardHargaIkan.Size = new Size(111, 28);
            LbCardHargaIkan.TabIndex = 2;
            LbCardHargaIkan.Text = "Harga Ikan";
            // 
            // LbStok
            // 
            LbStok.AutoSize = true;
            LbStok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbStok.Location = new Point(27, 205);
            LbStok.Name = "LbStok";
            LbStok.Size = new Size(45, 20);
            LbStok.TabIndex = 3;
            LbStok.Text = "Stok :";
            // 
            // LbCardNamaIkan
            // 
            LbCardNamaIkan.AutoSize = true;
            LbCardNamaIkan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbCardNamaIkan.Location = new Point(24, 169);
            LbCardNamaIkan.Name = "LbCardNamaIkan";
            LbCardNamaIkan.Size = new Size(110, 28);
            LbCardNamaIkan.TabIndex = 1;
            LbCardNamaIkan.Text = "Nama Ikan";
            // 
            // CardIkanCust
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelCardIkan);
            Name = "CardIkanCust";
            Size = new Size(311, 305);
            PanelCardIkan.ResumeLayout(false);
            PanelCardIkan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBCardIkan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelCardIkan;
        private Button BttnCardLihat;
        private PictureBox PBCardIkan;
        private Label LbStok;
        private Label LbCardHargaIkan;
        private Label LbCardNamaIkan;
    }
}
