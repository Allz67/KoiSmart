using KoiSmart.Controllers;
using KoiSmart.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_HalUtamaAdmin : Form
    {
        private AuthController _auth;

        public V_HalUtamaAdmin()
        {
            InitializeComponent();
            _auth = new AuthController();
        }

        private void V_HalUtamaAdmin_Load(object sender, EventArgs e)
        {
            // Check apakah user yang login adalah admin
            if (!AppSession.IsAuthenticated || AppSession.CurrentUser.Role != Models.AkunRole.admin)
            {
                MessageBox.Show("Akses ditolak! Hanya admin yang bisa mengakses halaman ini.");
                this.Close();
                return;
            }

            // Set title dengan nama user
            this.Text = $"Dashboard Admin - {AppSession.CurrentUser.NamaDepan} {AppSession.CurrentUser.NamaBelakang}";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _auth.Logout();

                // Buka login form
                V_Login loginForm = new V_Login();
                loginForm.Show();

                // Tutup dashboard
                this.Close();
            }
        }

        private void BtnTambahIkan_Click(object sender, EventArgs e)
        {
            // Navigate to V_FormDataIkan and hide this dashboard.
            // When the fish form is closed, restore this dashboard.
            V_FormDataIkan formDataIkan = new V_FormDataIkan();
            this.Hide();
            formDataIkan.FormClosed += (s, args) => this.Show();
            formDataIkan.Show();
        }
    }
}
