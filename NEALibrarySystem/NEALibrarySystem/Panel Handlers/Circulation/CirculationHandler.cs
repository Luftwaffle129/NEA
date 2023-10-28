using NEALibrarySystem.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Panel_Handlers.Circulation
{
    public static class CirculationHandler
    {
        public static string UpdateMemberName(string barcode)
        {
            foreach (Member member in DataLibrary.Members)
            {
                if (member.Barcode == barcode)
                {
                    return $"{member.FirstName} {member.LastName}";
                }
            }
            return "Not found";
        }
    }
}
