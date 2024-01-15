using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.CirculatedBooks
{
    public class ReserveHandler
    {
        private DateTimePicker _pickUpByDate; // date that the 
        public CirculationObjectHandler CirculationManager;
        public ReserveHandler(CirculationObjectHandler circulationObjectHandler, DateTimePicker pickUpByDate)
        {
            CirculationManager = circulationObjectHandler;
            _pickUpByDate = pickUpByDate;
        }
        /// <summary>
        /// empties all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
            _pickUpByDate.Value = DateTime.Today.AddDays(1);
            _pickUpByDate.MinDate = DateTime.Today.AddDays(1);
        }
        /// <summary>
        /// updates the book copies being loaned and creates a circulation record
        /// </summary>
        public void Save()
        {
            switch (DataLibrary.Reserve(CirculationManager.SelectedMember, CirculationManager.BookCopyList, _pickUpByDate.Value))
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
                    FrmMainSystem.Main.DisplayProcessMessage("Books Reserved");
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
            else
                _pickUpByDate.Value = DateTime.Today;
        }
    }
}
