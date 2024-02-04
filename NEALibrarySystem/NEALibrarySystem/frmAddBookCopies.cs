using NEALibrarySystem.Data_Structures;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.barcodes = txtBarcodes.Text.Split('\n');
            if (ValidBookCopyBarcodes())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Invalid barcodes");
        }
        /// <summary>
        /// Closes the form and cancels the book copy adding process
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Determine of inputted barcodes consist of only digits and are the correct length
        /// </summary>
        /// <returns>Boolean result of whether the barcodes are valid</returns>
        private bool ValidBookCopyBarcodes()
        {
            foreach (string barcode in barcodes)
            {
                if (!(barcode.Length == Settings.BookCopyBarcodeLength && Regex.IsMatch(barcode, @"^[0-9]*$")))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
