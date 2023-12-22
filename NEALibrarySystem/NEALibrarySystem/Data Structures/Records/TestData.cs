using NEALibrarySystem.Data_Structures.Records;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Used to create and load test data into the project
    /// </summary>
    public class TestData
    {
        private Random rand = new Random();

        private string[] firstNames =
        {
            "eve",
            "adam",
            "james",
            "jacob",
            "sam",
            "andrew",
            "finn",
            "joe",
            "ben",
            "sakchyam"
        };
        private string[] lastNames =
        {
            "Smith",
            "Johnson",
            "Williams",
            "Jones",
            "Brown",
            "Davis",
            "Miller",
            "Wilson",
            "Taylor",
            "Anderson",
            "Thomas",
            "Jackson",
            "White",
            "Harris",
            "Martin",
            "Thompson",
            "Garcia",
            "Martinez",
            "Robinson"
        };
        private string[] titles =
        {
            "The Great Gatsby",
            "To Kill a Mockingbird",
            "1984",
            "Pride and Prejudice",
            "The Catcher in the Rye",
            "The Hobbit",
            "Brave New World",
            "The Lord of the Rings",
            "Harry Potter and the Sorcerer's Stone",
            "The Da Vinci Code",
            "The Hunger Games",
            "Fahrenheit 451",
            "Animal Farm",
            "The Chronicles of Narnia",
            "The Alchemist",
            "The Shining",
            "The Girl with the Dragon Tattoo",
            "The Fault in Our Stars",
            "Gone with the Wind",
            "A Tale of Two Cities"
        };
        /// <summary>
        /// Clears data structures and inserts test data
        /// </summary>
        public void GenerateTestData()
        {
            //set up staff
            DataLibrary.CurrentUser = new Staff();
            DataLibrary.CurrentUser.IsAdministrator = true;

            // set up settings details
            Settings.MemberBarcodeLength = 3;
            Settings.LoanDurations = new int[3] { 14, 7, 5 };
            Settings.ReserveDurations = new int[3] { 7, 6, 5 };
            Settings.BookCopyBarcodeLength = 3;

            DataLibrary.ClearData.All();
            GenerateBooks();
            GenerateMembers();
            GenerateCirculationCopies();
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
        /// <summary>
        /// create 10 random book records with no copies attached to them
        /// </summary>
        private void GenerateBooks()
        {
            for (int i = 0; i < 10; i++)
            {
                BookCreator bookCreator = new BookCreator();
                bookCreator.Title = titles[rand.Next(0, titles.Length)];
                bookCreator.SeriesTitle = titles[rand.Next(0, titles.Length)];
                string isbn = "";
                for (int j = 0; j < 13; j++)
                {
                    isbn += GenerateRandomDigit().ToString();
                }
                bookCreator.Isbn = isbn;
                bookCreator.MediaType = GenerateRandomString(10);
                bookCreator.Author = GenerateRandomString(10);
                bookCreator.Publisher = GenerateRandomString(10);
                List<string> genres = new List<string>();
                for (int j = 0; j < 2; j++)
                    genres.Add(GenerateRandomString(10));
                bookCreator.Genres = genres;
                List<string> themes = new List<string>();
                for (int j = 0; j < 2; j++)
                    themes.Add(GenerateRandomString(10));
                bookCreator.Themes = themes;
                bookCreator.Description = GenerateRandomString(10);
                bookCreator.Price = 9.99;
                Book book = new Book(bookCreator);
                int copyCount = rand.Next(0, 10);
                if (copyCount > 0)
                {
                    for (int j = 0; j < copyCount; j++)
                    {
                        string barcode = "";
                        for (int k = 0; k < Settings.BookCopyBarcodeLength; k++)
                            barcode += GenerateRandomDigit();
                        DataLibrary.BookCopies.Add(new BookCopy(barcode, book));
                    }
                }
                DataLibrary.Books.Add(book);
            }
        }
        /// <summary>
        /// generates 10 random members
        /// </summary>
        private void GenerateMembers()
        {
            for (int i = 0; i < 10; i++)
            {
                MemberCreator memberCreator = new MemberCreator();
                string barcode = "";
                bool uniqueCode = false;
                do
                {
                    for (int j = 0; j < Settings.MemberBarcodeLength; j++)
                    {
                        barcode += GenerateRandomDigit().ToString();
                    }
                    if (SearchAndSort.Binary(DataLibrary.MemberBarcodes, barcode, SearchAndSort.RefClassAndString) == -1)
                        uniqueCode = true;
                } while (!uniqueCode);
                memberCreator.Barcode = barcode;
                memberCreator.FirstName = firstNames[rand.Next(0, firstNames.Length)];
                memberCreator.Surname = lastNames[rand.Next(0, lastNames.Length)];
                memberCreator.Postcode = $"{GenerateRandomLetter()}{GenerateRandomLetter()}{GenerateRandomDigit()} {GenerateRandomDigit(19)}{GenerateRandomLetter()}{GenerateRandomLetter()}";
                memberCreator.EmailAddress = $"{GenerateRandomString(10)}@gmail.com";
                string phoneNumber = "";
                for (int j = 0; j < 11; j++)
                {
                    phoneNumber += GenerateRandomDigit().ToString();
                }
                memberCreator.PhoneNumber = phoneNumber;
                memberCreator.Address1 = "Exeter rd";
                memberCreator.Address2 = "Fotlondys";
                memberCreator.TownCity = "Exeter";
                memberCreator.County = "Devon";
                memberCreator.DateOfBirth = Convert.ToDateTime("11/07/2006");
                memberCreator.JoinDate = Convert.ToDateTime("24/12/2020");
                memberCreator.Type = (MemberType)rand.Next(0, Member.TypeCount);
                DataLibrary.Members.Add(new Member(memberCreator));
            }
        }
        private void GenerateCirculationCopies()
        {
            foreach (var member in DataLibrary.Members)
            {
                int count = rand.Next(0, 3);
                if (count > 0)
                {
                    List<BookCopy> copies = new List<BookCopy>();
                    for (int i = 0; i < count; i++)
                    {
                        int index = rand.Next(0, DataLibrary.BookCopies.Count);
                        if (SearchAndSort.Binary(DataLibrary.CirculationCopies, DataLibrary.BookCopies[index], SearchAndSort.CircCopyAndBookCopy) == -1)
                        {
                            copies.Add(DataLibrary.BookCopies[index]);
                        }
                    }
                    DataLibrary.Loan(member, copies, DateTime.Today.AddDays(rand.Next(1, 14)));
                }
            }
        }
        private int GenerateRandomDigit(int max = 10)
        {
            return rand.Next(0, max);
        }
        private string GenerateRandomLetter()
        {
            int temp = rand.Next(0, 26) + 97;
            return Convert.ToChar(temp).ToString();
        }
        private string GenerateRandomString(int length)
        {
            string output = "";
            for (int i = 0; i <length; i++)
            {
                output += GenerateRandomLetter();
            }
            return output;
        }
    }
}
