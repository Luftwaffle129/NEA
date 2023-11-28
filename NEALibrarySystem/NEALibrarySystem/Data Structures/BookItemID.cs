using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class BookItemID
    {
        public Book Book { get; set; }
        public ItemBook ItemID { get; set; }
        public BookItemID(Book book, ItemBook itemId) 
        {
            Book = book;
            ItemID = itemId;
        }

    }
}
