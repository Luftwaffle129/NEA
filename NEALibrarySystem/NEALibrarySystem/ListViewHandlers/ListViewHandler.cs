using NEALibrarySystem.Data_Structures;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers
{
    /// <summary>
    /// Contains methods for list view handlers
    /// </summary>
    public static class ListViewHandler
    {
        /// <summary>
        /// Sets the inputted columns into the listview
        /// </summary>
        /// <param name="columns">List of column headers to add</param>
        /// <param name="listView">Listview to add the column headers to</param>
        public static void SetColumns(string[] columns, ref ListView listView)
        {
            foreach (string column in columns)
            {
                listView.Columns.Add(column);
            }
        }
        /// <summary>
        /// Sorts the items in the list view depending on the inputted list
        /// </summary> 
        /// 
        /// The sorting column is swapped with the first column so that the comparison method for the list view items does not require another parameter to specify the column
        /// This allows for the list view items to be sorted using the generic quicksort method
        /// 
        /// <param name="listView">List view to sort the items of</param>
        /// <param name="columnIndex">Column index to sort by</param>
        /// <param name="inverted">Value of whether the list will be sorted inverted</param>
        public static void SortListViewItems(ref ListView listView, int columnIndex, bool inverted)
        {
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            if (listView.Items.Count > 0)
            {
                // swap first index with index to sort by and add it to the list of listViewItems
                foreach (ListViewItem item in listView.Items)
                {
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[columnIndex].Text;
                    item.SubItems[columnIndex].Text = temp;
                    listViewItems.Add(item);
                }
                // sort by first the index in ascending order
                SearchAndSort.QuickSort<ListViewItem, ListViewItem>(listViewItems, SearchAndSort.TwoListViewItems);
                // invert list if necessary
                if (inverted)
                    listViewItems = DataFormatter.ReverseList(listViewItems);
                // update listview with new sorted order
                listView.Items.Clear();
                foreach (ListViewItem item in listViewItems)
                {
                    // unswap first index with index to sort by
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[columnIndex].Text;
                    item.SubItems[columnIndex].Text = temp;
                    // add the item to the listview
                    listView.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Resizes the column so that the text displayed is not cut off, except if the column length is longer than 200 pixels
        /// </summary>
        /// <param name="listView">List view to resize the column headers of</param>
        public static void ResizeColumnHeaders(ref ListView listView)
        {
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // auto resize for the column header length
            int[] columnWidths = new int[listView.Columns.Count];               // place the column widths into an array
            for (int i = 0; i < columnWidths.Length; i++)
            {
                columnWidths[i] = listView.Columns[i].Width;
            }
            // auto resize for the column content length
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            for (int i = 0; i < columnWidths.Length; i++) // for each column
            {
                if (listView.Columns[i].Width > 200) // if column is bigger than 200 pixels, reduce width to 200 pixels
                {
                    listView.Columns[i].Width = 200;
                }
                else if (columnWidths[i] > listView.Columns[i].Width) // if the header width is bigger than the column width, set width size to the header.
                {
                    listView.Columns[i].Width = columnWidths[i];
                }
            }
        }
    }
}
