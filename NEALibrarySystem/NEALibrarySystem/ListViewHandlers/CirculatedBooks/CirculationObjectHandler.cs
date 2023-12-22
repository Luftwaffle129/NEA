using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
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
        private bool _priceNeeded;
        private List<BookCopy> _bookCopyList = new List<BookCopy>();
        public List<BookCopy> BookCopyList
        {
            get { return _bookCopyList; }
            set { _bookCopyList = value ?? new List<BookCopy>(); }
        }
        public Member SelectedMember;
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
            SelectedMember = null;
        }
        /// <summary>
        /// Clears the Objects' text properties
        /// </summary>
        public void ResetFields()
        {
            _enterBarcodes.Clear();
            _memberBarcode.Clear();
            ResetMemberDetailFields();
            _selectedBooks.Items.Clear();
        }
        /// <summary>
        /// Clears the objects' text properties
        /// </summary>
        public void ResetMemberDetailFields()
        {
            _memberName.Text = "";
            _currentLoans.Text = "0";
            _lateFees.Text = "0";
            _overdueBooks.Text = "0";
            _enterBarcodes.Text = "";
        }
        /// <summary>
        /// Displays the member name, current loans, number of overdue books and the total of the late fees
        /// of the member barcode inputted in a member is found
        /// </summary>
        public void UpdateMemberDetails()
        {
            // set up textboxes
            int currentLoans = 0;
            int overdueBooks = 0;
            double lateFees = 0;
            string barcode = _memberBarcode.Text;
            int memberBarcodeIndex = SearchAndSort.Binary(DataLibrary.MemberBarcodes, barcode, SearchAndSort.RefClassAndString);
            if (DataLibrary.Members.Count > 0 && barcode.Length == Settings.MemberBarcodeLength && memberBarcodeIndex != -1)
            {
                // find the member and their name from the barcode
                SelectedMember = DataLibrary.MemberBarcodes[memberBarcodeIndex].Reference;
                _memberName.Text = SelectedMember.FirstName.Value + " " + SelectedMember.Surname.Value;
                // get member's loans and reservations
                if (DataLibrary.CirculationCopies.Count > 0 && SelectedMember.CircMemberRelations.Count > 0)
                {
                    foreach (CircMemberRelation relation in SelectedMember.CircMemberRelations)
                    {
                        if (relation.CirculationCopy.Type.Value == CirculationType.Loaned)
                        {
                            currentLoans++;
                            if (relation.CirculationCopy.DueDate.Value < DateTime.Now)
                            {
                                overdueBooks++;
                                lateFees += GetLateFees(relation.CirculationCopy.DueDate.Value);
                            }
                        }
                    }
                }
            }
            else
            {
                ResetMemberDetailFields();
                SelectedMember = null;
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
            string[] columns;
            if (PriceNeeded)
            {
                columns = new string[]
                {
                    "Barcode",
                    "Title",
                    "Series Title",
                    "Author",
                    "Price",
                    "Status",
                    "Due Date",
                    "Member Barcode"
                };
            }
            else
            {
                columns = new string[]
                {
                    "Barcode",
                    "Title",
                    "Series Title",
                    "Author",
                    "Status",
                    "Due Date",
                    "Member Barcode"
                };
            }
            ListViewHandler.SetColumns(columns, ref _selectedBooks);
        }
        public void UpdateListView()
        {
            _selectedBooks.Items.Clear();
            foreach (BookCopy copy in BookCopyList)
            {
                string[] data = Array.Empty<string>();
                if (_priceNeeded)
                {
                    data = new string[]
                    {
                        copy.Barcode.Value,
                        copy.BookRelation.Book.Title.Value,
                        copy.BookRelation.Book.SeriesTitle.Value,
                        copy.BookRelation.Book.Author.Value,
                        copy.BookRelation.Book.Price.Value.ToString(),
                        copy.GetStatus(),
                        copy.GetDueDate(),
                        copy.GetMemberBarcode()
                    };
                }
                else
                {
                    data = new string[]
{
                        copy.Barcode.Value,
                        copy.BookRelation.Book.Title.Value,
                        copy.BookRelation.Book.SeriesTitle.Value,
                        copy.BookRelation.Book.Author.Value,
                        copy.GetStatus(),
                        copy.GetDueDate(),
                        copy.GetMemberBarcode()
                    };
                }
                ListViewItem row = new ListViewItem(data);
                _selectedBooks.Items.Add(row);
            }
        }
        /// <summary>
        /// removes the checked items from the list view of selected books
        /// </summary>
        public void DeleteCheckedBookCopies()
        {
            if (_selectedBooks.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in _selectedBooks.CheckedItems)
                {
                    if (BookCopyList.Count > 0)
                    {
                        for (int index = 0; index < BookCopyList.Count; index++)
                        {
                            if (BookCopyList[index].Barcode.Value == item.SubItems[0].Text)
                            {
                                BookCopyList.RemoveAt(index);
                            }
                        }
                    }
                }
                UpdateListView();
            }
        }
        public void AddBookCopy()
        {
            string barcode = _enterBarcodes.Text;
            int index = SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, barcode, SearchAndSort.RefClassAndString);
            if (index == -1)
            {
                MessageBox.Show("Book Not Found");
            }
            else
            {
                BookCopyList.Add(DataLibrary.BookCopyBarcodes[index].Reference);
                UpdateListView();
                _enterBarcodes.Text = "";
            }
        }
        public double GetLateFees(DateTime date)
        {
            if (date.Date <= DateTime.Now.Date)
                return 0;
            else
                return (date - DateTime.Now.Date).TotalDays * Settings.LateFeePerDay;
        }
    }
}
