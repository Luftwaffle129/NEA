using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.SearchList
{
    public class SearchedItemsLoader
    {
        private ListView lsvSearch;
        public SearchedItemsLoader(ListView lsv)
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

            AddColumns(columns);

            foreach (Book book in DataLibrary.Books)
            {
                string genres = "";
                string themes = "";

                foreach (string genre in book.GetGenres())
                    genres += genres + ", ";
                if (genres.Length == 2)
                    genres.Remove(genres.Length - 3, 2);
                foreach (string theme in book.GetThemes())
                    themes += theme + ", ";
                if (themes.Length == 2)
                    themes.Remove(themes.Length - 3, 2);

                string[] data = new string[9]
                {
                    book.GetTitle(),
                    book.ISBN,
                    book.GetMediaType(),
                    book.GetAuthor(),
                    book.GetPublisher(),
                    genres,
                    themes,
                    book.Price.ToString(),
                    book.Description
                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }

            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void AddColumns(string[] columns)
        {
            foreach (string column in columns)
            {
                lsvSearch.Columns.Add(column);
            }
        }
    }
}
