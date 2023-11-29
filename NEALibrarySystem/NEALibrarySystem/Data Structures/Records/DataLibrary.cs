using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static NEALibrarySystem.SearchAndSort;

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
        #region book copy barcodes
        private static List<ReferenceClass<string, BookCopy>> _copyBarcodes;
        public static List<ReferenceClass<string, BookCopy>> CopyBarcodes
        {
            get { return _copyBarcodes; }
            set { _copyBarcodes = value ?? new List<ReferenceClass<string, BookCopy>>(); }
        }
        #endregion
        #endregion book copy books
        private static List<ReferenceClass<Book, BookCopy>> _bookCopyBooks;
        public static List<ReferenceClass<Book, BookCopy>> BookCopyBooks
        {
            get { return _bookCopyBooks; }
            set { _bookCopyBooks = value ?? new List<ReferenceClass<Book, BookCopy>>(); }
        }
        #region books
        private static List<Book> _books = new List<Book>();
        public static List<Book> Books
        {
            get { return _books; }
            set { _books = value ?? new List<Book>(); }
        }
        #endregion
        #region titles
        private static List<ReferenceClass<string, Book>> _titles = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Titles
        { 
            get { return _titles; } 
            set { _titles = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region series titles
        private static List<ReferenceClass<string, Book>> _seriesTitles = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> SeriesTitles
        {
            get { return _seriesTitles; }
            set { _seriesTitles = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region isbn
        private static List<ReferenceClass<string, Book>> _isbns = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Isbns
        {
            get { return _isbns; }
            set { _isbns = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region price
        private static List<ReferenceClass<double, Book>> _prices = new List<ReferenceClass<double, Book>>();
        public static List<ReferenceClass<double, Book>> Prices
        {
            get { return _prices; }
            set { _prices = value ?? new List<ReferenceClass<double, Book>>(); }
        }
        #endregion
        #region mediaTypes
        private static List<ReferenceClass<string, Book>> _mediaTypes = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> MediaTypes
        {
            get { return _mediaTypes; }
            set { _mediaTypes = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region author
        private static List<ReferenceClass<string, Book>> _authors = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Authors
        {
            get { return _authors; }
            set { _authors = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region publishers
        private static List<ReferenceClass<string, Book>> _publishers = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Publishers
        {
            get { return _publishers; }
            set { _publishers = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region genres
        private static List<ReferenceClass<string, Book>> _genres = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Genres
        {
            get { return _genres; }
            set { _genres = value ?? new List<ReferenceClass<string, Book>>(); }
        }
        #endregion
        #region themes
        private static List<ReferenceClass<string, Book>> _themes = new List<ReferenceClass<string, Book>>();
        public static List<ReferenceClass<string, Book>> Themes
        {
            get { return _themes; }
            set { _themes = value ?? new List<ReferenceClass<string, Book>>(); }
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
        #region member barcodes
        private static List<ReferenceClass<string, Member>> _memberBarcodes = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> MemberBarcodes
        {
            get { return _memberBarcodes; }
            set { _memberBarcodes = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region first name
        private static List<ReferenceClass<string, Member>> _firstName = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> FirstName
        {
            get { return _firstName; }
            set { _firstName = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region surname
        private static List<ReferenceClass<string, Member>> _surname = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> LastName
        {
            get { return _surname; }
            set { _surname = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region surname
        private static List<ReferenceClass<MemberType, Member>> _memberType = new List<ReferenceClass<MemberType, Member>>();
        public static List<ReferenceClass<MemberType, Member>> MemberType
        {
            get { return _memberType; }
            set { _memberType = value ?? new List<ReferenceClass<MemberType, Member>>(); }
        }
        #endregion
        #region media type
        private static List<ReferenceClass<MemberType, Member>> _mediaType = new List<ReferenceClass<MemberType, Member>>();
        public static List<ReferenceClass<MemberType, Member>> MediaType
        {
            get { return _mediaType; }
            set { _mediaType = value ?? new List<ReferenceClass<MemberType, Member>>(); }
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
        public static void LoadAllFiles()
        {

        }
        public static void SaveAllFiles()
        {

        }
        #endregion
        #region data handling
        #region filtering

        #endregion
        #region AddingRecords
        public static List<ReferenceClass<T, F>> CreateReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, F reference, T item, Compare<T> compare) where F : class
        {
            ReferenceClass<T, F> referenceClass = new ReferenceClass<T, F>();
            referenceClass.Value = item;
            referenceClass.Reference = reference;
            itemList = DataLibrary.AddReferenceClass(itemList, referenceClass, compare);
            return itemList;
        }
        /// <summary>
        /// Adds the reference class to the inputted list of reference classes
        /// </summary>
        /// <typeparam name="T">Value of the reference class</typeparam>
        /// <typeparam name="F">Class that the reference classes refer to</typeparam>
        /// <param name="list">List of reference classes</param>
        /// <param name="record">Reference class to add</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>The updated list</returns>
        public static List<ReferenceClass<T, F>> AddReferenceClass<T, F>(List<ReferenceClass<T, F>> list, ReferenceClass<T, F> record, Compare<T> compare) where F : class
        {
            list.Insert(SearchAndSort.BinaryInsert(list, record, compare), record);
            return list;
        }
        #endregion
        #region Deleting records
        public static List<ReferenceClass<T,F>> DeleteReferenceClass<T,F>(List<ReferenceClass<T,F>> list, ReferenceClass<T,F> item, Compare<T> compare) where F : class
        {
            list.RemoveAt(SearchAndSort.Binary(list, item.Value, compare));
            return list;
        }
        /// <summary>
        /// Removes the book and it's references from the system
        /// </summary>
        /// <param name="book">book to be deleted</param>
        public static void DeleteBook(Book book)
        {
            // delete references
            DataLibrary.Titles = DeleteReferenceClass(DataLibrary.Titles, book.Title, TwoStrings);
            DataLibrary.SeriesTitles = DeleteReferenceClass(DataLibrary.SeriesTitles, book.SeriesTitle, TwoStrings);
            DataLibrary.MediaTypes = DeleteReferenceClass(DataLibrary.MediaTypes, book.MediaType, TwoStrings);
            DataLibrary.Isbns = DeleteReferenceClass(DataLibrary.Isbns, book.Isbn, TwoStrings);
            DataLibrary.Prices = DeleteReferenceClass(DataLibrary.Prices, book.Price, TwoDoubles);
            DataLibrary.Authors = DeleteReferenceClass(DataLibrary.Authors, book.Author, TwoStrings);
            DataLibrary.Publishers = DeleteReferenceClass(DataLibrary.Publishers, book.Publisher, TwoStrings);
            if (book.Genres.Count > 0)
                foreach (ReferenceClass<string, Book> genre in book.Genres)
                    DataLibrary.Genres = DeleteReferenceClass(DataLibrary.Genres, genre, TwoStrings);
            if (book.Themes.Count > 0)
                foreach (ReferenceClass<string, Book> theme in book.Themes)
                    DataLibrary.Themes = DeleteReferenceClass(DataLibrary.Themes, theme, TwoStrings);
            // delete book
            DataLibrary.Books.Remove(book);
        }
        /// <summary>
        /// Deletes the member record with the inputted member barcode
        /// </summary>
        /// <param name="barcode">member barcode of member to be deleted</param>
        public static void DeleteMember(string barcode)
        {

        }
        #endregion
        #endregion
    }
}
