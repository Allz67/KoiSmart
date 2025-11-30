using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
using System;
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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email dan password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var akun = _auth.Login(email, password);

            if (akun != null)
            {
                AppSession.SetUser(akun);

                MessageBox.Show($"Login berhasil! Selamat datang, {akun.NamaDepan}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (akun.Role == AkunRole.admin)
                {
                    V_HalUtamaAdmin adminForm = new V_HalUtamaAdmin();
                    adminForm.Show();
                }
                else if (akun.Role == AkunRole.customer)
                {
                    V_HalUtamaCust customerForm = new V_HalUtamaCust();
                    customerForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Email atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBPwLogin.Clear();
            }
        }
    }
}