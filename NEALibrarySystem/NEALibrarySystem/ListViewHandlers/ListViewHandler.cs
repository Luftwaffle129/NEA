using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
