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
            BookRelation = new BookCopyRelation(book, this);
            DataLibrary.BookCopyRelations.Add(BookRelation);
            BookRelation.Book.BookCopyRelations.Add(BookRelation);
            int index; // index that the reference class is inserted into
            DataLibrary.BookCopyBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.BookCopyBarcodes, this, barcode, SearchAndSort.TwoBookCopyBarcodes, out index);
            Barcode = DataLibrary.BookCopyBarcodes[index];

            CirculationCopy = null;
        }
        /// <summary>
        /// Gets the status of the book copy
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            if (CirculationCopy == null)
                return "In Stock";
            else if (CirculationCopy.Type.Value == CirculationType.Reserved)
                return "Reserved";
            else
                return "Loaned";
        }
        /// <summary>
        /// Gets the member barcode of the book if it is circulated
        /// </summary>
        /// <returns>book copy's circulated member's barcode</returns>
        public string GetMemberBarcode()
        {
            if (CirculationCopy == null)
                return "";
            else
                return CirculationCopy.CircMemberRelation.Member.Barcode.Value;
        }
        /// <summary>
        /// gets the due date of the book if it is circulated
        /// </summary>
        /// <returns>book copy's circulated due date</returns>
        public string GetDueDate()
        {
            if (CirculationCopy == null)
                return "";
            else
                return DataFormatter.GetDate(CirculationCopy.DueDate.Value);
        }
    }
}