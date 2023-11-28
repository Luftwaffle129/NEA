using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// stores the information about a book
    /// </summary>
    public class Book
    {
        public int SeriesNumber;
        public string Description;
        public ReferenceClass<string, Book> Title;
        public ReferenceClass<string, Book> SeriesTitle;
        public ReferenceClass<string, Book> Isbn;
        public ReferenceClass<double, Book> Price;
        public ReferenceClass<string, Book> MediaType;
        public ReferenceClass<string, Book> Author;
        public ReferenceClass<string, Book> Publisher;
        public List<ReferenceClass<string, Book>> Genres;
        public List<ReferenceClass<string, Book>> Themes;

        public List<ReferenceClass<CirculationCopy, Book>> Loans;
        public List<ReferenceClass<CirculationCopy, Book>> Reservations;
        public Book() { }
        /// <summary>
        /// Creates a new book record from the data in a BookCreator class
        /// </summary>
        /// <param name="bookInfo">information to create a new book record</param>
        public Book(BookCreator bookInfo)
        {
            // set the attributes that are not referenced
            SeriesNumber = bookInfo.SeriesNumber;
            Description = bookInfo.Description;
            // set the referenced attributes
            DataLibrary.Titles = DataLibrary.AddReferenceClass(DataLibrary.Titles, this, bookInfo.Title);
            DataLibrary.SeriesTitles = DataLibrary.AddReferenceClass(DataLibrary.SeriesTitles, this, bookInfo.SeriesTitle);
            DataLibrary.Isbns = DataLibrary.AddReferenceClass(DataLibrary.Isbns, this, bookInfo.Isbn);
            DataLibrary.Prices = DataLibrary.AddReferenceClass(DataLibrary.Prices, this, bookInfo.Price);
            DataLibrary.MediaTypes = DataLibrary.AddReferenceClass(DataLibrary.MediaTypes, this, bookInfo.MediaType);
            DataLibrary.Authors = DataLibrary.AddReferenceClass(DataLibrary.Authors, this, bookInfo.Author);
            DataLibrary.Publishers = DataLibrary.AddReferenceClass(DataLibrary.Publishers, this, bookInfo.Publisher);
            if (bookInfo.Genres.Count > 0)
                foreach (string genre in bookInfo.Genres)
                    DataLibrary.Genres = DataLibrary.AddReferenceClass(DataLibrary.Genres, this, genre);
            if (bookInfo.Themes.Count > 0)
                foreach (string theme in bookInfo.Themes)
                    DataLibrary.Themes = DataLibrary.AddReferenceClass(DataLibrary.Themes, this, theme);
        }
    }
}