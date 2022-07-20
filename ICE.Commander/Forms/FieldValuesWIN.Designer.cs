
namespace ICE.Commander
{
    partial class FieldValuesWIN
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            this.encompassFolders = new System.Windows.Forms.ComboBox();
            this.ViewPipeline = new System.Windows.Forms.Button();
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this.LoanNumber = new System.Windows.Forms.TextBox();
            this.fieldList = new System.Windows.Forms.TextBox();
            this.statusUpdate = new System.Windows.Forms.Label();
            this.LoadLoan = new System.Windows.Forms.Button();
            this.ListFieldAndValues = new System.Windows.Forms.ListView();
            this.ExportData = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(419, 18);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 17);
            label3.TabIndex = 29;
            label3.Text = "Folder";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 20);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 17);
            label2.TabIndex = 26;
            label2.Text = "Ellie Instance";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(816, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 17);
            label1.TabIndex = 24;
            label1.Text = "Loan Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(27, 63);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 17);
            label4.TabIndex = 31;
            label4.Text = "Fields";
            // 
            // encompassFolders
            // 
            this.encompassFolders.FormattingEnabled = true;
            this.encompassFolders.Location = new System.Drawing.Point(475, 14);
            this.encompassFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.encompassFolders.Name = "encompassFolders";
            this.encompassFolders.Size = new System.Drawing.Size(271, 24);
            this.encompassFolders.TabIndex = 30;
            // 
            // ViewPipeline
            // 
            this.ViewPipeline.Location = new System.Drawing.Point(753, 12);
            this.ViewPipeline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ViewPipeline.Name = "ViewPipeline";
            this.ViewPipeline.Size = new System.Drawing.Size(35, 28);
            this.ViewPipeline.TabIndex = 28;
            this.ViewPipeline.Text = "?";
            this.ViewPipeline.UseVisualStyleBackColor = true;
            this.ViewPipeline.Click += new System.EventHandler(this.ViewPipeline_Click);
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(128, 15);
            this.EllieInstance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(271, 24);
            this.EllieInstance.TabIndex = 27;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // LoanNumber
            // 
            this.LoanNumber.Location = new System.Drawing.Point(917, 12);
            this.LoanNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoanNumber.Name = "LoanNumber";
            this.LoanNumber.Size = new System.Drawing.Size(149, 22);
            this.LoanNumber.TabIndex = 25;
            // 
            // fieldList
            // 
            this.fieldList.Location = new System.Drawing.Point(128, 63);
            this.fieldList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fieldList.Multiline = true;
            this.fieldList.Name = "fieldList";
            this.fieldList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fieldList.Size = new System.Drawing.Size(1525, 77);
            this.fieldList.TabIndex = 32;
            this.fieldList.TextChanged += new System.EventHandler(this.fieldList_TextChanged);
            // 
            // statusUpdate
            // 
            this.statusUpdate.AutoSize = true;
            this.statusUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.statusUpdate.Location = new System.Drawing.Point(136, 162);
            this.statusUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusUpdate.Name = "statusUpdate";
            this.statusUpdate.Size = new System.Drawing.Size(126, 17);
            this.statusUpdate.TabIndex = 33;
            this.statusUpdate.Text = "STATUS Update";
            // 
            // LoadLoan
            // 
            this.LoadLoan.Enabled = false;
            this.LoadLoan.Location = new System.Drawing.Point(1553, 18);
            this.LoadLoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadLoan.Name = "LoadLoan";
            this.LoadLoan.Size = new System.Drawing.Size(100, 28);
            this.LoadLoan.TabIndex = 34;
            this.LoadLoan.Text = "Load Fields";
            this.LoadLoan.UseVisualStyleBackColor = true;
            this.LoadLoan.Click += new System.EventHandler(this.LoadLoan_Click);
            // 
            // ListFieldAndValues
            // 
            this.ListFieldAndValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListFieldAndValues.FullRowSelect = true;
            this.ListFieldAndValues.GridLines = true;
            this.ListFieldAndValues.HideSelection = false;
            this.ListFieldAndValues.Location = new System.Drawing.Point(0, 192);
            this.ListFieldAndValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListFieldAndValues.Name = "ListFieldAndValues";
            this.ListFieldAndValues.Size = new System.Drawing.Size(1667, 578);
            this.ListFieldAndValues.TabIndex = 35;
            this.ListFieldAndValues.UseCompatibleStateImageBehavior = false;
            this.ListFieldAndValues.View = System.Windows.Forms.View.Details;
            // 
            // ExportData
            // 
            this.ExportData.Enabled = false;
            this.ExportData.Location = new System.Drawing.Point(1553, 157);
            this.ExportData.Margin = new System.Windows.Forms.Padding(4);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(100, 28);
            this.ExportData.TabIndex = 36;
            this.ExportData.Text = "Export";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.ExportData_Click);
            // 
            // FieldValuesWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 770);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.ListFieldAndValues);
            this.Controls.Add(this.LoadLoan);
            this.Controls.Add(this.statusUpdate);
            this.Controls.Add(this.fieldList);
            this.Controls.Add(label4);
            this.Controls.Add(this.encompassFolders);
            this.Controls.Add(label3);
            this.Controls.Add(this.ViewPipeline);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.Controls.Add(this.LoanNumber);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldValuesWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FieldValuesWIN";
            this.Load += new System.EventHandler(this.FieldValuesWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox encompassFolders;
        private System.Windows.Forms.Button ViewPipeline;
        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.TextBox LoanNumber;
        private System.Windows.Forms.TextBox fieldList;
        private System.Windows.Forms.Label statusUpdate;
        private System.Windows.Forms.Button LoadLoan;
        private System.Windows.Forms.ListView ListFieldAndValues;
        private System.Windows.Forms.Button ExportData;
    }
}