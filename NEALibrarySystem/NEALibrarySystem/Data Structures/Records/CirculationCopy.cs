using NEALibrarySystem.Data_Structures.Records;
using System;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Stores information about a circulated book
    /// </summary>
    public class CirculationCopy
    {
        public const int IDMAXVALUE = 999999999; // used to set the max id value
        public ReferenceClass<int, CirculationCopy> Id { get; set; } // used as the primary key
        public ReferenceClass<DateTime, CirculationCopy> Date { get; set; }
        public ReferenceClass<CirculationType, CirculationCopy> Type { get; set; }
        public BookCopy BookCopy { get; set; }
        public ReferenceClass<DateTime, CirculationCopy> DueDate;
        public bool EmailSent { get; set; }
        public Member Member { get; set; }
        public CirculationCopy(CirculationCopyCreator info)
        {
            int index; // index that the reference class is inserted into
            // ID creation
            int id;
            if (info.Id == -1)
            {
                bool uniqueID = false;
                Random random = new Random();
                do
                {
                    id = random.Next(0, IDMAXVALUE);
                    if (SearchAndSort.Binary(DataLibrary.CirculationIds, id, SearchAndSort.RefClassAndInteger) == -1)
                        uniqueID = true;
                } while (!uniqueID);
            }
            else
                id = info.Id;
            DataLibrary.CirculationIds = DataLibrary.CreateReferenceClass(DataLibrary.CirculationIds, this, id, SearchAndSort.TwoRefClassCircCopies, out index);
            Id = DataLibrary.CirculationIds[index];
            // Date creation
            DateTime date;
            if (info.Date == DateTime.MinValue)
                date = DateTime.Now;
            else
                date = info.Date;
                DataLibrary.CirculationDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDates, this, date, SearchAndSort.TwoRefClassCircCopies, out index);
            Date = DataLibrary.CirculationDates[index];
            // book copy
            BookCopy = info.BookCopy;
            BookCopy.CirculationCopy = this;
            // type
            DataLibrary.CirculationTypes = DataLibrary.CreateReferenceClass(DataLibrary.CirculationTypes, this, info.Type, SearchAndSort.TwoRefClassCircCopies, out index);
            Type = DataLibrary.CirculationTypes[index];
            // due date
            DataLibrary.CirculationDueDates = DataLibrary.CreateReferenceClass(DataLibrary.CirculationDueDates, this, info.DueDate, SearchAndSort.TwoRefClassCircCopies, out index);
            DueDate = DataLibrary.CirculationDueDates[index];
            // Member
            Member = info.Member;
            Member.Circulations.Add(this);

            EmailSent = false;
        }
        /// <summary>
        /// Gets the late fees owed by the user for a book
        /// </summary>
        /// <param name="dueDate"></param>
        /// <returns>late fee</returns>
        public static double GetLateFees(DateTime dueDate)
        {
            if (dueDate.Date >= DateTime.Now.Date) // check if due date has not been passed yet
                return 0;
            else
                return (dueDate - DateTime.Now.Date).TotalDays * Settings.LateFeePerDay; // returns the daily fee * number of days overdue
        }
    }
    public enum CirculationType
    {
        Reserved,
        Loaned
    }
}