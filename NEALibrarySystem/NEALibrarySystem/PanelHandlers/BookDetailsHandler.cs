using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NEALibrarySystem.PanelHandlers
{
    public class BookDetailsHandler
    {
        private BookDetailsObjects objects;
        public BookDetailsHandler(BookDetailsObjects objs) 
        {
            objects = objs;
        }
        
        public void AddBookCopies()
        {
            List<string> newBarcodes = new List<string>();
            frmAddBookCopies frmAddBookCopies = new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
            newBarcodes = frmAddBookCopies.DialogResult == ;
            new
        }
    }
}
