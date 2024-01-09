using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to pass parameteres to create a new book class
    /// </summary>
    public class BookCreator
    {
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
        /// <returns>Boolean values of whether the attributes are valid to pass into a book record</returns>
        public bool Validate(out List<string> invalidList)
        {
            invalidList = new List<string>();
            // series number - contains only digits, is 1 or above. If empty then set series number to 1
            if (SeriesNumber.Length > 0)
            {
                if (!Regex.IsMatch(SeriesNumber, @"^[0-9]*$"))
                    invalidList.Add("Series Number");
                else if (Convert.ToInt32(SeriesNumber) < 1)
                    invalidList.Add("Series Number");
            }
            else
                SeriesNumber = "1";
            // ISBN - unique and correct length and contains only digits
            if (!(SearchAndSort.Binary(DataLibrary.Isbns, Isbn, SearchAndSort.RefClassAndString) == -1 && Isbn.Length == Settings.ISBNLENGTH && Regex.IsMatch(Isbn, @"^[0-9]*$")))
                invalidList.Add("Isbn");
            // price - in the double format and contains 2 digits after a full stop at the end
            if (!(Double.TryParse(Price, out double price) && Regex.IsMatch(Price, @"^[0-9]*\.[0-9]{2}$")))
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
            // genres - no empty genres
            bool invalidGenre = false;
            foreach (string s in Genres)
                if (s.Length == 0)
                    invalidGenre = true;
            if (invalidGenre)
                invalidList.Add("Genres");
            // themes - no empty themes
            bool invalidTheme = false;
            foreach (string s in Themes)
                if (s.Length == 0)
                    invalidTheme = true;
            if (invalidTheme)
                invalidList.Add("Themes");

            return invalidList.Count > 0 ? false : true;
        }
    }
}
