using NEALibrarySystem.Data_Structures.RecordCreators;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.Data_Structures.RecordSavers;
using NEALibrarySystem.Properties;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        private static string[] _files =
        {
            "Titles",
            "Prices",
            "MediaTypes",
            "Authors",
            "Publishers",
            "Genres",
            "Themes",
            "Books",
            "Members",
            "BookCopies",
            "CirculationCopies",
            "Staff",
            "Settings"
        }; // list of all data file names

        /// <summary>
        /// sets the filePath static variable to be path of the EXE file concatenated to the data directory name
        /// </summary>
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
        /// <typeparam name="FileType">Data structure format of the file</typeparam>
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
        /// Creates the directory to save the data fields to if it does not exist
        /// </summary>
        public static void CreateDataDirectory()
        {
            if (!Directory.Exists(Application.StartupPath + "\\Data"))
                Directory.CreateDirectory(Application.StartupPath + "\\Data");
        }

        public static bool StaffFilesExist()
        {
            if (File.Exists(filePath + $"\\Staff.bin"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Loads all data into the system, loads from back up or creates new files of initial load fails.
        /// </summary>
        public static void HandleStartUp()
        {
            if (MissingDataFiles()) // if files are missing
            {
                HandleInvalidFiles();
            }
            else
            {
                try
                {
                    FileHandler.Load.All();
                }
                catch
                {
                    HandleInvalidFiles();
                }
            }
        }

        private static void HandleInvalidFiles()
        {
            bool resolved = false;
            do
            {
                frmConfirmation confirmation = new frmConfirmation($"Invalid files detected. Do you want to Load from a back up or create new files?", System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight, "Back up", "New files");

                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes) // user chooses to load a backup
                {
                    bool isSuccess = Backup.Load();
                    if (isSuccess)
                    {
                        try
                        {
                            FileHandler.Load.All();
                            resolved = true;
                        }
                        catch
                        {
                            MessageBox.Show("Error: Corrupt files");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Back up could not be loaded");
                    }
                }
                else if (confirmation.DialogResult == DialogResult.No) // user chooses to create new files
                {
                    FileHandler.InitialiseFilePath();
                    foreach (string file in _files)
                    {
                        FileStream f = File.Create(filePath + $"\\{file}.bin");
                        f.Close();
                    }
                    DataLibrary.ClearData.All();
                    // create default staff member
                    StaffCreator defaultStaff = new StaffCreator()
                    {
                        FirstName = "",
                        Surname = "",
                        Username = "Admin",
                        Password = "Password1",
                        EmailAddress = "",
                        IsAdministrator = true,
                    };
                    DataLibrary.StaffList.Add(new Staff(defaultStaff));
                    // load default settings
                    SettingsCreator defaultSettings = new SettingsCreator();
                    defaultSettings.GetDefaultSettings();
                    defaultSettings.SetStoredSettings();
                    FileHandler.Save.All();
                    MessageBox.Show("New files created. Default Staff Member created.\nUsername: Admin\nPassword: Password1");
                    resolved = true;
                }
            } while (!resolved);
        }
        /// <summary>
        /// Checks if all data files exist
        /// </summary>
        /// <returns>Boolean value of whether the necessary data files exist</returns>
        public static bool MissingDataFiles()
        {
            // get all missing files
            foreach (string file in _files)
            {
                if (!File.Exists(filePath + $"\\{file}.bin"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Handles saving and loading data from backups
        /// </summary>
        public static class Backup
        {

            /// <summary>
            /// Creates a back up of current data in the system
            /// </summary>
            /// <returns>Returns a boolean result of whether the back up was successfully created</returns>
            public static bool Save()
            {
                return true;
            }
            /// <summary>
            /// Loads a backup of data into the system
            /// </summary>
            /// <returns>Returns a boolean result of whether the back up was successfully loaded</returns>
            public static bool Load()
            {
                return true;
            }
        }
        /// <summary>
        /// Used to save data from the program into the files
        /// </summary>
        public static class Save
        {
            /// <summary>
            /// Saves all data stored into their respective files
            /// </summary>
            public static void All()
            {
                Books();
                BookCopies();
                CirculationCopies();
                Members();
                Staff();
                Settings();
            }
            /// <summary>
            /// Saves all data stored about the books into their respective files
            /// </summary>
            public static void Books()
            {
                // place the unique values for each property for all books into their respective lists
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
                        // save the non-reference properties in the book file
                        saver.SeriesTitle = book.SeriesTitle.Value;
                        saver.SeriesNumber = book.SeriesNumber;
                        saver.Isbn = book.Isbn.Value;
                        saver.Description = book.Description;
                        // find the book's value in the unique property list and save the index
                        saver.Title = SearchAndSort.Binary(titles, book.Title.Value, SearchAndSort.TwoStrings);
                        saver.MediaType = SearchAndSort.Binary(mediaTypes, book.MediaType.Value, SearchAndSort.TwoStrings);
                        saver.Author = SearchAndSort.Binary(authors, book.Author.Value, SearchAndSort.TwoStrings);
                        saver.Publisher = SearchAndSort.Binary(publishers, book.Publisher.Value, SearchAndSort.TwoStrings);
                        saver.Price = SearchAndSort.Binary(prices, book.Price.Value, SearchAndSort.TwoDoubles);
                        saver.Publisher = SearchAndSort.Binary(publishers, book.Publisher.Value, SearchAndSort.TwoStrings);

                        saver.Genres = new int[book.Genres.Count];
                        if (book.Genres.Count > 0)
                            for (int j = 0; j < book.Genres.Count; j++)
                                saver.Genres[j] = SearchAndSort.Binary(genres, book.Genres[j].Value, SearchAndSort.TwoStrings);
                        saver.Themes = new int[book.Themes.Count];
                        if (book.Themes.Count > 0)
                            for (int j = 0; j < book.Themes.Count; j++)
                                saver.Themes[j] = SearchAndSort.Binary(themes, book.Themes[j].Value, SearchAndSort.TwoStrings);
                        //add the book saver the the list of book savers
                        bookSavers[i] = saver;
                    }
                }
                // save all saver data into the book files
                SaveFile(titles.ToArray(), filePath, "Titles");
                SaveFile(prices.ToArray(), filePath, "Prices");
                SaveFile(mediaTypes.ToArray(), filePath, "MediaTypes");
                SaveFile(authors.ToArray(), filePath, "Authors");
                SaveFile(publishers.ToArray(), filePath, "Publishers");
                SaveFile(genres.ToArray(), filePath, "Genres");
                SaveFile(themes.ToArray(), filePath, "Themes");

                SaveFile(bookSavers, filePath, "Books");
            }
            /// <summary>
            /// Saves the data stored about all members into the member file
            /// </summary>
            public static void Members()
            {
                // Change each record into a serializable format
                MemberSaver[] memberSavers = new MemberSaver[DataLibrary.Members.Count];
                if (DataLibrary.Members.Count > 0)
                {
                    for (int i = 0; i < DataLibrary.Members.Count; i++)
                    {
                        Member member = DataLibrary.Members[i];
                        MemberSaver saver = new MemberSaver();
                        // add reformatted member data into the saver
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
            public static void BookCopies()
            {
                // Change each record into a serializable format
                BookCopySaver[] bookCopySavers = new BookCopySaver[DataLibrary.BookCopies.Count];
                if (DataLibrary.BookCopies.Count > 0)
                {
                    for (int i = 0; i < DataLibrary.BookCopies.Count; i++)
                    {
                        BookCopy bookCopy = DataLibrary.BookCopies[i];
                        BookCopySaver saver = new BookCopySaver();
                        // save data required for making a new book copy into the saver
                        saver.Barcode = bookCopy.Barcode.Value;
                        saver.Isbn = bookCopy.Book.Isbn.Value;
                        bookCopySavers[i] = saver;
                    }
                }
                SaveFile(bookCopySavers, filePath, "BookCopies");
            }
            /// <summary>
            /// Saves the data stored about all circulation copies into the circulation copy file
            /// </summary>
            public static void CirculationCopies()
            {
                CirculationCopySaver[] circulationCopySavers = new CirculationCopySaver[DataLibrary.CirculationCopies.Count];
                if (DataLibrary.CirculationCopies.Count > 0)
                    for (int i = 0; i < DataLibrary.CirculationCopies.Count; i++)
                    {
                        CirculationCopy circulationCopy = DataLibrary.CirculationCopies[i];
                        CirculationCopySaver saver = new CirculationCopySaver();
                        // add reformatted circulation data to the saver
                        saver.Id = circulationCopy.Id.Value;
                        saver.Type = (int)circulationCopy.Type.Value;
                        saver.BookCopyBarcode = circulationCopy.BookCopy.Barcode.Value;
                        saver.MemberBarcode = circulationCopy.Member.Barcode.Value;
                        saver.DueDate = circulationCopy.DueDate.Value;
                        saver.Date = circulationCopy.Date.Value;

                        circulationCopySavers[i] = saver;
                    }
                SaveFile(circulationCopySavers, filePath, "CirculationCopies");
            }
            /// <summary>
            /// Saves the data stored about all staff into the staff file
            /// </summary>
            public static void Staff()
            {
                StaffSaver[] staffSavers = new StaffSaver[DataLibrary.StaffList.Count];
                if (DataLibrary.StaffList.Count > 0)
                    for (int i = 0; i < DataLibrary.StaffList.Count; i++)
                    {
                        Staff staff = DataLibrary.StaffList[i];
                        // translate staff record into the saver format and add it to the array of savers
                        StaffSaver saver = new StaffSaver()
                        {
                            FirstName = staff.FirstName.Value,
                            Surname = staff.Surname.Value,
                            Username = staff.Username.Value,
                            Password = staff.Password,
                            EmailAddress = staff.EmailAddress.Value,
                            IsAdministrator = staff.IsAdministrator,
                        };
                        staffSavers[i] = saver;
                    }
                SaveFile(staffSavers, filePath, "Staff");
            }
            /// <summary>
            /// Saves the data stored about all staff into the staff file
            /// </summary>
            public static void Settings()
            {
                SettingsCreator creator = new SettingsCreator();
                creator.GetCurrentSettings();
                SaveFile(creator, filePath, "Settings");
            }
        }
        /// <summary>
        /// Used to load data from the files into the program
        /// </summary>
        public static class Load
        {
            /// <summary>
            /// Loads the data stored in the files
            /// </summary>
            public static void All()
            {
                Books();
                Members();
                BookCopies(); // book copies rely on books so is loaded after books
                CirculationCopies();// circulation copies rely on book copies and members so is loaded after them
                Staff();
            }
            /// <summary>
            /// Loads the book data stored in the files
            /// </summary>
            public static void Books()
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
                if (bookSavers != null)
                    foreach (BookSaver saver in bookSavers)
                    {
                        // create a book creator class from the book saver class
                        BookCreator creator = new BookCreator()
                        {
                            Title = titles[saver.Title],
                            SeriesTitle = saver.SeriesTitle,
                            SeriesNumber = saver.SeriesNumber.ToString(),
                            Isbn = saver.Isbn,
                            MediaType = mediaTypes[saver.MediaType],
                            Author = authors[saver.Author],
                            Publisher = publishers[saver.Publisher],
                            Genres = saver.Genres.Length > 0 ? GetValuesFromIndexes(genres, saver.Genres) : new List<string>(), // gets values from the unique item list if the list of indexes is not empty
                            Themes = saver.Themes.Length > 0 ? GetValuesFromIndexes(themes, saver.Themes) : new List<string>(),
                            Price = prices[saver.Price].ToString(),
                            Description = saver.Description,
                        };
                        DataLibrary.Books.Add(new Book(creator));
                    }
            }
            /// <summary>
            /// Loads the member records stored in the member file
            /// </summary>
            public static void Members()
            {
                MemberSaver[] memberSavers = LoadFile<MemberSaver[]>(filePath, "Members");
                DataLibrary.ClearData.Member();
                if (memberSavers != null)
                {
                    foreach (MemberSaver saver in memberSavers)
                    {
                        // create a member creator class from the member saver class
                        MemberCreator creator = new MemberCreator()
                        {
                            Barcode = saver.Barcode,
                            FirstName = saver.FirstName,
                            Surname = saver.Surname,
                            DateOfBirth = saver.DateOfBirth,
                            EmailAddress = saver.EmailAddress,
                            PhoneNumber = saver.PhoneNumber,
                            Address1 = saver.Address1,
                            Address2 = saver.Address2,
                            TownCity = saver.TownCity,
                            County = saver.County,
                            Postcode = saver.Postcode,
                            JoinDate = saver.JoinDate, // join date is set as the added record is of an existing member
                            Type = ((MemberType)saver.Type).ToString()
                        };
                        DataLibrary.Members.Add(new Member(creator));
                    }
                    for (int i = 0; i < memberSavers.Length; i++)
                    {
                        foreach (string linkedMember in memberSavers[i].LinkedMembers)
                            DataLibrary.Members[i].LinkedMembers.Add(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, linkedMember, SearchAndSort.RefClassAndString)].Reference);
                    }
                }
            }
            /// <summary>
            /// Loads the book copy records stored in the member file
            /// </summary>
            public static void BookCopies()
            {
                BookCopySaver[] bookCopySavers = LoadFile<BookCopySaver[]>(filePath, "BookCopies");
                DataLibrary.ClearData.BookCopy();
                if (bookCopySavers != null)
                    foreach (BookCopySaver saver in bookCopySavers)
                        // creates a book copy using the saver's barcode, and the book record found using the saver's ISBN
                        DataLibrary.BookCopies.Add(new BookCopy(saver.Barcode, DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, saver.Isbn, SearchAndSort.RefClassAndString)].Reference));
            }
            /// <summary>
            /// Loads the circulation copy records stored in the member file
            /// </summary>
            public static void CirculationCopies()
            {
                CirculationCopySaver[] circulationCopySavers = LoadFile<CirculationCopySaver[]>(filePath, "CirculationCopies");
                DataLibrary.ClearData.CirculationCopy();
                if (circulationCopySavers != null)
                    foreach (CirculationCopySaver saver in circulationCopySavers)
                    {
                        // create a circulation copy using the data in the saver
                        CirculationCopyCreator creator = new CirculationCopyCreator()
                        {
                            Id = saver.Id,
                            Type = (CirculationType)saver.Type,
                            BookCopy = DataLibrary.BookCopyBarcodes[SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, saver.BookCopyBarcode, SearchAndSort.RefClassAndString)].Reference,
                            Member = DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, saver.MemberBarcode, SearchAndSort.RefClassAndString)].Reference,
                            DueDate = saver.DueDate,
                            Date = saver.Date, // date is specified as it is loading an active circulation that was created in the past
                        };
                        DataLibrary.CirculationCopies.Add(new CirculationCopy(creator));
                    }
            }

            public static void Staff()
            {
                DataLibrary.ClearData.Staff();
                StaffSaver[] staffSavers = LoadFile<StaffSaver[]>(filePath, "Staff");
                if (staffSavers != null)
                    foreach (StaffSaver saver in staffSavers)
                    {
                        // create a circulation copy using the data in the saver
                        StaffCreator creator = new StaffCreator()
                        {
                            FirstName = saver.FirstName,
                            Surname = saver.Surname,
                            Username = saver.Username,
                            Password = saver.Password,
                            EmailAddress = saver.EmailAddress,
                            IsAdministrator = saver.IsAdministrator
                        };
                        DataLibrary.StaffList.Add(new Staff(creator));
                    }
            }
            public static void Settings() 
            {
                SettingsCreator creator = LoadFile<SettingsCreator>(filePath, "Settings");
                creator.SetStoredSettings();
            }
        }
        /// <summary>
        /// Gets the list of unique item values from the list of reference classes
        /// </summary>
        /// <typeparam name="T">Value of reference class</typeparam>
        /// <typeparam name="F">Reference type of reference class</typeparam>
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
        /// <param name="items">Array of values</param>
        /// <param name="indexes">Indexes to get the values of</param>
        /// <returns>List of values from the indexes</returns>
        private static List<T> GetValuesFromIndexes<T>(T[] items, int[] indexes)
        {
            List<T> values = new List<T>(); 
            foreach (int index in indexes)
                values.Add(items[index]);
            return values;
        }
    }
}
