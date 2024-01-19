namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Stores smallest item with a reference index
    /// </summary>
    public class SmallestItem<T> where T : class
    {
        public T Item; // smallest book
        public int Index; // column of the smallest book

        public SmallestItem(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }
}
