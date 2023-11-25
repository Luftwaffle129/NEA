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
using NEALibrarySystem.SearchList;
using NEALibrarySystem.Panel_Handlers.BookCheckIn;
using NEALibrarySystem.PanelHandlers;
using NEALibrarySystem.ListViewHandlers.SelectedItems;

namespace NEALibrarySystem
{
    public partial class FrmMainSystem : Form
    {
        public static FrmMainSystem Main;

        public FrmMainSystem()
        {
            Main = this;
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
        public DataLibrary.Feature CurrentFeature = DataLibrary.Feature.None;

        private SearchedItemsHandler _searchedItemsHandler;
        private BookLoanHandler _loanHandler;
        private BookDetailsHandler _bookDetailsHandler;
        private DeleteHandler _deleteHandler;

        #region initialisation
        public void InitializePanels()
        {
            _panels = new Panel[][] 
            {
            new Panel[] { pnlReturn, pnlLoan, pnlSell, pnlReservation, pnlSearch, pnlBookDetails, pnlDelete },
            new Panel[] { pnlSearch, pnlMemberDetails, pnlDelete },
            new Panel[] { pnlSearch, pnlCirculationDetails },
            new Panel[] { pnlSearch, pnlStaff },
            new Panel[] { pnlStatistics },
            new Panel[] { pnlBackup },
            new Panel[] { pnlSetting }
            };

            InitialiseCheckIn();
            InitialiseBookDetails();
            InitialiseDelete();
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
            CirculationObjectHandler circulationObjectHandler = new CirculationObjectHandler
            (
                txtReturnMemberBarcode,
                txtReturnMemberName,
                txtReturnLoans,
                txtReturnOverdue,
                txtReturnLateFees,
                txtReturnEnterBarcode,
                lsvReturnSelectedBooks,
                false
            );
            _loanHandler = new BookLoanHandler(circulationObjectHandler, dtpLoanReturnDate);
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
        private void InitialiseDelete()
        {
            _deleteHandler = new DeleteHandler(lsvDelete);
        }
        #endregion
        #region opening panels and tabs
        public void NavigatorCloseAllPanels()
        {
            foreach (Panel[] panelArr in _panels)
            {
                foreach (Panel panel in panelArr)
                {
                    panel.Visible = false;
                }
            }
        }
        public void NavigatorOpenSearchViewTab()
        {
            NavigatorCloseAllPanels();
            pnlSearch.Visible = true;

        }
        private void NavigatorOpenBookTab()
        {
            CurrentFeature = DataLibrary.Feature.Book;

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

            NavigatorOpenSearchViewTab();
        }
        private void NavigatorOpenMemberTab()
        {
            CurrentFeature = DataLibrary.Feature.Member;

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
            switch (CurrentFeature)
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
            switch (CurrentFeature)
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
        private void pnlLoan_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlLoan.Visible)
            {
                
            }
        }
        private void pnlCheckIn_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlReturn.Visible)
            {
                _loanHandler.Load();
            }
        }
        private void pnlSell_VisibleChanged(object sender, EventArgs e)
        {
            
        }
        private void pnlBookDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBookDetails.Visible)
            {
                _bookDetailsHandler.Load();
            }
        }
        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSearch.Visible)
            {
                _searchedItemsHandler.SetUpSearchTab();
            }
        }
        private void pnlMember_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlStatistics_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlDelete_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDelete.Visible)
            {
                _deleteHandler.Load(lsvSearchItems.CheckedItems);
            }
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
            TestData testData = new TestData();
            testData.GenerateTestData();
        }
        private void lsvSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region objects
        #region book details
        private void btnBookSave_Click(object sender, EventArgs e)
        {
            _bookDetailsHandler.Save();
        }
        private void btnBookCancel_Click(object sender, EventArgs e)
        {
            _bookDetailsHandler.Cancel();
        }
        private void btnBookAddCopies_Click(object sender, EventArgs e)
        {
            _bookDetailsHandler.AddBookCopies();
        }
        private void btnBookDeleteCopies_Click(object sender, EventArgs e)
        {
            _bookDetailsHandler.DeleteBookCopies();
        }
        #endregion

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            throw new Exception("womp womp");
        }
        #region delete handler

        private void btnDeleteDelete_Click(object sender, EventArgs e)
        {
            _deleteHandler.Delete();
        }
        private void btnDeleteCancel_Click(object sender, EventArgs e)
        {
            _deleteHandler.ClosePanel();
        }
        #endregion
        #region loan handler
        private void btnLoanSave_Click(object sender, EventArgs e)
        {
            _loanHandler.Save();
        }

        private void btnLoanCancel_Click(object sender, EventArgs e)
        {
            _loanHandler.Load();
        }

        private void btnLoanDelete_Click(object sender, EventArgs e)
        {
            _loanHandler.CirculationManager.DeleteCheckedListView();
        }
        private void txtLoanMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _loanHandler.CirculationManager.UpdateMemberDetails();
        }
        #endregion

        #endregion

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
