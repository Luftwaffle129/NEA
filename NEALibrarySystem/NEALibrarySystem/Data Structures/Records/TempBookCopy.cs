using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to store the temporary book copy information before modifying the main system
    /// </summary>
    public class TempBookCopy
    {
        public string Barcode { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public BookCopy BookCopy { get; set; }
        /// <summary>
        /// Used to create a temporary copy of a new book copy
        /// </summary>
        /// <param name="barcode"></param>
        public TempBookCopy(string barcode)
        {
            Barcode = barcode;
            Status = "In Stock";
            DueDate = "";
            BookCopy = null;
        }
        /// <summary>
        /// used to create a temporary copy of an existing book copy
        /// </summary>
        /// <param name="bookCopy"></param>
        public TempBookCopy(BookCopy bookCopy)
        {
            Barcode = bookCopy.Barcode.Value;
            Status = bookCopy.GetStatus();
            DueDate = bookCopy.GetDueDate();
            BookCopy = bookCopy;
        }
    }
}
