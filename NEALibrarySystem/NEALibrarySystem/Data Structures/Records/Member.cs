﻿using NEALibrarySystem.Data_Structures.Records;
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

        private List<CircMemberRelation> _circMemberRelation;
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
            AddressLine3 = memberInfo.AddressLine3;
            AddressLine4 = memberInfo.AddressLine4;
            AddressLine5 = memberInfo.AddressLine5;
            Postcode = memberInfo.Postcode;
            int index; // index of the created reference class
            DataLibrary.MemberBarcodes = DataLibrary.CreateReferenceClass(DataLibrary.MemberBarcodes, this, memberInfo.Barcode, SearchAndSort.TwoStrings, out index);
            Barcode = DataLibrary.MemberBarcodes[index];
            DataLibrary.FirstNames = DataLibrary.CreateReferenceClass(DataLibrary.FirstNames, this, memberInfo.FirstName, SearchAndSort.TwoStrings, out index);
            FirstName = DataLibrary.FirstNames[index];
            DataLibrary.LastNames = DataLibrary.CreateReferenceClass(DataLibrary.LastNames, this, memberInfo.LastName, SearchAndSort.TwoStrings, out index);
            LastName = DataLibrary.LastNames[index];
            DataLibrary.MemberType = DataLibrary.CreateReferenceClass(DataLibrary.MemberType, this, memberInfo.Type, SearchAndSort.TwoEnums, out index);
            Type = DataLibrary.MemberType[index];
        }
    }
    public enum MemberType
    {
        Adult,
        Child,
        Deliverer
    }
}
