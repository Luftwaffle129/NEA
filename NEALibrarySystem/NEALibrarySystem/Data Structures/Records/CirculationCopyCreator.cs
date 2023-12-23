using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
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
