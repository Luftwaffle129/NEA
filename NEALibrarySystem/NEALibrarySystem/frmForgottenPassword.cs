using NEALibrarySystem.Data_Structures;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmForgottenPassword : Form
    {
        private string _verificationCode;
        private DateTime _codeSentTime = DateTime.MinValue;
        private DateTime _codeSubmitTime = DateTime.MinValue;
        private Staff _staff; // record of the staff member that the inputted email address belongs to
        public frmForgottenPassword()
        {
            InitializeComponent();
            frmLogIn.Main.ForgottenPasswordStaff = null;
        }
        private void btnSubmitVerificationcode_Click(object sender, EventArgs e)
        {
            // if user entered the correct verification code within the time constraints, move onto the reset password process
            if (_codeSentTime.AddMinutes(5) > DateTime.Now) // if the code has expired
            {

                if (_codeSubmitTime.AddSeconds(1) <= DateTime.Now) // if the user pressed the submit button too fast
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
            // sends a verification code email to the inputted email address if the email address belonmgs to a member
            if (DataFormatter.IsValidEmail(txtEmail.Text))
            {
                int index = SearchAndSort.Binary(DataLibrary.StaffEmails, txtEmail.Text, SearchAndSort.RefClassAndString); // attempts to find a staff record with the inputted email address
                if (index != -1)
                {
                    _staff = DataLibrary.StaffEmails[index].Reference;
                    if (_codeSentTime.AddSeconds(30) < DateTime.Now) // if email was sent less than 30 seconds ago
                    {
                        Random rand = new Random();
                        _verificationCode = "";
                        for (int i = 0; i < 6; i++)
                        {
                            _verificationCode += rand.Next(0, 10).ToString();
                        }
                        EmailHandler.Send(DataLibrary.StaffEmails[index].Value, "Library System Verification Code", $"Your verification code used to reset your password is: {_verificationCode}", true);
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
            if (frmLogIn.Main.ForgottenPasswordStaff != null) // if verification code was sent and the valid verificaion code was submitted
            {
                frmLogIn.Main.ResetPassword();
            }
            else
            {
                frmLogIn.Main.Visible = true;
            }
        }
    }
}
