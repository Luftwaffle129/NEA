using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.Data_Structures
{
    public class BookCopy
    {
        public ReferenceClass<string, BookCopy> Barcode { get; set; }
        public BookCopyRelation BookRelation { get; set; }
        public CirculationCopy CirculationCopy { get; set; }
        public BookCopy(string barcode, Book book)
        {
            DataLibrary.BookCopyBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.BookCopyBarcodes, this, barcode, SearchAndSort.TwoStrings);
            BookRelation = new BookCopyRelation(book, this);
            DataLibrary.BookCopyRelations.Add(BookRelation);
            BookRelation.Book.BookCopyRelations.Add(BookRelation);
        }
    }
}