namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    public class StaffSaver
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdministrator { get; set; }
    }
}
