using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    public class MemberCreator
    {
        public string Barcode;
        public string FirstName;
        public string Surname;
        public string DateOfBirth;
        public string EmailAddress;
        public string PhoneNumber;
        public string AddressLine1;
        public string AddressLine2;
        public string TownCity;
        public string County;
        public string Postcode;
        public List<string> LinkedMembers = new List<string>();
        public DateTime JoinDate;
        public MemberType Type;
    }
}
