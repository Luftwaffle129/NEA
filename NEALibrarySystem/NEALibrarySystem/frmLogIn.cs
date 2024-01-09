using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmLogIn : Form
    {
        public static frmLogIn Main;
        FrmMainSystem frmMainSystem;
        frmForgottenPassword frmForgottenPassword;
        public frmLogIn()
        {
            InitializeComponent();
            Main = this;
            LimitPrototypeFeatures();
        }
        /// <summary>
        /// Used to hide objects not included in the prototype on the interface from the user
        /// </summary>
        private void LimitPrototypeFeatures()
        {
            txtPassword.ReadOnly = true;
            txtUsername.ReadOnly = true;
            btnForgotPassword.Visible = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // opens the mains system, hides the log in form
            frmMainSystem = new FrmMainSystem();
            frmMainSystem.Show();
            this.Hide();
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // opens the forgotten password formb hides the log in form
            frmForgottenPassword = new frmForgottenPassword();
            frmForgottenPassword.Show();
            this.Hide();
        }
    }
}
