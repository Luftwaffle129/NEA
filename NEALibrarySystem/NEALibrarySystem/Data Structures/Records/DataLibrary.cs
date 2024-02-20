using NEALibrarySystem.Data_Structures.RecordCreators;
using NEALibrarySystem.Data_Structures.Records;
using System;
using System.Collections.Generic;
using static NEALibrarySystem.SearchAndSort;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Stores the records and methods to access their data
    /// </summary>
    public static class DataLibrary
    {
        public static Staff CurrentUser = new Staff();
        #region data structures
        // contains the lists of data stored by the program
        #region staffList
        private static List<Staff> _staffList = new List<Staff>();
        public static List<Staff> StaffList
        {
            get { return _staffList; }
            set { _staffList = value ?? new List<Staff>(); }
        }
        #endregion
        #region staffFirstNames
        private static List<ReferenceClass<string, Staff>> _staffFirstNames = new List<ReferenceClass<string, Staff>>();
        public static List<ReferenceClass<string, Staff>> StaffFirstNames
        {
            get { return _staffFirstNames; }
            set { _staffFirstNames = value ?? new List<ReferenceClass<string, Staff>>(); }
        }
        #endregion
        #region staffSurnames
        private static List<ReferenceClass<string, Staff>> _staffSurnames = new List<ReferenceClass<string, Staff>>();
        public static List<ReferenceClass<string, Staff>> StaffSurnames
        {
            get { return _staffSurnames; }
            set { _staffSurnames = value ?? new List<ReferenceClass<string, Staff>>(); }
        }
        #endregion
        #region staffUsernames
        private static List<ReferenceClass<string, Staff>> _staffUsernames = new List<ReferenceClass<string, Staff>>();
        public static List<ReferenceClass<string, Staff>> StaffUsernames
        {
            get { return _staffUsernames; }
            set { _staffUsernames = value ?? new List<ReferenceClass<string, Staff>>(); }
        }
        #endregion
        #region staffEmails
        private static List<ReferenceClass<string, Staff>> _staffEmails = new List<ReferenceClass<string, Staff>>();
        public static List<ReferenceClass<string, Staff>> StaffEmails
        {
            get { return _staffEmails; }
            set { _staffEmails = value ?? new List<ReferenceClass<string, Staff>>(); }
        }
        #endregion
        #region book copies
        private static List<BookCopy> _bookCopies = new List<BookCopy>();
        public static List<BookCopy> BookCopies
        {
            get { return _bookCopies; }
            set { _bookCopies = value ?? new List<BookCopy>(); }
        }
        #endregion
        #region book copy barcodes
        private static List<ReferenceClass<string, BookCopy>> _bookCopyBarcodes = new List<ReferenceClass<string, BookCopy>>();
        public static List<ReferenceClass<string, BookCopy>> BookCopyBarcodes
        {
            get { return _bookCopyBarcodes; }
            set { _bookCopyBarcodes = value ?? new List<ReferenceClass<string, BookCopy>>(); }
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
        #region member first name
        private static List<ReferenceClass<string, Member>> _memberFirstNames = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> MemberFirstNames
        {
            get { return _memberFirstNames; }
            set { _memberFirstNames = value ?? new List<ReferenceClass<string, Member>>(); }
        }
        #endregion
        #region surname
        private static List<ReferenceClass<string, Member>> _surnames = new List<ReferenceClass<string, Member>>();
        public static List<ReferenceClass<string, Member>> Surnames
        {
            get { return _surnames; }
            set { _surnames = value ?? new List<ReferenceClass<string, Member>>(); }
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
        #region circulation copies
        private static List<CirculationCopy> _circulationCopies = new List<CirculationCopy>();
        public static List<CirculationCopy> CirculationCopies
        {
            get { return _circulationCopies; }
            set { _circulationCopies = value ?? new List<CirculationCopy>(); }
        }
        #endregion
        #region circulation IDs
        private static List<ReferenceClass<int, CirculationCopy>> _circulationIds = new List<ReferenceClass<int, CirculationCopy>>();
        public static List<ReferenceClass<int, CirculationCopy>> CirculationIds
        {
            get { return _circulationIds; }
            set { _circulationIds = value ?? new List<ReferenceClass<int, CirculationCopy>>(); }
        }
        #endregion
        #region circulation copy types
        private static List<ReferenceClass<CirculationType, CirculationCopy>> _circulationTypes = new List<ReferenceClass<CirculationType, CirculationCopy>>();
        public static List<ReferenceClass<CirculationType, CirculationCopy>> CirculationTypes
        {
            get { return _circulationTypes; }
            set { _circulationTypes = value ?? new List<ReferenceClass<CirculationType, CirculationCopy>>(); }
        }
        #endregion
        #region circulation due dates
        private static List<ReferenceClass<DateTime, CirculationCopy>> _circulationDueDates = new List<ReferenceClass<DateTime, CirculationCopy>>();
        public static List<ReferenceClass<DateTime, CirculationCopy>> CirculationDueDates
        {
            get { return _circulationDueDates; }
            set { _circulationDueDates = value ?? new List<ReferenceClass<DateTime, CirculationCopy>>(); }
        }
        #endregion
        #region circulation dates
        private static List<ReferenceClass<DateTime, CirculationCopy>> _circulationDates = new List<ReferenceClass<DateTime, CirculationCopy>>();
        public static List<ReferenceClass<DateTime, CirculationCopy>> CirculationDates
        {
            get { return _circulationDates; }
            set { _circulationDates = value ?? new List<ReferenceClass<DateTime, CirculationCopy>>(); }
        }
        #endregion
        #region enums
        // contains the enums used when handling processes and form navigation
        public enum Feature // represents the current features in the main system form
        {
            Circulation,
            Book,
            Member,
            Staff,
            Backups,
            Settings,
            None = -1
        }
        public enum SearchFeature // represents the search features in the main system form
        {
            Book,
            Circulation,
            Member,
            Staff
        }
        public enum CirculationError // represents the circulation errors when circulating books
        {
            None,
            NoMember,
            NoBookCopies,
            InvalidBookCopies
        }
        #endregion
        #endregion
        #region data handling
        #region circulation
        /// <summary>
        /// Creates a loan of each book copy to the provided member if the inputted data is valid
        /// </summary>
        /// <param name="member">member loaning the books</param>
        /// <param name="bookCopies">book copies being loaned</param>
        /// <param name="returnDate">date that the books should be returned</param>
        /// <returns>Any errors that occured befored the books could be loaned</returns>
        public static CirculationError Loan(Member member, List<BookCopy> bookCopies, DateTime returnDate)
        {
            // check if necessary inputs exist
            if (member != null)
            {
                if (bookCopies.Count > 0)
                {
                    // check if the books can be loaned
                    bool validBooks = true;
                    int index = 0;
                    do
                    {
                        if (bookCopies[index].CirculationCopy != null)
                        {
                            // check if book is not loaned or reserved by another member
                            if (bookCopies[index].CirculationCopy.Type.Value == CirculationType.Loaned
                                || bookCopies[index].CirculationCopy.Member.Barcode.Value != member.Barcode.Value)
                                validBooks = false;
                        }
                    } while (++index < bookCopies.Count && validBooks);
                    if (validBooks)
                    {
                        // create a loan record for each book copy
                        foreach (BookCopy copy in bookCopies)
                        {
                            CirculationCopyCreator creator = new CirculationCopyCreator()
                            {
                                BookCopy = copy,
                                Member = member,
                                DueDate = returnDate,
                                Type = CirculationType.Loaned
                            };
                            DataLibrary.CirculationCopies.Add(new CirculationCopy(creator));
                        }
                        FileHandler.Save.CirculationCopies();
                        return CirculationError.None;
                    }
                    else
                        return CirculationError.InvalidBookCopies;
                }
                else
                    return CirculationError.NoBookCopies;
            }
            else
                return CirculationError.NoMember;
        }
        /// <summary>
        /// Returns the inputted book copies from the specified member
        /// </summary>
        /// <param name="member">Member returning the books</param>
        /// <param name="bookCopies">Book copies being returned</param>
        /// <returns>Any errors that occured befored the books could be returned</returns>
        public static CirculationError Return(Member member, List<BookCopy> bookCopies)
        {
            // check if necessary inputs exist
            if (member != null)
            {
                if (bookCopies.Count > 0)
                {
                    // check if the books can be returned
                    bool validBooks = true;
                    int index = 0;
                    do
                    {
                        // check if book is circulated
                        if (bookCopies[index].CirculationCopy != null)
                        {
                            // check if book is not reserved, and not loaned by another member
                            if (bookCopies[index].CirculationCopy.Type.Value == CirculationType.Reserved
                                || bookCopies[index].CirculationCopy.Member.Barcode.Value != member.Barcode.Value)
                                validBooks = false;
                        }
                        else
                            validBooks = false;

                    } while (++index < bookCopies.Count && validBooks);
                    if (validBooks)
                    {
                        // deletes the circulation copies of the returned books
                        foreach (BookCopy copy in bookCopies)
                        {
                            DeleteCirculationCopy(copy.CirculationCopy);
                        }
                        FileHandler.Save.CirculationCopies();
                        return CirculationError.None;
                    }
                    else
                        return CirculationError.InvalidBookCopies;
                }
                else
                    return CirculationError.NoBookCopies;
            }
            else
                return CirculationError.NoMember;
        }
        /// <summary>
        /// Sells the list of book copies and removes them from the program
        /// </summary>
        /// <param name="bookCopies">list of book copies to sell</param>
        /// <returns>Any errors that occured befored the books could be sold</returns>
        public static CirculationError Sell(List<BookCopy> bookCopies)
        {
            // check if necessary inputs exist
            if (bookCopies.Count > 0)
            {
                // check if the books can be sold
                bool validBooks = true;
                int index = 0;
                do
                {
                    // check if book is not circulated
                    if (bookCopies[index].CirculationCopy != null)
                        validBooks = false;
                } while (++index < bookCopies.Count && validBooks);
                if (validBooks)
                {
                    // remove the book copies from the program
                    foreach (BookCopy copy in bookCopies)
                    {
                        DeleteBookCopy(copy);
                    }
                    FileHandler.Save.BookCopies();
                    FileHandler.Save.CirculationCopies();
                    return CirculationError.None;
                }
                else
                    return CirculationError.InvalidBookCopies;
            }
            else
                return CirculationError.NoBookCopies;
        }
        /// <summary>
        /// Reserves the inputted book copies the the sepcifed member. Returns an error and does not carry out the reservation process in invalid data is inputted
        /// </summary>
        /// <param name="member">Member reserving the books</param>
        /// <param name="bookCopies">Book copies to reserve</param>
        /// <param name="pickUpByDate">Date the the reserved book should be picked up by</param>
        /// <returns>Errors encountered when reserving the books. Error value set to none if reservation was succesful</returns>
        public static CirculationError Reserve(Member member, List<BookCopy> bookCopies, DateTime pickUpByDate)
        {
            // check if necessary inputs exist
            if (member != null)
            {
                if (bookCopies.Count > 0)
                {
                    // check if the books can be reserved
                    bool validBooks = true;
                    int index = 0;
                    do
                    {
                        // check that books are not circulated
                        if (bookCopies[index].CirculationCopy != null)
                            validBooks = false;
                    } while (++index < bookCopies.Count && validBooks);
                    if (validBooks)
                    {
                        // create a reservation record for each book copy
                        foreach (BookCopy copy in bookCopies)
                        {
                            CirculationCopyCreator creator = new CirculationCopyCreator()
                            {
                                BookCopy = copy,
                                Member = member,
                                DueDate = pickUpByDate,
                                Type = CirculationType.Reserved
                            };
                            DataLibrary.CirculationCopies.Add(new CirculationCopy(creator));
                        }
                        FileHandler.Save.CirculationCopies();
                        return CirculationError.None;
                    }
                    else
                        return CirculationError.InvalidBookCopies;
                }
                else
                    return CirculationError.NoBookCopies;
            }
            else
                return CirculationError.NoMember;
        }
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
            index = SearchAndSort.BinaryInsert(itemList, record, compare);
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
        /// Modifies a reference class by deleting the old one and replacing it
        /// </summary>
        /// <typeparam name="T">Value of the reference class</typeparam>
        /// <typeparam name="F">Reference of the reference class</typeparam>
        /// <param name="list">List of reference classes</param>
        /// <param name="reference">Reference of the new reference class</param>
        /// <param name="oldReferenceClass">Old reference class to delete</param>
        /// <param name="newValue">New value of the reference class</param>
        /// <param name="compare">Comparison algorithm when searching and inserting reference classes in the list</param>
        /// <param name="newReferenceClass">Reference class that was changed</param>
        /// <returns>Updated list of the reference classes</returns>
        public static List<ReferenceClass<T, F>> ModifyReferenceClass<T, F>(List<ReferenceClass<T, F>> list, F reference, ReferenceClass<T, F> oldReferenceClass, out ReferenceClass<T, F> newReferenceClass, T newValue, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            list = DeleteReferenceClass(list, oldReferenceClass, compare);
            list = CreateReferenceClass(list, reference, newValue, compare, out int index);
            newReferenceClass = list[index];
            return list;
        }
        /// <summary>
        /// Modifies a reference class by deleting the old reference classes and replacing them
        /// </summary>
        /// <typeparam name="T">Value of the reference class</typeparam>
        /// <typeparam name="F">Reference of the reference class</typeparam>
        /// <param name="list">List of reference classes</param>
        /// <param name="reference">Reference of the new reference class</param>
        /// <param name="oldReferenceClassList">Old reference classes to delete</param>
        /// <param name="newReferenceClassList">New reference classes that were added</param>
        /// <param name="newValueList">New values to make reference classes for</param>
        /// <param name="compare">Comparison algorithm when searching and inserting reference classes in the list</param>
        /// <returns>Updated list of the reference classes</returns>
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
        /// Modifies a member record with the new information in the member creator class
        /// </summary>
        /// <param name="member">Member to update</param>
        /// <param name="newMemberInfo">Information to update the member details with</param>
        public static void ModifyMember(Member member, MemberCreator newMemberInfo)
        {
            MemberBarcodes = ModifyReferenceClass(MemberBarcodes, member, member.Barcode, out member.Barcode, newMemberInfo.Barcode, TwoRefClassMembers);
            MemberFirstNames = ModifyReferenceClass(MemberFirstNames, member, member.FirstName, out member.FirstName, newMemberInfo.FirstName, TwoRefClassMembers);
            Surnames = ModifyReferenceClass(Surnames, member, member.Surname, out member.Surname, newMemberInfo.Surname,  TwoRefClassMembers);
            MemberTypes = ModifyReferenceClass(MemberTypes, member, member.Type, out member.Type, (MemberType)DataFormatter.StringToEnum<MemberType>(newMemberInfo.Type), TwoRefClassMembers);
            member.DateOfBirth = newMemberInfo.DateOfBirth;
            member.EmailAddress = newMemberInfo.EmailAddress;
            member.PhoneNumber = newMemberInfo.PhoneNumber;
            member.Address1 = newMemberInfo.Address1;
            member.Address2 = newMemberInfo.Address2;
            member.TownCity = newMemberInfo.TownCity;
            member.County = newMemberInfo.County;
            member.Postcode = newMemberInfo.Postcode;

            // remove member links
            if (member.LinkedMembers.Count > 0)
                foreach (Member link in member.LinkedMembers)
                    member.RemoveMemberLink(link);
            // add new member links
            if (newMemberInfo.LinkedMembers.Count > 0)
                foreach (string link in newMemberInfo.LinkedMembers)
                    member.AddMemberLink(link);
        }
        /// <summary>
        /// Modifies a staff record with the new information in the staff creator class
        /// </summary>
        /// <param name="staff">Staff to update</param>
        /// <param name="newStaffInfo">Information to update the staff details with</param>
        public static void ModifyStaff(Staff staff, StaffCreator newStaffInfo)
        {
            StaffFirstNames = ModifyReferenceClass(StaffFirstNames, staff, staff.FirstName, out staff.FirstName, newStaffInfo.FirstName, TwoRefClassStaff);
            StaffSurnames = ModifyReferenceClass(StaffSurnames, staff, staff.Surname, out staff.Surname, newStaffInfo.Surname, TwoRefClassStaff);
            StaffUsernames = ModifyReferenceClass(StaffUsernames, staff, staff.Username, out staff.Username, newStaffInfo.Username, TwoRefClassStaff);
            
            staff.Password = newStaffInfo.Password;
            staff.EmailAddress = newStaffInfo.EmailAddress;
            staff.IsAdministrator = newStaffInfo.IsAdministrator;
        }
        #endregion
        #region Deleting records
        /// <summary>
        /// Removes the specified reference class from a list of reference classes
        /// </summary>
        /// <typeparam name="T">Value of the reference class</typeparam>
        /// <typeparam name="F">Class that the reference classes refer to</typeparam>
        /// <param name="itemList">List of reference classes</param>
        /// <param name="item">Reference class to remove</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>The updated list</returns>
        public static List<ReferenceClass<T, F>> DeleteReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            itemList.RemoveAt(SearchAndSort.Binary(itemList, item, compare));
            return itemList;
        }
        /// <summary>
        /// Removes the book and it's references from the system
        /// </summary>
        /// <param name="book">Book to be deleted</param>
        public static void DeleteBook(Book book)
        {
            //delete book copies
            while (book.BookCopies.Count > 0)
            {
                DeleteBookCopy(book.BookCopies[0]);
            }
            // delete references
            Titles = DeleteReferenceClass(Titles, book.Title, TwoRefClassBooks);
            SeriesTitles = DeleteReferenceClass(SeriesTitles, book.SeriesTitle, TwoRefClassBooks);
            MediaTypes = DeleteReferenceClass(MediaTypes, book.MediaType, TwoRefClassBooks);
            Isbns = DeleteReferenceClass(Isbns, book.Isbn, TwoRefClassBooks);
            Prices = DeleteReferenceClass(Prices, book.Price, TwoRefClassBooks);
            Authors = DeleteReferenceClass(Authors, book.Author, TwoRefClassBooks);
            Publishers = DeleteReferenceClass(Publishers, book.Publisher, TwoRefClassBooks);
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
            FileHandler.Save.Books();
        }
        /// <summary>
        /// Deletes the member record with the inputted member barcode
        /// </summary>
        /// <param name="member">Member barcode of member to be deleted</param>
        public static void DeleteMember(Member member)
        {
            // delete circulation references
            while (member.Circulations.Count > 0)
            {
                DeleteCirculationCopy(member.Circulations[0]);
            }
            // delete reference classes
            MemberBarcodes = DeleteReferenceClass(MemberBarcodes, member.Barcode, TwoRefClassMembers);
            MemberFirstNames = DeleteReferenceClass(MemberFirstNames, member.FirstName, TwoRefClassMembers);
            Surnames = DeleteReferenceClass(Surnames, member.Surname, TwoRefClassMembers);
            MemberTypes = DeleteReferenceClass(MemberTypes, member.Type, TwoRefClassMembers);
            foreach (Member linkedMember in member.LinkedMembers)
            {
                member.RemoveMemberLink(linkedMember);
            }
            // delete member
            Members.Remove(member);
            FileHandler.Save.Members();
        }
        /// <summary>
        /// Deletes the specified book copy and the references to it
        /// </summary>
        /// <param name="bookCopy">book copy to delete</param>
        public static void DeleteBookCopy(BookCopy bookCopy)
        {
            // delete book copy relation
            bookCopy.Book.BookCopies.Remove(bookCopy);
            // delete barcode
            BookCopyBarcodes = DeleteReferenceClass(BookCopyBarcodes, bookCopy.Barcode, TwoBookCopyBarcodes);
            // delete circulation copy
            if (bookCopy.CirculationCopy != null)
                DeleteCirculationCopy(bookCopy.CirculationCopy);
            BookCopies.Remove(bookCopy);
            FileHandler.Save.BookCopies();
        }
        /// <summary>
        /// Deletes the specified circulation copy and its relation
        /// </summary>
        /// <param name="circulationCopy">Circulation copy to delete</param>
        public static void DeleteCirculationCopy(CirculationCopy circulationCopy)
        {
            // delete member relation
            circulationCopy.Member.Circulations.Remove(circulationCopy);
            // delete book copy relation
            circulationCopy.BookCopy.CirculationCopy = null;
            // delete reference classes
            CirculationDueDates = DeleteReferenceClass(CirculationDueDates, circulationCopy.DueDate, TwoRefClassCircCopies);
            CirculationDates = DeleteReferenceClass(CirculationDates, circulationCopy.Date, TwoRefClassCircCopies);
            CirculationTypes = DeleteReferenceClass(CirculationTypes, circulationCopy.Type, TwoRefClassCircCopies);
            CirculationCopies.Remove(circulationCopy);
            FileHandler.Save.CirculationCopies();
        }
        /// <summary>
        /// Deletes the specified staff record and its reference classes
        /// </summary>
        /// <param name="staff">Staff to delete</param>
        public static void DeleteStaff(Staff staff)
        {
            // delete reference classes
            StaffFirstNames = DeleteReferenceClass(StaffFirstNames, staff.FirstName, TwoRefClassStaff);
            StaffSurnames = DeleteReferenceClass(StaffSurnames, staff.Surname, TwoRefClassStaff);
            StaffUsernames = DeleteReferenceClass(StaffUsernames, staff.Username, TwoRefClassStaff);
            // delete record
            StaffList.Remove(staff);
            FileHandler.Save.Staff();

        }
        #endregion
        #endregion
        #region Clear all data
        public static class ClearData
        {
            /// <summary>
            /// Clears all stored data
            /// </summary>
            public static void All()
            {
                Book();
                Member();
                BookCopy();
                CirculationCopy();
                Staff();
            }
            /// <summary>
            /// Clears all stored book data
            /// </summary>
            public static void Book()
            {
                _books.Clear();
                _titles.Clear();
                _seriesTitles.Clear();
                _isbns.Clear();
                _prices.Clear();
                _mediaTypes.Clear();
                _authors.Clear();
                _publishers.Clear();
                _themes.Clear();
                _genres.Clear();
            }
            /// <summary>
            /// Clears all stored member data
            /// </summary>
            public static void Member()
            {
                _members.Clear();
                _memberBarcodes.Clear();
                _memberFirstNames.Clear();
                _surnames.Clear();
                _memberTypes.Clear();
            }
            /// <summary>
            /// Clears all stored book copy data
            /// </summary>
            public static void BookCopy()
            {
                _bookCopies.Clear();
                _bookCopyBarcodes.Clear();
            }
            /// <summary>
            /// Clears all stored circulation data
            /// </summary>
            public static void CirculationCopy()
            {
                _circulationIds.Clear();
                _circulationCopies.Clear();
                _circulationTypes.Clear();
                _circulationDueDates.Clear();
                _circulationDates.Clear();
            }
            /// <summary>
            /// Clears all stored staff data
            /// </summary>
            public static void Staff()
            {
                StaffList.Clear();
                StaffFirstNames.Clear();
                StaffSurnames.Clear();
                StaffUsernames.Clear();
            }
        }
        #endregion
    }
}