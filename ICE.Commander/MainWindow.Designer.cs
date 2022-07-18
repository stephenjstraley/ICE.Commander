namespace ICE.Commander
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIFieldUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webHookMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v3LoanContractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIFieldValidatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNumGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldDefinitionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersGroupsPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allUsersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersGroupsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersPersonasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersCompensationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersLicensesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underwritingConditionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.milestonesAssociatesRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMilestonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastOmpletedMilestonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMilestonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allAssociatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associatesByRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateLockRequestSummariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceLockListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanTemplateFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicTempalteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsAndAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allFieldValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIFieldSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem,
            this.testsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIFieldUpdaterToolStripMenuItem,
            this.queryBuilderToolStripMenuItem,
            this.webHookMonitorToolStripMenuItem,
            this.versionComparisonToolStripMenuItem,
            this.v3LoanContractsToolStripMenuItem,
            this.aPIFieldValidatorToolStripMenuItem,
            this.eNumGenerationToolStripMenuItem,
            this.fieldDefinitionListToolStripMenuItem,
            this.aPIFieldSchemaToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // aPIFieldUpdaterToolStripMenuItem
            // 
            this.aPIFieldUpdaterToolStripMenuItem.Name = "aPIFieldUpdaterToolStripMenuItem";
            this.aPIFieldUpdaterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aPIFieldUpdaterToolStripMenuItem.Text = "API Field Updater";
            this.aPIFieldUpdaterToolStripMenuItem.Click += new System.EventHandler(this.MenuItemAPIFieldUpdater_Click);
            // 
            // queryBuilderToolStripMenuItem
            // 
            this.queryBuilderToolStripMenuItem.Name = "queryBuilderToolStripMenuItem";
            this.queryBuilderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.queryBuilderToolStripMenuItem.Text = "Query Builder";
            this.queryBuilderToolStripMenuItem.Click += new System.EventHandler(this.MenuItemQueryBuilder_Click);
            // 
            // webHookMonitorToolStripMenuItem
            // 
            this.webHookMonitorToolStripMenuItem.Name = "webHookMonitorToolStripMenuItem";
            this.webHookMonitorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.webHookMonitorToolStripMenuItem.Text = "Web Hook Monitor";
            this.webHookMonitorToolStripMenuItem.Click += new System.EventHandler(this.MenuItemWebHook_Click);
            // 
            // versionComparisonToolStripMenuItem
            // 
            this.versionComparisonToolStripMenuItem.Name = "versionComparisonToolStripMenuItem";
            this.versionComparisonToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.versionComparisonToolStripMenuItem.Text = "Version Comparison";
            this.versionComparisonToolStripMenuItem.Click += new System.EventHandler(this.MenuItemVersionCompare_Click);
            // 
            // v3LoanContractsToolStripMenuItem
            // 
            this.v3LoanContractsToolStripMenuItem.Name = "v3LoanContractsToolStripMenuItem";
            this.v3LoanContractsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.v3LoanContractsToolStripMenuItem.Text = "V3 Loan Contracts";
            this.v3LoanContractsToolStripMenuItem.Click += new System.EventHandler(this.MenuItemGenerateV3Classes_Click);
            // 
            // aPIFieldValidatorToolStripMenuItem
            // 
            this.aPIFieldValidatorToolStripMenuItem.Name = "aPIFieldValidatorToolStripMenuItem";
            this.aPIFieldValidatorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aPIFieldValidatorToolStripMenuItem.Text = "API Field Validator";
            this.aPIFieldValidatorToolStripMenuItem.Click += new System.EventHandler(this.aPIFieldValidatorToolStripMenuItem_Click);
            // 
            // eNumGenerationToolStripMenuItem
            // 
            this.eNumGenerationToolStripMenuItem.Name = "eNumGenerationToolStripMenuItem";
            this.eNumGenerationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eNumGenerationToolStripMenuItem.Text = "ENum Generation";
            this.eNumGenerationToolStripMenuItem.Click += new System.EventHandler(this.eNumGenerationToolStripMenuItem_Click);
            // 
            // fieldDefinitionListToolStripMenuItem
            // 
            this.fieldDefinitionListToolStripMenuItem.Name = "fieldDefinitionListToolStripMenuItem";
            this.fieldDefinitionListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fieldDefinitionListToolStripMenuItem.Text = "Field Definition List";
            this.fieldDefinitionListToolStripMenuItem.Click += new System.EventHandler(this.fieldDefinitionListToolStripMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersGroupsPersonasToolStripMenuItem,
            this.underwritingConditionsToolStripMenuItem,
            this.milestonesAssociatesRolesToolStripMenuItem,
            this.locksToolStripMenuItem,
            this.foldersTemplatesToolStripMenuItem,
            this.documentsAndAttachmentsToolStripMenuItem,
            this.allFieldValuesToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // usersGroupsPersonasToolStripMenuItem
            // 
            this.usersGroupsPersonasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allUsersToolStripMenuItem1,
            this.usersGroupsToolStripMenuItem1,
            this.usersPersonasToolStripMenuItem1,
            this.usersCompensationsToolStripMenuItem1,
            this.usersLicensesToolStripMenuItem1,
            this.personasToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.usersGroupsPersonasToolStripMenuItem.Name = "usersGroupsPersonasToolStripMenuItem";
            this.usersGroupsPersonasToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.usersGroupsPersonasToolStripMenuItem.Text = "Users, Groups, Personas";
            // 
            // allUsersToolStripMenuItem1
            // 
            this.allUsersToolStripMenuItem1.Name = "allUsersToolStripMenuItem1";
            this.allUsersToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.allUsersToolStripMenuItem1.Text = "All Users";
            this.allUsersToolStripMenuItem1.Click += new System.EventHandler(this.allUsersToolStripMenuItem1_Click);
            // 
            // usersGroupsToolStripMenuItem1
            // 
            this.usersGroupsToolStripMenuItem1.Name = "usersGroupsToolStripMenuItem1";
            this.usersGroupsToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.usersGroupsToolStripMenuItem1.Text = "Users Groups";
            this.usersGroupsToolStripMenuItem1.Click += new System.EventHandler(this.usersGroupsToolStripMenuItem1_Click);
            // 
            // usersPersonasToolStripMenuItem1
            // 
            this.usersPersonasToolStripMenuItem1.Name = "usersPersonasToolStripMenuItem1";
            this.usersPersonasToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.usersPersonasToolStripMenuItem1.Text = "Users Personas";
            this.usersPersonasToolStripMenuItem1.Click += new System.EventHandler(this.usersPersonasToolStripMenuItem1_Click);
            // 
            // usersCompensationsToolStripMenuItem1
            // 
            this.usersCompensationsToolStripMenuItem1.Name = "usersCompensationsToolStripMenuItem1";
            this.usersCompensationsToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.usersCompensationsToolStripMenuItem1.Text = "Users Compensations";
            this.usersCompensationsToolStripMenuItem1.Click += new System.EventHandler(this.usersCompensationsToolStripMenuItem1_Click);
            // 
            // usersLicensesToolStripMenuItem1
            // 
            this.usersLicensesToolStripMenuItem1.Name = "usersLicensesToolStripMenuItem1";
            this.usersLicensesToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.usersLicensesToolStripMenuItem1.Text = "Users Licenses";
            this.usersLicensesToolStripMenuItem1.Click += new System.EventHandler(this.usersLicensesToolStripMenuItem1_Click);
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.personasToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // underwritingConditionsToolStripMenuItem
            // 
            this.underwritingConditionsToolStripMenuItem.Name = "underwritingConditionsToolStripMenuItem";
            this.underwritingConditionsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.underwritingConditionsToolStripMenuItem.Text = "Underwriting Conditions";
            this.underwritingConditionsToolStripMenuItem.Click += new System.EventHandler(this.underwritingConditionsToolStripMenuItem_Click);
            // 
            // milestonesAssociatesRolesToolStripMenuItem
            // 
            this.milestonesAssociatesRolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allMilestonesToolStripMenuItem,
            this.lastOmpletedMilestonesToolStripMenuItem,
            this.nextMilestonesToolStripMenuItem,
            this.allAssociatesToolStripMenuItem,
            this.associatesByRoleToolStripMenuItem});
            this.milestonesAssociatesRolesToolStripMenuItem.Name = "milestonesAssociatesRolesToolStripMenuItem";
            this.milestonesAssociatesRolesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.milestonesAssociatesRolesToolStripMenuItem.Text = "Milestones, Associates, Roles";
            // 
            // allMilestonesToolStripMenuItem
            // 
            this.allMilestonesToolStripMenuItem.Name = "allMilestonesToolStripMenuItem";
            this.allMilestonesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.allMilestonesToolStripMenuItem.Text = "All Milestones";
            this.allMilestonesToolStripMenuItem.Click += new System.EventHandler(this.allMilestonesToolStripMenuItem_Click);
            // 
            // lastOmpletedMilestonesToolStripMenuItem
            // 
            this.lastOmpletedMilestonesToolStripMenuItem.Name = "lastOmpletedMilestonesToolStripMenuItem";
            this.lastOmpletedMilestonesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.lastOmpletedMilestonesToolStripMenuItem.Text = "Last Completed Milestones";
            this.lastOmpletedMilestonesToolStripMenuItem.Click += new System.EventHandler(this.lastOmpletedMilestonesToolStripMenuItem_Click);
            // 
            // nextMilestonesToolStripMenuItem
            // 
            this.nextMilestonesToolStripMenuItem.Name = "nextMilestonesToolStripMenuItem";
            this.nextMilestonesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.nextMilestonesToolStripMenuItem.Text = "Next Milestones";
            this.nextMilestonesToolStripMenuItem.Click += new System.EventHandler(this.nextMilestonesToolStripMenuItem_Click);
            // 
            // allAssociatesToolStripMenuItem
            // 
            this.allAssociatesToolStripMenuItem.Name = "allAssociatesToolStripMenuItem";
            this.allAssociatesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.allAssociatesToolStripMenuItem.Text = "All Associates";
            this.allAssociatesToolStripMenuItem.Click += new System.EventHandler(this.allAssociatesToolStripMenuItem_Click);
            // 
            // associatesByRoleToolStripMenuItem
            // 
            this.associatesByRoleToolStripMenuItem.Name = "associatesByRoleToolStripMenuItem";
            this.associatesByRoleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.associatesByRoleToolStripMenuItem.Text = "Associates by Role";
            this.associatesByRoleToolStripMenuItem.Click += new System.EventHandler(this.associatesByRoleToolStripMenuItem_Click);
            // 
            // locksToolStripMenuItem
            // 
            this.locksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rateLockRequestSummariesToolStripMenuItem,
            this.resourceLockListToolStripMenuItem});
            this.locksToolStripMenuItem.Name = "locksToolStripMenuItem";
            this.locksToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.locksToolStripMenuItem.Text = "Locks";
            // 
            // rateLockRequestSummariesToolStripMenuItem
            // 
            this.rateLockRequestSummariesToolStripMenuItem.Name = "rateLockRequestSummariesToolStripMenuItem";
            this.rateLockRequestSummariesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.rateLockRequestSummariesToolStripMenuItem.Text = "Rate Lock Request Summaries";
            this.rateLockRequestSummariesToolStripMenuItem.Click += new System.EventHandler(this.rateLockRequestSummariesToolStripMenuItem_Click);
            // 
            // resourceLockListToolStripMenuItem
            // 
            this.resourceLockListToolStripMenuItem.Name = "resourceLockListToolStripMenuItem";
            this.resourceLockListToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.resourceLockListToolStripMenuItem.Text = "Resource Lock List";
            this.resourceLockListToolStripMenuItem.Click += new System.EventHandler(this.resourceLockListToolStripMenuItem_Click);
            // 
            // foldersTemplatesToolStripMenuItem
            // 
            this.foldersTemplatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanTemplateFoldersToolStripMenuItem,
            this.publicTempalteFilesToolStripMenuItem,
            this.allFoldersToolStripMenuItem});
            this.foldersTemplatesToolStripMenuItem.Name = "foldersTemplatesToolStripMenuItem";
            this.foldersTemplatesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.foldersTemplatesToolStripMenuItem.Text = "Folders, Templates";
            // 
            // loanTemplateFoldersToolStripMenuItem
            // 
            this.loanTemplateFoldersToolStripMenuItem.Name = "loanTemplateFoldersToolStripMenuItem";
            this.loanTemplateFoldersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.loanTemplateFoldersToolStripMenuItem.Text = "Loan Template Folders";
            this.loanTemplateFoldersToolStripMenuItem.Click += new System.EventHandler(this.loanTemplateFoldersToolStripMenuItem_Click);
            // 
            // publicTempalteFilesToolStripMenuItem
            // 
            this.publicTempalteFilesToolStripMenuItem.Name = "publicTempalteFilesToolStripMenuItem";
            this.publicTempalteFilesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.publicTempalteFilesToolStripMenuItem.Text = "Public Tempalte Files";
            this.publicTempalteFilesToolStripMenuItem.Click += new System.EventHandler(this.publicTempalteFilesToolStripMenuItem_Click);
            // 
            // allFoldersToolStripMenuItem
            // 
            this.allFoldersToolStripMenuItem.Name = "allFoldersToolStripMenuItem";
            this.allFoldersToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.allFoldersToolStripMenuItem.Text = "All Folders";
            this.allFoldersToolStripMenuItem.Click += new System.EventHandler(this.allFoldersToolStripMenuItem_Click);
            // 
            // documentsAndAttachmentsToolStripMenuItem
            // 
            this.documentsAndAttachmentsToolStripMenuItem.Name = "documentsAndAttachmentsToolStripMenuItem";
            this.documentsAndAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.documentsAndAttachmentsToolStripMenuItem.Text = "Documents and Attachments";
            this.documentsAndAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.documentsAndAttachmentsToolStripMenuItem_Click);
            // 
            // allFieldValuesToolStripMenuItem
            // 
            this.allFieldValuesToolStripMenuItem.Name = "allFieldValuesToolStripMenuItem";
            this.allFieldValuesToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.allFieldValuesToolStripMenuItem.Text = "All Field Values";
            this.allFieldValuesToolStripMenuItem.Click += new System.EventHandler(this.allFieldValuesToolStripMenuItem_Click);
            // 
            // aPIFieldSchemaToolStripMenuItem
            // 
            this.aPIFieldSchemaToolStripMenuItem.Name = "aPIFieldSchemaToolStripMenuItem";
            this.aPIFieldSchemaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aPIFieldSchemaToolStripMenuItem.Text = "API Field Schema";
            this.aPIFieldSchemaToolStripMenuItem.Click += new System.EventHandler(this.aPIFieldSchemaToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICE Commander - 1.0.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIFieldUpdaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webHookMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v3LoanContractsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIFieldValidatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNumGenerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersGroupsPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allUsersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersGroupsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersPersonasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersCompensationsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usersLicensesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem underwritingConditionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem milestonesAssociatesRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allMilestonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastOmpletedMilestonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextMilestonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allAssociatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem associatesByRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateLockRequestSummariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceLockListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanTemplateFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicTempalteFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentsAndAttachmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldDefinitionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allFieldValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIFieldSchemaToolStripMenuItem;
    }
}