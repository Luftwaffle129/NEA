using System;

namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    /// <summary>
    /// Used to convert member records into serializable formats to be saved
    /// </summary>
    public class MemberSaver
    {
        public string Barcode;
        public string FirstName;
        public string Surname;
        public DateTime DateOfBirth;
        public string[] LinkedMembers;
        public string EmailAddress;
        public string PhoneNumber;
        public string Address1;
        public string Address2;
        public string TownCity;
        public string County;
        public string Postcode;
        public DateTime JoinDate;
        public int Type;
    }
}
