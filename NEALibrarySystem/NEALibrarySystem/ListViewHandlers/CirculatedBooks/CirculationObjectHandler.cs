using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.CirculatedBooks
{
    public class CirculationObjectHandler
    {
        // Objects
        private ListView _selectedBooks;
        private TextBox _memberBarcode;
        private TextBox _memberName;
        private TextBox _currentLoans;
        private TextBox _overdueBooks;
        private TextBox _lateFees;
        private TextBox _enterBarcodes;

        // Variables
        private Member _selectedMember;
        private bool _priceNeeded;
        private List<BookCopy> _selectedBookCopyList;
        public List<BookCopy> SelectedBookCopyList
        {
            get { return _selectedBookCopyList; }
            set { _selectedBookCopyList = value ?? new List<BookCopy>(); }
        }

        /// <summary>
        /// Initials ciruclation objects
        /// </summary>
        /// <param name="memberBarcode"></param>
        /// <param name="memberName"></param>
        /// <param name="loans"></param>
        /// <param name="overdue"></param>
        /// <param name="lateFees"></param>
        /// <param name="enterBarcode"></param>
        /// <param name="lsv"></param>
        /// <param name="priceNeeded"></param>
        public CirculationObjectHandler(TextBox memberBarcode, TextBox memberName, TextBox loans, TextBox overdue, TextBox lateFees, TextBox enterBarcode, ListView lsv, bool priceNeeded)
        {
            // set up listview
            _selectedBooks = lsv;
            _memberBarcode = memberBarcode;
            _memberName = memberName;
            _currentLoans = loans;
            _overdueBooks = overdue;
            _lateFees = lateFees;
            _enterBarcodes = enterBarcode;
            _priceNeeded = priceNeeded;
            InitialiseListView(priceNeeded);
        }
        /// <summary>
        /// Clears the Objects' text properties
        /// </summary>
        public void ResetFields()
        {
            _memberName.Text = "";
            _memberBarcode.Text = "";
            _currentLoans.Text = "0";
            _lateFees.Text = "0";
            _overdueBooks.Text = "0";
            _enterBarcodes.Text = "";
        }
        public void UpdateMemberDetails()
        {
            // set up textboxes
            int currentLoans = 0;
            int overdueBooks = 0;
            int lateFees = 0;
            string barcode = _memberBarcode.Text;

            if (DataLibrary.Members.Count > 0 && barcode.Length == Settings.MemberBarcodeLength)
            {
                _selectedMember = null;
                // find the member's name from the barcode
                int memberIndex = SearchAndSort.Binary(DataLibrary.Members, barcode);
                // get member's loaned book copies

            }
            _currentLoans.Text = currentLoans.ToString();
            _overdueBooks.Text = overdueBooks.ToString();
            _lateFees.Text = lateFees.ToString();
        }
        /// <summary>
        /// sets up the list view
        /// </summary>
        /// <param name="PriceNeeded">determines if the price of the books are displayed in the listview</param>
        private void InitialiseListView(bool PriceNeeded)
        {
            // sets properties
            _selectedBooks.View = View.Details;
            _selectedBooks.LabelEdit = false;
            _selectedBooks.AllowColumnReorder = false;
            _selectedBooks.CheckBoxes = true;
            _selectedBooks.MultiSelect = true;
            _selectedBooks.FullRowSelect = true;
            _selectedBooks.GridLines = false;
            _selectedBooks.Sorting = SortOrder.None;
            _selectedBooks.HeaderStyle = ColumnHeaderStyle.Clickable;
            _selectedBooks.Scrollable = true;

            // sets columns
            string[] columns =
            {
                "Barcode",
                "Title",
                "Series Title",
                "Author",
                "Price"
            };
            if (!PriceNeeded)
            {
                string[] tempColumns = new string[columns.Length - 1];
                for (int index = 0; index < tempColumns.Length; index++)
                {
                    tempColumns[index] = columns[index];
                }
                columns = tempColumns;
            }
            ListViewHandler.SetColumns(columns, ref _selectedBooks);
        }
    }
}
