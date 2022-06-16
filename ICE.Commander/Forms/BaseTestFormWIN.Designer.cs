namespace ICE.Commander
{
    partial class BaseTestFormWIN
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
            this.LoanNumberLabel = new System.Windows.Forms.Label();
            this.ViewPipeline = new System.Windows.Forms.Button();
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this.LoanNumber = new System.Windows.Forms.TextBox();
            this.GoGetThem = new System.Windows.Forms.Button();
            this._listFields = new System.Windows.Forms.ListView();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(40, 38);
            label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(185, 32);
            label2.TabIndex = 11;
            label2.Text = "Ellie Instance";
            // 
            // LoanNumberLabel
            // 
            this.LoanNumberLabel.AutoSize = true;
            this.LoanNumberLabel.Location = new System.Drawing.Point(899, 38);
            this.LoanNumberLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LoanNumberLabel.Name = "LoanNumberLabel";
            this.LoanNumberLabel.Size = new System.Drawing.Size(186, 32);
            this.LoanNumberLabel.TabIndex = 9;
            this.LoanNumberLabel.Text = "Loan Number";
            // 
            // ViewPipeline
            // 
            this.ViewPipeline.Location = new System.Drawing.Point(803, 26);
            this.ViewPipeline.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ViewPipeline.Name = "ViewPipeline";
            this.ViewPipeline.Size = new System.Drawing.Size(69, 55);
            this.ViewPipeline.TabIndex = 13;
            this.ViewPipeline.Text = "?";
            this.ViewPipeline.UseVisualStyleBackColor = true;
            this.ViewPipeline.Click += new System.EventHandler(this.ViewPipeline_Click);
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(243, 29);
            this.EllieInstance.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(537, 39);
            this.EllieInstance.TabIndex = 12;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // LoanNumber
            // 
            this.LoanNumber.Location = new System.Drawing.Point(1104, 31);
            this.LoanNumber.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.LoanNumber.Name = "LoanNumber";
            this.LoanNumber.Size = new System.Drawing.Size(295, 38);
            this.LoanNumber.TabIndex = 10;
            // 
            // GoGetThem
            // 
            this.GoGetThem.Location = new System.Drawing.Point(1448, 26);
            this.GoGetThem.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.GoGetThem.Name = "GoGetThem";
            this.GoGetThem.Size = new System.Drawing.Size(109, 55);
            this.GoGetThem.TabIndex = 22;
            this.GoGetThem.Text = "GET";
            this.GoGetThem.UseVisualStyleBackColor = true;
            this.GoGetThem.Click += new System.EventHandler(this.GoGetThem_Click);
            // 
            // _listFields
            // 
            this._listFields.FullRowSelect = true;
            this._listFields.GridLines = true;
            this._listFields.HideSelection = false;
            this._listFields.Location = new System.Drawing.Point(32, 95);
            this._listFields.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this._listFields.Name = "_listFields";
            this._listFields.Size = new System.Drawing.Size(2657, 1056);
            this._listFields.TabIndex = 23;
            this._listFields.UseCompatibleStateImageBehavior = false;
            this._listFields.View = System.Windows.Forms.View.Details;
            this._listFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._listFields_MouseDoubleClick);
            // 
            // BaseTestFormWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2728, 1185);
            this.Controls.Add(this._listFields);
            this.Controls.Add(this.GoGetThem);
            this.Controls.Add(this.ViewPipeline);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.Controls.Add(this.LoanNumber);
            this.Controls.Add(this.LoanNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseTestFormWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseTestFormWIN";
            this.Load += new System.EventHandler(this.BaseTestFormWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.Button GoGetThem;
        protected System.Windows.Forms.ListView _listFields;
        protected System.Windows.Forms.Button ViewPipeline;
        protected System.Windows.Forms.TextBox LoanNumber;
        protected System.Windows.Forms.Label LoanNumberLabel;
    }
}