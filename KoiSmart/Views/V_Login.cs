using System;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_Login : Form
    {
        public V_Login()
        {
            InitializeComponent();
        }

        private void V_Login_Load(object sender, EventArgs e)
        {
            // contoh: sembunyiin password
            TBPwLogin.UseSystemPasswordChar = true;
        }

        private void LbToRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new V_Register().Show();
        }
    }
}
