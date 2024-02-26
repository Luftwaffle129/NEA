using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.CirculationDetails
{
    /// <summary>
    /// Used to handle the processes of the circulation details panel
    /// </summary>
    public class CirculationDetailsHandler
    {
        // objects of the circulation details panel
        private CirculationDetailsObjects _objects;
        private CirculationCopy _circCopy; // record being modified
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
            _objects.BookCopy.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _objects.BookCopy.Scrollable = true;

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
        /// <param name="circCopy">Circulation copy to be modified</param>
        public void Load(CirculationCopy circCopy)
        {
            _circCopy = circCopy;
            _objects.Id.Text = _circCopy.Id.Value.ToString();
            _objects.Type.Text = _circCopy.Type.Value.ToString();
            _objects.MemberBarcode.Text = _circCopy.Member.Barcode.Value;
            _objects.MemberName.Text = _circCopy.Member.GetFullName();
            _objects.Date.Text = DataFormatter.GetDateAndTime(_circCopy.Date.Value);
            _objects.DueDate.Text = DataFormatter.GetDate(_circCopy.DueDate.Value);
            Book book = circCopy.BookCopy.Book;
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
            ListViewHandler.ResizeColumnHeaders(ref _objects.BookCopy);
        }
        /// <summary>
        /// Deletes the circulation copy after the user confirms that the want to delete the record
        /// </summary>
        public void Delete()
        {
            frmConfirmation confirmation = new frmConfirmation("Do you want to delete this circulation record?", Color.Red, SystemColors.ControlLight);
            confirmation.ShowDialog();
            if (confirmation.DialogResult == DialogResult.Yes)
            {
                DataLibrary.DeleteCirculationCopy(_circCopy);
                MessageBox.Show("Circulation Copy Deleted");
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            }
        }
        /// <summary>
        /// Saves the changes to the circulation copy if the change to the due date is valid
        /// </summary>
        public void Save()
        {
            bool isValid = true;
            if (_circCopy.DueDate.Value != _objects.DueDate.Value)
            {
                if (_objects.DueDate.Value <= DateTime.Today)
                    isValid = false;
            }
            if (isValid)
            {
                DataLibrary.CirculationDueDates = DataLibrary.ModifyReferenceClass(DataLibrary.CirculationDueDates, _circCopy, _circCopy.DueDate, out _circCopy.DueDate, _objects.DueDate.Value, SearchAndSort.TwoRefClassCircCopies);
                FileHandler.Save.CirculationCopies();
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            }
            else
            {
                MessageBox.Show("Changed due date cannot be before today");
            }
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
