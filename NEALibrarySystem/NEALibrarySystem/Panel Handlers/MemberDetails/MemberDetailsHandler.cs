using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    /// <summary>
    /// Used to handle processes of the member details panel
    /// </summary>
    public class MemberDetailsHandler
    {
        // objects
        public MemberDetailsObjects _objects;
        // member record being modified
        private Member _memberData = null;
        private List<CirculationCopy> _circulationList = new List<CirculationCopy>(); // contains the list of circulation copies related to the member
        public MemberDetailsHandler(MemberDetailsObjects memberDetailsObjects)
        {
            _objects = memberDetailsObjects;

            // add the possible member types to the member type combo box 
            for (int i = 0; i < Member.TypeCount; i++)
                _objects.MemberType.Items.Add(((MemberType)i).ToString());
            // sets dateTime restrictions for the age
            _objects.DateOfBirth.MaxDate = DateTime.Today.AddDays(-1);
            _objects.DateOfBirth.MinDate = DateTime.Today.AddYears(-130);

            InitialiseCirculations();
        }
        /// <summary>
        /// Sets up the list view properties and columns
        /// </summary>
        private void InitialiseCirculations()
        {
            _objects.Circulations.Clear();
            _objects.Circulations.View = View.Details;
            _objects.Circulations.LabelEdit = false;
            _objects.Circulations.AllowColumnReorder = false;
            _objects.Circulations.CheckBoxes = false;
            _objects.Circulations.MultiSelect = true;
            _objects.Circulations.FullRowSelect = true;
            _objects.Circulations.GridLines = false;
            _objects.Circulations.Sorting = SortOrder.None;
            _objects.Circulations.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // add columns
            string[] columns = new string[3]
            {
                "Barcode",
                "Status",
                "Due Date"
            };
            ListViewHandler.SetColumns(columns, ref _objects.Circulations);
        }
        /// <summary>
        /// Sets up the objects of the member panel
        /// </summary>
        /// <param name="member">Member to be modified. Null if a new member record is being created</param>
        public void Load(Member member = null)
        {
            _memberData = member;
            _objects.Circulations.Items.Clear();
            if (member == null)
            {
                _objects.Barcode.Clear();
                _objects.FirstName.Clear();
                _objects.Surname.Clear();
                _objects.MemberType.Text = MemberType.Adult.ToString();
                _objects.DateOfBirth.Value = _objects.DateOfBirth.MaxDate;
                _objects.LinkedMembers.Clear();
                _objects.EmailAddress.Clear();
                _objects.PhoneNumber.Clear();
                _objects.Address1.Clear();
                _objects.Address2.Clear();
                _objects.TownCity.Clear();
                _objects.County.Clear();
                _objects.PostCode.Clear();
                _objects.JoinDate.Clear();
                _objects.Circulations.Items.Clear();
                _objects.LateFees.Text = "0.00";
            }
            else
            {
                _objects.Barcode.Text = member.Barcode.Value;
                _objects.FirstName.Text = member.FirstName.Value;
                _objects.Surname.Text = member.Surname.Value;
                _objects.MemberType.Text = member.Type.Value.ToString();
                _objects.DateOfBirth.Value = member.DateOfBirth;
                _objects.LinkedMembers.Text = DataFormatter.ListToString(member.LinkedMembers);
                _objects.EmailAddress.Text = member.EmailAddress;
                _objects.PhoneNumber.Text = member.PhoneNumber;
                _objects.Address1.Text = member.Address1;
                _objects.Address2.Text = member.Address2;
                _objects.TownCity.Text = member.TownCity;
                _objects.County.Text = member.County;
                _objects.PostCode.Text = member.Postcode;
                _objects.JoinDate.Text = DataFormatter.GetDate(member.JoinDate);
                // Get the member's loaned and reserved books
                if (_memberData.Circulations.Count > 0)
                {
                    foreach (CirculationCopy circulationCopy in _memberData.Circulations)
                    {
                        string[] data =
                        {
                            circulationCopy.BookCopy.Barcode.Value,
                            circulationCopy.Type.Value.ToString(),
                            DataFormatter.GetDate(circulationCopy.Date.Value)
                        };
                        _objects.Circulations.Items.Add(new ListViewItem(data));
                    }
                }

                // get total late fees
                double total = 0;
                if (_circulationList.Count > 0)
                    foreach (CirculationCopy copy in _circulationList)
                    total += CirculationCopy.GetLateFees(copy.DueDate.Value);
                _objects.LateFees.Text = DataFormatter.DoubleToPrice(total);
            }
        }
        /// <summary>
        /// Saves inputted member details into the member record
        /// </summary>
        public void Save()
        {
            // Gets member inputs
            MemberCreator memberCreator = new MemberCreator();
            memberCreator.Barcode = _objects.Barcode.Text;
            memberCreator.FirstName = _objects.FirstName.Text;
            memberCreator.Surname = _objects.Surname.Text;
            memberCreator.DateOfBirth = _objects.DateOfBirth.Value;
            memberCreator.Type = _objects.MemberType.Text;
            memberCreator.LinkedMembers = DataFormatter.SplitString(_objects.LinkedMembers.Text, ", ");
            memberCreator.EmailAddress = _objects.EmailAddress.Text;
            memberCreator.PhoneNumber = _objects.PhoneNumber.Text;
            memberCreator.Address1 = _objects.Address1.Text;
            memberCreator.Address2 = _objects.Address2.Text;
            memberCreator.TownCity = _objects.TownCity.Text;
            memberCreator.County = _objects.County.Text;
            memberCreator.Postcode = _objects.PostCode.Text;
            if (memberCreator.Validate(out List<string> errors, _memberData)) // check in inputes are valid
            {
                if (_memberData == null) // if creating a new record, add the new record to the list of members
                {
                    DataLibrary.Members.Add(new Member(memberCreator));
                    Load();
                }
                else // else modify the member record
                {
                    DataLibrary.ModifyMember(_memberData, memberCreator);
                    FrmMainSystem.Main.NavigatorOpenSearchViewTab();
                }
                FileHandler.Save.Members();
                FileHandler.Save.CirculationCopies();
            }
            else
                MessageBox.Show("Invalid inputs: " + DataFormatter.ListToString(errors));
        }
        /// <summary>
        /// Resets panel if creating a record, returns to search tab if modifying a record
        /// </summary>
        public void Cancel()
        {
            if (_memberData == null)
                Load();
            else
                FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
