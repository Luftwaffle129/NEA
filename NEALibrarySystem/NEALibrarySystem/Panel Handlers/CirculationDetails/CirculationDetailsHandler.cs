using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.CirculationDetails
{
    public class CirculationDetailsHandler
    {

        public CirculationDetailsObjects _objects;
        public CirculationCopy _circCopy;
        public CirculationDetailsHandler(CirculationDetailsObjects objects)
        {
            _objects = objects;
            InitialiseListView();
        }

        private void InitialiseListView()
        {
            // sets properties
            _objects.BookCopy.View = View.Details;
            _objects.BookCopy.LabelEdit = false;
            _objects.BookCopy.AllowColumnReorder = false;
            _objects.BookCopy.CheckBoxes = false;
            _objects.BookCopy.GridLines = false;
            _objects.BookCopy.Sorting = SortOrder.None;
            _objects.BookCopy.HeaderStyle = ColumnHeaderStyle.Clickable;
            _objects.BookCopy.Scrollable = true;

            _objects.DueDate.MinDate = DateTime.Today.AddDays(1);
            // sets columns
            string[] columns;
            columns = new string[]
            {
                "Barcode",
                "ISBN",
                "Title",
                "Series Title",
                "Media Type",
                "Author",
                "Publisher",
                "Genres",
                "Themes"
            };
            ListViewHandler.SetColumns(columns, ref _objects.BookCopy);
        }
        public void Load(CirculationCopy circCopy)
        {
            _circCopy = circCopy;
            _objects.CirculationType.Text = _circCopy.Type.Value.ToString();
            _objects.MemberBarcode.Text = _circCopy.CircMemberRelation.Member.Barcode.Value;
            _objects.MemberName.Text = _circCopy.CircMemberRelation.Member.GetFullName();
            _objects.Date.Text = _circCopy.Date.Value.ToString();
            _objects.DueDate.Text = DataFormatter.GetDate(_circCopy.DueDate.Value);
            Book book = circCopy.BookCopy.BookRelation.Book;
            string[] data =
            {
                circCopy.BookCopy.Barcode.Value,
                book.Isbn.Value,
                book.Title.Value,
                book.SeriesTitle.Value,
                book.MediaType.Value,
                book.Author.Value,
                book.Publisher.Value,
                DataFormatter.ReferenceClassListToString(book.Genres),
                DataFormatter.ReferenceClassListToString(book.Themes)
            };
            _objects.BookCopy.Items.Add(new ListViewItem(data));
            _objects.BookCopy.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void Delete()
        {
            DataLibrary.DeleteCirculationCopy(_circCopy);
            FrmMainSystem.Main.DisplayProcessMessage("Circulation Copy Deleted");
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
        public void Back()
        {
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
