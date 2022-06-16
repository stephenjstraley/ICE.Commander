namespace ICE.Commander
{
    partial class QueryBuilderWIN
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this._clearQuery = new System.Windows.Forms.Button();
            this._saveQuery = new System.Windows.Forms.Button();
            this._loadSavedQuery = new System.Windows.Forms.Button();
            this._viewAPI = new System.Windows.Forms.Button();
            this._createQuery = new System.Windows.Forms.Button();
            this.ItemsToQuery = new System.Windows.Forms.TextBox();
            this._terms = new System.Windows.Forms.ListView();
            this._contract = new System.Windows.Forms.ListView();
            this._outputFields = new System.Windows.Forms.ListView();
            this._addTerm = new System.Windows.Forms.Button();
            this._addAndOrTerm = new System.Windows.Forms.Button();
            this._removeTerm = new System.Windows.Forms.Button();
            this._moveToContact = new System.Windows.Forms.Button();
            this._removeFromContract = new System.Windows.Forms.Button();
            this._queryContract = new System.Windows.Forms.Button();
            this._apiSource = new System.Windows.Forms.Button();
            this._addOutputFIeld = new System.Windows.Forms.Button();
            this._removeOutputField = new System.Windows.Forms.Button();
            this._removeSortOrder = new System.Windows.Forms.Button();
            this._addSortOrder = new System.Windows.Forms.Button();
            this._sortOrder = new System.Windows.Forms.ListView();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 26);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 13);
            label2.TabIndex = 4;
            label2.Text = "Ellie Instance";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(330, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 13);
            label1.TabIndex = 481;
            label1.Text = "Result Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(26, 57);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 482;
            label3.Text = "Terms";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(1406, 57);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 13);
            label4.TabIndex = 483;
            label4.Text = "Contract";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(27, 597);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 13);
            label5.TabIndex = 484;
            label5.Text = "Output Fields";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(553, 597);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 13);
            label6.TabIndex = 497;
            label6.Text = "Sort Order";
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(102, 22);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(204, 21);
            this.EllieInstance.TabIndex = 1;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // _clearQuery
            // 
            this._clearQuery.Location = new System.Drawing.Point(1489, 766);
            this._clearQuery.Name = "_clearQuery";
            this._clearQuery.Size = new System.Drawing.Size(75, 23);
            this._clearQuery.TabIndex = 308;
            this._clearQuery.Text = "Clear Query";
            this._clearQuery.UseVisualStyleBackColor = true;
            this._clearQuery.Click += new System.EventHandler(this.ClearQuery_Click);
            // 
            // _saveQuery
            // 
            this._saveQuery.Location = new System.Drawing.Point(1489, 708);
            this._saveQuery.Name = "_saveQuery";
            this._saveQuery.Size = new System.Drawing.Size(75, 23);
            this._saveQuery.TabIndex = 306;
            this._saveQuery.Text = "Save Query";
            this._saveQuery.UseVisualStyleBackColor = true;
            this._saveQuery.Click += new System.EventHandler(this.SaveQuery_Click);
            // 
            // _loadSavedQuery
            // 
            this._loadSavedQuery.Location = new System.Drawing.Point(1489, 737);
            this._loadSavedQuery.Name = "_loadSavedQuery";
            this._loadSavedQuery.Size = new System.Drawing.Size(75, 23);
            this._loadSavedQuery.TabIndex = 307;
            this._loadSavedQuery.Text = "Load Query";
            this._loadSavedQuery.UseVisualStyleBackColor = true;
            this._loadSavedQuery.Click += new System.EventHandler(this.LoadSavedQuery_Click);
            // 
            // _viewAPI
            // 
            this._viewAPI.Location = new System.Drawing.Point(1489, 650);
            this._viewAPI.Name = "_viewAPI";
            this._viewAPI.Size = new System.Drawing.Size(75, 23);
            this._viewAPI.TabIndex = 478;
            this._viewAPI.Text = "Results";
            this._viewAPI.UseVisualStyleBackColor = true;
            this._viewAPI.Click += new System.EventHandler(this._viewAPI_Click);
            // 
            // _createQuery
            // 
            this._createQuery.Location = new System.Drawing.Point(1489, 592);
            this._createQuery.Name = "_createQuery";
            this._createQuery.Size = new System.Drawing.Size(75, 23);
            this._createQuery.TabIndex = 480;
            this._createQuery.Text = "Query";
            this._createQuery.UseVisualStyleBackColor = true;
            this._createQuery.Click += new System.EventHandler(this.CreateQuery_Click);
            // 
            // ItemsToQuery
            // 
            this.ItemsToQuery.Location = new System.Drawing.Point(413, 23);
            this.ItemsToQuery.MaxLength = 5;
            this.ItemsToQuery.Name = "ItemsToQuery";
            this.ItemsToQuery.Size = new System.Drawing.Size(100, 20);
            this.ItemsToQuery.TabIndex = 2;
            this.ItemsToQuery.Text = "1000";
            this.ItemsToQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // _terms
            // 
            this._terms.FullRowSelect = true;
            this._terms.GridLines = true;
            this._terms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._terms.HideSelection = false;
            this._terms.Location = new System.Drawing.Point(29, 73);
            this._terms.Name = "_terms";
            this._terms.Size = new System.Drawing.Size(1319, 483);
            this._terms.TabIndex = 485;
            this._terms.UseCompatibleStateImageBehavior = false;
            this._terms.View = System.Windows.Forms.View.Details;
            this._terms.DoubleClick += new System.EventHandler(this._terms_DoubleClick);
            // 
            // _contract
            // 
            this._contract.FullRowSelect = true;
            this._contract.GridLines = true;
            this._contract.HideSelection = false;
            this._contract.Location = new System.Drawing.Point(1409, 73);
            this._contract.Name = "_contract";
            this._contract.Size = new System.Drawing.Size(171, 483);
            this._contract.TabIndex = 486;
            this._contract.UseCompatibleStateImageBehavior = false;
            this._contract.View = System.Windows.Forms.View.Details;
            // 
            // _outputFields
            // 
            this._outputFields.FullRowSelect = true;
            this._outputFields.GridLines = true;
            this._outputFields.HideSelection = false;
            this._outputFields.Location = new System.Drawing.Point(30, 613);
            this._outputFields.Name = "_outputFields";
            this._outputFields.Size = new System.Drawing.Size(439, 181);
            this._outputFields.TabIndex = 487;
            this._outputFields.UseCompatibleStateImageBehavior = false;
            this._outputFields.View = System.Windows.Forms.View.Details;
            // 
            // _addTerm
            // 
            this._addTerm.BackColor = System.Drawing.Color.LightGreen;
            this._addTerm.Enabled = false;
            this._addTerm.Location = new System.Drawing.Point(29, 562);
            this._addTerm.Name = "_addTerm";
            this._addTerm.Size = new System.Drawing.Size(52, 23);
            this._addTerm.TabIndex = 488;
            this._addTerm.Text = "Term";
            this._addTerm.UseVisualStyleBackColor = false;
            this._addTerm.Click += new System.EventHandler(this.AddTerm_Click);
            // 
            // _addAndOrTerm
            // 
            this._addAndOrTerm.BackColor = System.Drawing.Color.DarkOrange;
            this._addAndOrTerm.Enabled = false;
            this._addAndOrTerm.Location = new System.Drawing.Point(87, 562);
            this._addAndOrTerm.Name = "_addAndOrTerm";
            this._addAndOrTerm.Size = new System.Drawing.Size(89, 23);
            this._addAndOrTerm.TabIndex = 489;
            this._addAndOrTerm.Text = "Add AND/OR";
            this._addAndOrTerm.UseVisualStyleBackColor = false;
            this._addAndOrTerm.Click += new System.EventHandler(this.AddAndOrTerm_Click);
            // 
            // _removeTerm
            // 
            this._removeTerm.BackColor = System.Drawing.Color.Red;
            this._removeTerm.Enabled = false;
            this._removeTerm.Location = new System.Drawing.Point(1273, 562);
            this._removeTerm.Name = "_removeTerm";
            this._removeTerm.Size = new System.Drawing.Size(75, 23);
            this._removeTerm.TabIndex = 490;
            this._removeTerm.Text = "Remove";
            this._removeTerm.UseVisualStyleBackColor = false;
            this._removeTerm.Click += new System.EventHandler(this.RemoveTerm_Click);
            // 
            // _moveToContact
            // 
            this._moveToContact.Location = new System.Drawing.Point(1354, 73);
            this._moveToContact.Name = "_moveToContact";
            this._moveToContact.Size = new System.Drawing.Size(49, 28);
            this._moveToContact.TabIndex = 491;
            this._moveToContact.Text = ">>";
            this._moveToContact.UseVisualStyleBackColor = true;
            this._moveToContact.Click += new System.EventHandler(this._moveToContact_Click);
            // 
            // _removeFromContract
            // 
            this._removeFromContract.Location = new System.Drawing.Point(1354, 163);
            this._removeFromContract.Name = "_removeFromContract";
            this._removeFromContract.Size = new System.Drawing.Size(49, 28);
            this._removeFromContract.TabIndex = 492;
            this._removeFromContract.Text = "XX";
            this._removeFromContract.UseVisualStyleBackColor = true;
            this._removeFromContract.Click += new System.EventHandler(this._removeFromContract_Click);
            // 
            // _queryContract
            // 
            this._queryContract.Location = new System.Drawing.Point(1489, 621);
            this._queryContract.Name = "_queryContract";
            this._queryContract.Size = new System.Drawing.Size(75, 23);
            this._queryContract.TabIndex = 493;
            this._queryContract.Text = "API Contract";
            this._queryContract.UseVisualStyleBackColor = true;
            this._queryContract.Click += new System.EventHandler(this._queryContract_Click);
            // 
            // _apiSource
            // 
            this._apiSource.Enabled = false;
            this._apiSource.Location = new System.Drawing.Point(1489, 679);
            this._apiSource.Name = "_apiSource";
            this._apiSource.Size = new System.Drawing.Size(75, 23);
            this._apiSource.TabIndex = 494;
            this._apiSource.Text = "Gen Code";
            this._apiSource.UseVisualStyleBackColor = true;
            this._apiSource.Click += new System.EventHandler(this._apiSource_Click);
            // 
            // _addOutputFIeld
            // 
            this._addOutputFIeld.Location = new System.Drawing.Point(475, 609);
            this._addOutputFIeld.Name = "_addOutputFIeld";
            this._addOutputFIeld.Size = new System.Drawing.Size(75, 23);
            this._addOutputFIeld.TabIndex = 495;
            this._addOutputFIeld.Text = "Add";
            this._addOutputFIeld.UseVisualStyleBackColor = true;
            this._addOutputFIeld.Click += new System.EventHandler(this._addOutputFIeld_Click);
            // 
            // _removeOutputField
            // 
            this._removeOutputField.Location = new System.Drawing.Point(475, 767);
            this._removeOutputField.Name = "_removeOutputField";
            this._removeOutputField.Size = new System.Drawing.Size(75, 23);
            this._removeOutputField.TabIndex = 496;
            this._removeOutputField.Text = "Remove";
            this._removeOutputField.UseVisualStyleBackColor = true;
            this._removeOutputField.Click += new System.EventHandler(this._removeOutputField_Click);
            // 
            // _removeSortOrder
            // 
            this._removeSortOrder.Location = new System.Drawing.Point(1001, 767);
            this._removeSortOrder.Name = "_removeSortOrder";
            this._removeSortOrder.Size = new System.Drawing.Size(75, 23);
            this._removeSortOrder.TabIndex = 500;
            this._removeSortOrder.Text = "Remove";
            this._removeSortOrder.UseVisualStyleBackColor = true;
            this._removeSortOrder.Click += new System.EventHandler(this._removeSortOrder_Click);
            // 
            // _addSortOrder
            // 
            this._addSortOrder.Location = new System.Drawing.Point(1001, 609);
            this._addSortOrder.Name = "_addSortOrder";
            this._addSortOrder.Size = new System.Drawing.Size(75, 23);
            this._addSortOrder.TabIndex = 499;
            this._addSortOrder.Text = "Add";
            this._addSortOrder.UseVisualStyleBackColor = true;
            this._addSortOrder.Click += new System.EventHandler(this._addSortOrder_Click);
            // 
            // _sortOrder
            // 
            this._sortOrder.FullRowSelect = true;
            this._sortOrder.GridLines = true;
            this._sortOrder.HideSelection = false;
            this._sortOrder.Location = new System.Drawing.Point(556, 613);
            this._sortOrder.Name = "_sortOrder";
            this._sortOrder.Size = new System.Drawing.Size(439, 181);
            this._sortOrder.TabIndex = 498;
            this._sortOrder.UseCompatibleStateImageBehavior = false;
            this._sortOrder.View = System.Windows.Forms.View.Details;
            // 
            // QueryBuilderWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 806);
            this.Controls.Add(this._removeSortOrder);
            this.Controls.Add(this._addSortOrder);
            this.Controls.Add(this._sortOrder);
            this.Controls.Add(label6);
            this.Controls.Add(this._removeOutputField);
            this.Controls.Add(this._addOutputFIeld);
            this.Controls.Add(this._apiSource);
            this.Controls.Add(this._queryContract);
            this.Controls.Add(this._removeFromContract);
            this.Controls.Add(this._moveToContact);
            this.Controls.Add(this._removeTerm);
            this.Controls.Add(this._addAndOrTerm);
            this.Controls.Add(this._addTerm);
            this.Controls.Add(this._outputFields);
            this.Controls.Add(this._contract);
            this.Controls.Add(this._terms);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.ItemsToQuery);
            this.Controls.Add(label1);
            this.Controls.Add(this._viewAPI);
            this.Controls.Add(this._createQuery);
            this.Controls.Add(this._clearQuery);
            this.Controls.Add(this._saveQuery);
            this.Controls.Add(this._loadSavedQuery);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryBuilderWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryBuilderWIN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueryBuilderWIN_FormClosed);
            this.Load += new System.EventHandler(this.QueryBuilderWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.Button _clearQuery;
        private System.Windows.Forms.Button _saveQuery;
        private System.Windows.Forms.Button _loadSavedQuery;
        private System.Windows.Forms.Button _viewAPI;
        private System.Windows.Forms.Button _createQuery;
        private System.Windows.Forms.TextBox ItemsToQuery;
        private System.Windows.Forms.ListView _terms;
        private System.Windows.Forms.ListView _contract;
        private System.Windows.Forms.ListView _outputFields;
        private System.Windows.Forms.Button _addTerm;
        private System.Windows.Forms.Button _addAndOrTerm;
        private System.Windows.Forms.Button _removeTerm;
        private System.Windows.Forms.Button _moveToContact;
        private System.Windows.Forms.Button _removeFromContract;
        private System.Windows.Forms.Button _queryContract;
        private System.Windows.Forms.Button _apiSource;
        private System.Windows.Forms.Button _addOutputFIeld;
        private System.Windows.Forms.Button _removeOutputField;
        private System.Windows.Forms.Button _removeSortOrder;
        private System.Windows.Forms.Button _addSortOrder;
        private System.Windows.Forms.ListView _sortOrder;
    }
}