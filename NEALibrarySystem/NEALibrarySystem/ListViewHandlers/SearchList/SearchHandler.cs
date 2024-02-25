using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using NEALibrarySystem.ListViewHandlers.SearchList;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using static NEALibrarySystem.Data_Structures.DataLibrary;

namespace NEALibrarySystem.SearchList
{
    /// <summary>
    /// Handles the methods used in the search panel
    /// </summary>
    public class SearchHandler
    {
        public SearchObjects Objects;
        public ListViewSorting Sorting;

        // arrays used to store each features' column headers
        private static string[] _memberColumns;
        public static string[] BookColumns; //public so that circulation details panel can display a book in the same format as the search panel
        private static string[] CirculationCopyColumns;
        private static string[] _staffColumns;
        public SearchHandler(SearchObjects objects)
        {
            Sorting = new ListViewSorting();
            Objects = objects;
            // list view properties
            Objects.ItemViewer.View = View.Details;
            Objects.ItemViewer.LabelEdit = false;
            Objects.ItemViewer.AllowColumnReorder = false;
            Objects.ItemViewer.CheckBoxes = true;
            Objects.ItemViewer.MultiSelect = true;
            Objects.ItemViewer.FullRowSelect = true;
            Objects.ItemViewer.GridLines = false;
            Objects.ItemViewer.Sorting = SortOrder.None;
            Objects.ItemViewer.HeaderStyle = ColumnHeaderStyle.Clickable;
            Objects.ItemViewer.Scrollable = true;

            _memberColumns = new string[]
            {
                "Barcode",
                "First Name",
                "surname",
                "Member Type"
            };
            BookColumns = new string[]
            {
                "ISBN",
                "Title",
                "Series Title",
                "Media Type",
                "Author",
                "Publisher",
                "Genres",
                "Themes"
            };
            CirculationCopyColumns = new string[]
            {
                "ID",
                "Barcode",
                "Title",
                "Series Title",
                "Author",
                "Date",
                "Status",
                "Due Date",
                "Member Barcode"
            };
            _staffColumns = new string[]
            {
                "Firstname",
                "Surname",
                "Username"
            };
        }
        #region loading
        /// <summary>
        /// This method is used to set up the search tab with the appropiate search feature to display the correct information
        /// </summary>
        public void SetUpSearchTab()
        {
            // sets initial sorting method
            Sorting.SortedDescending = false;
            Sorting.CurrentColumn = 1;
            // opens the search view tab to the currently selected search feature
            switch (FrmMainSystem.Main.SearchFeature)
            {
                case SearchFeature.Book:
                    ToBook();
                    ListViewHandler.SortListView(ref Objects.ItemViewer, 0, ref Sorting, ListViewHandler.ColourListViewNormal);
                    break;
                case SearchFeature.Circulation:
                    ToCirculation();
                    ListViewHandler.SortListView(ref Objects.ItemViewer, 0, ref Sorting, ListViewHandler.ColourListViewOverdue);
                    break;
                case SearchFeature.Member:
                    ToMember();
                    ListViewHandler.SortListView(ref Objects.ItemViewer, 0, ref Sorting, ListViewHandler.ColourListViewNormal);
                    break;
                case SearchFeature.Staff:
                    ToStaff();
                    ListViewHandler.SortListView(ref Objects.ItemViewer, 0, ref Sorting, ListViewHandler.ColourListViewNormal);
                    break;
            }

            UpdateComboBoxes();
        }
        /// <summary>
        /// Sets up the search panel for displaying book records
        /// </summary>
        public void ToBook()
        {
            LoadColumns(ref Objects.ItemViewer, DataLibrary.SearchFeature.Book);
            Objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Books);
        }
        /// <summary>
        /// sets up the search panel for displaying circulation records
        /// </summary>
        public void ToCirculation()
        {
            LoadColumns(ref Objects.ItemViewer, DataLibrary.SearchFeature.Circulation);
            Objects.Delete.Visible = true;
            UpdateListView(DataLibrary.CirculationCopies);
        }
        /// <summary>
        /// sets up the search panel for displaying member records
        /// </summary>
        public void ToMember()
        {
            LoadColumns(ref Objects.ItemViewer, DataLibrary.SearchFeature.Member);
            Objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Members);
        }
        /// <summary>
        /// sets up the search panel for displaying staff records
        /// </summary>
        public void ToStaff()
        {
            LoadColumns(ref Objects.ItemViewer, DataLibrary.SearchFeature.Staff);

            if (DataLibrary.CurrentUser.IsAdministrator) // control whether user can delete records
                Objects.Delete.Visible = true;
            else
                Objects.Delete.Visible = false;

            UpdateListView(DataLibrary.StaffList);
        }
        /// <summary>
        /// Loads the current search feature's column headers
        /// </summary>
        /// <param name="lsv">Listview to add the columns to</param>
        /// <param name="feature">Search feature to specify which comlumn headers to add</param>
        private void LoadColumns(ref ListView lsv, DataLibrary.SearchFeature feature)
        {
            lsv.Clear();

            string[] columns = new string[0];
            switch (feature)
            {
                case DataLibrary.SearchFeature.Member:
                    columns = _memberColumns;
                    break;
                case DataLibrary.SearchFeature.Book:
                    columns = BookColumns;
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    columns = CirculationCopyColumns;
                    break;
                case DataLibrary.SearchFeature.Staff:
                    columns = _staffColumns;
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
        #endregion
        /// <summary>
        /// Finds the checked records in the list view and deletes them along with their dependencies
        /// </summary>
        public void Delete()
        {
            if (Objects.ItemViewer.CheckedItems.Count > 0)
            {
                // output a confirmation message

                string itemType = "";
                frmConfirmation confirmation;
                // get the type of item being deleted
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case DataLibrary.SearchFeature.Member:
                        if (Objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "member";
                        else
                            itemType = "members";
                        break;
                    case DataLibrary.SearchFeature.Book:
                        if (Objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "book";
                        else
                            itemType = "books";
                        break;
                    case DataLibrary.SearchFeature.Circulation:
                        if (Objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "loan/reservation";
                        else
                            itemType = "loans/reservations";
                        break;
                    case DataLibrary.SearchFeature.Staff:
                        itemType = "staff";
                        break;
                }
                // output the confirmation message
                if (Objects.ItemViewer.CheckedItems.Count == 1)
                    confirmation = new frmConfirmation($"Do you want do delete 1 {itemType} and its connections?", Color.Red, SystemColors.ControlLight);
                else
                    confirmation = new frmConfirmation($"Do you want do delete {Objects.ItemViewer.CheckedItems.Count} {itemType} and their connections?", Color.Red, SystemColors.ControlLight);
                confirmation.ShowDialog();

                // if user confirms deletion of selected records, delete each record that was checked
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case DataLibrary.SearchFeature.Member:
                            foreach (ListViewItem item in Objects.ItemViewer.CheckedItems)
                            {
                                DataLibrary.DeleteMember(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            }
                            UpdateListView(DataLibrary.Members);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case DataLibrary.SearchFeature.Book:
                            foreach (ListViewItem item in Objects.ItemViewer.CheckedItems)
                            {
                                DataLibrary.DeleteBook(DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            }
                            UpdateListView(DataLibrary.Books);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case DataLibrary.SearchFeature.Circulation:
                            foreach (ListViewItem item in Objects.ItemViewer.CheckedItems)
                            {
                                DataLibrary.DeleteCirculationCopy(DataLibrary.CirculationIds[SearchAndSort.Binary(DataLibrary.CirculationIds, Convert.ToInt32(item.SubItems[0].Text), SearchAndSort.RefClassAndInteger)].Reference);
                            }
                            UpdateListView(DataLibrary.CirculationCopies);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewOverdue);
                            break;
                        case DataLibrary.SearchFeature.Staff:
                            bool invalidStaff = false;
                            foreach (ListViewItem item in Objects.ItemViewer.CheckedItems)
                            {
                                if (DataLibrary.StaffUsernames[SearchAndSort.Binary(DataLibrary.StaffUsernames, item.SubItems[2].Text, SearchAndSort.RefClassAndString)].Reference == DataLibrary.CurrentUser)
                                {
                                    invalidStaff = true;
                                }
                            }
                            if (!invalidStaff)
                            {
                                foreach (ListViewItem item in Objects.ItemViewer.CheckedItems)
                                {
                                    DataLibrary.DeleteStaff(DataLibrary.StaffUsernames[SearchAndSort.Binary(DataLibrary.StaffUsernames, item.SubItems[2].Text, SearchAndSort.RefClassAndString)].Reference);
                                }
                                UpdateListView(DataLibrary.StaffList);
                                Sorting.SortedDescending = !Sorting.SortedDescending;
                                ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            }
                            else
                            {
                                MessageBox.Show("Error: Cannot delete your own staff record");
                            }
                            break;
                    }
                    MessageBox.Show($"Deleted {itemType}");
                }
            }
            else
                MessageBox.Show("No items selected");
        }
        /// <summary>
        /// Updates the comboboxes to contain the column headers of the current search feature. Needed for selecting a search category
        /// </summary>
        public void UpdateComboBoxes()
        {
            string[] columns = new string[0];
            switch (FrmMainSystem.Main.SearchFeature)
            {
                case SearchFeature.Member:
                    columns = _memberColumns;
                    break;
                case SearchFeature.Book:
                    columns = BookColumns;
                    break;
                case SearchFeature.Circulation:
                    columns = CirculationCopyColumns;
                    break;
                case SearchFeature.Staff:
                    columns = _staffColumns;
                    break;
            }
            Objects.SearchField.Items.Clear();
            Objects.SearchField.Items.Add("");
            Objects.SearchField.Items.AddRange(columns);
            Objects.Filter1Field.Items.Clear();
            Objects.Filter1Field.Items.Add("");
            Objects.Filter1Field.Items.AddRange(columns);
            Objects.Filter2Field.Items.Clear();
            Objects.Filter2Field.Items.Add("");
            Objects.Filter2Field.Items.AddRange(columns);
        }
        /// <summary>
        /// empties all search input fields
        /// </summary>
        public void ResetSearchInputs()
        {
            Objects.Search.Text = string.Empty;
            Objects.SearchField.Text = string.Empty;
            Objects.Filter1.Text = string.Empty;
            Objects.Filter1Field.Text = string.Empty;
            Objects.Filter2.Text = string.Empty;
            Objects.Filter2Field.Text = string.Empty;
        }
        #region UpdateListView
        /// <summary>
        /// Updates the search panel's list view with the inputted member list
        /// </summary>
        /// <param name="memberList">List of members to display in the list view</param>
        public void UpdateListView(List<Member> memberList)
        {
            Objects.ItemViewer.Items.Clear();
            if (memberList.Count > 0) 
            {
                foreach (Member member in memberList)
                {
                    string[] data = new string[4]
                    {
                    member.Barcode.Value,
                    member.FirstName.Value,
                    member.Surname.Value,
                    member.Type.Value.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    Objects.ItemViewer.Items.Add(row);
                }
                ListViewHandler.ResizeColumnHeaders(ref Objects.ItemViewer);
                ListViewHandler.ColourListViewNormal(ref Objects.ItemViewer);
            }
        }
        /// <summary>
        /// Updates the search panel's list view with the inputted book list
        /// </summary>
        /// <param name="bookList">List of books to display in the list view</param>
        public void UpdateListView(List<Book> bookList)
        {
            Objects.ItemViewer.Items.Clear();
            if (bookList.Count > 0)
            {
                foreach (Book book in bookList)
                {
                    string[] data =
                    {
                        book.Isbn.Value,
                        book.Title.Value,
                        book.SeriesTitle.Value,
                        book.MediaType.Value,
                        book.Author.Value,
                        book.Publisher.Value,
                        DataFormatter.ListToString(book.Genres),
                        DataFormatter.ListToString(book.Themes)
                    };
                    ListViewItem row = new ListViewItem(data);
                    Objects.ItemViewer.Items.Add(row);
                }
                ListViewHandler.ResizeColumnHeaders(ref Objects.ItemViewer);
                ListViewHandler.ColourListViewNormal(ref Objects.ItemViewer);
            }            
        }
        /// <summary>
        /// Updates the search panel's list view with the inputted ciculation list
        /// </summary>
        /// <param name="circulationCopyList">List of circulation records to display in the list</param>
        public void UpdateListView(List<CirculationCopy> circulationCopyList)
        {
            Objects.ItemViewer.Items.Clear();
            if (circulationCopyList.Count > 0)
            {
                foreach (CirculationCopy copy in circulationCopyList)
                {
                    string[] data =
                    {
                        copy.Id.Value.ToString(),
                        copy.BookCopy.Barcode.Value,
                        copy.BookCopy.Book.Title.Value,
                        copy.BookCopy.Book.SeriesTitle.Value,
                        copy.BookCopy.Book.Author.Value,
                        DataFormatter.GetDateAndTime(copy.Date.Value),
                        copy.Type.Value.ToString(),
                        DataFormatter.GetDate(copy.DueDate.Value),
                        copy.Member.Barcode.Value.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    Objects.ItemViewer.Items.Add(row);
                }
                ListViewHandler.ResizeColumnHeaders(ref Objects.ItemViewer);
                ListViewHandler.ColourListViewOverdue(ref Objects.ItemViewer);
            }
        }
        /// <summary>
        /// Updates the search panel's list view with the inputted staff list
        /// </summary>
        /// <param name="staffList">List of staff records to display in the list</param>
        public void UpdateListView(List<Staff> staffList)
        {
            Objects.ItemViewer.Items.Clear();
            if (staffList.Count > 0)
            {
                foreach (Staff staff in staffList)
                {
                    string[] data =
                    {
                        staff.FirstName.Value,
                        staff.Surname.Value,
                        staff.Username.Value
                    };
                    ListViewItem row = new ListViewItem(data);
                    Objects.ItemViewer.Items.Add(row);
                }
                ListViewHandler.ResizeColumnHeaders(ref Objects.ItemViewer);
                ListViewHandler.ColourListViewNormal(ref Objects.ItemViewer);
            }
        }
        #endregion
        #region searching
        /// <summary>
        /// Applies the search filters on the stored records
        /// </summary>
        public void Search()
        {
            // check if search inputs are valid
            switch (ValidateSearchFields())
            {
                case SearchError.FilterFields:
                    MessageBox.Show("Invalid Filter Categories");
                    break;
                case SearchError.SearchField:
                    MessageBox.Show("Invalid Search Category");
                    break;
                case SearchError.NoFields: // if no inputs in the search fields load all records
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case SearchFeature.Member:
                            UpdateListView(DataLibrary.Members);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case SearchFeature.Book:
                            UpdateListView(DataLibrary.Books);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case SearchFeature.Circulation:
                            UpdateListView(DataLibrary.CirculationCopies);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewOverdue);
                            break;
                        case SearchFeature.Staff:
                            UpdateListView(DataLibrary.StaffList);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                    }
                    break;
                case SearchError.None:
                    // place input fields in array in order to apply filters for each of them using iteration
                    SearchInputs[] searchInputs = new SearchInputs[3]
                    {
                        new SearchInputs(Objects.SearchField, Objects.Search),
                        new SearchInputs(Objects.Filter1Field, Objects.Filter1),
                        new SearchInputs(Objects.Filter2Field, Objects.Filter2)
                    };
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case SearchFeature.Member:
                            List<Member> members = DataLibrary.Members;
                            // for each search filter
                            for (int i = 0; i < searchInputs.Length; i++)
                            {
                                if (members.Count > 0)
                                {
                                    // check if filter category is used
                                    if (searchInputs[i].Category.Text != "")
                                    {
                                        /* Find which column the category is being specified as
                                         * Once found, create a reference class list containing all the reference classes for the specified property
                                         * Sort the list
                                         * Apply the filter to get the new filtered list of records
                                         */
                                        if (searchInputs[i].Category.Text == _memberColumns[0])
                                        {
                                            List<ReferenceClass<string, Member>> referenceClasses = new List<ReferenceClass<string, Member>>();
                                            foreach (Member member in members)
                                                referenceClasses.Add(member.Barcode);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(referenceClasses, SearchAndSort.TwoUpperRefClassMembers);
                                            members = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _memberColumns[1])
                                        {
                                            List<ReferenceClass<string, Member>> referenceClasses = new List<ReferenceClass<string, Member>>();
                                            foreach (Member member in members)
                                                referenceClasses.Add(member.FirstName);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(referenceClasses, SearchAndSort.TwoUpperRefClassMembers);
                                            members = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _memberColumns[2])
                                        {
                                            List<ReferenceClass<string, Member>> referenceClasses = new List<ReferenceClass<string, Member>>();
                                            foreach (Member member in members)
                                                referenceClasses.Add(member.Surname);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(referenceClasses, SearchAndSort.TwoUpperRefClassMembers);
                                            members = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _memberColumns[3])
                                        {
                                            List<ReferenceClass<string, Member>> referenceClasses = new List<ReferenceClass<string, Member>>();
                                            foreach (Member member in members)
                                                referenceClasses = CreateReferenceClass(referenceClasses, member, member.Type.ToString(), SearchAndSort.TwoRefClassMembers, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(referenceClasses, SearchAndSort.TwoUpperRefClassMembers);
                                            members = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else // if not, then perform a search on all properties
                                    {
                                        members = MemberSearch(searchInputs[i].SearchTerm.Text, members);
                                    }
                                }
                            }
                            UpdateListView(members);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case SearchFeature.Book:
                            List<Book> books = DataLibrary.Books;
                            // for each search filter
                            for (int i = 0; i < searchInputs.Length; i++)
                            {
                                if (books.Count > 0)
                                {
                                    // check if filter category is used
                                    if (searchInputs[i].Category.Text != "")
                                    {
                                        /* Find which column the category is being specified as
                                         * Once found, create a reference class list containing all the reference classes for the specified property
                                         * Sort the list
                                         * Apply the filter to get the new filtered list of records
                                         */
                                        if (searchInputs[i].Category.Text == BookColumns[0])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Isbn);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[1])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Title);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[2])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.SeriesTitle);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[3])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.MediaType);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[4])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Author);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[5])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Publisher);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[6])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.AddRange(book.Genres);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == BookColumns[7])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.AddRange(book.Themes);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else // if not, then perform a search on all properties
                                    {
                                        books = BookSearch(searchInputs[i].SearchTerm.Text, books);
                                    }
                                }

                            }
                            UpdateListView(books);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                        case SearchFeature.Circulation:
                            List<CirculationCopy> circulationCopies = DataLibrary.CirculationCopies;
                            for (int i = 0; i < searchInputs.Length; i++)
                            {
                                if (circulationCopies.Count > 0)
                                {
                                    // check if filter category is used
                                    if (searchInputs[i].Category.Text != "")
                                    {
                                        /* Find which column the category is being specified as
                                         * Once found, create a reference class list containing all the reference classes for the specified property
                                         * Sort the list
                                         * Apply the filter to get the new filtered list of records
                                         */
                                        if (searchInputs[i].Category.Text == CirculationCopyColumns[0])
                                        {

                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.IntToString(circulationCopy.Id.Value, CirculationCopy.IDMAXVALUE.ToString().Length), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies);
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[1])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[2])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.Book.Title.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[3])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.Book.SeriesTitle.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[4])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.Book.Author.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[5])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.GetDateAndTime(circulationCopy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[6])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, circulationCopy.Type.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoRefClassCircCopies);
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[7])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.GetDate(circulationCopy.DueDate.Value), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[8])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.Member.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else // if not, then perform a search on all properties
                                    {
                                        circulationCopies = CirculationSearch(searchInputs[i].SearchTerm.Text, circulationCopies);
                                    }
                                }
                            }
                            UpdateListView(circulationCopies);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewOverdue);
                            break;
                        case SearchFeature.Staff:
                            List<Staff> staffList = DataLibrary.StaffList;
                            for (int i = 0; i < searchInputs.Length; i++)
                            {
                                if (staffList.Count > 0)
                                {
                                    // check if filter category is used
                                    if (searchInputs[i].Category.Text != "")
                                    {
                                        /* Find which column the category is being specified as
                                         * Once found, create a reference class list containing all the reference classes for the specified property
                                         * Sort the list
                                         * Apply the filter to get the new filtered list of records
                                         */
                                        if (searchInputs[i].Category.Text == CirculationCopyColumns[0])
                                        {

                                            List<ReferenceClass<string, Staff>> referenceClasses = new List<ReferenceClass<string, Staff>>();
                                            foreach (Staff staff in staffList)
                                                referenceClasses.Add(staff.FirstName); 
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Staff>, ReferenceClass<string, Staff>>(referenceClasses, SearchAndSort.TwoUpperRefClassStaff);
                                            staffList = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[1])
                                        {
                                            List<ReferenceClass<string, Staff>> referenceClasses = new List<ReferenceClass<string, Staff>>();
                                            foreach (Staff staff in staffList)
                                                referenceClasses.Add(staff.Surname);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Staff>, ReferenceClass<string, Staff>>(referenceClasses, SearchAndSort.TwoUpperRefClassStaff);
                                            staffList = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == CirculationCopyColumns[1])
                                        {
                                            List<ReferenceClass<string, Staff>> referenceClasses = new List<ReferenceClass<string, Staff>>();
                                            foreach (Staff staff in staffList)
                                                referenceClasses.Add(staff.Username);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Staff>, ReferenceClass<string, Staff>>(referenceClasses, SearchAndSort.TwoUpperRefClassStaff);
                                            staffList = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else // if not, then perform a search on all properties
                                    {
                                        staffList = StaffSearch(searchInputs[i].SearchTerm.Text, staffList);
                                    }
                                }
                            }
                            UpdateListView(staffList);
                            Sorting.SortedDescending = !Sorting.SortedDescending;
                            ListViewHandler.SortListView(ref Objects.ItemViewer, Sorting.CurrentColumn, ref Sorting, ListViewHandler.ColourListViewNormal);
                            break;
                    }
                    break;
            }
        }
        /// <summary>
        /// Holds the objects used when searching for specific records
        /// </summary>
        private class SearchInputs
        {
            public ComboBox Category; // stores the combobox containing the specified category
            public TextBox SearchTerm; // stores the textbokx containing the searchterm
            public SearchInputs(ComboBox category, TextBox searchTerm)
            {
                Category = category;
                SearchTerm = searchTerm;
            }
        }
        /// <summary>
        /// Validates search input fields
        /// </summary>
        /// <returns>Enum representing any errors regarding the inputs</returns>
        private SearchError ValidateSearchFields()
        {
            // check if filter categories are valid
            if (!IsCategoryValid(Objects.Filter1Field) || !IsCategoryValid(Objects.Filter2Field))
                return SearchError.FilterFields;
            // check if search category is valid
            if (!IsCategoryValid(Objects.SearchField))
                return SearchError.SearchField;
            // check if no search filters are applied
            if (Objects.Search.Text == "" && Objects.Filter1.Text == "" && Objects.Filter2.Text == "")
                return SearchError.NoFields;
            return SearchError.None;
        }
        /// <summary>
        /// Checks whether the inputted category combobox's text is valid
        /// </summary>
        /// <param name="category">Combobox containing the selected category</param>
        /// <returns>Boolean result of if the category was valid</returns>
        private bool IsCategoryValid(ComboBox category)
        {
            if (category.Text != "")
                // check that the category matches a column of the current selected searchFeature. If it does not, return not valid, else return valid
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case SearchFeature.Member:
                        bool contains = false;
                        foreach (string column in _memberColumns)
                            if (column == category.Text)
                                contains = true;
                        if (!contains)
                            return false;
                        break;
                    case SearchFeature.Book:
                        contains = false;
                        foreach (string column in BookColumns)
                            if (column == category.Text)
                                contains = true;
                        if (!contains)
                            return false;
                        break;
                    case SearchFeature.Circulation:
                        contains = false;
                        foreach (string column in CirculationCopyColumns)
                            if (column == category.Text)
                                contains = true;
                        if (!contains)
                            return false;
                        break;
                }
            return true;
        }
        /// <summary>
        /// Represents any errors encountered during the validation process
        /// </summary>
        private enum SearchError
        {
            None,
            SearchField,
            FilterFields,
            NoFields
        }
        /// <summary>
        /// finds all references classes that contain the item in their value and outputs a list of their references
        /// </summary>
        /// <typeparam name="T">Value of reference class</typeparam>
        /// <typeparam name="F">Reference of reference class</typeparam>
        /// <param name="list">List of reference classes</param>
        /// <param name="item">Search item</param>
        /// <param name="compare">Algorithm to compare the search item to the values in the list of reference classes</param>
        /// <returns>List of references of the reference classes that contained the search item in their value</returns>
        public List<F> ApplyFilter<T, F>(List<ReferenceClass<T, F>> list, T item, SearchAndSort.Compare<T, ReferenceClass<T, F>> compare) where F : class
        {
            List<F> resultList = new List<F>();
            int[] bounds = SearchAndSort.BinaryRange(list, item, compare); // finds the range of values that match the search item
            if (bounds[0] != -1) // if there were items that matched the search term, add them to the result list
                for (int i = bounds[0]; i <= bounds[1]; i++)
                    resultList.Add(list[i].Reference);

            return resultList;
        }
        #region book
        /// <summary>
        /// Finds all books that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// For each property, get lists of books where the property matches the search term (case insensitive)
        /// Merge the lists of books for each property into a single list without any duplicate records
        /// 
        /// <param name="searchItem">Item to search for</param>
        /// <returns>List of books that match the search term</returns>
        private List<Book> BookSearch(string searchItem, List<Book> books)
        {
            List<ReferenceClass<string, Book>>[] attributeRefClasses = new List<ReferenceClass<string, Book>>[BookColumns.Length]; // stores lists of reference classes of the inputted books
            List<List<Book>> validBooks = new List<List<Book>>(); // stores the list of books that pass the filter for each property
            if (books.Count > 0)
            {
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = new List<ReferenceClass<string, Book>>();
                }
                // add each book's reference classes into the list of attributes
                foreach (Book book in books)
                {
                    int i = 0; // index of attribute list being used
                    attributeRefClasses[i++].Add(book.Isbn);
                    attributeRefClasses[i++].Add(book.Title);
                    attributeRefClasses[i++].Add(book.SeriesTitle);
                    attributeRefClasses[i++].Add(book.MediaType);
                    attributeRefClasses[i++].Add(book.Author);
                    attributeRefClasses[i++].Add(book.Publisher);
                    foreach (ReferenceClass<string, Book> genre in book.Genres)
                    {
                        attributeRefClasses[i].Add(genre);
                    }
                    i++;
                    foreach (ReferenceClass<string, Book> theme in book.Themes)
                    {
                        attributeRefClasses[i].Add(theme);
                    }
                }
                // for each attribute's list of reference classes, sort the list, apply the filter to get the valid books, sort the list of valid books, and add them to the list of valid books
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(attributeRefClasses[i], SearchAndSort.TwoUpperRefClassBooks);
                    validBooks.Add(SearchAndSort.QuickSort<Book, Book>(ApplyFilter(attributeRefClasses[i], searchItem, SearchAndSort.UpperRefClassStartsWithString), SearchAndSort.TwoBooks));
                }
                // merge lists of attributes into a single list without any duplicated records and return
                return MergeWithoutDuplicates(validBooks, SearchAndSort.TwoSmallestBooks);
            }
            else
                return new List<Book>();
        }

        #endregion
        #region member
        /// <summary>
        /// Finds all members that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// For each property, get lists of members where the property matches the search term (case insensitive)
        /// Merge the lists of members for each property into a single list without any duplicate records
        /// 
        /// <param name="item">Items to serach for</param>
        /// <returns>List of members that match the search term</returns>
        private List<Member> MemberSearch(string searchItem, List<Member> members)
        {
            List<ReferenceClass<string, Member>>[] attributeRefClasses = new List<ReferenceClass<string, Member>>[_memberColumns.Length]; // stores lists of reference classes of the inputted members
            List<List<Member>> validMembers = new List<List<Member>>(); // stores the list of members that pass the filter for each property

            if (members.Count > 0)
            {
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = new List<ReferenceClass<string, Member>>();
                }
                // add each book's reference classes into the list of attributes
                foreach (Member member in members)
                {
                    int i = 0; // index of attribute list being used
                    attributeRefClasses[i++].Add(member.Barcode);
                    attributeRefClasses[i++].Add(member.FirstName);
                    attributeRefClasses[i++].Add(member.Surname);
                    attributeRefClasses[i] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], member, member.Type.Value.ToString(), SearchAndSort.TwoRefClassMembers, out int index);
                }
                // for each attribute's list of reference classes, sort the list, apply the filter to get the valid members, sort the list of valid members, and add them to the list of valid members
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(attributeRefClasses[i], SearchAndSort.TwoUpperRefClassMembers);
                    validMembers.Add(SearchAndSort.QuickSort<Member, Member>(ApplyFilter(attributeRefClasses[i], searchItem, SearchAndSort.UpperRefClassStartsWithString), SearchAndSort.TwoMembers));
                }
                // merge lists of attributes into a single list without any duplicated records and return
                return MergeWithoutDuplicates(validMembers, SearchAndSort.TwoSmallestMembers);
            }
            else
                return new List<Member>();
        }
        #endregion
        #region circulation
        /// <summary>
        /// Finds all circulation copies that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// For each property, get lists of circulation copies where the property matches the search term (case insensitive)
        /// Merge the lists of circulation copies for each property into a single list without any duplicate records
        /// 
        /// <param name="searchItem">Items to search for</param>
        /// <returns>List of circulation copies that match the search term</returns>
        private List<CirculationCopy> CirculationSearch(string searchItem, List<CirculationCopy> circulationCopies)
        {
            List<ReferenceClass<string, CirculationCopy>>[] attributeRefClasses = new List<ReferenceClass<string, CirculationCopy>>[CirculationCopyColumns.Length]; // stores lists of reference classes of the inputted circulation copies
            List<List<CirculationCopy>> validCirculationCopies = new List<List<CirculationCopy>>(); // stores the list of circulation copies that pass the filter for each property

            if (circulationCopies.Count > 0)
            {
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = new List<ReferenceClass<string, CirculationCopy>>();
                }
                // add each circulation copy's reference classes into the list of attributes
                foreach (CirculationCopy copy in circulationCopies)
                {
                    int i = 0; // index of attribute list being used
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.Id.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out int index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.BookCopy.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.BookCopy.Book.Title.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.BookCopy.Book.SeriesTitle.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.BookCopy.Book.Author.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.Member.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, DataFormatter.GetDateAndTime(copy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i++] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, DataFormatter.GetDate(copy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out index);
                    attributeRefClasses[i] = DataLibrary.CreateReferenceClass(attributeRefClasses[i], copy, copy.Type.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out index);
                }
                // for each attribute's list of reference classes, sort the list, apply the filter to get the valid circulation copies, sort the list of valid circulation copies, and add them to the list of valid circulation copies
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(attributeRefClasses[i], SearchAndSort.TwoUpperRefClassCircCopies);
                    validCirculationCopies.Add(SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(ApplyFilter(attributeRefClasses[i], searchItem, SearchAndSort.UpperRefClassStartsWithString), SearchAndSort.TwoCircCopies));
                }
                // merge lists of attributes into a single list without any duplicated records and return
                return MergeWithoutDuplicates(validCirculationCopies, SearchAndSort.TwoSmallestCircCopies);
            }
            else
                return new List<CirculationCopy>();
        }
        #endregion
        #region staff
        /// <summary>
        /// Finds all members that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// For each property, get lists of members where the property matches the search term (case insensitive)
        /// Merge the lists of members for each property into a single list without any duplicate records
        /// 
        /// <param name="item">Items to serach for</param>
        /// <returns>List of members that match the search term</returns>
        private List<Staff> StaffSearch(string searchItem, List<Staff> staffList)
        {
            List<ReferenceClass<string, Staff>>[] attributeRefClasses = new List<ReferenceClass<string, Staff>>[_staffColumns.Length]; // stores lists of reference classes of the inputted members
            List<List<Staff>> validStaffList = new List<List<Staff>>(); // stores the list of members that pass the filter for each property

            if (staffList.Count > 0)
            {
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = new List<ReferenceClass<string, Staff>>();
                }
                // add each book's reference classes into the list of attributes
                foreach (Staff staff in staffList)
                {
                    int i = 0; // index of attribute list being used
                    attributeRefClasses[i++].Add(staff.FirstName);
                    attributeRefClasses[i++].Add(staff.Surname);
                    attributeRefClasses[i++].Add(staff.Username);
                }
                // for each attribute's list of reference classes, sort the list, apply the filter to get the valid members, sort the list of valid members, and add them to the list of valid members
                for (int i = 0; i < attributeRefClasses.Length; i++)
                {
                    attributeRefClasses[i] = SearchAndSort.QuickSort<ReferenceClass<string, Staff>, ReferenceClass<string, Staff>>(attributeRefClasses[i], SearchAndSort.TwoUpperRefClassStaff);
                    validStaffList.Add(SearchAndSort.QuickSort<Staff, Staff>(ApplyFilter(attributeRefClasses[i], searchItem, SearchAndSort.UpperRefClassStartsWithString), SearchAndSort.TwoStaff));
                }
                // merge lists of attributes into a single list without any duplicated records and return
                return MergeWithoutDuplicates(validStaffList, SearchAndSort.TwoSmallestStaff);
            }
            else
                return new List<Staff>();
        }
        #endregion
        /// <summary>
        /// Get the index of the smallest book in the list
        /// </summary>
        /// <param name="list">List of book and the column they each belong to</param>
        /// <returns>Index of the smallest member</returns>
        private int GetSmallest<T>(List<SmallestItem<T>> list, SearchAndSort.Compare<SmallestItem<T>, SmallestItem<T>> compare) where T : class
        {
            int smallest = 0;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (compare(list[i], list[smallest]) == Greatest.Right) // if the list[i] is smaller than the current smallest item, set the smallest to the current index
                        smallest = i;
                }
                return smallest;
            }
            return -1;
        }
        /// <summary>
        /// Merges a list of lists into a single list of unique records
        /// </summary>
        /// <typeparam name="T">Type of class within each list</typeparam>
        /// <param name="list">List of lists that need to be merged</param>
        /// <param name="compare">Algorithm used to compare each list's smallest items with each other</param>
        /// <returns></returns>
        private List<T> MergeWithoutDuplicates<T>(List<List<T>> list, SearchAndSort.Compare<SmallestItem<T>, SmallestItem<T>> compare) where T : class
        {
            List<T> results = new List<T>();
            bool finished = false;
            do
            {
                List<SmallestItem<T>> smallestItems = new List<SmallestItem<T>>();
                // Get the first(smallest) book in each list
                for (int i = 0; i < list.Count; i++)
                    if (list[i].Count > 0)
                        smallestItems.Add(new SmallestItem<T>(list[i][0], i));
                if (smallestItems.Count > 0)
                {
                    int smallestIndex = GetSmallest(smallestItems, compare);

                    // Find the smallest book out of all of the list based on the ISBN
                    if (smallestIndex != -1)
                    {
                        // check if item has already been added
                        if (results.Count > 0)
                        {
                            if (smallestItems[smallestIndex].Item != results[results.Count - 1])
                                results.Add(smallestItems[smallestIndex].Item);
                        }
                        else
                            results.Add(smallestItems[smallestIndex].Item);
                        // remove added item from its previous list
                        list[smallestItems[smallestIndex].Index].RemoveAt(0);
                    }
                }
                else
                    finished = true;
            } while (!finished);
            return results;
        }
        #endregion
    }
}