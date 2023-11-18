using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NEALibrarySystem
{
    public class Book
    {
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        // single key
        #region Title
        private int titleID;
        public int TitleID
        {
            get
            {
                return titleID;
            }
            set
            {
                titleID = value;
            }
        }
        
        /// <summary>
        /// Gets string title from title data structure
        /// </summary>
        /// <returns>Returns string title</returns>
        public string GetTitle()
        {
            return GetNameFromID(DataLibrary.Titles, TitleID);
        }
        /// <summary>
        /// Sets ID from the inputted string title
        /// </summary>
        /// <param name="title">name of the title</param>
        public void SetTitle(string title)
        {
            List<ItemID> titles = DataLibrary.Titles;
            titleID = SetIDFromName(ref titles, title);
            DataLibrary.Titles = titles;
        }
        #endregion
        #region MediaType
        private int mediaTypeID { get; set; }
        public int MediaTypeID
        {
            get
            {
                return mediaTypeID;
            }
            set
            {
                mediaTypeID = value;
            }
        }
        /// <summary>
        /// Gets string media type from media type data structure
        /// </summary>
        /// <returns>Returns string media type</returns>
        public string GetMediaType()
        {
            return GetNameFromID(DataLibrary.MediaTypes, MediaTypeID);
        }
        /// <summary>
        /// Sets ID from the inputted string media type
        /// </summary>
        /// <param name="mediaType">name of media type</param>
        public void SetMediaType(string mediaType)
        {
            List<ItemID> mediaTypes = DataLibrary.MediaTypes;
            mediaTypeID = SetIDFromName(ref mediaTypes, mediaType);
            DataLibrary.MediaTypes = mediaTypes;
        }
        #endregion
        #region Author
        private int authorID;
        public int AuthorID
        {
            get
            {
                return authorID;
            }
            set
            {
                authorID = value;
            }
        }
        /// <summary>
        /// Gets string author name from author data structure
        /// </summary>
        /// <returns>Returns string of author name</returns>
        public string GetAuthor()
        {
            return GetNameFromID(DataLibrary.Authors, AuthorID);
        }
        /// <summary>
        /// Sets the ID for the inputted author name
        /// </summary>
        /// <param name="author">string of author name</param>
        public void SetAuthor(string author)
        {
            List<ItemID> authors = DataLibrary.Authors;
            authorID = SetIDFromName(ref authors, author);
            DataLibrary.Authors = authors;
        }
        #endregion
        #region Publisher
        private int publisherID;
        public int PublisherID
        {
            get
            {
                return publisherID;
            }
            set
            {
                publisherID = value;
            }
        }
        /// <summary>
        /// Gets string of publisher name from publisher data structure
        /// </summary>
        /// <returns>Returns string publisher name</returns>
        public string GetPublisher()
        {
            return GetNameFromID(DataLibrary.Publishers, publisherID);
        }
        /// <summary>
        /// Sets Id of the inputted publisher name
        /// </summary>
        /// <param name="publisher">name of the publisher</param>
        public void SetPublisher(string publisher)
        {
            List<ItemID> publishers = DataLibrary.Publishers;
            publisherID = SetIDFromName(ref publishers, publisher);
            DataLibrary.Publishers = publishers;
        }
        #endregion
        // list of keys
        #region Genres
        private List<int> genresID = new List<int>();
        public List<int> GenreIDs
        {
            get
            {
                return genresID;
            }
            set
            {
                genresID = value;
            }
        }
        /// <summary>
        /// Gets the list of genre names from the IDs
        /// </summary>
        /// <returns>List of genre names</returns>
        public List<string> GetGenres()
        {
            return GetItemIDList(GenreIDs, DataLibrary.Genres);
        }
        /// <summary>
        /// Sets a the List of IDs from the inputted list of genre names
        /// </summary>
        /// <param name="input">List of genre names</param>
        public void SetGenres(List<string> input)
        {
            List<ItemID> genres = DataLibrary.Genres;
            GenreIDs = SetItemIDList(input, ref genres);
            DataLibrary.Genres = genres;
        }
        #endregion
        #region Themes
        private List<int> themesID = new List<int>();
        public List<int> ThemeIDs
        {
            get
            {
                return themesID;
            }
            set
            {
                themesID = value;
            }
        }
        /// <summary>
        /// Gets the list of theme names from the IDs
        /// </summary>
        /// <returns>List of theme names</returns>
        public List<string> GetThemes()
        {
            return GetItemIDList(ThemeIDs, DataLibrary.Themes);
        }
        /// <summary>
        /// Sets a the List of IDs from the inputted list of theme names
        /// </summary>
        /// <param name="input">List of theme names</param>
        public void SetThemes(List<string> input)
        {
            List<ItemID> themes = DataLibrary.Themes;
            ThemeIDs = SetItemIDList(input, ref themes);
            DataLibrary.Themes = themes;
        }
        #endregion
        // list of classes
        private List<BookCopy> bookCopies = new List<BookCopy>();
        public List<BookCopy> BookCopies
        {
            get { return bookCopies; }
            set { bookCopies = value ?? new List<BookCopy>(); }
        }

        /// <summary>
        /// Outputs a list of strings from a ItemID list using the inputted IDs
        /// </summary>
        /// <param name="IDList">List of IDs</param>
        /// <param name="ItemIDList">List of ItemIDs</param>
        /// <returns>List of item names</returns>
        /// 
        private List<string> GetItemIDList(List<int> IDList, List<ItemID> ItemIDList)
        {
            List<string> output = new List<string>();
            foreach (int ID in IDList)
            {
                string temp = GetNameFromID(ItemIDList, ID);
                if (temp != "")
                    output.Add(temp);
            }
            return output;
        }
        /// <summary>
        /// Outputs a list of IDs from a ItemID list using the inputted strings
        /// </summary>
        /// <param name="itemList">list of names to set the IDs of</param>
        /// <param name="ItemIDList">List of ItemIDs</param>
        /// <returns>List of item IDs</returns>
        private List<int> SetItemIDList(List<string> itemList, ref List<ItemID> ItemIDList)
        {
            List<int> output = new List<int>();

            foreach (string item in itemList)
            {
                output.Add(SetIDFromName(ref ItemIDList, item));
            }
            return output;
        }

        /// <summary>
        /// Retrieves the name of the item with the inputted ID
        /// </summary>
        /// <param name="list">The list containing the items</param>
        /// <param name="ID">The ID to search for in list</param>
        /// <param name="name">the name of the datatype. Used for error messages</param>
        /// <returns>Returns the string linked to the ID inputted</returns>
        private string GetNameFromID(List<ItemID> list, int ID)
        {
            foreach (ItemID item in list)
            {
                if (item.ID == ID)
                {
                    return item.Name;
                }
            }
            return "";
        }
        /// <summary>
        /// Outputs the ID linked to the name. If no ID is found, creates a new ID linked to the name.
        /// </summary>
        /// <param name="list">The list containing the items</param>
        /// <param name="name">The name to find ID of or create an ID for</param>
        private int SetIDFromName(ref List<ItemID> list, string name)
        {
            // finds if the name is already stored. Returns the name's ID if it is
            int index = 0;
            if (list.Count > 0)
            {
                do
                {
                    if (list[index].Name == name)
                    {
                        return list[index].ID;
                    }
                } while (++index < list.Count);
            }
            // if an existing item is not found:
            int ID = 0;
            ItemID temp = new ItemID();
            temp.Name = name;
            // insert new item in the ID if there is a gap
            if (list.Count > 0)
            {
                // increments through each ID starting from 0
                do
                {
                    index = 0;
                    bool isGap = true;
                    //loops through each element in the list
                    do
                    {
                        if (list[index].ID == ID)
                        {
                            isGap = false;
                        }
                        index++;
                    }
                    while (index < list.Count && isGap);
                    temp.ID = ID;
                    if (isGap)
                    {
                        list.Add(temp);
                        return temp.ID;
                    }
                } while (++ID < list.Count);
            }
            // if no gaps, append new item
            temp.ID = ID;
            list.Add(temp);
            return temp.ID;
        }
        #region Constructors
        public Book() { }
        /// <summary>
        /// Constructor for getting records from the binary files
        /// </summary>
        /// <param name="bookSaver">record to load</param>
        public Book(BookSaver bookSaver)
        {
            titleID = bookSaver.TitleID;
            SeriesNumber = bookSaver.SeriesNumber;
            SeriesTitle = bookSaver.SeriesTitle;
            Description = bookSaver.Description;
            Price = bookSaver.Price;
            MediaTypeID = bookSaver.MediaTypeID;
            AuthorID = bookSaver.authorID;
            publisherID = bookSaver.publisherID;
            GenreIDs = bookSaver.genresID.ToList();
            themesID = bookSaver.themesID.ToList();
            if (bookSaver.bookCopies != null)
            {
                foreach (BookCopySaver bookCopySaver in bookSaver.bookCopies)
                {
                    bookCopies.Add(new BookCopy(bookCopySaver));
                }
            }
        }
        #endregion
    }
}