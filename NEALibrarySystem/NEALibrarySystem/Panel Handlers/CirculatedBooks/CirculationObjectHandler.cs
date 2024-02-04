﻿using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.CirculatedBooks
{
    public class CirculationObjectHandler
    {
        // Objects
        private ListView _selectedBooks;
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
        /// <summary>
        /// Initialises ciruclation objects
        /// </summary>
        public CirculationObjectHandler(TextBox memberBarcode, TextBox memberName, TextBox loans, TextBox overdue, TextBox lateFees, TextBox enterBarcode, ListView selectedBooks, bool priceNeeded)
        {
            // set up listview
            _selectedBooks = selectedBooks;
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
                    foreach (CircMemberRelation relation in SelectedMember.CircMemberRelations)
                        if (relation.CirculationCopy.Type.Value == CirculationType.Loaned)
                        {
                            currentLoans++;
                            if (relation.CirculationCopy.DueDate.Value < DateTime.Now) // if book is overdue
                            {
                                overdueBooks++;
                                lateFees += CirculationCopy.GetLateFees(relation.CirculationCopy.DueDate.Value);
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
        /// Sets up the list view
        /// </summary>
        /// <param name="PriceNeeded">Determines if the price of the books are displayed in the listview</param>
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
            ListViewHandler.SetColumns(columns, ref _selectedBooks);
        }
        /// <summary>
        /// Updates the items in the list view
        /// </summary>
        public void UpdateListView()
        {
            _selectedBooks.Items.Clear(); // clear the list view items
            foreach (BookCopy copy in BookCopyList) // add the book copies into the list
            {
                string[] data;
                if (_priceNeeded)
                    data = new string[]
                    {
                        copy.Barcode.Value,
                        copy.BookRelation.Book.Title.Value,
                        copy.BookRelation.Book.SeriesTitle.Value,
                        copy.BookRelation.Book.Author.Value,
                        DataFormatter.DoubleToPrice(copy.BookRelation.Book.Price.Value),
                        copy.GetStatus(),
                        copy.GetDueDate(),
                        copy.GetMemberBarcode()
                    };
                else
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
                ListViewItem row = new ListViewItem(data);
                _selectedBooks.Items.Add(row);
            }
            _selectedBooks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        /// <summary>
        /// removes the checked items from the list view of selected books
        /// </summary>
        public void DeleteCheckedBookCopies()
        {
            if (_selectedBooks.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in _selectedBooks.CheckedItems) // for each selected book
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
            int index = SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, barcode, SearchAndSort.RefClassAndString); // gets the index of the stored book copy barcode
            if (index == -1) // check if book copy was found
                MessageBox.Show("Book Copy Not Found");
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
}
