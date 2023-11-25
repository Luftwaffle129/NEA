using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to pass parameteres to create a new book class
    /// </summary>
    public class BookCreator
    {
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
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
    }
}
