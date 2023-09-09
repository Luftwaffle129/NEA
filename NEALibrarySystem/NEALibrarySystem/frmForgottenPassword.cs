using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmForgottenPassword : Form
    {
        public frmForgottenPassword()
        {
            InitializeComponent();
        }

        private void lblForgottenPassword_Click(object sender, EventArgs e)
        {

        }
        frmResetPassword frmResetPassword;
        private void btnSubmitVerificationcode_Click(object sender, EventArgs e)
        {
            frmResetPassword = new frmResetPassword();
            frmResetPassword.ShowDialog();
        }
    }
}
