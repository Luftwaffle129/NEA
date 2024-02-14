using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    /// <summary>
    /// Handles the methods used in the sell panel
    /// </summary>
    public class SellHandler
    {
        // Objects of the sell panel
        public CirculationObjectHandler CirculationManager;
        public TextBox _totalPrice;
        public SellHandler(CirculationObjectHandler circulationObjectHandler, TextBox totalPrice)
        {
            CirculationManager = circulationObjectHandler;
            _totalPrice = totalPrice;
        }
        /// <summary>
        /// Resets all fields in the panel
        /// </summary>
        public void Load()
        {
            CirculationManager.ResetFields();
            CirculationManager.BookCopyList.Clear();
            CirculationManager.SelectedMember = null;
            _totalPrice.Text = "0.00";
        }
        /// <summary>
        /// Attempts to sell the book copies if possible. if not possible, output an error
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
        /// <summary>
        /// Adds the book copy and the total price
        /// </summary>
        public void BookCopyAdded()
        {
            CirculationManager.AddBookCopy();
            UpdateTotalPrice();
        }
        /// <summary>
        /// Removes the checked book copies and the total price
        /// </summary>
        public void BookCopiesRemoved() 
        {
            CirculationManager.DeleteCheckedBookCopies();
            UpdateTotalPrice();
        }
        // Displays the total price of the selected book copies in the total price textbox
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
