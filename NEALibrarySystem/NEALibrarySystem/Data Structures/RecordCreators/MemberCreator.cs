﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public DateTime JoinDate = DateTime.Today;
        public string Type;

        /// <summary>
        /// Validates the data stored in this class
        /// </summary>
        /// <param name="/invalidList">List of invalid data</param>
        /// <param name="original">Original member record</param>
        /// <returns>Boolean result of whether the data is valid</returns>
        public bool Validate(out List<string> invalidList, Member original = null)
        {
            invalidList = new List<string>();
            // barcode - check if it is unique and correct length and contains only digits. If modifying a record, allow creator barcode to be equal to the old barcode
            if (!(Barcode.Length == Settings.MemberBarcodeLength && Regex.IsMatch(Barcode, @"^[0-9]*$"))) // contains only digits
                invalidList.Add("Barcode");
            else
            {
                if (original == null) // if creating a new record
                {
                    if (!(SearchAndSort.Binary(DataLibrary.MemberBarcodes, Barcode, SearchAndSort.RefClassAndString) == -1)) // check that the barcode does not match an existing member barcode
                        invalidList.Add("Barcode");
                }
                else // modifying a record
                {
                    if (!(SearchAndSort.Binary(DataLibrary.MemberBarcodes, Barcode, SearchAndSort.RefClassAndString) == -1 || Barcode == original.Barcode.Value)) // check that the barcode does not match an existing member barcode except its previous barcode
                        invalidList.Add("Barcode");
                }
            }
            // first name - not empty
            if (FirstName.Length == 0)
                invalidList.Add("First Name");
            // surname - not empty
            if (Surname.Length == 0)
                invalidList.Add("Surname");
            // date of birth - cannot be later than join date
            if (DateOfBirth > JoinDate)
                invalidList.Add("Date of Birth");
            // member type
            int eNumIndex = DataFormatter.StringToEnum<MemberType>(Type);
            if (eNumIndex == -1)
                invalidList.Add("Member Type");
            // email address - valid email address
            if (!DataFormatter.IsValidEmail(EmailAddress))
                invalidList.Add("Email Address");
            // phone number - contains the correct characters and correct number of digits
            int digits = Regex.Matches(PhoneNumber, @"[0-9]").Count; // gets the number of digits in the phone number
            if (!( Regex.IsMatch(PhoneNumber, @"^\+*[0-9\- ]*$") && (digits == 10 || digits == 11) )) // checks that the phone number contains a valid number of digits. Regex: start with a + 0 or more times, then digits 0-9 or a hyphen zero or more times
                invalidList.Add("Phone Number");
            // Address 1 - not empty
            if (FirstName.Length == 0)
                invalidList.Add("Address 1");
            // address 2 doesn't have any validation as it may not be required
            // Town/City - not empty
            if (TownCity.Length == 0)
                invalidList.Add("Town/City");
            // County - not empty
            if (County.Length == 0)
                invalidList.Add("County");
            // Postcode - correct format
            if (!Regex.IsMatch(Postcode, @"^[a-zA-Z]{1,2}[0-9][0-9a-zA-Z]? [0-9]{1}[a-zA-Z]{2}$")) // Regex: starts with 1 or 2 letters, then a digit once, then a digit or letter 0 or 1 times, then a space, then a digit once, then two letters
                invalidList.Add("Postcode");
            // linked members - correct length and is an existing member barcode
            if (!ValidateLinkedMembers())
                invalidList.Add("Linked Members");

            return invalidList.Count == 0;
        }
        /// <summary>
        /// Checks that all linked member barcodes are unique, the correct length, contain only digits, and match an existing member's barcode
        /// </summary>
        /// <returns>Boolean result of whether the barcodes are valid</returns>
        private bool ValidateLinkedMembers()
        {
            List<string> seenBarcodes = new List<string>(); // stores values that have already been seen
            foreach (string barcode in LinkedMembers)
            {
                // check that the barcode is the correct length. Returns false if otherwise
                if (!(Barcode.Length == Settings.MemberBarcodeLength && Regex.IsMatch(barcode, @"^[0-9]*$") && SearchAndSort.Binary(DataLibrary.MemberBarcodes, barcode, SearchAndSort.RefClassAndString) != -1 && barcode != Barcode))
                    return false;
                else
                    seenBarcodes.Add(barcode);
            }
            return true;
        }
    }
}
