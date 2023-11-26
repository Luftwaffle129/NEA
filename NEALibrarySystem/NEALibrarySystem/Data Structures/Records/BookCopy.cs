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
        public ReferenceClass<Book, BookCopy> Book { get; set; }
        public BookCopy(string barcode, Book book)
        {
            Barcode = barcode;
            Book = book;
        }
    }
}