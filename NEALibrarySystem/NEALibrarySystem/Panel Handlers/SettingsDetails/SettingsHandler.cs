using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.RecordCreators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Panel_Handlers.Settings
{
    /// <summary>
    /// Used to handle the methods used in processes in the settings panel in the main form
    /// </summary>
    public class SettingsHandler
    {
        private SettingsObjects _objects;
        private SettingsCreator _settingsCreator = new SettingsCreator();
        private int _circulationType;       // index of the circulation type due date being edited in the settings panel
        private int _circulationMemberType; // index of the member type due date being edited in the settings panel
        public SettingsHandler(SettingsObjects objects) 
        {
            _objects = objects;

            // initial combobox settings
            _objects.CirculationCirculationType.Items.Clear();
            _objects.CirculationCirculationType.Items.Add("Loans");
            _objects.CirculationCirculationType.Items.Add("Reservations");

            _objects.CirculationMemberType.Items.Clear();
            _objects.CirculationMemberType.Items.Add(MemberType.Adult.ToString());
            _objects.CirculationMemberType.Items.Add(MemberType.Child.ToString());
            _objects.CirculationMemberType.Items.Add(MemberType.Elderly.ToString());
            _objects.CirculationMemberType.Items.Add(MemberType.Deliverer.ToString());;
        }
        /// <summary>
        /// Sets up the input fields with the current settings data
        /// </summary>
        public void Load()
        {
            _settingsCreator.GetCurrentSettings();
            _objects.BarcodeBookCopy.Value = _settingsCreator.BookCopyBarcodeLength;
            _objects.BarcodeMember.Value = _settingsCreator.MemberBarcodeLength;
            _circulationType = 0;
            _circulationMemberType = 0;
            _objects.CirculationCirculationType.Text = "Loans";
            _objects.CirculationMemberType.Text = MemberType.Adult.ToString();
            _objects.CirculationLateFee.Value = Convert.ToDecimal(_settingsCreator.LateFeePerDay);
        }
        /// <summary>
        /// Updates which circulation type due date is being edited
        /// </summary>
        public void UpdateCirculationType()
        {

            if (_objects.CirculationCirculationType.Text == "Loans")
                _circulationType = 0;
            else
                _circulationType = 1;
            UpdateCirculationTimePeriod();
        }
        /// <summary>
        /// Updates which member type due date is being edited
        /// </summary>
        public void UpdateCirculationMemberType()
        {
            _circulationMemberType = DataFormatter.StringToEnum<MemberType>(_objects.CirculationMemberType.Text);
            UpdateCirculationTimePeriod();
        }
        /// <summary>
        /// Updates the due date time period that is currently selected to the stored value
        /// </summary>
        public void UpdateCirculationTimePeriod()
        {
            try // try catch to stop errors on loading the panel
            {
                _objects.CirculationTimeLength.Value = _settingsCreator.Durations[_circulationType, _circulationMemberType];
            }
            catch { }
        }
        /// <summary>
        /// Updates the stored value of the due date time period that is currently selected to inputted value
        /// </summary>
        public void SetCirculationTimePeriod()
        {
            _settingsCreator.Durations[_circulationType, _circulationMemberType] = Convert.ToInt32(_objects.CirculationTimeLength.Value);
        }
        /// <summary>
        /// Saves the inputted settings data
        /// </summary>
        public void Save()
        {
            _settingsCreator.BookCopyBarcodeLength = Convert.ToInt32(_objects.BarcodeBookCopy.Value);
            _settingsCreator.MemberBarcodeLength = Convert.ToInt32(_objects.BarcodeMember.Value);
            _settingsCreator.LateFeePerDay = Convert.ToDouble(_objects.CirculationLateFee.Value);
            _settingsCreator.SetStoredSettings();
        }
    }
}
