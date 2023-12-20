using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    public class ReturnHandler
    {
        public CirculationObjectHandler CirculationManager;
        public ReturnHandler(CirculationObjectHandler circulationObjectHandler)
        {
            CirculationManager = circulationObjectHandler;
        }
        /// <summary>
        /// empties all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
        }
        /// <summary>
        /// updates the book copies being loaned and creates a circulation record
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
                    MessageBox.Show("Not all book copies available");
                    break;
                case DataLibrary.CirculationError.None:
                    FrmMainSystem.Main.DisplayProcessMessage("Books Returned");
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
