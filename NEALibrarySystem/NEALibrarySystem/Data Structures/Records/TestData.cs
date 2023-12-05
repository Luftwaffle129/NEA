﻿using NEALibrarySystem.Data_Structures.Records;
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
            // set up settings details
            Settings.MemberBarcodeLength = 10;
            Settings.LoanDurations = new int[3]{ 14, 7, 5 };
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
                for (int j = 0; j < 12; j++) 
                {
                    barcode += GenerateRandomDigit().ToString();
                }
                memberCreator.Barcode = barcode;
                memberCreator.FirstName = firstNames[rand.Next(0, firstNames.Length)];
                memberCreator.LastName = lastNames[rand.Next(0, lastNames.Length)];
                memberCreator.Postcode = $"{GenerateRandomLetter()}{GenerateRandomLetter()}{GenerateRandomDigit()} {GenerateRandomDigit(19)}{GenerateRandomLetter()}{GenerateRandomLetter()}";
                memberCreator.EmailAddress = $"{GenerateRandomString(10)}@gmail.com";
                string phoneNumber = "";
                for (int j = 0; j < 11; j++)
                {
                    phoneNumber += GenerateRandomDigit().ToString();
                }
                memberCreator.PhoneNumber = phoneNumber;
                memberCreator.AddressLine1 = "Devon";
                memberCreator.AddressLine2 = "Exeter";
                memberCreator.AddressLine3 = "Exeter rd";
                memberCreator.AddressLine4 = "ApartmentName";
                memberCreator.AddressLine5 = "Apartment Number";
                memberCreator.DateOfBirth = "11/07/2006";
                memberCreator.Type = MemberType.Adult;
                Member member = new Member(memberCreator);
                // CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE CHANGE
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
            DataLibrary.CirculationCopies.Clear();
            DataLibrary.BookCopies.Clear();
        }
    }
}
