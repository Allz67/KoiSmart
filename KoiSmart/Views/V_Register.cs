using KoiSmart.Controllers;
using KoiSmart.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_Register : Form
    {
        private AuthController _auth = new AuthController();
        public V_Register()
        {
            InitializeComponent();
            _auth = new AuthController();
        }

        private void V_Register_Load(object sender, EventArgs e)
        {
            // Jika mau tambahin hal-hal default di sini
        }

        private void LbToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new V_Login().Show();
        }

        private void BttnVRegister_Click(object sender, EventArgs e)
        {
            Akun akunBaru = new Akun
            {
                NamaDepan = TBNamaDepan.Text.Trim(),
                NamaBelakang = TBNamaBelakang.Text.Trim(),
                Username = TBUsername.Text.Trim(),
                Email = TBEmailRegist.Text.Trim(),
                Password = TBPwRegist.Text.Trim(),
                NoTelepon = TBNoTelp.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(akunBaru.NamaDepan) ||
                string.IsNullOrWhiteSpace(akunBaru.NamaBelakang) ||
                string.IsNullOrWhiteSpace(akunBaru.Username) ||
                string.IsNullOrWhiteSpace(akunBaru.Email) ||
                string.IsNullOrWhiteSpace(akunBaru.Password) ||
                string.IsNullOrWhiteSpace(akunBaru.NoTelepon))
            {
                MessageBox.Show("Semua field wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sukses = _auth.Register(akunBaru);

            if (sukses)
            {
                MessageBox.Show("Akun berhasil dibuat! Silakan login.");

                this.Hide();
                new V_Login().Show();
            }
            else
            {
                MessageBox.Show("Registrasi gagal!");
            }
        }
    }
}