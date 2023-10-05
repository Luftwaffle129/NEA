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
        private BookDetailsObjects objects;
        private Book bookData;
        public BookDetailsHandler(BookDetailsObjects objs, Book book = null) 
        {
            objects = objs;
            bookData = new Book();
            if (book != null) 
            {
                bookData = book;
                loadBookDetails();
            }
        }
        public void loadBookDetails()
        {
            objects.Title.Text = bookData.GetTitle();
            objects.SeriesTitle.Text = bookData.SeriesTitle;
            objects.SeriesNumber.Text = bookData.SeriesNumber.ToString();
            objects.ISBN.Text = bookData.ISBN;
            objects.MediaType.Text = bookData.GetMediaType();
            objects.Author.Text = bookData.GetAuthor();
            objects.Publisher.Text = bookData.GetPublisher();
            objects.Genres.Text = DataFormatter.ListToString(bookData.GetGenres());
            objects.Themes.Text = DataFormatter.ListToString(bookData.GetThemes());
            objects.Description.Text = bookData.Description;
            objects.Price.Text = bookData.Price.ToString();

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
                    bookData.BookCopies.Add(temp);
                }
            }
        }
        public void Cancel()
        {

        }
    }
}
