using NEALibrarySystem.Data_Structures;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem.ListViewHandlers
{
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
    }
}
