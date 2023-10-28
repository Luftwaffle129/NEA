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
using NEALibrarySystem.Panel_Handlers.BookCheckIn;

namespace NEALibrarySystem
{
    public partial class frmMainSystem : Form
    {
        public frmMainSystem()
        {
            InitializeComponent();
            InitializePanels();
            InitializeTabs();
            _searchedItemsHandler = new SearchedItemsHandler(lsvSearchItems);
        }

        public bool isAdministrator;

        #region object manager
        private Panel[] _panels;
        private Button[] _mainTabs;
        private Button[] _subTabs;
        private DataLibrary.Feature _currentFeature;

        private SearchedItemsHandler _searchedItemsHandler;
        private BookCheckInHandler _bookCheckInHandler;

        #region initialisation
        private void InitializePanels()
        {
            _panels = new Panel[]
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
            _mainTabs = new Button[]
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
            _subTabs = new Button[]
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
        private void InitialiseCheckIn()
        {
            BookCheckInObjects bookCheckInObjects = new BookCheckInObjects()
            {
                MemberBarcode = txtCheckInMemberBarcode,
                MemberName = txtCheckInMemberName,
                EnterBookBarcodes = txtCheckInEnterBarcode,
                Loans = txtCheckInLoans,
                Overdue = txtCheckInOverdue,
                LateFees = txtCheckInLateFees,
                SelectedBooks = lsvCheckInSelectedBooks
            };
            _bookCheckInHandler = new BookCheckInHandler(bookCheckInObjects);
        }
        #endregion
        #region opening panels and tabs
        private void CloseAllPanels()
        {
            foreach (Panel panel in _panels)
            {
                panel.Visible = false;
            }
        }
        private void OpenSearchViewTab(DataLibrary.Feature feature)
        {
            pnlSearch.Visible = true;
            switch (feature)
            {
                case DataLibrary.Feature.Book:
                    _searchedItemsHandler.ToBook();
                    pnlSearch.Visible = true;
                    break;
                case DataLibrary.Feature.Member:

                    break;
                case DataLibrary.Feature.Transaction:

                    break;
                case DataLibrary.Feature.Staff:

                    break;

            }
        }
        private void OpenBookTab()
        {
            CloseAllPanels();
            _currentFeature = DataLibrary.Feature.Book;
            OpenSearchViewTab(_currentFeature);
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
            for (int i = 0; i < _subTabs.Length; i++)
            {
                if (i < tabs.Length)
                {
                    _subTabs[i].Visible = true;
                    _subTabs[i].Text = tabs[i];
                }
                else
                {
                    _subTabs[i].Visible = false;
                }
            }
        }
        private void RedirectorSubTab1()
        {
            switch (_currentFeature)
            {
                case DataLibrary.Feature.Book:
                    CloseAllPanels();
                    pnlCheckIn.Visible = true;
                    _bookCheckInHandler.LoadCheckInPanel();
                    break;
            }
        }
        private void RedirectorSubTab2()
        {
            switch (_currentFeature)
            {
                case DataLibrary.Feature.Book:

                    break;
            }
        }
        #endregion
        private void ChangeIcon()
        {
            switch(_currentFeature)
            {
                case DataLibrary.Feature.Book:
                    //set pic icon
                    break;
            }
        }
        #endregion
        #region events
        private void frmMainSystem_Load(object sender, EventArgs e)
        {
            bool leftPanelVisible = true;
            bool topPanelVisible = true;
            DataLibrary.LoadAllFiles();

            //overdue books
        }
        #region main tabs
        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenBookTab();
        }
        private void btnMembers_Click(object sender, EventArgs e)
        {
            DataLibrary.LoadTestData1();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.None;
        }
        #endregion
        #region sub tabs
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
            frmDesigner = new frmDesigner();
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
            frmAddBookCopies = new frmAddBookCopies();
            frmAddBookCopies.ShowDialog();
        }
        #endregion
        public void DisplayProcessMessage(string message)
        {
            lblMessageOutput.Text = message;
        }
        frmConfirmation frmConfirmation;
        private void pctIcon_Click(object sender, EventArgs e)
        {
            frmConfirmation = new frmConfirmation();
            frmConfirmation.ShowDialog();
        }

        private void pnlCheckOut_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnBookAddCopies_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
