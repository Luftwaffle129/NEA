﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to pass parameters to create or modify a book class
    /// </summary>
    public class BookCreator
    {
        // all attributes are strings to store the text from user inputs
        public string SeriesTitle { get; set; }
        public string SeriesNumber { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        private List<string> _genres = new List<string>();
        public List<string> Genres
        {
            get { return _genres; }
            set { _genres = value ?? new List<string>(); }
        }
        private List<string> _themes = new List<string>();
        public List<string> Themes
        {
            get { return _themes; }
            set { _themes = value ?? new List<string>(); }
        }

        /// <summary>
        /// Validates the values for creating a new book
        /// </summary>
        /// <param name="invalidList">List of invalid attributes</param>
        /// <returns>Boolean value of whether the attributes are valid to pass into a book record</returns>
        public bool Validate(out List<string> invalidList, Book original = null)
        {
            invalidList = new List<string>();
            // series number - contains only digits, is 1 or above. If empty then set series number to 1
            if (SeriesNumber.Length > 0)
            {
                if (!Regex.IsMatch(SeriesNumber, @"^[0-9]*$")) // if the input is not an integer
                    invalidList.Add("Series Number");
                else if (Convert.ToInt32(SeriesNumber) < 1) // if the input is below 1
                    invalidList.Add("Series Number");
            }
            else
                SeriesNumber = "1"; // if no input
            // ISBN - unique and correct length and contains only digits. If modifying a record, allow creator ISBN to be equal to the old ISBN
            if (!(Isbn.Length == Settings.ISBNLENGTH && Regex.IsMatch(Isbn, @"^[0-9]*$")))
                invalidList.Add("Isbn");
            else
            {
                if (original == null) // if creating a new record
                {
                    if (!(SearchAndSort.Binary(DataLibrary.Isbns, Isbn, SearchAndSort.RefClassAndString) == -1)) // check that the ISBN does not match an existing ISBN
                        invalidList.Add("Isbn");
                }
                else // modifying a book record
                {
                    if (!(SearchAndSort.Binary(DataLibrary.Isbns, Isbn, SearchAndSort.RefClassAndString) == -1 || Isbn == original.Isbn.Value)) // check that the ISBN does not match an existing ISBN except the previous ISBN
                        invalidList.Add("Isbn");
                }
            }
            // price - in the double format and contains 2 digits after a full stop at the end
            if (!Regex.IsMatch(Price, @"^[0-9]*\.[0-9]{2}$")) // starts with 0 or more digits, then a period, then 2 digits
                invalidList.Add("Price");
            // title - is not empty
            if (Title.Length == 0)
                invalidList.Add("Title");
            // media type - is not empty
            if (MediaType.Length == 0)
                invalidList.Add("Media Type");
            // author - is not empty
            if (Author.Length == 0)
                invalidList.Add("Author");
            // publisher - is not empty
            if (Publisher.Length == 0)
                invalidList.Add("Publisher");
            // genres
            if (!ValidateGenreTheme(Genres))
                invalidList.Add("Genres");
            // themes
            if (!ValidateGenreTheme(Themes))
                invalidList.Add("Themes");
            return invalidList.Count == 0;
        }
        /// <summary>
        /// Check that no phrases are empty or occur more than once in the list of strings, and contains only letters, numbers, hyphens and spaces
        /// </summary>
        /// <param name="strings">List of genres or themes</param>
        /// <returns>Boolean value of whether the list of genres or themes are valid</returns>
        private bool ValidateGenreTheme(List<string> strings)
        {
            List<string> seenStrings = new List<string>(); // stores values that have already been seen
            foreach (string s in strings)
            {
                // check that the phrase is not empty, it does not occur more than once in the list of strings, and contains only letters, numbers, hyphens and spaces. Returns false if otherwise
                if (s.Length == 0 || seenStrings.Contains(s) | !Regex.IsMatch(s, @"^[a-zA-Z0-9 -]*$"))
                    return false;
                else
                    seenStrings.Add(s);
            }
            return true;
        }
    }
}
