using NEALibrarySystem.Data_Structures;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmLogIn : Form
    {
        private const int ATTEMPTCOOLDOWN = 1; // minimum time between attempts in seconds
        //main system
        public static frmLogIn Main;
        FrmMainSystem frmMainSystem;

        // password recovery
        frmForgottenPassword frmForgottenPassword;
        frmResetPassword frmResetPassword;
        public Staff ForgottenPasswordStaff;

        DateTime previousAttempt = DateTime.MinValue;
        public frmLogIn()
        {
            InitializeComponent();
            Main = this;
            FileHandler.HandleStartUp();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DateTime.Now - previousAttempt > TimeSpan.FromSeconds(ATTEMPTCOOLDOWN)) // if the cooldown period between log in attempts is over
            {
                int staffIndex = IsValidCredentials();
                if (staffIndex != -1 )
                {
                    // opens the mains system, hides the log in form
                    frmMainSystem = new FrmMainSystem(DataLibrary.StaffUsernames[staffIndex].Reference);
                    frmMainSystem.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
            else
            {
                MessageBox.Show("Wait 1 second between attempts");
            }
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // opens the forgotten password form hides the log in form
            frmForgottenPassword = new frmForgottenPassword();
            frmForgottenPassword.Show();
            this.Hide();
        }
        /// <summary>
        /// Checks if the inputted username and password match a staff record
        /// </summary>
        /// <returns>Index of staff record if a match, else -1</returns>
        private int IsValidCredentials()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            int usernameIndex = SearchAndSort.Binary(DataLibrary.StaffUsernames, username, SearchAndSort.RefClassAndString); // attempt to find staff record wit the inputted username

            if (usernameIndex != -1) // if staff record was found
            {
                if (password == DataLibrary.StaffUsernames[usernameIndex].Reference.Password)
                {
                    return usernameIndex;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        // clears the password field
        public void ClearPassword()
        {
            txtPassword.Text = "";
        }
        // opens the reset password form with the staff record whom is having their password changed
        public void ResetPassword()
        {
            frmResetPassword = new frmResetPassword(ForgottenPasswordStaff);
            frmResetPassword.Show();
            this.Hide();
        }
    }
}