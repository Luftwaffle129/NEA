﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public static class Settings
    {
        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailKey { get; set; }
        public static int MemberBarcodeLength { get; set; }
        public static int BookCopyBarcodeLength { get; set; }

        private static int[] _loanDurations = new int[Member.MemberTypeCount];
        public static int[] LoanDurations 
        {
            get { return _loanDurations; }
            set { _loanDurations = value ?? new int[Member.MemberTypeCount]; }
        }
        private static int[] _reserveDurations = new int[Member.MemberTypeCount];
        public static int[] ReserveDurations
        {
            get { return _reserveDurations; }
            set { _reserveDurations = value ?? new int[Member.MemberTypeCount]; }
        }
        public static double LateFeePerDay { get; set; }
    }
}
