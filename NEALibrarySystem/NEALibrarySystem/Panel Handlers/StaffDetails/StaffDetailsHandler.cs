using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.Data_Structures.RecordCreators;
using NEALibrarySystem.Panel_Handlers.StaffDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Panel_Handlers.StaffHandler
{
    public class StaffDetailsHandler
    {
        private StaffDetailsObjects _objects = new StaffDetailsObjects();
        private Staff _staffData;
        public StaffDetailsHandler(StaffDetailsObjects objects) 
        {
            _objects = objects;
            _objects.AccessLevel.Items.Add("Staff");
            _objects.AccessLevel.Items.Add("Administrator");
        }

        public void Load(Staff staff = null)
        {
            _staffData = staff;
            if (staff == null)
            {
                _objects.FirstName.Text = string.Empty;
                _objects.Surname.Text = string.Empty;
                _objects.Username.Text = string.Empty;
                _objects.Password.Text = string.Empty;
                _objects.Email.Text = string.Empty;
                _objects.AccessLevel.Text = "Staff";
            }
            else
            {
                _objects.FirstName.Text = staff.FirstName.Value;
                _objects.Surname.Text = staff.Surname.Value;
                _objects.Username.Text = staff.Username.Value;
                _objects.Password.Text = staff.Password;
                _objects.Email.Text = staff.EmailAddress;
                _objects.AccessLevel.Text = staff.IsAdministrator ? "Administrator" : "Staff";
            }
        }
        public void Save()
        {
            StaffCreator creator = new StaffCreator();
            creator.FirstName = _objects.FirstName.Text;
            creator.Surname = _objects.Surname.Text;
            creator.Username = _objects.Username.Text;
            creator.Password = _objects.Password.Text;
            creator.EmailAddress = _objects.Email.Text;
            creator.IsAdministrator = _objects.AccessLevel.Text == "Staff" ? false : true;
            List<string> errors;
            if (creator.Validate(out errors, _staffData))
            {
                if (_staffData == null) // if a new staff record is being created
                {
                    Staff staff = new Staff(creator);
                    DataLibrary.StaffList.Add(staff);
                }
                else
                {
                    DataLibrary.ModifyStaff(_staffData, creator);
                }
                FileHandler.Save.Staff();
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
            }
            else
            {
                MessageBox.Show("Invalid inputs: " + DataFormatter.ListToString(errors));
            }
        }
        public void Cancel() 
        {
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
