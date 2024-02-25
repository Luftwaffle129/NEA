using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class ListViewSortingData
    {
        public int CurrentColumn; // index of the currently selected column in the list view
        public bool SortedDescending; // used to determine if the sorting should be inverted in the column
        public ListViewSortingData() 
        { 
            SortedDescending = false;
            CurrentColumn = 1; // set to one so that when loading, the list is sorted by ascending when initially sorting by the first column
        }
    }
}
