using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    internal class Book2
    {
        public string Title { get; set; }
        public string SeriesTitle { get; set; }
        public string SeriesNumber { get; set; }
        public string ISBN { get; set; }
        public string MediaType { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Themes { get; set; }
    }
}
