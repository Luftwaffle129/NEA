using NEALibrarySystem.Data_Structures.Records;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Used to store a book copy
    /// </summary>
    public class BookCopy
    {
        public ReferenceClass<string, BookCopy> Barcode { get; set; } // used as the primary key
        public Book Book { get; set; } // links the book copy to a book
        public CirculationCopy CirculationCopy { get; set; } // links the book copy to a circulation record
        public BookCopy(string barcode, Book book)
        {
            // create a relation to the book
            Book = book;
            Book.BookCopies.Add(this);

            int index; // index that the reference class is inserted into
            DataLibrary.BookCopyBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.BookCopyBarcodes, this, barcode, SearchAndSort.TwoBookCopyBarcodes, out index);
            Barcode = DataLibrary.BookCopyBarcodes[index];

            CirculationCopy = null;
        }
        /// <summary>
        /// Gets the status of the book copy
        /// </summary>
        /// <returns>String representation of the book copy's status</returns>
        public string GetStatus()
        {
            if (CirculationCopy == null) // if book copy is not circulated
                return "In Stock";
            else if (CirculationCopy.Type.Value == CirculationType.Reserved)
                return "Reserved";
            else
                return "Loaned";
        }
        /// <summary>
        /// Gets the member barcode of the book if it is circulated
        /// </summary>
        /// <returns>Book copy's circulated member's barcode</returns>
        public string GetMemberBarcode()
        {
            if (CirculationCopy == null) // if book copy is not circulated
                return "";
            else
                return CirculationCopy.Member.Barcode.Value;
        }
        /// <summary>
        /// Gets the due date of the book if it is circulated
        /// </summary>
        /// <returns>Book copy's circulated due date</returns>
        public string GetDueDate()
        {
            if (CirculationCopy == null) // if book copy is not circulated
                return "";
            else
                return DataFormatter.GetDate(CirculationCopy.DueDate.Value);
        }
    }
}