using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    [System.Serializable]
    /// <summary>
    /// Used to convert circulation copy records into serializable formats to be saved
    /// </summary>
    public class CirculationCopySaver
    {
        public int Id;
        public int Type;
        public string BookCopyBarcode;
        public string MemberBarcode;
        public DateTime DueDate;
        public DateTime Date;
    }
}
