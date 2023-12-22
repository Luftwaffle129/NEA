using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.Records;
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
        /// <typeparam name="T">Search item type</typeparam>
        /// <typeparam name="F">Type of item in the list</typeparam>
        /// <param name="itemList">list of items</param>
        /// <param name="item">search item</param>
        /// <param name="compare">comparison method</param>
        /// <returns></returns>
        public static int Binary<T, F>(List<F> itemList, T item, Compare<T, F> compare)
        {
            if (itemList.Count > 0)
            {
                int left = 0;
                int right = itemList.Count - 1;
                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.equal)
                        return middle;
                    else if (compare(itemList[middle], item) == Greatest.Right)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;

        }
        /*
        public static int BinaryRefClassUniqueRef<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<F> compare)
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
                    else if (compare(itemList[middle], item) == Greatest.Right)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;
        } */
        public static int Binary<T, F>(List<F> itemList, T item, Compare<T,F> compare, out int left, out int right)
        {
            if (itemList.Count > 0)
            {
                left = 0;
                right = itemList.Count - 1;
                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.equal)
                        return middle;
                    else if (compare(itemList[middle], item) == Greatest.Right)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            left = -1;
            right = -1;
            return -1;
        }
        /// <summary>
        /// Performs a binary search to find the range of indexes of matching items in the inputted sorted list. Requires a sorted ascending list.
        /// </summary>
        /// <typeparam name="T">Search item to find in the list</typeparam>
        /// <typeparam name="F">Items in the list</typeparam>
        /// <param name="itemList">list of items to search through</param>
        /// <param name="item">Search Item</param>
        /// <param name="compare">Method to compare the search item to the items in the list</param>
        /// <returns>Indexes of left most and right most found indexes. Returns {-1, -1} if item is not found</returns>
        public static int[] BinaryRange<T, F>(List<F> itemList, T item, Compare<T, F> compare)
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
                    while (left <= right && !middleFound)
                    {
                        middle = (left + right) / 2;
                        if (compare(itemList[middle], item) == Greatest.equal && compare(itemList[middle - 1], item) == Greatest.Right)
                            middleFound = true;
                        else if (compare(itemList[middle], item) == Greatest.Right)
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
                        if (compare(itemList[middle], item) == Greatest.equal && compare(itemList[middle + 1], item) == Greatest.Right)
                            middleFound = true;
                        else if (compare(itemList[middle], item) == Greatest.Right)
                            left = middle + 1;
                        else
                            right = middle - 1;
                    }
                    rightIndex = middle;
                }
            }
            return new int[] { -1, -1 };
        }
        /*
        public static int BinaryReferenceClass<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<T> compareValue, Compare<ReferenceClass<T, F>> compareRef) where F : class
        {
            // Get list of ReferenceClasses that share the same value
            int[] itemBoundaries = BinaryRange(itemList, item.Value, compareValue);
            List<ReferenceClass<T, F>> itemMatchList = new List<ReferenceClass<T, F>>();
            itemMatchList.AddRange(itemList.GetRange(itemBoundaries[0], itemBoundaries[1] - itemBoundaries[0] + 1));
            // Sort them in order of their unique identifier
            itemMatchList = QuickSort(itemMatchList, compareRef);
            return BinaryRefClassUniqueRef(itemMatchList, item, compareRef);
        } */
        /*
        public static int BinaryReferenceInsert<T, F>(List<ReferenceClass<T, F>> itemList, ReferenceClass<T, F> item, Compare<ReferenceClass<T, F>, ReferenceClass<T, F>> compare) where F : class
        {
            if (itemList.Count == 0) // if empty, return first index
                return 0;
            else if (itemList.Count == 1) // if count = 1, return before or after the only item
            {
                if (compare(itemList[0], item) == Greatest.Right)
                    return 1;
                else
                    return 0;
            }
            else // else, perform a binary search for a location to add the item
            {
                int left = 0;
                int right = itemList.Count - 1;

                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.Right) // if middle element is smaller than the item:
                    {
                        if (middle == itemList.Count - 1 || compare(itemList[middle + 1], item) == Greatest.Left) // if true, the index to insert is found
                            return middle + 1;
                        else
                            left = middle + 1;
                    }
                    else if (middle == 0)
                        return 0;
                    else
                    {
                        right = middle - 1;
                    }
                }
                return itemList.Count - 1;
            }
        }*/
        public static int BinaryInsert<T, F>(List<T> itemList, T item, Compare<T, F> compare) where T : F
        {
            if (itemList.Count == 0) // if empty, return first index
                return 0;
            else if (itemList.Count == 1) // if count = 1, return before or after the only item
            {
                if (compare(itemList[0], item) == Greatest.Right)
                    return 1;
                else
                    return 0;
            }
            else // else, perform a binary search for a location to add the item
            {
                int left = 0;
                int right = itemList.Count - 1;

                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.Right) // if middle element is smaller than the item:
                    {
                        if (middle == itemList.Count - 1 || compare(itemList[middle + 1], item) == Greatest.Left) // if true, the index to insert is found
                            return middle + 1;
                        else
                            left = middle + 1;
                    }
                    else if (middle == 0)
                        return 0;
                    else
                    {
                        right = middle - 1;
                    }
                }
                return itemList.Count - 1;
            }
        }
        #endregion
        #region sort
        public static List<F> QuickSort<T, F>(List<F> list, Compare<T, F> compare) where T : F
        {
            Partition(list, 0, list.Count - 1, compare);
            return list;
        }
        private static List<F> Partition<T, F>(List<F> list, int left, int right, Compare<T, F> compare) where T : F
        {
            if (left < right)
            {
                T pivot = (T)list[left];
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
        /// <summary>
        /// Compares the two inputted items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="item1">Item from a list of items</param>
        /// <param name="item2">Search item</param>
        /// <returns>Returns an enum stating the greater of the two values</returns>
        public delegate Greatest Compare<T, F>(F item1, T item2);
        public static Greatest TwoStrings(string text1, string text2)
        {
            if (text1 == text2)
                return Greatest.equal;
            int minimumLength = text1.Length < text2.Length ? text1.Length : text2.Length;
            for (int i = 0; i < minimumLength; i++)
            {
                if (Convert.ToInt32(text1[i]) > Convert.ToInt32(text2[i]))
                {
                    return Greatest.Left;
                }
                else if (Convert.ToInt32(text1[i]) < Convert.ToInt32(text2[i]))
                {
                    return Greatest.Right;
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
        public static Greatest TwoDates(DateTime date1, DateTime date2)
        {
            if (Math.Floor(date1.TimeOfDay.TotalSeconds) == date2.TimeOfDay.TotalSeconds && date1.Date == date2.Date)
                return Greatest.equal;
            else if (date1 > date2)
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
        // class comparisons
        public static Greatest RefClassAndString<F>(ReferenceClass<string, F> referenceClass, string str) where F : class
        {
            return TwoStrings(referenceClass.Value, str);
        }
        public static Greatest RefClassAndInteger<F>(ReferenceClass<int, F> referenceClass, int integer) where F : class
        {
            return TwoIntegers(referenceClass.Value, integer);
        }
        public static Greatest MemberAndString(Member member, string str)
        {
            return TwoStrings(member.Barcode.Value, str);
        }
        public static Greatest RefClassAndDate<F>(ReferenceClass<DateTime, F> reference, DateTime date) where F : class
        {
            return TwoDates(reference.Value, date);
        }
        public static Greatest TwoRefClassBooks(ReferenceClass<string, Book> book1, ReferenceClass<string, Book> book2)
        {
            Greatest value = TwoStrings(book1.Value, book2.Value);
            if (value == Greatest.equal)
                return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
            return value;
        }
        public static Greatest TwoRefClassBooks(ReferenceClass<double, Book> book1, ReferenceClass<double, Book> book2)
        {
            Greatest value = TwoDoubles(book1.Value, book2.Value);
            if (value == Greatest.equal)
                return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
            return value;
        }
        public static Greatest TwoBookCopyBarcodes(ReferenceClass<string, BookCopy> copy1, ReferenceClass<string, BookCopy> copy2)
        {
            return TwoStrings(copy1.Value, copy2.Value);
        }
        public static Greatest BookCopyAndBarcode(BookCopy copy, string barcode)
        {
            return TwoStrings(copy.Barcode.Value, barcode);
        }
        public static Greatest BookCopyAndIsbn(BookCopy copy, string isbn)
        {
            return TwoStrings(copy.BookRelation.Book.Isbn.Value, isbn);
        }
        public static Greatest TwoRefClassCircCopies(ReferenceClass<DateTime, CirculationCopy> copy1, ReferenceClass<DateTime, CirculationCopy> copy2)
        {
            Greatest value = TwoDates(copy1.Value, copy2.Value);
            if (value == Greatest.equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        public static Greatest TwoRefClassCircCopies(ReferenceClass<int, CirculationCopy> copy1, ReferenceClass<int, CirculationCopy> copy2)
        {
            Greatest value = TwoIntegers(copy1.Value, copy2.Value);
            if (value == Greatest.equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        public static Greatest TwoRefClassCircCopies(ReferenceClass<CirculationType, CirculationCopy> copy1, ReferenceClass<CirculationType, CirculationCopy> copy2)
        {
            Greatest value = TwoEnums(copy1.Value, copy2.Value);
            if (value == Greatest.equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        public static Greatest TwoRefClassMembers(ReferenceClass<string, Member> member1, ReferenceClass<string, Member> member2)
        {
            Greatest value = TwoStrings(member1.Value, member2.Value);
            if (value == Greatest.equal)
                return TwoStrings(member1.Reference.Barcode.Value, member2.Reference.Barcode.Value);
            return value;
        }
        public static Greatest TwoRefClassMembers(ReferenceClass<MemberType, Member> member1, ReferenceClass<MemberType, Member> member2)
        {
            Greatest value = TwoEnums(member1.Value, member2.Value);
            if (value == Greatest.equal)
                return TwoStrings(member1.Reference.Barcode.Value, member2.Reference.Barcode.Value);
            return value;
        }
        public static Greatest TwoBookCopies(BookCopy copy1, BookCopy copy2)
        {
            return TwoStrings(copy1.Barcode.Value, copy2.Barcode.Value);
        }
        public static Greatest TempBookCopyAndBookCopy(TempBookCopy tempCopy, BookCopy copy)
        {
            return TwoStrings(tempCopy.BookCopy.Barcode.Value, copy.Barcode.Value);
        }
        public static Greatest CircCopyAndBookCopy(CirculationCopy circCopy, BookCopy bookCopy)
        {
            return TwoBookCopies(circCopy.BookCopy, bookCopy);
        }
        public static Greatest TwoTempBookCopies(TempBookCopy copy1, TempBookCopy copy2)
        {
            return TwoStrings(copy1.Barcode, copy2.Barcode);
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