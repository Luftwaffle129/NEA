using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NEALibrarySystem
{
    public class Book
    {
        #region Title
        private int titleID;
        public int TitleID 
        {
            get 
            {
                return titleID;
            } 
            set
            {
                titleID = value;
            }
        }
        public string Title
        {
            get
            {
                return GetNameFromID(DataLibrary.titles, titleID, "title");
            }
            set
            {
                titleID = SetIDFromName(ref DataLibrary.titles, value);
            }
        }
        #endregion
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string ISBN { get; set; }
        #region MediaType
        private int mediaTypeID { get; set; }
        public int MediaTypeID
        {
            get
            {
                return mediaTypeID;
            }
            set
            {
                mediaTypeID = value;
            }
        }
        public string MediaType
        {
            get
            {
                return GetNameFromID(DataLibrary.mediaTypes, mediaTypeID, "media type");
            }
            set
            {
                mediaTypeID = SetIDFromName(ref DataLibrary.mediaTypes, value);
            }
        }
        #endregion
        #region Author
        private int authorID;
        public int AuthorID
        {
            get
            {
                return authorID;
            }
            set
            {
                authorID = value;
            }
        }
        public string Author
        {
            get
            {
                return GetNameFromID(DataLibrary.authors, authorID, "Author");
            }
            set
            {
                publisherID = SetIDFromName(ref DataLibrary.authors, value);
            }
        }
        #endregion
        #region Publisher
        private int publisherID;
        public int PublisherID
        {
            get
            {
                return publisherID;
            }
            set
            {
                publisherID = value;
            }
        }
        public string Publisher
        {
            get
            {
                return GetNameFromID(DataLibrary.publishers, publisherID, "publisher");
            }
            set
            {
                publisherID = SetIDFromName(ref DataLibrary.publishers, value);
            }
        }
        #endregion
        public string Description { get; set; }
        public decimal Price { get; set; }
        #region Genres
        private List<int> genresID = new List<int>();
        public List<int> GenresID 
        { 
            get
            {
                return genresID;
            }
            set
            {
                genresID = value;
            }
        }
        public List<string> Genres
        {
            get 
            {
                List<string> output = new List<string>();
                foreach (int ID in genresID)
                {
                    string temp = GetNameFromID(DataLibrary.genres, ID, "genre");
                    if (temp != "")
                        output.Add(temp);
                }
                return output;
            }
            set
            {
                List<int> output = new List<int>();

                foreach (string genre in value)
                {
                    SetIDFromName(ref DataLibrary.genres, genre);
                }
            }
        }
        #endregion
        #region Themes
        private List<int> themesID = new List<int>();
        public List<int> ThemesID
        {
            get
            {
                return themesID;
            }
            set
            {
                themesID = value;
            }
        }
        public List<string> Themes
        {
            get
            {
                List<string> output = new List<string>();
                foreach (int ID in themesID)
                {
                    string temp = GetNameFromID(DataLibrary.themes, ID, "theme");
                    if (temp != "")
                        output.Add(temp);
                }
                return output;
            }
            set
            {
                List<int> output = new List<int>();

                foreach (string theme in value)
                {
                    SetIDFromName(ref DataLibrary.themes, theme);
                }
            }
        }
        #endregion
        /// <summary>
        /// Outputs a messagebox declaring the missing data item and it's ID
        /// </summary>
        /// <param name="item">missing data item</param>
        /// <param name="ID">ID of the missing data item</param>
        private void MissingItemID(string item, int ID)
        {
            item = item[0].ToString().ToUpper() + item.Substring(1);
            MessageBox.Show($"{item} not found. ID: {ID}");
        }
        /// <summary>
        /// Returns the string linked to the ID inputted
        /// </summary>
        /// <param name="list">The list containing the items</param>
        /// <param name="ID">The ID to search for in list</param>
        /// <param name="name">the name of the datatype. Used for error messages</param>
        /// <returns></returns>
        private string GetNameFromID(List<ItemID> list, int ID, string name = "item")
        {
            foreach (ItemID item in list)
            {
                if (item.ID ==ID)
                {
                    return item.Name;
                }
            }
            MissingItemID(name, ID);
            return "";
        }
        /// <summary>
        /// Outputs the ID linked to the name. If no ID is found, creates a new ID linked to the name.
        /// </summary>
        /// <param name="list">The list containing the items</param>
        /// <param name="name">The name to find ID of or create an ID for</param>
        private int SetIDFromName(ref List<ItemID> list, string name)
        {
            int index = 0;
            do
            {
                if (list[index].Name == name)
                {
                    return list[index].ID;
                }
            } while (++index < list.Count);
            // if an existing item is not found
            index = 0;
            int ID = 0;
            ItemID temp = new ItemID();
            // insert new item in the ID if there is a gap
            do
            {
                index = 0;
                bool isGap = true;
                do
                {
                    if (list[index].ID == ID)
                    {
                        isGap = false;
                    }
                }
                while (++index < list.Count);
                temp.ID = ID;
                if (isGap)
                {
                    temp.Name = name;
                    list.Add(temp);
                    return ID;
                }
            } while (++ID < list.Count);
            // if no gaps, append new item
            temp.ID = ID;
            temp.Name = name;
            list.Add(temp);
            return ID;
        }
    }
}