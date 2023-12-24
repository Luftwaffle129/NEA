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
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using System.Drawing.Text;
using NEALibrarySystem.Panel_Handlers.CirculationDetails;
using NEALibrarySystem.ListViewHandlers.SearchList;

namespace NEALibrarySystem
{
    public partial class FrmMainSystem : Form
    {
        public static FrmMainSystem Main;

        public FrmMainSystem()
        {
            Main = this;
            InitializeComponent();
            _testData.GenerateTestParameters();
            InitializePanels();
            InitializeTabs();
            NavigatorOpenBookTab();
            FormBorderStyle = FormBorderStyle.Sizable;
        }

        public bool _isAdministrator;

        #region Navigator
        private Panel[][] _panels;
        private Button[] _mainTabs;
        private Button[] _subTabs;
        public DataLibrary.Feature CurrentFeature = DataLibrary.Feature.None;
        public DataLibrary.SearchFeature SearchFeature = DataLibrary.SearchFeature.Book;

        private SearchHandler _searchHandler;
        private LoanHandler _loanHandler;
        private ReturnHandler _returnHandler;
        private SellHandler _sellHandler;
        private ReserveHandler _reserveHandler;
        private BookDetailsHandler _bookDetailsHandler;
        private CirculationDetailsHandler _circulationDetailsHandler;
        private MemberDetailsHandler _memberDetailsHandler;
        private DeleteHandler _deleteHandler;

        TestData _testData = new TestData();

        private Book _selectedBook; // Used to stored the selected book when opening the book details panel
        private CirculationCopy _selectedCircCopy;
        private Member _selectedMember;
        #region initialisation
        public void InitializePanels()
        {
            _panels = new Panel[][] 
            {
            new Panel[] { pnlLoan, pnlReturn, pnlSell, pnlReserve},
            new Panel[] { pnlSearch, pnlBookDetails, pnlSearch },
            new Panel[] { pnlSearch, pnlMemberDetails, pnlDelete },
            new Panel[] { pnlSearch, pnlCirculationDetails },
            new Panel[] { pnlSearch, pnlStaff },
            new Panel[] { pnlStatistics },
            new Panel[] { pnlBackup },
            new Panel[] { pnlSetting }
            };

            InitialiseSearchTab();
            InitialiseLoan();
            InitialiseReturn();
            InitialiseSell();
            InitialiseReserve();
            InitialiseBookDetails();
            InitialiseCirculationDetails();
            InitialiseMemberDetails();
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
        private void InitialiseSearchTab()
        {
            SearchObjects searchObjects = new SearchObjects()
            {
                SearchField = cmbSearchField,
                Search = txtSearchBox,
                Filter1Field = cmbFilter1,
                Filter1 = txtFilter1,
                Filter2Field = cmbFilter2,
                Filter2 = txtFilter2,
                ItemViewer = lsvSearchItems,
                Delete = btnSearchDelete
            };
            _searchHandler = new SearchHandler(searchObjects);
        }
        private void InitialiseLoan()
        {
            CirculationObjectHandler circulationObjectHandler = new CirculationObjectHandler
            (
                txtLoanMemberBarcode,
                txtLoanMemberName,
                txtLoanLoans,
                txtLoanOverdue,
                txtLoanLateFees,
                txtLoanEnterBarcode,
                lsvLoanSelectedBooks,
                false
            );
            _loanHandler = new LoanHandler(circulationObjectHandler, dtpLoanReturnDate);
        }
        private void InitialiseReturn()
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
                true
            );
            _returnHandler = new ReturnHandler(circulationObjectHandler);
        }
        private void InitialiseSell()
        {
            CirculationObjectHandler circulationObjectHandler = new CirculationObjectHandler
            (
                txtSellMemberBarcode,
                txtSellMemberName,
                txtSellLoans,
                txtSellOverdue,
                txtSellLateFees,
                txtSellEnterBarcode,
                lsvSellSelectedBooks,
                true
            );
            _sellHandler = new SellHandler(circulationObjectHandler, txtSellPrice);
        }
        private void InitialiseReserve()
        {
            CirculationObjectHandler circulationObjectHandler = new CirculationObjectHandler
            (
                txtReserveMemberBarcode,
                txtReserveMemberName,
                txtReserveLoans,
                txtReserveOverdue,
                txtReserveLateFees,
                txtReserveEnterBarcode,
                lsvReserveSelectedBooks,
                false
            );
            _reserveHandler = new ReserveHandler(circulationObjectHandler, dtpReservePickUpByDate);
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
                Isbn = txtBookISBN,
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
        private void InitialiseCirculationDetails()
        {
            CirculationDetailsObjects circulationDetailsObjects = new CirculationDetailsObjects()
            {
                Id = txtCircDetailsId,
                Type = txtCircDetailsType,
                MemberBarcode = txtCircDetailsMemberBarcode,
                MemberName = txtCircDetailsMemberName,
                Date = txtCircDetailsDate,
                DueDate = dtpCircDetailsDueDate,
                BookCopy = lsvCircDetailsBookData
            };
            _circulationDetailsHandler = new CirculationDetailsHandler(circulationDetailsObjects);
        }
        private void InitialiseMemberDetails()
        {
            MemberDetailsObjects memberDetailsObjects = new MemberDetailsObjects()
            {
                Barcode = txtMemberBarcode,
                FirstName = txtMemberFirstName,
                Surname = txtMemberSurname,
                DateOfBirth = dtpMemberDateOfBirth,
                MemberType = cmbMemberType,
                LinkedMembers = txtMemberLinkedMembers,
                EmailAddress = txtMemberEmailAddress,
                PhoneNumber = txtMemberPhoneNumber,
                Address1 = txtMemberAddress1,
                Address2 = txtMemberAddress2,
                TownCity = txtMemberTownCity,
                County = txtMemberCounty,
                PostCode = txtMemberPostcode,
                JoinDate = txtMemberJoinDate,
                Circulations = lsvMemberCirculations,
                LateFees = txtMemberLateFees
            };
            _memberDetailsHandler = new MemberDetailsHandler(memberDetailsObjects);
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
        private void NavigatorOpenCirculationTab()
        {
            CurrentFeature = DataLibrary.Feature.Circulation;

            string[] tabs =
            {
                "Loan",
                "Return",
                "Sell",
                "Reserve",
            };
            NavigatorSetSubTabNames(tabs);

            NavigatorCloseAllPanels();
            pnlLoan.Visible = true;
        }
        private void NavigatorOpenBookTab()
        {
            CurrentFeature = DataLibrary.Feature.Book;
            SearchFeature = DataLibrary.SearchFeature.Book;
            string[] tabs =
            {
                "View Books",
                "Create New Book",
                "View Circulated Books"
            };
            NavigatorSetSubTabNames(tabs);

            NavigatorOpenSearchViewTab();
        }
        private void NavigatorOpenMemberTab()
        {
            CurrentFeature = DataLibrary.Feature.Member;
            SearchFeature = DataLibrary.SearchFeature.Member;
            string[] tabs =
            {
                "View Members",
                "Add Member",
                "Delete Member"
            };
            NavigatorSetSubTabNames(tabs);

            NavigatorCloseAllPanels();
            NavigatorOpenSearchViewTab();
        }
        private void NavigatorOpenDetails(ListViewItem item)
        {
            switch (SearchFeature)
            {
                case DataLibrary.SearchFeature.Book:
                    int index = SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString);
                    if (index != -1)
                    {
                        _selectedBook = DataLibrary.Isbns[index].Reference;
                        NavigatorCloseAllPanels();
                        pnlBookDetails.Visible = true;
                        NavigatorResetSelectedItems();
                    }
                    else
                        MessageBox.Show("Book not found");
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    index = SearchAndSort.Binary(DataLibrary.CirculationIds, Convert.ToInt32(item.SubItems[0].Text), SearchAndSort.RefClassAndInteger);
                    if (index != -1)
                    {
                        _selectedCircCopy = DataLibrary.CirculationIds[index].Reference;
                        NavigatorCloseAllPanels();
                        pnlCirculationDetails.Visible = true;
                        NavigatorResetSelectedItems();
                    }
                    else
                        MessageBox.Show("Circulation copy not found");
                    break;
                case DataLibrary.SearchFeature.Member:
                    index = SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString);
                    if (index != -1)
                    {
                        _selectedMember = DataLibrary.MemberBarcodes[index].Reference;
                        NavigatorCloseAllPanels();
                        pnlMemberDetails.Visible = true;
                        NavigatorResetSelectedItems();
                    }
                    else
                        MessageBox.Show("Member not found");
                    break;

            }
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
        private void NavigatorResetSelectedItems()
        {
            _selectedBook = null;
            _selectedCircCopy = null;
            _selectedMember = null;
        }
        private void NavigatorSubTab(int index)
        {
            NavigatorCloseAllPanels();
            
            /*
            int feature = 0;
            switch (CurrentFeature)
            {
                case DataLibrary.Feature.Circulation:
                    feature = 0;
                    break;
                case DataLibrary.Feature.Book:
                    feature = 1;
                    break;
                case DataLibrary.Feature.Member:
                    feature = 2;
                    break;
                case DataLibrary.Feature.Transaction: 
                    feature = 3; 
                    break;
                case DataLibrary.Feature.Staff: 
                    feature = 4; 
                    break;
                case DataLibrary.Feature.Statistics: 
                    feature = 5;
                    break;
                case DataLibrary.Feature.Backups: 
                    feature = 6; 
                    break;
                case DataLibrary.Feature.Settings: 
                    feature = 7; 
                    break;
            }
            */
            // set the correct search feature if opening a search tab
            if (CurrentFeature == DataLibrary.Feature.Member)
                SearchFeature = DataLibrary.SearchFeature.Member;
            else if (CurrentFeature == DataLibrary.Feature.Staff)
                SearchFeature = DataLibrary.SearchFeature.Staff;
            else if (CurrentFeature == DataLibrary.Feature.Book && index == 0)
                SearchFeature = DataLibrary.SearchFeature.Book;
            else if (CurrentFeature == DataLibrary.Feature.Book && index == 2)
                SearchFeature = DataLibrary.SearchFeature.Circulation;
            //open the panel
            _panels[(int)CurrentFeature][index].Visible = true;
            NavigatorResetSelectedItems();
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
        #region main tabs
        private void btnCirculation_Click(object sender, EventArgs e)
        {
            NavigatorOpenCirculationTab();
        }
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
            /*
            if (this.FormBorderStyle == FormBorderStyle.None)
                this.FormBorderStyle = FormBorderStyle.Sizable;
            else
                this.FormBorderStyle = FormBorderStyle.None;
            */
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
                _loanHandler.Load();
        }
        private void pnlCheckIn_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlReturn.Visible)
                _returnHandler.Load();
        }
        private void pnlSell_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSell.Visible == true)
                _sellHandler.Load();
        }
        private void pnlReserve_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlReserve.Visible == true)
                _reserveHandler.Load();
        }
        private void pnlBookDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBookDetails.Visible)
                _bookDetailsHandler.Load(_selectedBook);
        }
        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSearch.Visible)
                _searchHandler.SetUpSearchTab();
        }
        private void pnlMember_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlMemberDetails.Visible)
                _memberDetailsHandler.Load(_selectedMember);
        }
        private void pnlStatistics_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlDelete_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDelete.Visible)
                _deleteHandler.Load(lsvSearchItems.CheckedItems);
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
        private void pnlCirculationDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCirculationDetails.Visible == true)
                _circulationDetailsHandler.Load(_selectedCircCopy);
        }
        #endregion
        #region objects
        #region main form
        private void frmMainSystem_Load(object sender, EventArgs e)
        {
            FileHandler.CreateDataDirectory();
            FileHandler.DataFilesExist();
            FileHandler.Load.All();
        }
        private void FrmMainSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileHandler.Save.All();
            frmLogIn.Main.Visible = true;
        }
        public void DisplayProcessMessage(string message)
        {
            lblMessageOutput.Text = message;
        }
        private void pctIcon_Click(object sender, EventArgs e)
        {
            _testData.GenerateTestData();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
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
        #region circulation details
        private void btnCircDetailsSave_Click(object sender, EventArgs e)
        {
            _circulationDetailsHandler.Save();
        }
        private void btnCircDetailsBack_Click(object sender, EventArgs e)
        {
            _circulationDetailsHandler.Cancel();
        }
        #endregion
        #region member details
        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            _memberDetailsHandler.Save();
        }
        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            _memberDetailsHandler.Cancel();
        }
        #endregion
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
        private void txtLoanEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _loanHandler.CirculationManager.AddBookCopy();
            }
        }
        private void btnLoanDelete_Click(object sender, EventArgs e)
        {
            _loanHandler.CirculationManager.DeleteCheckedBookCopies();
        }
        private void txtLoanMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _loanHandler.CirculationManager.UpdateMemberDetails();
        }
        #endregion
        #region return handler
        private void txtReturnMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _returnHandler.MemberBarcodeUpdated();
        }
        private void txtReturnEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _returnHandler.CirculationManager.AddBookCopy();
            }
        }
        private void btnReturnDelete_Click(object sender, EventArgs e)
        {
            _returnHandler.CirculationManager.DeleteCheckedBookCopies();
        }
        private void btnReturnSave_Click(object sender, EventArgs e)
        {
            _returnHandler.Save();
        }
        private void btnReturnCancel_Click(object sender, EventArgs e)
        {
            _returnHandler.Load();
        }
        #endregion
        #region sell handler
        private void btnSellDelete_Click(object sender, EventArgs e)
        {
            _sellHandler.BookCopiesRemoved();
        }
        private void btnSellSave_Click(object sender, EventArgs e)
        {
            _sellHandler.Save();
        }
        private void txtSellEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _sellHandler.BookCopyAdded();
            }
        }
        private void btnSellCancel_Click(object sender, EventArgs e)
        {
            _sellHandler.Load();
        }
        private void txtSellMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _sellHandler.MemberBarcodeUpdated();
        }
        #endregion
        #region reserve handler
        private void txtReserveMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _reserveHandler.CirculationManager.UpdateMemberDetails();
        }
        private void txtReserveEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _reserveHandler.CirculationManager.AddBookCopy();
            }
        }
        private void btnReserveDelete_Click(object sender, EventArgs e)
        {
            _reserveHandler.CirculationManager.DeleteCheckedBookCopies();
        }
        private void btnReserveSave_Click(object sender, EventArgs e)
        {
            _reserveHandler.Save();
        }
        private void btnReserveCancel_Click(object sender, EventArgs e)
        {
            _reserveHandler.Load();
        }
        #endregion
        #region search handler
        private void lsvSearchItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsvSearchItems.Items.Count > 0)
            {
                int index = 0;
                bool foundItem = false;
                do
                {
                    if (lsvSearchItems.GetItemRect(index).Contains(e.Location))
                    {
                        NavigatorOpenDetails(lsvSearchItems.Items[index]);
                        foundItem = true;
                    }
                } while (++index < lsvSearchItems.Items.Count && !foundItem);
            }
        }
        private void btnSearchDelete_Click(object sender, EventArgs e)
        {
            _searchHandler.Delete();
        }
        private void lsvSearchItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _searchHandler.SortListView(e.Column);
        }
        private void btnSearchSearch_Click(object sender, EventArgs e)
        {
            _searchHandler.Search();
        }
        private void btnSearchResetFilters_Click(object sender, EventArgs e)
        {
            _searchHandler.ResetSearchInputs();
        }
        #endregion
        #endregion
        #endregion
        private void txtReturnLoans_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlLoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }


        private void txtRserveEnterBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellEnterBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReturnEnterBarcode_TextChanged(object sender, EventArgs e)
        {

        }
        private void pnlCheckOut_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void lsvSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtTransactionPrice_TextChanged(object sender, EventArgs e)
        {

        }
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
