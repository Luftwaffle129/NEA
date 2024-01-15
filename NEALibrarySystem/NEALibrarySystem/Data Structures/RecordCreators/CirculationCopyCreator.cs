using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to hold the data required for creating a circulation copy
    /// </summary>
    public class CirculationCopyCreator
    {
        public int Id = -1;
        public CirculationType Type;
        public BookCopy BookCopy;
        public Member Member;
        public DateTime DueDate;
        public DateTime Date = DateTime.MinValue;
    }
}
