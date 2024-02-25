using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.RecordCreators
{
    [System.Serializable]
    public class StaffCreator
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// Validates the data stored in this class
        /// </summary>
        /// <param name="invalidList">List of invalid data</param>
        /// <param name="original">Original staff record</param>
        /// <returns>Boolean result of whether the data is valid</returns>
        public bool Validate(out List<string> invalidList, Staff original = null)
        {
            invalidList = new List<string>();
            if (FirstName.Length == 0) // first name cannot be empty
                invalidList.Add("First Name");
            if (FirstName.Length == 0) // surname cannot be empty
                invalidList.Add("Surname");
            if (!DataFormatter.IsValidEmail(EmailAddress) ) // email address must be in the correct format
                invalidList.Add("Email Address");
            else
            {
                if (original == null) // if creating a new record, username must be unique
                {
                    if (SearchAndSort.Binary(DataLibrary.StaffUsernames, Username, SearchAndSort.RefClassAndString) != -1)
                        invalidList.Add("Username");
                }
                else // if modifying a record, username must be unique or equal to old username
                {
                    if (!(SearchAndSort.Binary(DataLibrary.StaffUsernames, Username, SearchAndSort.RefClassAndString) == -1 || Username == original.Username.Value))
                        invalidList.Add("Username");
                }
            }
            if (Username.Length == 0) // username cannot be empty
                invalidList.Add("Username");
            else
            {
                if (original == null) // if creating a new record, username must be unique
                {
                    if (SearchAndSort.Binary(DataLibrary.StaffUsernames, Username, SearchAndSort.RefClassAndString) != -1)
                        invalidList.Add("Username");
                }
                else // if modifying a record, username must be unique or equal to old username
                {
                    if (!(SearchAndSort.Binary(DataLibrary.StaffUsernames, Username, SearchAndSort.RefClassAndString) == -1 || Username == original.Username.Value))
                        invalidList.Add("Username");
                }
            }
            if (Password.Length < 4) // password must be at least 4 characters long
                invalidList.Add("Password Too Short");
            return invalidList.Count == 0;
        }
    }
}
