using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public static class SearchAndSort
    {
        #region search
        /// <summary>
        /// Returns the index of an item in a list of unique data
        /// </summary>
        /// <typeparam name="T">Type of Value in reference class</typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="itemList"></param>
        /// <param name="item"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static int BinaryUniqueValue<T, F>(List<ReferenceClass<T, F>> itemList, T item, Compare<T> compare) where F : class
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
        public static int BinaryUniqueRef<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<ReferenceClass<T, F>> compare) where F : class
        {
            if (itemList.Count > 0)
            {
                int left = 0;
                int right = itemList.Count - 1;
                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.equal)
                        return middle;
                    else if (compare(itemList[middle], item) == Greatest.Left)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;
        }
        public static int Binary<T, F>(List<ReferenceClass<T, F>> itemList, T item, Compare<T> compare, out int left, out int right) where F : class
        {
            if (itemList.Count > 0)
            {
                left = 0;
                right = itemList.Count - 1;
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
            left = -1;
            right = -1;
            return -1;
        }
        public static int[] BinaryRange<T, F>(List<ReferenceClass<T, F>> itemList, T item, Compare<T> compare) where F : class
        {
            if (itemList.Count > 0)
            {
                // finds an occurence of the item
                int leftBoundary;
                int rightBoundary;
                int firstFoundIndex = Binary(itemList, item, compare, out leftBoundary, out rightBoundary);
                // returns -1 if item is not found
                if (firstFoundIndex == -1)
                    return new int[] { -1, -1 };
                int leftIndex; // index of the leftmost occurence
                int rightIndex; // index of the right most occurence

                // finds smallest-indexed occurence of the item
                if (firstFoundIndex == 0)
                    leftIndex = 0;
                else
                {
                    int left = leftBoundary;
                    int right = firstFoundIndex;
                    int middle = -1;
                    bool middleFound = false;
                    while (left < right && !middleFound)
                    {
                        middle = (left + right) / 2;
                        if (compare(itemList[middle].Value, item) == Greatest.equal && compare(itemList[middle - 1].Value, item) == Greatest.Right)
                            middleFound = true;
                        else if (compare(itemList[middle].Value, item) == Greatest.Left)
                            left = middle + 1;
                        else
                            right = middle - 1;
                    }
                    leftIndex = middle;
                }
                // finds largest-indexed occurence of the item
                if (firstFoundIndex == itemList.Count - 1)
                    rightIndex = itemList.Count - 1;
                else
                {
                    int left = firstFoundIndex;
                    int right = rightBoundary;
                    int middle = -1;
                    bool middleFound = false;
                    while (left < right && !middleFound)
                    {
                        middle = (left + right) / 2;
                        if (compare(itemList[middle].Value, item) == Greatest.equal && compare(itemList[middle + 1].Value, item) == Greatest.Right)
                            middleFound = true;
                        else if (compare(itemList[middle].Value, item) == Greatest.Left)
                            left = middle + 1;
                        else
                            right = middle - 1;
                    }
                    rightIndex = middle;
                }
            }
            return new int[] { -1, -1 };
        }
        public static int BinaryReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<T> compareValue, Compare<ReferenceClass<T, F>> compareRef) where F : class
        {
            // Get list of ReferenceClasses that share the same value
            int[] itemBoundaries = BinaryRange(itemList, item.Value, compareValue);
            List<ReferenceClass<T, F>> itemMatchList = new List<ReferenceClass<T, F>>();
            itemMatchList.AddRange(itemList.GetRange(itemBoundaries[0], itemBoundaries[1] - itemBoundaries[0] + 1));
            // Sort them in order of their unique identifier
            itemMatchList = QuickSort(itemMatchList, compareRef);
            return BinaryUniqueRef(itemMatchList, item, compareRef);
        }
        public static int BinaryReferenceInsert<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<T> compare) where F : class
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
        #endregion
        #region sort
        public static List<T> QuickSort<T>(List<T> list, Compare<T> compare)
        {
            Partition(list, 0, list.Count - 1, compare);
            return list;
        }
        private static List<T> Partition<T>(List<T> list, int left, int right, Compare<T> compare)
        {
            if (left < right)
            {
                T pivot = list[left];
                int leftIndex = left;
                int rightIndex = right;
                while (rightIndex > leftIndex)
                {
                    while (compare(list[leftIndex], pivot) != Greatest.Left && rightIndex > leftIndex && leftIndex <= right)
                        leftIndex++;
                    while (compare(list[rightIndex], pivot) == Greatest.Left && rightIndex >= leftIndex && rightIndex >= left)
                        rightIndex--;
                    if (rightIndex > leftIndex)
                        Swap(ref list, leftIndex, rightIndex);
                }
                Swap(ref list, left, rightIndex);
                list = Partition(list, left, rightIndex - 1, compare);
                list = Partition(list, rightIndex + 1, right, compare);
                return list;
            }
            else
                return list;
        }
        /// <summary>
        /// Swaps the items at the specified indexes in the list
        /// </summary>
        /// <typeparam name="F">The type of list</typeparam>
        /// <param name="list"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void Swap<F>(ref List<F> list, int index1, int index2)
        {
            F temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        #endregion
        #region compare
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
        // REWRITE THIS BELOW -----------------------------------------------------------------------------=-------------------------------------=
        // ReferenceClass reference comparisons
        public static Greatest TwoBooks<T>(ReferenceClass<T, Book> book1, ReferenceClass<T, Book> book2)
        {
            return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
        }
        public static Greatest TwoBookCopies<T>(ReferenceClass<T, BookCopy> copy1, ReferenceClass<T, BookCopy> copy2)
        {
            return TwoStrings(copy1.Reference.Barcode.Value, copy2.Reference.Barcode.Value);
        }
        public static Greatest TwoCirculationCopies<T>(ReferenceClass<T, CirculationCopy> copy1, ReferenceClass<T, CirculationCopy> copy2)
        {
            return TwoDates(copy1.Reference.Date.Value, copy2.Reference.Date.Value);
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
        #endregion
    }
    public enum Greatest
    {
        Left = 0,
        Right = 1,
        equal = 2
    }
}