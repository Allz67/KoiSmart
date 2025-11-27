namespace KoiSmart.Views
{
    partial class V_FormDataIkan
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
            TbBuatJenis = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Location = new Point(81, 156);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 0;
            label1.Text = "Jenis";
            // 
            // TbBuatJenis
            // 
            TbBuatJenis.BackColor = SystemColors.ScrollBar;
            TbBuatJenis.Location = new Point(81, 184);
            TbBuatJenis.Name = "TbBuatJenis";
            TbBuatJenis.Size = new Size(413, 31);
            TbBuatJenis.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(81, 256);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(413, 31);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Location = new Point(81, 228);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 3;
            label2.Text = "Gender";
            // 
            // V_FormDataIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormTambahDataIkan_Adm;
            ClientSize = new Size(1418, 776);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(TbBuatJenis);
            Controls.Add(label1);
            Name = "V_FormDataIkan";
            Text = "V_FormDataIkan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TbBuatJenis;
        private TextBox textBox1;
        private Label label2;
    }
}