using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedItems;
using NEALibrarySystem.ListViewHandlers.SelectedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    public class BookLoanHandler
    {
        private DateTimePicker _returnDate;
        public CirculationObjectHandler CirculationManager;
        public BookLoanHandler(CirculationObjectHandler circulationObjectHandler, DateTimePicker ReturnDate) 
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
            _returnDate.Value = DateTime.Today;
            _returnDate.MinDate = DateTime.Today;
        }
        /// <summary>
        /// updates the book copies being loaned and creates a transaction record
        /// </summary>
        public void Save()
        {
            // check if necessary inputs exist
            if (CirculationManager.SelectedMember != null && CirculationManager.CirculatedBooks.Count > 0)
            {
                // update book copies
                foreach (CirculatedBook loanBook in CirculationManager.CirculatedBooks)
                {
                    int indexBook = 0;
                    bool loaned = false;
                    do
                    {
                        if (DataLibrary.Books[indexBook].BookCopies.Count > 0)
                        {
                            for (int indexCopy = 0; indexCopy < DataLibrary.Books[indexBook].BookCopies.Count; indexCopy++)
                            {
                                if (DataLibrary.Books[indexBook].BookCopies[indexCopy].Barcode == loanBook.Barcode)
                                {
                                    DataLibrary.Books[indexBook].BookCopies[indexCopy].Status = status.Loaned;
                                    DataLibrary.Books[indexBook].BookCopies[indexCopy].MemberID = CirculationManager.SelectedMember.Barcode;
                                    DataLibrary.Books[indexBook].BookCopies[indexCopy].ReturnDate = _returnDate.Value;
                                }
                            }
                        }
                    } while (++indexBook < DataLibrary.Books.Count && !loaned);
                }
                // create a transaction record

                Load();
            }
        }
        /// <summary>
        /// Updates the return date automatically and returns the 
        /// </summary>
        public void MemberBarcodeUpdated()
        {
            CirculationManager.UpdateMemberDetails();
            if (CirculationManager.SelectedMember != null)
            {
                _returnDate.Value = DateTime.Today.AddDays(Settings.LoanDurations[(int)CirculationManager.SelectedMember.Type]);
            }
            else
            {
                _returnDate.Value = DateTime.Today;
            }
        }
    }
}
