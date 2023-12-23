using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to store a relation between book copies and books
    /// </summary>
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
