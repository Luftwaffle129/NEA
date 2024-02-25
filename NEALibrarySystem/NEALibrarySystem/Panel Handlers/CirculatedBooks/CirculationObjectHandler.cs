using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.CirculatedBooks
{
    /// <summary>
    /// Used to control processes used in circulation for multiple features
    /// </summary>
    public class CirculationObjectHandler
    {
        // Objects
        public ListView SelectedBooks;
        private TextBox _memberBarcode; // Textbox that the member barcode is entered into
        private TextBox _memberName; // Textbox that the member name is displayed at
        private TextBox _currentLoans; // Textbox that displays the number of current loans the member has
        private TextBox _overdueBooks; // Texbox that displays the number of overdue books that the member has
        private TextBox _lateFees; // Textbox displaying the total sum of the member's late fees
        private TextBox _enterBarcodes; // Textbox used to enter book copy barcodes in order to select books

        // Variables
        private bool _priceNeeded; // used to toggle whether a price column is needed in the list view
        private List<BookCopy> _bookCopyList = new List<BookCopy>(); // book copies involved in the transaction
        public List<BookCopy> BookCopyList
        {
            get { return _bookCopyList; }
            set { _bookCopyList = value ?? new List<BookCopy>(); }
        }
        public Member SelectedMember; // member who the books are being circulated for
        public ListViewSorting Sorting;
        /// <summary>
        /// Initialises ciruclation objects
        /// </summary>
        public CirculationObjectHandler(TextBox memberBarcode, TextBox memberName, TextBox loans, TextBox overdue, TextBox lateFees, TextBox enterBarcode, ListView selectedBooks, bool priceNeeded)
        {
            Sorting = new ListViewSorting();
            // set up listview
            SelectedBooks = selectedBooks;
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
            SelectedBooks.Items.Clear();
        }
        /// <summary>
        /// Sets member details objects' text properties to be empty for their respective datatypes
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
            double lateFees = 0; // stores total late fees

            // find the member associated to the inputted barcode

            string barcode = _memberBarcode.Text;
            // check the inputted barcode has valid syntax
            if (DataLibrary.Members.Count > 0 && barcode.Length == Settings.MemberBarcodeLength && Regex.IsMatch(barcode, @"^[0-9]*$"))
            {
                // check if the inputted barcode is the same a member's barcode
                int memberBarcodeIndex = SearchAndSort.Binary(DataLibrary.MemberBarcodes, barcode, SearchAndSort.RefClassAndString);
                if (memberBarcodeIndex != -1)
                {
                    // find the member and their name from the barcode
                    SelectedMember = DataLibrary.MemberBarcodes[memberBarcodeIndex].Reference;
                    _memberName.Text = SelectedMember.FirstName.Value + " " + SelectedMember.Surname.Value;
                    // get member's loans and reservations
                    if (DataLibrary.CirculationCopies.Count > 0 && SelectedMember.Circulations.Count > 0)
                        foreach (CirculationCopy circulationCopy in SelectedMember.Circulations)
                            if (circulationCopy.Type.Value == CirculationType.Loaned)
                            {
                                currentLoans++;
                                if (circulationCopy.DueDate.Value < DateTime.Now) // if book is overdue
                                {
                                    overdueBooks++;
                                    lateFees += CirculationCopy.GetLateFees(circulationCopy.DueDate.Value);
                                }
                            }
                }
                else
                {
                    ResetMemberDetailFields();
                    SelectedMember = null;
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
        /// Sets up the list view
        /// </summary>
        /// <param name="PriceNeeded">Determines if the price of the books are displayed in the listview</param>
        private void InitialiseListView(bool PriceNeeded)
        {
            // sets properties
            SelectedBooks.View = View.Details;
            SelectedBooks.LabelEdit = false;
            SelectedBooks.AllowColumnReorder = false;
            SelectedBooks.CheckBoxes = true;
            SelectedBooks.MultiSelect = true;
            SelectedBooks.FullRowSelect = true;
            SelectedBooks.GridLines = false;
            SelectedBooks.Sorting = SortOrder.None;
            SelectedBooks.HeaderStyle = ColumnHeaderStyle.Clickable;
            SelectedBooks.Scrollable = true;

            // sets columns
            string[] columns;
            if (PriceNeeded) // if price is needed, add price as a column
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
            else
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
            ListViewHandler.SetColumns(columns, ref SelectedBooks);
        }
        /// <summary>
        /// Updates the items in the list view
        /// </summary>
        public void UpdateListView()
        {
            SelectedBooks.Items.Clear(); // clear the list view items
            foreach (BookCopy copy in BookCopyList) // add the book copies into the list
            {
                string[] data;
                if (_priceNeeded)
                    data = new string[]
                    {
                        copy.Barcode.Value,
                        copy.Book.Title.Value,
                        copy.Book.SeriesTitle.Value,
                        copy.Book.Author.Value,
                        DataFormatter.DoubleToPrice(copy.Book.Price.Value),
                        copy.GetStatus(),
                        copy.GetDueDate(),
                        copy.GetMemberBarcode()
                    };
                else
                    data = new string[]
                    {
                        copy.Barcode.Value,
                        copy.Book.Title.Value,
                        copy.Book.SeriesTitle.Value,
                        copy.Book.Author.Value,
                        copy.GetStatus(),
                        copy.GetDueDate(),
                        copy.GetMemberBarcode()
                    };
                ListViewItem row = new ListViewItem(data);
                SelectedBooks.Items.Add(row);
            }
            ListViewHandler.ResizeColumnHeaders(ref SelectedBooks);
            Sorting.SortedDescending = !Sorting.SortedDescending;
            ListViewHandler.SortListView(ref SelectedBooks, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
        }
        /// <summary>
        /// removes the checked items from the list view of selected books
        /// </summary>
        public void DeleteCheckedBookCopies()
        {
            if (SelectedBooks.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in SelectedBooks.CheckedItems) // for each selected book
                {
                    bool isDeleted = false;
                    int index = 0;
                    // find the index of the selected item in the list of book copies and delete the record
                    do
                    {
                        if (BookCopyList[index].Barcode.Value == item.SubItems[0].Text)
                        {
                            BookCopyList.RemoveAt(index);
                            isDeleted = true;
                        }
                    } while (++index < BookCopyList.Count && !isDeleted);
                }
                UpdateListView();
            }
        }
        /// <summary>
        /// Adds the book copy with the barcode inputted in the 'enter barcode' textbox
        /// </summary>
        public void AddBookCopy()
        {
            string barcode = _enterBarcodes.Text;
            if (barcode.Length == Settings.BookCopyBarcodeLength && Regex.IsMatch(barcode, @"^[0-9]*$"))
            {
                int index = SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, barcode, SearchAndSort.RefClassAndString); // gets the index of the stored book copy barcode
                if (index == -1) // check if book copy was found
                    MessageBox.Show("Book Copy Not Found");
                else
                {
                    BookCopy bookCopy = DataLibrary.BookCopyBarcodes[index].Reference;
                    if (BookCopyList.Contains(bookCopy))
                        MessageBox.Show("Book Copy Already Selected");
                    else
                    {
                        // add book copy, update list view, and empty the barcode textbox
                        BookCopyList.Add(bookCopy);
                        UpdateListView();
                        _enterBarcodes.Clear();
                    }
                }
            }
            else
                MessageBox.Show("Invalid barcode");
        }
    }
}
