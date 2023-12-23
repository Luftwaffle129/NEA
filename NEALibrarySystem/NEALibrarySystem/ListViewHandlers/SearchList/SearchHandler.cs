using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using NEALibrarySystem.ListViewHandlers.SearchList;
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
        private SearchObjects _objects;

        public SearchHandler(SearchObjects objects)
        {
            _objects = objects;
            _objects.ItemViewer.View = View.Details;
            _objects.ItemViewer.LabelEdit = false;
            _objects.ItemViewer.AllowColumnReorder = false;
            _objects.ItemViewer.CheckBoxes = true;
            _objects.ItemViewer.MultiSelect = true;
            _objects.ItemViewer.FullRowSelect = true;
            _objects.ItemViewer.GridLines = false;
            _objects.ItemViewer.Sorting = SortOrder.None;
            _objects.ItemViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _objects.ItemViewer.Scrollable = true;
        }
        #region loading
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
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Book);

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
                    DataFormatter.ListToString(book.Genres),
                    DataFormatter.ListToString(book.Themes)
                };
                ListViewItem row = new ListViewItem(data);
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _objects.Delete.Visible = true;
        }
        public void ToCirculation()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Circulation);

            foreach (CirculationCopy copy in DataLibrary.CirculationCopies)
            {
                string[] data =
                {
                    copy.Id.Value.ToString(),
                    copy.BookCopy.Barcode.Value,
                    copy.BookCopy.BookRelation.Book.Title.Value,
                    copy.BookCopy.BookRelation.Book.SeriesTitle.Value,
                    copy.BookCopy.BookRelation.Book.Author.Value,
                    copy.Date.Value.ToString(),
                    copy.Type.Value.ToString(),
                    DataFormatter.GetDate(copy.DueDate.Value),
                    copy.CircMemberRelation.Member.Barcode.Value.ToString()
                };
                ListViewItem row = new ListViewItem(data);
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _objects.Delete.Visible = true;
        }
        public void ToMember()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Member);

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
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            _objects.Delete.Visible = true;
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
                        "ID",
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
        #endregion
        public void Search()
        {
            
        }
        public void Delete()
        {
            if (_objects.ItemViewer.CheckedItems.Count > 0)
            {
                // output a confirmation message
                string itemType = "";
                frmConfirmation confirmation;
                // get the type of item being deleted
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case DataLibrary.SearchFeature.Member:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "member";
                        else
                            itemType = "members";
                        break;
                    case DataLibrary.SearchFeature.Book:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "book";
                        else
                            itemType = "books";
                        break;
                    case DataLibrary.SearchFeature.Circulation:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "loan/reservation";
                        else
                            itemType = "loans/reservations";
                        break;
                    case DataLibrary.SearchFeature.Staff:
                        itemType = "staff";
                        break;
                }
                // output the confirmation message
                if (_objects.ItemViewer.CheckedItems.Count == 1)
                    confirmation = new frmConfirmation($"Do you want do delete 1 {itemType}?");
                else
                    confirmation = new frmConfirmation($"Do you want do delete {_objects.ItemViewer.CheckedItems.Count} {itemType}?");
                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case DataLibrary.SearchFeature.Member:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteMember(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Book:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteBook(DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Circulation:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteCirculationCopy(DataLibrary.CirculationDates[SearchAndSort.Binary(DataLibrary.CirculationDates, Convert.ToDateTime(item.SubItems[4].Text), SearchAndSort.RefClassAndDate)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Staff:
                            break;
                    }
                    FrmMainSystem.Main.DisplayProcessMessage($"Deleted {itemType}");
                    ToBook();
                }
            }
            else
                MessageBox.Show("No items selected");
        }
    }

}