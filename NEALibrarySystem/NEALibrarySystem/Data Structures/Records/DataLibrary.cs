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
        #region book copies
        private static List<BookCopy> _bookCopies;
        public static List<BookCopy> BookCopies
        {
            get { return _bookCopies; }
            set { _bookCopies = value ?? new List<BookCopy>(); }
        }
        #endregion
        #region books
        private static List<Book> _books = new List<Book>();
        public static List<Book> Books
        {
            get { return _books; }
            set { _books = value ?? new List<Book>(); }
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
        private static List<ItemBook> _titles = new List<ItemBook>();
        public static List<ItemBook> Titles
        { 
            get { return _titles; } 
            set { _titles = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region mediaTypes
        private static List<ItemBook> _mediaTypes = new List<ItemBook>();
        public static List<ItemBook> MediaTypes
        {
            get { return _mediaTypes; }
            set { _mediaTypes = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region author
        private static List<ItemBook> _authors = new List<ItemBook>();
        public static List<ItemBook> Authors
        {
            get { return _authors; }
            set { _authors = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region publishers
        private static List<ItemBook> _publishers = new List<ItemBook>();
        public static List<ItemBook> Publishers
        {
            get { return _publishers; }
            set { _publishers = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region genres
        private static List<ItemBook> _genres = new List<ItemBook>();
        public static List<ItemBook> Genres
        {
            get { return _genres; }
            set { _genres = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region themes
        private static List<ItemBook> _themes = new List<ItemBook>();
        public static List<ItemBook> Themes
        {
            get { return _themes; }
            set { _themes = value ?? new List<ItemBook>(); }
        }
        #endregion
        #region genreBook
        private static List<BookItemID> _genreBook;
        public static List<BookItemID> GenreBook
        {
            get { return _genreBook; }
            set { _genreBook = value ?? new List<BookItemID>(); }
        }
        #endregion
        #region themeBook
        private static List<BookItemID> _themeBook;
        public static List<BookItemID> ThemeBook
        {
            get { return _themeBook; }
            set { _themeBook = value ?? new List<BookItemID>(); }
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
        #region Reservations
        private static List<CirculationCopy> _reservations;
        public static List <CirculationCopy> Reservations
        {
            get { return _reservations; }
            set { _reservations = value ?? new List<CirculationCopy>(); }
        }
        #endregion
        #region Loans
        private static List<CirculationCopy> _loans;
        public static List<CirculationCopy> Loans
        {
            get { return _loans; }
            set { _loans = value ?? new List<CirculationCopy>(); }
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
            if (DataLibrary.Books.Count > 0) 
            {

            }
        }
        /// <summary>
        /// Deletes the member record with the inputted member barcode
        /// </summary>
        /// <param name="barcode">member barcode of member to be deleted</param>
        public static void DeleteMember(string barcode)
        {
            
        }
        /// <summary>
        /// Removes the itemID from the list if it is not linked to any other records
        /// </summary>
        /// <param name="itemIDList">List containing the ItemID that might be removed</param>
        /// <param name="usedIDs">List of IDs that are being used by records</param>
        /// <param name="ID">The ID of the ItemID that might be removed</param>
        public static void RemoveUnnecessaryItemID(ref List<ItemBook> itemIDList, List<int> usedIDs, int ID)
        {

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
        #endregion
        #region data handling
        #region insertion
        public static int InsertItemBook(ref List<ItemBook> itemBookList, ItemBook itemBook)
        {
            int index = SearchAndSort.GetInsertIndex(itemBookList, itemBook.Name);
            itemBookList.Insert(index, itemBook);
            return index;
        }
        #endregion
        #region filtering

        #endregion
        #endregion
    }
}
