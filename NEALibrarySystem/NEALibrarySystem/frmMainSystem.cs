using System;
using System.Windows.Forms;
using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.SearchList;
using NEALibrarySystem.Panel_Handlers.BookCheckIn;
using NEALibrarySystem.PanelHandlers;
using NEALibrarySystem.ListViewHandlers.CirculatedBooks;
using NEALibrarySystem.Panel_Handlers.CirculationDetails;
using NEALibrarySystem.ListViewHandlers.SearchList;
using NEALibrarySystem.Panel_Handlers.StaffHandler;
using NEALibrarySystem.Panel_Handlers.StaffDetails;
using NEALibrarySystem.Panel_Handlers.BackupHandler;

namespace NEALibrarySystem
{
    public partial class FrmMainSystem : Form
    {
        public static FrmMainSystem Main;

        public FrmMainSystem(Staff staff)
        {
            Main = this;
            InitializeComponent();
            _testData.GenerateTestParameters();
            InitializePanels();
            InitializeSubTabs();
            NavigatorOpenBookTab();
            FormBorderStyle = FormBorderStyle.Sizable;
            DataLibrary.CurrentUser = staff;

            // hide buttons that are not available to the user's access level
            if (DataLibrary.CurrentUser.IsAdministrator == false)
            {
                btnSettings.Visible = false;
                btnBackups.Visible = false;
                btnStaffSave.Visible = false;
            }
            else
            {
                btnSettings.Visible = true;
                btnBackups.Visible = true;
                btnStaffSave.Visible = true;
            }
        }
        #region Navigator
        private Panel[][] _panels; // a 2-dimensional jagged array containing references to the panels. Represents the layout of the system
        private Button[] _subTabs; // array containing references to the sub tab buttons
        public DataLibrary.Feature CurrentFeature = DataLibrary.Feature.None; // stores the current feature in use
        public DataLibrary.SearchFeature SearchFeature = DataLibrary.SearchFeature.Book; // stores the current search feature in use

        // declares handlers used to control each panel
        private SearchHandler _searchHandler;
        private LoanHandler _loanHandler;
        private ReturnHandler _returnHandler;
        private SellHandler _sellHandler;
        private ReserveHandler _reserveHandler;
        private BookDetailsHandler _bookDetailsHandler;
        private CirculationDetailsHandler _circulationDetailsHandler;
        private MemberDetailsHandler _memberDetailsHandler;
        private StaffDetailsHandler _StaffDetailsHandler;
        private BackupHandler _backupHandler;
        // declares class used for generating test data
        TestData _testData = new TestData();
        // declares variables used to store a selected record. Used in opening the details panel of the selected item in the search list view to store the selecetd record
        private Book _selectedBook;
        private CirculationCopy _selectedCircCopy;
        private Member _selectedMember;
        private Staff _selectedStaff;

        #region initialisation
        /// <summary>
        /// Initialises all features and their panels
        /// initialises panel jagged array used for navigation
        /// </summary>
        public void InitializePanels()
        {
            _panels = new Panel[][] 
            {
                new Panel[] { pnlLoan, pnlReturn, pnlSell, pnlReserve},
                new Panel[] { pnlSearch, pnlBookDetails, pnlSearch },
                new Panel[] { pnlSearch, pnlMemberDetails },
                new Panel[] { pnlSearch, pnlStaffDetails },
                new Panel[] { pnlBackup },
                new Panel[] { pnlSettings },
                new Panel[] { pnlCirculationDetails } // not accessed directy by navigtion buttons but needed to close it
            };

            InitialiseSearchTab();
            InitialiseLoan();
            InitialiseReturn();
            InitialiseSell();
            InitialiseReserve();
            InitialiseBookDetails();
            InitialiseCirculationDetails();
            InitialiseMemberDetails();
            InitialiseStaffDetails();
            InitialiseBackup();
        }
        /// <summary>
        /// Populates the sub tab array with the sub tab button references
        /// </summary>
        private void InitializeSubTabs()
        {
            _subTabs = new Button[]
            {
                btnSubTab1,
                btnSubTab2,
                btnSubTab3,
                btnSubTab4,
            };
        }
        /// <summary>
        /// Initialises the search panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the loan panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the return panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the sell panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the reserve panel handler with the necessary objects and parameters
        /// </summary>
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
        /// <summary>
        /// Initialises the book details panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the circulation details panel handler with the necessary objects
        /// </summary>
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
        /// <summary>
        /// Initialises the member detail panel handler with the necessary objects
        /// </summary>
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

        private void InitialiseStaffDetails() 
        {
            StaffDetailsObjects staffDetailsObjects = new StaffDetailsObjects()
            {
                FirstName = txtStaffFirstName,
                Surname = txtStaffSurname,
                Username = txtStaffUsername,
                Password = txtStaffPassword,
                Email = txtStaffEmailAddress,
                AccessLevel = cmbStaffAccessLevel
            };
            _StaffDetailsHandler = new StaffDetailsHandler(staffDetailsObjects);
        }

        private void InitialiseBackup() 
        {
            _backupHandler = new BackupHandler(lblLastBackupDate);
        }
        #endregion
        #region opening panels and tabs
        /// <summary>
        /// Closes all feature panels
        /// </summary>
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
        /// <summary>
        /// Opens the search panel
        /// </summary>
        public void NavigatorOpenSearchViewTab()
        {
            NavigatorCloseAllPanels();
            pnlSearch.Visible = true;
        }
        /// <summary>
        /// Opens the circulation feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the loan panel
        /// </summary>
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
            NavigatorSetupSubTabs(tabs);

            NavigatorCloseAllPanels();
            pnlLoan.Visible = true;
        }
        /// <summary>
        /// Opens the book feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the search panel
        /// </summary>
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
            NavigatorSetupSubTabs(tabs);

            NavigatorOpenSearchViewTab();
        }
        /// <summary>
        /// Opens the member feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the search panel
        /// </summary>
        private void NavigatorOpenMemberTab()
        {
            CurrentFeature = DataLibrary.Feature.Member;
            SearchFeature = DataLibrary.SearchFeature.Member;
            string[] tabs =
            {
                "View Members",
                "Add Member"
            };
            NavigatorSetupSubTabs(tabs);

            NavigatorCloseAllPanels();
            NavigatorOpenSearchViewTab();
        }
        /// <summary>
        /// Opens the staff feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the search panel
        /// </summary>
        private void NavigatorOpenStaffTab()
        {
            CurrentFeature = DataLibrary.Feature.Staff;
            SearchFeature = DataLibrary.SearchFeature.Staff;
            string[] tabs =
            {
                "View Staff",
                "Add Staff"
            };
            NavigatorSetupSubTabs(tabs);

            if (!DataLibrary.CurrentUser.IsAdministrator)
            {
                btnSubTab2.Visible = false;
            }

            NavigatorCloseAllPanels();
            pnlSearch.Visible = true;
        }
        /// <summary>
        /// Opens the backup feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the search panel
        /// </summary>
        private void NavigatorOpenBackupTab()
        {
            CurrentFeature = DataLibrary.Feature.Backups;
            string[] tabs = new string[0];
            NavigatorSetupSubTabs(tabs);

            NavigatorCloseAllPanels();
            pnlBackup.Visible = true;
        }
        /// <summary>
        /// Opens the settings feature
        /// - sets the sub tabs to the correct text
        /// - closes all panels
        /// - opens the settings panel
        /// </summary>
        private void NavigatorOpenSettingsTab()
        {
            CurrentFeature = DataLibrary.Feature.Settings;
            string[] tabs = new string[0];
            NavigatorSetupSubTabs(tabs);

            NavigatorCloseAllPanels();
            pnlSettings.Visible = true;
        }

        /// <summary>
        /// Opens the details panel
        /// process:
        /// - finds the current search feature
        /// - gets the index of the selected record in the list view from the datastructure it is stored
        /// - closes all panels
        /// - opens the correct details panel
        /// - resets the selected items
        /// 
        /// - if selected item was not found, report the item as not found
        /// </summary>
        private void NavigatorOpenDetails(ListViewItem item)
        {
            // finds the current feature
            switch (SearchFeature)
            {
                case DataLibrary.SearchFeature.Book:
                    // gets index of the selected record within the datastructure it is stored
                    int index = SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString);
                    if (index != -1) // if not found
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
                    // gets index of the selected record within the datastructure it is stored
                    index = SearchAndSort.Binary(DataLibrary.CirculationIds, Convert.ToInt32(item.SubItems[0].Text), SearchAndSort.RefClassAndInteger);
                    if (index != -1) // if not found
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
                    // gets index of the selected record within the datastructure it is stored
                    index = SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString);
                    if (index != -1) // if not found
                    {
                        _selectedMember = DataLibrary.MemberBarcodes[index].Reference;
                        NavigatorCloseAllPanels();
                        pnlMemberDetails.Visible = true;
                        NavigatorResetSelectedItems();
                    }
                    else
                        MessageBox.Show("Member not found");
                    break;
                case DataLibrary.SearchFeature.Staff:
                    // gets index of the selected record within the datastructure it is stored
                    index = SearchAndSort.Binary(DataLibrary.StaffUsernames, item.SubItems[2].Text, SearchAndSort.RefClassAndString);
                    if (index != -1) // if not found
                    {
                        _selectedStaff = DataLibrary.StaffUsernames[index].Reference;
                        NavigatorCloseAllPanels();
                        pnlStaffDetails.Visible = true;
                        NavigatorResetSelectedItems();
                    }
                    else
                        MessageBox.Show("Staff not found");
                    break;

            }
        }
        #endregion
        #region sub tab handling
        /// <summary>
        /// Displays the necessary sub tabs containing the correct texts
        /// </summary>
        /// <param name="tabs">Array of text that the tabs will contain</param>
        private void NavigatorSetupSubTabs(string[] tabs)
        {
            btnSubTab2.Visible = true; // display sub tab
            // for the length of all sub tabs
            for (int i = 0; i < _subTabs.Length; i++)
            {
                // if the sub tab button is reassigned new text
                if (i < tabs.Length)
                {
                    // set button visible with the new text
                    _subTabs[i].Visible = true;
                    _subTabs[i].Text = tabs[i];
                }
                else
                {
                    // hide the button
                    _subTabs[i].Visible = false;
                }
            }
        }
        /// <summary>
        /// Empties the selected item variables used when opening detail panels
        /// </summary>
        private void NavigatorResetSelectedItems()
        {
            _selectedBook = null;
            _selectedCircCopy = null;
            _selectedMember = null;
            _selectedStaff = null;
        }
        /// <summary>
        /// Opens the corrcet sub tab panel from the button clicked in the top navigation panel
        /// </summary>
        /// <param name="index">button index</param>
        private void NavigatorOpenSubTab(int index)
        {
            NavigatorCloseAllPanels();      
            // set the correct search feature if opening a search tab
            if (CurrentFeature == DataLibrary.Feature.Member)
                SearchFeature = DataLibrary.SearchFeature.Member;
            else if (CurrentFeature == DataLibrary.Feature.Staff)
                SearchFeature = DataLibrary.SearchFeature.Staff;
            else if (CurrentFeature == DataLibrary.Feature.Book && index == 0) // if opening the search panel for books
                SearchFeature = DataLibrary.SearchFeature.Book;
            else if (CurrentFeature == DataLibrary.Feature.Book && index == 2) // if opening the search panel for circulations
                SearchFeature = DataLibrary.SearchFeature.Circulation;
            //open the panel
            _panels[(int)CurrentFeature][index].Visible = true;
        }
        #endregion
        /// <summary>
        /// Used to change the picture box icon to match the current feature
        /// </summary>
        private void ChangeIcon()
        {

        }
        #endregion
        #region events
        #region main form
        private void frmMainSystem_Load(object sender, EventArgs e)
        {
            NavigatorOpenBookTab();
        }
        private void FrmMainSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileHandler.Save.All();
            frmLogIn.Main.Visible = true;
        }
        private void pctIcon_Click(object sender, EventArgs e)
        {
            _testData.GenerateTestData();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DataLibrary.CurrentUser = null;
            this.Close();
        }
        #region main tabs
        // events when buttons in the left-most panel are clicked
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
            NavigatorOpenMemberTab();
        }
        private void btnStaff_Click(object sender, EventArgs e)
        {
            NavigatorOpenStaffTab();
        }
        private void btnBackups_Click(object sender, EventArgs e)
        {
            NavigatorOpenBackupTab();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            NavigatorOpenSettingsTab();
        }
        #endregion
        #region sub tabs
        // methods to open a panel from the sub tabs
        private void btnSubTab1_Click(object sender, EventArgs e)
        {
            NavigatorOpenSubTab(0);
        }
        private void btnSubTab2_Click(object sender, EventArgs e)
        {
            NavigatorOpenSubTab(1);
        }
        private void btnSubTab3_Click(object sender, EventArgs e)
        {
            NavigatorOpenSubTab(2);
        }
        private void btnSubTab4_Click(object sender, EventArgs e)
        {
            NavigatorOpenSubTab(3);
        }
        #endregion
        #endregion
        #region panel visibility
        // events for when panels visibility are changed. Used when changing panels to run their class's load method
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
        private void pnlMemberDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlMemberDetails.Visible)
                _memberDetailsHandler.Load(_selectedMember);
        }
        private void pnlStatistics_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlDelete_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void pnlBackup_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBackup.Visible)
                _backupHandler.UpdateLastBackupDate();
        }
        private void pnlSetting_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void pnlStaff_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlStaffDetails.Visible)
                _StaffDetailsHandler.Load(_selectedStaff);
        }
        private void pnlCirculationDetails_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCirculationDetails.Visible == true)
                _circulationDetailsHandler.Load(_selectedCircCopy);
        }
        #endregion
        #region book details panel
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
        #region circulation details panel
        private void btnCircDetailsSave_Click(object sender, EventArgs e)
        {
            _circulationDetailsHandler.Save();
        }
        private void btnCircDetailsBack_Click(object sender, EventArgs e)
        {
            _circulationDetailsHandler.Cancel();
        }
        private void btnCircDetailsDelete_Click(object sender, EventArgs e)
        {
            _circulationDetailsHandler.Delete();
        }
        #endregion
        #region member details panel
        private void btnMemberSave_Click(object sender, EventArgs e)
        {
            _memberDetailsHandler.Save();
        }
        private void btnMemberCancel_Click(object sender, EventArgs e)
        {
            _memberDetailsHandler.Cancel();
        }
        #endregion
        #region loan handler panel
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
            if (e.KeyCode == Keys.Enter) // if the user presses the enter key
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
            _loanHandler.MemberBarcodeUpdated();
        }
        #endregion
        #region return handler panel
        private void txtReturnMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _returnHandler.MemberBarcodeUpdated();
        }
        private void txtReturnEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // if the user presses the enter key
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
        #region sell handler panel
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
            if (e.KeyCode == Keys.Enter) // if the user presses the enter key
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
        #region reserve handler panel
        private void txtReserveMemberBarcode_TextChanged(object sender, EventArgs e)
        {
            _reserveHandler.MemberBarcodeUpdated();
        }
        private void txtReserveEnterBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // if the user presses the enter key
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
        #region search handler panel
        private void lsvSearchItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsvSearchItems.Items.Count > 0) // serach list view is not empty
            {
                // uses a linear search to find the item that was double clicked on
                int index = 0;
                bool foundItem = false;
                do
                {
                    if (lsvSearchItems.GetItemRect(index).Contains(e.Location))
                    {
                        NavigatorOpenDetails(lsvSearchItems.Items[index]); // opens the details of the item clicked on
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
        #region staff details panel
        private void btnStaffPasswordVisibility_MouseUp(object sender, MouseEventArgs e)
        {
            txtStaffPassword.UseSystemPasswordChar = true;
        }
        private void btnStaffPasswordVisibility_MouseDown(object sender, MouseEventArgs e)
        {
            txtStaffPassword.UseSystemPasswordChar = false;
        }
        private void btnStaffSave_Click(object sender, EventArgs e)
        {
            _StaffDetailsHandler.Save();
        }

        private void btnStaffCancel_Click(object sender, EventArgs e)
        {
            _StaffDetailsHandler.Cancel();
        }

        #endregion
        #region backup panel
        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            _backupHandler.SaveBackup();
        }
        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            _backupHandler.LoadBackup();
        }
        #endregion
        private void pnlMainTabs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void grpSettingsCirculation_Enter(object sender, EventArgs e)
        {

        }

        private void txtSettingsGmailPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numSettingsBarcodeMember_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSettingsGmailKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
