using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// stores the data of the members in the library
    /// </summary>
    public class Member
    {
        public ReferenceClass<string, Member> Barcode;
        public ReferenceClass<string, Member> FirstName;
        public ReferenceClass<string, Member> LastName;
        public string DateOfBirth;
        public string EmailAddress;
        public string PhoneNumber;
        public string AddressLine1;
        public string AddressLine2;
        public string AddressLine3;
        public string AddressLine4;
        public string AddressLine5;
        public string Postcode;
        public DateTime JoinDate;
        public ReferenceClass<MemberType, Member> Type;
        public Member()
        {
            JoinDate = DateTime.Today;
        }
    }
    public enum MemberType
    {
        Adult,
        Child,
        Deliverer
    }
}
