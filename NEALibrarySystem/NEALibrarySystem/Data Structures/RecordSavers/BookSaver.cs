namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    /// <summary>
    /// Used to convert book records into serializable formats to be saved
    /// </summary>
    public class BookSaver
    {
        public string SeriesTitle;
        public int SeriesNumber;
        public string Isbn;
        public string Description;  
        public int Price;       // holds the index of the double stored in the price file
        public int Title;       // holds the index of the string stored in the title file
        public int MediaType;   // holds the index of the string stored in the media type file
        public int Author;      // holds the index of the string stored in the author file
        public int Publisher;   // holds the index of the string stored in the publisher file
        public int[] Genres;    // holds the indexes of the strings stored in the genres file
        public int[] Themes;    // holds the indexes of the strings stored in the genres file
    }
}
