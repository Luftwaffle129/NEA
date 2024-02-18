using System;
using System.Drawing;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation(string message, string yesText = "Yes", string cancelText = "Cancel") // Used to initialise the form with the appropiate message
        {
            InitializeComponent();
            lblOutput.Text = message;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            btnYes.Text = yesText;
            btnCancel.Text = cancelText;
        }
        public frmConfirmation(string message, Color yesColor, Color cancelColor, string yesText = "Yes", string cancelText = "Cancel") // Used to initialise the form with the appropiate message
        {
            InitializeComponent();
            lblOutput.Text = message;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            btnYes.Text = yesText;
            btnCancel.Text = cancelText;
            btnYes.BackColor = yesColor;
            btnCancel.BackColor = cancelColor;
        }
        /// <summary>
        /// Returns a Yes as the dialog result
        /// </summary>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; 
            this.Close();
        }
        /// <summary>
        /// Reutrns a No as the dialog dresult
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; 
            this.Close();
        }
    }
}
