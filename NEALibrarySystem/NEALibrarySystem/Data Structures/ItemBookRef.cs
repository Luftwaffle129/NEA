using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    public class ItemBookRef
    {
        public Item Item { get; set; }
        public Book Book { get; set; }

        public ItemBookRef(Book book, Item item)
        {
            Book = book;
            Item = item;
        }
    }
}
