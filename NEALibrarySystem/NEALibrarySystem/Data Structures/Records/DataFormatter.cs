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
        public static string ItemBookListToString(List<ItemBook> itemBookList)
        {
            string output = "";
            if (itemBookList.Count > 0)
            {
                foreach (ItemBook itemBook in itemBookList)
                {
                    output += itemBook.Name + ", ";
                }
                output = output.Remove(output.Length - 2, 2);
            }
            return output;
        }
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