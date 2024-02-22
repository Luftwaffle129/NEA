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
    public class SettingsHandler
    {
        private SettingsObjects _objects;
        private SettingsCreator settingsCreator = new SettingsCreator();
        private int _circulationType;
        private int _circulationMemberType;
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
        public void Load()
        {
            settingsCreator.GetCurrentSettings();
            _objects.BarcodeBookCopy.Value = settingsCreator.BookCopyBarcodeLength;
            _objects.BarcodeMember.Value = settingsCreator.MemberBarcodeLength;
            _circulationType = 0;
            _circulationMemberType = 0;
            _objects.CirculationCirculationType.Text = "Loans";
            _objects.CirculationMemberType.Text = MemberType.Adult.ToString();
            _objects.CirculationLateFee.Value = Convert.ToDecimal(settingsCreator.LateFeePerDay);
        }
        public void UpdateCirculationType()
        {

            if (_objects.CirculationCirculationType.Text == "Loans")
                _circulationType = 0;
            else
                _circulationType = 1;
            UpdateCirculationTimePeriod();
        }
        public void UpdateCirculationMemberType()
        {
            _circulationMemberType = DataFormatter.StringToEnum<MemberType>(_objects.CirculationMemberType.Text);
            UpdateCirculationTimePeriod();
        }
        public void UpdateCirculationTimePeriod()
        {
            try
            {
                _objects.CirculationTimeLength.Value = settingsCreator.Durations[_circulationType, _circulationMemberType];
            }
            catch { }
        }
        public void SetCirculationTimePeriod()
        {
            settingsCreator.Durations[_circulationType, _circulationMemberType] = Convert.ToInt32(_objects.CirculationTimeLength.Value);
        }
        public void Save()
        {
            settingsCreator.BookCopyBarcodeLength = Convert.ToInt32(_objects.BarcodeBookCopy.Value);
            settingsCreator.MemberBarcodeLength = Convert.ToInt32(_objects.BarcodeMember.Value);
            settingsCreator.LateFeePerDay = Convert.ToDouble(_objects.CirculationLateFee.Value);
            settingsCreator.SetStoredSettings();
        }
    }
}
