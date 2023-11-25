using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem
{
    public static class Comparison
    {
        public static Greatest TwoStrings(string text1, string text2)
        {
            if (text1 == text2)
                return Greatest.equal;
            bool isText2Larger = (text2.Length > text1.Length) ? true : false;
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
            return isText2Larger ? Greatest.Right : Greatest.Left;
        }
    }
    public enum Greatest
    {
        Left = 0,
        Right = 1,
        equal = 2
    }
}
