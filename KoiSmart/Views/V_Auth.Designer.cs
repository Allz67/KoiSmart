namespace KoiSmart.Views
{
    partial class V_Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Auth));
            BttnRegister = new Button();
            BttnLogin = new Button();
            SuspendLayout();
            // 
            // BttnRegister
            // 
            BttnRegister.BackColor = Color.Red;
            BttnRegister.FlatStyle = FlatStyle.Flat;
            BttnRegister.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BttnRegister.Location = new Point(843, 388);
            BttnRegister.Name = "BttnRegister";
            BttnRegister.Size = new Size(433, 65);
            BttnRegister.TabIndex = 0;
            BttnRegister.Text = "Register";
            BttnRegister.UseVisualStyleBackColor = false;
            // 
            // BttnLogin
            // 
            BttnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BttnLogin.Location = new Point(843, 491);
            BttnLogin.Name = "BttnLogin";
            BttnLogin.Size = new Size(433, 65);
            BttnLogin.TabIndex = 1;
            BttnLogin.Text = "Login";
            BttnLogin.UseVisualStyleBackColor = true;
            // 
            // V_Auth
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1391, 769);
            Controls.Add(BttnLogin);
            Controls.Add(BttnRegister);
            DoubleBuffered = true;
            Name = "V_Auth";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_Auth";
            Load += V_Auth_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BttnRegister;
        private Button BttnLogin;
    }
}