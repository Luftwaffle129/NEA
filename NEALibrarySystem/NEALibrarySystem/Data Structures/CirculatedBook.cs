using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.ListViewHandlers.CirculatedItems
{
    public class CirculatedBook
    {
        #region barcode
        private string _barcode;
        public string Barcode 
        { 
            get { return _barcode; } 
            set { _barcode = value; }
        }
        #endregion
        #region ISBN
        private string _ISBN;
        public string ISBN
        {
            get { return _ISBN; }
            private set { _ISBN = value; }
        }
        #endregion
        #region Title
        private string _title;
        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }
        #endregion
        #region SeriesTitle
        private string _seriesTitle;
        public string SeriesTitle
        {
            get { return _seriesTitle; }
            private set { _seriesTitle = value; }
        }
        #endregion
        #region Author
        private string _author;
        public string Author
        {
            get { return _author; }
            private set { _author = value; }
        }
        #endregion
        #region Price
        private string _price;
        public string Price
        {
            get { return _price; }
            private set { _price = value; }
        }
        #endregion
        public CirculatedBook(Book book, string copyBarcode)
        {
            _barcode = copyBarcode;
            ISBN = book.ISBN;
            Title = book.GetTitle();
            SeriesTitle = book.SeriesTitle;
            Author = book.GetAuthor();
            Price = book.Price.ToString();
        }
    }
}
