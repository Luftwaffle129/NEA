﻿using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NEALibrarySystem
{
    public class Book
    {
        public string SeriesTitle { get; set; }
        public int SeriesNumber { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // single key
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
        public string GetTitle()
        {
            return GetNameFromID(DataLibrary.titles, TitleID);
        }
        public void SetTitle(string title)
        {
            publisherID = SetIDFromName(ref DataLibrary.titles, title);
        }
        #endregion
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
        public string GetMediaType()
        {
            return GetNameFromID(DataLibrary.mediaTypes, MediaTypeID);
        }
        public void SetMediaType(string mediaType)
        {
            publisherID = SetIDFromName(ref DataLibrary.mediaTypes, mediaType);
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
        public string GetAuthor()
        {
            return GetNameFromID(DataLibrary.authors, AuthorID);
        }
        public void SetAuthor(string author)
        {
            publisherID = SetIDFromName(ref DataLibrary.authors, author);
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
        public string GetPublisher()
        {
            return GetNameFromID(DataLibrary.publishers, publisherID);
        }
        public void SetPublisher(string publisher)
        {
            publisherID = SetIDFromName(ref DataLibrary.publishers, publisher);
        }
        #endregion
        // list of keys
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
        public List<string> GetGenres()
        {
            return GetItemIDList(GenresID, DataLibrary.genres);
        }
        public void SetGenres(List<string> input)
        {
            GenresID = SetItemIDList(input, ref DataLibrary.genres);
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
        public List<string> GetThemes()
        {
            return GetItemIDList(ThemesID, DataLibrary.themes);
        }
        public void SetThemes(List<string> input)
        {
            ThemesID = SetItemIDList(input, ref DataLibrary.themes);
        }
        #endregion

        private List<string> GetItemIDList(List<int> IDList, List<ItemID> ItemIDList)
        {
            List<string> output = new List<string>();
            foreach (int ID in IDList)
            {
                string temp = GetNameFromID(ItemIDList, ID);
                if (temp != "")
                    output.Add(temp);
            }
            return output;
        }
        private List<int> SetItemIDList(List<string> itemList, ref List<ItemID> ItemIDList)
        {
            List<int> output = new List<int>();

            foreach (string item in itemList)
            {
                output.Add(SetIDFromName(ref ItemIDList, item));
            }
            return output;
        }

        /// <summary>
        /// Retrieves the name of the item with the inputted ID
        /// </summary>
        /// <param name="list">The list containing the items</param>
        /// <param name="ID">The ID to search for in list</param>
        /// <param name="name">the name of the datatype. Used for error messages</param>
        /// <returns>Returns the string linked to the ID inputted</returns>
        private string GetNameFromID(List<ItemID> list, int ID)
        {
            foreach (ItemID item in list)
            {
                if (item.ID == ID)
                {
                    return item.Name;
                }
            }
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