using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    public class BookCopyRelation
    {
        public Book Book;
        public BookCopy Copy;

        public BookCopyRelation(Book book, BookCopy copy)
        {
            Book = book;
            Copy = copy;
        }

    }
}
