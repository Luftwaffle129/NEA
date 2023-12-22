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
        public ReferenceClass<int, CirculationCopy> Id { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> Date { get; set; }
        public ReferenceClass<CirculationType, CirculationCopy> Type { get; set; }
        public BookCopy BookCopy { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> DueDate;
        public bool EmailSent { get; set; }
        public CircMemberRelation CircMemberRelation { get; set; }
        public CirculationCopy(CirculationCopyCreator info)
        {
            int index; // index that the reference class is inserted into

            int id;
            bool uniqueID = false;
            Random random = new Random();
            do
            {
                id = random.Next(0, 999999999);
                if (SearchAndSort.Binary(DataLibrary.CirculationIds, id, SearchAndSort.RefClassAndInteger) == -1)
                    uniqueID = true;
            } while (!uniqueID);
            DataLibrary.CirculationIds = DataLibrary.CreateReferenceClass(DataLibrary.CirculationIds, this, id, SearchAndSort.TwoRefClassCircCopies, out index);
            
            DataLibrary.CirculationDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDates, this, DateTime.Now, SearchAndSort.TwoRefClassCircCopies, out index);
            Date = DataLibrary.CirculationDates[index];
            BookCopy = info.BookCopy;
            BookCopy.CirculationCopy = this;
            DataLibrary.CirculationTypes = DataLibrary.CreateReferenceClass(DataLibrary.CirculationTypes, this, info.Type, SearchAndSort.TwoRefClassCircCopies, out index);
            Type = DataLibrary.CirculationTypes[index];
            DataLibrary.CirculationDueDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDueDates, this, info.DueDate, SearchAndSort.TwoRefClassCircCopies, out index);
            DueDate = DataLibrary.CirculationDueDates[index];
            CircMemberRelation circMemberRelation = new CircMemberRelation(info.Member, this);
            DataLibrary.CircMemberRelations.Add(circMemberRelation);
            circMemberRelation.Member.CircMemberRelations.Add(circMemberRelation);
            CircMemberRelation = circMemberRelation;
            EmailSent = false;
        }
    }
    public enum CirculationType
    {
        Reserved,
        Loaned
    }
}