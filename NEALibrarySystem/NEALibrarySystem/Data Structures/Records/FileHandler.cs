using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.Data_Structures.RecordSavers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Data_Structures
{
    // default file path: Application.StartupPath + "\\data\\"

    /// <summary>
    /// Saves and loads files
    /// </summary>
    public static class FileHandler
    {
        public static string filePath;
        public static void InitialiseFilePath()
        {
             filePath = Application.StartupPath + "\\Data\\";
        }
        /// <summary>
        /// Saves file
        /// </summary>
        /// <typeparam name="FileType">Type of data structure</typeparam>
        /// <param name="data">Contents of the data structure</param>
        /// <param name="filePath">Path to save the file</param>
        /// <param name="fileName">Name of the file</param>
        private static void SaveFile<FileType>(FileType data, string filePath, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath + fileName + ".bin", FileMode.Create);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        /// <summary>
        /// Loads a binary files contents into the specified data structure format
        /// </summary>
        /// <typeparam name="FileType">data structure format of the file</typeparam>
        /// <param name="filePath">Path to load the file from</param>
        /// <param name="fileName">Name and type of the file</param>
        /// <returns>Returns the contents of the file</returns>
        private static FileType LoadFile<FileType>(string filePath, string fileName)
        {
            if (File.Exists(filePath + fileName + ".bin")) 
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filePath + fileName + ".bin", FileMode.Open);
                FileType data = default(FileType);

                if (stream.Length != 0)
                    data = (FileType)formatter.Deserialize(stream);
                stream.Close();

                return data;
            }
            else 
            {
                MessageBox.Show("File not found");
                return default(FileType);
            }
        }
        /// <summary>
        /// creates the directory to save the data fields to
        /// </summary>
        public static void CreateDataDirectory()
        {
            Directory.CreateDirectory(Application.StartupPath + "\\Data");
        }
        /// <summary>
        /// Checks if all data files exist
        /// </summary>
        public static void DataFilesExist()
        {
            List<string> missingFiles = new List<string>();
            string[] files =
            {
                "Titles",
                "Prices",
                "Media Types",
                "Authors",
                "Publishers",
                "Genres",
                "Themes",
                "Books"
            };
            foreach (string file in files)
                if (File.Exists(filePath + $"\\{file}.bin"))
                    missingFiles.Add(file);
            if (missingFiles.Count > 0)
            {
                frmConfirmation confirmation = new frmConfirmation($"Missing Files: {DataFormatter.ListToString(missingFiles)}\n Do you want to create new files?");
                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes)
                    foreach (string file in missingFiles)
                        File.Create(filePath + $"\\{file}.bin");
            }
        }
        #region Save
        /// <summary>
        /// Saves all data stored about the books into their respective files
        /// </summary>
        public static void SaveBooks() 
        {
            // get unique properties of all the books
            List<string> titles = GetUniqueItems(DataLibrary.Titles, SearchAndSort.TwoStrings);
            List<double> prices = GetUniqueItems(DataLibrary.Prices, SearchAndSort.TwoDoubles);
            List<string> mediaTypes = GetUniqueItems(DataLibrary.MediaTypes, SearchAndSort.TwoStrings);
            List<string> authors = GetUniqueItems(DataLibrary.Authors, SearchAndSort.TwoStrings);
            List<string> publishers = GetUniqueItems(DataLibrary.Publishers, SearchAndSort.TwoStrings);
            List<string> genres = GetUniqueItems(DataLibrary.Genres, SearchAndSort.TwoStrings);
            List<string> themes = GetUniqueItems(DataLibrary.Themes, SearchAndSort.TwoStrings);

            // saves each book. Some properties store a number corresponding to the index of a string in the lists of unique properties 
            // Change each record into a serializable format
            BookSaver[] bookSavers = new BookSaver[DataLibrary.Books.Count];
            if (DataLibrary.Books.Count > 0)
            {
                for (int i = 0; i < DataLibrary.Books.Count; i++)
                {
                    Book book = DataLibrary.Books[i];
                    BookSaver saver = new BookSaver();

                    saver.Title = SearchAndSort.Binary(titles, book.Title.Value, SearchAndSort.TwoStrings);
                    saver.SeriesTitle = book.SeriesTitle.Value;
                    saver.SeriesNumber = book.SeriesNumber;
                    saver.Isbn = book.Isbn.Value;
                    saver.Description = book.Description;
                    saver.MediaType = SearchAndSort.Binary(mediaTypes, book.MediaType.Value, SearchAndSort.TwoStrings);
                    saver.Author = SearchAndSort.Binary(authors, book.Author.Value, SearchAndSort.TwoStrings);
                    saver.Publisher = SearchAndSort.Binary(publishers, book.Publisher.Value, SearchAndSort.TwoStrings);
                    saver.Price = SearchAndSort.Binary(prices, book.Price.Value, SearchAndSort.TwoDoubles);
                    saver.Publisher = SearchAndSort.Binary(publishers, book.Publisher.Value, SearchAndSort.TwoStrings);

                    saver.Genres = new int[book.Genres.Count];
                    if (book.Genres.Count > 0)
                        for (int j = 0; j < DataLibrary.Genres.Count; j++)
                            saver.Genres[j] = SearchAndSort.Binary(genres, book.Genres[j].Value, SearchAndSort.TwoStrings);

                    saver.Themes = new int[book.Themes.Count];
                    if (book.Themes.Count > 0)
                        for (int j = 0; j < DataLibrary.Themes.Count; j++)
                            saver.Themes[j] = SearchAndSort.Binary(themes, book.Themes[j].Value, SearchAndSort.TwoStrings);

                    bookSavers[i] = saver;
                }
            }
            SaveFile(titles.ToArray(), filePath, "Titles");
            SaveFile(prices.ToArray(), filePath, "Prices");
            SaveFile(mediaTypes.ToArray(), filePath, "Media Types");
            SaveFile(authors.ToArray(), filePath, "Authors");
            SaveFile(publishers.ToArray(), filePath, "Publishers");
            SaveFile(genres.ToArray(), filePath, "Genres");
            SaveFile(themes.ToArray(), filePath, "Themes");

            SaveFile(bookSavers, filePath, "Books");
        }
        /// <summary>
        /// Saves the data stored about all members into the member file
        /// </summary>
        public static void SaveMembers()
        {
            // Change each record into a serializable format
            MemberSaver[] memberSavers = new MemberSaver[DataLibrary.Members.Count];
            if (DataLibrary.Members.Count > 0)
            {
                for (int i = 0; i < DataLibrary.Members.Count; i++)
                {
                    Member member = DataLibrary.Members[i];
                    MemberSaver saver = new MemberSaver();
                    saver.Barcode = member.Barcode.Value;
                    saver.FirstName = member.FirstName.Value;
                    saver.Surname = member.Surname.Value;
                    saver.DateOfBirth = member.DateOfBirth;
                    saver.LinkedMembers = DataFormatter.MemberListToBarcodeList(member.LinkedMembers).ToArray();
                    saver.EmailAddress = member.EmailAddress;
                    saver.PhoneNumber = member.PhoneNumber;
                    saver.Address1 = member.Address1;
                    saver.Address2 = member.Address2;
                    saver.TownCity = member.TownCity;
                    saver.County = member.County;
                    saver.Postcode = member.Postcode;
                    saver.JoinDate = member.JoinDate;
                    saver.Type = (int)member.Type.Value;
                    memberSavers[i] = saver;
                }
            }

            SaveFile(memberSavers, filePath, "Members");
        }
        /// <summary>
        /// Saves the data stored about all book copies into the book copy file
        /// </summary>
        public static void SaveBookCopies()
        {
            // Change each record into a serializable format
            BookCopySaver[] bookCopySavers = new BookCopySaver[DataLibrary.BookCopies.Count];
            if (DataLibrary.BookCopies.Count > 0)
            {
                for (int i = 0; i < DataLibrary.BookCopies.Count; i++)
                {
                    BookCopy bookCopy = DataLibrary.BookCopies[i];
                    BookCopySaver saver = new BookCopySaver();
                    saver.Barcode = bookCopy.Barcode.Value;
                    saver.Isbn = bookCopy.BookRelation.Book.Isbn.Value;
                    bookCopySavers[i] = saver;
                }
            }
            SaveFile(bookCopySavers, filePath, "BookCopies");
        }
        #endregion
        #region Load
        /// <summary>
        /// Loads the book data stored in the files
        /// </summary>
        public static void LoadBooks()
        {
            // clears current book data
            // extracts book data from the files
            BookSaver[] bookSavers = LoadFile<BookSaver[]>(filePath, "Books");
            string[] titles = LoadFile<string[]>(filePath, "Titles");
            double[] prices = LoadFile<double[]>(filePath, "Prices");
            string[] mediaTypes = LoadFile<string[]>(filePath, "MediaTypes");
            string[] authors = LoadFile<string[]>(filePath, "Authors");
            string[] publishers = LoadFile<string[]>(filePath, "Publishers");
            string[] genres = LoadFile<string[]>(filePath, "Genres");
            string[] themes = LoadFile<string[]>(filePath, "Themes");

            DataLibrary.ClearData.Book();
            // creates book files from the extracted book data
            if (bookSavers.Length > 0)
                foreach (BookSaver saver in bookSavers)
                {
                    BookCreator bookCreator = new BookCreator()
                    {
                        Title = titles[saver.Title],
                        SeriesTitle = saver.SeriesTitle,
                        SeriesNumber = saver.SeriesNumber,
                        Isbn = saver.Isbn,
                        MediaType = mediaTypes[saver.MediaType],
                        Author = authors[saver.Author],
                        Publisher = publishers[saver.Publisher],
                        Genres = saver.Genres.Length > 0 ? GetValuesFromIndexes(genres, saver.Genres) : new List<string>(),
                        Themes = saver.Themes.Length > 0 ? GetValuesFromIndexes(themes, saver.Themes) : new List<string>(),
                        Price = prices[saver.Price],
                        Description = saver.Description,
                    };
                    DataLibrary.Books.Add(new Book(bookCreator));
                }
        }
        /// <summary>
        /// Loads the member records stored in the member file
        /// </summary>
        public static void LoadMembers()
        {
            MemberSaver[] memberSavers = LoadFile<MemberSaver[]>(filePath, "Members");
            DataLibrary.ClearData.Member();
            if (memberSavers.Length > 0)
                foreach (MemberSaver saver in memberSavers)
                {
                    MemberCreator memberCreator = new MemberCreator()
                    {
                        Barcode = saver.Barcode,
                        FirstName = saver.FirstName,
                        Surname = saver.Surname,
                        DateOfBirth = saver.DateOfBirth,
                        LinkedMembers = saver.LinkedMembers.ToList(),
                        EmailAddress = saver.EmailAddress,
                        PhoneNumber = saver.PhoneNumber,
                        Address1 = saver.Address1,
                        Address2 = saver.Address2,
                        TownCity = saver.TownCity,
                        County = saver.County,
                        Postcode = saver.Postcode,
                        JoinDate = saver.JoinDate,
                        Type = (MemberType)saver.Type
                    };
                    DataLibrary.Members.Add(new Member(memberCreator));
                }
        }
        /// <summary>
        /// Loads the book copy records stored in the member file
        /// </summary>
        public static void LoadBookCopies()
        {
            BookCopySaver[] bookCopySavers = LoadFile<BookCopySaver[]>(filePath, "BookCopies");
            if (bookCopySavers.Length > 0)
                foreach (BookCopySaver saver in bookCopySavers)
                {
                    DataLibrary.BookCopies.Add(new BookCopy(saver.Barcode, DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, saver.Isbn, SearchAndSort.RefClassAndString)].Reference));
                }
        }
        #endregion
        /// <summary>
        /// Gets the list of unique item values from the list of reference classes
        /// </summary>
        /// <typeparam name="T">Value</typeparam>
        /// <typeparam name="F">Reference</typeparam>
        /// <param name="itemList">List of reference classes</param>
        /// <param name="compare">Method to compare the ReferenceClass value to the currently stored unique items</param>
        /// <returns>List of the unique values</returns>
        private static List<T> GetUniqueItems<T, F>(List<ReferenceClass<T, F>> itemList,  SearchAndSort.Compare<T, T> compare) where F : class
        {
            List<T> uniqueItems = new List<T>(); 
            // goes through each reference class in the list
            foreach (ReferenceClass<T, F> item in itemList)
            {
                if (SearchAndSort.Binary(uniqueItems, item.Value, compare) == -1) // if its value is not already in unique items, add it
                    uniqueItems.Insert(SearchAndSort.BinaryInsert(uniqueItems, item.Value, compare), item.Value);
            }
            return uniqueItems;
        }
        /// <summary>
        /// Uses the given indexes to find the valuse they are referencing in an array
        /// </summary>
        /// <typeparam name="T">Datatype within the list</typeparam>
        /// <param name="uniqueItems">Array of values</param>
        /// <param name="indexes">Indexes to get the values of</param>
        /// <returns>List of values from the indexes</returns>
        private static List<T> GetValuesFromIndexes<T>(T[] uniqueItems, int[] indexes)
        {
            List<T> uniqueValues = new List<T>(); 
            foreach (int index in indexes)
                uniqueValues.Add(uniqueItems[index]);
            return uniqueValues;
        }
    }
}
