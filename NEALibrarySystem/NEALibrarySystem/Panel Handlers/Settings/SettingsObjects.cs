using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.Settings
{
    /// <summary>
    /// Used to store the objects used in the settings panel
    /// </summary>
    public class SettingsObjects
    {
        public TextBox GmailUsername;
        public TextBox GmailPassword;
        public TextBox GmailKey;
        public NumericUpDown BarcodeBookCopy;
        public NumericUpDown BarcodeMember;
        public NumericUpDown CirculationLateFee;
        public ComboBox CirculationType;
        public ComboBox CirculationMemberType;
        public NumericUpDown CirculationTimeLength;
    }
}
