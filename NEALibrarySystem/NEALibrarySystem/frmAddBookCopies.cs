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
            this.barcodes = DataFormatter.SplitString(txtBarcodes.Text, "\r\n").ToArray();
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
            if (barcodes.Length > 0)
            {
                for (int i = 0; i < barcodes.Length; i++)
                {
                    if (barcodes[i].Substring(barcodes[i].Length - 1, 1) == "")
                        barcodes[i] = barcodes[i].Substring(0, barcodes[i].Length - 2);
                    if (!(barcodes[i].Length == Settings.BookCopyBarcodeLength && Regex.IsMatch(barcodes[i], @"^[0-9]*$")))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
}
