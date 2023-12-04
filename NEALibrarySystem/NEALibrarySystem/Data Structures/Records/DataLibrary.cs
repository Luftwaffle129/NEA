using NEALibrarySystem.Data_Structures.Records;
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
        public static List<ReferenceClass<string, BookCopy>> BookCopyBarcodes
        {
            get { return _copyBarcodes; }
            set { _copyBarcodes = value ?? new List<ReferenceClass<string, BookCopy>>(); }
        }
        #endregion
        #region book copy relations
        private static List<BookCopyRelation> _bookCopyRelation;
        public static List<BookCopyRelation> BookCopyRelations
        {
            get { return _bookCopyRelation; }
            set { _bookCopyRelation = value?? new List<BookCopyRelation>(); }
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
        #region circulation copies
        private static List<CirculationCopy> _circulationCopies;
        public static List <CirculationCopy> CirculationCopies
        {
            get { return _circulationCopies; }
            set { _circulationCopies = value ?? new List<CirculationCopy>(); }
        }
        #endregion
        #region circulation copy types
        private static List<ReferenceClass<CirculationType, CirculationCopy>> _circulationTypes;
        public static List<ReferenceClass<CirculationType, CirculationCopy>> CirculationTypes
        {
            get { return _circulationTypes; }
            set { _circulationTypes = value ?? new List<ReferenceClass<CirculationType, CirculationCopy>>(); }
        }
        #endregion
        #region circulation due dates
        private static List<ReferenceClass<DateTime, CirculationCopy>> _circulationDueDates;
        public static List<ReferenceClass<DateTime, CirculationCopy>> CirculationDueDates
        {
            get { return _circulationDueDates; }
            set { _circulationDueDates = value ?? new List<ReferenceClass<DateTime, CirculationCopy>>(); }
        }
        #endregion
        #region circulation dates
        private static List<ReferenceClass<DateTime, CirculationCopy>> _circulationDates;
        public static List<ReferenceClass<DateTime, CirculationCopy>> CirculationDates
        {
            get { return _circulationDates; }
            set { _circulationDates = value ?? new List<ReferenceClass<DateTime, CirculationCopy>>(); }
        }
        #endregion
        #region
        private static List<CircMemberRelation> _circMemberRelations;
        public static List<CircMemberRelation> CircMemberRelations
        {
            get { return _circMemberRelations; }
            set { _circMemberRelations = value ?? new List<CircMemberRelation>(); }
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
        #region Adding Records
        /// <summary>
        /// Creates a new reference class and adds it to the specified list
        /// </summary>
        /// <typeparam name="T">Item value</typeparam>
        /// <typeparam name="F">Class being referenced</typeparam>
        /// <param name="itemList">List of reference classes</param>
        /// <param name="reference">Class being referenced</param>
        /// <param name="item">Value of the reference class</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>List of reference classes containing the new reference class</returns>
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
        /// <param name="itemList">List of reference classes</param>
        /// <param name="record">Reference class to add</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>The updated list</returns>
        public static List<ReferenceClass<T, F>> AddReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> record, Compare<T> compare) where F : class
        {
            itemList.Insert(SearchAndSort.BinaryReferenceInsert(itemList, record, compare), record);
            return itemList;
        }
        /// <summary>
        /// Creates a new book copy and adds it to the list of book copies
        /// </summary>
        /// <param name="barcode">barcode of the new book copy</param>
        /// <param name="book">book of the new book copy</param>    
        public static void CreateBookCopy(string barcode, Book book)
        {
            DataLibrary.BookCopies.Add(new BookCopy(barcode, book));
        }
        #endregion
        #region Modifying Records
        /// <summary>
        /// Updates a book record with the new information
        /// </summary>
        /// <param name="book">book to update</param>
        /// <param name="newBookInfo">new informatipn for the book</param>
        /// <returns>Updated book</returns>
        public static Book ModifyBookRecord(Book book, BookCreator newBookInfo)
        {
            book.SeriesNumber = newBookInfo.SeriesNumber;
            book.Description = newBookInfo.Description;
            book.Title.Value = newBookInfo.Title;
            book.SeriesTitle.Value = newBookInfo.SeriesTitle;
            book.Isbn.Value = newBookInfo.Isbn;
            book.Price.Value = newBookInfo.Price;
            book.MediaType.Value = newBookInfo.MediaType;
            book.Author.Value = newBookInfo.Author;
            book.Publisher.Value = newBookInfo.Publisher;
            // remove old genres
            if (book.Genres.Count > 0)
                foreach (ReferenceClass<string, Book> genre in book.Genres)
                    DataLibrary.Genres = DeleteReferenceClass(DataLibrary.Genres, genre, TwoStrings, TwoBooks);
            // add new genres
            if (newBookInfo.Genres.Count > 0)
                foreach (string genre in newBookInfo.Genres)
                    DataLibrary.Genres = CreateReferenceClass(DataLibrary.Genres, book, genre, TwoStrings);
            // remove old themes
            if (book.Themes.Count > 0)
                foreach (ReferenceClass<string, Book> theme in book.Themes)
                    DataLibrary.Themes = DeleteReferenceClass(DataLibrary.Themes, theme, TwoStrings, TwoBooks);
            // add new themes
            if (newBookInfo.Themes.Count > 0)
                foreach (string theme in newBookInfo.Themes)
                    DataLibrary.Themes = CreateReferenceClass(DataLibrary.Themes, book, theme, TwoStrings);
            return book;
        }
        #endregion
        #region Deleting records
        /// <summary>
        /// Removes the specified reference class from a list of reference classes
        /// </summary>
        /// <typeparam name="T">Value of the reference class</typeparam>
        /// <typeparam name="F">Class that the reference classes refer to</typeparam>
        /// <param name="itemList">List of reference classes</param>
        /// <param name="record">Reference class to remove</param>
        /// <param name="compareValue">Comparison method</param>
        /// <returns>The updated list</returns>
        public static List<ReferenceClass<T,F>> DeleteReferenceClass<T,F>(List<ReferenceClass<T,F>> itemList, ReferenceClass<T,F> item, Compare<T> compareValue, Compare<ReferenceClass<T, F>> compareRef) where F : class
        {
            itemList.RemoveAt(SearchAndSort.BinaryReferenceClass(itemList, item, compareValue, compareRef));
            return itemList;
        }
        /// <summary>
        /// Removes the book and it's references from the system
        /// </summary>
        /// <param name="book">book to be deleted</param>
        public static void DeleteBook(Book book)
        {
            //delete book copies
            if (book.BookCopyRelations.Count > 0)
                for (int i = 0; i < book.BookCopyRelations.Count; i++)
                    DeleteBookCopy(book.BookCopyRelations[i].Copy);
            // delete references
            DataLibrary.Titles = DeleteReferenceClass(DataLibrary.Titles, book.Title, TwoStrings, TwoBooks);
            DataLibrary.SeriesTitles = DeleteReferenceClass(DataLibrary.SeriesTitles, book.SeriesTitle, TwoStrings, TwoBooks);
            DataLibrary.MediaTypes = DeleteReferenceClass(DataLibrary.MediaTypes, book.MediaType, TwoStrings, TwoBooks);
            DataLibrary.Isbns = DeleteReferenceClass(DataLibrary.Isbns, book.Isbn, TwoStrings, TwoBooks);
            DataLibrary.Prices = DeleteReferenceClass(DataLibrary.Prices, book.Price, TwoDoubles, TwoBooks);
            DataLibrary.Authors = DeleteReferenceClass(DataLibrary.Authors, book.Author, TwoStrings, TwoBooks);
            DataLibrary.Publishers = DeleteReferenceClass(DataLibrary.Publishers, book.Publisher, TwoStrings, TwoBooks);
            if (book.Genres.Count > 0)
                foreach (ReferenceClass<string, Book> genre in book.Genres)
                    DataLibrary.Genres = DeleteReferenceClass(DataLibrary.Genres, genre, TwoStrings, TwoBooks);
            if (book.Themes.Count > 0)
                foreach (ReferenceClass<string, Book> theme in book.Themes)
                    DataLibrary.Themes = DeleteReferenceClass(DataLibrary.Themes, theme, TwoStrings, TwoBooks);
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
        /// <summary>
        /// Deletes the specified book copy and the references to it
        /// </summary>
        /// <param name="bookCopy">book copy to delete</param>
        public static void DeleteBookCopy(BookCopy bookCopy) 
        {
            // delete book copy relation
            bookCopy.BookRelation.Book.BookCopyRelations.Remove(bookCopy.BookRelation);
            DataLibrary.BookCopyRelations.Remove(bookCopy.BookRelation);
            // delete barcode
            DataLibrary.BookCopyBarcodes = DeleteReferenceClass(DataLibrary.BookCopyBarcodes, bookCopy.Barcode, TwoStrings, TwoBookCopies);
            // delete circulation copy
            if (bookCopy.CirculationCopy != null)
                DeleteCirculationCopy(bookCopy.CirculationCopy);
            // delete book
            DataLibrary.BookCopies.Remove(bookCopy);
        }
        public static void DeleteCirculationCopy(CirculationCopy circulationCopy)
        {
            // delete member relation
            circulationCopy.CircMemberRelation.Member.CircMemberRelations.Remove(circulationCopy.CircMemberRelation);
            DataLibrary.CircMemberRelations.Remove(circulationCopy.CircMemberRelation);
            // delete book copy relation
            circulationCopy.BookCopy.CirculationCopy = null;
            // delete reference classes
            DataLibrary.CirculationDueDates = DeleteReferenceClass(DataLibrary.CirculationDueDates, circulationCopy.DueDate, TwoDates, TwoCirculationCopies);
            DataLibrary.CirculationDates = DeleteReferenceClass(DataLibrary.CirculationDates, circulationCopy.Date, TwoDates, TwoCirculationCopies);
            DataLibrary.CirculationTypes = DeleteReferenceClass(DataLibrary.CirculationTypes, circulationCopy.Type, TwoEnums, TwoCirculationCopies);
        }
        #endregion
        #endregion
    }
}