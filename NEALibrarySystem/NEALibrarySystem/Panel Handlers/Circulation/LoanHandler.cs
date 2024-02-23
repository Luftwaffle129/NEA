using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    /// <summary>
    /// Handles the processes used in the loan panel
    /// </summary>
    public class LoanHandler
    {
        // objects of the loan panel
        private DateTimePicker _returnDate;
        public CirculationObjectHandler CirculationManager;
        public LoanHandler(CirculationObjectHandler circulationObjectHandler, DateTimePicker ReturnDate) 
        { 
            CirculationManager = circulationObjectHandler;
            _returnDate = ReturnDate;
            _returnDate.Value = DateTime.Today.AddDays(1);
            _returnDate.MinDate = DateTime.Today.AddDays(1);
        }
        /// <summary>
        /// Resets the objects and empties the current member value
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
            CirculationManager.UpdateListView();
        }
        /// <summary>
        /// Loans the book copies if possible, else output an error to the user
        /// </summary>
        public void Save()
        {
            switch (DataLibrary.Loan(CirculationManager.SelectedMember, CirculationManager.BookCopyList, _returnDate.Value)) // Attempt to loan the book and handle the error
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
                _returnDate.Value = DateTime.Today.AddDays(Data_Structures.Settings.LoanDurations[(int)CirculationManager.SelectedMember.Type.Value]);
        }
    }
}