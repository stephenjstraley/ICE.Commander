namespace ICE.Commander
{
    partial class AndOrTermWIN
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._orCondition = new System.Windows.Forms.RadioButton();
            this._andCondition = new System.Windows.Forms.RadioButton();
            this._terms = new System.Windows.Forms.ListView();
            this._selectedTerms = new System.Windows.Forms.ListView();
            this._selectTerm = new System.Windows.Forms.Button();
            this._removeTerm = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._accept = new System.Windows.Forms.Button();
            this._termName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 66);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 483;
            label3.Text = "Terms";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(253, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 489;
            label1.Text = "Selected Terms";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(214, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 494;
            label2.Text = "Term Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._orCondition);
            this.groupBox1.Controls.Add(this._andCondition);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // _orCondition
            // 
            this._orCondition.AutoSize = true;
            this._orCondition.Location = new System.Drawing.Point(88, 19);
            this._orCondition.Name = "_orCondition";
            this._orCondition.Size = new System.Drawing.Size(41, 17);
            this._orCondition.TabIndex = 1;
            this._orCondition.Text = "OR";
            this._orCondition.UseVisualStyleBackColor = true;
            // 
            // _andCondition
            // 
            this._andCondition.AutoSize = true;
            this._andCondition.Checked = true;
            this._andCondition.Location = new System.Drawing.Point(6, 19);
            this._andCondition.Name = "_andCondition";
            this._andCondition.Size = new System.Drawing.Size(48, 17);
            this._andCondition.TabIndex = 0;
            this._andCondition.TabStop = true;
            this._andCondition.Text = "AND";
            this._andCondition.UseVisualStyleBackColor = true;
            // 
            // _terms
            // 
            this._terms.FullRowSelect = true;
            this._terms.HideSelection = false;
            this._terms.Location = new System.Drawing.Point(16, 82);
            this._terms.Name = "_terms";
            this._terms.Size = new System.Drawing.Size(153, 222);
            this._terms.TabIndex = 487;
            this._terms.UseCompatibleStateImageBehavior = false;
            this._terms.View = System.Windows.Forms.View.Details;
            // 
            // _selectedTerms
            // 
            this._selectedTerms.FullRowSelect = true;
            this._selectedTerms.HideSelection = false;
            this._selectedTerms.Location = new System.Drawing.Point(256, 82);
            this._selectedTerms.Name = "_selectedTerms";
            this._selectedTerms.Size = new System.Drawing.Size(153, 222);
            this._selectedTerms.TabIndex = 488;
            this._selectedTerms.UseCompatibleStateImageBehavior = false;
            this._selectedTerms.View = System.Windows.Forms.View.Details;
            // 
            // _selectTerm
            // 
            this._selectTerm.Location = new System.Drawing.Point(175, 82);
            this._selectTerm.Name = "_selectTerm";
            this._selectTerm.Size = new System.Drawing.Size(75, 23);
            this._selectTerm.TabIndex = 490;
            this._selectTerm.Text = "Select";
            this._selectTerm.UseVisualStyleBackColor = true;
            this._selectTerm.Click += new System.EventHandler(this._selectTerm_Click);
            // 
            // _removeTerm
            // 
            this._removeTerm.Location = new System.Drawing.Point(415, 82);
            this._removeTerm.Name = "_removeTerm";
            this._removeTerm.Size = new System.Drawing.Size(75, 23);
            this._removeTerm.TabIndex = 491;
            this._removeTerm.Text = "Remove";
            this._removeTerm.UseVisualStyleBackColor = true;
            this._removeTerm.Click += new System.EventHandler(this._removeTerm_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(16, 330);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 492;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this._cancel_Click);
            // 
            // _accept
            // 
            this._accept.Location = new System.Drawing.Point(415, 330);
            this._accept.Name = "_accept";
            this._accept.Size = new System.Drawing.Size(75, 23);
            this._accept.TabIndex = 493;
            this._accept.Text = "Accept";
            this._accept.UseVisualStyleBackColor = true;
            this._accept.Click += new System.EventHandler(this._accept_Click);
            // 
            // _termName
            // 
            this._termName.Location = new System.Drawing.Point(282, 24);
            this._termName.Name = "_termName";
            this._termName.Size = new System.Drawing.Size(127, 20);
            this._termName.TabIndex = 495;
            this._termName.Leave += new System.EventHandler(this._termName_Leave);
            // 
            // AndOrTermWIN
            // 
            this.AcceptButton = this._accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(506, 365);
            this.Controls.Add(this._termName);
            this.Controls.Add(label2);
            this.Controls.Add(this._accept);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._removeTerm);
            this.Controls.Add(this._selectTerm);
            this.Controls.Add(label1);
            this.Controls.Add(this._selectedTerms);
            this.Controls.Add(this._terms);
            this.Controls.Add(label3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AndOrTermWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AND/OR Terms";
            this.Load += new System.EventHandler(this.AndOrTermWIN_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _orCondition;
        private System.Windows.Forms.RadioButton _andCondition;
        private System.Windows.Forms.ListView _terms;
        private System.Windows.Forms.ListView _selectedTerms;
        private System.Windows.Forms.Button _selectTerm;
        private System.Windows.Forms.Button _removeTerm;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Button _accept;
        private System.Windows.Forms.TextBox _termName;
    }
}