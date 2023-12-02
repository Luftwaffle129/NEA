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
        public ReferenceClass<DateTime, CirculationCopy> DueDate { get; set; }
        public bool EmailSent { get; set; }

        public CircMemberRelation CircMemberRelation { get; set; }
        public CirculationCopy(CirculationCopyCreator info)
        {
            DataLibrary.CirculationTypes = DataLibrary.CreateReferenceClass(DataLibrary.CirculationTypes, this, info.Type, SearchAndSort.TwoEnums);
            DataLibrary.CirculationDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDates, this, DateTime.Now, SearchAndSort.TwoDates);
            DataLibrary.CirculationDueDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDueDates, this, info.DueDate, SearchAndSort.TwoDates);

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