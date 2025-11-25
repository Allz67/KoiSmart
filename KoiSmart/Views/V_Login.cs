using KoiSmart.Controllers;
using System;
using System.IO;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_Login : Form
    {
        private AuthController _auth;
        public V_Login()
        {
            InitializeComponent();
            _auth = new AuthController();
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

        private void BttnVLogin_Click(object sender, EventArgs e)
        {
            string email = TBEmailLogin.Text.Trim();
            string password = TBPwLogin.Text.Trim();

            var akun = _auth.Login(email, password);

            if (akun != null)
            {
                MessageBox.Show("Login berhasil!");

                this.Hide();
                // NANTI diganti jadi halaman utama
                // new V_Home(akun).Show();
            }
            else
            {
                MessageBox.Show("Email atau password salah!");
            }
        }
    }
}
