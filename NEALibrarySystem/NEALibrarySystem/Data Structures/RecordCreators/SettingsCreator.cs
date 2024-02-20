using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.RecordCreators
{
    [System.Serializable]
    public class SettingsCreator
    {
        public string GmailUsername;
        public string GmailEmail;
        public string GmailPassword;
        public string GmailKey;
        public int MemberBarcodeLength;
        public int BookCopyBarcodeLength;
        public DateTime LastBackup;

        private int[,] _durations = new int[2, Member.TypeCount]; // [0, X] refers to a loan duration, [1, X] refers to a reservation duration
        public int[,] Durations
        {
            get { return _durations; }
            set { _durations = value ?? new int[2, Member.TypeCount]; }
        }
        public double LateFeePerDay { get; set; }
        public void GetCurrentSettings()
        {
            GmailUsername = Settings.GmailUsername;
            GmailPassword = Settings.GmailPassword;
            GmailKey = Settings.GmailKey;
            MemberBarcodeLength = Settings.MemberBarcodeLength;
            BookCopyBarcodeLength = Settings.BookCopyBarcodeLength;
            LateFeePerDay = Settings.LateFeePerDay;
            LastBackup = Settings.LastBackup;
            for (int i = 0; i < Settings.LoanDurations.Length; i++)
            {
                Durations[0, i] = Settings.LoanDurations[i];
                Durations[1, i] = Settings.ReserveDurations[i];
            }
        }
        public void SetStoredSettings()
        {
            Settings.GmailUsername = GmailUsername;
            Settings.GmailPassword = GmailPassword;
            Settings.GmailKey = GmailKey;
            Settings.MemberBarcodeLength = MemberBarcodeLength;
            Settings.BookCopyBarcodeLength = BookCopyBarcodeLength;
            Settings.LateFeePerDay = LateFeePerDay;
            Settings.LastBackup = LastBackup;
            for (int i = 0; i < 4; i++)
            {
                Settings.LoanDurations[i] = Durations[0, i];
                Settings.ReserveDurations[i] = Durations[1, i];
            }
        }
        public void GetDefaultSettings() 
        {
            MemberBarcodeLength = 10;
            BookCopyBarcodeLength = 6;
            Durations = new int[2, 4] { { 14, 14, 28, 28 }, {14, 14, 28 ,28} };
            LateFeePerDay = 0.05;
            LastBackup = DateTime.MinValue;
        }
        public void Validate()
        {

        }
    }
}
