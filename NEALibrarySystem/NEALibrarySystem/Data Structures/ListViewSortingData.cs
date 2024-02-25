namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Used to hold the sorting information for a list view
    /// </summary>
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
