using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    public class LoanHandler
    {
        private DateTimePicker _returnDate;
        public CirculationObjectHandler CirculationManager;
        public LoanHandler(CirculationObjectHandler circulationObjectHandler, DateTimePicker ReturnDate) 
        { 
            CirculationManager = circulationObjectHandler;
            _returnDate = ReturnDate;
        }
        /// <summary>
        /// empties all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
            _returnDate.Value = DateTime.Today.AddDays(1);
            _returnDate.MinDate = DateTime.Today.AddDays(1);
        }
        /// <summary>
        /// updates the book copies being loaned and creates a circulation record
        /// </summary>
        public void Save()
        {
            switch (DataLibrary.Loan(CirculationManager.SelectedMember, CirculationManager.BookCopyList, _returnDate.Value))
            {
                case DataLibrary.CirculationError.NoMember:
                    MessageBox.Show("Member not found");
                    break;
                case DataLibrary.CirculationError.NoBookCopies:
                    MessageBox.Show("No book copies selected");
                    break;
                case DataLibrary.CirculationError.InvalidBookCopies:
                    MessageBox.Show("Not all book copies available");
                    break;
                case DataLibrary.CirculationError.None:
                    FrmMainSystem.Main.DisplayProcessMessage("Books Loaned");
                    Load();
                    break;
            }
        }
        /// <summary>
        /// Updates the return date automatically and outputs the
        /// member name, late fees, current loans and number of overdue books
        /// if the inputted member barcode matches a member
        /// </summary>
        public void MemberBarcodeUpdated()
        {
            CirculationManager.UpdateMemberDetails();
            if (CirculationManager.SelectedMember != null)
                _returnDate.Value = DateTime.Today.AddDays(Settings.LoanDurations[(int)CirculationManager.SelectedMember.Type.Value]);
            else
                _returnDate.Value = DateTime.Today;
        }
    }
}