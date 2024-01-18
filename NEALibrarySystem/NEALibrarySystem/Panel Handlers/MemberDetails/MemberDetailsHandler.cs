﻿using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace NEALibrarySystem
{
    public class MemberDetailsHandler
    {
        // objects
        public MemberDetailsObjects _objects;
        // member record being modified
        private Member _memberData;
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
            if (member == null)
            {
                _objects.Barcode.Clear();
                _objects.FirstName.Clear();
                _objects.Surname.Clear();
                _objects.MemberType.Text = string.Empty;
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
                _objects.LateFees.Clear();
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
                if (_memberData.CircMemberRelations.Count > 0)
                    foreach (CircMemberRelation circRelation in _memberData.CircMemberRelations)
                        _circulationList.Add(circRelation.CirculationCopy);
                foreach (CirculationCopy circCopy in _circulationList)
                {
                    string[] data =
                    {
                        circCopy.BookCopy.Barcode.Value,
                        circCopy.Type.Value.ToString(),
                        DataFormatter.GetDate(circCopy.Date.Value)
                    };
                    _objects.Circulations.Items.Add(new ListViewItem(data));
                }
                // get total late fees
                double total = 0;
                if (_circulationList.Count > 0)
                    foreach (CirculationCopy copy in _circulationList)
                    total += CirculationCopy.GetLateFees(copy.DueDate.Value);
            }
        }
        /// <summary>
        /// Saves
        /// </summary>
        public void Save()
        {
            // Gets member inputs
            MemberCreator memberCreator = new MemberCreator();
            memberCreator.Barcode = _objects.Barcode.Text;
            memberCreator.FirstName = _objects.FirstName.Text;
            memberCreator.Surname = _objects.Surname.Text;
            memberCreator.DateOfBirth = _objects.DateOfBirth.Value;
            memberCreator.LinkedMembers = DataFormatter.SplitString(_objects.LinkedMembers.Text, ", ");
            memberCreator.EmailAddress = _objects.EmailAddress.Text;
            memberCreator.PhoneNumber = _objects.PhoneNumber.Text;
            memberCreator.Address1 = _objects.Address1.Text;
            memberCreator.Address2 = _objects.Address2.Text;
            memberCreator.TownCity = _objects.TownCity.Text;
            memberCreator.County = _objects.County.Text;
            memberCreator.Postcode = _objects.PostCode.Text;
            if (memberCreator.Validate(out List<string> errors)) // check in inputes are valid
            {
                if (_memberData == null) // if creating a new record, add the new record to the list of members
                    DataLibrary.Members.Add(new Member(memberCreator));
                else // else modify the member record
                    DataLibrary.ModifyMember(_memberData, memberCreator);
                FileHandler.Save.Members();
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
