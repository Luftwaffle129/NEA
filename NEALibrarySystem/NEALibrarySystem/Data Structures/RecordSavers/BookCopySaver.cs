using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    /// <summary>
    /// Used to convert book copy records into serializable formats to be saved
    /// </summary>
    public class BookCopySaver
    {
        public string Barcode;
        public string Isbn;
    }
}
