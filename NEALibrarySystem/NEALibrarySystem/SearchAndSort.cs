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
        public static int Binary<T, F>(List<ReferenceClass<T, F>> itemList, T item, Compare<T> compare) where F : class
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
        public static int BinaryInsert<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<T> compare) where F : class
        {
            if (itemList.Count == 0) // if empty, return first index
                return 0;
            else if (itemList.Count == 1) // if count = 1, return before or after the only item
            {
                if (compare(itemList[0].Value, item.Value) == Greatest.Right)
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
                    if (compare(itemList[middle].Value, item.Value) == Greatest.Right) // if middle element is smaller than the item:
                    {
                        if (compare(itemList[middle + 1].Value, item.Value) == Greatest.Left) // if true, the index to insert is found
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
        public delegate Greatest Compare<T>(T item1, T item2);
        public static Greatest TwoStrings(string text1, string text2)
        {
            if (text1 == text2)
                return Greatest.equal;
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
            return (text2.Length > text1.Length) ? Greatest.Right : Greatest.Left; // returns the longest item as the largest
        }
        public static Greatest TwoIntegers(int num1, int num2)
        {
            if (num1 == num2)
                return Greatest.equal;
            else if (num1 > num2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        public static Greatest TwoDoubles(double num1, double num2)
        {
            if (num1 == num2)
                return Greatest.equal;
            else if (num1 > num2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        public static Greatest TwoEnums(MemberType member1, MemberType member2)
        {
            if (member1 == member2)
                return Greatest.equal;
            else if (member1 > member2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        public static Greatest TwoEnums(CirculationType copy1, CirculationType copy2)
        {
            if (copy1 == copy2)
                return Greatest.equal;
            else if (copy1 > copy2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        public static Greatest TwoReferenceClasses<F>(ReferenceClass<string,F> ref1, ReferenceClass<string,F> ref2) where F : class
        {
            return TwoStrings(ref1.Value, ref2.Value);
        }
        public static Greatest TwoReferenceClasses<F>(ReferenceClass<int, F> ref1, ReferenceClass<int, F> ref2) where F : class
        {
            return TwoIntegers(ref1.Value, ref2.Value);
        }
        public static Greatest TwoBooks(Book book1, Book book2)
        {
            return TwoStrings(book1.Isbn.Value, book2.Isbn.Value);
        }
        public static Greatest TwoDates(DateTime date1, DateTime date2)
        {
            if (date1 == date2)
                return Greatest.equal;
            else if (date1 > date2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
    }
    public enum Greatest
    {
        Left = 0,
        Right = 1,
        equal = 2
    }
}