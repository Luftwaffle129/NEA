namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    /// <summary>
    /// Used to convert book copy records into serializable formats to be saved
    /// </summary>
    public class BookCopySaver
    {
        public string Barcode;  // stores the barcode of the book copy
        public string Isbn;     // stores the ISBN of the book record that the book copy is from
    }
}