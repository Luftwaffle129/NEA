using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.SearchList
{
    public class SearchedItemsHandler
    {
        private ListView lsvSearch;
        public SearchedItemsHandler(ListView lsv)
        {
            lsvSearch = lsv;
            lsvSearch.View = View.Details;
            lsvSearch.LabelEdit = false;
            lsvSearch.AllowColumnReorder = false;
            lsvSearch.CheckBoxes = true;
            lsvSearch.MultiSelect = true;
            lsvSearch.FullRowSelect = true;
            lsvSearch.GridLines = false;
            lsvSearch.Sorting = SortOrder.None;
            lsvSearch.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvSearch.Scrollable = true;
        }
        public void ToBook()
        {
            lsvSearch.Clear();
            string[] columns =
            {
                "Title",
                "ISBN",
                "Media Type",
                "Author",
                "Publisher",
                "Genres",
                "Themes",
                "price",
                "description"
            };

            ListViewHandler.AddColumns(columns, ref lsvSearch);

            foreach (Book book in DataLibrary.Books)
            {
                string[] data = new string[9]
                {
                    book.GetTitle(),
                    book.ISBN,
                    book.GetMediaType(),
                    book.GetAuthor(),
                    book.GetPublisher(),
                    DataFormatter.ListToString(book.GetGenres()),
                    DataFormatter.ListToString(book.GetThemes()),
                    book.Price.ToString(),
                    book.Description
                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }

            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void updatedSelectedItems()
        {

        }
    }
}
