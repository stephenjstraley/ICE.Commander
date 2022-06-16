namespace ICE.Commander
{
    partial class OutputFieldSelectionWIN
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
            this._outputFields = new System.Windows.Forms.ListView();
            this._accept = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._searchFor = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 49);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 13);
            label1.TabIndex = 489;
            label1.Text = "Select Field(s)";
            // 
            // _outputFields
            // 
            this._outputFields.FullRowSelect = true;
            this._outputFields.GridLines = true;
            this._outputFields.HideSelection = false;
            this._outputFields.Location = new System.Drawing.Point(12, 65);
            this._outputFields.Name = "_outputFields";
            this._outputFields.Size = new System.Drawing.Size(446, 443);
            this._outputFields.TabIndex = 488;
            this._outputFields.UseCompatibleStateImageBehavior = false;
            this._outputFields.View = System.Windows.Forms.View.Details;
            // 
            // _accept
            // 
            this._accept.Location = new System.Drawing.Point(383, 514);
            this._accept.Name = "_accept";
            this._accept.Size = new System.Drawing.Size(75, 23);
            this._accept.TabIndex = 490;
            this._accept.Text = "OK";
            this._accept.UseVisualStyleBackColor = true;
            this._accept.Click += new System.EventHandler(this._accept_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(10, 514);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 491;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 18);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 13);
            label2.TabIndex = 492;
            label2.Text = "Search";
            // 
            // _searchFor
            // 
            this._searchFor.Location = new System.Drawing.Point(59, 15);
            this._searchFor.Name = "_searchFor";
            this._searchFor.Size = new System.Drawing.Size(165, 20);
            this._searchFor.TabIndex = 1;
            this._searchFor.TextChanged += new System.EventHandler(this._searchFor_TextChanged);
            // 
            // OutputFieldSelectionWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(470, 545);
            this.Controls.Add(this._searchFor);
            this.Controls.Add(label2);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._accept);
            this.Controls.Add(label1);
            this.Controls.Add(this._outputFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutputFieldSelectionWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select FIelds for Output Query";
            this.Load += new System.EventHandler(this.OutputFieldSelectionWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _outputFields;
        private System.Windows.Forms.Button _accept;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.TextBox _searchFor;
    }
}