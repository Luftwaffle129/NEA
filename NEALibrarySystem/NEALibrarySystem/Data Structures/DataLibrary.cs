using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Stores the records and methods to access their data
    /// </summary>
    public static class DataLibrary
    {
        #region data structures
        #region books
        private static List<Book> _books = new List<Book>();
        public static List<Book> Books
        {
            get { return _books; }
            set { _books = value ?? new List<Book>(); }
        }
        #endregion
        #region bookSearchResults
        private static List<string> _bookSearchResults = new List<string>();
        public static List<string> BookSearchResults
        {
            get { return _bookSearchResults; }
            set { _bookSearchResults = value ?? new List<string>();}
        }
        #endregion
        #region members
        private static List<Member> _members = new List<Member>();
        public static List<Member> Members
        {
            get { return _members; }
            set { _members = value ?? new List<Member>(); }
        }
        #endregion
        #region titles
        private static List<ItemID> _titles = new List<ItemID>();
        public static List<ItemID> Titles
        { 
            get { return _titles; } 
            set { _titles = value ?? new List<ItemID>(); }
        }
        #endregion
        #region mediaTypes
        private static List<ItemID> _mediaTypes = new List<ItemID>();
        public static List<ItemID> MediaTypes
        {
            get { return _mediaTypes; }
            set { _mediaTypes = value ?? new List<ItemID>(); }
        }
        #endregion
        #region author
        private static List<ItemID> _authors = new List<ItemID>();
        public static List<ItemID> Authors
        {
            get { return _authors; }
            set { _authors = value ?? new List<ItemID>(); }
        }
        #endregion
        #region publishers
        private static List<ItemID> _publishers = new List<ItemID>();
        public static List<ItemID> Publishers
        {
            get { return _publishers; }
            set { _publishers = value ?? new List<ItemID>(); }
        }
        #endregion
        #region genres
        private static List<ItemID> _genres = new List<ItemID>();
        public static List<ItemID> Genres
        {
            get { return _genres; }
            set { _genres = value ?? new List<ItemID>(); }
        }
        #endregion
        #region themes
        private static List<ItemID> _themes = new List<ItemID>();
        public static List<ItemID> Themes
        {
            get { return _themes; }
            set { _themes = value ?? new List<ItemID>(); }
        }
        #endregion
        #region staff
        private static List<Staff> _staff = new List<Staff>();
        public static List<Staff> Staff
        {
            get { return _staff; }
            set { _staff = value ?? new List<Staff>(); }
        }
        #endregion
        #region selectedBooks
        private static List<Book> _selectedBooks = new List<Book>();
        public static List<Book> SelectedBooks
        {
            get { return _selectedBooks; }
            set { _selectedBooks = value ?? new List<Book>(); }
        }
        #endregion
        #region transactions
        private static List<Transaction> _transactions = new List<Transaction>();
        public static List<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value ?? new List<Transaction>(); }
        }
        #endregion
        #endregion
        #region Deleting records
        /// <summary>
        /// Deletes the book record with the inputted ISBN
        /// </summary>
        /// <param name="ISBN">ISBN of book to be deleted</param>
        public static void DeleteBook(string ISBN)
        {
            int index = 0;
            bool isBookRemoved = false;
            Book removedBook = new Book();
            // find the record and remove it
            do
            {
                if (DataLibrary.Books[index].ISBN == ISBN)
                {
                    removedBook = DataLibrary.Books[index];
                    DataLibrary.Books.RemoveAt(index);
                    isBookRemoved = true;
                }
            } while (++index < DataLibrary.Books.Count && !isBookRemoved);

            // removes the removed book's Title from DataLibrary.Titles if it is no longer used
            List<int> usedTitleIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    usedTitleIDs.Add(book.TitleID);
                }
            }
            List<ItemID> tempTitles = DataLibrary.Titles;
            RemoveUnnecessaryItemID(ref tempTitles, usedTitleIDs, removedBook.TitleID);
            DataLibrary.Titles = tempTitles;

            // removes the removed book's media type from DataLibrary.MediaTypes if it is no longer used
            List<int> usedMediaTypeIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    usedMediaTypeIDs.Add(book.MediaTypeID);
                }
            }
            List<ItemID> tempMediaTypes = DataLibrary.MediaTypes;
            RemoveUnnecessaryItemID(ref tempMediaTypes, usedMediaTypeIDs, removedBook.MediaTypeID);
            DataLibrary.MediaTypes = tempMediaTypes;

            // removes the removed book's author from DataLibrary.Authors if it is no longer used
            List<int> usedAuthorIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    usedAuthorIDs.Add(book.AuthorID);
                }
            }
            List<ItemID> tempAuthors = DataLibrary.Authors;
            RemoveUnnecessaryItemID(ref tempAuthors, usedAuthorIDs, removedBook.AuthorID);
            DataLibrary.Authors = tempAuthors;

            // removes the removed book's publishers from DataLibrary.Publishers if it is no longer used
            List<int> usedPublisherIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    usedPublisherIDs.Add(book.PublisherID);
                }
            }
            List<ItemID> tempPublishers = DataLibrary.Publishers;
            RemoveUnnecessaryItemID(ref tempPublishers, usedPublisherIDs, removedBook.PublisherID);
            DataLibrary.Publishers = tempPublishers;

            // removes the removed book's genres from DataLibrary.Genres if it they no longer used
            List<int> usedGenreIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    foreach (int ID in book.GenreIDs)
                    {
                        usedGenreIDs.Add(ID);
                    }
                }
            }
            List<ItemID> tempGenres = DataLibrary.Genres;
            foreach (int ID in removedBook.GenreIDs)
            {
                RemoveUnnecessaryItemID(ref tempGenres, usedGenreIDs, ID);
            }
            DataLibrary.Genres = tempGenres;

            // removes the removed book's themes from DataLibrary.Themes if it they no longer used
            List<int> usedThemeIDs = new List<int>();
            if (DataLibrary.Books.Count > 0)
            {
                foreach (Book book in DataLibrary.Books)
                {
                    foreach (int ID in book.ThemeIDs)
                    {
                        usedThemeIDs.Add(ID);
                    }
                }
            }
            List<ItemID> tempThemes = DataLibrary.Themes;
            foreach (int ID in removedBook.ThemeIDs)
            {
                RemoveUnnecessaryItemID(ref tempThemes, usedThemeIDs, ID);
            }
            DataLibrary.Themes = tempThemes;
        }
        /// <summary>
        /// Deletes the member record with the inputted member barcode
        /// </summary>
        /// <param name="barcode">member barcode of member to be deleted</param>
        public static void DeleteMember(string barcode)
        {
            if (DataLibrary.Members.Count > 0)
            {
                // locates the member by their barcode and deletes the record
                for (int index = 0; index < DataLibrary.Members.Count; index++)
                {
                    if (DataLibrary.Members[index].Barcode == barcode)
                    {
                        DataLibrary.Members.RemoveAt(index);
                    }
                    else
                    {
                        // removes the removed member from any associations to other members
                        if (DataLibrary.Members[index].AssociatedMembers.Count > 0)
                        {
                            for (int index2 = 0; index2 < DataLibrary.Members[index].AssociatedMembers.Count; index2++)
                            {
                                if (DataLibrary.Members[index].AssociatedMembers[index2] == barcode)
                                {
                                    DataLibrary.Members[index].AssociatedMembers.RemoveAt(index2);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Removes the itemID from the list if it is not linked to any other records
        /// </summary>
        /// <param name="itemIDList">List containing the ItemID that might be removed</param>
        /// <param name="usedIDs">List of IDs that are being used by records</param>
        /// <param name="ID">The ID of the ItemID that might be removed</param>
        public static void RemoveUnnecessaryItemID(ref List<ItemID> itemIDList, List<int> usedIDs, int ID)
        {
            int index = 0;
            bool used = false;
            do
            {
                if (ID == usedIDs[index])
                {
                    used = true;
                }
            } while (++index < usedIDs.Count && !used);
            if (!used)
            {
                // find and delete the itemID record
                index = 0;
                bool isRemoved = false;
                do
                {
                    if (ID == itemIDList[index].ID)
                    {
                        itemIDList.RemoveAt(index);
                    }
                } while (++index < itemIDList.Count && !isRemoved);
            }
        }
        #endregion
        #region enums
        public enum Feature
        {
            Book = 0,
            Member = 1,
            Transaction = 2,
            Staff = 3,
            Statistics = 4,
            Backups = 5,
            Settings = 6,
            None = -1
        }
        #endregion
        #region file handling
        /// <summary>
        /// creates the directory to save the data fields to
        /// </summary>
        public static void CreateDataDirectory()
        {
            Directory.CreateDirectory(Application.StartupPath + "\\data");
        }
        #region Load Files
        private static string DataFilePath = Application.StartupPath + "\\data\\";
        /// <summary>
        /// Reads all files and load data into the appropiate data structures
        /// </summary>
        public static void LoadAllFiles()
        {
            LoadBooksFile();
            Titles = LoadItemIDFile("titles");
            MediaTypes = LoadItemIDFile("mediaTypes");
            Authors = LoadItemIDFile("authors");
            Publishers = LoadItemIDFile("publishers");
            Genres = LoadItemIDFile("genres");
            Themes = LoadItemIDFile("themes");
        }
        public static void LoadBooksFile()
        {
            BookSaverCollection bookSaverCollection = FileHandler.LoadFile<BookSaverCollection>(DataFilePath, "books");
            if (bookSaverCollection != null)
            {
                foreach (BookSaver bookSaver in bookSaverCollection.Collection)
                {
                    Book temp = new Book(bookSaver);
                    Books.Add(temp);
                }
            }
        }
        private static List<ItemID> LoadItemIDFile(string fileName)
        {
            List<ItemID> Output = new List<ItemID>();
            ItemIDSaverCollection itemIDSaverCollection = FileHandler.LoadFile<ItemIDSaverCollection>(DataFilePath, fileName);
            if (itemIDSaverCollection != null)
            {
                foreach (ItemIDSaver itemIDSaver in itemIDSaverCollection.Collection)
                {
                    ItemID temp = new ItemID(itemIDSaver);
                    Output.Add(temp);
                }
            }
            return Output;
        }
        #endregion
        #region Save Files
        public static void SaveAllFiles(string filePath = null)
        {
            SaveBooksFile(filePath);
            SaveItemIDFile(Titles, "titles", filePath);
            SaveItemIDFile(MediaTypes, "mediaTypes", filePath);
            SaveItemIDFile(Authors, "authors", filePath);
            SaveItemIDFile(Publishers, "publishers", filePath);
            SaveItemIDFile(Genres, "genres", filePath);
            SaveItemIDFile(Themes, "themes", filePath);
        }
        public static void SaveBooksFile(string filePath = null)
        {
            if (filePath == null)
                filePath = DataFilePath;
            BookSaverCollection bookSaverCollection = new BookSaverCollection(DataLibrary.Books);
            FileHandler.SaveFile<BookSaverCollection>(bookSaverCollection, filePath, "books");
        }
        private static void SaveItemIDFile(List<ItemID> itemIDs, string name = null, string filePath = null)
        {
            if (filePath == null)
                filePath = DataFilePath;
            ItemIDSaverCollection itemIDSaverCollection = new ItemIDSaverCollection(itemIDs);
            FileHandler.SaveFile<ItemIDSaverCollection>(itemIDSaverCollection, filePath, name);
        }
        #endregion
        #endregion
        #region data handling
        #region Searching

        #endregion
        #region Sorting
        public static void SortBooks()
        {

        }
        private enum BookFields
        {
            Title,
            ISBN,
            MediaType,
            Author,
            Publisher,
            Genres,
            Themes
        }
        #endregion
        #region filtering

        #endregion
        #endregion
    }
}
