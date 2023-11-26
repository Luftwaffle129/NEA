﻿using NEALibrarySystem.Data_Structures;
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
        /// <summary>
        /// Current feature that the search tab is set to
        /// </summary>
        public SearchedItemsHandler(ListView listview)
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
                    book.Title.Name,
                    book.Isbn,
                    book.MediaType.Name,
                    book.Author.Name,
                    book.Publisher.Name,
                    DataFormatter.ItemBookListToString(book.Genres),
                    DataFormatter.ItemBookListToString(book.Themes)
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
                member.Barcode,
                member.FirstName,
                member.LastName,
                member.Type.ToString()
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
                    columns = new string[4]
                    {
                        "Barcode",
                        "First Name",
                        "Last Name",
                        "Member Type"
                    };
                    break;
                case (DataLibrary.Feature.Book):
                    columns = new string[7]
                    {
                        "Title",
                        "ISBN",
                        "Media Type",
                        "Author",
                        "Publisher",
                        "Genres",
                        "Themes"
                    };
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
    }
}
