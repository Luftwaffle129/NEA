using NEALibrarySystem.Data_Structures.RecordCreators;

namespace NEALibrarySystem.Data_Structures
{
    public class Staff
    {
        public ReferenceClass<string, Staff> FirstName;
        public ReferenceClass<string, Staff> Surname;
        public ReferenceClass<string, Staff> Username;
        public string Password;
        public ReferenceClass<string, Staff> EmailAddress;
        public bool IsAdministrator;

        // constructors
        public Staff() { }
        public Staff(StaffCreator creator)
        {
            Password = creator.Password;
            IsAdministrator = creator.IsAdministrator;
            // create reference classes
            DataLibrary.StaffUsernames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffUsernames, this, creator.Username, SearchAndSort.TwoRefClassStaff, out int index);
            Username = DataLibrary.StaffUsernames[index];
            DataLibrary.StaffFirstNames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffFirstNames, this, creator.FirstName, SearchAndSort.TwoRefClassStaff, out index);
            FirstName = DataLibrary.StaffFirstNames[index];
            DataLibrary.StaffSurnames = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffSurnames, this, creator.Surname, SearchAndSort.TwoRefClassStaff, out index);
            Surname = DataLibrary.StaffSurnames[index];
            DataLibrary.StaffEmails = DataLibrary.CreateReferenceClass<string, Staff>(DataLibrary.StaffEmails, this, creator.EmailAddress, SearchAndSort.TwoRefClassStaff, out index);
            EmailAddress = DataLibrary.StaffEmails[index];
        }
    }
}
