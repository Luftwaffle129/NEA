using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public static class Settings
    {
        private const int _memberTypes = 3;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string GmailKey { get; set; }
        public static int MemberBarcodeLength { get; set; }
        private static int[] _loanDurations = new int[_memberTypes];
        public static int[] LoanDurations 
        {
            get { return _loanDurations; }
            set { _loanDurations = value ?? new int[_memberTypes]; }
        }

    }
}
