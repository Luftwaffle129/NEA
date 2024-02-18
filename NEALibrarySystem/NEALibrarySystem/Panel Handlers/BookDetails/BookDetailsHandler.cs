using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem.PanelHandlers
{
    /// <summary>
    /// Used to handle processes of the book details panel
    /// </summary>
    public class BookDetailsHandler
    {
        private BookDetailsObjects _objects;
        private Book _bookData; // if modifying a book record, stores the data of the existing book
        private List<TempBookCopy> _bookCopyList = new List<TempBookCopy>();
        private bool _isNewRecord;
        public BookDetailsHandler(BookDetailsObjects objs) 
        {
            _objects = objs;
            _bookData = new Book();
            InitialiseCopyDetails();
        }
        /// <summary>
        /// Loads the book details into the input boxes
        /// </summary>
        /// <param name="book">book to be modified. null if creating a new book</param>
        public void Load(Book book = null)
        {
            //book details
            if (book != null) // if book is not null, fill input fields with the existing book data
            {
                _bookData = book;
                _objects.Title.Text = _bookData.Title.Value;
                _objects.SeriesTitle.Text = _bookData.SeriesTitle.Value;
                _objects.SeriesNumber.Text = _bookData.SeriesNumber.ToString();
                _objects.Isbn.Text = _bookData.Isbn.Value;
                _objects.MediaType.Text = _bookData.MediaType.Value;
                _objects.Author.Text = _bookData.Author.Value;
                _objects.Publisher.Text = _bookData.Publisher.Value;
                _objects.Genres.Text = DataFormatter.ListToString(_bookData.Genres);
                _objects.Themes.Text = DataFormatter.ListToString(_bookData.Themes);
                _objects.Description.Text = _bookData.Description;
                _objects.Price.Text = DataFormatter.DoubleToPrice(_bookData.Price.Value);
                _isNewRecord = false;
            }
            else // if book is null, set input fields to be empty
            {
                _bookData = new Book();
                _objects.Title.Clear();
                _objects.SeriesTitle.Clear();
                _objects.SeriesNumber.Clear();
                _objects.Isbn.Clear();
                _objects.MediaType.Clear();
                _objects.Author.Clear();
                _objects.Publisher.Clear();
                _objects.Genres.Clear();
                _objects.Themes.Clear();
                _objects.Description.Clear();
                _objects.Price.Clear();
                _isNewRecord = true;
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
            }
            UpdateBookCopyList();
        }
        /// <summary>
        /// deletes the selected book copies in the list view
        /// </summary>
        public void DeleteBookCopies()
        {
            if (_objects.CopyDetails.CheckedItems.Count > 0)
            {
                // find which copies to delete
                List<TempBookCopy> deleteCopyList = new List<TempBookCopy>();
                foreach (ListViewItem item in _objects.CopyDetails.CheckedItems)
                    foreach (TempBookCopy copy in _bookCopyList)
                        if (item.SubItems[0].Text == copy.Barcode)
                            deleteCopyList.Add(copy);
                // delete copies
                foreach (TempBookCopy copy in deleteCopyList)
                    _bookCopyList.Remove(copy);
            }
            UpdateBookCopyList();
        }
        /// <summary>
        /// Updates book copies shown in the book copy details listview
        /// </summary>
        private void UpdateBookCopyList()
        {
            _objects.CopyDetails.Items.Clear();
            foreach (TempBookCopy bookCopy in _bookCopyList)
            {
                string[] data =
                {
                bookCopy.Barcode,
                bookCopy.Status,
                bookCopy.DueDate
                };
                _objects.CopyDetails.Items.Add(new ListViewItem(data));
            }
            _objects.CopyDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        /// <summary>
        /// Initialises the list view used to display book copies
        /// </summary>
        private void InitialiseCopyDetails()
        {
            _objects.CopyDetails.Clear();
            _objects.CopyDetails.View = View.Details;
            _objects.CopyDetails.LabelEdit = false;
            _objects.CopyDetails.AllowColumnReorder = false;
            _objects.CopyDetails.CheckBoxes = true;
            _objects.CopyDetails.MultiSelect = true;
            _objects.CopyDetails.FullRowSelect = true;
            _objects.CopyDetails.GridLines = false;
            _objects.CopyDetails.Sorting = SortOrder.None;
            _objects.CopyDetails.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            // add columns
            string[] columns = new string[3]
            {
                "Barcode",
                "Status",
                "Due Date"
            };
            ListViewHandler.SetColumns(columns, ref _objects.CopyDetails);
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
                BookCreator creator = GetBookInput();
                if (creator.Validate(out List<string> invalidInputs))
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
                BookCreator creator = GetBookInput();
                if (creator.Validate(out List<string> invalidInputs, _bookData))
                {
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
                    if (_bookCopyList.Count > 0)
                    {
                        List<TempBookCopy> unchangedBookCopyList = new List<TempBookCopy>(); // list of book copies in the modified record that were not changed from the old record
                        // Get the unchanged book copies from _BookCopyList
                        foreach (TempBookCopy copy in _bookCopyList)
                            if (copy.BookCopy != null)
                                unchangedBookCopyList.Add(copy);
                        unchangedBookCopyList = SearchAndSort.QuickSort<TempBookCopy, TempBookCopy>(unchangedBookCopyList, SearchAndSort.TwoTempBookCopies);
                        // Get the remove the deleted book copies
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
                    else
                    {
                        foreach (BookCopy copy in oldBookCopyList)
                            DataLibrary.DeleteBookCopy(copy);
                    }
                    // Add new book copies
                    foreach (TempBookCopy copy in _bookCopyList)
                    {
                        if (copy.BookCopy == null) // Check if the TempBookCopy is a new copy
                        {
                            DataLibrary.CreateBookCopy(copy.Barcode, _bookData);
                        }
                    }
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
            temp.Isbn = _objects.Isbn.Text;
            temp.Title = _objects.Title.Text;
            temp.SeriesTitle = _objects.SeriesTitle.Text;
            temp.SeriesNumber = _objects.SeriesNumber.Text;
            temp.MediaType = _objects.MediaType.Text;
            temp.Author = _objects.Author.Text;
            temp.Publisher = _objects.Publisher.Text;
            temp.Genres = DataFormatter.SplitString(_objects.Genres.Text, ", ");
            temp.Themes = DataFormatter.SplitString(_objects.Themes.Text, ", ");
            temp.Description = _objects.Description.Text;
            temp.Price = _objects.Price.Text;
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
    }
}
