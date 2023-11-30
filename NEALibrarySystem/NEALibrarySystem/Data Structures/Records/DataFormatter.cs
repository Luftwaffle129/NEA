using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        public static string ReferenceClassListToString<T, F>(List<ReferenceClass<T, F>> list) where F : class
        {
            string output = "";
            if (list.Count > 0)
            {
                foreach (ReferenceClass<T, F> item in list)
                {
                    output += item.Value.ToString() + ",";
                }
                output = output.Remove(output.Length - 1, 1);
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
    }
}