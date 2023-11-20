using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers.CirculatedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private ListView _listView;
        private TextBox _name;
        private TextBox _currentLoans;
        private TextBox _overdueBooks;
        private TextBox _lateFees;
        private TextBox _enterBarcode;
        /// <summary>
        /// Used to set up the listview in the circulatino handler upon initialisation
        /// </summary>
        /// <param name="lsv"></param>
        /// <param name="priceNeeded"></param>
        public CirculationObjectHandler(TextBox name, TextBox loans, TextBox overdue, TextBox lateFees,TextBox enterBarcode, ListView lsv, bool priceNeeded)
        {
            // set up listview
            _listView = lsv;
            _name = name;
            _currentLoans = loans;
            _overdueBooks = overdue;
            _lateFees = lateFees;
            _enterBarcode = enterBarcode;
            _priceNeeded = priceNeeded;
            InitialiseListView(priceNeeded);
        }
        public void UpdateMemberDetails(string barcode)
        {
            // set up textboxes
            int currentLoans = 0;
            int overdueBooks = 0;
            int lateFees = 0;

            if (DataLibrary.Members.Count > 0)
            {
                // find the member's name from the barcode
                int index = 0;
                bool memberFound = false;
                do
                {
                    if (DataLibrary.Members[index].Barcode == barcode)
                    {
                        memberFound = true;
                        _name.Text = $"{DataLibrary.Members[index].FirstName} {DataLibrary.Members[index].LastName}";
                    }
                } while (++index < DataLibrary.Members.Count && !memberFound);
                if (DataLibrary.Books.Count > 0)
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
                                        if (bookCopy.DueDate <= DateTime.Now) //check if the book is overdue
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
            _listView.View = View.Details;
            _listView.LabelEdit = false;
            _listView.AllowColumnReorder = false;
            _listView.CheckBoxes = true;
            _listView.MultiSelect = true;
            _listView.FullRowSelect = true;
            _listView.GridLines = false;
            _listView.Sorting = SortOrder.None;
            _listView.HeaderStyle = ColumnHeaderStyle.Clickable;
            _listView.Scrollable = true;

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
            ListViewHandler.SetColumns(columns, ref _listView);
        }
        /// <summary>
        /// Updates the ListView with the stored circulated books
        /// </summary>
        public void UpdateListView()
        {
            _listView.Items.Clear();
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
                _listView.Items.Add(row);
            }
        }
    }
}