using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.CirculationDetails
{
    /// <summary>
    /// Used to store the objects used in the circulation details panel handler
    /// </summary>
    public class CirculationDetailsObjects
    {
        public TextBox Id;
        public TextBox Type;
        public TextBox MemberBarcode;
        public TextBox MemberName;
        public TextBox Date;
        public DateTimePicker DueDate;
        public ListView BookCopy;
    }
}
