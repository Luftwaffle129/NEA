using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public class SellHandler
    {
        public CirculationObjectHandler CirculationManager;
        public TextBox _totalPrice;
        public SellHandler(CirculationObjectHandler circulationObjectHandler, TextBox totalPrice)
        {
            CirculationManager = circulationObjectHandler;
            _totalPrice = totalPrice;
        }
        /// <summary>
        /// empties all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
        }
        /// <summary>
        /// updates the book copies being loaned and creates a circulation record
        /// </summary>
        public void Save()
        {
            switch (DataLibrary.Sell(CirculationManager.BookCopyList))
            {
                case DataLibrary.CirculationError.NoBookCopies:
                    MessageBox.Show("No book copies selected");
                    break;
                case DataLibrary.CirculationError.InvalidBookCopies:
                    MessageBox.Show("Not all book copies available");
                    break;
                case DataLibrary.CirculationError.None:
                    FrmMainSystem.Main.DisplayProcessMessage("Books Sold");
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
        public void BookCopyAdded()
        {
            CirculationManager.AddBookCopy();
            UpdateTotalPrice();
        }
        public void BookCopiesRemoved() 
        {
            CirculationManager.DeleteCheckedBookCopies();
            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            double totalPrice = 0;
            if (CirculationManager.BookCopyList.Count > 0)
                foreach (BookCopy copy in CirculationManager.BookCopyList)
                    totalPrice += copy.BookRelation.Book.Price.Value;
            _totalPrice.Text = DataFormatter.DoubleToPrice(totalPrice);
        }
    }
}
