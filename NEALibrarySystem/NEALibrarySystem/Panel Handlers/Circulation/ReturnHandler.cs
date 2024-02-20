using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    /// <summary>
    /// Handles the processes used in the return panel
    /// </summary>
    public class ReturnHandler
    {
        public CirculationObjectHandler CirculationManager;
        public ReturnHandler(CirculationObjectHandler circulationObjectHandler)
        {
            CirculationManager = circulationObjectHandler;
        }
        /// <summary>
        /// Resets all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
        }
        /// <summary>
        /// Returns the books if possible, else outputs an error to the user
        /// </summary>
        public void Save()
        {
            switch (DataLibrary.Return(CirculationManager.SelectedMember, CirculationManager.BookCopyList))
            {
                case DataLibrary.CirculationError.NoMember:
                    MessageBox.Show("Member not found");
                    break;
                case DataLibrary.CirculationError.NoBookCopies:
                    MessageBox.Show("No book copies selected");
                    break;
                case DataLibrary.CirculationError.InvalidBookCopies:
                    MessageBox.Show("Not all book copies returnable");
                    break;
                case DataLibrary.CirculationError.None:
                    Load();
                    break;
            }
        }
        /// <summary>
        /// Outputs the member name, late fees, current loans and number of overdue books
        /// if the inputted member barcode matches a member
        /// </summary>
        public void MemberBarcodeUpdated()
        {
            CirculationManager.UpdateMemberDetails();
        }
    }
}
