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

        public List<BookCopy> BookCopies;
        public List<ReferenceClass<CirculationCopy, Book>> CirculationCopies;
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
            DataLibrary.Titles = DataLibrary.CreateReferenceClass(DataLibrary.Titles, this, bookInfo.Title,SearchAndSort.TwoStrings);
            DataLibrary.SeriesTitles = DataLibrary.CreateReferenceClass(DataLibrary.SeriesTitles, this, bookInfo.SeriesTitle, SearchAndSort.TwoStrings);
            DataLibrary.Isbns = DataLibrary.CreateReferenceClass(DataLibrary.Isbns, this, bookInfo.Isbn, SearchAndSort.TwoStrings);
            DataLibrary.Prices = DataLibrary.CreateReferenceClass(DataLibrary.Prices, this, bookInfo.Price, SearchAndSort.TwoDoubles);
            DataLibrary.MediaTypes = DataLibrary.CreateReferenceClass(DataLibrary.MediaTypes, this, bookInfo.MediaType, SearchAndSort.TwoStrings);
            DataLibrary.Authors = DataLibrary.CreateReferenceClass(DataLibrary.Authors, this, bookInfo.Author, SearchAndSort.TwoStrings);
            DataLibrary.Publishers = DataLibrary.CreateReferenceClass(DataLibrary.Publishers, this, bookInfo.Publisher, SearchAndSort.TwoStrings);
            if (bookInfo.Genres.Count > 0)
                foreach (string genre in bookInfo.Genres)
                    DataLibrary.Genres = DataLibrary.CreateReferenceClass(DataLibrary.Genres, this, genre, SearchAndSort.TwoStrings);
            if (bookInfo.Themes.Count > 0)
                foreach (string theme in bookInfo.Themes)
                    DataLibrary.Themes = DataLibrary.CreateReferenceClass(DataLibrary.Themes, this, theme, SearchAndSort.TwoStrings);
        }
    }
}