using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem
{
    public static class SearchAndSort
    {
        public static int Binary<T,F>(List<F> itemList, T item, Comparison<T> compare) where F : ReferenceClass<T>
        {
            if (itemList.Count > 0)
            {
                int left = 0;
                int right = itemList.Count - 1;
                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle].Value, item) == Greatest.equal)
                        return middle;
                    else if (compare(itemList[middle].Value, item) == Greatest.Left)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;
        }
        public static int BinaryInsert<T,F>(List<F> itemList, T item, Comparison<T> compare) where F : ReferenceClass<T>
        {
            if (itemList.Count == 0) // if empty, return first index
                return 0;
            else if (itemList.Count == 1) // if count = 1, return before or after the only item
            {
                if (compare(itemList[0].Value, item) == Greatest.Right)
                    return 1;
                else
                    return 0;
            }
            else // else, perform a binary search for a location to add the item
            {
                int left = 0;
                int right = itemList.Count - 1;

                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle].Value, item) == Greatest.Right) // if middle element is smaller than the item:
                    {
                        if (compare(itemList[middle + 1].Value, item) == Greatest.Left) // if true, the index to insert is found
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
        public delegate Greatest Comparison<T>(T item1, T item2);
        public static Greatest TwoStrings(string text1, string text2)
        {
            if (text1 == text2)
                return Greatest.equal;
            bool isText2Larger = (text2.Length > text1.Length) ? true : false;
            int minimumLength = Math.Abs(text1.Length - text2.Length);
            for (int i = 0; i < minimumLength; i++)
            {
                if (text1[i] < text2[i])
                {
                    return Greatest.Right;
                }
                else if (text1[i] > text2[i])
                {
                    return Greatest.Left;
                }
            }
            return isText2Larger ? Greatest.Right : Greatest.Left;
        }
    }
    public enum Greatest
    {
        Left = 0,
        Right = 1,
        equal = 2
    }
}