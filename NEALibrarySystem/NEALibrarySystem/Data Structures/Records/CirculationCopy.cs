using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class CirculationCopy
    {
        public ReferenceClass<DateTime, CirculationCopy> Date { get; set; }
        public ReferenceClass<CirculationType, CirculationCopy> Type { get; set; }
        public BookCopy BookCopy { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> DueDate;
        public bool EmailSent { get; set; }

        public CircMemberRelation CircMemberRelation { get; set; }
        public CirculationCopy(CirculationCopyCreator info)
        {
            int index; // index that the reference class is inserted into
            DataLibrary.CirculationTypes = DataLibrary.CreateReferenceClass(DataLibrary.CirculationTypes, this, info.Type, SearchAndSort.TwoEnums, out index);
            Type = DataLibrary.CirculationTypes[index];
            DataLibrary.CirculationDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDates, this, DateTime.Now, SearchAndSort.TwoDates, out index);
            Date = DataLibrary.CirculationDates[index];
            DataLibrary.CirculationDueDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDueDates, this, info.DueDate, SearchAndSort.TwoDates, out index);
            DueDate = DataLibrary.CirculationDueDates[index];
            CircMemberRelation circMemberRelation = new CircMemberRelation(info.Member, this);
            DataLibrary.CircMemberRelations.Add(circMemberRelation);
            circMemberRelation.Member.CircMemberRelations.Add(circMemberRelation);
            CircMemberRelation = circMemberRelation;
            EmailSent = false;
            DataLibrary.CirculationCopies.Add(this);
        }
    }
    public enum CirculationType
    {
        reserved,
        loaned
    }
}