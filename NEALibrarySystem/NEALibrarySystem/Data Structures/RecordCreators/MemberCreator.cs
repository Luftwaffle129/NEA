using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        public string Type;

        public bool Validate(out List<string> invalidList)
        {
            invalidList = new List<string>();
            // barcode - check if it is unique
            if (!(Barcode.Length == Settings.MemberBarcodeLength && SearchAndSort.Binary(DataLibrary.MemberBarcodes, Barcode, SearchAndSort.RefClassAndString) == -1))
                invalidList.Add("Barcode");
            // first name - not empty
            if (FirstName.Length == 0)
                invalidList.Add("First Name");
            // surname - not empty
            if (Surname.Length == 0)
                invalidList.Add("Surname");
            // member type
            int eNumIndex = DataFormatter.StringToEnum<MemberType>(Type);
            if (eNumIndex != -1)
                invalidList.Add("Member Type");
            // email address - valid email address
            if (!Regex.IsMatch(EmailAddress, @"^[\w -\.]+@([\w-]+\.)+[\w-]{ 2,4}$"))
                invalidList.Add("Email Address");
            // phone number - contains the correct characters
            if (!Regex.IsMatch(PhoneNumber, @"^\+*[0-9\- ]*$"))
                invalidList.Add("Phone Number");
            // Address 1 - not empty
            if (FirstName.Length == 0)
                invalidList.Add("Address 1");
            // address 2 doesnt have any validation as it may not be required
            // Town/City - not empty
            if (TownCity.Length == 0)
                invalidList.Add("Town/City");
            // County - not empty
            if (County.Length == 0)
                invalidList.Add("County");
            // Postcode - correct format
            if (!Regex.IsMatch(Postcode, @"^[A-Z]{1,2}[0-9][0-9A-Z]? [0-9]{1}[A-Z]{2}$"))
                invalidList.Add("Postcode");
            // linked members - correct length and is an existing member barcode
            bool invalidMember = false;
            foreach (string member in LinkedMembers)
                if (!(Barcode.Length == Settings.MemberBarcodeLength && SearchAndSort.Binary(DataLibrary.MemberBarcodes, Barcode, SearchAndSort.RefClassAndString) != -1))
                    invalidMember = true;
            if (invalidMember)
                invalidList.Add("Linked Members");

            return invalidList.Count > 0 ? false : true;
        }
    }
}
