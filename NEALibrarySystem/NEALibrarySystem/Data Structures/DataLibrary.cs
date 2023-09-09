using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NEALibrarySystem.Data_Structures
{
    public static class DataLibrary
    {
        public static List<Book> books = new List<Book>();
        public static List<BookCopy> bookCopies = new List<BookCopy>();
        public static List<Member> members = new List<Member>();
        public static List<ItemID> titles = new List<ItemID>();
        public static List<ItemID> mediaTypes = new List<ItemID>();
        public static List<ItemID> authors = new List<ItemID>();
        public static List<ItemID> publishers = new List<ItemID>();
        public static List<ItemID> genres = new List<ItemID>();
        public static List<ItemID> themes = new List<ItemID>();
        public static List<Staff> staff = new List<Staff>();

        #region Load Files
        /// <summary>
        /// Reads all files and load data into the appropiate data structures
        /// </summary>
        public static void LoadDataFromFiles()
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
        #endregion
    }
}
