using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.SearchList
{
    public class SearchHandler
    {
        private ListView lsvSearch;
        /// <summary>
        /// Current feature that the search tab is set to
        /// </summary>
        public SearchHandler(ListView listview)
        {
            lsvSearch = listview;
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
        public void SetUpSearchTab()
        {
            switch (FrmMainSystem.Main.SearchFeature)
            {
                case DataLibrary.SearchFeature.Book:
                    ToBook();
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    ToCirculation();
                    break;
                case DataLibrary.SearchFeature.Member:
                    ToMember();
                    break;
                case DataLibrary.SearchFeature.Staff:

                    break;
            }
        }
        public void ToBook()
        {
            LoadColumns(ref lsvSearch, DataLibrary.SearchFeature.Book);

            foreach (Book book in DataLibrary.Books)
            {
                string[] data =
                {
                    book.Isbn.Value,
                    book.Title.Value,
                    book.SeriesTitle.Value,
                    book.MediaType.Value,
                    book.Author.Value,
                    book.Publisher.Value,
                    DataFormatter.ReferenceClassListToString(book.Genres),
                    DataFormatter.ReferenceClassListToString(book.Themes)
                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }
            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void ToCirculation()
        {
            LoadColumns(ref lsvSearch, DataLibrary.SearchFeature.Circulation);

            foreach (CirculationCopy copy in DataLibrary.CirculationCopies)
            {
                string[] data =
                {
                    copy.BookCopy.Barcode.Value,
                    copy.BookCopy.BookRelation.Book.Title.Value,
                    copy.BookCopy.BookRelation.Book.SeriesTitle.Value,
                    copy.BookCopy.BookRelation.Book.Author.Value,
                    copy.Date.Value.ToString(),
                    copy.Type.Value.ToString(),
                    copy.DueDate.Value.Date.ToString(),
                    copy.CircMemberRelation.Member.Barcode.Value.ToString(),

                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }
            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void ToMember()
        {
            LoadColumns(ref lsvSearch, DataLibrary.SearchFeature.Member);

            foreach (Member member in DataLibrary.Members)
            {
                string[] data = new string[4]
                {
                member.Barcode.Value,
                member.FirstName.Value,
                member.Surname.Value,
                member.Type.Value.ToString()
                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }

            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public static void LoadColumns(ref ListView lsv, DataLibrary.SearchFeature feature)
        {
            lsv.Clear();

            string[] columns = new string[0];
            switch (feature)
            {
                case DataLibrary.SearchFeature.Member:
                    columns = new string[4]
                    {
                        "Barcode",
                        "First Name",
                        "Surname",
                        "Member type"
                    };
                    break;
                case DataLibrary.SearchFeature.Book:
                    columns = new string[8]
                    {
                        "ISBN",
                        "Title",
                        "Series Title",
                        "Media Type",
                        "Author",
                        "Publisher",
                        "Genres",
                        "Themes"
                    };
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    columns = new string[]
                    {
                        "Barcode",
                        "Title",
                        "Series Title",
                        "Author",
                        "Date",
                        "Status",
                        "Due Date",
                        "Member Barcode"
                    };
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
    }

}