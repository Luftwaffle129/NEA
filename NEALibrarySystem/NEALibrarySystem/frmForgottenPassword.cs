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
    public partial class frmForgottenPassword : Form
    {
        private string _verificationCode;
        private DateTime _codeSentTime = DateTime.MinValue;
        private DateTime _codeSubmitTime = DateTime.MinValue;
        private Staff _staff;
        public frmForgottenPassword()
        {
            InitializeComponent();
            frmLogIn.Main.ForgottenPasswordStaff = null;
        }
        private void btnSubmitVerificationcode_Click(object sender, EventArgs e)
        {
            if (_codeSentTime.AddMinutes(5) > DateTime.Now)
            {

                if (_codeSubmitTime.AddSeconds(1) > DateTime.Now)
                {
                    _codeSubmitTime = DateTime.Now;
                    if (txtVerificationCode.Text == _verificationCode)
                    {
                        frmLogIn.Main.ForgottenPasswordStaff = _staff;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect verification code");
                    }
                }
                else
                    MessageBox.Show("Too fast");
            }
            else
            {
                MessageBox.Show("Code expired. Send a new code.");
            }
        }

        private void btnSendVerificationCode_Click(object sender, EventArgs e)
        {
            if (DataFormatter.IsValidEmail(txtEmail.Text))
            {
                int index = SearchAndSort.Binary(DataLibrary.StaffEmails, txtEmail.Text, SearchAndSort.RefClassAndString);
                if (index != -1)
                {
                    _staff = DataLibrary.StaffEmails[index].Reference;
                    if (_codeSentTime.AddSeconds(30) < DateTime.Now)
                    {
                        Random rand = new Random();
                        _verificationCode = "";
                        for (int i = 0; i < 6; i++)
                        {
                            _verificationCode += rand.Next(0, 10).ToString();
                        }
                        EmailHandler.Send(DataLibrary.StaffEmails[index].Value, "Library System Verification Code", $"Your verification code used to reset your password is: {_verificationCode}");
                        _codeSentTime = DateTime.Now;
                        MessageBox.Show("Verification code sent");
                    }
                    else
                        MessageBox.Show("Too fast. Retry in " + Math.Ceiling((_codeSentTime.AddSeconds(30) - DateTime.Now).TotalSeconds).ToString() + " Seconds.");
                }
                else
                    MessageBox.Show("Email does not match a staff member");
            }
            else
                MessageBox.Show("Invalid email");
        }

        private void frmForgottenPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmLogIn.Main.ForgottenPasswordStaff == null)
            {
                frmLogIn.Main.Visible = true;
            }
            else
            {
                frmLogIn.Main.ResetPassword();
            }
        }
    }
}
