using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    public class BookSaver
    {
        public string SeriesTitle;
        public int SeriesNumber;
        public string Isbn;
        public string Description;  
        public double Price;
        public string Title;
        public string MediaType;
        public string Author;
        public string Publisher;
        public string[] Genres;
        public string[] Themes;

        public BookSaver() { }
        public BookSaver(Book book)
        {
            Title = book.Title.Value;
            SeriesTitle = book.SeriesTitle.Value;
            SeriesNumber = book.SeriesNumber;
            Isbn = book.Isbn.Value;
            Description = book.Description;
            Price = book.Price.Value;
            MediaType = book.MediaType.Value;
            Author = book.Author.Value;
            Publisher = book.Publisher.Value;

            Genres = new string[book.Genres.Count];
            for (int i = 0; i < book.Genres.Count; i++)
                Genres[i] = book.Genres[i].Value;

            Themes = new string[book.Themes.Count];
            for (int i = 0; i < book.Themes.Count; i++)
                Themes[i] = book.Themes[i].Value;
        }
    }
}
