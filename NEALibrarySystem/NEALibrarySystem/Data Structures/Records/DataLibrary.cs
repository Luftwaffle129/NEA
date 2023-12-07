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
        public static List<ReferenceClass<string, Member>> FirstNames
        {
            get { return _firstName; }
            set { _firstName = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region surname
        private static List<ReferenceClass<string, Member>> _surname = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> LastNames
        {
            get { return _surname; }
            set { _surname = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region member type
        private static List<ReferenceClass<MemberType, Member>> _memberTypes = new List<ReferenceClass<MemberType, Member>>();
        public static List<ReferenceClass<MemberType, Member>> MemberTypes
        {
            get { return _memberTypes; }
            set { _memberTypes = value ?? new List<ReferenceClass<MemberType, Member>>(); }
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
        public static List<ReferenceClass<T, F>> CreateReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, F reference, T item, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare, out int index) where F : class
        {
            ReferenceClass<T, F> referenceClass = new ReferenceClass<T, F>();
            referenceClass.Value = item;
            referenceClass.Reference = reference;
            itemList = AddReferenceClass(itemList, referenceClass, compare, out index);
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
        public static List<ReferenceClass<T, F>> AddReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> record, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare, out int index) where F : class
        {
            index = SearchAndSort.BinaryReferenceInsert(itemList, record, compare);
            itemList.Insert(index, record);
            return itemList;
        }
        /// <summary>
        /// Creates a new book copy and adds it to the list of book copies
        /// </summary>
        /// <param name="barcode">barcode of the new book copy</param>
        /// <param name="book">book of the new book copy</param>    
        public static void CreateBookCopy(string barcode, Book book)
        {
            BookCopies.Add(new BookCopy(barcode, book));
        }
        #endregion
        #region Modifying Records
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="list"></param>
        /// <param name="reference"></param>
        /// <param name="oldReferenceClass"></param>
        /// <param name="newValue"></param>
        /// <param name="compareValue"></param>
        /// <param name="compareRef"></param>
        /// <param name="newReferenceClass"></param>
        /// <returns></returns>
        public static List<ReferenceClass<T,F>> ModifyReferenceClass<T,F>(List<ReferenceClass<T, F>> list, F reference, ReferenceClass<T,F> oldReferenceClass, out ReferenceClass<T, F> newReferenceClass, T newValue, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            list = DeleteReferenceClass(list, oldReferenceClass, compare);
            list = CreateReferenceClass(list, reference, newValue, compare, out int index);
            newReferenceClass = list[index];
            return list;
        }
        public static List<ReferenceClass<T, F>> ModifyReferenceClassList<T, F>(List<ReferenceClass<T, F>> list, F reference, List<ReferenceClass<T, F>> oldReferenceClassList, out List<ReferenceClass<T, F>> newReferenceClassList, List<T> newValueList, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            // delete old references
            newReferenceClassList = new List<ReferenceClass<T, F>>();
            if (oldReferenceClassList.Count > 0)
                foreach (ReferenceClass<T, F> referenceClass in oldReferenceClassList)
                    list = DeleteReferenceClass(list, referenceClass, compare);
            oldReferenceClassList.Clear();
            // add new values as reference classes
            if (newValueList.Count > 0)
                foreach (T value in newValueList)
                {
                    list = CreateReferenceClass(list, reference, value, compare, out int index);
                    newReferenceClassList.Add(list[index]);
                }
            return list;
        }
        /// <summary>
        /// Updates a book record with the new information
        /// </summary>
        /// <param name="book">book to update</param>
        /// <param name="newBookInfo">new informatipn for the book</param>
        /// <returns>Updated book</returns>
        public static void ModifyBookRecord(Book book, BookCreator newBookInfo)
        {
            book.SeriesNumber = newBookInfo.SeriesNumber;
            book.Description = newBookInfo.Description;

            Titles = ModifyReferenceClass(Titles, book, book.Title, out book.Title, newBookInfo.Title, TwoRefClassBooks);
            SeriesTitles = ModifyReferenceClass(SeriesTitles, book, book.SeriesTitle, out book.SeriesTitle, newBookInfo.SeriesTitle, TwoRefClassBooks);
            Isbns = ModifyReferenceClass(Isbns, book, book.Isbn, out book.Isbn, newBookInfo.Isbn, TwoRefClassBooks);
            Prices = ModifyReferenceClass(Prices, book, book.Price, out book.Price, newBookInfo.Price, TwoRefClassBooks);
            MediaTypes = ModifyReferenceClass(MediaTypes, book, book.MediaType, out book.MediaType, newBookInfo.MediaType, TwoRefClassBooks);
            Authors = ModifyReferenceClass(Authors, book, book.Author, out book.Author, newBookInfo.Author, TwoRefClassBooks);
            Publishers = ModifyReferenceClass(Publishers, book, book.Publisher, out book.Publisher, newBookInfo.Publisher, TwoRefClassBooks);
            Genres = ModifyReferenceClassList(Genres, book, book.Genres, out book.Genres, newBookInfo.Genres, TwoRefClassBooks);
            Themes = ModifyReferenceClassList(Themes, book, book.Themes, out book.Themes, newBookInfo.Themes, TwoRefClassBooks);
        }
        public static void ModifyCirculationCopy(CirculationCopy circCopy, DateTime newDueDate)
        {
            CirculationDueDates = ModifyReferenceClass(CirculationDueDates, circCopy, circCopy.DueDate, out circCopy.DueDate, newDueDate, TwoCirculationCopies);
        }
        public static void ModifyMember(Member member, MemberCreator newMemberInfo)
        {
            MemberBarcodes = ModifyReferenceClass(MemberBarcodes, member, member.Barcode, out member.Barcode, newMemberInfo.Barcode, TwoMembers);
            FirstNames = ModifyReferenceClass(FirstNames, member, member.FirstName, out member.FirstName, newMemberInfo.FirstName, TwoMembers);
            LastNames = ModifyReferenceClass(LastNames, member, member.LastName, out member.LastName, newMemberInfo.LastName, TwoMembers);
            MemberTypes = ModifyReferenceClass(MemberTypes, member, member.Type, out member.Type, newMemberInfo.Type, TwoMembers);
            member.DateOfBirth = newMemberInfo.DateOfBirth;
            member.EmailAddress = newMemberInfo.EmailAddress;
            member.PhoneNumber = newMemberInfo.PhoneNumber;
            member.AddressLine1 = newMemberInfo.AddressLine1;
            member.AddressLine2 = newMemberInfo.AddressLine2;
            member.AddressLine3 = newMemberInfo.AddressLine3;
            member.AddressLine4 = newMemberInfo.AddressLine4;
            member.AddressLine5 = newMemberInfo.AddressLine5;
            member.Postcode = newMemberInfo.Postcode;
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
        public static List<ReferenceClass<T,F>> DeleteReferenceClass<T,F>(List<ReferenceClass<T,F>> itemList, ReferenceClass<T, F> item, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            itemList.RemoveAt(SearchAndSort.Binary(itemList, item, compare));
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
            Titles = DeleteReferenceClass(Titles, book.Title, TwoRefClassBooks);
            SeriesTitles = DeleteReferenceClass(SeriesTitles, book.SeriesTitle, TwoRefClassBooks);
            MediaTypes = DeleteReferenceClass(MediaTypes, book.MediaType, TwoRefClassBooks);
            Isbns = DeleteReferenceClass(Isbns, book.Isbn, TwoRefClassBooks);
            Prices = DeleteReferenceClass(Prices, book.Price, TwoRefClassBooks);
            Authors = DeleteReferenceClass(Authors, book.Author, TwoRefClassBooks);
            Publishers = DeleteReferenceClass(Publishers, book.Publisher,  TwoRefClassBooks);
            if (book.Genres.Count > 0)
                foreach (ReferenceClass<string, Book> genre in book.Genres)
                    Genres = DeleteReferenceClass(Genres, genre, TwoRefClassBooks);
            book.Genres.Clear();
            if (book.Themes.Count > 0)
                foreach (ReferenceClass<string, Book> theme in book.Themes)
                    Themes = DeleteReferenceClass(Themes, theme, TwoRefClassBooks);
            book.Themes.Clear();
            // delete book
            Books.Remove(book);
        }
        /// <summary>
        /// Deletes the member record with the inputted member barcode
        /// </summary>
        /// <param name="barcode">member barcode of member to be deleted</param>
        public static void DeleteMember(Member member)
        {
            // delete circulation references
            if (member.CircMemberRelations.Count > 0)
                foreach (CircMemberRelation circMemberRelation in member.CircMemberRelations)
                    DeleteCirculationCopy(circMemberRelation.CirculationCopy);
            // delete reference classes
            MemberBarcodes = DeleteReferenceClass(MemberBarcodes, member.Barcode, TwoMembers);
            FirstNames = DeleteReferenceClass(FirstNames, member.FirstName, TwoMembers);
            LastNames = DeleteReferenceClass(LastNames, member.LastName, TwoMembers);
            MemberTypes = DeleteReferenceClass(MemberTypes, member.Type, TwoMembers);
            // delete member
            Members.Remove(member);
        }
        /// <summary>
        /// Deletes the specified book copy and the references to it
        /// </summary>
        /// <param name="bookCopy">book copy to delete</param>
        public static void DeleteBookCopy(BookCopy bookCopy) 
        {
            // delete book copy relation
            bookCopy.BookRelation.Book.BookCopyRelations.Remove(bookCopy.BookRelation);
            BookCopyRelations.Remove(bookCopy.BookRelation);
            // delete barcode
            BookCopyBarcodes = DeleteReferenceClass(BookCopyBarcodes, bookCopy.Barcode, TwoBookCopyBarcodes);
            // delete circulation copy
            if (bookCopy.CirculationCopy != null)
                DeleteCirculationCopy(bookCopy.CirculationCopy);
            // delete book
            BookCopies.Remove(bookCopy);
        }
        public static void DeleteCirculationCopy(CirculationCopy circulationCopy)
        {
            // delete member relation
            circulationCopy.CircMemberRelation.Member.CircMemberRelations.Remove(circulationCopy.CircMemberRelation);
            CircMemberRelations.Remove(circulationCopy.CircMemberRelation);
            // delete book copy relation
            circulationCopy.BookCopy.CirculationCopy = null;
            // delete reference classes
            CirculationDueDates = DeleteReferenceClass(CirculationDueDates, circulationCopy.DueDate, TwoCirculationCopies);
            CirculationDates = DeleteReferenceClass(CirculationDates, circulationCopy.Date, TwoCirculationCopies);
            CirculationTypes = DeleteReferenceClass(CirculationTypes, circulationCopy.Type, TwoCirculationCopies);
            CirculationCopies.Remove(circulationCopy);
        }
        #endregion
        #endregion
    }
}