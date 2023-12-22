using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// stores the data of the members in the library
    /// </summary>
    public class Member
    {
        public ReferenceClass<string, Member> Barcode;
        public ReferenceClass<string, Member> FirstName;
        public ReferenceClass<string, Member> Surname;
        public string DateOfBirth;
        public string EmailAddress;
        public string PhoneNumber;
        public string AddressLine1;
        public string AddressLine2;
        public string TownCity;
        public string County;
        public string Postcode;
        public DateTime JoinDate;
        public ReferenceClass<MemberType, Member> Type;

        private List<Member> _linkedMembers = new List<Member>();
        public List<Member> LinkedMembers
        {
            get { return _linkedMembers; }
            set { _linkedMembers = value ?? new List<Member>(); }
        }

        private List<CircMemberRelation> _circMemberRelation = new List<CircMemberRelation>();
        public List<CircMemberRelation> CircMemberRelations
        {
            get { return _circMemberRelation; }
            set { _circMemberRelation = value ?? new List<CircMemberRelation>(); }    
        }
        public Member(MemberCreator memberInfo)
        {
            JoinDate = DateTime.Today;
            DateOfBirth = memberInfo.DateOfBirth;
            EmailAddress = memberInfo.EmailAddress;
            PhoneNumber = memberInfo.PhoneNumber;
            AddressLine1 = memberInfo.AddressLine1;
            AddressLine2 = memberInfo.AddressLine2;
            TownCity = memberInfo.TownCity;
            County = memberInfo.County;
            Postcode = memberInfo.Postcode;
            JoinDate = memberInfo.JoinDate == null ? DateTime.Now : memberInfo.JoinDate;
            int index; // index of the created reference class
            DataLibrary.MemberBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.MemberBarcodes, this, memberInfo.Barcode, SearchAndSort.TwoRefClassMembers, out index);
            Barcode = DataLibrary.MemberBarcodes[index];
            DataLibrary.FirstNames = DataLibrary.CreateReferenceClass(DataLibrary.FirstNames, this, memberInfo.FirstName, SearchAndSort.TwoRefClassMembers, out index);
            FirstName = DataLibrary.FirstNames[index];
            DataLibrary.Surnames = DataLibrary.CreateReferenceClass(DataLibrary.Surnames, this, memberInfo.Surname, SearchAndSort.TwoRefClassMembers, out index);
            Surname = DataLibrary.Surnames[index];
            DataLibrary.MemberTypes = DataLibrary.CreateReferenceClass(DataLibrary.MemberTypes, this, memberInfo.Type, SearchAndSort.TwoRefClassMembers, out index);
            Type = DataLibrary.MemberTypes[index];
            if (memberInfo.LinkedMembers.Count > 0)
                foreach (string memberLink in memberInfo.LinkedMembers)
                    LinkedMembers.Add(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, memberLink, SearchAndSort.RefClassAndString)].Reference);
        }
        public void AddMemberLink(string memberBarcode)
        {
            Member member = DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, memberBarcode, SearchAndSort.RefClassAndString)].Reference;
            LinkedMembers.Add(member);
            member.LinkedMembers.Add(this);
        }
        public void RemoveMemberLink(Member member)
        {
            member.LinkedMembers.Remove(this);
            LinkedMembers.Remove(member);
        }
        public string GetFullName()
        {
            return FirstName.Value + " " + Surname.Value;
        }
        public static int TypeCount
        {
            get { return Enum.GetNames(typeof(MemberType)).Length; }
        }
    }
    public enum MemberType
    {
        Adult,
        Child,
        Elderly,
        Deliverer
    }
}
