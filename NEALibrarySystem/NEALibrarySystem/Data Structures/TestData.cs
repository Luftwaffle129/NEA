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
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
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
            ClearAllData();
            GenerateBooks();
            GenerateMembers();
        }
        /// <summary>
        /// create 10 random book records with no copies attached to them
        /// </summary>
        private void GenerateBooks()
        {
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book();
                book.SetTitle(titles[rand.Next(0, titles.Length)]);
                string ISBN = "";
                for (int j = 0; j < 13; j++)
                {
                    ISBN += GenerateRandomDigit().ToString();
                }
                book.ISBN = ISBN;
                book.SetMediaType(GenerateRandomString(10));
                book.SetAuthor(GenerateRandomString(10));
                book.SetPublisher(GenerateRandomString(10));
                string[] genres = { GenerateRandomString(10), GenerateRandomString(10) };
                book.SetGenres(genres.ToList<string>());
                string[] themes = { GenerateRandomString(10), GenerateRandomString(10) };
                book.SetThemes(themes.ToList<string>());
                book.Description = GenerateRandomString(10);
                book.Price = 9.99;
                books.Add(book);
            }
            DataLibrary.Books = books;
        }
        /// <summary>
        /// generates 10 random members
        /// </summary>
        private void GenerateMembers()
        {
            for (int i = 0; i < 10; i++)
            {
                Member member = new Member();
                string barcode = "";
                for (int j = 0; j < 12; j++) 
                {
                    barcode += GenerateRandomDigit().ToString();
                }
                member.Barcode = barcode;
                member.FirstName = firstNames[rand.Next(0, firstNames.Length)];
                member.LastName = lastNames[rand.Next(0, lastNames.Length)];
                member.Postcode = $"{GenerateRandomLetter()}{GenerateRandomLetter()}{GenerateRandomDigit()} {GenerateRandomDigit(19)}{GenerateRandomLetter()}{GenerateRandomLetter()}";
                member.EmailAddress = $"{GenerateRandomString(10)}@gmail.com";
                string phoneNumber = "";
                for (int j = 0; j < 11; j++)
                {
                    phoneNumber += GenerateRandomDigit().ToString();
                }
                member.PhoneNumber = phoneNumber;
                member.AddressLine1 = "Devon";
                member.AddressLine2 = "Exeter";
                member.AddressLine3 = "Exeter rd";
                member.AddressLine4 = "ApartmentName";
                member.AddressLine5 = "Apartment Number";
                member.DateOfBirth = "11/07/2006";
                member.CustomerType = customerType.Adult;
                members.Add(member);
            }
            DataLibrary.Members = members;
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
        /// <summary>
        /// clears all records
        /// </summary>
        private void ClearAllData()
        {
            DataLibrary.Books.Clear();
            DataLibrary.Members.Clear();
            DataLibrary.Titles.Clear();
            DataLibrary.MediaTypes.Clear();
            DataLibrary.Authors.Clear();
            DataLibrary.Publishers.Clear();
            DataLibrary.Genres.Clear();
            DataLibrary.Themes.Clear();
            DataLibrary.Staff.Clear();
            DataLibrary.Transactions.Clear();
        }
    }
}
