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
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
            _returnDate.Value = DateTime.Today;
            _returnDate.MinDate = DateTime.Today;
        }
        /// <summary>
        /// updates the book copies being loaned and creates a transaction record
        /// </summary>
        public void Save()
        {
            // check if necessary inputs exist
            if (CirculationManager.SelectedMember != null)
            {
                if (CirculationManager.BookCopyList.Count > 0)
                {
                    // check if the books can be loaned
                    bool validBooks = true;
                    int index = 0;
                    while (index < CirculationManager.BookCopyList.Count)
                    {
                        if (CirculationManager.BookCopyList[index].CirculationCopy != null)
                        {
                            // check if book is not loaned or reserved by another member
                            if (CirculationManager.BookCopyList[index].CirculationCopy.Type.Value == CirculationType.Loaned 
                                || CirculationManager.BookCopyList[index].CirculationCopy.CircMemberRelation.Member.Barcode.Value != CirculationManager.SelectedMember.Barcode.Value)
                                validBooks = false;
                        }
                    }
                    if (validBooks)
                    {
                        // loan books
                        foreach (BookCopy copy in CirculationManager.BookCopyList)
                        {
                            CirculationCopyCreator creator = new CirculationCopyCreator();
                            creator.BookCopy = copy;
                            creator.Member = CirculationManager.SelectedMember;
                            creator.DueDate = _returnDate.Value;
                            creator.Type = CirculationType.Loaned;
                            DataLibrary.CirculationCopies.Add(new CirculationCopy(creator));
                        }
                        FrmMainSystem.Main.DisplayProcessMessage("Books Loaned");
                        Load();
                    }
                    else
                        MessageBox.Show("Not all book copies available");
                }
                else
                    MessageBox.Show("No book copies selected");
            }
            else
                MessageBox.Show("Member not found");
        }
        /// <summary>
        /// Updates the return date automatically and returns the 
        /// </summary>
        public void MemberBarcodeUpdated()
        {
            CirculationManager.UpdateMemberDetails();
            if (CirculationManager.SelectedMember != null)
            {
                _returnDate.Value = DateTime.Today.AddDays(Settings.LoanDurations[(int)CirculationManager.SelectedMember.Type.Value]);
            }
            else
            {
                _returnDate.Value = DateTime.Today;
            }
        }
    }
}