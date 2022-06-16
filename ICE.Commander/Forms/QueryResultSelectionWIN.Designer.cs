namespace ICE.Commander
{
    partial class QueryResultSelectionWIN
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
            this._loadLoan = new System.Windows.Forms.Button();
            this._loanDetailsTabControl = new System.Windows.Forms.TabControl();
            this._loanFieldsTab = new System.Windows.Forms.TabPage();
            this._dynamicFieldsTab = new System.Windows.Forms.TabPage();
            this._customFieldsTab = new System.Windows.Forms.TabPage();
            this._virtualFieldsTab = new System.Windows.Forms.TabPage();
            this._documentsTab = new System.Windows.Forms.TabPage();
            this._milestonesTab = new System.Windows.Forms.TabPage();
            this._uwConditionsTab = new System.Windows.Forms.TabPage();
            this._serialixedTab = new System.Windows.Forms.TabPage();
            this._listLoanFields = new System.Windows.Forms.ListView();
            this._listDynamicFields = new System.Windows.Forms.ListView();
            this._listCustomFields = new System.Windows.Forms.ListView();
            this._listVirtualFields = new System.Windows.Forms.ListView();
            this._listDocuments = new System.Windows.Forms.ListView();
            this._listMilestones = new System.Windows.Forms.ListView();
            this._listUWConditions = new System.Windows.Forms.ListView();
            this._jsonText = new System.Windows.Forms.TextBox();
            this._loanDetailsTabControl.SuspendLayout();
            this._loanFieldsTab.SuspendLayout();
            this._dynamicFieldsTab.SuspendLayout();
            this._customFieldsTab.SuspendLayout();
            this._virtualFieldsTab.SuspendLayout();
            this._documentsTab.SuspendLayout();
            this._milestonesTab.SuspendLayout();
            this._uwConditionsTab.SuspendLayout();
            this._serialixedTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loadLoan
            // 
            this._loadLoan.Location = new System.Drawing.Point(4, 6);
            this._loadLoan.Name = "_loadLoan";
            this._loadLoan.Size = new System.Drawing.Size(75, 23);
            this._loadLoan.TabIndex = 5;
            this._loadLoan.Text = "Load Loan";
            this._loadLoan.UseVisualStyleBackColor = true;
            this._loadLoan.Click += new System.EventHandler(this._loadLoan_Click);
            // 
            // _loanDetailsTabControl
            // 
            this._loanDetailsTabControl.Controls.Add(this._loanFieldsTab);
            this._loanDetailsTabControl.Controls.Add(this._dynamicFieldsTab);
            this._loanDetailsTabControl.Controls.Add(this._customFieldsTab);
            this._loanDetailsTabControl.Controls.Add(this._virtualFieldsTab);
            this._loanDetailsTabControl.Controls.Add(this._documentsTab);
            this._loanDetailsTabControl.Controls.Add(this._milestonesTab);
            this._loanDetailsTabControl.Controls.Add(this._uwConditionsTab);
            this._loanDetailsTabControl.Controls.Add(this._serialixedTab);
            this._loanDetailsTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._loanDetailsTabControl.Location = new System.Drawing.Point(0, 38);
            this._loanDetailsTabControl.Name = "_loanDetailsTabControl";
            this._loanDetailsTabControl.SelectedIndex = 0;
            this._loanDetailsTabControl.Size = new System.Drawing.Size(1269, 589);
            this._loanDetailsTabControl.TabIndex = 7;
            this._loanDetailsTabControl.SelectedIndexChanged += new System.EventHandler(this._loanDetails_SelectedIndexChanged);
            // 
            // _loanFieldsTab
            // 
            this._loanFieldsTab.Controls.Add(this._listLoanFields);
            this._loanFieldsTab.Location = new System.Drawing.Point(4, 22);
            this._loanFieldsTab.Name = "_loanFieldsTab";
            this._loanFieldsTab.Padding = new System.Windows.Forms.Padding(3);
            this._loanFieldsTab.Size = new System.Drawing.Size(889, 317);
            this._loanFieldsTab.TabIndex = 0;
            this._loanFieldsTab.Text = "Fields";
            this._loanFieldsTab.UseVisualStyleBackColor = true;
            // 
            // _dynamicFieldsTab
            // 
            this._dynamicFieldsTab.Controls.Add(this._listDynamicFields);
            this._dynamicFieldsTab.Location = new System.Drawing.Point(4, 22);
            this._dynamicFieldsTab.Name = "_dynamicFieldsTab";
            this._dynamicFieldsTab.Padding = new System.Windows.Forms.Padding(3);
            this._dynamicFieldsTab.Size = new System.Drawing.Size(1261, 563);
            this._dynamicFieldsTab.TabIndex = 1;
            this._dynamicFieldsTab.Text = "Dynamic Fields";
            this._dynamicFieldsTab.UseVisualStyleBackColor = true;
            // 
            // _customFieldsTab
            // 
            this._customFieldsTab.Controls.Add(this._listCustomFields);
            this._customFieldsTab.Location = new System.Drawing.Point(4, 22);
            this._customFieldsTab.Name = "_customFieldsTab";
            this._customFieldsTab.Size = new System.Drawing.Size(889, 317);
            this._customFieldsTab.TabIndex = 2;
            this._customFieldsTab.Text = "Custom Fields";
            this._customFieldsTab.UseVisualStyleBackColor = true;
            // 
            // _virtualFieldsTab
            // 
            this._virtualFieldsTab.Controls.Add(this._listVirtualFields);
            this._virtualFieldsTab.Location = new System.Drawing.Point(4, 22);
            this._virtualFieldsTab.Name = "_virtualFieldsTab";
            this._virtualFieldsTab.Size = new System.Drawing.Size(1245, 563);
            this._virtualFieldsTab.TabIndex = 3;
            this._virtualFieldsTab.Text = "Virtual Fields";
            this._virtualFieldsTab.UseVisualStyleBackColor = true;
            // 
            // _documentsTab
            // 
            this._documentsTab.Controls.Add(this._listDocuments);
            this._documentsTab.Location = new System.Drawing.Point(4, 22);
            this._documentsTab.Name = "_documentsTab";
            this._documentsTab.Size = new System.Drawing.Size(889, 317);
            this._documentsTab.TabIndex = 4;
            this._documentsTab.Text = "Documents";
            this._documentsTab.UseVisualStyleBackColor = true;
            // 
            // _milestonesTab
            // 
            this._milestonesTab.Controls.Add(this._listMilestones);
            this._milestonesTab.Location = new System.Drawing.Point(4, 22);
            this._milestonesTab.Name = "_milestonesTab";
            this._milestonesTab.Size = new System.Drawing.Size(889, 317);
            this._milestonesTab.TabIndex = 5;
            this._milestonesTab.Text = "Milestones";
            this._milestonesTab.UseVisualStyleBackColor = true;
            // 
            // _uwConditionsTab
            // 
            this._uwConditionsTab.Controls.Add(this._listUWConditions);
            this._uwConditionsTab.Location = new System.Drawing.Point(4, 22);
            this._uwConditionsTab.Name = "_uwConditionsTab";
            this._uwConditionsTab.Size = new System.Drawing.Size(889, 317);
            this._uwConditionsTab.TabIndex = 6;
            this._uwConditionsTab.Text = "UW Conditions";
            this._uwConditionsTab.UseVisualStyleBackColor = true;
            // 
            // _serialixedTab
            // 
            this._serialixedTab.Controls.Add(this._jsonText);
            this._serialixedTab.Location = new System.Drawing.Point(4, 22);
            this._serialixedTab.Name = "_serialixedTab";
            this._serialixedTab.Size = new System.Drawing.Size(889, 317);
            this._serialixedTab.TabIndex = 7;
            this._serialixedTab.Text = "Serialized";
            this._serialixedTab.UseVisualStyleBackColor = true;
            // 
            // _listLoanFields
            // 
            this._listLoanFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listLoanFields.FullRowSelect = true;
            this._listLoanFields.GridLines = true;
            this._listLoanFields.HideSelection = false;
            this._listLoanFields.Location = new System.Drawing.Point(3, 3);
            this._listLoanFields.Name = "_listLoanFields";
            this._listLoanFields.Size = new System.Drawing.Size(883, 311);
            this._listLoanFields.TabIndex = 1;
            this._listLoanFields.UseCompatibleStateImageBehavior = false;
            this._listLoanFields.View = System.Windows.Forms.View.Details;
            // 
            // _listDynamicFields
            // 
            this._listDynamicFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listDynamicFields.FullRowSelect = true;
            this._listDynamicFields.GridLines = true;
            this._listDynamicFields.HideSelection = false;
            this._listDynamicFields.Location = new System.Drawing.Point(3, 3);
            this._listDynamicFields.Name = "_listDynamicFields";
            this._listDynamicFields.Size = new System.Drawing.Size(1255, 557);
            this._listDynamicFields.TabIndex = 2;
            this._listDynamicFields.UseCompatibleStateImageBehavior = false;
            this._listDynamicFields.View = System.Windows.Forms.View.Details;
            // 
            // _listCustomFields
            // 
            this._listCustomFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listCustomFields.FullRowSelect = true;
            this._listCustomFields.GridLines = true;
            this._listCustomFields.HideSelection = false;
            this._listCustomFields.Location = new System.Drawing.Point(0, 0);
            this._listCustomFields.Name = "_listCustomFields";
            this._listCustomFields.Size = new System.Drawing.Size(889, 317);
            this._listCustomFields.TabIndex = 3;
            this._listCustomFields.UseCompatibleStateImageBehavior = false;
            this._listCustomFields.View = System.Windows.Forms.View.Details;
            // 
            // _listVirtualFields
            // 
            this._listVirtualFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listVirtualFields.FullRowSelect = true;
            this._listVirtualFields.GridLines = true;
            this._listVirtualFields.HideSelection = false;
            this._listVirtualFields.Location = new System.Drawing.Point(0, 0);
            this._listVirtualFields.Name = "_listVirtualFields";
            this._listVirtualFields.Size = new System.Drawing.Size(1245, 563);
            this._listVirtualFields.TabIndex = 4;
            this._listVirtualFields.UseCompatibleStateImageBehavior = false;
            this._listVirtualFields.View = System.Windows.Forms.View.Details;
            // 
            // _listDocuments
            // 
            this._listDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listDocuments.FullRowSelect = true;
            this._listDocuments.GridLines = true;
            this._listDocuments.HideSelection = false;
            this._listDocuments.Location = new System.Drawing.Point(0, 0);
            this._listDocuments.Name = "_listDocuments";
            this._listDocuments.Size = new System.Drawing.Size(889, 317);
            this._listDocuments.TabIndex = 3;
            this._listDocuments.UseCompatibleStateImageBehavior = false;
            this._listDocuments.View = System.Windows.Forms.View.Details;
            // 
            // _listMilestones
            // 
            this._listMilestones.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listMilestones.FullRowSelect = true;
            this._listMilestones.GridLines = true;
            this._listMilestones.HideSelection = false;
            this._listMilestones.Location = new System.Drawing.Point(0, 0);
            this._listMilestones.Name = "_listMilestones";
            this._listMilestones.Size = new System.Drawing.Size(889, 317);
            this._listMilestones.TabIndex = 3;
            this._listMilestones.UseCompatibleStateImageBehavior = false;
            this._listMilestones.View = System.Windows.Forms.View.Details;
            // 
            // _listUWConditions
            // 
            this._listUWConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listUWConditions.FullRowSelect = true;
            this._listUWConditions.GridLines = true;
            this._listUWConditions.HideSelection = false;
            this._listUWConditions.Location = new System.Drawing.Point(0, 0);
            this._listUWConditions.Name = "_listUWConditions";
            this._listUWConditions.Size = new System.Drawing.Size(889, 317);
            this._listUWConditions.TabIndex = 4;
            this._listUWConditions.UseCompatibleStateImageBehavior = false;
            this._listUWConditions.View = System.Windows.Forms.View.Details;
            // 
            // _jsonText
            // 
            this._jsonText.Cursor = System.Windows.Forms.Cursors.No;
            this._jsonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._jsonText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._jsonText.Location = new System.Drawing.Point(0, 0);
            this._jsonText.Multiline = true;
            this._jsonText.Name = "_jsonText";
            this._jsonText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._jsonText.Size = new System.Drawing.Size(889, 317);
            this._jsonText.TabIndex = 1;
            // 
            // QueryResultSelectionWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 627);
            this.Controls.Add(this._loanDetailsTabControl);
            this.Controls.Add(this._loadLoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryResultSelectionWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loan Status:";
            this.Load += new System.EventHandler(this.QueryResultSelectionWIN_Load);
            this._loanDetailsTabControl.ResumeLayout(false);
            this._loanFieldsTab.ResumeLayout(false);
            this._dynamicFieldsTab.ResumeLayout(false);
            this._customFieldsTab.ResumeLayout(false);
            this._virtualFieldsTab.ResumeLayout(false);
            this._documentsTab.ResumeLayout(false);
            this._milestonesTab.ResumeLayout(false);
            this._uwConditionsTab.ResumeLayout(false);
            this._serialixedTab.ResumeLayout(false);
            this._serialixedTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _loadLoan;
        private System.Windows.Forms.TabControl _loanDetailsTabControl;
        private System.Windows.Forms.TabPage _loanFieldsTab;
        private System.Windows.Forms.TabPage _dynamicFieldsTab;
        private System.Windows.Forms.ListView _listLoanFields;
        private System.Windows.Forms.ListView _listDynamicFields;
        private System.Windows.Forms.TabPage _customFieldsTab;
        private System.Windows.Forms.ListView _listCustomFields;
        private System.Windows.Forms.TabPage _virtualFieldsTab;
        private System.Windows.Forms.ListView _listVirtualFields;
        private System.Windows.Forms.TabPage _documentsTab;
        private System.Windows.Forms.TabPage _milestonesTab;
        private System.Windows.Forms.TabPage _uwConditionsTab;
        private System.Windows.Forms.TabPage _serialixedTab;
        private System.Windows.Forms.ListView _listDocuments;
        private System.Windows.Forms.ListView _listMilestones;
        private System.Windows.Forms.ListView _listUWConditions;
        private System.Windows.Forms.TextBox _jsonText;
    }
}