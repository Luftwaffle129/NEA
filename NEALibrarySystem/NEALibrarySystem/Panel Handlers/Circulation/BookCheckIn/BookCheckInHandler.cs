using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Panel_Handlers.BookCheckIn
{
    public class BookCheckInHandler
    {
        private BookCheckInObjects _objects;
        public BookCheckInHandler(BookCheckInObjects objs) 
        { 
            _objects = objs;
        }
        public void LoadCheckInPanel()
        {
            _objects.MemberName.Text = "";
            _objects.MemberBarcode.Text = "";
            _objects.Loans.Text = "";
            _objects.LateFees.Text = "";
            _objects.Overdue.Text = "";
            _objects.EnterBookBarcodes.Text = "";
            _objects.SelectedBooks.Clear();
        }

    }
}
