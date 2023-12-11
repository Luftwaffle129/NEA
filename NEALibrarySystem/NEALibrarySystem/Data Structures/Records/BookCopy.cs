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
            int index; // index that the reference class is inserted into
            DataLibrary.BookCopyBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.BookCopyBarcodes, this, barcode, SearchAndSort.TwoBookCopyBarcodes, out index);
            Barcode = DataLibrary.BookCopyBarcodes[index];
            BookRelation = new BookCopyRelation(book, this);
            DataLibrary.BookCopyRelations.Add(BookRelation);
            BookRelation.Book.BookCopyRelations.Add(BookRelation);
            CirculationCopy = null;
        }
        public string GetStatus()
        {
            if (CirculationCopy == null)
                return "In Stock";
            if (CirculationCopy.Type.Value == CirculationType.reserved)
                return "Reserved";
            else
                return "Loaned";
        }
        public string GetMemberBarcode()
        {
            if (CirculationCopy == null)
                return "";
            else
                return CirculationCopy.CircMemberRelation.Member.Barcode.Value;
        }
        public string GetDueDate()
        {
            if (CirculationCopy == null)
                return "";
            else
                return CirculationCopy.DueDate.Value.Date.ToString();
        }
    }
}