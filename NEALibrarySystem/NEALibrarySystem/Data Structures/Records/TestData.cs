using NEALibrarySystem.Data_Structures.Records;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        private string[] _firstNames =
        {
            "Eve",
            "Adam",
            "James",
            "Jacob",
            "Sam",
            "Andrew",
            "Finn",
            "Joe",
            "Ben",
            "Sakchyam"
        };
        private string[] _lastNames =
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
        private string[] _titles =
        {
            "The Great Gatsby",
            "To Kill a Mockingbird",
            "1984",
            "Pride and Prejudice",
            "The Catcher in the Rye",
            "The Hobbit",
            "Brave New World",
            "The Lord of the Rings",
            "Harry Potter",
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
        private string[] _seriesTitles =
        {
            "Forgotten Shadow",
            "Part Two",
            "Rush",
            "Gosling",
            "",
            ""
        };
        private string[] _mediaTypes =
        {
            "Hard Cover",
            "Hard Cover",
            "Hard Cover",
            "Paperback",
            "Paperback",
            "Paperback",
            "CD"
        };
        private string[] _authors = 
        {
            "F. Scott Fitzgerald",
            "Harper Lee",
            "George Orwell",
            "Jane Austen",
            "J.D. Salinger",
            "J.R.R. Tolkien",
            "Aldous Huxley",
            "J.K. Rowling",
            "Dan Brown",
            "Suzanne Collins"
        };
        private string[] _publishers = 
        {
            "Penguin Random House",
            "HarperCollins",
            "Simon & Schuster",
            "Macmillan Publishers",
            "Hachette Book Group",
            "Scholastic Corporation",
            "Pearson PLC",
            "Wiley",
            "Oxford University Press",
            "Bloomsbury Publishing"
        };
        private string[] _genres = 
        {
            "Mystery",
            "Science Fiction",
            "Fantasy",
            "Romance",
            "Thriller",
            "Historical Fiction",
            "Biography",
            "Horror",
            "Non-Fiction",
            "Adventure"
        };
        private string[] _themes = 
        {
            "Medieval",
            "Identity",
            "Conflict",
            "Survival",
            "Discovery",
            "Justice",
            "Technology",
            "Nature",
            "Injustice",
            "Family"
        };

        /// <summary>
        /// Clears data structures and inserts test data
        /// </summary>
        public void GenerateTestData()
        {

            DataLibrary.ClearData.All();
            GenerateBooks();
            GenerateMembers();
            GenerateCirculationCopies();
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            FileHandler.Save.All();
        }
        public void GenerateTestParameters()
        {
            //set up staff
            DataLibrary.CurrentUser = new Staff();
            DataLibrary.CurrentUser.IsAdministrator = true;

            // set up settings details
            Settings.MemberBarcodeLength = 10;
            Settings.LoanDurations = new int[3] { 14, 7, 5 };
            Settings.ReserveDurations = new int[3] { 7, 6, 5 };
            Settings.BookCopyBarcodeLength = 6;
            Settings.LateFeePerDay = 0.05;
        }
        /// <summary>
        /// create 10 random book records with no copies attached to them
        /// </summary>
        private void GenerateBooks()
        {
            for (int i = 0; i < 10; i++)
            {
                BookCreator bookCreator = new BookCreator();
                bookCreator.Title = _titles[rand.Next(0, _titles.Length)];
                bookCreator.SeriesTitle = _seriesTitles[rand.Next(0, _seriesTitles.Length)];
                bool unique = false; // used to identify if an item is not already contained within a list
                int counter; // used for adding random number of items to a list
                string isbn;
                do
                {
                    isbn = "";
                    for (int j = 0; j < Settings.ISBNLENGTH; j++)
                    {
                        isbn += GenerateRandomDigit().ToString();
                    }
                    if (SearchAndSort.Binary(DataLibrary.Isbns, isbn, SearchAndSort.RefClassAndString) == -1)
                        unique = true;
                } while (!unique) ;
                bookCreator.Isbn = isbn;
                bookCreator.MediaType = _mediaTypes[rand.Next(0, _mediaTypes.Length)];
                bookCreator.Author = _authors[rand.Next(0, _authors.Length)];
                bookCreator.Publisher = _publishers[rand.Next(0, _publishers.Length)];
                List<string> genres = new List<string>();
                counter = rand.Next(0, 3);
                if (counter > 0)
                    for (int j = 0; j < counter; j++)
                    {
                        string genreToAdd;
                        unique = false;
                        do
                        {
                            genreToAdd = _genres[rand.Next(0, _genres.Length)];
                            if (!genres.Contains(genreToAdd))
                                unique = true;
                        } while (!unique);
                        genres.Add(genreToAdd);
                    }
                bookCreator.Genres = genres;
                List<string> themes = new List<string>();
                counter = rand.Next(0, 3);
                if (counter > 0)
                    for (int j = 0; j < 2; j++)
                    {
                        string themeToAdd;
                        unique = false;
                        do
                        {
                            themeToAdd = _themes[rand.Next(0, _themes.Length)];
                            if (!genres.Contains(themeToAdd))
                                unique = true;
                        } while (!unique);
                        themes.Add(themeToAdd);
                    }
                bookCreator.Themes = themes;
                bookCreator.Description = rand.Next(0,2) == 0 ? "" : "This is a book";
                bookCreator.Price = (Convert.ToDouble(rand.Next(100, 2000)) / 100).ToString();
                Book book = new Book(bookCreator);
                int copyCount = rand.Next(0, 10);
                if (copyCount > 0)
                {
                    for (int j = 0; j < copyCount; j++)
                    {
                        unique = false;
                        string barcode;
                        do
                        {
                            barcode = "";
                            for (int k = 0; k < Settings.BookCopyBarcodeLength; k++)
                                barcode += GenerateRandomDigit();
                            if (SearchAndSort.Binary(DataLibrary.BookCopyBarcodes, barcode, SearchAndSort.RefClassAndString) == -1)
                                unique = true;
                        } while (!unique);
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
                memberCreator.FirstName = _firstNames[rand.Next(0, _firstNames.Length)];
                memberCreator.Surname = _lastNames[rand.Next(0, _lastNames.Length)];
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
                memberCreator.Type = ((MemberType)rand.Next(0, Member.TypeCount)).ToString();
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
