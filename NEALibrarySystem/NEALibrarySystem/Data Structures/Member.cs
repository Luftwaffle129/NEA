using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// stores the data of the members in the library
    /// </summary>
    public class Member
    {
        public string Barcode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string Postcode { get; set; }
        public DateTime JoinDate { get; set; }
        public List<string> AssociatedMembers { get; set; }
        public MemberType Type { get; set; }

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
