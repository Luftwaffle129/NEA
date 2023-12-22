using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to hold the data for a member record before adding or modifying an existing one
    /// </summary>
    public class MemberCreator
    {
        public string Barcode;
        public string FirstName;
        public string Surname;
        public DateTime DateOfBirth;
        public string EmailAddress;
        public string PhoneNumber;
        public string Address1;
        public string Address2;
        public string TownCity;
        public string County;
        public string Postcode;
        public List<string> LinkedMembers = new List<string>();
        public DateTime JoinDate;
        public MemberType Type;
    }
}
