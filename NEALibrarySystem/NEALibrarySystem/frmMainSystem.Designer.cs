namespace NEALibrarySystem
{
    partial class frmMainSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnBackups = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnSubTab1 = new System.Windows.Forms.Button();
            this.btnSubTab2 = new System.Windows.Forms.Button();
            this.btnSubTab3 = new System.Windows.Forms.Button();
            this.btnSubTab4 = new System.Windows.Forms.Button();
            this.btnSubTab5 = new System.Windows.Forms.Button();
            this.btnSubTab6 = new System.Windows.Forms.Button();
            this.btnSubTab7 = new System.Windows.Forms.Button();
            this.lblMessageOutput = new System.Windows.Forms.Label();
            this.pnlReservation = new System.Windows.Forms.Panel();
            this.dtpReservationPickUpBy = new System.Windows.Forms.DateTimePicker();
            this.btnReservationCancel = new System.Windows.Forms.Button();
            this.btnReservationSave = new System.Windows.Forms.Button();
            this.lblReservationSetDueDate = new System.Windows.Forms.Label();
            this.txtReservationLateBooks = new System.Windows.Forms.TextBox();
            this.lblReservationOverdueBooks = new System.Windows.Forms.Label();
            this.lsvReservationSelectedBooks = new System.Windows.Forms.ListView();
            this.txtReservationSelectedBooks = new System.Windows.Forms.Label();
            this.txtReservationCurrentMemberCheckOuts = new System.Windows.Forms.TextBox();
            this.lblReservationCurrentMemberCheckOuts = new System.Windows.Forms.Label();
            this.txtReservationMemberBarcode = new System.Windows.Forms.TextBox();
            this.lblReservationMemberBarcode = new System.Windows.Forms.Label();
            this.txtReservationMemberName = new System.Windows.Forms.TextBox();
            this.lblReservationMemberName = new System.Windows.Forms.Label();
            this.pnlMember = new System.Windows.Forms.Panel();
            this.grpMemberBookLinks = new System.Windows.Forms.GroupBox();
            this.lsvMemberBookLinks = new System.Windows.Forms.ListView();
            this.txtMemberJoinDate = new System.Windows.Forms.TextBox();
            this.lblMemberJoinDate = new System.Windows.Forms.Label();
            this.txtMemberPostcode = new System.Windows.Forms.TextBox();
            this.txtMemberAddressLine4 = new System.Windows.Forms.TextBox();
            this.txtMemberAddressLine5 = new System.Windows.Forms.TextBox();
            this.lblMemberPostcode = new System.Windows.Forms.Label();
            this.lblMemberAssociatedMemberBarcodes = new System.Windows.Forms.Label();
            this.txtMemberAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblMemberAddressLine3 = new System.Windows.Forms.Label();
            this.btnMemberCancel = new System.Windows.Forms.Button();
            this.txtMemberBarcode = new System.Windows.Forms.TextBox();
            this.btnMemberSave = new System.Windows.Forms.Button();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.txtMemberAssociatedMemberBarcodes = new System.Windows.Forms.TextBox();
            this.txtMemberCustomerType = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblMemberAddressLine2 = new System.Windows.Forms.Label();
            this.txtMemberDateOfBirth = new System.Windows.Forms.TextBox();
            this.lblMemberAddressLine5 = new System.Windows.Forms.Label();
            this.txtMemberAddressLine3 = new System.Windows.Forms.TextBox();
            this.txtMemberAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblMemberSurname = new System.Windows.Forms.Label();
            this.lblMemberAddressLine4 = new System.Windows.Forms.Label();
            this.lblMemberAddressLine1 = new System.Windows.Forms.Label();
            this.txtMemberEmailAddress = new System.Windows.Forms.TextBox();
            this.txtMemberPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblMemberDateOfBirth = new System.Windows.Forms.Label();
            this.lblMemberCustomerType = new System.Windows.Forms.Label();
            this.lblMemberEmailAddress = new System.Windows.Forms.Label();
            this.lblMemberBarcode = new System.Windows.Forms.Label();
            this.txtMemberSurname = new System.Windows.Forms.TextBox();
            this.lblMemberPhoneNumber = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.chkSearchCopyBarcodes = new System.Windows.Forms.CheckBox();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.cmbSearchField = new System.Windows.Forms.ComboBox();
            this.grpRunningTotal = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRunninGTotalOutput = new System.Windows.Forms.TextBox();
            this.lblRunningTotal = new System.Windows.Forms.Label();
            this.btnSetRunningTotalDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRunningTotalDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRunningTotalTime = new System.Windows.Forms.TextBox();
            this.btnResetRunningTotal = new System.Windows.Forms.Button();
            this.lsvSearchItems = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SeriesTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtFilter2 = new System.Windows.Forms.TextBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.txtFilter1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnresetFilters = new System.Windows.Forms.Button();
            this.lblFilter1 = new System.Windows.Forms.Label();
            this.lblFilter2 = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.cmbFilter2 = new System.Windows.Forms.ComboBox();
            this.cmbFilter1 = new System.Windows.Forms.ComboBox();
            this.pnlStaff = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStaffMemberRecord = new System.Windows.Forms.Button();
            this.cmbStaffAccessLevel = new System.Windows.Forms.ComboBox();
            this.btnStaffPasswordVisibility = new System.Windows.Forms.Button();
            this.lblStaffAccessLevel = new System.Windows.Forms.Label();
            this.txtStaffPassword = new System.Windows.Forms.TextBox();
            this.lblStaffPassword = new System.Windows.Forms.Label();
            this.lblStaffMemberBarcode = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.btnStaffCancel = new System.Windows.Forms.Button();
            this.btnStaffSave = new System.Windows.Forms.Button();
            this.pnlCheckOut = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOutSetDueDate = new System.Windows.Forms.Label();
            this.txtCheckOutLateBooks = new System.Windows.Forms.TextBox();
            this.lblCheckOutOverdueBooks = new System.Windows.Forms.Label();
            this.lsvCheckOutSelectedBooks = new System.Windows.Forms.ListView();
            this.txtCheckOutSelectedBooks = new System.Windows.Forms.Label();
            this.txtCheckOutCurrentMemberCheckOuts = new System.Windows.Forms.TextBox();
            this.lblCheckOutCurrentMemberCheckOuts = new System.Windows.Forms.Label();
            this.txtCheckOutMemberBarcode = new System.Windows.Forms.TextBox();
            this.lblCheckOutMemberBarcode = new System.Windows.Forms.Label();
            this.txtCheckOutMemberName = new System.Windows.Forms.TextBox();
            this.lblCheckOutMemberName = new System.Windows.Forms.Label();
            this.btnCheckOutSave = new System.Windows.Forms.Button();
            this.btnCheckOutCancel = new System.Windows.Forms.Button();
            this.pnlDelete = new System.Windows.Forms.Panel();
            this.lsvDelete = new System.Windows.Forms.ListView();
            this.lblDeleteSelectedRecords = new System.Windows.Forms.Label();
            this.lblDeleteTitle = new System.Windows.Forms.Label();
            this.btnDeleteCancel = new System.Windows.Forms.Button();
            this.btnDeleteDelete = new System.Windows.Forms.Button();
            this.pnlSell = new System.Windows.Forms.Panel();
            this.txtCheckOutPrice = new System.Windows.Forms.TextBox();
            this.lblCheckOutPrice = new System.Windows.Forms.Label();
            this.txtSellOverdueBooks = new System.Windows.Forms.TextBox();
            this.lblSellBooksOverdueBooks = new System.Windows.Forms.Label();
            this.lsvSellSelectedBooks = new System.Windows.Forms.ListView();
            this.lblSellSelectedBooks = new System.Windows.Forms.Label();
            this.txtSellLoans = new System.Windows.Forms.TextBox();
            this.lblSellLoans = new System.Windows.Forms.Label();
            this.txtSellMemberBarcode = new System.Windows.Forms.TextBox();
            this.lblSellMemberBarcode = new System.Windows.Forms.Label();
            this.txtSellMemberName = new System.Windows.Forms.TextBox();
            this.lblSellMemberName = new System.Windows.Forms.Label();
            this.btnSellCancel = new System.Windows.Forms.Button();
            this.btnSellSave = new System.Windows.Forms.Button();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.lblDefaultSettings = new System.Windows.Forms.Label();
            this.txtSettingDefault = new System.Windows.Forms.TextBox();
            this.cmbSettingDefault2 = new System.Windows.Forms.ComboBox();
            this.cmbSettingDefault3 = new System.Windows.Forms.ComboBox();
            this.cmbSettingDefault1 = new System.Windows.Forms.ComboBox();
            this.btnGmailKeyIsVisible = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.lblSettingGmailKey = new System.Windows.Forms.Label();
            this.btnSettingCancel = new System.Windows.Forms.Button();
            this.btnSettingSave = new System.Windows.Forms.Button();
            this.pnlCheckIn = new System.Windows.Forms.Panel();
            this.lblCheckInEnterBarcode = new System.Windows.Forms.Label();
            this.txtCheckInEnterBarcode = new System.Windows.Forms.TextBox();
            this.lblCheckInLateFees = new System.Windows.Forms.Label();
            this.txtCheckInOverdue = new System.Windows.Forms.TextBox();
            this.lblCheckInOverdue = new System.Windows.Forms.Label();
            this.lsvCheckInSelectedBooks = new System.Windows.Forms.ListView();
            this.lblCheckInSelectedBooks = new System.Windows.Forms.Label();
            this.txtCheckInLoans = new System.Windows.Forms.TextBox();
            this.lblCheckInLoans = new System.Windows.Forms.Label();
            this.txtCheckInMemberBarcode = new System.Windows.Forms.TextBox();
            this.lblCheckInMemberBarcode = new System.Windows.Forms.Label();
            this.txtCheckInMemberName = new System.Windows.Forms.TextBox();
            this.lblCheckInMemberName = new System.Windows.Forms.Label();
            this.btnCheckInCancel = new System.Windows.Forms.Button();
            this.txtCheckInLateFees = new System.Windows.Forms.TextBox();
            this.btnCheckInSave = new System.Windows.Forms.Button();
            this.pnlBookDetails = new System.Windows.Forms.Panel();
            this.btnBookSave = new System.Windows.Forms.Button();
            this.btnBookCancel = new System.Windows.Forms.Button();
            this.grpBooksBookStatus = new System.Windows.Forms.GroupBox();
            this.txtLoaned = new System.Windows.Forms.TextBox();
            this.lblBooksInStock = new System.Windows.Forms.Label();
            this.txtBooksReserved = new System.Windows.Forms.TextBox();
            this.txtBooksInStock = new System.Windows.Forms.TextBox();
            this.lblBooksLoaned = new System.Windows.Forms.Label();
            this.lblBooksReserved = new System.Windows.Forms.Label();
            this.grpBookDetails = new System.Windows.Forms.GroupBox();
            this.txtBookPrice = new System.Windows.Forms.TextBox();
            this.txtBookDescription = new System.Windows.Forms.TextBox();
            this.txtBookThemes = new System.Windows.Forms.TextBox();
            this.txtBookGenres = new System.Windows.Forms.TextBox();
            this.txtBookPublisher = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookMediaType = new System.Windows.Forms.TextBox();
            this.txtBookISBN = new System.Windows.Forms.TextBox();
            this.txtBookSeriesNumber = new System.Windows.Forms.TextBox();
            this.txtBookSeriesTitle = new System.Windows.Forms.TextBox();
            this.lblBookPrice = new System.Windows.Forms.Label();
            this.lblBookDescription = new System.Windows.Forms.Label();
            this.lblBookThemes = new System.Windows.Forms.Label();
            this.lblBookGenres = new System.Windows.Forms.Label();
            this.lblBookPublisher = new System.Windows.Forms.Label();
            this.lblBookSeriesNumber = new System.Windows.Forms.Label();
            this.lblBookTitleSeries = new System.Windows.Forms.Label();
            this.lblBookMediaType = new System.Windows.Forms.Label();
            this.lblBookAuthor = new System.Windows.Forms.Label();
            this.lblBookISBN = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.grpBookCopyDetails = new System.Windows.Forms.GroupBox();
            this.btnBookDeleteCopies = new System.Windows.Forms.Button();
            this.btnBookAddCopies = new System.Windows.Forms.Button();
            this.lsvBookCopyDetails = new System.Windows.Forms.ListView();
            this.pnlSatistics = new System.Windows.Forms.Panel();
            this.chtStatisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpStatisticsInputs = new System.Windows.Forms.GroupBox();
            this.chkStatisticsTimeAsVariable = new System.Windows.Forms.CheckBox();
            this.cmbStatisticsTimeInterval = new System.Windows.Forms.ComboBox();
            this.cmbStatisticsTotalOrChange = new System.Windows.Forms.ComboBox();
            this.btnStatisticsEnter = new System.Windows.Forms.Button();
            this.lblStatisticsVariables = new System.Windows.Forms.Label();
            this.txtStatisticsVariables = new System.Windows.Forms.TextBox();
            this.lblStatisticsVariableType = new System.Windows.Forms.Label();
            this.cmbStatisticsVariableType = new System.Windows.Forms.ComboBox();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.lblLastBackupDate = new System.Windows.Forms.Label();
            this.btnRestoreBackup = new System.Windows.Forms.Button();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.pctIcon = new System.Windows.Forms.PictureBox();
            this.pnlMainTabs = new System.Windows.Forms.Panel();
            this.pnlSubTabs = new System.Windows.Forms.Panel();
            this.pnlReservation.SuspendLayout();
            this.pnlMember.SuspendLayout();
            this.grpMemberBookLinks.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.grpRunningTotal.SuspendLayout();
            this.pnlStaff.SuspendLayout();
            this.pnlCheckOut.SuspendLayout();
            this.pnlDelete.SuspendLayout();
            this.pnlSell.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.pnlCheckIn.SuspendLayout();
            this.pnlBookDetails.SuspendLayout();
            this.grpBooksBookStatus.SuspendLayout();
            this.grpBookDetails.SuspendLayout();
            this.grpBookCopyDetails.SuspendLayout();
            this.pnlSatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtStatisticsChart)).BeginInit();
            this.grpStatisticsInputs.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            this.pnlMainTabs.SuspendLayout();
            this.pnlSubTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBooks
            // 
            this.btnBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBooks.BackColor = System.Drawing.Color.Silver;
            this.btnBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooks.Location = new System.Drawing.Point(0, 150);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(150, 75);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "BOOKS";
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMembers.BackColor = System.Drawing.Color.Silver;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.Location = new System.Drawing.Point(0, 225);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(150, 75);
            this.btnMembers.TabIndex = 2;
            this.btnMembers.Text = "MEMBERS";
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransactions.BackColor = System.Drawing.Color.Silver;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.Location = new System.Drawing.Point(0, 300);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(150, 75);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "SALE HISTORY";
            this.btnTransactions.UseVisualStyleBackColor = false;
            // 
            // btnStaff
            // 
            this.btnStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaff.BackColor = System.Drawing.Color.Silver;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.Location = new System.Drawing.Point(0, 375);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(150, 75);
            this.btnStaff.TabIndex = 4;
            this.btnStaff.Text = "STAFF";
            this.btnStaff.UseVisualStyleBackColor = false;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatistics.BackColor = System.Drawing.Color.Silver;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(0, 450);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(150, 75);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "STATISTICS";
            this.btnStatistics.UseVisualStyleBackColor = false;
            // 
            // btnBackups
            // 
            this.btnBackups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackups.BackColor = System.Drawing.Color.Silver;
            this.btnBackups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackups.Location = new System.Drawing.Point(0, 525);
            this.btnBackups.Name = "btnBackups";
            this.btnBackups.Size = new System.Drawing.Size(150, 75);
            this.btnBackups.TabIndex = 6;
            this.btnBackups.Text = "BACKUPS";
            this.btnBackups.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Silver;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(0, 600);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(150, 75);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.BackColor = System.Drawing.Color.Silver;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(0, 1005);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(150, 75);
            this.btnLogOut.TabIndex = 9;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            // 
            // btnSubTab1
            // 
            this.btnSubTab1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab1.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab1.Location = new System.Drawing.Point(0, 0);
            this.btnSubTab1.Name = "btnSubTab1";
            this.btnSubTab1.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab1.TabIndex = 10;
            this.btnSubTab1.Text = "Option 1";
            this.btnSubTab1.UseVisualStyleBackColor = false;
            this.btnSubTab1.Click += new System.EventHandler(this.btnSecondaryTab1_Click);
            // 
            // btnSubTab2
            // 
            this.btnSubTab2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab2.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab2.Location = new System.Drawing.Point(150, 0);
            this.btnSubTab2.Name = "btnSubTab2";
            this.btnSubTab2.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab2.TabIndex = 11;
            this.btnSubTab2.Text = "Option 2";
            this.btnSubTab2.UseVisualStyleBackColor = false;
            this.btnSubTab2.Click += new System.EventHandler(this.btnSecondaryTab2_Click);
            // 
            // btnSubTab3
            // 
            this.btnSubTab3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab3.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab3.Location = new System.Drawing.Point(300, 0);
            this.btnSubTab3.Name = "btnSubTab3";
            this.btnSubTab3.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab3.TabIndex = 12;
            this.btnSubTab3.Text = "Option 3";
            this.btnSubTab3.UseVisualStyleBackColor = false;
            this.btnSubTab3.Click += new System.EventHandler(this.btnSecondaryTab3_Click);
            // 
            // btnSubTab4
            // 
            this.btnSubTab4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab4.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab4.Location = new System.Drawing.Point(450, 0);
            this.btnSubTab4.Name = "btnSubTab4";
            this.btnSubTab4.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab4.TabIndex = 13;
            this.btnSubTab4.Text = "Option 4";
            this.btnSubTab4.UseVisualStyleBackColor = false;
            this.btnSubTab4.Click += new System.EventHandler(this.btnSecondaryTab4_Click);
            // 
            // btnSubTab5
            // 
            this.btnSubTab5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab5.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab5.Location = new System.Drawing.Point(600, 0);
            this.btnSubTab5.Name = "btnSubTab5";
            this.btnSubTab5.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab5.TabIndex = 14;
            this.btnSubTab5.Text = "Option 5";
            this.btnSubTab5.UseVisualStyleBackColor = false;
            this.btnSubTab5.Click += new System.EventHandler(this.btnSecondaryTab5_Click);
            // 
            // btnSubTab6
            // 
            this.btnSubTab6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab6.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab6.Location = new System.Drawing.Point(750, 0);
            this.btnSubTab6.Name = "btnSubTab6";
            this.btnSubTab6.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab6.TabIndex = 15;
            this.btnSubTab6.Text = "Option 6";
            this.btnSubTab6.UseVisualStyleBackColor = false;
            this.btnSubTab6.Click += new System.EventHandler(this.btnSecondaryTab6_Click);
            // 
            // btnSubTab7
            // 
            this.btnSubTab7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubTab7.BackColor = System.Drawing.Color.Silver;
            this.btnSubTab7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubTab7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubTab7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubTab7.Location = new System.Drawing.Point(900, 0);
            this.btnSubTab7.Name = "btnSubTab7";
            this.btnSubTab7.Size = new System.Drawing.Size(150, 100);
            this.btnSubTab7.TabIndex = 16;
            this.btnSubTab7.Text = "Option 7";
            this.btnSubTab7.UseVisualStyleBackColor = false;
            // 
            // lblMessageOutput
            // 
            this.lblMessageOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageOutput.BackColor = System.Drawing.Color.White;
            this.lblMessageOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessageOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageOutput.Location = new System.Drawing.Point(1570, 0);
            this.lblMessageOutput.Name = "lblMessageOutput";
            this.lblMessageOutput.Size = new System.Drawing.Size(200, 100);
            this.lblMessageOutput.TabIndex = 43;
            this.lblMessageOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlReservation
            // 
            this.pnlReservation.Controls.Add(this.dtpReservationPickUpBy);
            this.pnlReservation.Controls.Add(this.btnReservationCancel);
            this.pnlReservation.Controls.Add(this.btnReservationSave);
            this.pnlReservation.Controls.Add(this.lblReservationSetDueDate);
            this.pnlReservation.Controls.Add(this.txtReservationLateBooks);
            this.pnlReservation.Controls.Add(this.lblReservationOverdueBooks);
            this.pnlReservation.Controls.Add(this.lsvReservationSelectedBooks);
            this.pnlReservation.Controls.Add(this.txtReservationSelectedBooks);
            this.pnlReservation.Controls.Add(this.txtReservationCurrentMemberCheckOuts);
            this.pnlReservation.Controls.Add(this.lblReservationCurrentMemberCheckOuts);
            this.pnlReservation.Controls.Add(this.txtReservationMemberBarcode);
            this.pnlReservation.Controls.Add(this.lblReservationMemberBarcode);
            this.pnlReservation.Controls.Add(this.txtReservationMemberName);
            this.pnlReservation.Controls.Add(this.lblReservationMemberName);
            this.pnlReservation.Location = new System.Drawing.Point(150, 100);
            this.pnlReservation.Name = "pnlReservation";
            this.pnlReservation.Size = new System.Drawing.Size(1770, 980);
            this.pnlReservation.TabIndex = 53;
            // 
            // dtpReservationPickUpBy
            // 
            this.dtpReservationPickUpBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReservationPickUpBy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReservationPickUpBy.Location = new System.Drawing.Point(306, 277);
            this.dtpReservationPickUpBy.Name = "dtpReservationPickUpBy";
            this.dtpReservationPickUpBy.Size = new System.Drawing.Size(226, 38);
            this.dtpReservationPickUpBy.TabIndex = 15;
            this.dtpReservationPickUpBy.Value = new System.DateTime(2023, 6, 29, 0, 0, 0, 0);
            // 
            // btnReservationCancel
            // 
            this.btnReservationCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReservationCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservationCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservationCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnReservationCancel.Name = "btnReservationCancel";
            this.btnReservationCancel.Size = new System.Drawing.Size(120, 50);
            this.btnReservationCancel.TabIndex = 14;
            this.btnReservationCancel.Text = "Cancel";
            this.btnReservationCancel.UseVisualStyleBackColor = false;
            // 
            // btnReservationSave
            // 
            this.btnReservationSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReservationSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservationSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservationSave.Location = new System.Drawing.Point(1518, 924);
            this.btnReservationSave.Name = "btnReservationSave";
            this.btnReservationSave.Size = new System.Drawing.Size(120, 50);
            this.btnReservationSave.TabIndex = 13;
            this.btnReservationSave.Text = "Save";
            this.btnReservationSave.UseVisualStyleBackColor = false;
            // 
            // lblReservationSetDueDate
            // 
            this.lblReservationSetDueDate.AutoSize = true;
            this.lblReservationSetDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationSetDueDate.Location = new System.Drawing.Point(15, 283);
            this.lblReservationSetDueDate.Name = "lblReservationSetDueDate";
            this.lblReservationSetDueDate.Size = new System.Drawing.Size(155, 31);
            this.lblReservationSetDueDate.TabIndex = 10;
            this.lblReservationSetDueDate.Text = "Pick Up By:";
            // 
            // txtReservationLateBooks
            // 
            this.txtReservationLateBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationLateBooks.Location = new System.Drawing.Point(306, 217);
            this.txtReservationLateBooks.Name = "txtReservationLateBooks";
            this.txtReservationLateBooks.ReadOnly = true;
            this.txtReservationLateBooks.Size = new System.Drawing.Size(150, 38);
            this.txtReservationLateBooks.TabIndex = 9;
            // 
            // lblReservationOverdueBooks
            // 
            this.lblReservationOverdueBooks.AutoSize = true;
            this.lblReservationOverdueBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationOverdueBooks.Location = new System.Drawing.Point(15, 220);
            this.lblReservationOverdueBooks.Name = "lblReservationOverdueBooks";
            this.lblReservationOverdueBooks.Size = new System.Drawing.Size(209, 31);
            this.lblReservationOverdueBooks.TabIndex = 8;
            this.lblReservationOverdueBooks.Text = "Overdue Books:";
            // 
            // lsvReservationSelectedBooks
            // 
            this.lsvReservationSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvReservationSelectedBooks.HideSelection = false;
            this.lsvReservationSelectedBooks.Location = new System.Drawing.Point(306, 337);
            this.lsvReservationSelectedBooks.Name = "lsvReservationSelectedBooks";
            this.lsvReservationSelectedBooks.Size = new System.Drawing.Size(1179, 637);
            this.lsvReservationSelectedBooks.TabIndex = 7;
            this.lsvReservationSelectedBooks.UseCompatibleStateImageBehavior = false;
            // 
            // txtReservationSelectedBooks
            // 
            this.txtReservationSelectedBooks.AutoSize = true;
            this.txtReservationSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationSelectedBooks.Location = new System.Drawing.Point(15, 346);
            this.txtReservationSelectedBooks.Name = "txtReservationSelectedBooks";
            this.txtReservationSelectedBooks.Size = new System.Drawing.Size(211, 31);
            this.txtReservationSelectedBooks.TabIndex = 6;
            this.txtReservationSelectedBooks.Text = "Selected Books:";
            // 
            // txtReservationCurrentMemberCheckOuts
            // 
            this.txtReservationCurrentMemberCheckOuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationCurrentMemberCheckOuts.Location = new System.Drawing.Point(306, 157);
            this.txtReservationCurrentMemberCheckOuts.Name = "txtReservationCurrentMemberCheckOuts";
            this.txtReservationCurrentMemberCheckOuts.ReadOnly = true;
            this.txtReservationCurrentMemberCheckOuts.Size = new System.Drawing.Size(150, 38);
            this.txtReservationCurrentMemberCheckOuts.TabIndex = 5;
            // 
            // lblReservationCurrentMemberCheckOuts
            // 
            this.lblReservationCurrentMemberCheckOuts.AutoSize = true;
            this.lblReservationCurrentMemberCheckOuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationCurrentMemberCheckOuts.Location = new System.Drawing.Point(15, 160);
            this.lblReservationCurrentMemberCheckOuts.Name = "lblReservationCurrentMemberCheckOuts";
            this.lblReservationCurrentMemberCheckOuts.Size = new System.Drawing.Size(263, 31);
            this.lblReservationCurrentMemberCheckOuts.TabIndex = 4;
            this.lblReservationCurrentMemberCheckOuts.Text = "Current Check Outs:";
            // 
            // txtReservationMemberBarcode
            // 
            this.txtReservationMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationMemberBarcode.Location = new System.Drawing.Point(306, 37);
            this.txtReservationMemberBarcode.Name = "txtReservationMemberBarcode";
            this.txtReservationMemberBarcode.Size = new System.Drawing.Size(1179, 38);
            this.txtReservationMemberBarcode.TabIndex = 3;
            // 
            // lblReservationMemberBarcode
            // 
            this.lblReservationMemberBarcode.AutoSize = true;
            this.lblReservationMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationMemberBarcode.Location = new System.Drawing.Point(15, 40);
            this.lblReservationMemberBarcode.Name = "lblReservationMemberBarcode";
            this.lblReservationMemberBarcode.Size = new System.Drawing.Size(228, 31);
            this.lblReservationMemberBarcode.TabIndex = 2;
            this.lblReservationMemberBarcode.Text = "Member Barcode:";
            // 
            // txtReservationMemberName
            // 
            this.txtReservationMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservationMemberName.Location = new System.Drawing.Point(306, 97);
            this.txtReservationMemberName.Name = "txtReservationMemberName";
            this.txtReservationMemberName.Size = new System.Drawing.Size(1179, 38);
            this.txtReservationMemberName.TabIndex = 1;
            // 
            // lblReservationMemberName
            // 
            this.lblReservationMemberName.AutoSize = true;
            this.lblReservationMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationMemberName.Location = new System.Drawing.Point(15, 100);
            this.lblReservationMemberName.Name = "lblReservationMemberName";
            this.lblReservationMemberName.Size = new System.Drawing.Size(199, 31);
            this.lblReservationMemberName.TabIndex = 0;
            this.lblReservationMemberName.Text = "Member Name:";
            // 
            // pnlMember
            // 
            this.pnlMember.Controls.Add(this.grpMemberBookLinks);
            this.pnlMember.Controls.Add(this.txtMemberJoinDate);
            this.pnlMember.Controls.Add(this.lblMemberJoinDate);
            this.pnlMember.Controls.Add(this.txtMemberPostcode);
            this.pnlMember.Controls.Add(this.txtMemberAddressLine4);
            this.pnlMember.Controls.Add(this.txtMemberAddressLine5);
            this.pnlMember.Controls.Add(this.lblMemberPostcode);
            this.pnlMember.Controls.Add(this.lblMemberAssociatedMemberBarcodes);
            this.pnlMember.Controls.Add(this.txtMemberAddressLine1);
            this.pnlMember.Controls.Add(this.lblMemberAddressLine3);
            this.pnlMember.Controls.Add(this.btnMemberCancel);
            this.pnlMember.Controls.Add(this.txtMemberBarcode);
            this.pnlMember.Controls.Add(this.btnMemberSave);
            this.pnlMember.Controls.Add(this.lblMemberName);
            this.pnlMember.Controls.Add(this.txtMemberAssociatedMemberBarcodes);
            this.pnlMember.Controls.Add(this.txtMemberCustomerType);
            this.pnlMember.Controls.Add(this.txtMemberName);
            this.pnlMember.Controls.Add(this.lblMemberAddressLine2);
            this.pnlMember.Controls.Add(this.txtMemberDateOfBirth);
            this.pnlMember.Controls.Add(this.lblMemberAddressLine5);
            this.pnlMember.Controls.Add(this.txtMemberAddressLine3);
            this.pnlMember.Controls.Add(this.txtMemberAddressLine2);
            this.pnlMember.Controls.Add(this.lblMemberSurname);
            this.pnlMember.Controls.Add(this.lblMemberAddressLine4);
            this.pnlMember.Controls.Add(this.lblMemberAddressLine1);
            this.pnlMember.Controls.Add(this.txtMemberEmailAddress);
            this.pnlMember.Controls.Add(this.txtMemberPhoneNumber);
            this.pnlMember.Controls.Add(this.lblMemberDateOfBirth);
            this.pnlMember.Controls.Add(this.lblMemberCustomerType);
            this.pnlMember.Controls.Add(this.lblMemberEmailAddress);
            this.pnlMember.Controls.Add(this.lblMemberBarcode);
            this.pnlMember.Controls.Add(this.txtMemberSurname);
            this.pnlMember.Controls.Add(this.lblMemberPhoneNumber);
            this.pnlMember.Location = new System.Drawing.Point(150, 100);
            this.pnlMember.Name = "pnlMember";
            this.pnlMember.Size = new System.Drawing.Size(1770, 980);
            this.pnlMember.TabIndex = 54;
            // 
            // grpMemberBookLinks
            // 
            this.grpMemberBookLinks.Controls.Add(this.lsvMemberBookLinks);
            this.grpMemberBookLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMemberBookLinks.Location = new System.Drawing.Point(1437, 32);
            this.grpMemberBookLinks.Name = "grpMemberBookLinks";
            this.grpMemberBookLinks.Size = new System.Drawing.Size(327, 889);
            this.grpMemberBookLinks.TabIndex = 46;
            this.grpMemberBookLinks.TabStop = false;
            this.grpMemberBookLinks.Text = "Book links";
            // 
            // lsvMemberBookLinks
            // 
            this.lsvMemberBookLinks.HideSelection = false;
            this.lsvMemberBookLinks.Location = new System.Drawing.Point(6, 37);
            this.lsvMemberBookLinks.Name = "lsvMemberBookLinks";
            this.lsvMemberBookLinks.Size = new System.Drawing.Size(315, 848);
            this.lsvMemberBookLinks.TabIndex = 1;
            this.lsvMemberBookLinks.UseCompatibleStateImageBehavior = false;
            // 
            // txtMemberJoinDate
            // 
            this.txtMemberJoinDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberJoinDate.Location = new System.Drawing.Point(255, 883);
            this.txtMemberJoinDate.Name = "txtMemberJoinDate";
            this.txtMemberJoinDate.ReadOnly = true;
            this.txtMemberJoinDate.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberJoinDate.TabIndex = 74;
            // 
            // lblMemberJoinDate
            // 
            this.lblMemberJoinDate.AutoSize = true;
            this.lblMemberJoinDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberJoinDate.Location = new System.Drawing.Point(15, 886);
            this.lblMemberJoinDate.Name = "lblMemberJoinDate";
            this.lblMemberJoinDate.Size = new System.Drawing.Size(137, 31);
            this.lblMemberJoinDate.TabIndex = 73;
            this.lblMemberJoinDate.Text = "Join Date:";
            // 
            // txtMemberPostcode
            // 
            this.txtMemberPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberPostcode.Location = new System.Drawing.Point(255, 827);
            this.txtMemberPostcode.Name = "txtMemberPostcode";
            this.txtMemberPostcode.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberPostcode.TabIndex = 72;
            // 
            // txtMemberAddressLine4
            // 
            this.txtMemberAddressLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAddressLine4.Location = new System.Drawing.Point(255, 707);
            this.txtMemberAddressLine4.Name = "txtMemberAddressLine4";
            this.txtMemberAddressLine4.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAddressLine4.TabIndex = 70;
            // 
            // txtMemberAddressLine5
            // 
            this.txtMemberAddressLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAddressLine5.Location = new System.Drawing.Point(255, 767);
            this.txtMemberAddressLine5.Name = "txtMemberAddressLine5";
            this.txtMemberAddressLine5.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAddressLine5.TabIndex = 71;
            // 
            // lblMemberPostcode
            // 
            this.lblMemberPostcode.AutoSize = true;
            this.lblMemberPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberPostcode.Location = new System.Drawing.Point(15, 830);
            this.lblMemberPostcode.Name = "lblMemberPostcode";
            this.lblMemberPostcode.Size = new System.Drawing.Size(136, 31);
            this.lblMemberPostcode.TabIndex = 69;
            this.lblMemberPostcode.Text = "Postcode:";
            // 
            // lblMemberAssociatedMemberBarcodes
            // 
            this.lblMemberAssociatedMemberBarcodes.AutoSize = true;
            this.lblMemberAssociatedMemberBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAssociatedMemberBarcodes.Location = new System.Drawing.Point(15, 335);
            this.lblMemberAssociatedMemberBarcodes.Name = "lblMemberAssociatedMemberBarcodes";
            this.lblMemberAssociatedMemberBarcodes.Size = new System.Drawing.Size(239, 62);
            this.lblMemberAssociatedMemberBarcodes.TabIndex = 68;
            this.lblMemberAssociatedMemberBarcodes.Text = "Associated \r\nmember barcodes:";
            // 
            // txtMemberAddressLine1
            // 
            this.txtMemberAddressLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAddressLine1.Location = new System.Drawing.Point(255, 527);
            this.txtMemberAddressLine1.Name = "txtMemberAddressLine1";
            this.txtMemberAddressLine1.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAddressLine1.TabIndex = 67;
            // 
            // lblMemberAddressLine3
            // 
            this.lblMemberAddressLine3.AutoSize = true;
            this.lblMemberAddressLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAddressLine3.Location = new System.Drawing.Point(15, 650);
            this.lblMemberAddressLine3.Name = "lblMemberAddressLine3";
            this.lblMemberAddressLine3.Size = new System.Drawing.Size(193, 31);
            this.lblMemberAddressLine3.TabIndex = 66;
            this.lblMemberAddressLine3.Text = "Address line 3:";
            // 
            // btnMemberCancel
            // 
            this.btnMemberCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMemberCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnMemberCancel.Name = "btnMemberCancel";
            this.btnMemberCancel.Size = new System.Drawing.Size(120, 50);
            this.btnMemberCancel.TabIndex = 1;
            this.btnMemberCancel.Text = "Cancel";
            this.btnMemberCancel.UseVisualStyleBackColor = false;
            // 
            // txtMemberBarcode
            // 
            this.txtMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberBarcode.Location = new System.Drawing.Point(255, 47);
            this.txtMemberBarcode.Name = "txtMemberBarcode";
            this.txtMemberBarcode.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberBarcode.TabIndex = 65;
            // 
            // btnMemberSave
            // 
            this.btnMemberSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMemberSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberSave.Location = new System.Drawing.Point(1518, 924);
            this.btnMemberSave.Name = "btnMemberSave";
            this.btnMemberSave.Size = new System.Drawing.Size(120, 50);
            this.btnMemberSave.TabIndex = 0;
            this.btnMemberSave.Text = "Save";
            this.btnMemberSave.UseVisualStyleBackColor = false;
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberName.Location = new System.Drawing.Point(15, 110);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(94, 31);
            this.lblMemberName.TabIndex = 45;
            this.lblMemberName.Text = "Name:";
            // 
            // txtMemberAssociatedMemberBarcodes
            // 
            this.txtMemberAssociatedMemberBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAssociatedMemberBarcodes.Location = new System.Drawing.Point(255, 347);
            this.txtMemberAssociatedMemberBarcodes.Name = "txtMemberAssociatedMemberBarcodes";
            this.txtMemberAssociatedMemberBarcodes.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAssociatedMemberBarcodes.TabIndex = 63;
            // 
            // txtMemberCustomerType
            // 
            this.txtMemberCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberCustomerType.Location = new System.Drawing.Point(255, 287);
            this.txtMemberCustomerType.Name = "txtMemberCustomerType";
            this.txtMemberCustomerType.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberCustomerType.TabIndex = 62;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.Location = new System.Drawing.Point(255, 107);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberName.TabIndex = 44;
            // 
            // lblMemberAddressLine2
            // 
            this.lblMemberAddressLine2.AutoSize = true;
            this.lblMemberAddressLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAddressLine2.Location = new System.Drawing.Point(15, 590);
            this.lblMemberAddressLine2.Name = "lblMemberAddressLine2";
            this.lblMemberAddressLine2.Size = new System.Drawing.Size(193, 31);
            this.lblMemberAddressLine2.TabIndex = 46;
            this.lblMemberAddressLine2.Text = "Address line 2:";
            // 
            // txtMemberDateOfBirth
            // 
            this.txtMemberDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberDateOfBirth.Location = new System.Drawing.Point(255, 227);
            this.txtMemberDateOfBirth.Name = "txtMemberDateOfBirth";
            this.txtMemberDateOfBirth.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberDateOfBirth.TabIndex = 61;
            // 
            // lblMemberAddressLine5
            // 
            this.lblMemberAddressLine5.AutoSize = true;
            this.lblMemberAddressLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAddressLine5.Location = new System.Drawing.Point(15, 770);
            this.lblMemberAddressLine5.Name = "lblMemberAddressLine5";
            this.lblMemberAddressLine5.Size = new System.Drawing.Size(193, 31);
            this.lblMemberAddressLine5.TabIndex = 47;
            this.lblMemberAddressLine5.Text = "Address line 5:";
            // 
            // txtMemberAddressLine3
            // 
            this.txtMemberAddressLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAddressLine3.Location = new System.Drawing.Point(255, 647);
            this.txtMemberAddressLine3.Name = "txtMemberAddressLine3";
            this.txtMemberAddressLine3.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAddressLine3.TabIndex = 60;
            // 
            // txtMemberAddressLine2
            // 
            this.txtMemberAddressLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberAddressLine2.Location = new System.Drawing.Point(255, 587);
            this.txtMemberAddressLine2.Name = "txtMemberAddressLine2";
            this.txtMemberAddressLine2.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberAddressLine2.TabIndex = 59;
            // 
            // lblMemberSurname
            // 
            this.lblMemberSurname.AutoSize = true;
            this.lblMemberSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberSurname.Location = new System.Drawing.Point(15, 170);
            this.lblMemberSurname.Name = "lblMemberSurname";
            this.lblMemberSurname.Size = new System.Drawing.Size(131, 31);
            this.lblMemberSurname.TabIndex = 49;
            this.lblMemberSurname.Text = "Surname:";
            // 
            // lblMemberAddressLine4
            // 
            this.lblMemberAddressLine4.AutoSize = true;
            this.lblMemberAddressLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAddressLine4.Location = new System.Drawing.Point(15, 710);
            this.lblMemberAddressLine4.Name = "lblMemberAddressLine4";
            this.lblMemberAddressLine4.Size = new System.Drawing.Size(193, 31);
            this.lblMemberAddressLine4.TabIndex = 48;
            this.lblMemberAddressLine4.Text = "Address line 4:";
            // 
            // lblMemberAddressLine1
            // 
            this.lblMemberAddressLine1.AutoSize = true;
            this.lblMemberAddressLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberAddressLine1.Location = new System.Drawing.Point(15, 530);
            this.lblMemberAddressLine1.Name = "lblMemberAddressLine1";
            this.lblMemberAddressLine1.Size = new System.Drawing.Size(193, 31);
            this.lblMemberAddressLine1.TabIndex = 50;
            this.lblMemberAddressLine1.Text = "Address line 1:";
            // 
            // txtMemberEmailAddress
            // 
            this.txtMemberEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberEmailAddress.Location = new System.Drawing.Point(255, 407);
            this.txtMemberEmailAddress.Name = "txtMemberEmailAddress";
            this.txtMemberEmailAddress.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberEmailAddress.TabIndex = 57;
            // 
            // txtMemberPhoneNumber
            // 
            this.txtMemberPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberPhoneNumber.Location = new System.Drawing.Point(255, 467);
            this.txtMemberPhoneNumber.Name = "txtMemberPhoneNumber";
            this.txtMemberPhoneNumber.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberPhoneNumber.TabIndex = 58;
            // 
            // lblMemberDateOfBirth
            // 
            this.lblMemberDateOfBirth.AutoSize = true;
            this.lblMemberDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberDateOfBirth.Location = new System.Drawing.Point(15, 230);
            this.lblMemberDateOfBirth.Name = "lblMemberDateOfBirth";
            this.lblMemberDateOfBirth.Size = new System.Drawing.Size(179, 31);
            this.lblMemberDateOfBirth.TabIndex = 51;
            this.lblMemberDateOfBirth.Text = "Date Of Birth:";
            // 
            // lblMemberCustomerType
            // 
            this.lblMemberCustomerType.AutoSize = true;
            this.lblMemberCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCustomerType.Location = new System.Drawing.Point(15, 290);
            this.lblMemberCustomerType.Name = "lblMemberCustomerType";
            this.lblMemberCustomerType.Size = new System.Drawing.Size(208, 31);
            this.lblMemberCustomerType.TabIndex = 52;
            this.lblMemberCustomerType.Text = "Customer Type:";
            // 
            // lblMemberEmailAddress
            // 
            this.lblMemberEmailAddress.AutoSize = true;
            this.lblMemberEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberEmailAddress.Location = new System.Drawing.Point(15, 410);
            this.lblMemberEmailAddress.Name = "lblMemberEmailAddress";
            this.lblMemberEmailAddress.Size = new System.Drawing.Size(193, 31);
            this.lblMemberEmailAddress.TabIndex = 53;
            this.lblMemberEmailAddress.Text = "Email address:";
            // 
            // lblMemberBarcode
            // 
            this.lblMemberBarcode.AutoSize = true;
            this.lblMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberBarcode.Location = new System.Drawing.Point(15, 50);
            this.lblMemberBarcode.Name = "lblMemberBarcode";
            this.lblMemberBarcode.Size = new System.Drawing.Size(123, 31);
            this.lblMemberBarcode.TabIndex = 55;
            this.lblMemberBarcode.Text = "Barcode:";
            // 
            // txtMemberSurname
            // 
            this.txtMemberSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberSurname.Location = new System.Drawing.Point(255, 167);
            this.txtMemberSurname.Name = "txtMemberSurname";
            this.txtMemberSurname.Size = new System.Drawing.Size(1159, 38);
            this.txtMemberSurname.TabIndex = 56;
            // 
            // lblMemberPhoneNumber
            // 
            this.lblMemberPhoneNumber.AutoSize = true;
            this.lblMemberPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberPhoneNumber.Location = new System.Drawing.Point(15, 470);
            this.lblMemberPhoneNumber.Name = "lblMemberPhoneNumber";
            this.lblMemberPhoneNumber.Size = new System.Drawing.Size(198, 31);
            this.lblMemberPhoneNumber.TabIndex = 54;
            this.lblMemberPhoneNumber.Text = "Phone number:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.chkSearchCopyBarcodes);
            this.pnlSearch.Controls.Add(this.lblSearchField);
            this.pnlSearch.Controls.Add(this.cmbSearchField);
            this.pnlSearch.Controls.Add(this.grpRunningTotal);
            this.pnlSearch.Controls.Add(this.lsvSearchItems);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtFilter2);
            this.pnlSearch.Controls.Add(this.txtSearchBox);
            this.pnlSearch.Controls.Add(this.txtFilter1);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnresetFilters);
            this.pnlSearch.Controls.Add(this.lblFilter1);
            this.pnlSearch.Controls.Add(this.lblFilter2);
            this.pnlSearch.Controls.Add(this.btnApplyFilters);
            this.pnlSearch.Controls.Add(this.cmbFilter2);
            this.pnlSearch.Controls.Add(this.cmbFilter1);
            this.pnlSearch.Location = new System.Drawing.Point(150, 100);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1770, 980);
            this.pnlSearch.TabIndex = 55;
            // 
            // chkSearchCopyBarcodes
            // 
            this.chkSearchCopyBarcodes.AutoSize = true;
            this.chkSearchCopyBarcodes.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkSearchCopyBarcodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSearchCopyBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchCopyBarcodes.Location = new System.Drawing.Point(730, 89);
            this.chkSearchCopyBarcodes.Name = "chkSearchCopyBarcodes";
            this.chkSearchCopyBarcodes.Size = new System.Drawing.Size(81, 75);
            this.chkSearchCopyBarcodes.TabIndex = 42;
            this.chkSearchCopyBarcodes.Text = "Show\r\nCopy\r\nBarcodes";
            this.chkSearchCopyBarcodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSearchCopyBarcodes.UseVisualStyleBackColor = true;
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchField.Location = new System.Drawing.Point(6, 10);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(102, 20);
            this.lblSearchField.TabIndex = 40;
            this.lblSearchField.Text = "Search Field:";
            // 
            // cmbSearchField
            // 
            this.cmbSearchField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchField.FormattingEnabled = true;
            this.cmbSearchField.Location = new System.Drawing.Point(10, 33);
            this.cmbSearchField.Name = "cmbSearchField";
            this.cmbSearchField.Size = new System.Drawing.Size(236, 28);
            this.cmbSearchField.TabIndex = 39;
            // 
            // grpRunningTotal
            // 
            this.grpRunningTotal.Controls.Add(this.button1);
            this.grpRunningTotal.Controls.Add(this.txtRunninGTotalOutput);
            this.grpRunningTotal.Controls.Add(this.lblRunningTotal);
            this.grpRunningTotal.Controls.Add(this.btnSetRunningTotalDate);
            this.grpRunningTotal.Controls.Add(this.label2);
            this.grpRunningTotal.Controls.Add(this.txtRunningTotalDate);
            this.grpRunningTotal.Controls.Add(this.label1);
            this.grpRunningTotal.Controls.Add(this.txtRunningTotalTime);
            this.grpRunningTotal.Controls.Add(this.btnResetRunningTotal);
            this.grpRunningTotal.Location = new System.Drawing.Point(817, 3);
            this.grpRunningTotal.Name = "grpRunningTotal";
            this.grpRunningTotal.Size = new System.Drawing.Size(345, 161);
            this.grpRunningTotal.TabIndex = 37;
            this.grpRunningTotal.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(227, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 133);
            this.button1.TabIndex = 42;
            this.button1.Text = "Add Custom Transaction";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtRunninGTotalOutput
            // 
            this.txtRunninGTotalOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunninGTotalOutput.Location = new System.Drawing.Point(96, 129);
            this.txtRunninGTotalOutput.Name = "txtRunninGTotalOutput";
            this.txtRunninGTotalOutput.ReadOnly = true;
            this.txtRunninGTotalOutput.Size = new System.Drawing.Size(125, 26);
            this.txtRunninGTotalOutput.TabIndex = 36;
            // 
            // lblRunningTotal
            // 
            this.lblRunningTotal.AutoSize = true;
            this.lblRunningTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningTotal.Location = new System.Drawing.Point(6, 12);
            this.lblRunningTotal.Name = "lblRunningTotal";
            this.lblRunningTotal.Size = new System.Drawing.Size(151, 20);
            this.lblRunningTotal.TabIndex = 35;
            this.lblRunningTotal.Text = "RUNNING TOTAL";
            // 
            // btnSetRunningTotalDate
            // 
            this.btnSetRunningTotalDate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSetRunningTotalDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetRunningTotalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetRunningTotalDate.Location = new System.Drawing.Point(6, 39);
            this.btnSetRunningTotalDate.Name = "btnSetRunningTotalDate";
            this.btnSetRunningTotalDate.Size = new System.Drawing.Size(84, 76);
            this.btnSetRunningTotalDate.TabIndex = 29;
            this.btnSetRunningTotalDate.Text = "Set Start Date";
            this.btnSetRunningTotalDate.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtRunningTotalDate
            // 
            this.txtRunningTotalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunningTotalDate.Location = new System.Drawing.Point(96, 97);
            this.txtRunningTotalDate.Name = "txtRunningTotalDate";
            this.txtRunningTotalDate.Size = new System.Drawing.Size(125, 26);
            this.txtRunningTotalDate.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Time:";
            // 
            // txtRunningTotalTime
            // 
            this.txtRunningTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunningTotalTime.Location = new System.Drawing.Point(96, 49);
            this.txtRunningTotalTime.Name = "txtRunningTotalTime";
            this.txtRunningTotalTime.Size = new System.Drawing.Size(125, 26);
            this.txtRunningTotalTime.TabIndex = 33;
            // 
            // btnResetRunningTotal
            // 
            this.btnResetRunningTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnResetRunningTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetRunningTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetRunningTotal.Location = new System.Drawing.Point(6, 129);
            this.btnResetRunningTotal.Name = "btnResetRunningTotal";
            this.btnResetRunningTotal.Size = new System.Drawing.Size(84, 26);
            this.btnResetRunningTotal.TabIndex = 34;
            this.btnResetRunningTotal.Text = "Reset";
            this.btnResetRunningTotal.UseVisualStyleBackColor = false;
            // 
            // lsvSearchItems
            // 
            this.lsvSearchItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.SeriesTitle});
            this.lsvSearchItems.HideSelection = false;
            this.lsvSearchItems.Location = new System.Drawing.Point(10, 170);
            this.lsvSearchItems.Name = "lsvSearchItems";
            this.lsvSearchItems.Size = new System.Drawing.Size(1750, 800);
            this.lsvSearchItems.TabIndex = 38;
            this.lsvSearchItems.UseCompatibleStateImageBehavior = false;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // SeriesTitle
            // 
            this.SeriesTitle.Text = "Series Title";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(6, 64);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(64, 20);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";
            // 
            // txtFilter2
            // 
            this.txtFilter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter2.Location = new System.Drawing.Point(504, 87);
            this.txtFilter2.Name = "txtFilter2";
            this.txtFilter2.Size = new System.Drawing.Size(216, 26);
            this.txtFilter2.TabIndex = 19;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(10, 87);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(236, 26);
            this.txtSearchBox.TabIndex = 7;
            // 
            // txtFilter1
            // 
            this.txtFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter1.Location = new System.Drawing.Point(265, 87);
            this.txtFilter1.Name = "txtFilter1";
            this.txtFilter1.Size = new System.Drawing.Size(216, 26);
            this.txtFilter1.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(10, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(236, 39);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnresetFilters
            // 
            this.btnresetFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnresetFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnresetFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnresetFilters.Location = new System.Drawing.Point(504, 125);
            this.btnresetFilters.Name = "btnresetFilters";
            this.btnresetFilters.Size = new System.Drawing.Size(216, 39);
            this.btnresetFilters.TabIndex = 27;
            this.btnresetFilters.Text = "Reset Filters";
            this.btnresetFilters.UseVisualStyleBackColor = false;
            // 
            // lblFilter1
            // 
            this.lblFilter1.AutoSize = true;
            this.lblFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter1.Location = new System.Drawing.Point(261, 10);
            this.lblFilter1.Name = "lblFilter1";
            this.lblFilter1.Size = new System.Drawing.Size(61, 20);
            this.lblFilter1.TabIndex = 21;
            this.lblFilter1.Text = "Filter 1:";
            // 
            // lblFilter2
            // 
            this.lblFilter2.AutoSize = true;
            this.lblFilter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter2.Location = new System.Drawing.Point(500, 10);
            this.lblFilter2.Name = "lblFilter2";
            this.lblFilter2.Size = new System.Drawing.Size(61, 20);
            this.lblFilter2.TabIndex = 22;
            this.lblFilter2.Text = "Filter 2:";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnApplyFilters.Location = new System.Drawing.Point(265, 125);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(216, 39);
            this.btnApplyFilters.TabIndex = 26;
            this.btnApplyFilters.Text = "Apply filters";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            // 
            // cmbFilter2
            // 
            this.cmbFilter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter2.FormattingEnabled = true;
            this.cmbFilter2.Location = new System.Drawing.Point(504, 33);
            this.cmbFilter2.Name = "cmbFilter2";
            this.cmbFilter2.Size = new System.Drawing.Size(216, 28);
            this.cmbFilter2.TabIndex = 23;
            // 
            // cmbFilter1
            // 
            this.cmbFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter1.FormattingEnabled = true;
            this.cmbFilter1.Location = new System.Drawing.Point(265, 33);
            this.cmbFilter1.Name = "cmbFilter1";
            this.cmbFilter1.Size = new System.Drawing.Size(216, 28);
            this.cmbFilter1.TabIndex = 24;
            // 
            // pnlStaff
            // 
            this.pnlStaff.Controls.Add(this.textBox1);
            this.pnlStaff.Controls.Add(this.label13);
            this.pnlStaff.Controls.Add(this.btnStaffMemberRecord);
            this.pnlStaff.Controls.Add(this.cmbStaffAccessLevel);
            this.pnlStaff.Controls.Add(this.btnStaffPasswordVisibility);
            this.pnlStaff.Controls.Add(this.lblStaffAccessLevel);
            this.pnlStaff.Controls.Add(this.txtStaffPassword);
            this.pnlStaff.Controls.Add(this.lblStaffPassword);
            this.pnlStaff.Controls.Add(this.lblStaffMemberBarcode);
            this.pnlStaff.Controls.Add(this.txtStaffName);
            this.pnlStaff.Controls.Add(this.btnStaffCancel);
            this.pnlStaff.Controls.Add(this.btnStaffSave);
            this.pnlStaff.Location = new System.Drawing.Point(150, 100);
            this.pnlStaff.Name = "pnlStaff";
            this.pnlStaff.Size = new System.Drawing.Size(1770, 980);
            this.pnlStaff.TabIndex = 56;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(255, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1230, 38);
            this.textBox1.TabIndex = 114;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 31);
            this.label13.TabIndex = 113;
            this.label13.Text = "Username:";
            // 
            // btnStaffMemberRecord
            // 
            this.btnStaffMemberRecord.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStaffMemberRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffMemberRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffMemberRecord.Location = new System.Drawing.Point(1235, 107);
            this.btnStaffMemberRecord.Name = "btnStaffMemberRecord";
            this.btnStaffMemberRecord.Size = new System.Drawing.Size(250, 38);
            this.btnStaffMemberRecord.TabIndex = 112;
            this.btnStaffMemberRecord.Text = "Member Record";
            this.btnStaffMemberRecord.UseVisualStyleBackColor = false;
            // 
            // cmbStaffAccessLevel
            // 
            this.cmbStaffAccessLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStaffAccessLevel.FormattingEnabled = true;
            this.cmbStaffAccessLevel.Location = new System.Drawing.Point(255, 280);
            this.cmbStaffAccessLevel.Name = "cmbStaffAccessLevel";
            this.cmbStaffAccessLevel.Size = new System.Drawing.Size(1229, 39);
            this.cmbStaffAccessLevel.TabIndex = 111;
            // 
            // btnStaffPasswordVisibility
            // 
            this.btnStaffPasswordVisibility.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStaffPasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffPasswordVisibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffPasswordVisibility.Location = new System.Drawing.Point(1235, 217);
            this.btnStaffPasswordVisibility.Name = "btnStaffPasswordVisibility";
            this.btnStaffPasswordVisibility.Size = new System.Drawing.Size(249, 38);
            this.btnStaffPasswordVisibility.TabIndex = 110;
            this.btnStaffPasswordVisibility.Text = "Show/Hide";
            this.btnStaffPasswordVisibility.UseVisualStyleBackColor = false;
            // 
            // lblStaffAccessLevel
            // 
            this.lblStaffAccessLevel.AutoSize = true;
            this.lblStaffAccessLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffAccessLevel.Location = new System.Drawing.Point(15, 290);
            this.lblStaffAccessLevel.Name = "lblStaffAccessLevel";
            this.lblStaffAccessLevel.Size = new System.Drawing.Size(183, 31);
            this.lblStaffAccessLevel.TabIndex = 108;
            this.lblStaffAccessLevel.Text = "Access Level:";
            // 
            // txtStaffPassword
            // 
            this.txtStaffPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffPassword.Location = new System.Drawing.Point(255, 217);
            this.txtStaffPassword.Name = "txtStaffPassword";
            this.txtStaffPassword.Size = new System.Drawing.Size(974, 38);
            this.txtStaffPassword.TabIndex = 107;
            // 
            // lblStaffPassword
            // 
            this.lblStaffPassword.AutoSize = true;
            this.lblStaffPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffPassword.Location = new System.Drawing.Point(15, 230);
            this.lblStaffPassword.Name = "lblStaffPassword";
            this.lblStaffPassword.Size = new System.Drawing.Size(142, 31);
            this.lblStaffPassword.TabIndex = 106;
            this.lblStaffPassword.Text = "Password:";
            // 
            // lblStaffMemberBarcode
            // 
            this.lblStaffMemberBarcode.AutoSize = true;
            this.lblStaffMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffMemberBarcode.Location = new System.Drawing.Point(15, 110);
            this.lblStaffMemberBarcode.Name = "lblStaffMemberBarcode";
            this.lblStaffMemberBarcode.Size = new System.Drawing.Size(225, 31);
            this.lblStaffMemberBarcode.TabIndex = 81;
            this.lblStaffMemberBarcode.Text = "Member barcode:";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(255, 107);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(974, 38);
            this.txtStaffName.TabIndex = 80;
            // 
            // btnStaffCancel
            // 
            this.btnStaffCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStaffCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnStaffCancel.Name = "btnStaffCancel";
            this.btnStaffCancel.Size = new System.Drawing.Size(120, 50);
            this.btnStaffCancel.TabIndex = 1;
            this.btnStaffCancel.Text = "Cancel";
            this.btnStaffCancel.UseVisualStyleBackColor = false;
            // 
            // btnStaffSave
            // 
            this.btnStaffSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStaffSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffSave.Location = new System.Drawing.Point(1518, 924);
            this.btnStaffSave.Name = "btnStaffSave";
            this.btnStaffSave.Size = new System.Drawing.Size(120, 50);
            this.btnStaffSave.TabIndex = 0;
            this.btnStaffSave.Text = "Save";
            this.btnStaffSave.UseVisualStyleBackColor = false;
            // 
            // pnlCheckOut
            // 
            this.pnlCheckOut.Controls.Add(this.dateTimePicker1);
            this.pnlCheckOut.Controls.Add(this.lblCheckOutSetDueDate);
            this.pnlCheckOut.Controls.Add(this.txtCheckOutLateBooks);
            this.pnlCheckOut.Controls.Add(this.lblCheckOutOverdueBooks);
            this.pnlCheckOut.Controls.Add(this.lsvCheckOutSelectedBooks);
            this.pnlCheckOut.Controls.Add(this.txtCheckOutSelectedBooks);
            this.pnlCheckOut.Controls.Add(this.txtCheckOutCurrentMemberCheckOuts);
            this.pnlCheckOut.Controls.Add(this.lblCheckOutCurrentMemberCheckOuts);
            this.pnlCheckOut.Controls.Add(this.txtCheckOutMemberBarcode);
            this.pnlCheckOut.Controls.Add(this.lblCheckOutMemberBarcode);
            this.pnlCheckOut.Controls.Add(this.txtCheckOutMemberName);
            this.pnlCheckOut.Controls.Add(this.lblCheckOutMemberName);
            this.pnlCheckOut.Controls.Add(this.btnCheckOutSave);
            this.pnlCheckOut.Controls.Add(this.btnCheckOutCancel);
            this.pnlCheckOut.Location = new System.Drawing.Point(150, 100);
            this.pnlCheckOut.Name = "pnlCheckOut";
            this.pnlCheckOut.Size = new System.Drawing.Size(1770, 980);
            this.pnlCheckOut.TabIndex = 17;
            this.pnlCheckOut.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCheckOut_Paint);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(291, 287);
            this.dateTimePicker1.MaxDate = new System.DateTime(2024, 7, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2023, 7, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(226, 38);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2023, 7, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblCheckOutSetDueDate
            // 
            this.lblCheckOutSetDueDate.AutoSize = true;
            this.lblCheckOutSetDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutSetDueDate.Location = new System.Drawing.Point(15, 290);
            this.lblCheckOutSetDueDate.Name = "lblCheckOutSetDueDate";
            this.lblCheckOutSetDueDate.Size = new System.Drawing.Size(137, 31);
            this.lblCheckOutSetDueDate.TabIndex = 22;
            this.lblCheckOutSetDueDate.Text = "Due Date:";
            // 
            // txtCheckOutLateBooks
            // 
            this.txtCheckOutLateBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutLateBooks.Location = new System.Drawing.Point(291, 227);
            this.txtCheckOutLateBooks.Name = "txtCheckOutLateBooks";
            this.txtCheckOutLateBooks.ReadOnly = true;
            this.txtCheckOutLateBooks.Size = new System.Drawing.Size(150, 38);
            this.txtCheckOutLateBooks.TabIndex = 21;
            // 
            // lblCheckOutOverdueBooks
            // 
            this.lblCheckOutOverdueBooks.AutoSize = true;
            this.lblCheckOutOverdueBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutOverdueBooks.Location = new System.Drawing.Point(15, 230);
            this.lblCheckOutOverdueBooks.Name = "lblCheckOutOverdueBooks";
            this.lblCheckOutOverdueBooks.Size = new System.Drawing.Size(209, 31);
            this.lblCheckOutOverdueBooks.TabIndex = 20;
            this.lblCheckOutOverdueBooks.Text = "Overdue Books:";
            // 
            // lsvCheckOutSelectedBooks
            // 
            this.lsvCheckOutSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCheckOutSelectedBooks.HideSelection = false;
            this.lsvCheckOutSelectedBooks.Location = new System.Drawing.Point(291, 347);
            this.lsvCheckOutSelectedBooks.Name = "lsvCheckOutSelectedBooks";
            this.lsvCheckOutSelectedBooks.Size = new System.Drawing.Size(1179, 627);
            this.lsvCheckOutSelectedBooks.TabIndex = 19;
            this.lsvCheckOutSelectedBooks.UseCompatibleStateImageBehavior = false;
            // 
            // txtCheckOutSelectedBooks
            // 
            this.txtCheckOutSelectedBooks.AutoSize = true;
            this.txtCheckOutSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutSelectedBooks.Location = new System.Drawing.Point(15, 350);
            this.txtCheckOutSelectedBooks.Name = "txtCheckOutSelectedBooks";
            this.txtCheckOutSelectedBooks.Size = new System.Drawing.Size(211, 31);
            this.txtCheckOutSelectedBooks.TabIndex = 18;
            this.txtCheckOutSelectedBooks.Text = "Selected Books:";
            // 
            // txtCheckOutCurrentMemberCheckOuts
            // 
            this.txtCheckOutCurrentMemberCheckOuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutCurrentMemberCheckOuts.Location = new System.Drawing.Point(291, 167);
            this.txtCheckOutCurrentMemberCheckOuts.Name = "txtCheckOutCurrentMemberCheckOuts";
            this.txtCheckOutCurrentMemberCheckOuts.ReadOnly = true;
            this.txtCheckOutCurrentMemberCheckOuts.Size = new System.Drawing.Size(150, 38);
            this.txtCheckOutCurrentMemberCheckOuts.TabIndex = 17;
            // 
            // lblCheckOutCurrentMemberCheckOuts
            // 
            this.lblCheckOutCurrentMemberCheckOuts.AutoSize = true;
            this.lblCheckOutCurrentMemberCheckOuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutCurrentMemberCheckOuts.Location = new System.Drawing.Point(15, 170);
            this.lblCheckOutCurrentMemberCheckOuts.Name = "lblCheckOutCurrentMemberCheckOuts";
            this.lblCheckOutCurrentMemberCheckOuts.Size = new System.Drawing.Size(263, 31);
            this.lblCheckOutCurrentMemberCheckOuts.TabIndex = 16;
            this.lblCheckOutCurrentMemberCheckOuts.Text = "Current Check Outs:";
            // 
            // txtCheckOutMemberBarcode
            // 
            this.txtCheckOutMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutMemberBarcode.Location = new System.Drawing.Point(291, 47);
            this.txtCheckOutMemberBarcode.Name = "txtCheckOutMemberBarcode";
            this.txtCheckOutMemberBarcode.Size = new System.Drawing.Size(1179, 38);
            this.txtCheckOutMemberBarcode.TabIndex = 15;
            // 
            // lblCheckOutMemberBarcode
            // 
            this.lblCheckOutMemberBarcode.AutoSize = true;
            this.lblCheckOutMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutMemberBarcode.Location = new System.Drawing.Point(15, 50);
            this.lblCheckOutMemberBarcode.Name = "lblCheckOutMemberBarcode";
            this.lblCheckOutMemberBarcode.Size = new System.Drawing.Size(228, 31);
            this.lblCheckOutMemberBarcode.TabIndex = 14;
            this.lblCheckOutMemberBarcode.Text = "Member Barcode:";
            // 
            // txtCheckOutMemberName
            // 
            this.txtCheckOutMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutMemberName.Location = new System.Drawing.Point(291, 107);
            this.txtCheckOutMemberName.Name = "txtCheckOutMemberName";
            this.txtCheckOutMemberName.Size = new System.Drawing.Size(1179, 38);
            this.txtCheckOutMemberName.TabIndex = 13;
            // 
            // lblCheckOutMemberName
            // 
            this.lblCheckOutMemberName.AutoSize = true;
            this.lblCheckOutMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutMemberName.Location = new System.Drawing.Point(15, 110);
            this.lblCheckOutMemberName.Name = "lblCheckOutMemberName";
            this.lblCheckOutMemberName.Size = new System.Drawing.Size(199, 31);
            this.lblCheckOutMemberName.TabIndex = 12;
            this.lblCheckOutMemberName.Text = "Member Name:";
            // 
            // btnCheckOutSave
            // 
            this.btnCheckOutSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckOutSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOutSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOutSave.Location = new System.Drawing.Point(1518, 924);
            this.btnCheckOutSave.Name = "btnCheckOutSave";
            this.btnCheckOutSave.Size = new System.Drawing.Size(120, 50);
            this.btnCheckOutSave.TabIndex = 13;
            this.btnCheckOutSave.Text = "Save";
            this.btnCheckOutSave.UseVisualStyleBackColor = false;
            // 
            // btnCheckOutCancel
            // 
            this.btnCheckOutCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckOutCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOutCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOutCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnCheckOutCancel.Name = "btnCheckOutCancel";
            this.btnCheckOutCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCheckOutCancel.TabIndex = 14;
            this.btnCheckOutCancel.Text = "Cancel";
            this.btnCheckOutCancel.UseVisualStyleBackColor = false;
            // 
            // pnlDelete
            // 
            this.pnlDelete.Controls.Add(this.lsvDelete);
            this.pnlDelete.Controls.Add(this.lblDeleteSelectedRecords);
            this.pnlDelete.Controls.Add(this.lblDeleteTitle);
            this.pnlDelete.Controls.Add(this.btnDeleteCancel);
            this.pnlDelete.Controls.Add(this.btnDeleteDelete);
            this.pnlDelete.Location = new System.Drawing.Point(150, 100);
            this.pnlDelete.Name = "pnlDelete";
            this.pnlDelete.Size = new System.Drawing.Size(1770, 980);
            this.pnlDelete.TabIndex = 54;
            // 
            // lsvDelete
            // 
            this.lsvDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvDelete.HideSelection = false;
            this.lsvDelete.Location = new System.Drawing.Point(311, 107);
            this.lsvDelete.Name = "lsvDelete";
            this.lsvDelete.Size = new System.Drawing.Size(1179, 867);
            this.lsvDelete.TabIndex = 24;
            this.lsvDelete.UseCompatibleStateImageBehavior = false;
            // 
            // lblDeleteSelectedRecords
            // 
            this.lblDeleteSelectedRecords.AutoSize = true;
            this.lblDeleteSelectedRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteSelectedRecords.Location = new System.Drawing.Point(15, 110);
            this.lblDeleteSelectedRecords.Name = "lblDeleteSelectedRecords";
            this.lblDeleteSelectedRecords.Size = new System.Drawing.Size(237, 31);
            this.lblDeleteSelectedRecords.TabIndex = 23;
            this.lblDeleteSelectedRecords.Text = "Selected Records:";
            // 
            // lblDeleteTitle
            // 
            this.lblDeleteTitle.AutoSize = true;
            this.lblDeleteTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteTitle.Location = new System.Drawing.Point(15, 50);
            this.lblDeleteTitle.Name = "lblDeleteTitle";
            this.lblDeleteTitle.Size = new System.Drawing.Size(134, 39);
            this.lblDeleteTitle.TabIndex = 19;
            this.lblDeleteTitle.Text = "Delete:";
            // 
            // btnDeleteCancel
            // 
            this.btnDeleteCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDeleteCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnDeleteCancel.Name = "btnDeleteCancel";
            this.btnDeleteCancel.Size = new System.Drawing.Size(120, 50);
            this.btnDeleteCancel.TabIndex = 14;
            this.btnDeleteCancel.Text = "Cancel";
            this.btnDeleteCancel.UseVisualStyleBackColor = false;
            // 
            // btnDeleteDelete
            // 
            this.btnDeleteDelete.BackColor = System.Drawing.Color.Red;
            this.btnDeleteDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDelete.Location = new System.Drawing.Point(1518, 924);
            this.btnDeleteDelete.Name = "btnDeleteDelete";
            this.btnDeleteDelete.Size = new System.Drawing.Size(120, 50);
            this.btnDeleteDelete.TabIndex = 13;
            this.btnDeleteDelete.Text = "Delete";
            this.btnDeleteDelete.UseVisualStyleBackColor = false;
            // 
            // pnlSell
            // 
            this.pnlSell.Controls.Add(this.txtCheckOutPrice);
            this.pnlSell.Controls.Add(this.lblCheckOutPrice);
            this.pnlSell.Controls.Add(this.txtSellOverdueBooks);
            this.pnlSell.Controls.Add(this.lblSellBooksOverdueBooks);
            this.pnlSell.Controls.Add(this.lsvSellSelectedBooks);
            this.pnlSell.Controls.Add(this.lblSellSelectedBooks);
            this.pnlSell.Controls.Add(this.txtSellLoans);
            this.pnlSell.Controls.Add(this.lblSellLoans);
            this.pnlSell.Controls.Add(this.txtSellMemberBarcode);
            this.pnlSell.Controls.Add(this.lblSellMemberBarcode);
            this.pnlSell.Controls.Add(this.txtSellMemberName);
            this.pnlSell.Controls.Add(this.lblSellMemberName);
            this.pnlSell.Controls.Add(this.btnSellCancel);
            this.pnlSell.Controls.Add(this.btnSellSave);
            this.pnlSell.Location = new System.Drawing.Point(150, 100);
            this.pnlSell.Name = "pnlSell";
            this.pnlSell.Size = new System.Drawing.Size(1770, 980);
            this.pnlSell.TabIndex = 57;
            // 
            // txtCheckOutPrice
            // 
            this.txtCheckOutPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckOutPrice.Location = new System.Drawing.Point(291, 287);
            this.txtCheckOutPrice.Name = "txtCheckOutPrice";
            this.txtCheckOutPrice.ReadOnly = true;
            this.txtCheckOutPrice.Size = new System.Drawing.Size(150, 38);
            this.txtCheckOutPrice.TabIndex = 28;
            // 
            // lblCheckOutPrice
            // 
            this.lblCheckOutPrice.AutoSize = true;
            this.lblCheckOutPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutPrice.Location = new System.Drawing.Point(15, 290);
            this.lblCheckOutPrice.Name = "lblCheckOutPrice";
            this.lblCheckOutPrice.Size = new System.Drawing.Size(220, 31);
            this.lblCheckOutPrice.TabIndex = 27;
            this.lblCheckOutPrice.Text = "Check Out Price:";
            // 
            // txtSellOverdueBooks
            // 
            this.txtSellOverdueBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellOverdueBooks.Location = new System.Drawing.Point(291, 227);
            this.txtSellOverdueBooks.Name = "txtSellOverdueBooks";
            this.txtSellOverdueBooks.ReadOnly = true;
            this.txtSellOverdueBooks.Size = new System.Drawing.Size(150, 38);
            this.txtSellOverdueBooks.TabIndex = 26;
            // 
            // lblSellBooksOverdueBooks
            // 
            this.lblSellBooksOverdueBooks.AutoSize = true;
            this.lblSellBooksOverdueBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellBooksOverdueBooks.Location = new System.Drawing.Point(15, 230);
            this.lblSellBooksOverdueBooks.Name = "lblSellBooksOverdueBooks";
            this.lblSellBooksOverdueBooks.Size = new System.Drawing.Size(209, 31);
            this.lblSellBooksOverdueBooks.TabIndex = 25;
            this.lblSellBooksOverdueBooks.Text = "Overdue Books:";
            // 
            // lsvSellSelectedBooks
            // 
            this.lsvSellSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvSellSelectedBooks.HideSelection = false;
            this.lsvSellSelectedBooks.Location = new System.Drawing.Point(291, 347);
            this.lsvSellSelectedBooks.Name = "lsvSellSelectedBooks";
            this.lsvSellSelectedBooks.Size = new System.Drawing.Size(1179, 627);
            this.lsvSellSelectedBooks.TabIndex = 24;
            this.lsvSellSelectedBooks.UseCompatibleStateImageBehavior = false;
            // 
            // lblSellSelectedBooks
            // 
            this.lblSellSelectedBooks.AutoSize = true;
            this.lblSellSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellSelectedBooks.Location = new System.Drawing.Point(15, 350);
            this.lblSellSelectedBooks.Name = "lblSellSelectedBooks";
            this.lblSellSelectedBooks.Size = new System.Drawing.Size(211, 31);
            this.lblSellSelectedBooks.TabIndex = 23;
            this.lblSellSelectedBooks.Text = "Selected Books:";
            // 
            // txtSellLoans
            // 
            this.txtSellLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellLoans.Location = new System.Drawing.Point(249, 167);
            this.txtSellLoans.Name = "txtSellLoans";
            this.txtSellLoans.ReadOnly = true;
            this.txtSellLoans.Size = new System.Drawing.Size(212, 38);
            this.txtSellLoans.TabIndex = 22;
            // 
            // lblSellLoans
            // 
            this.lblSellLoans.AutoSize = true;
            this.lblSellLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellLoans.Location = new System.Drawing.Point(15, 170);
            this.lblSellLoans.Name = "lblSellLoans";
            this.lblSellLoans.Size = new System.Drawing.Size(194, 31);
            this.lblSellLoans.TabIndex = 21;
            this.lblSellLoans.Text = "Current Loans:";
            // 
            // txtSellMemberBarcode
            // 
            this.txtSellMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellMemberBarcode.Location = new System.Drawing.Point(249, 47);
            this.txtSellMemberBarcode.Name = "txtSellMemberBarcode";
            this.txtSellMemberBarcode.Size = new System.Drawing.Size(1241, 38);
            this.txtSellMemberBarcode.TabIndex = 20;
            // 
            // lblSellMemberBarcode
            // 
            this.lblSellMemberBarcode.AutoSize = true;
            this.lblSellMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellMemberBarcode.Location = new System.Drawing.Point(15, 50);
            this.lblSellMemberBarcode.Name = "lblSellMemberBarcode";
            this.lblSellMemberBarcode.Size = new System.Drawing.Size(228, 31);
            this.lblSellMemberBarcode.TabIndex = 19;
            this.lblSellMemberBarcode.Text = "Member Barcode:";
            // 
            // txtSellMemberName
            // 
            this.txtSellMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellMemberName.Location = new System.Drawing.Point(249, 107);
            this.txtSellMemberName.Name = "txtSellMemberName";
            this.txtSellMemberName.Size = new System.Drawing.Size(1241, 38);
            this.txtSellMemberName.TabIndex = 18;
            // 
            // lblSellMemberName
            // 
            this.lblSellMemberName.AutoSize = true;
            this.lblSellMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellMemberName.Location = new System.Drawing.Point(15, 110);
            this.lblSellMemberName.Name = "lblSellMemberName";
            this.lblSellMemberName.Size = new System.Drawing.Size(199, 31);
            this.lblSellMemberName.TabIndex = 17;
            this.lblSellMemberName.Text = "Member Name:";
            // 
            // btnSellCancel
            // 
            this.btnSellCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSellCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnSellCancel.Name = "btnSellCancel";
            this.btnSellCancel.Size = new System.Drawing.Size(120, 50);
            this.btnSellCancel.TabIndex = 14;
            this.btnSellCancel.Text = "Cancel";
            this.btnSellCancel.UseVisualStyleBackColor = false;
            // 
            // btnSellSave
            // 
            this.btnSellSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSellSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSellSave.Location = new System.Drawing.Point(1518, 924);
            this.btnSellSave.Name = "btnSellSave";
            this.btnSellSave.Size = new System.Drawing.Size(120, 50);
            this.btnSellSave.TabIndex = 13;
            this.btnSellSave.Text = "Save";
            this.btnSellSave.UseVisualStyleBackColor = false;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.lblDefaultSettings);
            this.pnlSetting.Controls.Add(this.txtSettingDefault);
            this.pnlSetting.Controls.Add(this.cmbSettingDefault2);
            this.pnlSetting.Controls.Add(this.cmbSettingDefault3);
            this.pnlSetting.Controls.Add(this.cmbSettingDefault1);
            this.pnlSetting.Controls.Add(this.btnGmailKeyIsVisible);
            this.pnlSetting.Controls.Add(this.textBox12);
            this.pnlSetting.Controls.Add(this.lblSettingGmailKey);
            this.pnlSetting.Controls.Add(this.btnSettingCancel);
            this.pnlSetting.Controls.Add(this.btnSettingSave);
            this.pnlSetting.Location = new System.Drawing.Point(150, 100);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(1770, 980);
            this.pnlSetting.TabIndex = 58;
            // 
            // lblDefaultSettings
            // 
            this.lblDefaultSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultSettings.Location = new System.Drawing.Point(599, 376);
            this.lblDefaultSettings.Name = "lblDefaultSettings";
            this.lblDefaultSettings.Size = new System.Drawing.Size(579, 36);
            this.lblDefaultSettings.TabIndex = 79;
            this.lblDefaultSettings.Text = "Default Settings:";
            this.lblDefaultSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSettingDefault
            // 
            this.txtSettingDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingDefault.Location = new System.Drawing.Point(600, 548);
            this.txtSettingDefault.Name = "txtSettingDefault";
            this.txtSettingDefault.Size = new System.Drawing.Size(579, 38);
            this.txtSettingDefault.TabIndex = 78;
            // 
            // cmbSettingDefault2
            // 
            this.cmbSettingDefault2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingDefault2.FormattingEnabled = true;
            this.cmbSettingDefault2.Location = new System.Drawing.Point(599, 460);
            this.cmbSettingDefault2.Name = "cmbSettingDefault2";
            this.cmbSettingDefault2.Size = new System.Drawing.Size(579, 39);
            this.cmbSettingDefault2.TabIndex = 77;
            // 
            // cmbSettingDefault3
            // 
            this.cmbSettingDefault3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingDefault3.FormattingEnabled = true;
            this.cmbSettingDefault3.Location = new System.Drawing.Point(600, 505);
            this.cmbSettingDefault3.Name = "cmbSettingDefault3";
            this.cmbSettingDefault3.Size = new System.Drawing.Size(578, 39);
            this.cmbSettingDefault3.TabIndex = 76;
            // 
            // cmbSettingDefault1
            // 
            this.cmbSettingDefault1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingDefault1.FormattingEnabled = true;
            this.cmbSettingDefault1.Location = new System.Drawing.Point(599, 415);
            this.cmbSettingDefault1.Name = "cmbSettingDefault1";
            this.cmbSettingDefault1.Size = new System.Drawing.Size(579, 39);
            this.cmbSettingDefault1.TabIndex = 75;
            // 
            // btnGmailKeyIsVisible
            // 
            this.btnGmailKeyIsVisible.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGmailKeyIsVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGmailKeyIsVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGmailKeyIsVisible.Location = new System.Drawing.Point(1058, 317);
            this.btnGmailKeyIsVisible.Name = "btnGmailKeyIsVisible";
            this.btnGmailKeyIsVisible.Size = new System.Drawing.Size(120, 38);
            this.btnGmailKeyIsVisible.TabIndex = 74;
            this.btnGmailKeyIsVisible.Text = "Show/Hide";
            this.btnGmailKeyIsVisible.UseVisualStyleBackColor = false;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(745, 317);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(307, 38);
            this.textBox12.TabIndex = 73;
            // 
            // lblSettingGmailKey
            // 
            this.lblSettingGmailKey.AutoSize = true;
            this.lblSettingGmailKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingGmailKey.Location = new System.Drawing.Point(593, 320);
            this.lblSettingGmailKey.Name = "lblSettingGmailKey";
            this.lblSettingGmailKey.Size = new System.Drawing.Size(146, 31);
            this.lblSettingGmailKey.TabIndex = 72;
            this.lblSettingGmailKey.Text = "Gmail Key:";
            // 
            // btnSettingCancel
            // 
            this.btnSettingCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSettingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnSettingCancel.Name = "btnSettingCancel";
            this.btnSettingCancel.Size = new System.Drawing.Size(120, 50);
            this.btnSettingCancel.TabIndex = 1;
            this.btnSettingCancel.Text = "Cancel";
            this.btnSettingCancel.UseVisualStyleBackColor = false;
            // 
            // btnSettingSave
            // 
            this.btnSettingSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSettingSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingSave.Location = new System.Drawing.Point(1518, 924);
            this.btnSettingSave.Name = "btnSettingSave";
            this.btnSettingSave.Size = new System.Drawing.Size(120, 50);
            this.btnSettingSave.TabIndex = 0;
            this.btnSettingSave.Text = "Save";
            this.btnSettingSave.UseVisualStyleBackColor = false;
            // 
            // pnlCheckIn
            // 
            this.pnlCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckIn.Controls.Add(this.lblCheckInEnterBarcode);
            this.pnlCheckIn.Controls.Add(this.txtCheckInEnterBarcode);
            this.pnlCheckIn.Controls.Add(this.lblCheckInLateFees);
            this.pnlCheckIn.Controls.Add(this.txtCheckInOverdue);
            this.pnlCheckIn.Controls.Add(this.lblCheckInOverdue);
            this.pnlCheckIn.Controls.Add(this.lsvCheckInSelectedBooks);
            this.pnlCheckIn.Controls.Add(this.lblCheckInSelectedBooks);
            this.pnlCheckIn.Controls.Add(this.txtCheckInLoans);
            this.pnlCheckIn.Controls.Add(this.lblCheckInLoans);
            this.pnlCheckIn.Controls.Add(this.txtCheckInMemberBarcode);
            this.pnlCheckIn.Controls.Add(this.lblCheckInMemberBarcode);
            this.pnlCheckIn.Controls.Add(this.txtCheckInMemberName);
            this.pnlCheckIn.Controls.Add(this.lblCheckInMemberName);
            this.pnlCheckIn.Controls.Add(this.btnCheckInCancel);
            this.pnlCheckIn.Controls.Add(this.txtCheckInLateFees);
            this.pnlCheckIn.Controls.Add(this.btnCheckInSave);
            this.pnlCheckIn.Location = new System.Drawing.Point(150, 100);
            this.pnlCheckIn.Name = "pnlCheckIn";
            this.pnlCheckIn.Size = new System.Drawing.Size(1770, 980);
            this.pnlCheckIn.TabIndex = 52;
            // 
            // lblCheckInEnterBarcode
            // 
            this.lblCheckInEnterBarcode.AutoSize = true;
            this.lblCheckInEnterBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInEnterBarcode.Location = new System.Drawing.Point(15, 350);
            this.lblCheckInEnterBarcode.Name = "lblCheckInEnterBarcode";
            this.lblCheckInEnterBarcode.Size = new System.Drawing.Size(206, 31);
            this.lblCheckInEnterBarcode.TabIndex = 29;
            this.lblCheckInEnterBarcode.Text = "Enter barcodes:";
            // 
            // txtCheckInEnterBarcode
            // 
            this.txtCheckInEnterBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckInEnterBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInEnterBarcode.Location = new System.Drawing.Point(249, 347);
            this.txtCheckInEnterBarcode.Name = "txtCheckInEnterBarcode";
            this.txtCheckInEnterBarcode.Size = new System.Drawing.Size(1241, 38);
            this.txtCheckInEnterBarcode.TabIndex = 30;
            // 
            // lblCheckInLateFees
            // 
            this.lblCheckInLateFees.AutoSize = true;
            this.lblCheckInLateFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInLateFees.Location = new System.Drawing.Point(15, 290);
            this.lblCheckInLateFees.Name = "lblCheckInLateFees";
            this.lblCheckInLateFees.Size = new System.Drawing.Size(215, 31);
            this.lblCheckInLateFees.TabIndex = 27;
            this.lblCheckInLateFees.Text = "Late Fees owed:";
            // 
            // txtCheckInOverdue
            // 
            this.txtCheckInOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInOverdue.Location = new System.Drawing.Point(249, 227);
            this.txtCheckInOverdue.Name = "txtCheckInOverdue";
            this.txtCheckInOverdue.ReadOnly = true;
            this.txtCheckInOverdue.Size = new System.Drawing.Size(212, 38);
            this.txtCheckInOverdue.TabIndex = 26;
            // 
            // lblCheckInOverdue
            // 
            this.lblCheckInOverdue.AutoSize = true;
            this.lblCheckInOverdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInOverdue.Location = new System.Drawing.Point(15, 230);
            this.lblCheckInOverdue.Name = "lblCheckInOverdue";
            this.lblCheckInOverdue.Size = new System.Drawing.Size(209, 31);
            this.lblCheckInOverdue.TabIndex = 25;
            this.lblCheckInOverdue.Text = "Overdue Books:";
            // 
            // lsvCheckInSelectedBooks
            // 
            this.lsvCheckInSelectedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCheckInSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCheckInSelectedBooks.HideSelection = false;
            this.lsvCheckInSelectedBooks.Location = new System.Drawing.Point(249, 407);
            this.lsvCheckInSelectedBooks.Name = "lsvCheckInSelectedBooks";
            this.lsvCheckInSelectedBooks.Size = new System.Drawing.Size(1241, 501);
            this.lsvCheckInSelectedBooks.TabIndex = 24;
            this.lsvCheckInSelectedBooks.UseCompatibleStateImageBehavior = false;
            // 
            // lblCheckInSelectedBooks
            // 
            this.lblCheckInSelectedBooks.AutoSize = true;
            this.lblCheckInSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInSelectedBooks.Location = new System.Drawing.Point(15, 410);
            this.lblCheckInSelectedBooks.Name = "lblCheckInSelectedBooks";
            this.lblCheckInSelectedBooks.Size = new System.Drawing.Size(211, 31);
            this.lblCheckInSelectedBooks.TabIndex = 23;
            this.lblCheckInSelectedBooks.Text = "Selected Books:";
            // 
            // txtCheckInLoans
            // 
            this.txtCheckInLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInLoans.Location = new System.Drawing.Point(249, 167);
            this.txtCheckInLoans.Name = "txtCheckInLoans";
            this.txtCheckInLoans.ReadOnly = true;
            this.txtCheckInLoans.Size = new System.Drawing.Size(212, 38);
            this.txtCheckInLoans.TabIndex = 22;
            // 
            // lblCheckInLoans
            // 
            this.lblCheckInLoans.AutoSize = true;
            this.lblCheckInLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInLoans.Location = new System.Drawing.Point(15, 170);
            this.lblCheckInLoans.Name = "lblCheckInLoans";
            this.lblCheckInLoans.Size = new System.Drawing.Size(194, 31);
            this.lblCheckInLoans.TabIndex = 21;
            this.lblCheckInLoans.Text = "Current Loans:";
            // 
            // txtCheckInMemberBarcode
            // 
            this.txtCheckInMemberBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckInMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInMemberBarcode.Location = new System.Drawing.Point(249, 47);
            this.txtCheckInMemberBarcode.Name = "txtCheckInMemberBarcode";
            this.txtCheckInMemberBarcode.Size = new System.Drawing.Size(1241, 38);
            this.txtCheckInMemberBarcode.TabIndex = 20;
            // 
            // lblCheckInMemberBarcode
            // 
            this.lblCheckInMemberBarcode.AutoSize = true;
            this.lblCheckInMemberBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInMemberBarcode.Location = new System.Drawing.Point(15, 50);
            this.lblCheckInMemberBarcode.Name = "lblCheckInMemberBarcode";
            this.lblCheckInMemberBarcode.Size = new System.Drawing.Size(228, 31);
            this.lblCheckInMemberBarcode.TabIndex = 19;
            this.lblCheckInMemberBarcode.Text = "Member Barcode:";
            // 
            // txtCheckInMemberName
            // 
            this.txtCheckInMemberName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckInMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInMemberName.Location = new System.Drawing.Point(249, 107);
            this.txtCheckInMemberName.Name = "txtCheckInMemberName";
            this.txtCheckInMemberName.ReadOnly = true;
            this.txtCheckInMemberName.Size = new System.Drawing.Size(1241, 38);
            this.txtCheckInMemberName.TabIndex = 18;
            // 
            // lblCheckInMemberName
            // 
            this.lblCheckInMemberName.AutoSize = true;
            this.lblCheckInMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInMemberName.Location = new System.Drawing.Point(15, 110);
            this.lblCheckInMemberName.Name = "lblCheckInMemberName";
            this.lblCheckInMemberName.Size = new System.Drawing.Size(199, 31);
            this.lblCheckInMemberName.TabIndex = 17;
            this.lblCheckInMemberName.Text = "Member Name:";
            // 
            // btnCheckInCancel
            // 
            this.btnCheckInCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckInCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckInCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckInCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckInCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnCheckInCancel.Name = "btnCheckInCancel";
            this.btnCheckInCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCheckInCancel.TabIndex = 14;
            this.btnCheckInCancel.Text = "Cancel";
            this.btnCheckInCancel.UseVisualStyleBackColor = false;
            // 
            // txtCheckInLateFees
            // 
            this.txtCheckInLateFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckInLateFees.Location = new System.Drawing.Point(249, 287);
            this.txtCheckInLateFees.Name = "txtCheckInLateFees";
            this.txtCheckInLateFees.ReadOnly = true;
            this.txtCheckInLateFees.Size = new System.Drawing.Size(212, 38);
            this.txtCheckInLateFees.TabIndex = 28;
            // 
            // btnCheckInSave
            // 
            this.btnCheckInSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckInSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCheckInSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckInSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckInSave.Location = new System.Drawing.Point(1518, 924);
            this.btnCheckInSave.Name = "btnCheckInSave";
            this.btnCheckInSave.Size = new System.Drawing.Size(120, 50);
            this.btnCheckInSave.TabIndex = 13;
            this.btnCheckInSave.Text = "Save";
            this.btnCheckInSave.UseVisualStyleBackColor = false;
            // 
            // pnlBookDetails
            // 
            this.pnlBookDetails.Controls.Add(this.btnBookSave);
            this.pnlBookDetails.Controls.Add(this.btnBookCancel);
            this.pnlBookDetails.Controls.Add(this.grpBooksBookStatus);
            this.pnlBookDetails.Controls.Add(this.grpBookDetails);
            this.pnlBookDetails.Controls.Add(this.grpBookCopyDetails);
            this.pnlBookDetails.Location = new System.Drawing.Point(150, 100);
            this.pnlBookDetails.Name = "pnlBookDetails";
            this.pnlBookDetails.Size = new System.Drawing.Size(1770, 980);
            this.pnlBookDetails.TabIndex = 59;
            // 
            // btnBookSave
            // 
            this.btnBookSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBookSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookSave.Location = new System.Drawing.Point(1518, 924);
            this.btnBookSave.Name = "btnBookSave";
            this.btnBookSave.Size = new System.Drawing.Size(120, 50);
            this.btnBookSave.TabIndex = 0;
            this.btnBookSave.Text = "Save";
            this.btnBookSave.UseVisualStyleBackColor = false;
            // 
            // btnBookCancel
            // 
            this.btnBookCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBookCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookCancel.Location = new System.Drawing.Point(1644, 924);
            this.btnBookCancel.Name = "btnBookCancel";
            this.btnBookCancel.Size = new System.Drawing.Size(120, 50);
            this.btnBookCancel.TabIndex = 1;
            this.btnBookCancel.Text = "Cancel";
            this.btnBookCancel.UseVisualStyleBackColor = false;
            // 
            // grpBooksBookStatus
            // 
            this.grpBooksBookStatus.Controls.Add(this.txtLoaned);
            this.grpBooksBookStatus.Controls.Add(this.lblBooksInStock);
            this.grpBooksBookStatus.Controls.Add(this.txtBooksReserved);
            this.grpBooksBookStatus.Controls.Add(this.txtBooksInStock);
            this.grpBooksBookStatus.Controls.Add(this.lblBooksLoaned);
            this.grpBooksBookStatus.Controls.Add(this.lblBooksReserved);
            this.grpBooksBookStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBooksBookStatus.Location = new System.Drawing.Point(1437, 700);
            this.grpBooksBookStatus.Name = "grpBooksBookStatus";
            this.grpBooksBookStatus.Size = new System.Drawing.Size(327, 208);
            this.grpBooksBookStatus.TabIndex = 45;
            this.grpBooksBookStatus.TabStop = false;
            this.grpBooksBookStatus.Text = "Book Status";
            // 
            // txtLoaned
            // 
            this.txtLoaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaned.Location = new System.Drawing.Point(151, 157);
            this.txtLoaned.Name = "txtLoaned";
            this.txtLoaned.ReadOnly = true;
            this.txtLoaned.Size = new System.Drawing.Size(89, 38);
            this.txtLoaned.TabIndex = 49;
            // 
            // lblBooksInStock
            // 
            this.lblBooksInStock.AutoSize = true;
            this.lblBooksInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksInStock.Location = new System.Drawing.Point(6, 40);
            this.lblBooksInStock.Name = "lblBooksInStock";
            this.lblBooksInStock.Size = new System.Drawing.Size(121, 31);
            this.lblBooksInStock.TabIndex = 45;
            this.lblBooksInStock.Text = "In Stock:";
            // 
            // txtBooksReserved
            // 
            this.txtBooksReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBooksReserved.Location = new System.Drawing.Point(151, 97);
            this.txtBooksReserved.Name = "txtBooksReserved";
            this.txtBooksReserved.ReadOnly = true;
            this.txtBooksReserved.Size = new System.Drawing.Size(89, 38);
            this.txtBooksReserved.TabIndex = 48;
            // 
            // txtBooksInStock
            // 
            this.txtBooksInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBooksInStock.Location = new System.Drawing.Point(151, 37);
            this.txtBooksInStock.Name = "txtBooksInStock";
            this.txtBooksInStock.ReadOnly = true;
            this.txtBooksInStock.Size = new System.Drawing.Size(89, 38);
            this.txtBooksInStock.TabIndex = 44;
            // 
            // lblBooksLoaned
            // 
            this.lblBooksLoaned.AutoSize = true;
            this.lblBooksLoaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksLoaned.Location = new System.Drawing.Point(6, 160);
            this.lblBooksLoaned.Name = "lblBooksLoaned";
            this.lblBooksLoaned.Size = new System.Drawing.Size(112, 31);
            this.lblBooksLoaned.TabIndex = 47;
            this.lblBooksLoaned.Text = "Loaned:";
            // 
            // lblBooksReserved
            // 
            this.lblBooksReserved.AutoSize = true;
            this.lblBooksReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksReserved.Location = new System.Drawing.Point(6, 100);
            this.lblBooksReserved.Name = "lblBooksReserved";
            this.lblBooksReserved.Size = new System.Drawing.Size(139, 31);
            this.lblBooksReserved.TabIndex = 46;
            this.lblBooksReserved.Text = "Reserved:";
            // 
            // grpBookDetails
            // 
            this.grpBookDetails.Controls.Add(this.txtBookPrice);
            this.grpBookDetails.Controls.Add(this.txtBookDescription);
            this.grpBookDetails.Controls.Add(this.txtBookThemes);
            this.grpBookDetails.Controls.Add(this.txtBookGenres);
            this.grpBookDetails.Controls.Add(this.txtBookPublisher);
            this.grpBookDetails.Controls.Add(this.txtBookAuthor);
            this.grpBookDetails.Controls.Add(this.txtBookMediaType);
            this.grpBookDetails.Controls.Add(this.txtBookISBN);
            this.grpBookDetails.Controls.Add(this.txtBookSeriesNumber);
            this.grpBookDetails.Controls.Add(this.txtBookSeriesTitle);
            this.grpBookDetails.Controls.Add(this.lblBookPrice);
            this.grpBookDetails.Controls.Add(this.lblBookDescription);
            this.grpBookDetails.Controls.Add(this.lblBookThemes);
            this.grpBookDetails.Controls.Add(this.lblBookGenres);
            this.grpBookDetails.Controls.Add(this.lblBookPublisher);
            this.grpBookDetails.Controls.Add(this.lblBookSeriesNumber);
            this.grpBookDetails.Controls.Add(this.lblBookTitleSeries);
            this.grpBookDetails.Controls.Add(this.lblBookMediaType);
            this.grpBookDetails.Controls.Add(this.lblBookAuthor);
            this.grpBookDetails.Controls.Add(this.lblBookISBN);
            this.grpBookDetails.Controls.Add(this.lblBookTitle);
            this.grpBookDetails.Controls.Add(this.txtBookTitle);
            this.grpBookDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookDetails.Location = new System.Drawing.Point(6, 22);
            this.grpBookDetails.Name = "grpBookDetails";
            this.grpBookDetails.Size = new System.Drawing.Size(1425, 936);
            this.grpBookDetails.TabIndex = 44;
            this.grpBookDetails.TabStop = false;
            this.grpBookDetails.Text = "Book Details";
            // 
            // txtBookPrice
            // 
            this.txtBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookPrice.Location = new System.Drawing.Point(211, 876);
            this.txtBookPrice.Name = "txtBookPrice";
            this.txtBookPrice.Size = new System.Drawing.Size(1197, 38);
            this.txtBookPrice.TabIndex = 41;
            // 
            // txtBookDescription
            // 
            this.txtBookDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookDescription.Location = new System.Drawing.Point(211, 577);
            this.txtBookDescription.Multiline = true;
            this.txtBookDescription.Name = "txtBookDescription";
            this.txtBookDescription.Size = new System.Drawing.Size(1197, 278);
            this.txtBookDescription.TabIndex = 20;
            // 
            // txtBookThemes
            // 
            this.txtBookThemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookThemes.Location = new System.Drawing.Point(211, 517);
            this.txtBookThemes.Name = "txtBookThemes";
            this.txtBookThemes.Size = new System.Drawing.Size(1197, 38);
            this.txtBookThemes.TabIndex = 19;
            // 
            // txtBookGenres
            // 
            this.txtBookGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookGenres.Location = new System.Drawing.Point(211, 457);
            this.txtBookGenres.Name = "txtBookGenres";
            this.txtBookGenres.Size = new System.Drawing.Size(1197, 38);
            this.txtBookGenres.TabIndex = 18;
            // 
            // txtBookPublisher
            // 
            this.txtBookPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookPublisher.Location = new System.Drawing.Point(211, 397);
            this.txtBookPublisher.Name = "txtBookPublisher";
            this.txtBookPublisher.Size = new System.Drawing.Size(1197, 38);
            this.txtBookPublisher.TabIndex = 17;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookAuthor.Location = new System.Drawing.Point(211, 337);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(1197, 38);
            this.txtBookAuthor.TabIndex = 16;
            // 
            // txtBookMediaType
            // 
            this.txtBookMediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookMediaType.Location = new System.Drawing.Point(211, 277);
            this.txtBookMediaType.Name = "txtBookMediaType";
            this.txtBookMediaType.Size = new System.Drawing.Size(1197, 38);
            this.txtBookMediaType.TabIndex = 15;
            // 
            // txtBookISBN
            // 
            this.txtBookISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookISBN.Location = new System.Drawing.Point(211, 217);
            this.txtBookISBN.Name = "txtBookISBN";
            this.txtBookISBN.Size = new System.Drawing.Size(1197, 38);
            this.txtBookISBN.TabIndex = 14;
            // 
            // txtBookSeriesNumber
            // 
            this.txtBookSeriesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookSeriesNumber.Location = new System.Drawing.Point(211, 157);
            this.txtBookSeriesNumber.Name = "txtBookSeriesNumber";
            this.txtBookSeriesNumber.Size = new System.Drawing.Size(1197, 38);
            this.txtBookSeriesNumber.TabIndex = 13;
            // 
            // txtBookSeriesTitle
            // 
            this.txtBookSeriesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookSeriesTitle.Location = new System.Drawing.Point(211, 97);
            this.txtBookSeriesTitle.Name = "txtBookSeriesTitle";
            this.txtBookSeriesTitle.Size = new System.Drawing.Size(1197, 38);
            this.txtBookSeriesTitle.TabIndex = 12;
            // 
            // lblBookPrice
            // 
            this.lblBookPrice.AutoSize = true;
            this.lblBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookPrice.Location = new System.Drawing.Point(10, 879);
            this.lblBookPrice.Name = "lblBookPrice";
            this.lblBookPrice.Size = new System.Drawing.Size(84, 31);
            this.lblBookPrice.TabIndex = 11;
            this.lblBookPrice.Text = "Price:";
            // 
            // lblBookDescription
            // 
            this.lblBookDescription.AutoSize = true;
            this.lblBookDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookDescription.Location = new System.Drawing.Point(10, 580);
            this.lblBookDescription.Name = "lblBookDescription";
            this.lblBookDescription.Size = new System.Drawing.Size(159, 31);
            this.lblBookDescription.TabIndex = 10;
            this.lblBookDescription.Text = "Description:";
            // 
            // lblBookThemes
            // 
            this.lblBookThemes.AutoSize = true;
            this.lblBookThemes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookThemes.Location = new System.Drawing.Point(10, 520);
            this.lblBookThemes.Name = "lblBookThemes";
            this.lblBookThemes.Size = new System.Drawing.Size(120, 31);
            this.lblBookThemes.TabIndex = 9;
            this.lblBookThemes.Text = "Themes:";
            // 
            // lblBookGenres
            // 
            this.lblBookGenres.AutoSize = true;
            this.lblBookGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookGenres.Location = new System.Drawing.Point(10, 460);
            this.lblBookGenres.Name = "lblBookGenres";
            this.lblBookGenres.Size = new System.Drawing.Size(111, 31);
            this.lblBookGenres.TabIndex = 8;
            this.lblBookGenres.Text = "Genres:";
            // 
            // lblBookPublisher
            // 
            this.lblBookPublisher.AutoSize = true;
            this.lblBookPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookPublisher.Location = new System.Drawing.Point(10, 400);
            this.lblBookPublisher.Name = "lblBookPublisher";
            this.lblBookPublisher.Size = new System.Drawing.Size(135, 31);
            this.lblBookPublisher.TabIndex = 7;
            this.lblBookPublisher.Text = "Publisher:";
            // 
            // lblBookSeriesNumber
            // 
            this.lblBookSeriesNumber.AutoSize = true;
            this.lblBookSeriesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookSeriesNumber.Location = new System.Drawing.Point(10, 160);
            this.lblBookSeriesNumber.Name = "lblBookSeriesNumber";
            this.lblBookSeriesNumber.Size = new System.Drawing.Size(197, 31);
            this.lblBookSeriesNumber.TabIndex = 6;
            this.lblBookSeriesNumber.Text = "Series number:";
            // 
            // lblBookTitleSeries
            // 
            this.lblBookTitleSeries.AutoSize = true;
            this.lblBookTitleSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitleSeries.Location = new System.Drawing.Point(10, 100);
            this.lblBookTitleSeries.Name = "lblBookTitleSeries";
            this.lblBookTitleSeries.Size = new System.Drawing.Size(149, 31);
            this.lblBookTitleSeries.TabIndex = 5;
            this.lblBookTitleSeries.Text = "Series title:";
            // 
            // lblBookMediaType
            // 
            this.lblBookMediaType.AutoSize = true;
            this.lblBookMediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookMediaType.Location = new System.Drawing.Point(10, 280);
            this.lblBookMediaType.Name = "lblBookMediaType";
            this.lblBookMediaType.Size = new System.Drawing.Size(154, 31);
            this.lblBookMediaType.TabIndex = 4;
            this.lblBookMediaType.Text = "Media type:";
            // 
            // lblBookAuthor
            // 
            this.lblBookAuthor.AutoSize = true;
            this.lblBookAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookAuthor.Location = new System.Drawing.Point(10, 340);
            this.lblBookAuthor.Name = "lblBookAuthor";
            this.lblBookAuthor.Size = new System.Drawing.Size(102, 31);
            this.lblBookAuthor.TabIndex = 3;
            this.lblBookAuthor.Text = "Author:";
            // 
            // lblBookISBN
            // 
            this.lblBookISBN.AutoSize = true;
            this.lblBookISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookISBN.Location = new System.Drawing.Point(10, 220);
            this.lblBookISBN.Name = "lblBookISBN";
            this.lblBookISBN.Size = new System.Drawing.Size(184, 31);
            this.lblBookISBN.TabIndex = 2;
            this.lblBookISBN.Text = "ISBN number:";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.Location = new System.Drawing.Point(10, 40);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(74, 31);
            this.lblBookTitle.TabIndex = 1;
            this.lblBookTitle.Text = "Title:";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookTitle.Location = new System.Drawing.Point(211, 37);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(1197, 38);
            this.txtBookTitle.TabIndex = 0;
            // 
            // grpBookCopyDetails
            // 
            this.grpBookCopyDetails.Controls.Add(this.btnBookDeleteCopies);
            this.grpBookCopyDetails.Controls.Add(this.btnBookAddCopies);
            this.grpBookCopyDetails.Controls.Add(this.lsvBookCopyDetails);
            this.grpBookCopyDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookCopyDetails.Location = new System.Drawing.Point(1437, 22);
            this.grpBookCopyDetails.Name = "grpBookCopyDetails";
            this.grpBookCopyDetails.Size = new System.Drawing.Size(327, 672);
            this.grpBookCopyDetails.TabIndex = 43;
            this.grpBookCopyDetails.TabStop = false;
            this.grpBookCopyDetails.Text = "Copies";
            // 
            // btnBookDeleteCopies
            // 
            this.btnBookDeleteCopies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBookDeleteCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookDeleteCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookDeleteCopies.Location = new System.Drawing.Point(171, 622);
            this.btnBookDeleteCopies.Name = "btnBookDeleteCopies";
            this.btnBookDeleteCopies.Size = new System.Drawing.Size(150, 41);
            this.btnBookDeleteCopies.TabIndex = 47;
            this.btnBookDeleteCopies.Text = "Add copies";
            this.btnBookDeleteCopies.UseVisualStyleBackColor = false;
            // 
            // btnBookAddCopies
            // 
            this.btnBookAddCopies.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBookAddCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAddCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookAddCopies.Location = new System.Drawing.Point(6, 622);
            this.btnBookAddCopies.Name = "btnBookAddCopies";
            this.btnBookAddCopies.Size = new System.Drawing.Size(150, 41);
            this.btnBookAddCopies.TabIndex = 46;
            this.btnBookAddCopies.Text = "Add copies";
            this.btnBookAddCopies.UseVisualStyleBackColor = false;
            this.btnBookAddCopies.Click += new System.EventHandler(this.btnBookAddCopies_Click);
            // 
            // lsvBookCopyDetails
            // 
            this.lsvBookCopyDetails.HideSelection = false;
            this.lsvBookCopyDetails.Location = new System.Drawing.Point(6, 37);
            this.lsvBookCopyDetails.Name = "lsvBookCopyDetails";
            this.lsvBookCopyDetails.Size = new System.Drawing.Size(315, 582);
            this.lsvBookCopyDetails.TabIndex = 0;
            this.lsvBookCopyDetails.UseCompatibleStateImageBehavior = false;
            // 
            // pnlSatistics
            // 
            this.pnlSatistics.Controls.Add(this.chtStatisticsChart);
            this.pnlSatistics.Controls.Add(this.grpStatisticsInputs);
            this.pnlSatistics.Location = new System.Drawing.Point(150, 100);
            this.pnlSatistics.Name = "pnlSatistics";
            this.pnlSatistics.Size = new System.Drawing.Size(1770, 980);
            this.pnlSatistics.TabIndex = 60;
            // 
            // chtStatisticsChart
            // 
            chartArea2.Name = "ChartArea1";
            this.chtStatisticsChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtStatisticsChart.Legends.Add(legend2);
            this.chtStatisticsChart.Location = new System.Drawing.Point(307, 36);
            this.chtStatisticsChart.Name = "chtStatisticsChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtStatisticsChart.Series.Add(series2);
            this.chtStatisticsChart.Size = new System.Drawing.Size(1429, 917);
            this.chtStatisticsChart.TabIndex = 0;
            this.chtStatisticsChart.Text = "chart1";
            // 
            // grpStatisticsInputs
            // 
            this.grpStatisticsInputs.Controls.Add(this.chkStatisticsTimeAsVariable);
            this.grpStatisticsInputs.Controls.Add(this.cmbStatisticsTimeInterval);
            this.grpStatisticsInputs.Controls.Add(this.cmbStatisticsTotalOrChange);
            this.grpStatisticsInputs.Controls.Add(this.btnStatisticsEnter);
            this.grpStatisticsInputs.Controls.Add(this.lblStatisticsVariables);
            this.grpStatisticsInputs.Controls.Add(this.txtStatisticsVariables);
            this.grpStatisticsInputs.Controls.Add(this.lblStatisticsVariableType);
            this.grpStatisticsInputs.Controls.Add(this.cmbStatisticsVariableType);
            this.grpStatisticsInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.grpStatisticsInputs.Location = new System.Drawing.Point(6, 19);
            this.grpStatisticsInputs.Name = "grpStatisticsInputs";
            this.grpStatisticsInputs.Size = new System.Drawing.Size(295, 934);
            this.grpStatisticsInputs.TabIndex = 8;
            this.grpStatisticsInputs.TabStop = false;
            this.grpStatisticsInputs.Text = "Chart Inputs";
            // 
            // chkStatisticsTimeAsVariable
            // 
            this.chkStatisticsTimeAsVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.chkStatisticsTimeAsVariable.Location = new System.Drawing.Point(6, 702);
            this.chkStatisticsTimeAsVariable.Name = "chkStatisticsTimeAsVariable";
            this.chkStatisticsTimeAsVariable.Size = new System.Drawing.Size(283, 60);
            this.chkStatisticsTimeAsVariable.TabIndex = 10;
            this.chkStatisticsTimeAsVariable.Text = "Use Time As Variable";
            this.chkStatisticsTimeAsVariable.UseVisualStyleBackColor = true;
            // 
            // cmbStatisticsTimeInterval
            // 
            this.cmbStatisticsTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatisticsTimeInterval.FormattingEnabled = true;
            this.cmbStatisticsTimeInterval.Location = new System.Drawing.Point(6, 811);
            this.cmbStatisticsTimeInterval.Name = "cmbStatisticsTimeInterval";
            this.cmbStatisticsTimeInterval.Size = new System.Drawing.Size(283, 33);
            this.cmbStatisticsTimeInterval.TabIndex = 9;
            // 
            // cmbStatisticsTotalOrChange
            // 
            this.cmbStatisticsTotalOrChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatisticsTotalOrChange.FormattingEnabled = true;
            this.cmbStatisticsTotalOrChange.Location = new System.Drawing.Point(6, 768);
            this.cmbStatisticsTotalOrChange.Name = "cmbStatisticsTotalOrChange";
            this.cmbStatisticsTotalOrChange.Size = new System.Drawing.Size(283, 33);
            this.cmbStatisticsTotalOrChange.TabIndex = 8;
            // 
            // btnStatisticsEnter
            // 
            this.btnStatisticsEnter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStatisticsEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatisticsEnter.Location = new System.Drawing.Point(6, 855);
            this.btnStatisticsEnter.Name = "btnStatisticsEnter";
            this.btnStatisticsEnter.Size = new System.Drawing.Size(283, 70);
            this.btnStatisticsEnter.TabIndex = 6;
            this.btnStatisticsEnter.Text = "Enter";
            this.btnStatisticsEnter.UseVisualStyleBackColor = false;
            // 
            // lblStatisticsVariables
            // 
            this.lblStatisticsVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsVariables.Location = new System.Drawing.Point(6, 113);
            this.lblStatisticsVariables.Name = "lblStatisticsVariables";
            this.lblStatisticsVariables.Size = new System.Drawing.Size(283, 40);
            this.lblStatisticsVariables.TabIndex = 7;
            this.lblStatisticsVariables.Text = "Field Options:";
            this.lblStatisticsVariables.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtStatisticsVariables
            // 
            this.txtStatisticsVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatisticsVariables.Location = new System.Drawing.Point(6, 157);
            this.txtStatisticsVariables.Multiline = true;
            this.txtStatisticsVariables.Name = "txtStatisticsVariables";
            this.txtStatisticsVariables.Size = new System.Drawing.Size(283, 531);
            this.txtStatisticsVariables.TabIndex = 2;
            // 
            // lblStatisticsVariableType
            // 
            this.lblStatisticsVariableType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsVariableType.Location = new System.Drawing.Point(6, 34);
            this.lblStatisticsVariableType.Name = "lblStatisticsVariableType";
            this.lblStatisticsVariableType.Size = new System.Drawing.Size(283, 40);
            this.lblStatisticsVariableType.TabIndex = 5;
            this.lblStatisticsVariableType.Text = "Field:";
            this.lblStatisticsVariableType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbStatisticsVariableType
            // 
            this.cmbStatisticsVariableType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatisticsVariableType.FormattingEnabled = true;
            this.cmbStatisticsVariableType.Location = new System.Drawing.Point(6, 77);
            this.cmbStatisticsVariableType.Name = "cmbStatisticsVariableType";
            this.cmbStatisticsVariableType.Size = new System.Drawing.Size(283, 33);
            this.cmbStatisticsVariableType.TabIndex = 3;
            // 
            // pnlBackup
            // 
            this.pnlBackup.Controls.Add(this.lblLastBackupDate);
            this.pnlBackup.Controls.Add(this.btnRestoreBackup);
            this.pnlBackup.Controls.Add(this.btnCreateBackup);
            this.pnlBackup.Location = new System.Drawing.Point(150, 100);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(1770, 980);
            this.pnlBackup.TabIndex = 61;
            // 
            // lblLastBackupDate
            // 
            this.lblLastBackupDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastBackupDate.Location = new System.Drawing.Point(735, 351);
            this.lblLastBackupDate.Name = "lblLastBackupDate";
            this.lblLastBackupDate.Size = new System.Drawing.Size(300, 60);
            this.lblLastBackupDate.TabIndex = 5;
            this.lblLastBackupDate.Text = "Last Backup Date: \r\n11:40:39 25/06/2023";
            this.lblLastBackupDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRestoreBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreBackup.Location = new System.Drawing.Point(735, 540);
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.Size = new System.Drawing.Size(300, 90);
            this.btnRestoreBackup.TabIndex = 4;
            this.btnRestoreBackup.Text = "Restore A Backup";
            this.btnRestoreBackup.UseVisualStyleBackColor = false;
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBackup.Location = new System.Drawing.Point(735, 423);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(300, 90);
            this.btnCreateBackup.TabIndex = 3;
            this.btnCreateBackup.Text = "Create Backup";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            // 
            // pctIcon
            // 
            this.pctIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctIcon.BackColor = System.Drawing.Color.White;
            this.pctIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctIcon.Location = new System.Drawing.Point(0, 0);
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.Size = new System.Drawing.Size(150, 150);
            this.pctIcon.TabIndex = 1;
            this.pctIcon.TabStop = false;
            this.pctIcon.Click += new System.EventHandler(this.pctIcon_Click);
            // 
            // pnlMainTabs
            // 
            this.pnlMainTabs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMainTabs.Controls.Add(this.pctIcon);
            this.pnlMainTabs.Controls.Add(this.btnBooks);
            this.pnlMainTabs.Controls.Add(this.btnMembers);
            this.pnlMainTabs.Controls.Add(this.btnTransactions);
            this.pnlMainTabs.Controls.Add(this.btnStaff);
            this.pnlMainTabs.Controls.Add(this.btnStatistics);
            this.pnlMainTabs.Controls.Add(this.btnBackups);
            this.pnlMainTabs.Controls.Add(this.btnSettings);
            this.pnlMainTabs.Controls.Add(this.btnLogOut);
            this.pnlMainTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTabs.Name = "pnlMainTabs";
            this.pnlMainTabs.Size = new System.Drawing.Size(150, 1080);
            this.pnlMainTabs.TabIndex = 31;
            // 
            // pnlSubTabs
            // 
            this.pnlSubTabs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSubTabs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlSubTabs.Controls.Add(this.btnSubTab1);
            this.pnlSubTabs.Controls.Add(this.btnSubTab2);
            this.pnlSubTabs.Controls.Add(this.btnSubTab3);
            this.pnlSubTabs.Controls.Add(this.btnSubTab4);
            this.pnlSubTabs.Controls.Add(this.btnSubTab5);
            this.pnlSubTabs.Controls.Add(this.btnSubTab6);
            this.pnlSubTabs.Controls.Add(this.btnSubTab7);
            this.pnlSubTabs.Controls.Add(this.lblMessageOutput);
            this.pnlSubTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubTabs.Location = new System.Drawing.Point(150, 0);
            this.pnlSubTabs.Margin = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.pnlSubTabs.Name = "pnlSubTabs";
            this.pnlSubTabs.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
            this.pnlSubTabs.Size = new System.Drawing.Size(1770, 100);
            this.pnlSubTabs.TabIndex = 31;
            // 
            // frmMainSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlSubTabs);
            this.Controls.Add(this.pnlMainTabs);
            this.Controls.Add(this.pnlSell);
            this.Controls.Add(this.pnlCheckIn);
            this.Controls.Add(this.pnlBookDetails);
            this.Controls.Add(this.pnlReservation);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlCheckOut);
            this.Controls.Add(this.pnlMember);
            this.Controls.Add(this.pnlSatistics);
            this.Controls.Add(this.pnlDelete);
            this.Controls.Add(this.pnlBackup);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.pnlStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "frmMainSystem";
            this.Text = "Main System";
            this.Load += new System.EventHandler(this.frmMainSystem_Load);
            this.pnlReservation.ResumeLayout(false);
            this.pnlReservation.PerformLayout();
            this.pnlMember.ResumeLayout(false);
            this.pnlMember.PerformLayout();
            this.grpMemberBookLinks.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.grpRunningTotal.ResumeLayout(false);
            this.grpRunningTotal.PerformLayout();
            this.pnlStaff.ResumeLayout(false);
            this.pnlStaff.PerformLayout();
            this.pnlCheckOut.ResumeLayout(false);
            this.pnlCheckOut.PerformLayout();
            this.pnlDelete.ResumeLayout(false);
            this.pnlDelete.PerformLayout();
            this.pnlSell.ResumeLayout(false);
            this.pnlSell.PerformLayout();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.pnlCheckIn.ResumeLayout(false);
            this.pnlCheckIn.PerformLayout();
            this.pnlBookDetails.ResumeLayout(false);
            this.grpBooksBookStatus.ResumeLayout(false);
            this.grpBooksBookStatus.PerformLayout();
            this.grpBookDetails.ResumeLayout(false);
            this.grpBookDetails.PerformLayout();
            this.grpBookCopyDetails.ResumeLayout(false);
            this.pnlSatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtStatisticsChart)).EndInit();
            this.grpStatisticsInputs.ResumeLayout(false);
            this.grpStatisticsInputs.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            this.pnlMainTabs.ResumeLayout(false);
            this.pnlSubTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pctIcon;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnBackups;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSubTab1;
        private System.Windows.Forms.Button btnSubTab2;
        private System.Windows.Forms.Button btnSubTab3;
        private System.Windows.Forms.Button btnSubTab4;
        private System.Windows.Forms.Button btnSubTab5;
        private System.Windows.Forms.Button btnSubTab6;
        private System.Windows.Forms.Button btnSubTab7;
        private System.Windows.Forms.Label lblMessageOutput;
        private System.Windows.Forms.Panel pnlReservation;
        private System.Windows.Forms.DateTimePicker dtpReservationPickUpBy;
        private System.Windows.Forms.Button btnReservationCancel;
        private System.Windows.Forms.Button btnReservationSave;
        private System.Windows.Forms.Label lblReservationSetDueDate;
        private System.Windows.Forms.TextBox txtReservationLateBooks;
        private System.Windows.Forms.Label lblReservationOverdueBooks;
        private System.Windows.Forms.ListView lsvReservationSelectedBooks;
        private System.Windows.Forms.Label txtReservationSelectedBooks;
        private System.Windows.Forms.TextBox txtReservationCurrentMemberCheckOuts;
        private System.Windows.Forms.Label lblReservationCurrentMemberCheckOuts;
        private System.Windows.Forms.TextBox txtReservationMemberBarcode;
        private System.Windows.Forms.Label lblReservationMemberBarcode;
        private System.Windows.Forms.TextBox txtReservationMemberName;
        private System.Windows.Forms.Label lblReservationMemberName;
        private System.Windows.Forms.Panel pnlMember;
        private System.Windows.Forms.GroupBox grpMemberBookLinks;
        private System.Windows.Forms.ListView lsvMemberBookLinks;
        private System.Windows.Forms.TextBox txtMemberJoinDate;
        private System.Windows.Forms.Label lblMemberJoinDate;
        private System.Windows.Forms.TextBox txtMemberPostcode;
        private System.Windows.Forms.TextBox txtMemberAddressLine4;
        private System.Windows.Forms.TextBox txtMemberAddressLine5;
        private System.Windows.Forms.Label lblMemberPostcode;
        private System.Windows.Forms.Label lblMemberAssociatedMemberBarcodes;
        private System.Windows.Forms.TextBox txtMemberAddressLine1;
        private System.Windows.Forms.Label lblMemberAddressLine3;
        private System.Windows.Forms.Button btnMemberCancel;
        private System.Windows.Forms.TextBox txtMemberBarcode;
        private System.Windows.Forms.Button btnMemberSave;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.TextBox txtMemberAssociatedMemberBarcodes;
        private System.Windows.Forms.TextBox txtMemberCustomerType;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblMemberAddressLine2;
        private System.Windows.Forms.TextBox txtMemberDateOfBirth;
        private System.Windows.Forms.Label lblMemberAddressLine5;
        private System.Windows.Forms.TextBox txtMemberAddressLine3;
        private System.Windows.Forms.TextBox txtMemberAddressLine2;
        private System.Windows.Forms.Label lblMemberSurname;
        private System.Windows.Forms.Label lblMemberAddressLine4;
        private System.Windows.Forms.Label lblMemberAddressLine1;
        private System.Windows.Forms.TextBox txtMemberEmailAddress;
        private System.Windows.Forms.TextBox txtMemberPhoneNumber;
        private System.Windows.Forms.Label lblMemberDateOfBirth;
        private System.Windows.Forms.Label lblMemberCustomerType;
        private System.Windows.Forms.Label lblMemberEmailAddress;
        private System.Windows.Forms.Label lblMemberBarcode;
        private System.Windows.Forms.TextBox txtMemberSurname;
        private System.Windows.Forms.Label lblMemberPhoneNumber;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchField;
        private System.Windows.Forms.ComboBox cmbSearchField;
        private System.Windows.Forms.GroupBox grpRunningTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRunninGTotalOutput;
        private System.Windows.Forms.Label lblRunningTotal;
        private System.Windows.Forms.Button btnSetRunningTotalDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRunningTotalDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRunningTotalTime;
        private System.Windows.Forms.Button btnResetRunningTotal;
        private System.Windows.Forms.ListView lsvSearchItems;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader SeriesTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtFilter2;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.TextBox txtFilter1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnresetFilters;
        private System.Windows.Forms.Label lblFilter1;
        private System.Windows.Forms.Label lblFilter2;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.ComboBox cmbFilter2;
        private System.Windows.Forms.ComboBox cmbFilter1;
        private System.Windows.Forms.Panel pnlStaff;
        private System.Windows.Forms.Button btnStaffPasswordVisibility;
        private System.Windows.Forms.Label lblStaffAccessLevel;
        private System.Windows.Forms.TextBox txtStaffPassword;
        private System.Windows.Forms.Label lblStaffPassword;
        private System.Windows.Forms.Label lblStaffMemberBarcode;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Button btnStaffCancel;
        private System.Windows.Forms.Button btnStaffSave;
        private System.Windows.Forms.Panel pnlCheckOut;
        private System.Windows.Forms.Label lblCheckOutSetDueDate;
        private System.Windows.Forms.TextBox txtCheckOutLateBooks;
        private System.Windows.Forms.Label lblCheckOutOverdueBooks;
        private System.Windows.Forms.ListView lsvCheckOutSelectedBooks;
        private System.Windows.Forms.Label txtCheckOutSelectedBooks;
        private System.Windows.Forms.TextBox txtCheckOutCurrentMemberCheckOuts;
        private System.Windows.Forms.Label lblCheckOutCurrentMemberCheckOuts;
        private System.Windows.Forms.TextBox txtCheckOutMemberBarcode;
        private System.Windows.Forms.Label lblCheckOutMemberBarcode;
        private System.Windows.Forms.TextBox txtCheckOutMemberName;
        private System.Windows.Forms.Label lblCheckOutMemberName;
        private System.Windows.Forms.Button btnCheckOutSave;
        private System.Windows.Forms.Button btnCheckOutCancel;
        private System.Windows.Forms.Panel pnlSell;
        private System.Windows.Forms.TextBox txtCheckOutPrice;
        private System.Windows.Forms.Label lblCheckOutPrice;
        private System.Windows.Forms.TextBox txtSellOverdueBooks;
        private System.Windows.Forms.Label lblSellBooksOverdueBooks;
        private System.Windows.Forms.ListView lsvSellSelectedBooks;
        private System.Windows.Forms.Label lblSellSelectedBooks;
        private System.Windows.Forms.TextBox txtSellLoans;
        private System.Windows.Forms.Label lblSellLoans;
        private System.Windows.Forms.TextBox txtSellMemberBarcode;
        private System.Windows.Forms.Label lblSellMemberBarcode;
        private System.Windows.Forms.TextBox txtSellMemberName;
        private System.Windows.Forms.Label lblSellMemberName;
        private System.Windows.Forms.Button btnSellCancel;
        private System.Windows.Forms.Button btnSellSave;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Label lblDefaultSettings;
        private System.Windows.Forms.TextBox txtSettingDefault;
        private System.Windows.Forms.ComboBox cmbSettingDefault2;
        private System.Windows.Forms.ComboBox cmbSettingDefault3;
        private System.Windows.Forms.ComboBox cmbSettingDefault1;
        private System.Windows.Forms.Button btnGmailKeyIsVisible;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label lblSettingGmailKey;
        private System.Windows.Forms.Button btnSettingCancel;
        private System.Windows.Forms.Button btnSettingSave;
        private System.Windows.Forms.TextBox txtCheckInLateFees;
        private System.Windows.Forms.Label lblCheckInLateFees;
        private System.Windows.Forms.TextBox txtCheckInOverdue;
        private System.Windows.Forms.Label lblCheckInOverdue;
        private System.Windows.Forms.ListView lsvCheckInSelectedBooks;
        private System.Windows.Forms.Label lblCheckInSelectedBooks;
        private System.Windows.Forms.TextBox txtCheckInLoans;
        private System.Windows.Forms.Label lblCheckInLoans;
        private System.Windows.Forms.TextBox txtCheckInMemberBarcode;
        private System.Windows.Forms.Label lblCheckInMemberBarcode;
        private System.Windows.Forms.TextBox txtCheckInMemberName;
        private System.Windows.Forms.Label lblCheckInMemberName;
        private System.Windows.Forms.Button btnCheckInCancel;
        private System.Windows.Forms.Button btnCheckInSave;
        private System.Windows.Forms.Panel pnlBookDetails;
        private System.Windows.Forms.Button btnBookSave;
        private System.Windows.Forms.Button btnBookCancel;
        private System.Windows.Forms.GroupBox grpBooksBookStatus;
        private System.Windows.Forms.TextBox txtLoaned;
        private System.Windows.Forms.Label lblBooksInStock;
        private System.Windows.Forms.TextBox txtBooksReserved;
        private System.Windows.Forms.TextBox txtBooksInStock;
        private System.Windows.Forms.Label lblBooksLoaned;
        private System.Windows.Forms.Label lblBooksReserved;
        private System.Windows.Forms.GroupBox grpBookDetails;
        private System.Windows.Forms.TextBox txtBookPrice;
        private System.Windows.Forms.TextBox txtBookDescription;
        private System.Windows.Forms.TextBox txtBookThemes;
        private System.Windows.Forms.TextBox txtBookGenres;
        private System.Windows.Forms.TextBox txtBookPublisher;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookMediaType;
        private System.Windows.Forms.TextBox txtBookISBN;
        private System.Windows.Forms.TextBox txtBookSeriesNumber;
        private System.Windows.Forms.TextBox txtBookSeriesTitle;
        private System.Windows.Forms.Label lblBookPrice;
        private System.Windows.Forms.Label lblBookDescription;
        private System.Windows.Forms.Label lblBookThemes;
        private System.Windows.Forms.Label lblBookGenres;
        private System.Windows.Forms.Label lblBookPublisher;
        private System.Windows.Forms.Label lblBookSeriesNumber;
        private System.Windows.Forms.Label lblBookTitleSeries;
        private System.Windows.Forms.Label lblBookMediaType;
        private System.Windows.Forms.Label lblBookAuthor;
        private System.Windows.Forms.Label lblBookISBN;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.GroupBox grpBookCopyDetails;
        private System.Windows.Forms.ListView lsvBookCopyDetails;
        private System.Windows.Forms.Panel pnlSatistics;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtStatisticsChart;
        private System.Windows.Forms.GroupBox grpStatisticsInputs;
        private System.Windows.Forms.ComboBox cmbStatisticsTimeInterval;
        private System.Windows.Forms.ComboBox cmbStatisticsTotalOrChange;
        private System.Windows.Forms.Button btnStatisticsEnter;
        private System.Windows.Forms.Label lblStatisticsVariables;
        private System.Windows.Forms.TextBox txtStatisticsVariables;
        private System.Windows.Forms.Label lblStatisticsVariableType;
        private System.Windows.Forms.ComboBox cmbStatisticsVariableType;
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.Label lblLastBackupDate;
        private System.Windows.Forms.Button btnRestoreBackup;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbStaffAccessLevel;
        private System.Windows.Forms.CheckBox chkSearchCopyBarcodes;
        private System.Windows.Forms.Panel pnlDelete;
        private System.Windows.Forms.ListView lsvDelete;
        private System.Windows.Forms.Label lblDeleteSelectedRecords;
        private System.Windows.Forms.Label lblDeleteTitle;
        private System.Windows.Forms.Button btnDeleteCancel;
        private System.Windows.Forms.Button btnDeleteDelete;
        private System.Windows.Forms.Button btnBookAddCopies;
        private System.Windows.Forms.CheckBox chkStatisticsTimeAsVariable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStaffMemberRecord;
        private System.Windows.Forms.Button btnBookDeleteCopies;
        private System.Windows.Forms.Label lblCheckInEnterBarcode;
        private System.Windows.Forms.TextBox txtCheckInEnterBarcode;
        private System.Windows.Forms.Panel pnlCheckIn;
        private System.Windows.Forms.Panel pnlMainTabs;
        private System.Windows.Forms.Panel pnlSubTabs;
    }
}