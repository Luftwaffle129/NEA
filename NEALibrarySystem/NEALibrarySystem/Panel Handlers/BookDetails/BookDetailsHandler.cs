using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
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
        private bool _IsNewRecord = false;
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
                _objects.Title.Text = _bookData.Title.Name;
                _objects.SeriesTitle.Text = _bookData.SeriesTitle;
                _objects.SeriesNumber.Text = _bookData.SeriesNumber.ToString();
                _objects.ISBN.Text = _bookData.Isbn;
                _objects.MediaType.Text = _bookData.MediaType.Name;
                _objects.Author.Text = _bookData.Author.Name;
                _objects.Publisher.Text = _bookData.Publisher.Name;
                _objects.Genres.Text = DataFormatter.ItemBookListToString(_bookData.Genres);
                _objects.Themes.Text = DataFormatter.ItemBookListToString(_bookData.Themes);
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
                _IsNewRecord = true;
            }

            UpdateBookCopies();
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
                    zBookCopy temp = new zBookCopy()
                    {
                        Barcode = barcode,
                        Status = status.InStock,
                        ReturnDate = DateTime.Today,
                        OverdueEmailLastSent = DateTime.Today,
                        MemberID = barcode,
                    };
                    _bookData.BookCopies.Add(temp);
                }
            }
            UpdateBookCopies();
        }
        /// <summary>
        /// deletes the selected book copies
        /// </summary>
        public void DeleteBookCopies()
        {
            foreach(ListViewItem item in _objects.CopyDetails.CheckedItems)
            {
                for (int i = 0; i < _bookData.BookCopies.Count; i++)
                {
                    if (item.SubItems[0].Text == _bookData.BookCopies[i].Barcode)
                    {
                        _bookData.BookCopies.RemoveAt(i);
                    }
                }
            }
            UpdateBookCopies();
        }
        /// <summary>
        /// Updates book copies shown in the book copy details listview
        /// </summary>
        private void UpdateBookCopies()
        {
            _objects.CopyDetails.Items.Clear();
            if (_bookData.BookCopies != null)
            {
                foreach (zBookCopy bookCopy in _bookData.BookCopies)
                {
                    string[] data = new string[3]
                    {
                    bookCopy.Barcode,
                    bookCopy.Status.ToString(),
                    bookCopy.ReturnDate.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    _objects.CopyDetails.Items.Add(row);
                }
            }
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
            //add columns
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
            if (_IsNewRecord)
            {
                //add the new record and empty the input fields
                DataLibrary.Books.Add(GetBookInput());
                Load();
            }
            else
            {
                //remove old record of the book
                if (DataLibrary.Books.Count !=0)
                {
                    bool isReplaced = false;
                    int index = 0;
                    do
                    {
                        if (DataLibrary.Books[index] == _bookData)
                        {
                            DataLibrary.Books[index] = GetBookInput();
                            isReplaced = true;
                        }
                    } while (!isReplaced || ++index >= DataLibrary.Books.Count);
                }
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
            temp.Genres = DataFormatter.RemoveWhiteSpace(_objects.Genres.Text).Split(',').ToList<string>();
            temp.Themes = DataFormatter.RemoveWhiteSpace(_objects.Themes.Text).Split(',').ToList<string>();
            temp.Description = _objects.Description.Text;
            return temp;
        }
        /// <summary>
        /// Cancels the update or insertion of a new book record
        /// </summary>
        public void Cancel()
        {
            if (_IsNewRecord)
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
