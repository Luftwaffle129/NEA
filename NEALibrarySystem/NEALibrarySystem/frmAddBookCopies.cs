﻿using NEALibrarySystem.Data_Structures;
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
        public string[] Barcodes;
        /// <summary>
        /// Returns the list of barcodes and and closes the form
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Barcodes = DataFormatter.SplitString(txtBarcodes.Text, "\r\n").ToArray();
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
        /// Determine of inputted barcodes consist of only digits, are unique and are the correct length
        /// </summary>
        /// <returns>Boolean result of whether the barcodes are valid</returns>
        private bool ValidBookCopyBarcodes()
        {
            if (Barcodes.Length > 0)
            {
                for (int i = 0; i < Barcodes.Length; i++)
                {
                    // check if barcode is the correct length and contains the correct characters
                    if (!(Barcodes[i].Length == Settings.BookCopyBarcodeLength && Regex.IsMatch(Barcodes[i], @"^[0-9]*$")))
                        return false;
                    // check that barcode is not already used
                    if (SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, Barcodes[i], SearchAndSort.RefClassAndString) != -1)
                        return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}
