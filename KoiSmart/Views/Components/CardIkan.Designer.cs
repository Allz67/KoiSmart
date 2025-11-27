namespace KoiSmart.Views.Components
{
    partial class CardIkan
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
            BttnCardLihat = new Button();
            LbStok = new Label();
            LbCardHargaIkan = new Label();
            LbCardNamaIkan = new Label();
            PBCardIkan = new PictureBox();
            PanelCardIkan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBCardIkan).BeginInit();
            SuspendLayout();
            // 
            // PanelCardIkan
            // 
            PanelCardIkan.BackgroundImage = Properties.Resources.kotak_ikan;
            PanelCardIkan.BackgroundImageLayout = ImageLayout.Zoom;
            PanelCardIkan.Controls.Add(BttnCardLihat);
            PanelCardIkan.Controls.Add(LbStok);
            PanelCardIkan.Controls.Add(LbCardHargaIkan);
            PanelCardIkan.Controls.Add(LbCardNamaIkan);
            PanelCardIkan.Controls.Add(PBCardIkan);
            PanelCardIkan.Location = new Point(3, 9);
            PanelCardIkan.Name = "PanelCardIkan";
            PanelCardIkan.Size = new Size(295, 285);
            PanelCardIkan.TabIndex = 0;
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
            // PBCardIkan
            // 
            PBCardIkan.BackgroundImageLayout = ImageLayout.Zoom;
            PBCardIkan.Location = new Point(24, 16);
            PBCardIkan.Name = "PBCardIkan";
            PBCardIkan.Size = new Size(245, 141);
            PBCardIkan.TabIndex = 0;
            PBCardIkan.TabStop = false;
            // 
            // CardIkan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(PanelCardIkan);
            Name = "CardIkan";
            Size = new Size(311, 305);
            PanelCardIkan.ResumeLayout(false);
            PanelCardIkan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBCardIkan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelCardIkan;
        private Button BttnCardLihat;
        private Label LbStok;
        private Label LbCardHargaIkan;
        private Label LbCardNamaIkan;
        private PictureBox PBCardIkan;
    }
}
