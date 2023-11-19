using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.Circulation
{
    public static class CirculationHandler
    {
        /// <summary>
        /// Updates the member details to equal those of the inputted barcode's member
        /// </summary>
        /// <param name="name">TextBox displaying the member name</param>
        /// <param name="loans">TextBox displaying the number of loans the member has</param>
        /// <param name="overdue">Textbox displaying the number of overdue loans the member has</param>
        /// <param name="lateFees">TextBox displaying the total late fees the member has</param>
        /// <param name="barcode">barcode of the member to retrieve the details of</param>
        public static void UpdateMemberDetails(ref TextBox name, ref TextBox loans, ref TextBox overdue, ref TextBox lateFees, string barcode)
        {
            CirculationMemberDetails memberDetails = new CirculationMemberDetails(barcode);
            name.Text = memberDetails.Name;
            loans.Text = memberDetails.CurrentLoans.ToString();
            overdue.Text = memberDetails.OverdueBooks.ToString();
            lateFees.Text = memberDetails.LateFees.ToString();
        }
        public static void AddBook(string barcode)
        {

        }
    }
}
