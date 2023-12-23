using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NEALibrarySystem.ListViewHandlers
{
    public static class ListViewHandler
    {
        /// <summary>
        /// Sets the inputted columns into the listview
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="listView"></param>
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
        /// <param name="listView">list view to sort the items of</param>
        /// <param name="columnIndex">column index to sort by</param>
        public static void SortListViewItems(ref ListView listView, int columnIndex, bool inverted)
        {
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            if (listView.Items.Count > 0)
            {
                // swap first index with index to sort by
                foreach (ListViewItem item in listView.Items)
                {
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[columnIndex].Text;
                    item.SubItems[columnIndex].Text = temp;
                    listViewItems.Add(item);
                }
                // sort by first the index ascending
                SearchAndSort.QuickSort<ListViewItem, ListViewItem>(listViewItems, SearchAndSort.TwoListViewItems);
                // unswap first index with index to sort by
                foreach (ListViewItem item in listViewItems)
                {
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[columnIndex].Text;
                    item.SubItems[columnIndex].Text = temp;
                }
                // invert list if necessary
                if (inverted)
                    listViewItems = DataFormatter.ReverseList(listViewItems);
                // update listview with new listViewItem order
                listView.Items.Clear();
                foreach (ListViewItem item in listViewItems)
                    listView.Items.Add(item);
            }
        }
    }
}
