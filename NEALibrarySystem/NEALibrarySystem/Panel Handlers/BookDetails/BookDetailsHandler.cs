using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.ListViewHandlers;
using NEALibrarySystem.SearchList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.PanelHandlers
{
    public class BookDetailsHandler
    {
        private BookDetailsObjects _objects;
        private Book _bookData;
        private List<TempBookCopy> _bookCopyList = new List<TempBookCopy>();
        private bool _isNewRecord = true;
        public BookDetailsHandler(BookDetailsObjects objs) 
        {
            _objects = objs;
            _bookData = new Book();
            InitialiseCopyDetails();
        }
        /// <summary>
        /// Loads the book details into the input boxes
        /// </summary>
        public void Load(Book book = null)
        {
            //book details
            if (book != null)
            {
                _bookData = book;
                _objects.Title.Text = _bookData.Title.Value;
                _objects.SeriesTitle.Text = _bookData.SeriesTitle.Value;
                _objects.SeriesNumber.Text = _bookData.SeriesNumber.ToString();
                _objects.Isbn.Text = _bookData.Isbn.Value;
                _objects.MediaType.Text = _bookData.MediaType.Value;
                _objects.Author.Text = _bookData.Author.Value;
                _objects.Publisher.Text = _bookData.Publisher.Value;
                _objects.Genres.Text = DataFormatter.ReferenceClassListToString(_bookData.Genres);
                _objects.Themes.Text = DataFormatter.ReferenceClassListToString(_bookData.Themes);
                _objects.Description.Text = _bookData.Description;
                _objects.Price.Text = _bookData.Price.Value.ToString();
                _isNewRecord = false;
            }
            else 
            {
                _bookData = new Book();
                _objects.Title.Text = "";
                _objects.SeriesTitle.Text = "";
                _objects.SeriesNumber.Text = "";
                _objects.Isbn.Text = "";
                _objects.MediaType.Text = "";
                _objects.Author.Text = "";
                _objects.Publisher.Text = "";
                _objects.Genres.Text = "";
                _objects.Themes.Text = "";
                _objects.Description.Text = "";
                _objects.Price.Text = "";

                _objects.CopyDetails.Items.Clear();
                _isNewRecord = true;
            }
            InitialiseCopyDetails();
            DataLibrary.BookCopies = DataLibrary.BookCopies;
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
            if (_bookData.Isbn != null)
            {
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
            }
        }
        /// <summary>
        /// initialises the list view used to display book copies
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
            AddColumns(columns);
            _objects.CopyDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            _bookCopyList.Clear();
            List<BookCopy> currentBookCopyList = GetCurrentBookCopies();
            if (currentBookCopyList.Count > 0)
                foreach (BookCopy bookCopy in currentBookCopyList)
                {
                    _bookCopyList.Add(new TempBookCopy(bookCopy));
                }
            UpdateBookCopyList();
        }
        public List<BookCopy> GetCurrentBookCopies()
        {
            List<BookCopy> bookCopyList = new List<BookCopy>();
            if (!_isNewRecord && _bookData.BookCopyRelations.Count > 0)
            {
                foreach (BookCopyRelation copyRelation in _bookData.BookCopyRelations)
                    bookCopyList.Add(copyRelation.Copy);
            }
            return bookCopyList;
        }
        private void AddColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                _objects.CopyDetails.Columns.Add(column);
            }
        }
        #endregion
        /// <summary>
        /// Saves the inputted book data into the list of books and book copies
        /// </summary>
        public void Save()
        {
            if (_isNewRecord)
            {
                Book book = new Book(GetBookInput());
                DataLibrary.Books.Add(book);
                // Add new book copies
                foreach (TempBookCopy copy in _bookCopyList)
                {
                    DataLibrary.CreateBookCopy(copy.Barcode, book);
                }
                Load();
            }
            else
            {
                // Update old book record
                BookCreator newInfo = GetBookInput();
                DataLibrary.Isbns = DataLibrary.ModifyReferenceClass(DataLibrary.Isbns, _bookData, _bookData.Isbn, out _bookData.Isbn, newInfo.Isbn, SearchAndSort.TwoRefClassBooks);
                DataLibrary.Titles = DataLibrary.ModifyReferenceClass(DataLibrary.Titles, _bookData, _bookData.Title, out _bookData.Title, newInfo.Title, SearchAndSort.TwoRefClassBooks);
                DataLibrary.SeriesTitles = DataLibrary.ModifyReferenceClass(DataLibrary.SeriesTitles, _bookData, _bookData.SeriesTitle, out _bookData.SeriesTitle, newInfo.SeriesTitle, SearchAndSort.TwoRefClassBooks);
                _bookData.SeriesNumber = newInfo.SeriesNumber;
                DataLibrary.MediaTypes = DataLibrary.ModifyReferenceClass(DataLibrary.MediaTypes, _bookData, _bookData.MediaType, out _bookData.MediaType, newInfo.MediaType, SearchAndSort.TwoRefClassBooks);
                DataLibrary.Authors = DataLibrary.ModifyReferenceClass(DataLibrary.Authors, _bookData, _bookData.Author, out _bookData.Author, newInfo.Author, SearchAndSort.TwoRefClassBooks);
                DataLibrary.Publishers = DataLibrary.ModifyReferenceClass(DataLibrary.Publishers, _bookData, _bookData.Publisher, out _bookData.Publisher, newInfo.Publisher, SearchAndSort.TwoRefClassBooks);
                DataLibrary.Genres = DataLibrary.ModifyReferenceClassList(DataLibrary.Genres, _bookData, _bookData.Genres, out _bookData.Genres, newInfo.Genres, SearchAndSort.TwoRefClassBooks);
                DataLibrary.Themes = DataLibrary.ModifyReferenceClassList(DataLibrary.Themes, _bookData, _bookData.Themes, out _bookData.Themes, newInfo.Themes, SearchAndSort.TwoRefClassBooks);
                _bookData.Description = newInfo.Description;
                DataLibrary.Prices = DataLibrary.ModifyReferenceClass(DataLibrary.Prices, _bookData, _bookData.Price, out _bookData.Price, newInfo.Price, SearchAndSort.TwoRefClassBooks);
                // Delete the removed book copies
                List<BookCopy> oldBookCopyList = SearchAndSort.QuickSort<BookCopy, BookCopy>(GetCurrentBookCopies(), SearchAndSort.TwoBookCopies);
                if (_bookCopyList.Count > 0)
                {
                    List<TempBookCopy> unchangedBookCopyList = new List<TempBookCopy>();
                    // Get the unchanged book copies from _BookCopyList
                    foreach (TempBookCopy copy in _bookCopyList)
                        if (copy.BookCopy != null)
                            unchangedBookCopyList.Add(copy);

                    // Get the old book copies to remove
                    if (unchangedBookCopyList.Count > 0)
                        foreach (BookCopy copy in oldBookCopyList)
                        {
                            if (SearchAndSort.Binary(unchangedBookCopyList, copy, SearchAndSort.TempBookCopyAndBookCopy) == -1)
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
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            }
        }
        /// <summary>
        /// retrieves the book record created from the inputted data
        /// </summary>
        /// <returns>inputted book data</returns>
        private BookCreator GetBookInput() 
        {
            BookCreator temp = new BookCreator();
            temp.Isbn = _objects.Isbn.Text;
            temp.Title = _objects.Title.Text;
            temp.SeriesTitle = _objects.SeriesTitle.Text;
            temp.SeriesNumber = Convert.ToInt32(_objects.SeriesNumber.Text);
            temp.MediaType = _objects.MediaType.Text;
            temp.Author = _objects.Author.Text;
            temp.Publisher = _objects.Publisher.Text;
            temp.Genres = _objects.Genres.Text.Split(',').ToList<string>();
            temp.Themes = _objects.Themes.Text.Split(',').ToList<string>();
            temp.Description = _objects.Description.Text;
            return temp;
        }
        /// <summary>
        /// Cancels the update or insertion of a new book record
        /// </summary>
        public void Cancel()
        {
            if (_isNewRecord)
            { 
                Load();
            }
            else
            {
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            }
        }

    }

}
