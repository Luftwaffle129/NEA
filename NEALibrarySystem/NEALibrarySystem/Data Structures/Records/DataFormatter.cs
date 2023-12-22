﻿using System;
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
        // Gets the date in the dd/mm/yyyy format
        public static string GetDate(DateTime dateTime)
        {
            return dateTime.Date.ToString().Substring(0,10);
        }

        public static List<string> SplitString(string text, string separator)
        {
            List<string> stringArr = new List<string>();
            int startIndex = 0;
            int pointer = 0;
            int length = 0;
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
                    pointer += separator.Length;
                    startIndex = pointer;
                    length = 0;
                }
            } while (++pointer < text.Length - (separator.Length - 1));
            if (length > 0)
                stringArr.Add(text.Substring(startIndex, length + separator.Length));
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
    }
}