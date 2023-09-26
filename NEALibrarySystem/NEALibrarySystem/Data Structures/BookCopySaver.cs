using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class BookCopySaver
    {
        public BookCopySaver(BookCopy bookCopy)
        {
            Barcode = bookCopy.Barcode;
            Status = bookCopy.Status;
            DueDate = bookCopy.DueDate;
            MemberID = bookCopy.MemberID;
            ISBN = bookCopy.ISBN;
            OverdueEmailSent = bookCopy.OverdueEmailSent;
        }
        public string Barcode { get; set; }
        public status Status { get; set; }
        public DateTime DueDate { get; set; }
        public string MemberID { get; set; }
        public string ISBN { get; set; }
        public Boolean OverdueEmailSent { get; set; }
    }
}
