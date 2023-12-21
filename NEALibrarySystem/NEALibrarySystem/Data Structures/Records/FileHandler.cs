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
            BookSaver[] bookSavers = new BookSaver[DataLibrary.Books.Count];
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
                for (int j = 0; j < DataLibrary.Genres.Count; j++)
                    saver.Genres[j] = SearchAndSort.Binary(genres, book.Genres[j].Value, SearchAndSort.TwoStrings);

                saver.Themes = new int[book.Themes.Count];
                for (int j = 0; j < DataLibrary.Themes.Count; j++)
                    saver.Themes[j] = SearchAndSort.Binary(themes, book.Themes[j].Value, SearchAndSort.TwoStrings);
                
                bookSavers[i] = saver;
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
        public static void SaveMembers()
        {

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
            string filePath = Application.StartupPath + "\\Data\\";
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
            foreach (BookSaver bookSaver in bookSavers)
            {
                BookCreator bookCreator = new BookCreator()
                {
                    Title = titles[bookSaver.Title],
                    SeriesTitle = bookSaver.SeriesTitle,
                    SeriesNumber = bookSaver.SeriesNumber,
                    Isbn = bookSaver.Isbn,
                    MediaType = mediaTypes[bookSaver.MediaType],
                    Author = authors[bookSaver.Author],
                    Publisher = publishers[bookSaver.Publisher],
                    Genres = GetValuesFromIndexes(genres, bookSaver.Genres),
                    Themes = GetValuesFromIndexes(themes, bookSaver.Themes),
                    Price = prices[bookSaver.Price],
                    Description = bookSaver.Description,
                };
                DataLibrary.Books.Add(new Book(bookCreator));
            }
        }
        public static void LoadMembers()
        {

        }
        #endregion
        /// <summary>
        /// Gets the list of unique item values from the list of reference classes
        /// </summary>
        /// <typeparam name="T">Value</typeparam>
        /// <typeparam name="F">Reference</typeparam>
        /// <param name="itemList">list of reference classes</param>
        /// <param name="compare">method to compare the ReferenceClass value to the currently stored unique items</param>
        /// <returns>List of the unique values</returns>
        private static List<T> GetUniqueItems<T, F>(List<ReferenceClass<T, F>> itemList,  SearchAndSort.Compare<T, T> compare) where F : class
        {
            List<T> uniqueItems = new List<T>(); 
            foreach (ReferenceClass<T, F> item in itemList)
            {
                if (SearchAndSort.Binary(uniqueItems, item.Value, compare) == -1)
                    SearchAndSort.BinaryInsert(uniqueItems, item.Value, compare);
            }
            return uniqueItems;
        }
        private static List<T> GetValuesFromIndexes<T>(T[] uniqueItems, int[] indexes)
        {
            List<T> uniqueValues = new List<T>(); 
            foreach (int index in indexes)
                uniqueValues.Add(uniqueItems[index]);
            return uniqueValues;
        }
    }
}
