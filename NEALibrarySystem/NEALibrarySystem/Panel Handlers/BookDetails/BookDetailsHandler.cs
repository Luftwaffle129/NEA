using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
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
        private List<BookCopy> _bookCopyList;
        private bool _isNewRecord = false;
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
                _objects.ISBN.Text = _bookData.Isbn.Value;
                _objects.MediaType.Text = _bookData.MediaType.Value;
                _objects.Author.Text = _bookData.Author.Value;
                _objects.Publisher.Text = _bookData.Publisher.Value;
                _objects.Genres.Text = DataFormatter.ReferenceClassListToString(_bookData.Genres);
                _objects.Themes.Text = DataFormatter.ReferenceClassListToString(_bookData.Themes);
                _objects.Description.Text = _bookData.Description;
                _objects.Price.Text = _bookData.Price.ToString();
            }
            else 
            {
                _objects.Title.Text = "";
                _objects.SeriesTitle.Text = "";
                _objects.SeriesNumber.Text = "";
                _objects.ISBN.Text = "";
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

            UpdateBookCopyList();
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
                    BookCopy bookCopy = new BookCopy(barcode, _bookData);
                    DataLibrary.BookCopies.Add(bookCopy);
                }
            }
            UpdateBookCopyList();
        }
        /// <summary>
        /// deletes the selected book copies in the list view
        /// </summary>
        public void DeleteBookCopies()
        {
            foreach(ListViewItem item in _objects.CopyDetails.CheckedItems)
            {
                DataLibrary.DeleteBookCopy(DataLibrary.BookCopies[SearchAndSort.Binary(DataLibrary.BookCopies, item.SubItems[(int)BookCopyColumn.Barcode].Text, SearchAndSort.BookCopyAndBarcode)]);
            }
            UpdateBookCopyList();
        }
        /// <summary>
        /// Updates book copies shown in the book copy details listview
        /// </summary>
        private void UpdateBookCopyList()
        {
            _objects.CopyDetails.Items.Clear();
            SearchAndSort.BinaryRange(DataLibrary.BookCopies, _bookData.Isbn.Value, SearchAndSort.BookCopyAndIsbn);
        }
        /// <summary>
        /// initialises the list view used to display book copies
        /// </summary>
        private void InitialiseCopyDetails()
        {
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
                "Due date"
            };
            AddColumns(columns);
            _objects.CopyDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
        /// Saves the inputted book data into the list of books
        /// </summary>
        public void Save()
        {
            if (_isNewRecord)
            {
                //add the new record and empty the input fields
                DataLibrary.Books.Add(new Book(GetBookInput()));
                Load();
            }
            else
            {
                //update old book record
                DataLibrary.ModifyBookRecord(_bookData, GetBookInput());
            }
        }
        /// <summary>
        /// retrieves the book record created from the inputted data
        /// </summary>
        /// <returns>inputted book data</returns>
        private BookCreator GetBookInput() 
        {
            BookCreator temp = new BookCreator();
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
