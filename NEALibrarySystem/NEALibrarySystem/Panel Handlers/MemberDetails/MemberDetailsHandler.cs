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
        public MemberDetailsObjects Objects;
        public ListViewSorting Sorting;
        // member record being modified
        private Member _memberData = null;
        private List<CirculationCopy> _circulationList = new List<CirculationCopy>(); // contains the list of circulation copies related to the member
        public MemberDetailsHandler(MemberDetailsObjects memberDetailsObjects)
        {
            Sorting = new ListViewSorting();
            Objects = memberDetailsObjects;

            // add the possible member types to the member type combo box 
            for (int i = 0; i < Member.TypeCount; i++)
                Objects.MemberType.Items.Add(((MemberType)i).ToString());
            // sets dateTime restrictions for the age
            Objects.DateOfBirth.MaxDate = DateTime.Today.AddDays(-1);
            Objects.DateOfBirth.MinDate = DateTime.Today.AddYears(-130);

            InitialiseCirculations();
        }
        /// <summary>
        /// Sets up the list view properties and columns
        /// </summary>
        private void InitialiseCirculations()
        {
            Objects.Circulations.Clear();
            Objects.Circulations.View = View.Details;
            Objects.Circulations.LabelEdit = false;
            Objects.Circulations.AllowColumnReorder = false;
            Objects.Circulations.CheckBoxes = false;
            Objects.Circulations.MultiSelect = true;
            Objects.Circulations.FullRowSelect = true;
            Objects.Circulations.GridLines = false;
            Objects.Circulations.Sorting = SortOrder.None;
            Objects.Circulations.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // add columns
            string[] columns = new string[3]
            {
                "Barcode",
                "Status",
                "Due Date"
            };
            ListViewHandler.SetColumns(columns, ref Objects.Circulations);
        }
        /// <summary>
        /// Sets up the objects of the member panel
        /// </summary>
        /// <param name="member">Member to be modified. Null if a new member record is being created</param>
        public void Load(Member member = null)
        {
            _memberData = member;
            Objects.Circulations.Items.Clear();
            if (member == null)
            {
                Objects.Barcode.Clear();
                Objects.FirstName.Clear();
                Objects.Surname.Clear();
                Objects.MemberType.Text = MemberType.Adult.ToString();
                Objects.DateOfBirth.Value = Objects.DateOfBirth.MaxDate;
                Objects.LinkedMembers.Clear();
                Objects.EmailAddress.Clear();
                Objects.PhoneNumber.Clear();
                Objects.Address1.Clear();
                Objects.Address2.Clear();
                Objects.TownCity.Clear();
                Objects.County.Clear();
                Objects.PostCode.Clear();
                Objects.JoinDate.Clear();
                Objects.Circulations.Items.Clear();
                Objects.LateFees.Text = "0.00";
            }
            else
            {
                Objects.Barcode.Text = member.Barcode.Value;
                Objects.FirstName.Text = member.FirstName.Value;
                Objects.Surname.Text = member.Surname.Value;
                Objects.MemberType.Text = member.Type.Value.ToString();
                Objects.DateOfBirth.Value = member.DateOfBirth;
                Objects.LinkedMembers.Text = DataFormatter.ListToString(member.LinkedMembers);
                Objects.EmailAddress.Text = member.EmailAddress;
                Objects.PhoneNumber.Text = member.PhoneNumber;
                Objects.Address1.Text = member.Address1;
                Objects.Address2.Text = member.Address2;
                Objects.TownCity.Text = member.TownCity;
                Objects.County.Text = member.County;
                Objects.PostCode.Text = member.Postcode;
                Objects.JoinDate.Text = DataFormatter.GetDate(member.JoinDate);
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
                        Objects.Circulations.Items.Add(new ListViewItem(data));
                    }
                    ListViewHandler.ResizeColumnHeaders(ref Objects.Circulations);
                    ListViewHandler.ColourListViewNormal(ref Objects.Circulations);
                }

                // get total late fees
                double total = 0;
                if (_circulationList.Count > 0)
                    foreach (CirculationCopy copy in _circulationList)
                    total += CirculationCopy.GetLateFees(copy.DueDate.Value);
                Objects.LateFees.Text = DataFormatter.DoubleToPrice(total);
            }
        }
        /// <summary>
        /// Saves inputted member details into the member record
        /// </summary>
        public void Save()
        {
            // Gets member inputs
            MemberCreator memberCreator = new MemberCreator();
            memberCreator.Barcode = Objects.Barcode.Text;
            memberCreator.FirstName = Objects.FirstName.Text;
            memberCreator.Surname = Objects.Surname.Text;
            memberCreator.DateOfBirth = Objects.DateOfBirth.Value;
            memberCreator.Type = Objects.MemberType.Text;
            memberCreator.LinkedMembers = DataFormatter.SplitString(Objects.LinkedMembers.Text, ", ");
            memberCreator.EmailAddress = Objects.EmailAddress.Text;
            memberCreator.PhoneNumber = Objects.PhoneNumber.Text;
            memberCreator.Address1 = Objects.Address1.Text;
            memberCreator.Address2 = Objects.Address2.Text;
            memberCreator.TownCity = Objects.TownCity.Text;
            memberCreator.County = Objects.County.Text;
            memberCreator.Postcode = Objects.PostCode.Text;
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
