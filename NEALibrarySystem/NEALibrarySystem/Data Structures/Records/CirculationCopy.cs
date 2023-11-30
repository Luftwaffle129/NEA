using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class CirculationCopy
    {
        public ReferenceClass<CirculationType, CirculationCopy> Type { get; set; }
        public ReferenceClass<BookCopy, CirculationCopy> BookCopy { get; set; }
        public ReferenceClass<Member, CirculationCopy> Member { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> Date { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> DueDate { get; set; }
        public bool EmailSent { get; set; }
        public CirculationCopy(CirculationType type, BookCopy bookCopy, Member member, DateTime dueDate)
        {
            DataLibrary.CirculationTypes = DataLibrary.CreateReferenceClass(DataLibrary.CirculationTypes, this, type, SearchAndSort.TwoEnums);
            DataLibrary.CirculationDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDates, this, DateTime.Now, SearchAndSort.TwoDates);
            DataLibrary.CirculationDueDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDueDates, this, dueDate, SearchAndSort.TwoDates);

            EmailSent = false;
        }
    }
    public enum CirculationType
    {
        reserved,
        loaned
    }
}