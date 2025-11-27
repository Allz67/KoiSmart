using KoiSmart.Controllers;
using KoiSmart.Helpers;
using KoiSmart.Models;
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
            // Sembunyiin password
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

            // Validasi input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email dan password harus diisi!");
                return;
            }

            // Coba login
            var akun = _auth.Login(email, password);

            if (akun != null)
            {
                // Simpan ke session
                AppSession.SetUser(akun);

                MessageBox.Show("Login berhasil!");

                // NAVIGATION berdasarkan ROLE
                if (akun.Role == AkunRole.admin)
                {
                    // Buka halaman admin
                    V_HalUtamaAdmin adminForm = new V_HalUtamaAdmin();
                    adminForm.Show();
                }
                else if (akun.Role == AkunRole.customer)
                {
                    // Buka halaman customer (jika sudah ada)
                    // V_HalUtamaCustomer customerForm = new V_HalUtamaCustomer();
                    // customerForm.Show();
                    MessageBox.Show("Halaman customer belum dibuat");
                }

                // Tutup login form
                this.Close();
            }
            else
            {
                MessageBox.Show("Email atau password salah!");
                TBPwLogin.Clear();
            }
        }
    }
}
