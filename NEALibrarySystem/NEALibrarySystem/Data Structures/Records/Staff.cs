using NEALibrarySystem.Data_Structures.RecordCreators;

namespace NEALibrarySystem.Data_Structures
{
    public class Staff
    {
        public ReferenceClass<string, Staff> FirstName { get; set; }
        public ReferenceClass<string, Staff> Surname { get; set; }
        public ReferenceClass<string, Staff> Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdministrator { get; set; }

        // constructors
        public Staff() { }
        public Staff(StaffCreator creator)
        {
            Password = creator.Password;
            EmailAddress = creator.EmailAddress;
            IsAdministrator = creator.IsAdministrator;
            // create reference classes
            DataLibrary.StaffUsernames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffUsernames, this, creator.Username, SearchAndSort.TwoRefClassStaff, out int index);
            Username = DataLibrary.StaffUsernames[index];
            DataLibrary.StaffFirstNames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffFirstNames, this, creator.FirstName, SearchAndSort.TwoRefClassStaff, out index);
            FirstName = DataLibrary.StaffFirstNames[index];
            DataLibrary.StaffSurnames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffSurnames, this, creator.Surname, SearchAndSort.TwoRefClassStaff, out index);
            Surname = DataLibrary.StaffSurnames[index];
        }
    }
}
