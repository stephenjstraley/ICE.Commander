namespace ICE.Commander
{
    partial class CanonicalLookupWIN
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
            this.CanonicalList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CanonicalList
            // 
            this.CanonicalList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CanonicalList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CanonicalList.Dock = System.Windows.Forms.DockStyle.Top;
            this.CanonicalList.FormattingEnabled = true;
            this.CanonicalList.Location = new System.Drawing.Point(0, 0);
            this.CanonicalList.Name = "CanonicalList";
            this.CanonicalList.Size = new System.Drawing.Size(385, 21);
            this.CanonicalList.TabIndex = 0;
            this.CanonicalList.SelectedIndexChanged += new System.EventHandler(this.CanonicalList_SelectedIndexChanged);
            this.CanonicalList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CanonicalList_KeyDown);
            // 
            // CanonicalLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(385, 258);
            this.Controls.Add(this.CanonicalList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CanonicalLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Canonical Lookup";
            this.Load += new System.EventHandler(this.CanonicalLookup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CanonicalList;
    }
}