using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Price;
        public int Title;
        public int MediaType;
        public int Author;
        public int Publisher;
        public int[] Genres;
        public int[] Themes;
    }
}
