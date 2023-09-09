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
        public string Barcode { get; set; }
        public status Status { get; set; }
        public DateTime DueDate { get; set; }
        public string MemberID { get; set; }
        public string ISBN { get; set; }
        public Boolean OverdueEmailSent { get; set; }
    }
    public enum status
    {
        InStock,
        Reserved,
        Loaned
    }
}
