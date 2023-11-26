using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class CirculationCopy
    {
        public ReferenceClass<BookCopy, CirculationCopy> BookCopy { get; set; }
        public ReferenceClass<Member, CirculationCopy> Member { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> DueDate { get; set; }
        public bool EmailSent { get; set; }
        public CirculationCopy(BookCopy bookCopy, Member member, DateTime dueDate)
        {
            BookCopy = bookCopy;
            Member = member;
            DueDate = dueDate;
        }
    }
}