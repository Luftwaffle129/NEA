using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem.PanelHandlers
{
    /// <summary>
    /// Used to handle processes of the book details panel in the main form
    /// </summary>
    public class BookDetailsHandler
    {
        public BookDetailsObjects Objects;
        private Book _bookData; // if modifying a book record, stores the data of the existing book
        private List<TempBookCopy> _bookCopyList = new List<TempBookCopy>(); // list of temporary book copies. Used to make temporary changes to a book record's book copies before saving to allow for discarding the changes
        public ListViewSortingData ListViewSortingData;
        private bool _isNewRecord; // whether the book detail panel is being used to create a new book record or modify an existing one
        public BookDetailsHandler(BookDetailsObjects objs) 
        {
            ListViewSortingData = new ListViewSortingData();
            Objects = objs;
            _bookData = new Book();
            InitialiseCopyDetails();
        }
        /// <summary>
        /// Loads the book details into the input boxes if modifying a book. Empties the input fields if creating a new book
        /// </summary>
        /// <param name="book">Book to be modified. null if creating a new book</param>
        public void Load(Book book = null)
        {
            //book details
            if (book != null) // if book is not null, fill input fields with the existing book data
            {
                _bookData = book;
                Objects.Title.Text = _bookData.Title.Value;
                Objects.SeriesTitle.Text = _bookData.SeriesTitle.Value;
                Objects.SeriesNumber.Text = _bookData.SeriesNumber.ToString();
                Objects.Isbn.Text = _bookData.Isbn.Value;
                Objects.MediaType.Text = _bookData.MediaType.Value;
                Objects.Author.Text = _bookData.Author.Value;
                Objects.Publisher.Text = _bookData.Publisher.Value;
                Objects.Genres.Text = DataFormatter.ListToString(_bookData.Genres);
                Objects.Themes.Text = DataFormatter.ListToString(_bookData.Themes);
                Objects.Description.Text = _bookData.Description;
                Objects.Price.Text = DataFormatter.DoubleToPrice(_bookData.Price.Value);
                _isNewRecord = false;
                Objects.BookCopyStatus.Visible = true;
            }
            else // if book is null, set input fields to be empty
            {
                _bookData = new Book();
                Objects.Title.Clear();
                Objects.SeriesTitle.Clear();
                Objects.SeriesNumber.Clear();
                Objects.Isbn.Clear();
                Objects.MediaType.Clear();
                Objects.Author.Clear();
                Objects.Publisher.Clear();
                Objects.Genres.Clear();
                Objects.Themes.Clear();
                Objects.Description.Clear();
                Objects.Price.Clear();
                _isNewRecord = true;
                Objects.BookCopyStatus.Visible = false;
            }
            InitialiseCopyDetails();
            LoadCopyDetails();
        }
        #region Book Copies
        /// <summary>
        /// Opens a form to retrieve new books and adds the inputted values into the bookcopyies list
        /// </summary>
        public void AddBookCopies()
        {
            frmAddBookCopies frmAddBookCopies = new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
            if (frmAddBookCopies.DialogResult == DialogResult.OK)
            {
                foreach(string barcode in frmAddBookCopies.barcodes)
                {
                    _bookCopyList.Add(new TempBookCopy(barcode));
                }
                UpdateBookCopyList();
            }
        }
        /// <summary>
        /// Deletes the selected book copies in the list view
        /// </summary>
        public void DeleteBookCopies()
        {
            if (Objects.CopyDetails.CheckedItems.Count > 0)
            {
                // find which copies to delete
                List<TempBookCopy> deleteCopyList = new List<TempBookCopy>();
                foreach (ListViewItem item in Objects.CopyDetails.CheckedItems)
                    foreach (TempBookCopy copy in _bookCopyList)
                        if (item.SubItems[0].Text == copy.Barcode)
                            deleteCopyList.Add(copy);
                // delete copies
                foreach (TempBookCopy copy in deleteCopyList)
                    _bookCopyList.Remove(copy);
                UpdateBookCopyList();
            }
        }
        /// <summary>
        /// Updates book copies shown in the book copy details listview
        /// </summary>
        private void UpdateBookCopyList()
        {
            Objects.CopyDetails.Items.Clear();
            foreach (TempBookCopy bookCopy in _bookCopyList)
            {
                string[] data =
                {
                bookCopy.Barcode,
                bookCopy.Status,
                bookCopy.DueDate
                };
                Objects.CopyDetails.Items.Add(new ListViewItem(data));
            }
            DisplayBookCopyStatusTotals();
            ListViewHandler.ResizeColumnHeaders(ref Objects.CopyDetails);
            ListViewSortingData.SortedDescending = !ListViewSortingData.SortedDescending; // this is done so that is resorts to the previous sort order
            ListViewHandler.SortListView(ref Objects.CopyDetails, ListViewSortingData.CurrentColumn, ref ListViewSortingData, ListViewHandler.ColourListViewNormal);
            ListViewHandler.ColourListViewNormal(ref Objects.CopyDetails);
        }
        /// <summary>
        /// Initialises the list view used to display book copies
        /// </summary>
        private void InitialiseCopyDetails()
        {
            Objects.CopyDetails.Clear();
            Objects.CopyDetails.View = View.Details;
            Objects.CopyDetails.LabelEdit = false;
            Objects.CopyDetails.AllowColumnReorder = false;
            Objects.CopyDetails.CheckBoxes = true;
            Objects.CopyDetails.MultiSelect = true;
            Objects.CopyDetails.FullRowSelect = true;
            Objects.CopyDetails.GridLines = false;
            Objects.CopyDetails.Sorting = SortOrder.None;
            Objects.CopyDetails.HeaderStyle = ColumnHeaderStyle.Clickable;
            // add columns
            string[] columns = new string[3]
            {
                "Barcode",
                "Status",
                "Due Date"
            };
            ListViewHandler.SetColumns(columns, ref Objects.CopyDetails);
        }
        /// <summary>
        /// Loads the copy details of the book details being modified into the bookcopy list view. list view is left empty if creating a new book
        /// </summary>
        public void LoadCopyDetails()
        {
            _bookCopyList.Clear();
            List<BookCopy> currentBookCopyList = GetCurrentBookCopies();
            if (currentBookCopyList.Count > 0)
                foreach (BookCopy bookCopy in currentBookCopyList)
                {
                    _bookCopyList.Add(new TempBookCopy(bookCopy));
                }
            UpdateBookCopyList();
        }
        /// <summary>
        /// Gets the book copies of the book record being modified
        /// </summary>
        /// <returns>List of the book record's book copies. Returns empty list if creating a new book</returns>
        public List<BookCopy> GetCurrentBookCopies()
        {
            List<BookCopy> bookCopyList = new List<BookCopy>();
            if (!_isNewRecord && _bookData.BookCopies.Count > 0)
            {
                foreach (BookCopy copy in _bookData.BookCopies)
                    bookCopyList.Add(copy);
            }
            return bookCopyList;
        }
        #endregion
        /// <summary>
        /// Saves the inputted book data into the list of books and book copies
        /// </summary>
        public void Save()
        {
            if (_isNewRecord) // if the panel is being used to create a record
            {
                BookCreator creator = GetBookInput(); // create a book creator and load the inputted data
                if (creator.Validate(out List<string> invalidInputs)) // if valid
                {
                    Book book = new Book(creator);
                    DataLibrary.Books.Add(book);
                    // Add new book copies
                    if (_bookCopyList.Count > 0)
                        foreach (TempBookCopy copy in _bookCopyList)
                            DataLibrary.CreateBookCopy(copy.Barcode, book);
                    FileHandler.Save.Books();
                    FileHandler.Save.BookCopies();
                    Load();
                }
                else
                    MessageBox.Show("Invalid inputs: " + DataFormatter.ListToString(invalidInputs));
            }
            else // else the panel is being used to modify a record
            {
                // Update old book record
                BookCreator creator = GetBookInput(); // create a book creator and load the inputted data
                if (creator.Validate(out List<string> invalidInputs, _bookData)) // if valid
                {
                    // modify the old book record properties to the new ones
                    DataLibrary.Isbns = DataLibrary.ModifyReferenceClass(DataLibrary.Isbns, _bookData, _bookData.Isbn, out _bookData.Isbn, creator.Isbn, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.Titles = DataLibrary.ModifyReferenceClass(DataLibrary.Titles, _bookData, _bookData.Title, out _bookData.Title, creator.Title, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.SeriesTitles = DataLibrary.ModifyReferenceClass(DataLibrary.SeriesTitles, _bookData, _bookData.SeriesTitle, out _bookData.SeriesTitle, creator.SeriesTitle, SearchAndSort.TwoRefClassBooks);
                    _bookData.SeriesNumber = Convert.ToInt32(creator.SeriesNumber);
                    DataLibrary.MediaTypes = DataLibrary.ModifyReferenceClass(DataLibrary.MediaTypes, _bookData, _bookData.MediaType, out _bookData.MediaType, creator.MediaType, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.Authors = DataLibrary.ModifyReferenceClass(DataLibrary.Authors, _bookData, _bookData.Author, out _bookData.Author, creator.Author, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.Publishers = DataLibrary.ModifyReferenceClass(DataLibrary.Publishers, _bookData, _bookData.Publisher, out _bookData.Publisher, creator.Publisher, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.Genres = DataLibrary.ModifyReferenceClassList(DataLibrary.Genres, _bookData, _bookData.Genres, out _bookData.Genres, creator.Genres, SearchAndSort.TwoRefClassBooks);
                    DataLibrary.Themes = DataLibrary.ModifyReferenceClassList(DataLibrary.Themes, _bookData, _bookData.Themes, out _bookData.Themes, creator.Themes, SearchAndSort.TwoRefClassBooks);
                    _bookData.Description = creator.Description;
                    DataLibrary.Prices = DataLibrary.ModifyReferenceClass(DataLibrary.Prices, _bookData, _bookData.Price, out _bookData.Price, Convert.ToDouble(creator.Price), SearchAndSort.TwoRefClassBooks);
                    
                    // Delete the removed book copies
                    List<BookCopy> oldBookCopyList = SearchAndSort.QuickSort<BookCopy, BookCopy>(GetCurrentBookCopies(), SearchAndSort.TwoBookCopies); // list of book copies before modifying the record
                    if (_bookCopyList.Count > 0) // if there are any book copies
                    {
                        List<TempBookCopy> unchangedBookCopyList = new List<TempBookCopy>(); // list of book copies in the modified record that were not changed from the old record
                        // Get the unchanged book copies from _BookCopyList
                        foreach (TempBookCopy copy in _bookCopyList)
                            if (copy.BookCopy != null)
                                unchangedBookCopyList.Add(copy);
                        unchangedBookCopyList = SearchAndSort.QuickSort<TempBookCopy, TempBookCopy>(unchangedBookCopyList, SearchAndSort.TwoTempBookCopies);
                        // Delete the original book copies that have now been removed
                        if (unchangedBookCopyList.Count > 0)
                            foreach (BookCopy copy in oldBookCopyList)
                            {
                                if (SearchAndSort.Binary(unchangedBookCopyList, copy, SearchAndSort.TempBookCopyAndBookCopy) == -1) // deletes the old book copy if it is not in the list of modified book copies
                                    DataLibrary.DeleteBookCopy(copy);
                            }
                        else
                            foreach (BookCopy copy in oldBookCopyList)
                                DataLibrary.DeleteBookCopy(copy);
                    }
                    else // else delete all book copies
                    {
                        foreach (BookCopy copy in oldBookCopyList)
                            DataLibrary.DeleteBookCopy(copy);
                    }
                    // Add new book copies
                    foreach (TempBookCopy copy in _bookCopyList)
                    {
                        if (copy.BookCopy == null) // if the TempBookCopy is a new copy
                        {
                            DataLibrary.CreateBookCopy(copy.Barcode, _bookData);
                        }
                    }
                    // save all affected data structures
                    FileHandler.Save.Books();
                    FileHandler.Save.BookCopies();
                    FileHandler.Save.CirculationCopies();
                    FrmMainSystem.Main.NavigatorOpenSearchViewTab();
                }
                else
                    MessageBox.Show("Invalid inputs: " + DataFormatter.ListToString(invalidInputs));
            }
        }
        /// <summary>
        /// Retrieves the book record created from the inputted data
        /// </summary>
        /// <returns>Inputted book data</returns>
        private BookCreator GetBookInput() 
        {
            BookCreator temp = new BookCreator();
            temp.Isbn = Objects.Isbn.Text;
            temp.Title = Objects.Title.Text;
            temp.SeriesTitle = Objects.SeriesTitle.Text;
            temp.SeriesNumber = Objects.SeriesNumber.Text;
            temp.MediaType = Objects.MediaType.Text;
            temp.Author = Objects.Author.Text;
            temp.Publisher = Objects.Publisher.Text;
            temp.Genres = DataFormatter.SplitString(Objects.Genres.Text, ", ");
            temp.Themes = DataFormatter.SplitString(Objects.Themes.Text, ", ");
            temp.Description = Objects.Description.Text;
            temp.Price = Objects.Price.Text;
            return temp;
        }
        /// <summary>
        /// Cancels the update or insertion of a new book record
        /// </summary>
        public void Cancel()
        {
            if (_isNewRecord)
                Load();
            else
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
        /// <summary>
        /// Displays the totals of each type of circulation status in the status text boxes
        /// </summary>
        public void DisplayBookCopyStatusTotals()
        {
            int inStock = 0;
            int reserved = 0;
            int loaned = 0;
            foreach (TempBookCopy copy in _bookCopyList)
            {
                switch (copy.Status)
                {
                    case "In Stock":
                        inStock++;
                        break;
                    case "Reserved":
                        reserved++;
                        break;
                    case "Loaned":
                        loaned++;
                        break;
                }
            }
            Objects.InStock.Text = inStock.ToString();
            Objects.Reserved.Text = reserved.ToString();
            Objects.Loaned.Text = loaned.ToString();
        }
    }
}
