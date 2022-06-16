namespace ICE.Commander
{
    partial class FieldComparerWIN
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
            this.ViewPipeline = new System.Windows.Forms.Button();
            this.LoadLoan = new System.Windows.Forms.Button();
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this.LoanNumber = new System.Windows.Forms.TextBox();
            this.ListFieldAndValues = new System.Windows.Forms.ListView();
            this.statusUpdate = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 13);
            label2.TabIndex = 11;
            label2.Text = "Ellie Instance";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(340, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 13);
            label1.TabIndex = 9;
            label1.Text = "Loan Number";
            // 
            // ViewPipeline
            // 
            this.ViewPipeline.Location = new System.Drawing.Point(304, 16);
            this.ViewPipeline.Name = "ViewPipeline";
            this.ViewPipeline.Size = new System.Drawing.Size(26, 23);
            this.ViewPipeline.TabIndex = 14;
            this.ViewPipeline.Text = "?";
            this.ViewPipeline.UseVisualStyleBackColor = true;
            this.ViewPipeline.Click += new System.EventHandler(this.ViewPipeline_Click);
            // 
            // LoadLoan
            // 
            this.LoadLoan.Location = new System.Drawing.Point(550, 15);
            this.LoadLoan.Name = "LoadLoan";
            this.LoadLoan.Size = new System.Drawing.Size(75, 23);
            this.LoadLoan.TabIndex = 13;
            this.LoadLoan.Text = "Load Loan";
            this.LoadLoan.UseVisualStyleBackColor = true;
            this.LoadLoan.Click += new System.EventHandler(this.LoadLoanForCompare_Click);
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(94, 17);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(204, 21);
            this.EllieInstance.TabIndex = 12;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // LoanNumber
            // 
            this.LoanNumber.Location = new System.Drawing.Point(417, 18);
            this.LoanNumber.Name = "LoanNumber";
            this.LoanNumber.Size = new System.Drawing.Size(113, 20);
            this.LoanNumber.TabIndex = 10;
            // 
            // ListFieldAndValues
            // 
            this.ListFieldAndValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListFieldAndValues.FullRowSelect = true;
            this.ListFieldAndValues.GridLines = true;
            this.ListFieldAndValues.HideSelection = false;
            this.ListFieldAndValues.Location = new System.Drawing.Point(0, 79);
            this.ListFieldAndValues.Name = "ListFieldAndValues";
            this.ListFieldAndValues.Size = new System.Drawing.Size(1245, 622);
            this.ListFieldAndValues.TabIndex = 15;
            this.ListFieldAndValues.UseCompatibleStateImageBehavior = false;
            this.ListFieldAndValues.View = System.Windows.Forms.View.Details;
            // 
            // statusUpdate
            // 
            this.statusUpdate.AutoSize = true;
            this.statusUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusUpdate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.statusUpdate.Location = new System.Drawing.Point(18, 50);
            this.statusUpdate.Name = "statusUpdate";
            this.statusUpdate.Size = new System.Drawing.Size(101, 13);
            this.statusUpdate.TabIndex = 16;
            this.statusUpdate.Text = "STATUS Update";
            // 
            // FieldComparerWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 701);
            this.Controls.Add(this.statusUpdate);
            this.Controls.Add(this.ListFieldAndValues);
            this.Controls.Add(this.ViewPipeline);
            this.Controls.Add(this.LoadLoan);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.Controls.Add(this.LoanNumber);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldComparerWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Field Comparer";
            this.Load += new System.EventHandler(this.FieldComparerWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewPipeline;
        private System.Windows.Forms.Button LoadLoan;
        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.TextBox LoanNumber;
        private System.Windows.Forms.ListView ListFieldAndValues;
        private System.Windows.Forms.Label statusUpdate;
    }
}