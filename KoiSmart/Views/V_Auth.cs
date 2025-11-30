using KoiSmart.Controllers;

namespace KoiSmart.Views
{
    public partial class V_Auth : Form
    {
        private AuthController _authController;

        public V_Auth()
        {
            InitializeComponent();
            _authController = new AuthController();

            BttnLogin.Click += BttnLogin_Click;
            BttnRegister.Click += BttnRegister_Click;
        }

        private void BttnLogin_Click(object sender, EventArgs e)
        {
            _authController.ShowLoginForm(this);
        }

        private void BttnRegister_Click(object sender, EventArgs e)
        {
            _authController.ShowRegisterForm(this);
        }

        private void V_Auth_Load(object sender, EventArgs e)
        {
        }
    }
}