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
    public partial class frmAddBookCopies : Form
    {
        public frmAddBookCopies()
        {
            InitializeComponent();
        }
        public string[] barcodes;
        /// <summary>
        /// Returns the list of barcodes and and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.barcodes = txtBarcodes.Text.Split('\n');
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Closes the form and cancels the book copy adding process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
