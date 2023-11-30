using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class BookCopy
    {
        public ReferenceClass<string, BookCopy> Barcode { get; set; }
        public Book Book { get; set; }
        public BookCopy(string barcode, Book book)
        {
            DataLibrary.BookCopyBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.BookCopyBarcodes, this, barcode, SearchAndSort.TwoStrings);
            Book = book;
            Book.BookCopies.Add(this);
        }
    }
}