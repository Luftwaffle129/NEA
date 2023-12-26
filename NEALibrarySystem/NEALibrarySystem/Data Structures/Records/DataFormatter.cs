using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace NEALibrarySystem.Data_Structures
{
    public static class DataFormatter
    {
        /// <summary>
        /// converts a list of reference classes' values to a string
        /// </summary>
        /// <typeparam name="T">Reference class value</typeparam>
        /// <typeparam name="F">Reference class reference</typeparam>
        /// <param name="list">list of reference classes</param>
        /// <returns>string of values</returns>
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
        /// removes the white space from a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(string text)
        {
            string output = "";
            if (text.Length > 0)
            {
                for (int index = 0; index < text.Length; index++)
                {
                    string character = text.Substring(index, 1);
                    if (Regex.IsMatch(character, @"\S"))
                    {
                        output += character;
                    }
                }
            }
            return output;
        }
        // Gets the date in the YYYY/MM/DD format
        public static string GetDate(DateTime dateTime)
        {
            string year = dateTime.Year.ToString();
            string month = dateTime.Month.ToString();
            month = month.Length == 1 ? "0" + month : month;
            string day = dateTime.Day.ToString();
            day = day.Length == 1 ? "0" + day : day;
            return $"{year}/{month}/{day}";
        }
        // Gets the date in the YYYY/MM/DD HH/MM/SS format
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
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<string> SplitString(string text, string separator)
        {
            List<string> stringArr = new List<string>();
            int startIndex = 0;
            int pointer = 0;
            int length = 0;
            if (text.Length > 0)
            {
                if (text.Length >= separator.Length)
                {
                    do
                    {
                        if (text.Substring(pointer, separator.Length) != separator)
                        {
                            length++;
                        }
                        else
                        {
                            if (length > 0)
                                stringArr.Add(text.Substring(startIndex, length));
                            pointer += separator.Length - 1;
                            startIndex = pointer + 1;
                            length = 0;
                        }
                    } while (++pointer < text.Length - (separator.Length - 1));
                    if (text.Length > startIndex)
                        stringArr.Add(text.Substring(startIndex));
                }
                else
                    stringArr.Add(text);
            }
            return stringArr;
        }
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
        public static List<string> MemberListToBarcodeList(List<Member> memberList)
        {
            List<string> barcodeList = new List<string>();
            if (memberList.Count > 0)
                foreach (Member member in memberList)
                    barcodeList.Add(member.Barcode.Value);
            return barcodeList;
        }
        public static List<T> ReverseList<T>(List<T> list)
        {
            int left = 0;
            int right = list.Count - 1;
            while (left < right)
            {
                T temp = list[left];
                list[left] = list[right];
                list[right] = temp;
                left++;
                right--;
            }
            return list;
        }
        /// <summary>
        /// Checks if text contains the subtext regardless of upper or lowercase characters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="subtext">text that may be contained in the other</param>
        /// <returns>True if text does contain subtext, false if otherwise</returns>
        public static bool Contains(string text, string subtext)
        {
            return text.ToUpper().Contains(subtext.ToUpper());
        }
        public static string IntToString(int num, int length)
        {
            string text = num.ToString();
            while (text.Length < length)
                text = "0" + text;
            return text;
        }
    }
}