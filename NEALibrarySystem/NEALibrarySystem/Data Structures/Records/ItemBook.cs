using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class ItemBook
    {
        public string Name {  get; set; }
        private List<Book> _books;
        public List<Book> Books 
        { 
            get {  return _books; } 
            set {  _books = value ?? new List<Book>(); } 
        }
        public ItemBook()
        {
            Books = new List<Book>();
        }
        public ItemBook(string name)
        {
            Name = name;
            Books = new List<Book>();
        }
    }
}
