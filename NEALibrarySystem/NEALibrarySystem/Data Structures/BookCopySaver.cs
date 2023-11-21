﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace NEALibrarySystem.Data_Structures
{
    [System.Serializable]
    public class BookCopySaver
    {
        public BookCopySaver(BookCopy bookCopy)
        {
            Barcode = bookCopy.Barcode;
            Status = bookCopy.Status;
            DueDate = bookCopy.ReturnDate;
            MemberID = bookCopy.MemberID;
            //ISBN = bookCopy.ISBN;
            //OverdueEmailSent = bookCopy.OverdueEmailSent;
            OverdueEmailLastSent = bookCopy.OverdueEmailLastSent;
        }
        public string Barcode { get; set; }
        public status Status { get; set; }
        public DateTime DueDate { get; set; }
        public string MemberID { get; set; }
        //public string ISBN { get; set; }
        //public Boolean OverdueEmailSent { get; set; }
        public DateTime OverdueEmailLastSent { get; set; }
    }
}
