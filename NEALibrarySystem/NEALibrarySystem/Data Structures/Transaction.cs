﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    public class Transaction
    {
        private TransactionType _type;
        public TransactionType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _memberBarcode;
        public string Memberbarcode
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
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private List<string> _ISBN;
        public List<string> ISBN 
        { 
            get { return _ISBN; } 
            set { _ISBN = value ?? new List<string>(); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
    public enum TransactionType
    {
        Reservation = 0,
        Loan = 1,
        Return = 2,
        Sale = 3
    }
}

