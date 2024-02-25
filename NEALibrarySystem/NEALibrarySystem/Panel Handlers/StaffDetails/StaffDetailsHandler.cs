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
    /// <summary>
    /// Used to handle the methods used in processes in the staff details panel in the main form
    /// </summary>
    public class StaffDetailsHandler
    {
        private StaffDetailsObjects _objects = new StaffDetailsObjects();
        private Staff _staffData;       // staff record being modified. null if creating a staff record
        public StaffDetailsHandler(StaffDetailsObjects objects) 
        {
            _objects = objects;
            _objects.AccessLevel.Items.Add("Staff");
            _objects.AccessLevel.Items.Add("Administrator");
        }
        /// <summary>
        /// Loads the staff details into the input boxes if creating a record, empties the input fields if creating a new staff record
        /// </summary>
        /// <param name="staff"></param>
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
                _objects.Email.Text = staff.EmailAddress.Value;
                _objects.AccessLevel.Text = staff.IsAdministrator ? "Administrator" : "Staff";
            }
        }
        /// <summary>
        /// Saves the inputted staff details into a modified or created staff record
        /// </summary>
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
            if (creator.Validate(out errors, _staffData)) // if inputted data is valid
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
        /// <summary>
        /// Cancels the creation or modificaiton of a staff record. If creating, reset the panel. If modifying, reopen the search panel.
        /// </summary>
        public void Cancel() 
        {
            if (_staffData == null) // if creating a new record
                Load();
            else
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
