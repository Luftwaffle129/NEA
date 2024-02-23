using NEALibrarySystem.Data_Structures;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.CirculatedBooks
{
    /// <summary>
    /// Handles the processes used in the reserve panel
    /// </summary>
    public class ReserveHandler
    {
        // objects of the reserve panel
        private DateTimePicker _pickUpByDate;
        public CirculationObjectHandler CirculationManager;
        public ReserveHandler(CirculationObjectHandler circulationObjectHandler, DateTimePicker pickUpByDate)
        {
            CirculationManager = circulationObjectHandler;
            _pickUpByDate = pickUpByDate;
            _pickUpByDate.Value = DateTime.Today.AddDays(1);
            _pickUpByDate.MinDate = DateTime.Today.AddDays(1);
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
            switch (DataLibrary.Reserve(CirculationManager.SelectedMember, CirculationManager.BookCopyList, _pickUpByDate.Value)) // Attempt to reserve the book and handle the error
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
                _pickUpByDate.Value = DateTime.Today.AddDays(Settings.ReserveDurations[(int)CirculationManager.SelectedMember.Type.Value]);
        }
    }
}
