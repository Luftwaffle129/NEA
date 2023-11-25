using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class CirculationCopy
    {
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }
        public DateTime DueDate { get; set; }
        public bool EmailSent { get; set; }
    }
}
