using System;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation(string message)
        {
            InitializeComponent();
            lblOutput.Text = message;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; 
            this.Close();
        }

        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; 
            this.Close();
        }
    }
}
