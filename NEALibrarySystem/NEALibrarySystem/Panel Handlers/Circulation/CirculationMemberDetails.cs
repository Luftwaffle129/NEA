using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Panel_Handlers.Circulation
{
    /// <summary>
    /// used to find the necessary circulation information of a member
    /// </summary>
    public class CirculationMemberDetails
    {
        #region attributes
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        private int _currentLoans;
        public int CurrentLoans
        {
            get { return _currentLoans; }
            private set { _currentLoans = value; }
        }
        private int _overdueBooks;
        public int OverdueBooks
        {
            get { return _overdueBooks; }
            private set { _overdueBooks = value; }
        }
        private double _lateFees;
        public double LateFees
        {
            get { return _lateFees; }
            private set { _lateFees = value; }
        }
        #endregion
        public CirculationMemberDetails(string barcode)
        {
            CurrentLoans = 0;
            OverdueBooks = 0;
            LateFees = 0;

            if (DataLibrary.Members.Count > 0)
            {
                int index = 0;
                bool memberFound = false;
                do
                {
                    if (DataLibrary.Members[index].Barcode == barcode)
                    {
                        memberFound = true;
                        Name = $"{DataLibrary.Members[index].FirstName} {DataLibrary.Members[index].LastName}";
                    }
                } while (++index < DataLibrary.Members.Count && !memberFound);
                if (DataLibrary.Books.Count > 0)
                {
                    foreach (Book book in DataLibrary.Books)
                    {
                        if (book.BookCopies.Count > 0)
                        {
                            foreach (BookCopy bookCopy in book.BookCopies)
                            {
                                if (bookCopy.MemberID == barcode)
                                {
                                    if (bookCopy.Status == status.Loaned)
                                    {
                                        CurrentLoans++;
                                        if (bookCopy.DueDate <= DateTime.Now)
                                        {
                                            OverdueBooks++;
                                            LateFees += 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
