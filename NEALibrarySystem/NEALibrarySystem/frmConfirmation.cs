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
    public partial class frmConfirmation : Form
    {
        public frmConfirmation(string message)
        {
            InitializeComponent();
            lblOutput.Text = message;
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
