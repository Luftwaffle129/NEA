using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using NEALibrarySystem.Data_Structures.Records;
using NEALibrarySystem.Data_Structures;

namespace NEALibrarySystem.Panel_Handlers.BackupHandler
{
    public class BackupHandler
    {
        public Label _lastBackupDate;

        public BackupHandler(Label lastBackupDate) 
        { 
            _lastBackupDate = lastBackupDate;
        }
        public void Load()
        {
            string backupDate = Data_Structures.Settings.LastBackup == DateTime.MinValue ? "Never" : DataFormatter.GetDateAndTime(Data_Structures.Settings.LastBackup);
            _lastBackupDate.Text = "Last Backup Date: " + backupDate;
        }
        public void SaveBackup()
        {
            frmConfirmation frmConfirmation = new frmConfirmation("Are you sure you want to save a backup?", System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.ControlLight);
            frmConfirmation.ShowDialog();
            if (frmConfirmation.DialogResult == DialogResult.Yes)
            {
                if (FileHandler.Backup.Save())
                {
                    MessageBox.Show("Back up created");
                    Load();
                }
                else
                    MessageBox.Show("Back up failed");
            }
        }
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
