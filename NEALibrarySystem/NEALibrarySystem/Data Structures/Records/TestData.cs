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
        // realistic test data for creating records
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
        private string[] _emails =
        {
            "keon_Trinh",
            "booklover123",
            "CuriousMind",
            "READER_JT",
            "ExampleText",
            "21testNames12",
            "F",
            "HarmoniousCat",
            "_Suhkoi27_",
            "HamptonFamily"
        };
        private string[] _address1 =
{
            "Maple Avenue",
            "Elm Street",
            "Meadow Lane",
            "Cedar Drive",
            "Willow Street",
            "Oakwood Avenue",
            "Pinecrest Road",
            "Sunset Boulevard",
            "Lakeside Drive",
            "Magnolia Lane"
        };
        private string[] _address2 =
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Willbrook Cottage",
        };
        private string[] _townCity =
        {
            "Torquay",
            "Newton Abbot",
            "Exeter",
            "Dawlish",
            "Teignmouth"
        };
        private string[] _county =
{
            "Cornwall",
            "Devon",
            "Somerset"
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
        /// <summary>
        /// Sets up example setting properties and a staff placeholder for te current user
        /// </summary>
        public void GenerateTestParameters()
        {
            // set up settings details
            Settings.MemberBarcodeLength = 10;
            Settings.LoanDurations = new int[3] { 14, 7, 5 };
            Settings.ReserveDurations = new int[3] { 14, 7, 5 };
            Settings.BookCopyBarcodeLength = 6;
            Settings.LateFeePerDay = 0.05;
        }
        /// <summary>
        /// Create 10 random book records with a up to 10 book copies for each book
        /// </summary>
        private void GenerateBooks()
        {
            for (int i = 0; i < 10; i++)
            {
                BookCreator bookCreator = new BookCreator();
                bookCreator.Title = _titles[rand.Next(0, _titles.Length)]; // get random realistic title
                bookCreator.SeriesTitle = _seriesTitles[rand.Next(0, _seriesTitles.Length)]; // get random realistic series title
                // sets realistic series number
                if (_seriesTitles.Length > 0)
                    bookCreator.SeriesNumber = rand.Next(1, 4).ToString();
                else
                    bookCreator.SeriesNumber = "1";
                bool unique = false; // used to identify if an item is not already contained within a list
                int counter; // used for adding random number of items to a list
                // generate a random unique ISBN number
                string isbn;
                do
                {
                    isbn = "";
                    for (int j = 0; j < Settings.ISBNLENGTH; j++)
                    {
                        isbn += GenerateRandomDigit().ToString(); // generate random ISBN
                    }
                    if (SearchAndSort.Binary(DataLibrary.Isbns, isbn, SearchAndSort.RefClassAndString) == -1) // if it is not unique, generate a new ISBN
                        unique = true;
                } while (!unique) ;
                bookCreator.Isbn = isbn;
                bookCreator.MediaType = _mediaTypes[rand.Next(0, _mediaTypes.Length)]; // get random realistic media type
                bookCreator.Author = _authors[rand.Next(0, _authors.Length)]; // get random realistic author
                bookCreator.Publisher = _publishers[rand.Next(0, _publishers.Length)]; // get random realistic publisher
                // generate 0-3 genres for the book
                List<string> genres = new List<string>();
                counter = rand.Next(0, 3);
                if (counter > 0)
                    for (int j = 0; j < counter; j++)
                    {
                        string genreToAdd;
                        unique = false;
                        do
                        {
                            genreToAdd = _genres[rand.Next(0, _genres.Length)]; // get a random genre
                            if (!genres.Contains(genreToAdd)) // if book already has the genre, generate a new one
                                unique = true;
                        } while (!unique);
                        genres.Add(genreToAdd);
                    }
                bookCreator.Genres = genres;
                // generate 0-3 themes for the book
                List<string> themes = new List<string>();
                counter = rand.Next(0, 3);
                if (counter > 0)
                    for (int j = 0; j < 2; j++)
                    {
                        string themeToAdd;
                        unique = false;
                        do
                        {
                            themeToAdd = _themes[rand.Next(0, _themes.Length)]; // get a random theme
                            if (!themes.Contains(themeToAdd)) // if book already has the theme, generate a new one
                                unique = true;
                        } while (!unique);
                        themes.Add(themeToAdd);
                    }
                bookCreator.Themes = themes;
                bookCreator.Description = rand.Next(0,2) == 0 ? "" : "This is a book"; // generate a description
                bookCreator.Price = (Convert.ToDouble(rand.Next(100, 2000)) / 100).ToString(); // generate a price between £1 and £20
                Book book = new Book(bookCreator);
                // generate 0-10 book copies for the new book
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
                            // generate a random barcode
                            for (int k = 0; k < Settings.BookCopyBarcodeLength; k++)
                                barcode += GenerateRandomDigit();
                            // if it is a unique barcode, exit the loop, else create a new barcode
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
                // generate a unique barcode
                string barcode = "";
                bool uniqueCode = false;
                do
                {
                    // generate a random barcode
                    for (int j = 0; j < Settings.MemberBarcodeLength; j++)
                    {
                        barcode += GenerateRandomDigit().ToString();
                    }
                    // if it is a unique barcode, exit the loop, else create a new barcode 
                    if (SearchAndSort.Binary(DataLibrary.MemberBarcodes, barcode, SearchAndSort.RefClassAndString) == -1)
                        uniqueCode = true;
                } while (!uniqueCode);
                memberCreator.Barcode = barcode;
                memberCreator.FirstName = _firstNames[rand.Next(0, _firstNames.Length)]; // generate a realistic random first name
                memberCreator.Surname = _lastNames[rand.Next(0, _lastNames.Length)]; // generate a realistic random surname
                memberCreator.Postcode = $"{GenerateRandomLetter()}{GenerateRandomLetter()}{GenerateRandomDigit()} {GenerateRandomDigit(19)}{GenerateRandomLetter()}{GenerateRandomLetter()}"; // generate a random standard postcode
                memberCreator.EmailAddress = $"{_emails[rand.Next(0, _emails.Length)]}@gmail.com"; // generate realistic random email
                // generate a random phone number
                string phoneNumber = "";
                for (int j = 0; j < 11; j++)
                {
                    phoneNumber += GenerateRandomDigit().ToString();
                }
                memberCreator.PhoneNumber = phoneNumber;
                memberCreator.Address1 = _address1[rand.Next(0, _address1.Length)];
                memberCreator.Address2 = _address2[rand.Next(0, _address2.Length)];
                memberCreator.TownCity = _townCity[rand.Next(0, _townCity.Length)];
                memberCreator.County = _county[rand.Next(0, _county.Length)];
                memberCreator.DateOfBirth = Convert.ToDateTime(DateTime.Now.AddDays(-rand.Next(365 * 5, 365 * 90)));
                memberCreator.JoinDate = Convert.ToDateTime(DateTime.Now.AddDays(-rand.Next(0, 365 * 2)));
                memberCreator.Type = ((MemberType)rand.Next(0, Member.TypeCount)).ToString();
                DataLibrary.Members.Add(new Member(memberCreator));
            }
        }
        private void GenerateCirculationCopies()
        {
            // generate 0-3 circulation copies for each member
            foreach (var member in DataLibrary.Members)
            {
                int count = rand.Next(0, 3);
                if (count > 0)
                {
                    List<BookCopy> copies = new List<BookCopy>();
                    for (int i = 0; i < count; i++)
                    {
                        int index = rand.Next(0, DataLibrary.BookCopies.Count); // get a random existing book copy index
                        if (SearchAndSort.Binary(DataLibrary.CirculationCopies, DataLibrary.BookCopies[index], SearchAndSort.CircCopyAndBookCopy) == -1) // if book copy is not circulated
                        {
                            copies.Add(DataLibrary.BookCopies[index]);
                        }
                    }
                    // randomly loan or reserve the found book copy
                    if (rand.Next(0,2) == 0)
                        DataLibrary.Loan(member, copies, DateTime.Today.AddDays(rand.Next(1, 14)));
                    else
                        DataLibrary.Reserve(member, copies, DateTime.Today.AddDays(rand.Next(1, 14)));
                }
            }
        }
        /// <summary>
        /// Generates a random digit from 0 to the specifed number exclusive. 0-9 if number is not specified
        /// </summary>
        /// <param name="max">Max number to generate a digit from</param>
        /// <returns>Random digit</returns>
        private int GenerateRandomDigit(int max = 10)
        {
            return rand.Next(0, max);
        }
        /// <summary>
        /// Generates a random letter
        /// </summary>
        /// <returns>Random letter</returns>
        private string GenerateRandomLetter()
        {
            int temp = rand.Next(0, 26) + 97; // generates an character code in the a-z range
            return Convert.ToChar(temp).ToString();
        }
    }
}
