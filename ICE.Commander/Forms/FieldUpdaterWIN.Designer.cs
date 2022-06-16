namespace ICE.Commander
{
    partial class FieldUpdaterWIN
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.LoanNumber = new System.Windows.Forms.TextBox();
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this.LoadLoan = new System.Windows.Forms.Button();
            this._loanDetails = new System.Windows.Forms.TabControl();
            this._loanFields = new System.Windows.Forms.TabPage();
            this._listFields = new System.Windows.Forms.ListView();
            this._dynamicFields = new System.Windows.Forms.TabPage();
            this._listDynamicFields = new System.Windows.Forms.ListView();
            this._customFields = new System.Windows.Forms.TabPage();
            this.ListCustomFields = new System.Windows.Forms.ListView();
            this._virtualFields = new System.Windows.Forms.TabPage();
            this.ListVirtualFields = new System.Windows.Forms.ListView();
            this._documents = new System.Windows.Forms.TabPage();
            this.ListDocuments = new System.Windows.Forms.ListView();
            this._milestones = new System.Windows.Forms.TabPage();
            this.ListMilestones = new System.Windows.Forms.ListView();
            this._UWConditions = new System.Windows.Forms.TabPage();
            this.ListUWConditions = new System.Windows.Forms.ListView();
            this._rateLocks = new System.Windows.Forms.TabPage();
            this.ListRateLocks = new System.Windows.Forms.ListView();
            this._users = new System.Windows.Forms.TabPage();
            this.ListUsers = new System.Windows.Forms.ListView();
            this._serialized = new System.Windows.Forms.TabPage();
            this.JSonText = new System.Windows.Forms.TextBox();
            this._enhConditions = new System.Windows.Forms.TabPage();
            this.ListEnhancedConditions = new System.Windows.Forms.ListView();
            this.enhancedConditionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FieldSearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.ViewPipeline = new System.Windows.Forms.Button();
            this.LoanLockStatus = new System.Windows.Forms.Label();
            this.RunninStatus = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this._loanDetails.SuspendLayout();
            this._loanFields.SuspendLayout();
            this._dynamicFields.SuspendLayout();
            this._customFields.SuspendLayout();
            this._virtualFields.SuspendLayout();
            this._documents.SuspendLayout();
            this._milestones.SuspendLayout();
            this._UWConditions.SuspendLayout();
            this._rateLocks.SuspendLayout();
            this._users.SuspendLayout();
            this._serialized.SuspendLayout();
            this._enhConditions.SuspendLayout();
            this.enhancedConditionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(339, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 13);
            label1.TabIndex = 0;
            label1.Text = "Loan Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 13);
            label2.TabIndex = 2;
            label2.Text = "Ellie Instance";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(915, 25);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 13);
            label3.TabIndex = 6;
            label3.Text = "Field Search";
            // 
            // LoanNumber
            // 
            this.LoanNumber.Location = new System.Drawing.Point(416, 22);
            this.LoanNumber.Name = "LoanNumber";
            this.LoanNumber.Size = new System.Drawing.Size(113, 20);
            this.LoanNumber.TabIndex = 1;
            this.LoanNumber.TextChanged += new System.EventHandler(this.LoanNumber_TextChanged);
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(93, 21);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(204, 21);
            this.EllieInstance.TabIndex = 3;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // LoadLoan
            // 
            this.LoadLoan.Location = new System.Drawing.Point(549, 19);
            this.LoadLoan.Name = "LoadLoan";
            this.LoadLoan.Size = new System.Drawing.Size(75, 23);
            this.LoadLoan.TabIndex = 4;
            this.LoadLoan.Text = "Load Loan";
            this.LoadLoan.UseVisualStyleBackColor = true;
            this.LoadLoan.Click += new System.EventHandler(this.LoadLoan_Click);
            // 
            // _loanDetails
            // 
            this._loanDetails.Controls.Add(this._loanFields);
            this._loanDetails.Controls.Add(this._dynamicFields);
            this._loanDetails.Controls.Add(this._customFields);
            this._loanDetails.Controls.Add(this._virtualFields);
            this._loanDetails.Controls.Add(this._documents);
            this._loanDetails.Controls.Add(this._milestones);
            this._loanDetails.Controls.Add(this._UWConditions);
            this._loanDetails.Controls.Add(this._rateLocks);
            this._loanDetails.Controls.Add(this._users);
            this._loanDetails.Controls.Add(this._serialized);
            this._loanDetails.Controls.Add(this._enhConditions);
            this._loanDetails.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this._loanDetails.Location = new System.Drawing.Point(12, 64);
            this._loanDetails.Name = "_loanDetails";
            this._loanDetails.SelectedIndex = 0;
            this._loanDetails.Size = new System.Drawing.Size(1251, 675);
            this._loanDetails.TabIndex = 3;
            this._loanDetails.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LoanDetails_DrawItem);
            this._loanDetails.SelectedIndexChanged += new System.EventHandler(this.LoanDetails_SelectedIndexChanged);
            // 
            // _loanFields
            // 
            this._loanFields.Controls.Add(this._listFields);
            this._loanFields.Location = new System.Drawing.Point(4, 22);
            this._loanFields.Name = "_loanFields";
            this._loanFields.Padding = new System.Windows.Forms.Padding(3);
            this._loanFields.Size = new System.Drawing.Size(1243, 649);
            this._loanFields.TabIndex = 0;
            this._loanFields.Text = "Fields";
            this._loanFields.UseVisualStyleBackColor = true;
            // 
            // _listFields
            // 
            this._listFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listFields.FullRowSelect = true;
            this._listFields.GridLines = true;
            this._listFields.HideSelection = false;
            this._listFields.Location = new System.Drawing.Point(3, 3);
            this._listFields.Name = "_listFields";
            this._listFields.Size = new System.Drawing.Size(1237, 643);
            this._listFields.TabIndex = 0;
            this._listFields.UseCompatibleStateImageBehavior = false;
            this._listFields.View = System.Windows.Forms.View.Details;
            this._listFields.DoubleClick += new System.EventHandler(this.ListFields_DoubleClick);
            // 
            // _dynamicFields
            // 
            this._dynamicFields.Controls.Add(this._listDynamicFields);
            this._dynamicFields.Location = new System.Drawing.Point(4, 22);
            this._dynamicFields.Name = "_dynamicFields";
            this._dynamicFields.Padding = new System.Windows.Forms.Padding(3);
            this._dynamicFields.Size = new System.Drawing.Size(1243, 649);
            this._dynamicFields.TabIndex = 5;
            this._dynamicFields.Text = "Dynamic Fields";
            this._dynamicFields.UseVisualStyleBackColor = true;
            // 
            // _listDynamicFields
            // 
            this._listDynamicFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listDynamicFields.FullRowSelect = true;
            this._listDynamicFields.GridLines = true;
            this._listDynamicFields.HideSelection = false;
            this._listDynamicFields.Location = new System.Drawing.Point(3, 3);
            this._listDynamicFields.Name = "_listDynamicFields";
            this._listDynamicFields.Size = new System.Drawing.Size(1237, 643);
            this._listDynamicFields.TabIndex = 1;
            this._listDynamicFields.UseCompatibleStateImageBehavior = false;
            this._listDynamicFields.View = System.Windows.Forms.View.Details;
            // 
            // _customFields
            // 
            this._customFields.Controls.Add(this.ListCustomFields);
            this._customFields.Location = new System.Drawing.Point(4, 22);
            this._customFields.Name = "_customFields";
            this._customFields.Padding = new System.Windows.Forms.Padding(3);
            this._customFields.Size = new System.Drawing.Size(1243, 649);
            this._customFields.TabIndex = 1;
            this._customFields.Text = "Custom Fields";
            this._customFields.UseVisualStyleBackColor = true;
            // 
            // ListCustomFields
            // 
            this.ListCustomFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListCustomFields.FullRowSelect = true;
            this.ListCustomFields.GridLines = true;
            this.ListCustomFields.HideSelection = false;
            this.ListCustomFields.Location = new System.Drawing.Point(3, 3);
            this.ListCustomFields.Name = "ListCustomFields";
            this.ListCustomFields.Size = new System.Drawing.Size(1237, 643);
            this.ListCustomFields.TabIndex = 2;
            this.ListCustomFields.UseCompatibleStateImageBehavior = false;
            this.ListCustomFields.View = System.Windows.Forms.View.Details;
            this.ListCustomFields.DoubleClick += new System.EventHandler(this.ListCustomFields_DoubleClick);
            // 
            // _virtualFields
            // 
            this._virtualFields.Controls.Add(this.ListVirtualFields);
            this._virtualFields.Location = new System.Drawing.Point(4, 22);
            this._virtualFields.Name = "_virtualFields";
            this._virtualFields.Padding = new System.Windows.Forms.Padding(3);
            this._virtualFields.Size = new System.Drawing.Size(1243, 649);
            this._virtualFields.TabIndex = 4;
            this._virtualFields.Text = "Virtual Fields";
            this._virtualFields.UseVisualStyleBackColor = true;
            // 
            // ListVirtualFields
            // 
            this.ListVirtualFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListVirtualFields.FullRowSelect = true;
            this.ListVirtualFields.GridLines = true;
            this.ListVirtualFields.HideSelection = false;
            this.ListVirtualFields.Location = new System.Drawing.Point(3, 3);
            this.ListVirtualFields.Name = "ListVirtualFields";
            this.ListVirtualFields.Size = new System.Drawing.Size(1237, 643);
            this.ListVirtualFields.TabIndex = 3;
            this.ListVirtualFields.UseCompatibleStateImageBehavior = false;
            this.ListVirtualFields.View = System.Windows.Forms.View.Details;
            // 
            // _documents
            // 
            this._documents.Controls.Add(this.ListDocuments);
            this._documents.Location = new System.Drawing.Point(4, 22);
            this._documents.Name = "_documents";
            this._documents.Padding = new System.Windows.Forms.Padding(3);
            this._documents.Size = new System.Drawing.Size(1243, 649);
            this._documents.TabIndex = 6;
            this._documents.Text = "Document List";
            this._documents.UseVisualStyleBackColor = true;
            // 
            // ListDocuments
            // 
            this.ListDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDocuments.FullRowSelect = true;
            this.ListDocuments.GridLines = true;
            this.ListDocuments.HideSelection = false;
            this.ListDocuments.Location = new System.Drawing.Point(3, 3);
            this.ListDocuments.Name = "ListDocuments";
            this.ListDocuments.Size = new System.Drawing.Size(1237, 643);
            this.ListDocuments.TabIndex = 2;
            this.ListDocuments.UseCompatibleStateImageBehavior = false;
            this.ListDocuments.View = System.Windows.Forms.View.Details;
            this.ListDocuments.DoubleClick += new System.EventHandler(this.ListDocuments_DoubleClick);
            // 
            // _milestones
            // 
            this._milestones.Controls.Add(this.ListMilestones);
            this._milestones.Location = new System.Drawing.Point(4, 22);
            this._milestones.Name = "_milestones";
            this._milestones.Padding = new System.Windows.Forms.Padding(3);
            this._milestones.Size = new System.Drawing.Size(1243, 649);
            this._milestones.TabIndex = 8;
            this._milestones.Text = "Milestones";
            this._milestones.UseVisualStyleBackColor = true;
            // 
            // ListMilestones
            // 
            this.ListMilestones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListMilestones.FullRowSelect = true;
            this.ListMilestones.GridLines = true;
            this.ListMilestones.HideSelection = false;
            this.ListMilestones.Location = new System.Drawing.Point(3, 3);
            this.ListMilestones.Name = "ListMilestones";
            this.ListMilestones.Size = new System.Drawing.Size(1237, 643);
            this.ListMilestones.TabIndex = 2;
            this.ListMilestones.UseCompatibleStateImageBehavior = false;
            this.ListMilestones.View = System.Windows.Forms.View.Details;
            // 
            // _UWConditions
            // 
            this._UWConditions.Controls.Add(this.ListUWConditions);
            this._UWConditions.Location = new System.Drawing.Point(4, 22);
            this._UWConditions.Name = "_UWConditions";
            this._UWConditions.Padding = new System.Windows.Forms.Padding(3);
            this._UWConditions.Size = new System.Drawing.Size(1243, 649);
            this._UWConditions.TabIndex = 9;
            this._UWConditions.Text = "UW Conditions";
            this._UWConditions.UseVisualStyleBackColor = true;
            // 
            // ListUWConditions
            // 
            this.ListUWConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListUWConditions.FullRowSelect = true;
            this.ListUWConditions.GridLines = true;
            this.ListUWConditions.HideSelection = false;
            this.ListUWConditions.Location = new System.Drawing.Point(3, 3);
            this.ListUWConditions.Name = "ListUWConditions";
            this.ListUWConditions.Size = new System.Drawing.Size(1237, 643);
            this.ListUWConditions.TabIndex = 3;
            this.ListUWConditions.UseCompatibleStateImageBehavior = false;
            this.ListUWConditions.View = System.Windows.Forms.View.Details;
            // 
            // _rateLocks
            // 
            this._rateLocks.Controls.Add(this.ListRateLocks);
            this._rateLocks.Location = new System.Drawing.Point(4, 22);
            this._rateLocks.Name = "_rateLocks";
            this._rateLocks.Padding = new System.Windows.Forms.Padding(3);
            this._rateLocks.Size = new System.Drawing.Size(1243, 649);
            this._rateLocks.TabIndex = 10;
            this._rateLocks.Text = "Rate Locks";
            this._rateLocks.UseVisualStyleBackColor = true;
            // 
            // ListRateLocks
            // 
            this.ListRateLocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListRateLocks.FullRowSelect = true;
            this.ListRateLocks.GridLines = true;
            this.ListRateLocks.HideSelection = false;
            this.ListRateLocks.Location = new System.Drawing.Point(3, 3);
            this.ListRateLocks.Name = "ListRateLocks";
            this.ListRateLocks.Size = new System.Drawing.Size(1237, 643);
            this.ListRateLocks.TabIndex = 4;
            this.ListRateLocks.UseCompatibleStateImageBehavior = false;
            this.ListRateLocks.View = System.Windows.Forms.View.Details;
            this.ListRateLocks.DoubleClick += new System.EventHandler(this.ListRateLocks_DoubleClick);
            // 
            // _users
            // 
            this._users.Controls.Add(this.ListUsers);
            this._users.Location = new System.Drawing.Point(4, 22);
            this._users.Name = "_users";
            this._users.Padding = new System.Windows.Forms.Padding(3);
            this._users.Size = new System.Drawing.Size(1243, 649);
            this._users.TabIndex = 2;
            this._users.Text = "Users";
            this._users.UseVisualStyleBackColor = true;
            // 
            // ListUsers
            // 
            this.ListUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListUsers.FullRowSelect = true;
            this.ListUsers.GridLines = true;
            this.ListUsers.HideSelection = false;
            this.ListUsers.Location = new System.Drawing.Point(3, 3);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(1237, 643);
            this.ListUsers.TabIndex = 1;
            this.ListUsers.UseCompatibleStateImageBehavior = false;
            this.ListUsers.View = System.Windows.Forms.View.Details;
            // 
            // _serialized
            // 
            this._serialized.Controls.Add(this.JSonText);
            this._serialized.Location = new System.Drawing.Point(4, 22);
            this._serialized.Name = "_serialized";
            this._serialized.Padding = new System.Windows.Forms.Padding(3);
            this._serialized.Size = new System.Drawing.Size(1243, 649);
            this._serialized.TabIndex = 3;
            this._serialized.Text = "Serialized";
            this._serialized.UseVisualStyleBackColor = true;
            // 
            // JSonText
            // 
            this.JSonText.Cursor = System.Windows.Forms.Cursors.No;
            this.JSonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JSonText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JSonText.Location = new System.Drawing.Point(3, 3);
            this.JSonText.Multiline = true;
            this.JSonText.Name = "JSonText";
            this.JSonText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.JSonText.Size = new System.Drawing.Size(1237, 643);
            this.JSonText.TabIndex = 0;
            // 
            // _enhConditions
            // 
            this._enhConditions.Controls.Add(this.ListEnhancedConditions);
            this._enhConditions.Location = new System.Drawing.Point(4, 22);
            this._enhConditions.Name = "_enhConditions";
            this._enhConditions.Padding = new System.Windows.Forms.Padding(3);
            this._enhConditions.Size = new System.Drawing.Size(1243, 649);
            this._enhConditions.TabIndex = 11;
            this._enhConditions.Text = "Enhanced Conditions";
            this._enhConditions.UseVisualStyleBackColor = true;
            // 
            // ListEnhancedConditions
            // 
            this.ListEnhancedConditions.ContextMenuStrip = this.enhancedConditionMenu;
            this.ListEnhancedConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListEnhancedConditions.FullRowSelect = true;
            this.ListEnhancedConditions.GridLines = true;
            this.ListEnhancedConditions.HideSelection = false;
            this.ListEnhancedConditions.Location = new System.Drawing.Point(3, 3);
            this.ListEnhancedConditions.Name = "ListEnhancedConditions";
            this.ListEnhancedConditions.Size = new System.Drawing.Size(1237, 643);
            this.ListEnhancedConditions.TabIndex = 1;
            this.ListEnhancedConditions.UseCompatibleStateImageBehavior = false;
            this.ListEnhancedConditions.View = System.Windows.Forms.View.Details;
            this.ListEnhancedConditions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListEnhancedConditions_MouseClick);
            // 
            // enhancedConditionMenu
            // 
            this.enhancedConditionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.enhancedConditionMenu.Name = "enhancedConditionMenu";
            this.enhancedConditionMenu.Size = new System.Drawing.Size(110, 98);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.EHDetails);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.EHAdd);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.EHEdit);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.EHDelete);
            // 
            // FieldSearch
            // 
            this.FieldSearch.Enabled = false;
            this.FieldSearch.Location = new System.Drawing.Point(992, 22);
            this.FieldSearch.Name = "FieldSearch";
            this.FieldSearch.Size = new System.Drawing.Size(132, 20);
            this.FieldSearch.TabIndex = 5;
            // 
            // Search
            // 
            this.Search.Enabled = false;
            this.Search.Location = new System.Drawing.Point(1130, 19);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 7;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // ViewPipeline
            // 
            this.ViewPipeline.Location = new System.Drawing.Point(303, 20);
            this.ViewPipeline.Name = "ViewPipeline";
            this.ViewPipeline.Size = new System.Drawing.Size(26, 23);
            this.ViewPipeline.TabIndex = 8;
            this.ViewPipeline.Text = "?";
            this.ViewPipeline.UseVisualStyleBackColor = true;
            this.ViewPipeline.Click += new System.EventHandler(this.ViewPipeline_Click);
            // 
            // LoanLockStatus
            // 
            this.LoanLockStatus.AutoSize = true;
            this.LoanLockStatus.Location = new System.Drawing.Point(630, 24);
            this.LoanLockStatus.Name = "LoanLockStatus";
            this.LoanLockStatus.Size = new System.Drawing.Size(22, 13);
            this.LoanLockStatus.TabIndex = 9;
            this.LoanLockStatus.Text = "xxx";
            // 
            // RunninStatus
            // 
            this.RunninStatus.AutoSize = true;
            this.RunninStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunninStatus.ForeColor = System.Drawing.Color.Blue;
            this.RunninStatus.Location = new System.Drawing.Point(728, 25);
            this.RunninStatus.Name = "RunninStatus";
            this.RunninStatus.Size = new System.Drawing.Size(63, 13);
            this.RunninStatus.TabIndex = 10;
            this.RunninStatus.Text = "XXXXXXX";
            this.RunninStatus.Visible = false;
            // 
            // FieldUpdaterWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 751);
            this.Controls.Add(this.RunninStatus);
            this.Controls.Add(this.LoanLockStatus);
            this.Controls.Add(this.ViewPipeline);
            this.Controls.Add(this.Search);
            this.Controls.Add(label3);
            this.Controls.Add(this.FieldSearch);
            this.Controls.Add(this._loanDetails);
            this.Controls.Add(this.LoadLoan);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.Controls.Add(this.LoanNumber);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldUpdaterWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API Field Updater";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FieldUpdaterWIN_FormClosed);
            this.Load += new System.EventHandler(this.FieldUpdaterWIN_Load);
            this._loanDetails.ResumeLayout(false);
            this._loanFields.ResumeLayout(false);
            this._dynamicFields.ResumeLayout(false);
            this._customFields.ResumeLayout(false);
            this._virtualFields.ResumeLayout(false);
            this._documents.ResumeLayout(false);
            this._milestones.ResumeLayout(false);
            this._UWConditions.ResumeLayout(false);
            this._rateLocks.ResumeLayout(false);
            this._users.ResumeLayout(false);
            this._serialized.ResumeLayout(false);
            this._serialized.PerformLayout();
            this._enhConditions.ResumeLayout(false);
            this.enhancedConditionMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LoanNumber;
        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.Button LoadLoan;
        private System.Windows.Forms.TabControl _loanDetails;
        private System.Windows.Forms.TabPage _loanFields;
        private System.Windows.Forms.TabPage _customFields;
        private System.Windows.Forms.TabPage _users;
        private System.Windows.Forms.TabPage _serialized;
        private System.Windows.Forms.TextBox JSonText;
        private System.Windows.Forms.ListView _listFields;
        private System.Windows.Forms.TabPage _virtualFields;
        private System.Windows.Forms.TabPage _dynamicFields;
        private System.Windows.Forms.ListView _listDynamicFields;
        private System.Windows.Forms.ListView ListCustomFields;
        private System.Windows.Forms.ListView ListVirtualFields;
        private System.Windows.Forms.ListView ListUsers;
        private System.Windows.Forms.TextBox FieldSearch;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TabPage _documents;
        private System.Windows.Forms.ListView ListDocuments;
        private System.Windows.Forms.Button ViewPipeline;
        private System.Windows.Forms.Label LoanLockStatus;
        private System.Windows.Forms.TabPage _milestones;
        private System.Windows.Forms.ListView ListMilestones;
        private System.Windows.Forms.TabPage _UWConditions;
        private System.Windows.Forms.ListView ListUWConditions;
        private System.Windows.Forms.TabPage _rateLocks;
        private System.Windows.Forms.ListView ListRateLocks;
        private System.Windows.Forms.TabPage _enhConditions;
        private System.Windows.Forms.ListView ListEnhancedConditions;
        private System.Windows.Forms.ContextMenuStrip enhancedConditionMenu;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Label RunninStatus;
    }
}