using System;
using System.Collections.Generic;
using System.IO;
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
        /*public static void LoadDataFromFiles()
        {
            string filePath = Application.StartupPath + "\\data\\";

            LoadMemberFile(File.ReadAllText(filePath + "members.txt").Split(','));
            LoadAssociatedMemberFile(File.ReadAllText(filePath + "associatedMembers.txt").Split(','));
            LoadBooksFile(File.ReadAllText(filePath + "books.txt").Split(','));
            LoadTitleFile(File.ReadAllText(filePath + "titles.txt").Split(','));
            LoadMediaTypeFile(File.ReadAllText(filePath + "mediaTypes.txt").Split(','));
            LoadAuthorsFile(File.ReadAllText(filePath + "authors.txt").Split(','));
            LoadPublisherFile(File.ReadAllText(filePath + "publishers.txt").Split(','));
            LoadGenreFile(File.ReadAllText(filePath + "genres.txt").Split(','));
            LoadThemeFile(File.ReadAllText(filePath + "themes.txt").Split(','));
            LoadBookGenresFile(File.ReadAllText(filePath + "bookGenres.txt").Split(','));
            LoadBookThemesFile(File.ReadAllText(filePath + "bookThemes.txt").Split(','));
            LoadBookCopiesFile(File.ReadAllText(filePath + "bookCopies.txt").Split(','));
            LoadSettingsFile(File.ReadAllText(filePath + "settings.txt").Split(','));
            LoadStaffFile(File.ReadAllText(filePath + "settings.txt").Split(','));
        }
        private static void LoadMemberFile(string[] membersFileContents)
        {
            for (int recordIndex = 0; recordIndex < membersFileContents.Length / 14; recordIndex += 14)
            {
                Member tempMember = new Member();
                int offset = 0;
                tempMember.Barcode = membersFileContents[recordIndex + offset++];
                tempMember.FirstName = membersFileContents[recordIndex + offset++];
                tempMember.LastName = membersFileContents[recordIndex + offset++];
                tempMember.DateOfBirth = membersFileContents[recordIndex + offset++];
                tempMember.CustomerType = (customerType)Convert.ToInt32(membersFileContents[recordIndex + offset++]);
                tempMember.EmailAddress = membersFileContents[recordIndex + offset++];
                tempMember.PhoneNumber = membersFileContents[recordIndex + offset++];
                tempMember.AddressLine1 = membersFileContents[recordIndex + offset++];
                tempMember.AddressLine2 = membersFileContents[recordIndex + offset++];
                tempMember.AddressLine3 = membersFileContents[recordIndex + offset++];
                tempMember.AddressLine4 = membersFileContents[recordIndex + offset++];
                tempMember.AddressLine5 = membersFileContents[recordIndex + offset++];
                tempMember.Postcode = membersFileContents[recordIndex + offset++];
                tempMember.JoinDate = Convert.ToDateTime(membersFileContents[recordIndex + offset++]);
                members.Add(tempMember);
            }
        }
        private static void LoadAssociatedMemberFile(string[] associatedMembersFileContents)
        {
            for (int recordIndex = 0; recordIndex < associatedMembersFileContents.Length / 2; recordIndex += 2)
            {
                foreach (Member memberID in members)
                {
                    if (memberID.Barcode == associatedMembersFileContents[recordIndex])
                        memberID.AssociatedMembers.Add(associatedMembersFileContents[recordIndex + 1]);
                    if (memberID.Barcode == associatedMembersFileContents[recordIndex + 1])
                        memberID.AssociatedMembers.Add(associatedMembersFileContents[recordIndex]);
                }
            }
        }
        private static void LoadBooksFile(string[] booksFileContents)
        {
            for (int recordIndex = 0; recordIndex < booksFileContents.Length / 5; recordIndex += 5)
            {
                Book tempBook = new Book();
                int offset = 0;
                tempBook.ISBN = booksFileContents[recordIndex + offset++];
                tempBook.TitleID = Convert.ToInt32(booksFileContents[recordIndex + offset++]);
                tempBook.SeriesTitle = booksFileContents[recordIndex + offset++];
                tempBook.SeriesNumber = Convert.ToInt32(booksFileContents[recordIndex + offset++]);
                tempBook.MediaTypeID = Convert.ToInt32(booksFileContents[recordIndex + offset++]);
                tempBook.AuthorID = Convert.ToInt32(booksFileContents[recordIndex + offset++]);
                tempBook.PublisherID = Convert.ToInt32(booksFileContents[recordIndex + offset++]);
                tempBook.Description = booksFileContents[recordIndex + offset++];
                tempBook.Price = Convert.ToDecimal(booksFileContents[recordIndex + offset++]);
                books.Add(tempBook);
            }
        }
        private static void LoadTitleFile(string[] titleFileContents)
        {
            for (int recordIndex = 0; recordIndex < titleFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempTitle = new ItemID();
                tempTitle.ID = Convert.ToInt32(titleFileContents[recordIndex]);
                tempTitle.Name = titleFileContents[recordIndex + 1];
                titles.Add(tempTitle);
            }
        }
        private static void LoadMediaTypeFile(string[] mediaTypeFileContents)
        {
            for (int recordIndex = 0; recordIndex < mediaTypeFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempMediaType = new ItemID();
                tempMediaType.ID = Convert.ToInt32(mediaTypeFileContents[recordIndex]);
                tempMediaType.Name = mediaTypeFileContents[recordIndex + 1];
                mediaTypes.Add(tempMediaType);
            }
        }
        private static void LoadAuthorsFile(string[] authorFileContents)
        {
            for (int recordIndex = 0; recordIndex < authorFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempAuthor = new ItemID();
                tempAuthor.ID = Convert.ToInt32(authorFileContents[recordIndex]);
                tempAuthor.Name = authorFileContents[recordIndex + 1];
                authors.Add(tempAuthor);
            }
        }
        private static void LoadPublisherFile(string[] publisherFileContents)
        {
            for (int recordIndex = 0; recordIndex < publisherFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempPublisher = new ItemID();
                tempPublisher.ID = Convert.ToInt32(publisherFileContents[recordIndex]);
                tempPublisher.Name = publisherFileContents[recordIndex + 1];
                publishers.Add(tempPublisher);
            }
        }
        private static void LoadGenreFile(string[] genreFileContents)
        {
            for (int recordIndex = 0; recordIndex < genreFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempGenre = new ItemID();
                tempGenre.ID = Convert.ToInt32(genreFileContents[recordIndex]);
                tempGenre.Name = genreFileContents[recordIndex + 1];
                genres.Add(tempGenre);
            }
        }
        private static void LoadThemeFile(string[] themeFileContents)
        {
            for (int recordIndex = 0; recordIndex < themeFileContents.Length / 2; recordIndex += 2)
            {
                ItemID tempTheme = new ItemID();
                tempTheme.ID = Convert.ToInt32(themeFileContents[recordIndex]);
                tempTheme.Name = themeFileContents[recordIndex + 1];
                themes.Add(tempTheme);
            }
        }
        private static void LoadBookGenresFile(string[] bookGenresFileContents)
        {
            for (int recordIndex = 0; recordIndex < bookGenresFileContents.Length / 2; recordIndex += 2)
            {
                foreach (Book item in books)
                {
                    if (item.ISBN == bookGenresFileContents[recordIndex])
                    {
                        item.GenresID.Add(Convert.ToInt32(bookGenresFileContents[recordIndex + 1]));
                    }
                }
            }
        }
        private static void LoadBookThemesFile(string[] bookThemesFileContents)
        {
            for (int recordIndex = 0; recordIndex < bookThemesFileContents.Length / 2; recordIndex += 2)
            {
                foreach (Book item in books)
                {
                    if (item.ISBN == bookThemesFileContents[recordIndex])
                    {
                        item.ThemesID.Add(Convert.ToInt32(bookThemesFileContents[recordIndex + 1]));
                    }
                }
            }
        }
        private static void LoadBookCopiesFile(string[] bookCopiesFileContents)
        {
            for (int recordIndex = 0; recordIndex < bookCopiesFileContents.Length / 6; recordIndex += 6)
            {
                BookCopy tempBookCopy = new BookCopy();
                int offset = 0;
                tempBookCopy.Barcode = bookCopiesFileContents[recordIndex + offset++];
                tempBookCopy.ISBN = bookCopiesFileContents[recordIndex + offset++];
                tempBookCopy.Status = (status)Convert.ToInt32(bookCopiesFileContents[recordIndex + offset++]);
                tempBookCopy.MemberID = bookCopiesFileContents[recordIndex + offset++];
                tempBookCopy.DueDate = Convert.ToDateTime(bookCopiesFileContents[recordIndex + offset++]);
                tempBookCopy.OverdueEmailSent = Convert.ToBoolean(bookCopiesFileContents[recordIndex + offset++]);
            }
        }
        private static void LoadSettingsFile(string[] SettingsFileContents)
        {

        }
        private static void LoadStaffFile(string[] StaffFileContents)
        {
            for (int recordIndex = 0; recordIndex < StaffFileContents.Length / 4; recordIndex += 4)
            {
                Staff tempStaff = new Staff();
                int offset = 0;
                tempStaff.Username = StaffFileContents[recordIndex + offset++];
                tempStaff.Password = StaffFileContents[recordIndex + offset++];
                tempStaff.EmailAddress = StaffFileContents[recordIndex + offset++];
                tempStaff.IsAdministrator = Convert.ToBoolean(StaffFileContents[recordIndex + offset++]);
            }
        }
        */
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
        enum BookFields
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
