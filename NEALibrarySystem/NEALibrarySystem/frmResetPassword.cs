using NEALibrarySystem.Data_Structures;
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
    public partial class frmResetPassword : Form
    {
        Staff _staff; // staff record which is having its password changed
        public frmResetPassword(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 4) 
            {
                if (txtConfirmPassword.Text == txtPassword.Text)
                {
                    _staff.Password = txtPassword.Text;
                    FileHandler.Save.Staff();
                    MessageBox.Show("Password changed");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }
            }
            else
            {
                MessageBox.Show("Password too short");
            }
        }

        private void frmResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogIn.Main.Visible = true;
        }
    }
}
