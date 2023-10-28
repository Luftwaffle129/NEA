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
        public static void AddColumns(string[] columns, ref ListView listView)
        {
            foreach (string column in columns)
            {
                listView.Columns.Add(column);
            }
        }
    }
}
