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
    public class SearchItemsHandler
    {
        private ListView lsvSearch;
        /// <summary>
        /// Current feature that the search tab is set to
        /// </summary>
        public SearchItemsHandler(ListView listview)
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
            switch (FrmMainSystem.Main.CurrentFeature)
            {
                case DataLibrary.Feature.Book:
                    ToBook();
                    break;
                case DataLibrary.Feature.Member:
                    ToMember();
                    break;
                case DataLibrary.Feature.Transaction:

                    break;
                case DataLibrary.Feature.Staff:

                    break;
            }
        }
        public void ToBook()
        {
            LoadColumns(ref lsvSearch, DataLibrary.Feature.Book);

            foreach (Book book in DataLibrary.Books)
            {
                string[] data =
                {
                    book.Title.Value,
                    book.Isbn.Value,
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
        public void ToMember()
        {
            LoadColumns(ref lsvSearch, DataLibrary.Feature.Member);

            foreach (Member member in DataLibrary.Members)
            {
                string[] data = new string[4]
                {
                member.Barcode.Value,
                member.FirstName.Value,
                member.LastName.Value,
                member.Type.Value.ToString()
                };
                ListViewItem row = new ListViewItem(data);
                lsvSearch.Items.Add(row);
            }

            lsvSearch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public static void LoadColumns(ref ListView lsv, DataLibrary.Feature feature)
        {
            lsv.Clear();

            string[] columns = new string[0];
            switch (feature)
            {
                case (DataLibrary.Feature.Member):
                    columns = new string[]
                    {
                        GetMemberColumn(0),
                        GetMemberColumn(1),
                        GetMemberColumn(2),
                        GetMemberColumn(3),
                    };
                    break;
                case (DataLibrary.Feature.Book):
                    columns = new string[]
                    {
                        GetBookColumn(0),
                        GetBookColumn(1),
                        GetBookColumn(2),
                        GetBookColumn(3),
                        GetBookColumn(4),
                        GetBookColumn(5),
                        GetBookColumn(6),
                    };
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
        public static string GetBookColumn(int num)
        {
            string column = ((BookColumn)num).ToString();
            if (num == (int)BookColumn.MediaType)
                column = column.Insert(5, " ");
            else if (num == (int)BookColumn.Isbn)
                column = column.ToUpper();
            return column;
        }
        public static string GetMemberColumn(int num)
        {
            string column = ((MemberColumn)num).ToString();
            if (num == (int)MemberColumn.FirstName)
                column = column.Insert(5, " ");
            else if (num == (int)MemberColumn.LastName)
                column = column.Insert(4, " ");
            else if (num == (int)MemberColumn.MemberType)
                column = column.Insert(6, " ");
            return column;
        }
    }
    public enum BookColumn
    {
        Title,
        Isbn,
        MediaType,
        Author,
        Publisher,
        Genres,
        Themes
    }
    public enum BookCopyColumn
    {
        Barcode,
        Status,
        DueDate
    }
    public enum MemberColumn
    {
        Barcode,
        FirstName,
        LastName,
        MemberType
    }
}
