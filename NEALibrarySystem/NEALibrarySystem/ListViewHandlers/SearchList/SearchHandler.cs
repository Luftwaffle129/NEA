using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using NEALibrarySystem.ListViewHandlers.SearchList;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static NEALibrarySystem.Data_Structures.DataLibrary;

namespace NEALibrarySystem.SearchList
{
    public class SearchHandler
    {
        private SearchObjects _objects;

        private int _currentColumn;
        private bool _invertedSort = false;
        private static string[] _memberColumns;
        private static string[] _bookColumns;
        private static string[] _circulationCopyColumns;
        public SearchHandler(SearchObjects objects)
        {
            _objects = objects;
            _objects.ItemViewer.View = View.Details;
            _objects.ItemViewer.LabelEdit = false;
            _objects.ItemViewer.AllowColumnReorder = false;
            _objects.ItemViewer.CheckBoxes = true;
            _objects.ItemViewer.MultiSelect = true;
            _objects.ItemViewer.FullRowSelect = true;
            _objects.ItemViewer.GridLines = false;
            _objects.ItemViewer.Sorting = SortOrder.None;
            _objects.ItemViewer.HeaderStyle = ColumnHeaderStyle.Clickable;
            _objects.ItemViewer.Scrollable = true;

            _memberColumns = new string[]
            {
                "Barcode",
                "First Name",
                "surname",
                "Member Type"
            };
            _bookColumns = new string[]
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
            _circulationCopyColumns = new string[]
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
        }
        #region loading
        public void SetUpSearchTab()
        {
            _invertedSort = false;
            switch (FrmMainSystem.Main.SearchFeature)
            {
                case SearchFeature.Book:
                    ToBook();
                    break;
                case SearchFeature.Circulation:
                    ToCirculation();
                    break;
                case SearchFeature.Member:
                    ToMember();
                    break;
                case SearchFeature.Staff:

                    break;
            }
            UpdateComboBoxes();
        }
        public void ToBook()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Book);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Books);
        }
        public void ToCirculation()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Circulation);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.CirculationCopies);
        }
        public void ToMember()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Member);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Members);
        }
        public static void LoadColumns(ref ListView lsv, DataLibrary.SearchFeature feature)
        {
            lsv.Clear();

            string[] columns = new string[0];
            switch (feature)
            {
                case DataLibrary.SearchFeature.Member:
                    columns = _memberColumns;
                    break;
                case DataLibrary.SearchFeature.Book:
                    columns = _bookColumns;
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    columns = _circulationCopyColumns;
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
        #endregion
        public void Delete()
        {
            if (_objects.ItemViewer.CheckedItems.Count > 0)
            {
                // output a confirmation message
                string itemType = "";
                frmConfirmation confirmation;
                // get the type of item being deleted
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case DataLibrary.SearchFeature.Member:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "member";
                        else
                            itemType = "members";
                        break;
                    case DataLibrary.SearchFeature.Book:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "book";
                        else
                            itemType = "books";
                        break;
                    case DataLibrary.SearchFeature.Circulation:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "loan/reservation";
                        else
                            itemType = "loans/reservations";
                        break;
                    case DataLibrary.SearchFeature.Staff:
                        itemType = "staff";
                        break;
                }
                // output the confirmation message
                if (_objects.ItemViewer.CheckedItems.Count == 1)
                    confirmation = new frmConfirmation($"Do you want do delete 1 {itemType}?");
                else
                    confirmation = new frmConfirmation($"Do you want do delete {_objects.ItemViewer.CheckedItems.Count} {itemType}?");
                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case DataLibrary.SearchFeature.Member:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteMember(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Book:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteBook(DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Circulation:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteCirculationCopy(DataLibrary.CirculationDates[SearchAndSort.Binary(DataLibrary.CirculationDates, Convert.ToDateTime(item.SubItems[4].Text), SearchAndSort.RefClassAndDate)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Staff:
                            break;
                    }
                    FrmMainSystem.Main.DisplayProcessMessage($"Deleted {itemType}");
                    ToBook();
                }
            }
            else
                MessageBox.Show("No items selected");
        }

        public void UpdateComboBoxes()
        {
            switch (FrmMainSystem.Main.SearchFeature)
            {
                case SearchFeature.Member:
                    _objects.SearchField.Items.Clear();
                    _objects.SearchField.Items.AddRange(_memberColumns);
                    _objects.Filter1Field.Items.Clear();
                    _objects.Filter1Field.Items.AddRange(_memberColumns);
                    _objects.Filter2Field.Items.Clear();
                    _objects.Filter2Field.Items.AddRange(_memberColumns);
                    break;
                case SearchFeature.Book:
                    _objects.SearchField.Items.Clear();
                    _objects.SearchField.Items.AddRange(_bookColumns);
                    _objects.Filter1Field.Items.Clear();
                    _objects.Filter1Field.Items.AddRange(_bookColumns);
                    _objects.Filter2Field.Items.Clear();
                    _objects.Filter2Field.Items.AddRange(_bookColumns);
                    break;
                case SearchFeature.Circulation:
                    _objects.SearchField.Items.Clear();
                    _objects.SearchField.Items.AddRange(_circulationCopyColumns);
                    _objects.Filter1Field.Items.Clear();
                    _objects.Filter1Field.Items.AddRange(_circulationCopyColumns);
                    _objects.Filter2Field.Items.Clear();
                    _objects.Filter2Field.Items.AddRange(_circulationCopyColumns);
                    break;
            }
        }
        public void ResetSearchInputs()
        {
            _objects.Search.Text = string.Empty;
            _objects.SearchField.Text = string.Empty;
            _objects.Filter1.Text = string.Empty;
            _objects.Filter1Field.Text = string.Empty;
            _objects.Filter2.Text = string.Empty;
            _objects.Filter2Field.Text = string.Empty;
        }
        #region UpdateListView
        public void UpdateListView(List<Member> memberList)
        {
            _objects.ItemViewer.Items.Clear();
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
                    _objects.ItemViewer.Items.Add(row);
                }
                _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        public void UpdateListView(List<Book> bookList)
        {
            _objects.ItemViewer.Items.Clear();
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
                    _objects.ItemViewer.Items.Add(row);
                }
                _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }            
        }
        public void UpdateListView(List<CirculationCopy> circulationCopyList)
        {
            _objects.ItemViewer.Items.Clear();
            if (circulationCopyList.Count > 0)
            {
                foreach (CirculationCopy copy in circulationCopyList)
                {
                    string[] data =
                    {
                        copy.Id.Value.ToString(),
                        copy.BookCopy.Barcode.Value,
                        copy.BookCopy.BookRelation.Book.Title.Value,
                        copy.BookCopy.BookRelation.Book.SeriesTitle.Value,
                        copy.BookCopy.BookRelation.Book.Author.Value,
                        DataFormatter.GetDateAndTime(copy.Date.Value),
                        copy.Type.Value.ToString(),
                        DataFormatter.GetDate(copy.DueDate.Value),
                        copy.CircMemberRelation.Member.Barcode.Value.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    _objects.ItemViewer.Items.Add(row);
                }
                _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
                case SearchError.NoFields:
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case SearchFeature.Member:
                            UpdateListView(DataLibrary.Members);
                            break;
                        case SearchFeature.Book:
                            UpdateListView(DataLibrary.Books);
                            break;
                        case SearchFeature.Circulation:
                            UpdateListView(DataLibrary.CirculationCopies);
                            break;
                    }
                    break;
                case SearchError.None:
                    // place input fields in array to apply filters for each of them using iteration
                    SearchInputs[] searchInputs = new SearchInputs[3]
                    {
                        new SearchInputs(_objects.SearchField, _objects.Search),
                        new SearchInputs(_objects.Filter1Field, _objects.Filter1),
                        new SearchInputs(_objects.Filter2Field, _objects.Filter2)
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
                                    else if (i == 0) // if not, then perform a search on all properties if it is the first search term
                                    {
                                        members = MemberSearch(_objects.Search.Text);
                                    }
                                }
                            }
                            UpdateListView(members);
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
                                        if (searchInputs[i].Category.Text == _bookColumns[0])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Isbn);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[1])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Title);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[2])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.SeriesTitle);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[3])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.MediaType);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[4])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Author);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[5])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.Add(book.Publisher);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[6])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.AddRange(book.Genres);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _bookColumns[7])
                                        {
                                            List<ReferenceClass<string, Book>> referenceClasses = new List<ReferenceClass<string, Book>>();
                                            foreach (Book book in books)
                                                referenceClasses.AddRange(book.Themes);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(referenceClasses, SearchAndSort.TwoUpperRefClassBooks);
                                            books = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else if (i == 0) // if not, then perform a search on all properties if it is the first search term
                                    {
                                        books = BookSearch(_objects.Search.Text);
                                    }
                                }

                            }
                            UpdateListView(books);
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
                                        if (searchInputs[i].Category.Text == _circulationCopyColumns[0])
                                        {

                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.IntToString(circulationCopy.Id.Value, CirculationCopy.IdMaxValue.ToString().Length), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies);
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[1])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[2])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.BookRelation.Book.Title.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[3])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.BookRelation.Book.SeriesTitle.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[4])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.BookCopy.BookRelation.Book.Author.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[5])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.GetDateAndTime(circulationCopy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[6])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, circulationCopy.Type.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoRefClassCircCopies);
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[7])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass(referenceClasses, circulationCopy, DataFormatter.GetDate(circulationCopy.DueDate.Value), SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                        else if (searchInputs[i].Category.Text == _circulationCopyColumns[8])
                                        {
                                            List<ReferenceClass<string, CirculationCopy>> referenceClasses = new List<ReferenceClass<string, CirculationCopy>>();
                                            foreach (CirculationCopy circulationCopy in circulationCopies)
                                                referenceClasses = DataLibrary.CreateReferenceClass<string, CirculationCopy>(referenceClasses, circulationCopy, circulationCopy.CircMemberRelation.Member.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out int index);
                                            referenceClasses = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(referenceClasses, SearchAndSort.TwoUpperRefClassCircCopies); 
                                            circulationCopies = ApplyFilter(referenceClasses, searchInputs[i].SearchTerm.Text, SearchAndSort.UpperRefClassStartsWithString);
                                        }
                                    }
                                    else if (i == 0) // if not, then perform a search on all properties if it is the first search term
                                    {
                                        circulationCopies = CirculationSearch(_objects.Search.Text);
                                    }
                                }
                            }
                            UpdateListView(circulationCopies);
                            break;
                    }
                    break;
            }
        }
        private class SearchInputs
        {
            public ComboBox Category;
            public TextBox SearchTerm;
            public SearchInputs(ComboBox category, TextBox searchTerm)
            {
                Category = category;
                SearchTerm = searchTerm;
            }
        }
        private SearchError ValidateSearchFields()
        {
            // check if filter1 inputs are valid

            // check if filter 1 is used
            if (_objects.Filter1.Text != "")
                // check that a valid category is specified for the selected searchFeature
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case SearchFeature.Member:
                        bool contains = false;
                        foreach (string column in _memberColumns)
                            if (column == _objects.Filter1Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                    case SearchFeature.Book:
                        contains = false;
                        foreach (string column in _bookColumns)
                            if (column == _objects.Filter1Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                    case SearchFeature.Circulation:
                        contains = false;
                        foreach (string column in _circulationCopyColumns)
                            if (column == _objects.Filter1Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                }
            // check if filter2 inputs are valid

            // check if filter 2 is used
            if (_objects.Filter2.Text != "")
                // check that a valid category is specified for the selected searchFeature
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case SearchFeature.Member:
                        bool contains = false;
                        foreach (string column in _memberColumns)
                            if (column == _objects.Filter2Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                    case SearchFeature.Book:
                        contains = false;
                        foreach (string column in _bookColumns)
                            if (column == _objects.Filter2Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                    case SearchFeature.Circulation:
                        contains = false;
                        foreach (string column in _circulationCopyColumns)
                            if (column == _objects.Filter2Field.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.FilterFields;
                        break;
                }
            // check if search field input is valid

            // check if search is used
            if (_objects.SearchField.Text != "")
                // check that a valid category is specified for the selected searchFeature
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case SearchFeature.Member:
                        bool contains = false;
                        foreach (string column in _memberColumns)
                            if (column == _objects.SearchField.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.SearchField;
                        break;
                    case SearchFeature.Book:
                        contains = false;
                        foreach (string column in _bookColumns)
                            if (column == _objects.SearchField.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.SearchField;
                        break;
                    case SearchFeature.Circulation:
                        contains = false;
                        foreach (string column in _circulationCopyColumns)
                            if (column == _objects.SearchField.Text)
                                contains = true;
                        if (!contains)
                            return SearchError.SearchField;
                        break;
                }
            // check if no search filters are applied
            if (_objects.Search.Text == "" && _objects.Filter1.Text == "" && _objects.Filter2.Text == "")
                return SearchError.NoFields;
            return SearchError.None;
        }
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
            int[] bounds = SearchAndSort.BinaryRange(list, item, compare);
            if (bounds[0] != -1)
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
        /// Get lists of valid books for each property
        /// Add all properties lists into a single list without any duplicate records
        /// 
        /// <param name="item">items to </param>
        /// <returns>List of books that match the search term</returns>
        private List<Book> BookSearch(string item)
        {
            // Get lists of valid books for each property

            List<Book> isbns = ApplyFilter(DataLibrary.Isbns, item, SearchAndSort.UpperRefClassStartsWithString);
            isbns = SearchAndSort.QuickSort<Book, Book>(isbns, SearchAndSort.TwoBooks);
            // Below are the steps performed on each property below to get a list of valid books for each property:
            // gets an ordered list of the reference class property which is case insensitive
            List<ReferenceClass<string, Book>> titleRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.Titles, SearchAndSort.TwoUpperRefClassBooks);
            // get the list of books that are valid under the filter
            List<Book> titles = ApplyFilter(titleRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            // sort them based on their reference
            titles = SearchAndSort.QuickSort<Book, Book>(titles, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> seriesTitleRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.SeriesTitles, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> seriesTitles = ApplyFilter(seriesTitleRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            seriesTitles = SearchAndSort.QuickSort<Book, Book>(seriesTitles, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> mediaTypeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.MediaTypes, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> mediaTypes = ApplyFilter(mediaTypeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            mediaTypes = SearchAndSort.QuickSort<Book, Book>(mediaTypes, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> authorRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.Authors, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> authors = ApplyFilter(authorRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            authors = SearchAndSort.QuickSort<Book, Book>(authors, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> publisherRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.Publishers, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> publishers = ApplyFilter(publisherRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            publishers = SearchAndSort.QuickSort<Book, Book>(publishers, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> genreRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.Genres, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> genres = ApplyFilter(genreRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            genres = SearchAndSort.QuickSort<Book, Book>(genres, SearchAndSort.TwoBooks);
            List<ReferenceClass<string, Book>> themeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Book>, ReferenceClass<string, Book>>(DataLibrary.Themes, SearchAndSort.TwoUpperRefClassBooks);
            List<Book> themes = ApplyFilter(themeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            themes = SearchAndSort.QuickSort<Book, Book>(themes, SearchAndSort.TwoBooks);

            List<List<Book>> columnTypes =new List<List<Book>>
            {
                isbns,
                titles,
                seriesTitles,
                mediaTypes,
                authors, 
                publishers, 
                genres, 
                themes
            };
            return MergeWithoutDuplicates(columnTypes, SearchAndSort.TwoSmallestBooks);
        }

        #endregion
        #region member
        /// <summary>
        /// Finds all members that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// Get lists of valid members for each property
        /// Add all properties lists into a single list without any duplicate records
        /// 
        /// <param name="item">items to </param>
        /// <returns>List of members that match the search term</returns>
        private List<Member> MemberSearch(string item)
        {
            // Get lists of valid members for each property
            List<Member> barcodes = ApplyFilter(DataLibrary.MemberBarcodes, item, SearchAndSort.UpperRefClassStartsWithString);
            barcodes = SearchAndSort.QuickSort<Member, Member>(barcodes, SearchAndSort.TwoMembers);
            List<ReferenceClass<string, Member>> firstNameRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(DataLibrary.FirstNames, SearchAndSort.TwoUpperRefClassMembers);
            List<Member> firstNames = ApplyFilter(firstNameRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            firstNames = SearchAndSort.QuickSort<Member, Member>(firstNames, SearchAndSort.TwoMembers);

            List<ReferenceClass<string, Member>> surameRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(DataLibrary.Surnames, SearchAndSort.TwoUpperRefClassMembers);
            List<Member> surnames = ApplyFilter(surameRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            surnames = SearchAndSort.QuickSort<Member, Member>(surnames, SearchAndSort.TwoMembers);

            List<ReferenceClass<string, Member>> memberTypeRefClassList = new List<ReferenceClass<string, Member>>();
            foreach (Member member in DataLibrary.Members)
                memberTypeRefClassList = CreateReferenceClass(memberTypeRefClassList, member, member.Type.ToString(), SearchAndSort.TwoRefClassMembers, out int index);
            memberTypeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, Member>, ReferenceClass<string, Member>>(memberTypeRefClassList, SearchAndSort.TwoUpperRefClassMembers);
            List<Member> memberTypes = ApplyFilter(memberTypeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);

            List<List<Member>> properties = new List<List<Member>>
            {
                barcodes, 
                firstNames, 
                surnames, 
                memberTypes
            };
            return MergeWithoutDuplicates(properties, SearchAndSort.TwoSmallestMembers);
        }
        #endregion
        #region circulation
        /// <summary>
        /// Finds all circulation copies that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// Get lists of valid circulation copies for each property
        /// Add all properties lists into a single list without any duplicate records
        /// 
        /// <param name="item">items to </param>
        /// <returns>List of circulation copies that match the search term</returns>
        private List<CirculationCopy> CirculationSearch(string item)
        {
            // Get lists of valid circulation copies for each property
            List<ReferenceClass<string, CirculationCopy>> idRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> bookBarcodeRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> titleRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> seriesTitleRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> authorRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> memberBarcodeRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> dateRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> dueDateRefClassList = new List<ReferenceClass<string, CirculationCopy>>();
            List<ReferenceClass<string, CirculationCopy>> circulationTypeRefClassList = new List<ReferenceClass<string, CirculationCopy>>();

            if (DataLibrary.CirculationCopies.Count > 0)
                foreach (CirculationCopy copy in DataLibrary.CirculationCopies)
                {
                    idRefClassList = DataLibrary.CreateReferenceClass(idRefClassList, copy, copy.Id.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out int index);
                    bookBarcodeRefClassList = DataLibrary.CreateReferenceClass(bookBarcodeRefClassList, copy, copy.BookCopy.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    titleRefClassList = DataLibrary.CreateReferenceClass(titleRefClassList, copy, copy.BookCopy.BookRelation.Book.Title.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    seriesTitleRefClassList = DataLibrary.CreateReferenceClass(seriesTitleRefClassList, copy, copy.BookCopy.BookRelation.Book.SeriesTitle.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    authorRefClassList = DataLibrary.CreateReferenceClass(authorRefClassList, copy, copy.BookCopy.BookRelation.Book.Author.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    memberBarcodeRefClassList = DataLibrary.CreateReferenceClass(memberBarcodeRefClassList, copy, copy.CircMemberRelation.Member.Barcode.Value, SearchAndSort.TwoRefClassCircCopies, out index);
                    dateRefClassList = DataLibrary.CreateReferenceClass(dateRefClassList, copy, DataFormatter.GetDateAndTime(copy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out index);
                    dueDateRefClassList = DataLibrary.CreateReferenceClass(dueDateRefClassList, copy, DataFormatter.GetDate(copy.Date.Value), SearchAndSort.TwoRefClassCircCopies, out index);
                    circulationTypeRefClassList = DataLibrary.CreateReferenceClass(circulationTypeRefClassList, copy, copy.Type.Value.ToString(), SearchAndSort.TwoRefClassCircCopies, out index);
                }
            idRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(idRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            bookBarcodeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(bookBarcodeRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            titleRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(titleRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            seriesTitleRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(seriesTitleRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            authorRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(authorRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            memberBarcodeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(memberBarcodeRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            dateRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(dateRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            dueDateRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(dueDateRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);
            circulationTypeRefClassList = SearchAndSort.QuickSort<ReferenceClass<string, CirculationCopy>, ReferenceClass<string, CirculationCopy>>(circulationTypeRefClassList, SearchAndSort.TwoUpperRefClassCircCopies);

            List<CirculationCopy> ids = ApplyFilter(bookBarcodeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            ids = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(ids, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> bookBarcodes = ApplyFilter(bookBarcodeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            bookBarcodes = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(bookBarcodes, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> titles = ApplyFilter(titleRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            titles = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(titles, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> seriesTitles = ApplyFilter(seriesTitleRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            seriesTitles = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(seriesTitles, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> authors = ApplyFilter(authorRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            authors = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(authors, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> dates = ApplyFilter(dateRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            dates = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(dates, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> dueDates = ApplyFilter(dueDateRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            dueDates = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(dueDates, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> memberBarcodes = ApplyFilter(memberBarcodeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            memberBarcodes = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(memberBarcodes, SearchAndSort.TwoCircCopies);
            List<CirculationCopy> circulationTypes = ApplyFilter(circulationTypeRefClassList, item, SearchAndSort.UpperRefClassStartsWithString);
            circulationTypes = SearchAndSort.QuickSort<CirculationCopy, CirculationCopy>(circulationTypes, SearchAndSort.TwoCircCopies);

            List<List<CirculationCopy>> properties = new List<List<CirculationCopy>>
            {
                ids,
                bookBarcodes,
                titles,
                seriesTitles,
                authors,
                dates,
                circulationTypes,
                dueDates,
                memberBarcodes
            };
            return MergeWithoutDuplicates(properties, SearchAndSort.TwoSmallestCircCopies);
        }
        #endregion
        /// <summary>
        /// Get the index of the smallest book in the list
        /// </summary>
        /// <param name="list">list of book and the column they each belong to</param>
        /// <returns>index of the smallest member</returns>
        private int GetSmallest<T>(List<SmallestItem<T>> list, SearchAndSort.Compare<SmallestItem<T>, SmallestItem<T>> compare) where T : class
        {
            int smallest = 0;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (compare(list[i], list[smallest]) == Greatest.Right)
                        smallest = i;
                }
                return smallest;
            }
            return -1;
        }
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
        #region sorting
        public void SortListView(int column)
        {
            if (_currentColumn == column)
                _invertedSort = _invertedSort ? false : true; // inverts the boolean variable
            else
            {
                _currentColumn = column;
                _invertedSort = false;
            }
            ListViewHandler.SortListViewItems(ref _objects.ItemViewer, column, _invertedSort);
        }
        #endregion
    }
}