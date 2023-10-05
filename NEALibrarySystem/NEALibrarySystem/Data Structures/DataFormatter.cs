using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public static class DataFormatter
    {
        public static string ListToString(List<string> data)
        {
            string output = "";
            if (data.Count == 0)
            {
                foreach (string item in data)
                {
                    output += item + ", ";
                }
                output = output.Remove(output.Length - 3, 2);
            }
            return output;
        }
    }
}