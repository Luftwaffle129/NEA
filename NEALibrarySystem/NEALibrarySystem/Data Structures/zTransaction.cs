using NEALibrarySystem.ListViewHandlers.CirculatedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class zTransaction
    {
        private int _ID;
        public int ID
        {
            get { return ID; }
            private set { ID = value; }
        }
        private TransactionType _type;
        public TransactionType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _memberBarcode;
        public string MemberBarcode
        {
            get { return _memberBarcode; }
            set { _memberBarcode = value; }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private List<string> _barcodes;
        public List<string> Barcodes 
        { 
            get { return _barcodes; } 
            set { _barcodes = value ?? new List<string>(); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public zTransaction()
        {

        }
        /// <summary>
        /// Custom transaction constructor
        /// </summary>
        /// <param name="memberBarcode"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        public zTransaction(string memberBarcode, double price, string description)
        {
            _memberBarcode = memberBarcode;
            _type = TransactionType.Custom;
            _price = price;
            _description = description;
            Date = DateTime.Now;
        }
        /// <summary>
        /// Book circulation constructor for loans and Reservations
        /// </summary>
        /// <param name="circulatedBooks">List of books involved in the transaction</param>
        /// <param name="memberBarcode"></param>
        /// <param name="type">Type of transaction or circulation</param>
        /// <param name="dueDate">Date of a book return or reservation pick up date</param>
        /// <param name="price"></param>
        public zTransaction(List<zCirculatedBook> circulatedBooks, string memberBarcode, TransactionType type, DateTime dueDate)
        {
            _memberBarcode = memberBarcode;
            _type = type;
            Date = dueDate;
        }
        public zTransaction(List<zCirculatedBook> circulatedBooks, string memberBarcode, TransactionType type)
        {
            _memberBarcode = memberBarcode;
            _type = type;
        }

        public zTransaction(List<zCirculatedBook> circulatedBooks, string memberBarcode, double price)
        {
            _memberBarcode = memberBarcode;
            _type = TransactionType.Sale;
            _price = price;
        }
        private void CreateID()
        {
            if (DataLibrary.Transactions.Count > 0)
            {
                int lowestID = 0;
                
            }
        }
    }
    public enum TransactionType
    {
        Reservation = 0,
        Loan = 1,
        Return = 2,
        Sale = 3,
        Custom = 4
    }
}

