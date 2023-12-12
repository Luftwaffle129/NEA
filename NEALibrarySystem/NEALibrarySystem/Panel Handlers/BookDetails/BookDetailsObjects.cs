using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NEALibrarySystem.PanelHandlers
{
    public class BookDetailsObjects
    {
        // book details
        public ListView CopyDetails;
        public TextBox InStock;
        public TextBox Reserved;
        public TextBox Loaned;
        /* buttons
        public Button AddBookCopies;
        public Button DeleteBookCopies;
        public Button Save;
        public Button Cancel;
        */

        public TextBox Title;
        public TextBox SeriesTitle;
        public TextBox SeriesNumber;
        public TextBox Isbn;
        public TextBox MediaType;
        public TextBox Author;
        public TextBox Publisher;
        public TextBox Genres;
        public TextBox Themes;
        public TextBox Description;
        public TextBox Price;
    }
}
