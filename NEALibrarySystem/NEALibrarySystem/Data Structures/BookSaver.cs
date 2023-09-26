using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace NEALibrarySystem.Data_Structures
{
    [System.Serializable]
    public class BookSaver
    {
        public BookSaver(Book book) 
        {
            SeriesTitle = book.SeriesTitle;
            SeriesNumber = book.SeriesNumber;
            ISBN = book.ISBN;
            Description = book.Description;
            Price = book.Price;
            TitleID = book.TitleID;
            MediaTypeID = book.MediaTypeID;
            authorID = book.AuthorID;
            publisherID = book.PublisherID;
            genresID = book.GenresID.ToArray();
            themesID = book.ThemesID.ToArray();
        }
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MediaTypeID { get; set; }
        public int TitleID { get; set; }
        public int authorID {  get; set; }
        public int publisherID {  get; set; }
        public int[] genresID { get; set; }
        public int[] themesID { get; set; }
    }
}
