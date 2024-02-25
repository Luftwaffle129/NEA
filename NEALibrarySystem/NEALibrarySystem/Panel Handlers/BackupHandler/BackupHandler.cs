using System;
using System.Windows.Forms;
using NEALibrarySystem.Data_Structures;

namespace NEALibrarySystem.Panel_Handlers.BackupHandler
{
    /// <summary>
    /// Used to handle the processes needed in the back up panel in the main form
    /// </summary>
    public class BackupHandler
    {
        private Label _lastBackupDate; // used to reference the last backup date label in the main form

        /// <param name="lastBackupDate">Last backup date label in the settings panel</param>
        public BackupHandler(Label lastBackupDate) 
        { 
            _lastBackupDate = lastBackupDate;
        }
        /// <summary>
        /// Used to set up the form when the user selects the settings feature.
        /// Updates the last backup date label
        /// </summary>
        public void Load()
        {
            string backupDate = Data_Structures.Settings.LastBackup == DateTime.MinValue ? "Never" : DataFormatter.GetDateAndTime(Data_Structures.Settings.LastBackup);
            _lastBackupDate.Text = "Last Backup Date: " + backupDate;
        }
        /// <summary>
        /// Starts the saving a back up process.
        /// Prompts the user with a confirmation form and saves a back up if the user says yes. Outputs whether it worked
        /// </summary>
        public void SaveBackup()
        {
            frmConfirmation frmConfirmation = new frmConfirmation("Are you sure you want to save a backup?", System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight);
            frmConfirmation.ShowDialog();
            if (frmConfirmation.DialogResult == DialogResult.Yes)
            {
                if (FileHandler.Backup.Save())
                {
                    MessageBox.Show("Back up created");
                    Load(); // reset date of last back up created
                }
                else
                    MessageBox.Show("Back up failed");
            }
        }
        /// <summary>
        /// Starts the loaing a back up process.
        /// Prompts the user with a confirmation form and loads the back up if the users says yes. Outputs whether it worked
        /// </summary>
        public void LoadBackup() 
        {
            frmConfirmation frmConfirmation = new frmConfirmation("Are you sure you want to load a backup?", System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight);
            frmConfirmation.ShowDialog();
            if (frmConfirmation.DialogResult == DialogResult.Yes)
            {
                if (FileHandler.Backup.Restore())
                    MessageBox.Show("Back up loaded");
                else
                    MessageBox.Show("Back up failed");
            }
        }
    }
}
