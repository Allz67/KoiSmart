using System;
using System.Windows.Forms;

namespace KoiSmart.Views
{
    public partial class V_Register : Form
    {
        public V_Register()
        {
            InitializeComponent();
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
    }
}