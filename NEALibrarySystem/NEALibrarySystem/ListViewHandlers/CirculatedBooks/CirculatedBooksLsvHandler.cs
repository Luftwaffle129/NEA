using NEALibrarySystem.ListViewHandlers.CirculatedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers.SelectedItems
{
    public class CirculatedBooksLsvHandler
    {
        private ListView listView;

        public CirculatedBooksLsvHandler(ListView lsv, bool priceNeeded)
        {
            listView = lsv;
            InitialiseListView(priceNeeded);
        }
        private void InitialiseListView(bool PriceNeeded)
        {
            listView.View = View.Details;
            listView.LabelEdit = false;
            listView.AllowColumnReorder = false;
            listView.CheckBoxes = true;
            listView.MultiSelect = true;
            listView.FullRowSelect = true;
            listView.GridLines = false;
            listView.Sorting = SortOrder.None;
            listView.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView.Scrollable = true;

            string[] columns =
            {
                "Barcode",
                "Title",
                "Series Title",
                "Author"
            };
            if (PriceNeeded)
            {
                string[] tempColumns = new string[columns.Length + 1];
                for (int index = 0; index < tempColumns.Length; index++)
                {
                    tempColumns[index] = columns[index];
                }
                tempColumns[tempColumns.Length - 1] = "Price";
            }
        }
        public void UpdateListView(List<CirculatedBook> circulatedBooks)
        {
            listView.Items.Clear();
            foreach (var circulatedBook in circulatedBooks)
            {
                string[] data =
                {
                    circulatedBook.Barcode,
                    circulatedBook.Title,
                    circulatedBook.SeriesTitle,
                    circulatedBook.Author,
                    circulatedBook.Price
                };
                ListViewItem row = new ListViewItem(data);
                listView.Items.Add(row);
            }
        }
    }
}
