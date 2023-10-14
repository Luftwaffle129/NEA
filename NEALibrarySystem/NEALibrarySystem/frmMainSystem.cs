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
            InitializeTabs();
            SetSubTabs(new string[0]);
            searchedItemsLoader = new SearchedItemsLoader(lsvSearchItems);
        }

        public bool isAdministrator;

        #region Navigation
        private Panel[] Panels;
        private Button[] MainTabs;
        private Button[] SubTabs;
        #region initialisation
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
        private void InitializeTabs()
        {
            MainTabs = new Button[]
            {
                btnBooks,
                btnMembers,
                btnTransactions,
                btnStaff,
                btnStatistics,
                btnBackups,
                btnSettings,
                btnLogOut
            };
            SubTabs = new Button[]
            {
                btnSubTab1,
                btnSubTab2,
                btnSubTab3,
                btnSubTab4,
                btnSubTab5,
                btnSubTab6,
                btnSubTab7
            };
        }
        #endregion
        #region opening panels and tabs
        private void CloseAllPanels()
        {
            foreach (Panel panel in Panels)
            {
                panel.Visible = false;
            }
        }
        private void OpenSearchViewTab(Feature feature)
        {
            pnlSearch.Visible = true;
            switch (feature)
            {
                case Feature.Book:
                    searchedItemsLoader.ToBook();
                    pnlSearch.Visible = true;
                    break;
                case Feature.Member:

                    break;
                case Feature.Transaction:

                    break;
                case Feature.Staff:

                    break;

            }
        }
        private void OpenBookTab()
        {
            CloseAllPanels();
            OpenSearchViewTab(Feature.Book);
            string[] bookTabs =
{
                "Check In",
                "Check Out",
                "Create reservation",
                "Sell books",
                "Search Books",
                "Search Reservations",
                "Add Book",
                "Remove Books"
            };
            SetSubTabNames(bookTabs);
        }
        #endregion
        #region sub tab handling
        private void SetSubTabNames(string[] tabs)
        {
            for (int i = 0; i < SubTabs.Length; i++)
            {
                if (i < tabs.Length)
                {
                    SubTabs[i].Visible = true;
                    SubTabs[i].Text = tabs[i];
                }
                else
                {
                    SubTabs[i].Visible = false;
                }
            }
        }
        private void RedirectorSubTab1(Feature currentFeature)
        {
            switch (currentFeature)
            {
                case Feature.Book:
                    CloseAllPanels();
                    pnlCheckIn.Visible = true;
                    // init check in panel
                    break;
            }
        }
        private void RedirectorSubTab2(Feature currentFeature)
        {
            switch (currentFeature)
            {
                case Feature.Book:

                    break;
            }
        }
        #endregion
        enum Feature
        {
            Book = 0,
            Member = 1,
            Transaction = 2,
            Staff = 3,
            Statistics = 4,
            Backups = 5,
            Settings = 6,
        }
        #endregion

        public void DisplayProcessMessage(string message)
        {
            lblMessageOutput.Text = message;
        }
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
        private void btnBookAddCopies_Click(object sender, EventArgs e)
        {

        }
    }
}
