namespace KoiSmart.Views
{
    partial class V_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Login));
            TBEmailLogin = new TextBox();
            TBPwLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BttnVLoogin = new Button();
            SuspendLayout();
            // 
            // TBEmailLogin
            // 
            TBEmailLogin.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBEmailLogin.Location = new Point(836, 341);
            TBEmailLogin.Name = "TBEmailLogin";
            TBEmailLogin.Size = new Size(364, 51);
            TBEmailLogin.TabIndex = 0;
            // 
            // TBPwLogin
            // 
            TBPwLogin.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBPwLogin.Location = new Point(836, 471);
            TBPwLogin.Name = "TBPwLogin";
            TBPwLogin.Size = new Size(364, 51);
            TBPwLogin.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(836, 295);
            label1.Name = "label1";
            label1.Size = new Size(70, 31);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(836, 426);
            label2.Name = "label2";
            label2.Size = new Size(112, 31);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // BttnVLoogin
            // 
            BttnVLoogin.BackColor = Color.Red;
            BttnVLoogin.FlatStyle = FlatStyle.Flat;
            BttnVLoogin.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BttnVLoogin.ForeColor = Color.White;
            BttnVLoogin.Location = new Point(836, 580);
            BttnVLoogin.Name = "BttnVLoogin";
            BttnVLoogin.Size = new Size(364, 51);
            BttnVLoogin.TabIndex = 4;
            BttnVLoogin.Text = "Login";
            BttnVLoogin.UseVisualStyleBackColor = false;
            // 
            // V_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1403, 772);
            Controls.Add(BttnVLoogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TBPwLogin);
            Controls.Add(TBEmailLogin);
            Name = "V_Login";
            Text = "V_Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBEmailLogin;
        private TextBox TBPwLogin;
        private Label label1;
        private Label label2;
        private Button BttnVLoogin;
    }
}