using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class BookCopy
    {
        public string Barcode { get; set; }
        public Book Book { get; set; }
        public BookCopy(string barcode, Book book)
        {
            Barcode = barcode;
            Book = book;
        }
    }
}
