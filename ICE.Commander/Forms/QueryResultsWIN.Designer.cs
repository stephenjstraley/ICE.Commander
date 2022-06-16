namespace ICE.Commander
{
    partial class QueryResultsWIN
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
            this._queryFields = new System.Windows.Forms.ListView();
            this.Export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _queryFields
            // 
            this._queryFields.Dock = System.Windows.Forms.DockStyle.Top;
            this._queryFields.FullRowSelect = true;
            this._queryFields.GridLines = true;
            this._queryFields.HideSelection = false;
            this._queryFields.Location = new System.Drawing.Point(0, 0);
            this._queryFields.Name = "_queryFields";
            this._queryFields.Size = new System.Drawing.Size(1419, 557);
            this._queryFields.TabIndex = 1;
            this._queryFields.UseCompatibleStateImageBehavior = false;
            this._queryFields.View = System.Windows.Forms.View.Details;
            this._queryFields.DoubleClick += new System.EventHandler(this.QueryFields_DoubleClick);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(12, 567);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(65, 24);
            this.Export.TabIndex = 2;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Exports_Click);
            // 
            // QueryResultsWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 603);
            this.Controls.Add(this.Export);
            this.Controls.Add(this._queryFields);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryResultsWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Results";
            this.Load += new System.EventHandler(this.QueryResultsWIN_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _queryFields;
        private System.Windows.Forms.Button Export;
    }
}