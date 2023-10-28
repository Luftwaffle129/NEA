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
        public BookDetailsHandler(BookDetailsObjects objs, Book book = null) 
        {
            _objects = objs;
            _bookData = new Book();

            if (book != null) 
            {
                _bookData = book;
                loadBookDetails();
            }
            else
            {
                foreach (TextBox textBox in _objects.Fields)
                {
                    textBox.Text = "";
                }
            }
            InitialiseCopyDetails();
        }
        /// <summary>
        /// Loads the book details into the input boxes
        /// </summary>
        public void loadBookDetails()
        {
            //book details
            _objects.Fields[(int)BookDetailsObjects.FieldName.Title].Text = _bookData.GetTitle();
            _objects.Fields[(int)BookDetailsObjects.FieldName.SeriesTitle].Text = _bookData.SeriesTitle;
            _objects.Fields[(int)BookDetailsObjects.FieldName.SeriesNumber].Text = _bookData.SeriesNumber.ToString();
            _objects.Fields[(int)BookDetailsObjects.FieldName.ISBN].Text = _bookData.ISBN;
            _objects.Fields[(int)BookDetailsObjects.FieldName.MediaType].Text = _bookData.GetMediaType();
            _objects.Fields[(int)BookDetailsObjects.FieldName.Author].Text = _bookData.GetAuthor();
            _objects.Fields[(int)BookDetailsObjects.FieldName.Publisher].Text = _bookData.GetPublisher();
            _objects.Fields[(int)BookDetailsObjects.FieldName.Genres].Text = DataFormatter.ListToString(_bookData.GetGenres());
            _objects.Fields[(int)BookDetailsObjects.FieldName.Themes].Text = DataFormatter.ListToString(_bookData.GetThemes());
            _objects.Fields[(int)BookDetailsObjects.FieldName.Description].Text = _bookData.Description;
            _objects.Fields[(int)BookDetailsObjects.FieldName.Price].Text = _bookData.Price.ToString();
            // book copies

        }
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
        public void DeleteBookCopies()
        {

        }
        public void Cancel()
        {

        }
        /// <summary>
        /// Loads book copies into the book copy details listview
        /// </summary>
        private void LoadBookCopies()
        {
            _objects.CopyDetails.Items.Clear();
            if (_bookData.BookCopies == null)
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
        }
        private void AddColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                _objects.CopyDetails.Columns.Add(column);
            }
        }
    }
}
