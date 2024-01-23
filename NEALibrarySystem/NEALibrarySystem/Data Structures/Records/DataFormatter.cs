using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NEALibrarySystem.Data_Structures
{
    public static class DataFormatter
    {
        /// <summary>
        /// Converts a list of reference classes' values to a string with a ", " separating each item
        /// </summary>
        /// <typeparam name="T">Reference class value</typeparam>
        /// <typeparam name="F">Reference class reference</typeparam>
        /// <param name="list">List of reference classes</param>
        /// <returns>String of values</returns>
        public static string ListToString<T, F>(List<ReferenceClass<T, F>> list) where F : class
        {
            string output = "";
            if (list.Count > 0)
            {
                foreach (ReferenceClass<T, F> item in list)
                {
                    output += item.Value.ToString() + ", ";
                }
                output = output.Remove(output.Length - 2, 2);
            }
            return output;
        }
        /// <summary>
        /// Converts a list of strings to a single string with a ", " separating each item
        /// </summary>
        /// <param name="list">List of items</param>
        /// <returns>String of values</returns>
        public static string ListToString(List<string> list)
        {
            string output = "";
            if (list.Count > 0)
            {
                foreach (string item in list)
                {
                    output += item + ", ";
                }
                output = output.Remove(output.Length - 2, 2);
            }
            return output;
        }
        /// <summary>
        /// Converts a list of members to a single string with a ", " separating each member barcode
        /// </summary>
        /// <param name="list">List of items</param>
        /// <returns>String of values</returns>
        public static string ListToString(List<Member> list)
        {
            string output = "";
            if (list.Count > 0)
            {
                foreach (Member item in list)
                {
                    output += item.Barcode.Value + ", ";
                }
                output = output.Remove(output.Length - 2, 2);
            }
            return output;
        }
        /// <summary>
        /// Gets the date in the YYYY/MM/DD format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>string of the date in YYYY/MM/DD format</returns>
        public static string GetDate(DateTime dateTime)
        {
            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            month = month.Length == 1 ? "0" + month : month;
            string day = dateTime.Day.ToString();
            day = day.Length == 1 ? "0" + day : day;
            return $"{year}/{month}/{day}";
        }
        /// <summary>
        /// Gets the date in the YYYY/MM/DD HH/MM/SS format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>string of the date in YYYY/MM/DD HH/MM/SSformat</returns>
        public static string GetDateAndTime(DateTime dateTime)
        {
            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            month = month.Length == 1 ? "0" + month : month;
            string day = dateTime.Day.ToString();
            day = day.Length == 1 ? "0" + day : day;
            return $"{year}/{month}/{day} {dateTime.TimeOfDay}";
        }
        /// <summary>
        /// Splits the string into elements in a list using the separator
        /// </summary>
        /// <param name="text">string of items</param>
        /// <param name="separator">substring o characters used to separate the elements</param>
        /// <returns>List of itemsnfrom the string</returns>
        public static List<string> SplitString(string text, string separator)
        {
            List<string> stringArr = new List<string>(); //  string array to output
            int startIndex = 0;
            int pointer = 0; // points at the currently observed character
            int length = 0; // length of current item
            if (text.Length > 0) // if list is empty
            {
                if (text.Length >= separator.Length) // if list is smaller than the separator
                {
                    do // cycle through each character in the string
                    {
                        if (text.Substring(pointer, separator.Length) != separator) // if a separator is not on the current pointer index
                        {
                            length++;
                        }
                        else // else, add the element to the list and reset the length and start index. change the pointer to start at the next element in the string.
                        {
                            if (length > 0)
                                stringArr.Add(text.Substring(startIndex, length));
                            pointer += separator.Length - 1;
                            startIndex = pointer + 1;
                            length = 0;
                        }
                    } while (++pointer < text.Length - (separator.Length - 1));
                    if (text.Length > startIndex) // add the last item in the list if there is not a separator at the end of the string
                        stringArr.Add(text.Substring(startIndex));
                }
                else
                    stringArr.Add(text);
            }
            return stringArr;
        }
        /// <summary>
        /// Converts a string input into a enum value
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="value">String to attempt to match to a value in the enum</param>
        /// <returns>integer value of the enum</returns>
        public static int StringToEnum<T>(string value) where T : Enum
        {
            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                if (value == ((T)(object)i).ToString())
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Retrieves the list of the barcode of each member in the inputted list
        /// </summary>
        /// <param name="memberList"></param>
        /// <returns>List of member Barcodes</returns>
        public static List<string> MemberListToBarcodeList(List<Member> memberList)
        {
            List<string> barcodeList = new List<string>();
            if (memberList.Count > 0)
                foreach (Member member in memberList)
                    barcodeList.Add(member.Barcode.Value);
            return barcodeList;
        }
        /// <summary>
        /// Reverses the inputted list
        /// </summary>
        /// <typeparam name="T">Type within the list</typeparam>
        /// <param name="list">List of items to reverse</param>
        /// <returns>Reversed list</returns>
        public static List<T> ReverseList<T>(List<T> list)
        {
            // declare two pointers at each end of the list
            int left = 0;
            int right = list.Count - 1;
            // while they have not passed one another
            while (left < right)
            {
                // swap the elements at the pointers
                T temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                // move the pointers
                left++;
                right--;
            }
            return list;
        }
        /// <summary>
        /// Checks if text contains the subtext regardless of upper or lowercase characters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subtext">Text that may be contained in the other</param>
        /// <returns>True if text does contain subtext, false if otherwise</returns>
        public static bool Contains(string text, string subtext)
        {
            return text.ToUpper().Contains(subtext.ToUpper());
        }
        /// <summary>
        /// Convers an integer to a string of a specific length by adding 0s to the front until it matches the required length
        /// </summary>
        /// <param name="num">Integer input</param>
        /// <param name="length">Desired length of the string</param>
        /// <returns>String of the number with the inputted length</returns>
        public static string IntToString(int num, int length)
        {
            string text = num.ToString();
            while (text.Length < length)
                text = "0" + text;
            return text;
        }
        /// <summary>
        /// Converts a double number into a price format, assuming 2 or less decimal places are used
        /// </summary>
        /// <param name="num">Number to convert into a string price</param>
        /// <returns>Price in string format</returns>
        public static string DoubleToPrice(double num)
        {
            string price = num.ToString();
            // if the string is in the integer format, add a decimal place
            if (!price.Contains("."))
                price += '.';
            // while the price does not end in .XX, where X represents a number, append 0 to the end of the price
            while (!Regex.IsMatch(price, @"\.[0-9]{2}$"))
            {
                price += '0';
            }
            return price;
        }
    }
}