using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.Data_Structures
{
    public class zBookCopy
    {
        public string Barcode { get; set; }
        public status Status { get; set; }
        public DateTime ReturnDate { get; set; }
        public string MemberID { get; set; }
        //public string ISBN { get; set; }
        public DateTime OverdueEmailLastSent { get; set; }
        #region constructors
        public zBookCopy() { }
        /// <summary>
        /// Used to load book copies from files
        /// </summary>
        /// <param name="bookCopySaver">record to be loaded from files</param>
        public zBookCopy(zBookCopySaver bookCopySaver)
        {
            Barcode = bookCopySaver.Barcode;
            Status = bookCopySaver.Status;
            ReturnDate = bookCopySaver.DueDate;
            MemberID = bookCopySaver.MemberID;
            OverdueEmailLastSent = bookCopySaver.OverdueEmailLastSent;
        }
        #endregion
    }
    public enum status
    {
        InStock,
        Reserved,
        Loaned
    }
}
