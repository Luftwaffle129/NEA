using System.Windows.Forms;

namespace NEALibrarySystem
{
    /// <summary>
    /// Used to store the objects used in the member details panel
    /// </summary>
    public class MemberDetailsObjects
    {
        public TextBox Barcode;
        public TextBox FirstName;
        public TextBox Surname;
        public DateTimePicker DateOfBirth;
        public ComboBox MemberType;
        public TextBox LinkedMembers;
        public TextBox EmailAddress;
        public TextBox PhoneNumber;
        public TextBox Address1;
        public TextBox Address2;
        public TextBox TownCity;
        public TextBox County;
        public TextBox PostCode;
        public TextBox JoinDate;
        public ListView Circulations;
        public TextBox LateFees;
    }
}
