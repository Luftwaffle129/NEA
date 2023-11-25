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
        public BookSaverCollection(List<zBook> books)
        {
            Collection = new BookSaver[books.Count];
            for (int i = 0; i < books.Count; i++) 
            {
                BookSaver temp = new BookSaver(books[i]);
                Collection[i] = temp;
            }
        }
        private BookSaver[] collection = new BookSaver[0];
        public BookSaver[] Collection 
        {
            get { return collection; }
            set { collection = value ?? new BookSaver[0]; } 
        }
    }
}
