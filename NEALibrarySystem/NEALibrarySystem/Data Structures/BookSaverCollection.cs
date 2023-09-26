using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    [System.Serializable]
    public class BookSaverCollection
    {
        public BookSaverCollection(List<Book> books)
        {
            Books = new BookSaver[books.Count];
            for (int i = 0; i < books.Count; i++) 
            {
                BookSaver temp = new BookSaver(books[i]);
            }
        }
        public BookSaver[] Books { get; set; }
    }
}
