namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Used to store the smallest item with a reference index. Used in broad searches
    /// </summary>
    public class SmallestItem<T> where T : class
    {
        public T Item; // smallest item
        public int Index; // column of the smallest item

        public SmallestItem(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }
}
