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
        public TextBox[] Fields;
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
        public enum FieldName
        {
            Title = 0,
            SeriesTitle = 1,
            SeriesNumber = 2,
            ISBN = 3,
            MediaType = 4,
            Author = 5,
            Publisher = 6,
            Genres = 7,
            Themes = 8,
            Description = 9,
            Price = 10
        }
    }
}
