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
using NEALibrarySystem.PanelHandlers;

namespace NEALibrarySystem
{
    public partial class FrmMainSystem : Form
    {
        public FrmMainSystem()
        {
            InitializeComponent();
            InitializePanels();
            InitializeTabs();
            _searchedItemsHandler = new SearchedItemsHandler(lsvSearchItems);
            NavigatorOpenBookTab();
        }

        public bool _isAdministrator;

        #region Navigator
        private Panel[][] _panels;
        private Button[] _mainTabs;
        private Button[] _subTabs;
        public DataLibrary.Feature _currentFeature;

        private SearchedItemsHandler _searchedItemsHandler;
        private BookCheckInHandler _bookCheckInHandler;
        private BookDetailsHandler _bookDetailsHandler;

        #region initialisation
        public void InitializePanels()
        {
            _panels = new Panel[][] 
            {
            new Panel[] { pnlCheckIn, pnlCheckOut, pnlSell, pnlReservation, pnlSearch, pnlBookDetails, pnlDelete },
            new Panel[] { pnlSearch, pnlMember, pnlDelete },
            new Panel[] { pnlSearch },
            new Panel[] { pnlSearch, pnlStaff },
            new Panel[] { pnlStatistics },
            new Panel[] { pnlBackup },
            new Panel[] { pnlSetting }
            };

            InitialiseCheckIn();
            InitialiseBookDetails();
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
        private void InitialiseBookDetails()
        {
            BookDetailsObjects bookDetailsObjects = new BookDetailsObjects()
            {
                CopyDetails = lsvBookCopyDetails,
                InStock = txtBooksInStock,
                Reserved = txtBooksReserved,
                Loaned = txtBookLoaned,

                Title = txtBookTitle,
                SeriesTitle = txtBookSeriesTitle,
                SeriesNumber = txtBookSeriesNumber,
                ISBN = txtBookISBN,
                MediaType = txtBookMediaType,
                Author = txtBookAuthor,
                Publisher = txtBookPublisher,
                Genres = txtBookGenres,
                Themes = txtBookThemes,
                Description = txtBookDescription,
                Price = txtBookPrice,
            };
            _bookDetailsHandler = new BookDetailsHandler(bookDetailsObjects);
        }
        #endregion
        #region opening panels and tabs
        private void NavigatorCloseAllPanels()
        {
            foreach (Panel[] panelArr in _panels)
            {
                foreach (Panel panel in panelArr)
                {
                    panel.Visible = false;
                }
            }
        }
        private void NavigatorOpenSearchViewTab()
        {
            pnlSearch.Visible = true;
            switch (_currentFeature)
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
        private void NavigatorOpenBookTab()
        {
            _currentFeature = DataLibrary.Feature.Book;

            string[] bookTabs =
            {
                "Check In",
                "Check Out",
                "Sell",
                "Create Reservation",
                "Search Books",
                "Create New Book",
                "Remove Books"
            };
            NavigatorSetSubTabNames(bookTabs);

            NavigatorCloseAllPanels();
            NavigatorOpenSearchViewTab();
        }
        private void NavigatorOpenMemberTab()
        {
            _currentFeature = DataLibrary.Feature.Member;

            string[] memberTabs =
            {
                "Search Members",
                "Add Member",
                "Delete Member"
            };
            NavigatorSetSubTabNames(memberTabs);

            NavigatorCloseAllPanels();
            NavigatorOpenSearchViewTab();
        }
        #endregion
        #region sub tab handling
        private void NavigatorSetSubTabNames(string[] tabs)
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
        private void NavigatorSubTab(int index)
        {
            NavigatorCloseAllPanels();
            int feature = 0;
            switch (_currentFeature)
            {
                case DataLibrary.Feature.Book:
                    feature = 0;
                    break;
                case DataLibrary.Feature.Member:
                    feature = 1;
                    break;
                case DataLibrary.Feature.Transaction: 
                    feature = 2; 
                    break;
                case DataLibrary.Feature.Staff: 
                    feature = 3; 
                    break;
                case DataLibrary.Feature.Statistics: 
                    feature = 4;
                    break;
                case DataLibrary.Feature.Backups: 
                    feature = 5; 
                    break;
                case DataLibrary.Feature.Settings: 
                    feature = 6; 
                    break;
            }
            _panels[feature][index].Visible = true;
        }
        #endregion
        private void ChangeIcon()
        {
            switch (_currentFeature)
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
            NavigatorOpenBookTab();
        }
        private void btnMembers_Click(object sender, EventArgs e)
        {
            //DataLibrary.LoadTestData1();
            NavigatorOpenMemberTab();
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
        private void btnSubTab1_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(0);
        }
        private void btnSubTab2_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(1);
        }
        private void btnSubTab3_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(2);
        }
        private void btnSubTab4_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(3);
        }
        private void btnSubTab5_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(4);
        }
        private void btnSubTab6_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(5);
        }
        private void btnSubTab7_Click(object sender, EventArgs e)
        {
            NavigatorSubTab(6);
        }
        #endregion
        #region panel visibility
        private void pnlCheckOut_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCheckOut.Visible)
            {
                
            }
        }
        private void pnlCheckIn_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCheckIn.Visible)
            {
                _bookCheckInHandler.LoadCheckInPanel();
            }
        }
        private void pnlSell_VisibleChanged(object sender, EventArgs e)
        {
            
        }
        private void pnlBookDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBookDetails.Visible)
            {
                _bookDetailsHandler.loadBookDetails();
            }
        }
        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlMember_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlStatistics_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlDelete_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlBackup_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlSetting_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlStaff_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlReservation_VisibleChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private void pnlCheckOut_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnBookAddCopies_Click(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
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
        #endregion
        /*
         *  OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

            }
         */
    }
}
