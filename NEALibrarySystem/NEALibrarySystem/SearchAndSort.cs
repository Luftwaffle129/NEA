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
    /// <summary>
    /// Contains the methods used for searching and sorting
    /// </summary>
    public static class SearchAndSort
    {
        #region search
        /// <summary>
        /// Peforms a binary search on the data provided
        /// </summary>
        /// <typeparam name="T">Search item type</typeparam>
        /// <typeparam name="F">Type of item in the list</typeparam>
        /// <param name="itemList">List of items</param>
        /// <param name="item">Search item</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>Returns the index of an item in a list of unique data. Returns -1 if not found</returns>
        public static int Binary<T, F>(List<F> itemList, T item, Compare<T, F> compare)
        {
            if (itemList.Count > 0)
            {
                int left = 0;
                int right = itemList.Count - 1;
                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.Equal)
                        return middle;
                    else if (compare(itemList[middle], item) == Greatest.Right)
                        left = middle + 1;
                    else
                        right = middle - 1;
                }
            }
            return -1;

        }
        /// <summary>
        /// Peforms a binary search on the data provided
        /// </summary>
        /// <typeparam name="T">Search item type</typeparam>
        /// <typeparam name="F">Type of item in the list</typeparam>
        /// <param name="itemList">List of items</param>
        /// <param name="item">Search item</param>
        /// <param name="compare">Comparison method</param>
        /// <param name="left">Left pointer index when search item was found. -1 if not found</param>
        /// <param name="right">Right pointer index when item was found. -1 if not found</param>
        /// <returns>Returns the index of an item in a list of unique data. Returns -1 if not found</returns>
        public static int Binary<T, F>(List<F> itemList, T item, Compare<T,F> compare, out int left, out int right)
        {
            if (itemList.Count > 0)
            {
                left = 0;
                right = itemList.Count - 1;
                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (compare(itemList[middle], item) == Greatest.Equal)
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
        /// <param name="itemList">List of items to search through</param>
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

                // finds smallest-indexed occurence of the item via a binary search
                if (compare(itemList[0], item) == Greatest.Equal)
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
                        // if middle item is equal to the search term, and the item to the right of it is greater than the search term
                        if (compare(itemList[middle], item) == Greatest.Equal && compare(itemList[middle - 1], item) == Greatest.Right)
                            middleFound = true;
                        else if (compare(itemList[middle], item) == Greatest.Right)
                            left = middle + 1;
                        else
                            right = middle - 1;
                    }
                    leftIndex = middle;
                }
                // finds largest-indexed occurence of the item via a binary search
                if (compare(itemList[itemList.Count - 1], item) == Greatest.Equal)
                    rightIndex = itemList.Count - 1;
                else
                {
                    int left = firstFoundIndex;
                    int right = rightBoundary;
                    int middle = -1;
                    bool middleFound = false;
                    while (left <= right && !middleFound)
                    {
                        middle = (left + right) / 2;
                        // if middle item is equal to the search term, and the item to the left of it is smaller than the search term
                        if (compare(itemList[middle], item) == Greatest.Equal && compare(itemList[middle + 1], item) == Greatest.Left)
                            middleFound = true;
                        else if (compare(itemList[middle], item) != Greatest.Left)
                            left = middle + 1;
                        else
                            right = middle - 1;
                    }
                    rightIndex = middle;
                    
                }
                return new int[] { leftIndex, rightIndex };
            }
            return new int[] { -1, -1 };
        }
        /// <summary>
        /// Finds the location to insert a new item of data into a sorted list
        /// </summary>
        /// <typeparam name="T">Data type of the list and item-to-insert</typeparam>
        /// <typeparam name="F">Data type of the list and item-to-insert</typeparam>
        /// <param name="itemList">list of items</param>
        /// <param name="item">Item to insert</param>
        /// <param name="compare">Comparison algorithm</param>
        /// <returns>Index to insert the new item at</returns>
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
                    if (compare(itemList[middle], item) == Greatest.Right) // if middle element is smaller than the insert item:
                    {
                        if (middle == itemList.Count - 1 || compare(itemList[middle + 1], item) == Greatest.Left) // if middle is at the end of the array or the item to the right is larger than the insert item, the index to insert is found
                            return middle + 1;
                        else
                            left = middle + 1;
                    }
                    else if (middle == 0) // if insert item is smaller than all items in the list
                        return 0;
                    else
                    {
                        right = middle - 1;
                    }
                }
                return -1; // should never run
            }
        }
        #endregion
        #region sort
        /// <summary>
        /// Sorting algorithm to sort a list of items
        /// </summary>
        /// <typeparam name="T">Datatype of items being sorted</typeparam>
        /// <typeparam name="F">Datatype of items being sorted</typeparam>
        /// <param name="list">List of items</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>Sorted list</returns>
        public static List<F> QuickSort<T, F>(List<F> list, Compare<T, F> compare) where T : F
        {
            Partition(list, 0, list.Count - 1, compare);
            return list;
        }
        /// <summary>
        /// Sorts a partition 
        /// </summary>
        /// <typeparam name="T">Datatype of items being sorted</typeparam>
        /// <typeparam name="F">Datatype of items being sorted</typeparam>
        /// <param name="list">List of items</param>
        /// <param name="left">Start index of the partition</param>
        /// <param name="right">End index of the partition</param>
        /// <param name="compare">Comparison method</param>
        /// <returns>item list with the partition section specified being sorted/</returns>
        private static List<F> Partition<T, F>(List<F> list, int left, int right, Compare<T, F> compare) where T : F
        {
            // places all elements smaller than the chosen pivot on the left, and the larger elements on the right
            if (left < right)
            {
                T pivot = (T)list[left];
                int leftIndex = left;
                int rightIndex = right;
                // swaps elements into 2 groups of higher than pivot (right) and lower than pivot (left)
                while (rightIndex > leftIndex)
                {
                    while (compare(list[leftIndex], pivot) != Greatest.Left && rightIndex > leftIndex && leftIndex <= right)
                        leftIndex++;
                    while (compare(list[rightIndex], pivot) == Greatest.Left && rightIndex >= leftIndex && rightIndex >= left)
                        rightIndex--;
                    if (rightIndex > leftIndex)
                        Swap(ref list, leftIndex, rightIndex);
                }
                Swap(ref list, left, rightIndex); // swap the pivot from its left-most position with the closest element that is smaller than it
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
        /// <param name="list">List of elements</param>
        /// <param name="index1">First index to swap</param>
        /// <param name="index2">Second index to swap</param>
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
        /// <summary>
        /// Compares two string values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoStrings(string text1, string text2)
        {
            if (text1 == text2)
                return Greatest.Equal;
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
        /// <summary>
        /// Compares two string values without case sensitivity
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoUpperStrings(string text1, string text2)
        {
            text1 = text1.ToUpper();
            text2 = text2.ToUpper();
            if (text1 == text2)
                return Greatest.Equal;
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
        /// <summary>
        /// Compares two integer values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoIntegers(int num1, int num2)
        {
            if (num1 == num2)
                return Greatest.Equal;
            else if (num1 > num2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        /// <summary>
        /// Compares two double values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoDoubles(double num1, double num2)
        {
            if (num1 == num2)
                return Greatest.Equal;
            else if (num1 > num2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        /// <summary>
        /// Compares two dateTime values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoDates(DateTime date1, DateTime date2)
        {
            if (date1.Date == date2.Date)
                return Greatest.Equal;
            else if (date1 > date2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        /// <summary>
        /// Compares two MemberType enum values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoEnums(MemberType member1, MemberType member2)
        {
            if (member1 == member2)
                return Greatest.Equal;
            else if (member1 > member2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        /// <summary>
        /// Compares two CirculationType enum values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoEnums(CirculationType copy1, CirculationType copy2)
        {
            if (copy1 == copy2)
                return Greatest.Equal;
            else if (copy1 > copy2)
                return Greatest.Left;
            else
                return Greatest.Right;
        }
        // class comparisons
        /// <summary>
        /// Compares a reference class with a string value, and a string. case sensitive
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest RefClassAndString<F>(ReferenceClass<string, F> referenceClass, string str) where F : class
        {
            return TwoStrings(referenceClass.Value, str);
        }
        /// <summary>
        /// Compares a reference class with a integer value, and an integer
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest RefClassAndInteger<F>(ReferenceClass<int, F> referenceClass, int integer) where F : class
        {
            return TwoIntegers(referenceClass.Value, integer);
        }
        /// <summary>
        /// Compares a reference class with a dateTime value, and a dateTime
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest RefClassAndDate<F>(ReferenceClass<DateTime, F> reference, DateTime date) where F : class
        {
            return TwoDates(reference.Value, date);
        }
        /// <summary>
        /// Compares two reference classes with string values and book references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassBooks(ReferenceClass<string, Book> book1, ReferenceClass<string, Book> book2)
        {
            Greatest value = TwoStrings(book1.Value, book2.Value);
            if (value == Greatest.Equal)
                return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and book references. String values are compared case-insensitive
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoUpperRefClassBooks(ReferenceClass<string, Book> book1, ReferenceClass<string, Book> book2)
        {
            Greatest value = TwoStrings(book1.Value.ToUpper(), book2.Value.ToUpper());
            if (value == Greatest.Equal)
                return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and book references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassBooks(ReferenceClass<double, Book> book1, ReferenceClass<double, Book> book2)
        {
            Greatest value = TwoDoubles(book1.Value, book2.Value);
            if (value == Greatest.Equal)
                return TwoStrings(book1.Reference.Isbn.Value, book2.Reference.Isbn.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and book copy references.
        /// Only the primary key book copy barcodes requires this comparison so only the values are compared
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoBookCopyBarcodes(ReferenceClass<string, BookCopy> copy1, ReferenceClass<string, BookCopy> copy2)
        {
            return TwoStrings(copy1.Value, copy2.Value);
        }
        /// <summary>
        /// Compares two reference classes with DateTime values and circulation references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassCircCopies(ReferenceClass<DateTime, CirculationCopy> copy1, ReferenceClass<DateTime, CirculationCopy> copy2)
        {
            Greatest value = TwoDates(copy1.Value, copy2.Value);
            if (value == Greatest.Equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with integer values and circulation references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassCircCopies(ReferenceClass<int, CirculationCopy> copy1, ReferenceClass<int, CirculationCopy> copy2)
        {
            Greatest value = TwoIntegers(copy1.Value, copy2.Value);
            if (value == Greatest.Equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and circulation references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassCircCopies(ReferenceClass<string, CirculationCopy> copy1, ReferenceClass<string, CirculationCopy> copy2)
        {
            Greatest value = TwoStrings(copy1.Value, copy2.Value);
            if (value == Greatest.Equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and circulation references. strings are compared case-insensitive
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoUpperRefClassCircCopies(ReferenceClass<string, CirculationCopy> copy1, ReferenceClass<string, CirculationCopy> copy2)
        {
            Greatest value = TwoStrings(copy1.Value.ToUpper(), copy2.Value.ToUpper());
            if (value == Greatest.Equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with CirculationType enum values and circulation references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassCircCopies(ReferenceClass<CirculationType, CirculationCopy> copy1, ReferenceClass<CirculationType, CirculationCopy> copy2)
        {
            Greatest value = TwoEnums(copy1.Value, copy2.Value);
            if (value == Greatest.Equal)
                return TwoIntegers(copy1.Reference.Id.Value, copy2.Reference.Id.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and member references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassMembers(ReferenceClass<string, Member> member1, ReferenceClass<string, Member> member2)
        {
            Greatest value = TwoStrings(member1.Value, member2.Value);
            if (value == Greatest.Equal)
                return TwoStrings(member1.Reference.Barcode.Value, member2.Reference.Barcode.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and member references. strings are compared case-insensitive
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoUpperRefClassMembers(ReferenceClass<string, Member> member1, ReferenceClass<string, Member> member2)
        {
            Greatest value = TwoStrings(member1.Value.ToUpper(), member2.Value.ToUpper());
            if (value == Greatest.Equal)
                return TwoStrings(member1.Reference.Barcode.Value, member2.Reference.Barcode.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with MemberType enum values and book references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassMembers(ReferenceClass<MemberType, Member> member1, ReferenceClass<MemberType, Member> member2)
        {
            Greatest value = TwoEnums(member1.Value, member2.Value);
            if (value == Greatest.Equal)
                return TwoStrings(member1.Reference.Barcode.Value, member2.Reference.Barcode.Value);
            return value;
        }
        /// <summary>
        /// Compares two book copies by comparing their barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoBookCopies(BookCopy copy1, BookCopy copy2)
        {
            return TwoStrings(copy1.Barcode.Value, copy2.Barcode.Value);
        }
        /// <summary>
        /// Compares a TempBookCopy and a BookCopy depending on their barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TempBookCopyAndBookCopy(TempBookCopy tempCopy, BookCopy copy)
        {
            return TwoStrings(tempCopy.BookCopy.Barcode.Value, copy.Barcode.Value);
        }
        /// <summary>
        /// Compares a book copy and a circulation copy by the book copies
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest CircCopyAndBookCopy(CirculationCopy circCopy, BookCopy bookCopy)
        {
            return TwoBookCopies(circCopy.BookCopy, bookCopy);
        }
        /// <summary>
        /// Compares two temporary book copies by their barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoTempBookCopies(TempBookCopy copy1, TempBookCopy copy2)
        {
            return TwoStrings(copy1.Barcode, copy2.Barcode);
        }
        /// <summary>
        /// Compares two listViewItems by comparing their first subitem
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoListViewItems(ListViewItem item1, ListViewItem item2)
        {
            return TwoStrings(item1.SubItems[0].Text, item2.SubItems[0].Text);
        }
        /// <summary>
        /// Compares two books by their ISBN values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoBooks(Book book1, Book book2)
        {
            return TwoStrings(book1.Isbn.Value, book2.Isbn.Value);
        }
        /// <summary>
        /// Compares two members by their barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoMembers(Member member1, Member member2)
        {
            return TwoStrings(member1.Barcode.Value, member2.Barcode.Value);
        }
        /// <summary>
        /// Compares two staff by their barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoStaff(Staff staff1, Staff staff2)
        {
            return TwoStrings(staff1.Username.Value, staff2.Username.Value);
        }
        /// <summary>
        /// Compares two circulation copies by their IDs
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoCircCopies(CirculationCopy copy1, CirculationCopy copy2)
        {
            return TwoIntegers(copy1.Id.Value, copy2.Id.Value);
        }
        /// <summary>
        /// Compares two Smallest Book classes by their book's ISBN values
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoSmallestBooks(SmallestItem<Book> item1, SmallestItem<Book> item2)
        {
            return TwoStrings(item1.Item.Isbn.Value, item2.Item.Isbn.Value);
        }
        /// <summary>
        /// Compares two Smallest Member classes by thier members' barcodes
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoSmallestMembers(SmallestItem<Member> item1, SmallestItem<Member> item2)
        {
            return TwoStrings(item1.Item.Barcode.Value, item2.Item.Barcode.Value);

        }
        /// <summary>
        /// Compares two Smallest Circulation Copy classes by the circulation copies' IDs
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoSmallestCircCopies(SmallestItem<CirculationCopy> item1, SmallestItem<CirculationCopy> item2)
        {
            return TwoIntegers(item1.Item.Id.Value, item2.Item.Id.Value);
        }
        /// <summary>
        /// Compares two Smallest staff classes by the staff usernames
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoSmallestStaff(SmallestItem<Staff> item1, SmallestItem<Staff> item2)
        {
            return TwoStrings(item1.Item.Username.Value, item2.Item.Username.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="F">Class being referenced by the reference class</typeparam>
        /// <param name="referenceClass">Reference class to have its value compared</param>
        /// <param name="str">String of text</param>
        /// <returns>Returns equal if the reference class value is equal to or starts with the search term at the start, else returns if it is greater or less than the search term</returns>
        public static Greatest UpperRefClassStartsWithString<F>(ReferenceClass<string, F> referenceClass, string str) where F : class
        {
            if (referenceClass.Value.Length >= str.Length)
                if (referenceClass.Value.Substring(0, str.Length).ToUpper() == str.ToUpper())
                    return Greatest.Equal;
            return TwoStrings(referenceClass.Value.ToUpper(), str.ToUpper());
        }
        /// <summary>
        /// Compares two reference classes with string values and member references
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoRefClassStaff(ReferenceClass<string, Staff> staff1, ReferenceClass<string, Staff> staff2)
        {
            Greatest value = TwoStrings(staff1.Value, staff2.Value);
            if (value == Greatest.Equal)
                return TwoStrings(staff1.Reference.Username.Value, staff2.Reference.Username.Value);
            return value;
        }
        /// <summary>
        /// Compares two reference classes with string values and staff references. strings are compared case-insensitive
        /// </summary>
        /// <returns>Enum indicating the greater item</returns>
        public static Greatest TwoUpperRefClassStaff(ReferenceClass<string, Staff> staff1, ReferenceClass<string, Staff> staff2)
        {
            Greatest value = TwoStrings(staff1.Value.ToUpper(), staff2.Value.ToUpper());
            if (value == Greatest.Equal)
                return TwoStrings(staff1.Reference.Username.Value, staff2.Reference.Username.Value);
            return value;
        }
        #endregion
    }
    public enum Greatest
    {
        Left = 0,
        Right = 1,
        Equal = 2
    }
}