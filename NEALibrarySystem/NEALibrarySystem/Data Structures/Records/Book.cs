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
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        private ItemBook _title;
        public ItemBook Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private ItemBook _mediaType;
        public ItemBook MediaType
        {
            get { return _mediaType; }
            set { _mediaType = value; }
        }
        public ItemBook Author { get; set; }
        public ItemBook Publisher { get; set; }
        private List<ItemBook> _genres = new List<ItemBook>();
        public List<ItemBook> Genres
        {
            get { return _genres; }
            set { _genres = value ?? new List<ItemBook>(); }
        }
        private List<ItemBook> _themes = new List<ItemBook>();
        public List<ItemBook> Themes
        {
            get { return _themes; }
            set { _themes = value ?? new List<ItemBook>(); }
        }
        /// <summary>
        /// Creates a new book record from the data in bookCreator
        /// </summary>
        /// <param name="bookInfo">information to create a new book record</param>
        public Book(BookCreator bookInfo)
        {
            SeriesTitle = bookInfo.SeriesTitle;
            SeriesNumber = bookInfo.SeriesNumber;
            Isbn = bookInfo.Isbn;
            Description = bookInfo.Description;
            Price = bookInfo.Price;
            // add title
            List<ItemBook> tempItemBookList = DataLibrary.Titles;
            Title = tempItemBookList[AddItemBook(ref tempItemBookList, bookInfo.Title)];
            DataLibrary.Titles = tempItemBookList;
            // add media type
            tempItemBookList = DataLibrary.MediaTypes;
            MediaType = tempItemBookList[AddItemBook(ref tempItemBookList, bookInfo.MediaType)];
            DataLibrary.MediaTypes = tempItemBookList;
            // add author
            tempItemBookList = DataLibrary.Authors;
            Author = tempItemBookList[AddItemBook(ref tempItemBookList, bookInfo.Author)];
            DataLibrary.Authors = tempItemBookList;
            // add media type
            tempItemBookList = DataLibrary.Publishers;
            Publisher = tempItemBookList[AddItemBook(ref tempItemBookList, bookInfo.Publisher)];
            DataLibrary.Publishers = tempItemBookList;
            // add genres
            if (bookInfo.Genres.Count > 0)
            {
                tempItemBookList = DataLibrary.Genres;
                foreach (string genre in bookInfo.Genres)
                {
                    // add add genre element
                    Genres.Add(tempItemBookList[AddItemBook(ref tempItemBookList, genre)]);
                }
                DataLibrary.Genres = tempItemBookList;
            }
            // add themes
            if (bookInfo.Themes.Count > 0)
            {
                tempItemBookList = DataLibrary.Themes;
                foreach (string theme in bookInfo.Themes)
                {
                    // add add theme element
                    Themes.Add(tempItemBookList[AddItemBook(ref tempItemBookList, theme)]);
                }
                DataLibrary.Themes = tempItemBookList;
            }
        }
        /// <summary>
        /// Adds a reference to this book into a existing itemBook with the matching text or into a new itemBook
        /// </summary>
        /// <param name="itemBookList">list of item books to add the book information to</param>
        /// <param name="text"></param>
        /// <returns>Index the item was added at</returns>
        public int AddItemBook(ref List<ItemBook> itemBookList, string text)
        {
            // add book reference to an existing item if possible
            if (itemBookList.Count > 0)
            {
                int itemIndex = Search.GetFoundIndex(itemBookList, text);
                if (itemIndex != -1) // if there is an existing itemBook class
                {
                    itemBookList[itemIndex].Books.Add(this);
                    return itemIndex;
                }
            }
            // else create a new itemBook class
            ItemBook itemBook = new ItemBook(text);
            itemBook.Books.Add(this);
            return DataLibrary.InsertItemBook(ref itemBookList, itemBook);
        }
    }
}