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
    public class BookReturnHandler
    {
        public CirculationObjectHandler CirculationManager;
        public BookReturnHandler(CirculationObjectHandler circulationObjectHandler)
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
        /// updates the book copies being loaned and creates a transaction record
        /// </summary>
        public void Save()
        {
            // check if necessary inputs exist
            if (CirculationManager.SelectedMember != null)
            {
                if (CirculationManager.BookCopyList.Count > 0)
                {
                    // check if the books can be returned
                    bool validBooks = true;
                    int index = 0;
                    while (index < CirculationManager.BookCopyList.Count)
                    {
                        if (CirculationManager.BookCopyList[index].CirculationCopy != null)
                        {
                            // check if book is not loaned or reserved by another member
                            if (CirculationManager.BookCopyList[index].CirculationCopy.Type.Value == CirculationType.reserved
                                || CirculationManager.BookCopyList[index].CirculationCopy.CircMemberRelation.Member.Barcode.Value != CirculationManager.SelectedMember.Barcode.Value)
                                validBooks = false;
                        }
                        else
                                validBooks = false;
                    }
                    if (validBooks)
                    {
                        foreach (BookCopy copy in CirculationManager.BookCopyList)
                        {
                            DataLibrary.DeleteCirculationCopy(copy.CirculationCopy);
                        }
                        FrmMainSystem.Main.DisplayProcessMessage("Books Returned");
                    }
                    else
                        MessageBox.Show("Not all book copies loaned by the member");
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
        }
    }
}
