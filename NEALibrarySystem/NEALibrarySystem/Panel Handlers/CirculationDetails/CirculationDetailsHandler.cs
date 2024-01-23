using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.CirculationDetails
{
    public class CirculationDetailsHandler
    {
        // objects of the circulation details panel
        public CirculationDetailsObjects _objects;
        public CirculationCopy _circCopy; // record being modified
        public CirculationDetailsHandler(CirculationDetailsObjects objects)
        {
            _objects = objects;
            InitialiseListView();
        }
        /// <summary>
        /// Sets up the properties and columns of the lsitview
        /// </summary>
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
        /// <summary>
        /// Set the fields to display the properties of the circulation copy
        /// </summary>
        /// <param name="circCopy">circulation copy to be modified</param>
        public void Load(CirculationCopy circCopy)
        {
            _circCopy = circCopy;
            _objects.Id.Text = _circCopy.Id.Value.ToString();
            _objects.Type.Text = _circCopy.Type.Value.ToString();
            _objects.MemberBarcode.Text = _circCopy.CircMemberRelation.Member.Barcode.Value;
            _objects.MemberName.Text = _circCopy.CircMemberRelation.Member.GetFullName();
            _objects.Date.Text = DataFormatter.GetDateAndTime(_circCopy.Date.Value);
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
                DataFormatter.ListToString(book.Genres),
                DataFormatter.ListToString(book.Themes)
            };
            _objects.BookCopy.Items.Clear();
            _objects.BookCopy.Items.Add(new ListViewItem(data));
            _objects.BookCopy.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        /// <summary>
        /// Deletes the circulation copy
        /// </summary>
        public void Delete()
        {
            DataLibrary.DeleteCirculationCopy(_circCopy);
            FrmMainSystem.Main.DisplayProcessMessage("Circulation Copy Deleted");
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
        /// <summary>
        /// Saves the changes to the circulation copy
        /// </summary>
        public void Save()
        {
            DataLibrary.CirculationDueDates = DataLibrary.ModifyReferenceClass(DataLibrary.CirculationDueDates, _circCopy, _circCopy.DueDate, out _circCopy.DueDate, _objects.DueDate.Value, SearchAndSort.TwoRefClassCircCopies);
            FileHandler.Save.CirculationCopies();
        }
        /// <summary>
        /// Cancels the changes to the circulation copy and opens the search tab
        /// </summary>
        public void Cancel()
        {
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
