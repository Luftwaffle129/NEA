using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedItems;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NEALibrarySystem.ListViewHandlers.SelectedItems
{
    /// <summary>
    /// used to retrieve the member details and handle the list view for the circulation panel
    /// </summary>
    public class CirculationObjectHandler
    {
        private bool _priceNeeded;
        private List<CirculatedBook> _circulatedBooks;
        public List<CirculatedBook> CirculatedBooks
        {
            get { return _circulatedBooks; }
            set 
            { 
                _circulatedBooks = value ?? new List<CirculatedBook>();
                UpdateListView();
            }
        }
        private Member _selectedMember;
        public Member SelectedMember { get; set; }
        private ListView _selectedBooks;
        public TextBox MemberBarcode;
        private TextBox _memberName;
        private TextBox _currentLoans;
        private TextBox _overdueBooks;
        private TextBox _lateFees;
        private TextBox _enterBarcodes;
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
        public CirculationObjectHandler(TextBox memberBarcode, TextBox memberName, TextBox loans, TextBox overdue, TextBox lateFees,TextBox enterBarcode, ListView lsv, bool priceNeeded)
        {
            // set up listview
            _selectedBooks = lsv;
            MemberBarcode = memberBarcode;
            _memberName = memberName;
            _currentLoans = loans;
            _overdueBooks = overdue;
            _lateFees = lateFees;
            _enterBarcodes = enterBarcode;
            _priceNeeded = priceNeeded;
            InitialiseListView(priceNeeded);
        }
        public void ResetFields()
        {
            _memberName.Text = "";
            MemberBarcode.Text = "";
            _currentLoans.Text = "0";
            _lateFees.Text = "0";
            _overdueBooks.Text = "0";
            _enterBarcodes.Text = "";
            _selectedBooks.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode">Barcode on the member</param>
        public void UpdateMemberDetails()
        {
            // set up textboxes
            int currentLoans = 0;
            int overdueBooks = 0;
            int lateFees = 0;
            string barcode = MemberBarcode.Text;

            if (DataLibrary.Members.Count > 0 && barcode.Length == Settings.MemberBarcodeLength)
            {
                SelectedMember = null;
                // find the member's name from the barcode
                int index = 0;
                bool memberFound = false;
                do
                {
                    if (DataLibrary.Members[index].Barcode == barcode)
                    {
                        memberFound = true;
                        SelectedMember = DataLibrary.Members[index];
                        _memberName.Text = $"{SelectedMember.FirstName} {SelectedMember.LastName}";
                    }
                } while (++index < DataLibrary.Members.Count && !memberFound);
                if (DataLibrary.Books.Count > 0 && memberFound)
                {
                    // get total of the number of loans, overdue books and the late fees of the member
                    foreach (Book book in DataLibrary.Books)
                    {
                        if (book.BookCopies.Count > 0)
                        {
                            foreach (BookCopy bookCopy in book.BookCopies)
                            {
                                if (bookCopy.MemberID == barcode) // if book is associated with the member
                                {
                                    if (bookCopy.Status == status.Loaned) // if the book is loaned
                                    {
                                        currentLoans++;
                                        if (bookCopy.ReturnDate < DateTime.Today) //check if the book is overdue
                                        {
                                            overdueBooks++;
                                            lateFees += 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
        /// <summary>
        /// Updates the ListView with the stored circulated books
        /// </summary>
        public void UpdateListView()
        {
            _selectedBooks.Items.Clear();
            foreach (var circulatedBook in _circulatedBooks)
            {
                string[] data = Array.Empty<string>();
                if (_priceNeeded)
                {
                    data = new string[]
                    {
                        circulatedBook.Barcode,
                        circulatedBook.Title,
                        circulatedBook.SeriesTitle,
                        circulatedBook.Author,
                        circulatedBook.Price
                    };
                }
                else
                {
                    data = new string[]
{
                        circulatedBook.Barcode,
                        circulatedBook.Title,
                        circulatedBook.SeriesTitle,
                        circulatedBook.Author
                    };
                }
                ListViewItem row = new ListViewItem(data);
                _selectedBooks.Items.Add(row);
            }
        }
        /// <summary>
        /// removes the checked items from the list view of selected books
        /// </summary>
        public void DeleteCheckedListView()
        {
            if (_selectedBooks.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in _selectedBooks.CheckedItems)
                {
                    if (_circulatedBooks.Count > 0)
                    {
                        for (int index = 0; index < _circulatedBooks.Count; index++)
                        {
                            if (_circulatedBooks[index].Barcode == item.SubItems[0].Text)
                            {
                                _circulatedBooks.RemoveAt(index);
                            }
                        }
                    }
                }
                UpdateListView();
            }
        }
    }
}