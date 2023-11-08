using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void loadBookDetails(Book book = null)
        {
            //book details
            if (book != null)
            {
                _bookData = book;
                _objects.Title.Text = _bookData.GetTitle();
                _objects.SeriesTitle.Text = _bookData.SeriesTitle;
                _objects.SeriesNumber.Text = _bookData.SeriesNumber.ToString();
                _objects.ISBN.Text = _bookData.ISBN;
                _objects.MediaType.Text = _bookData.GetMediaType();
                _objects.Author.Text = _bookData.GetAuthor();
                _objects.Publisher.Text = _bookData.GetPublisher();
                _objects.Genres.Text = DataFormatter.ListToString(_bookData.GetGenres());
                _objects.Themes.Text = DataFormatter.ListToString(_bookData.GetThemes());
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
                    BookCopy temp = new BookCopy()
                    {
                        Barcode = barcode,
                        Status = status.InStock,
                        DueDate = DateTime.Now,
                        OverdueEmailLastSent = DateTime.Now,
                        MemberID = barcode,
                    };
                    _bookData.BookCopies.Add(temp);
                }
            }
        }
        /// <summary>
        /// deletes the selected book copies
        /// </summary>
        public void DeleteBookCopies()
        {
            foreach(ListViewItem item in _objects.CopyDetails.SelectedItems)
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
        /// Updates book copies into the book copy details listview
        /// </summary>
        private void UpdateBookCopies()
        {
            _objects.CopyDetails.Items.Clear();
            if (_bookData.BookCopies != null)
            {
                foreach (BookCopy bookCopy in _bookData.BookCopies)
                {
                    string[] data = new string[3]
                    {
                    bookCopy.Barcode,
                    bookCopy.Status.ToString(),
                    bookCopy.DueDate.ToString()
                    };
                    ListViewItem row = new ListViewItem(data);
                    _objects.CopyDetails.Items.Add(row);
                }
            }
        }
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
        public void Save()
        {
            Book temp = new Book();
            temp.SetTitle(_objects.Title.Text);
            temp.SeriesTitle = _objects.SeriesTitle.Text;
            temp.SeriesNumber = Convert.ToInt32(_objects.SeriesNumber.Text);
            temp.SetMediaType(_objects.MediaType.Text);
            temp.SetAuthor(_objects.Author.Text);
            temp.SetPublisher(_objects.Publisher.Text);
            temp.SetGenres(_objects.Genres.Text.Split(',').ToList<string>());
            temp.SetThemes(_objects.Themes.Text.Split(',').ToList<string>());
            temp.Description = _objects.Description.Text;
            temp.BookCopies = _bookData.BookCopies; 
            DataLibrary.Books.Add(temp);
        }
        public void Cancel()
        {
            loadBookDetails();
        }
    }
}
