using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem
{
    public static class Search
    {
        /// <summary>
        /// Feturns the index the item was first found at
        /// </summary>
        /// <param name="itemBookList"> List of items</param>
        /// <param name="item">Item being searched for</param>
        /// <returns>Index of last</returns>
        public static int GetFoundIndex(List<ItemBook> itemBookList, string item)
        {
            if (itemBookList.Count > 0)
            {
                int left = 0;
                int right = itemBookList.Count - 1;
                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (itemBookList[middle].Name == item)
                        return middle;
                    else if (Comparison.TwoStrings(itemBookList[middle].Name, item) == Greatest.Left)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;
        }/// <summary>
        /// Gets the suitable index in which to insert the item book
        /// </summary>
        /// <param name="itemBookList">list of item books</param>
        /// <param name="item">item to insert</param>
        /// <returns>returns the index that the item should be inserted into</returns>
        public static int GetInsertIndex(List<ItemBook> itemBookList, string item)
        {
            if (itemBookList.Count == 0) // if empty, return first index
                return 0;
            else if (itemBookList.Count == 1) // if count = 1, return before or after the only item
            {
                if (Comparison.TwoStrings(itemBookList[0].Name, item) == Greatest.Right)
                    return 1;
                else
                    return 0;
            }
            else // else, perform a binary search for a location to add the item
            {
                int left = 0;
                int right = itemBookList.Count - 1;

                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (Comparison.TwoStrings(itemBookList[middle].Name, item) == Greatest.Right) // if middle element is smaller than the item:
                    {
                        if (Comparison.TwoStrings(itemBookList[middle + 1].Name, item) == Greatest.Left) // if true, the index to insert is found
                            return middle + 1;
                        else
                            left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
                return -1;
            }
        }
    }
}