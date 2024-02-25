using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// stores the data of the members in the library
    /// </summary>
    public class Member
    {
        // member attributes
        public ReferenceClass<string, Member> Barcode;
        public ReferenceClass<string, Member> FirstName;
        public ReferenceClass<string, Member> Surname;
        public DateTime DateOfBirth;
        public string EmailAddress;
        public string PhoneNumber;
        public string Address1;
        public string Address2;
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
        private List<CirculationCopy> _circulations = new List<CirculationCopy>();
        public List<CirculationCopy> Circulations
        {
            get { return _circulations; }
            set { _circulations = value ?? new List<CirculationCopy>(); }    
        }
        /// <summary>
        /// Initialises a member record with the data in a member creator
        /// </summary>
        /// <param name="memberInfo"></param>
        public Member(MemberCreator memberInfo)
        {
            JoinDate = DateTime.Today;
            DateOfBirth = memberInfo.DateOfBirth;
            EmailAddress = memberInfo.EmailAddress;
            PhoneNumber = memberInfo.PhoneNumber;
            Address1 = memberInfo.Address1;
            Address2 = memberInfo.Address2;
            TownCity = memberInfo.TownCity;
            County = memberInfo.County;
            Postcode = memberInfo.Postcode.ToUpper();
            JoinDate = memberInfo.JoinDate == DateTime.MinValue ? DateTime.Now : memberInfo.JoinDate;
            // add reference classes
            int index; // index of the created reference class
            DataLibrary.MemberBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.MemberBarcodes, this, memberInfo.Barcode, SearchAndSort.TwoRefClassMembers, out index);
            Barcode = DataLibrary.MemberBarcodes[index];
            DataLibrary.MemberFirstNames = DataLibrary.CreateReferenceClass(DataLibrary.MemberFirstNames, this, memberInfo.FirstName, SearchAndSort.TwoRefClassMembers, out index);
            FirstName = DataLibrary.MemberFirstNames[index];
            DataLibrary.MemberSurnames = DataLibrary.CreateReferenceClass(DataLibrary.MemberSurnames, this, memberInfo.Surname, SearchAndSort.TwoRefClassMembers, out index);
            Surname = DataLibrary.MemberSurnames[index];
            DataLibrary.MemberTypes = DataLibrary.CreateReferenceClass(DataLibrary.MemberTypes, this, (MemberType)DataFormatter.StringToEnum<MemberType>(memberInfo.Type), SearchAndSort.TwoRefClassMembers, out index);
            Type = DataLibrary.MemberTypes[index];
            if (memberInfo.LinkedMembers.Count > 0)
                foreach (string memberLink in memberInfo.LinkedMembers)
                    LinkedMembers.Add(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, memberLink, SearchAndSort.RefClassAndString)].Reference);
        }
        /// <summary>
        /// Adds a member link to _linkedMembers attribute if it does not already exist in the list
        /// </summary>
        /// <param name="memberBarcode">barcode of the member to link</param>
        public void AddMemberLink(string memberBarcode)
        {
            Member member = DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, memberBarcode, SearchAndSort.RefClassAndString)].Reference;
            if (!LinkedMembers.Contains(member) && memberBarcode != this.Barcode.Value)
            {
                LinkedMembers.Add(member);
                member.LinkedMembers.Add(this);
            }
        }
        /// <summary>
        /// Remove the specified member from the list of linked members
        /// </summary>
        /// <param name="member">member to remove</param>
        public void RemoveMemberLink(Member member)
        {
            member.LinkedMembers.Remove(this);
            LinkedMembers.Remove(member);
        }
        /// <summary>
        /// Concatenates the first name and surname
        /// </summary>
        /// <returns>The first name and surname of the member</returns>
        public string GetFullName()
        {
            return FirstName.Value + " " + Surname.Value;
        }

        /// <summary>
        /// Stores the number of different member types
        /// </summary>
        private static int _typeCount = Enum.GetNames(typeof(MemberType)).Length;
        public static int TypeCount
        {
            get { return _typeCount; }
            private set { _typeCount = value; }
        }
    }
    /// <summary>
    /// Represents the different types of members
    /// </summary>
    public enum MemberType
    {
        Adult,
        Child,
        Elderly,
        Deliverer
    }
}
