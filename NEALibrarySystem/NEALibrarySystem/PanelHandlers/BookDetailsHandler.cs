using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.PanelHandlers
{
    public class BookDetailsHandler
    {
        private BookDetailsObjects objects;
        private Book bookData;
        public BookDetailsHandler(BookDetailsObjects objs) 
        {
            objects = objs;
            bookData = new Book();
        }
        
        public void AddBookCopies()
        {
            string[] newBarcodes;
            frmAddBookCopies frmAddBookCopies = new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
            if (frmAddBookCopies.DialogResult == DialogResult.OK)
            {
                newBarcodes = frmAddBookCopies.barcodes;
            }
        }
    }
}
