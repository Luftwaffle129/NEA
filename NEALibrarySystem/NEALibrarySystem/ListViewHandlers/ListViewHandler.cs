using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace NEALibrarySystem.ListViewHandlers
{
    /// <summary>
    /// Contains methods for list view handlers
    /// </summary>
    public static class ListViewHandler
    {
        // colours for the item rows in a list view
        private static Color _normalColorBright = SystemColors.ControlLightLight;
        private static Color _normalColorDark = SystemColors.ControlLight;
        private static Color _warningColorBright = Color.FromArgb(0xFF,0x43,0x43); // Light red
        private static Color _warningColorDark = Color.FromArgb(0xFF, 0x00, 0x00); // Red

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
        public delegate void ColourListView(ref ListView listView);
        /// <summary>
        /// Colours the list view items in an alternating pattern
        /// </summary>
        /// <param name="listView"></param>
        public static void ColourListViewNormal(ref ListView listView)
        {
            int index = -1;
            while (++index < listView.Items.Count)
            {
                if (index % 2 == 0)
                    listView.Items[index].BackColor = _normalColorBright;
                else
                    listView.Items[index].BackColor = _normalColorDark;
            }
        }
        /// <summary>
        /// Specifically for circulation list views. 
        /// Colours the list view items in an alternating pattern. 
        /// If a record is overdue, colour it red.
        /// </summary>
        /// <param name="listView"></param>
        public static void ColourListViewOverdue(ref ListView listView)
        {
            int index = -1;
            while (++index < listView.Items.Count)
            {
                if (SearchAndSort.TwoStrings(listView.Items[index].SubItems[7].Text, listView.Items[index].SubItems[5].Text.Substring(0, listView.Items[index].SubItems[7].Text.Length)) != Greatest.Right) // checks if the book is not overdue
                { 
                    // if not overdue, set the normal colour pattern
                    if (index % 2 == 0)
                        listView.Items[index].BackColor = _normalColorBright;
                    else
                        listView.Items[index].BackColor = _normalColorDark;
                }
                else
                {
                    // if overdue, set warning colour pattern
                    if (index % 2 == 0)
                        listView.Items[index].BackColor = _warningColorBright;
                    else
                        listView.Items[index].BackColor = _warningColorDark;
                }
            }
        }
        #region sorting
        /// <summary>
        /// Sorts the items in the list view depending on the inputted list
        /// </summary> 
        /// 
        /// The sorting column is swapped with the first column so that the comparison method for the list view items does not require another parameter to specify the column
        /// This allows for the list view items to be sorted using the generic quicksort method
        /// 
        /// <param name="listView">List view to sort</param>
        /// <param name="column">Column to sort by</param>
        /// <param name="currentColumn">Previous column sorted by</param>
        /// <param name="descending">Whether the column is currently in descending order</param>
        public static void SortListView(ref ListView listView, int column, ref ListViewSortingData listViewSorting, ColourListView colourListView)
        {
            if (listViewSorting.CurrentColumn == column) // if the current column selected is the same as the current column being sorted by
                listViewSorting.SortedDescending = !listViewSorting.SortedDescending; // inverts the boolean variable _inverted sort
            else
            {
                listViewSorting.CurrentColumn = column;
                listViewSorting.SortedDescending = false;
            }

            // sort the list view items
            List<ListViewItem> listViewSorter = new List<ListViewItem>();
            if (listView.Items.Count > 0)
            {
                // swap first index with index to sort by and add it to the list of listViewItems
                foreach (ListViewItem item in listView.Items)
                {
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[column].Text;
                    item.SubItems[column].Text = temp;
                    listViewSorter.Add(item);
                }
                // sort by first the index in ascending order
                SearchAndSort.QuickSort<ListViewItem, ListViewItem>(listViewSorter, SearchAndSort.TwoListViewItems);
                // invert list if necessary
                if (listViewSorting.SortedDescending)
                    listViewSorter = DataFormatter.ReverseList(listViewSorter);
                // update listview with new sorted order
                listView.Items.Clear();
                foreach (ListViewItem item in listViewSorter)
                {
                    // unswap first index with index to sort by
                    string temp = item.SubItems[0].Text;
                    item.SubItems[0].Text = item.SubItems[column].Text;
                    item.SubItems[column].Text = temp;
                    // add the item to the listview
                    listView.Items.Add(item);
                }
            }

            colourListView(ref listView);
        }
        #endregion
    }
}
