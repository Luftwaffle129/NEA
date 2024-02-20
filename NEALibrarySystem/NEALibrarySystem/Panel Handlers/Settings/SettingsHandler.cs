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
            _objects.CirculationType.Items.Clear();
            _objects.CirculationType.Items.Add("Loans");
            _objects.CirculationType.Items.Add("Reservations");
            _objects.CirculationType.Text = "Loans";

            _objects.CirculationMemberType.Items.Clear();
            _objects.CirculationType.Items.Add(MemberType.Adult.ToString());
            _objects.CirculationType.Items.Add(MemberType.Child.ToString());
            _objects.CirculationType.Items.Add(MemberType.Elderly.ToString());
            _objects.CirculationType.Items.Add(MemberType.Deliverer.ToString());
            _objects.CirculationType.Text = MemberType.Adult.ToString();
        }
        public void Load()
        {
            settingsCreator.GetCurrentSettings();
            _objects.GmailUsername.Text = settingsCreator.GmailUsername;
            _objects.GmailPassword.Text = settingsCreator.GmailPassword;
            _objects.GmailKey.Text = settingsCreator.GmailKey;
            _objects.BarcodeBookCopy.Value = settingsCreator.BookCopyBarcodeLength;
            _objects.BarcodeMember.Value = settingsCreator.MemberBarcodeLength;
            _circulationType = 0;
            _circulationMemberType = 0;
            UpdateCirculationTimePeriod();
        }
        public void UpdateCirculationType()
        {

            if (_objects.CirculationType.Text == "Loans")
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
            _objects.CirculationTimeLength.Value = settingsCreator.Durations[_circulationType, _circulationMemberType];
        }
        public void SetCirculationTimePeriod()
        {
            settingsCreator.Durations[_circulationType, _circulationMemberType] = Convert.ToInt32(_objects.CirculationTimeLength.Value);
        }
        public void Save()
        {

        }
    }
}
