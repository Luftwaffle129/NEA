using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation(string message) // Used to initialise the form with the appropiate message
        {
            InitializeComponent();
            lblOutput.Text = message;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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
        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; 
            this.Close();
        }
    }
}
