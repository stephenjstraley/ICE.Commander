namespace ICE.Commander
{
    partial class AddTermWIN
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this._TermName = new System.Windows.Forms.TextBox();
            this._FieldId = new System.Windows.Forms.ComboBox();
            this._Value = new System.Windows.Forms.TextBox();
            this._NumericValue = new System.Windows.Forms.CheckBox();
            this._MatchType = new System.Windows.Forms.ComboBox();
            this._OrdinalMatchType = new System.Windows.Forms.ComboBox();
            this._DateCriteria = new System.Windows.Forms.ComboBox();
            this._DateMatchPrecision = new System.Windows.Forms.ComboBox();
            this._Include = new System.Windows.Forms.CheckBox();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 13);
            label1.TabIndex = 0;
            label1.Text = "Term Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(45, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 2;
            label2.Text = "Field ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(54, 96);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 13);
            label3.TabIndex = 4;
            label3.Text = "Value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(24, 128);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 7;
            label4.Text = "Match Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(310, 128);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(100, 13);
            label5.TabIndex = 9;
            label5.Text = "Ordinal Match Type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 166);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 13);
            label6.TabIndex = 11;
            label6.Text = "Date Criteria";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(300, 166);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(109, 13);
            label7.TabIndex = 13;
            label7.Text = "Date Match Precision";
            // 
            // _TermName
            // 
            this._TermName.Location = new System.Drawing.Point(94, 24);
            this._TermName.Name = "_TermName";
            this._TermName.Size = new System.Drawing.Size(127, 20);
            this._TermName.TabIndex = 1;
            this._TermName.Enter += new System.EventHandler(this._TermName_Enter);
            this._TermName.Leave += new System.EventHandler(this._TermName_Leave);
            // 
            // _FieldId
            // 
            this._FieldId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._FieldId.FormattingEnabled = true;
            this._FieldId.Location = new System.Drawing.Point(94, 57);
            this._FieldId.Name = "_FieldId";
            this._FieldId.Size = new System.Drawing.Size(364, 21);
            this._FieldId.TabIndex = 3;
            // 
            // _Value
            // 
            this._Value.Location = new System.Drawing.Point(94, 93);
            this._Value.Name = "_Value";
            this._Value.Size = new System.Drawing.Size(364, 20);
            this._Value.TabIndex = 5;
            // 
            // _NumericValue
            // 
            this._NumericValue.AutoSize = true;
            this._NumericValue.Location = new System.Drawing.Point(503, 95);
            this._NumericValue.Name = "_NumericValue";
            this._NumericValue.Size = new System.Drawing.Size(95, 17);
            this._NumericValue.TabIndex = 6;
            this._NumericValue.Text = "Numeric Value";
            this._NumericValue.UseVisualStyleBackColor = true;
            // 
            // _MatchType
            // 
            this._MatchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._MatchType.FormattingEnabled = true;
            this._MatchType.Location = new System.Drawing.Point(94, 125);
            this._MatchType.Name = "_MatchType";
            this._MatchType.Size = new System.Drawing.Size(162, 21);
            this._MatchType.TabIndex = 8;
            // 
            // _OrdinalMatchType
            // 
            this._OrdinalMatchType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._OrdinalMatchType.FormattingEnabled = true;
            this._OrdinalMatchType.Location = new System.Drawing.Point(415, 125);
            this._OrdinalMatchType.Name = "_OrdinalMatchType";
            this._OrdinalMatchType.Size = new System.Drawing.Size(162, 21);
            this._OrdinalMatchType.TabIndex = 10;
            // 
            // _DateCriteria
            // 
            this._DateCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._DateCriteria.FormattingEnabled = true;
            this._DateCriteria.Location = new System.Drawing.Point(94, 163);
            this._DateCriteria.Name = "_DateCriteria";
            this._DateCriteria.Size = new System.Drawing.Size(162, 21);
            this._DateCriteria.TabIndex = 12;
            // 
            // _DateMatchPrecision
            // 
            this._DateMatchPrecision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._DateMatchPrecision.FormattingEnabled = true;
            this._DateMatchPrecision.Location = new System.Drawing.Point(415, 163);
            this._DateMatchPrecision.Name = "_DateMatchPrecision";
            this._DateMatchPrecision.Size = new System.Drawing.Size(162, 21);
            this._DateMatchPrecision.TabIndex = 14;
            // 
            // _Include
            // 
            this._Include.AutoSize = true;
            this._Include.Checked = true;
            this._Include.CheckState = System.Windows.Forms.CheckState.Checked;
            this._Include.Location = new System.Drawing.Point(503, 27);
            this._Include.Name = "_Include";
            this._Include.Size = new System.Drawing.Size(61, 17);
            this._Include.TabIndex = 15;
            this._Include.Text = "Include";
            this._Include.UseVisualStyleBackColor = true;
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(24, 211);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(61, 29);
            this.Accept.TabIndex = 16;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(537, 211);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(61, 29);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // AddTermWIN
            // 
            this.AcceptButton = this.Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(623, 262);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this._Include);
            this.Controls.Add(this._DateMatchPrecision);
            this.Controls.Add(label7);
            this.Controls.Add(this._DateCriteria);
            this.Controls.Add(label6);
            this.Controls.Add(this._OrdinalMatchType);
            this.Controls.Add(label5);
            this.Controls.Add(this._MatchType);
            this.Controls.Add(label4);
            this.Controls.Add(this._NumericValue);
            this.Controls.Add(this._Value);
            this.Controls.Add(label3);
            this.Controls.Add(this._FieldId);
            this.Controls.Add(label2);
            this.Controls.Add(this._TermName);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTermWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "(int)";
            this.Load += new System.EventHandler(this.AddTermWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _TermName;
        private System.Windows.Forms.ComboBox _FieldId;
        private System.Windows.Forms.TextBox _Value;
        private System.Windows.Forms.CheckBox _NumericValue;
        private System.Windows.Forms.ComboBox _MatchType;
        private System.Windows.Forms.ComboBox _OrdinalMatchType;
        private System.Windows.Forms.ComboBox _DateCriteria;
        private System.Windows.Forms.ComboBox _DateMatchPrecision;
        private System.Windows.Forms.CheckBox _Include;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Cancel;
    }
}