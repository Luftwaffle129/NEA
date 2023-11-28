using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class ItemBook : ReferenceClass<string>
    {
        public ItemBook()
        {
            Books = new List<Book>();
        }
        public ItemBook(string name)
        {
            Value = name;
            Books = new List<Book>();
        }
    }
}
