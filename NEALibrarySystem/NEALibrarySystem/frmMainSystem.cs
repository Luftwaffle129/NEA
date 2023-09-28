using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using NEALibrarySystem.Data_Structures;
using System.Drawing.Printing;
using NEALibrarySystem.SearchList;

namespace NEALibrarySystem
{
    public partial class frmMainSystem : Form
    {
        private SearchedItemsLoader searchedItemsLoader;
        public frmMainSystem()
        {
            InitializeComponent();
            InitializePanels();
            searchedItemsLoader = new SearchedItemsLoader(lsvSearchItems);
        }

        public bool isAdministrator;

        private void frmMainSystem_Load(object sender, EventArgs e)
        {
            bool leftPanelVisible = true; 
            bool topPanelVisible = true;
            DataLibrary.LoadAllFiles();

            //overdue books
        }
        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenBookTab();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            DataLibrary.LoadTestData1();
        }
        private void btnTransactions_Click(object sender, EventArgs e)
        {

        }
        private void btnStaffMembers_Click(object sender, EventArgs e)
        {

        }
        private void btnStatistics_Click(object sender, EventArgs e)
        {

        }
        private void btnBackups_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblFilter1_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grpDataGrid_Enter(object sender, EventArgs e)
        {

        }
        frmConfirmation frmConfirmation;
        private void pctIcon_Click(object sender, EventArgs e)
        {
            frmConfirmation = new frmConfirmation();
            frmConfirmation.ShowDialog();
        }

        private void btnSecondaryTab1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
        frmDesigner frmDesigner;
        private void btnSecondaryTab2_Click(object sender, EventArgs e)
        {
            frmDesigner= new frmDesigner();
            frmDesigner.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        frmCustomTransaction frmCustomTransaction;
        private void btnSecondaryTab3_Click(object sender, EventArgs e)
        {
            frmCustomTransaction = new frmCustomTransaction();
            frmCustomTransaction.ShowDialog();
        }
        bool runT = false;
        private void btnSecondaryTab4_Click(object sender, EventArgs e)
        {
            if (runT)
            { grpRunningTotal.Visible = false; runT = false; }
            else
            { grpRunningTotal.Visible = true; runT = true; }
        }
        bool CBar = false;
        private void btnSecondaryTab5_Click(object sender, EventArgs e)
        {
            if (CBar)
            { chkSearchCopyBarcodes.Visible = false; CBar = false; }
            else
            { chkSearchCopyBarcodes.Visible = true; CBar = true; }
        }
        frmAddBookCopies frmAddBookCopies;
        private void btnSecondaryTab6_Click(object sender, EventArgs e)
        {
            frmAddBookCopies= new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
        }

        private void pnlCheckOut_Paint(object sender, PaintEventArgs e)
        {

        }
        #region Navigation

        private Panel[] Panels;
        private Button[] MainTabs;
        private Button[] SubTabs;
        private void InitializePanels()
        {
            Panels = new Panel[]
            {
                pnlBackup,
                pnlBookDetails,
                pnlCheckIn,
                pnlCheckOut,
                pnlDelete,
                pnlMember,
                pnlReservation,
                pnlSatistics,
                pnlSearch,
                pnlSell,
                pnlSetting,
                pnlStaff
            };
        }
        private void InitializeMainTabs()
        {
            MainTabs = new Button[]
            {
                
            };
        }
        private void CloseAllPanels()
        {
            foreach (Panel panel in Panels)
            {
                panel.Visible = false;
            }
        }
        private void OpenBookTab()
        {
            CloseAllPanels();
            OpenSearchViewTab(Feature.Book);
        }
        private void OpenSearchViewTab(Feature feature) 
        {
            pnlSearch.Visible = true;
            switch (feature)
            {
                case Feature.Book:
                    searchedItemsLoader.ToBook();
                    break;
                case Feature.Member:

                    break;
                case Feature.Transaction:

                    break;
                case Feature.Staff:

                    break;

            }
        }


        enum Feature
        {
            Book = 0,
            Member = 1,
            Transaction = 2,
            Staff = 3
        }
        #endregion
    }
}
