namespace ICE.Commander
{
    partial class ViewAllFieldDefinitionsWIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfFields = new System.Windows.Forms.Label();
            this.GO = new System.Windows.Forms.Button();
            this.Additions = new System.Windows.Forms.Button();
            this.QueryFields = new System.Windows.Forms.ListView();
            this.Status = new System.Windows.Forms.Label();
            this.ExportData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of API Fields";
            // 
            // NumberOfFields
            // 
            this.NumberOfFields.AutoSize = true;
            this.NumberOfFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfFields.ForeColor = System.Drawing.SystemColors.Highlight;
            this.NumberOfFields.Location = new System.Drawing.Point(124, 9);
            this.NumberOfFields.Name = "NumberOfFields";
            this.NumberOfFields.Size = new System.Drawing.Size(39, 13);
            this.NumberOfFields.TabIndex = 1;
            this.NumberOfFields.Text = "XXXX";
            // 
            // GO
            // 
            this.GO.Location = new System.Drawing.Point(695, 4);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(75, 23);
            this.GO.TabIndex = 2;
            this.GO.Text = "GO";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // Additions
            // 
            this.Additions.Enabled = false;
            this.Additions.Location = new System.Drawing.Point(1089, 517);
            this.Additions.Name = "Additions";
            this.Additions.Size = new System.Drawing.Size(75, 23);
            this.Additions.TabIndex = 8;
            this.Additions.Text = "Additions";
            this.Additions.UseVisualStyleBackColor = true;
            this.Additions.Click += new System.EventHandler(this.Additions_Click);
            // 
            // QueryFields
            // 
            this.QueryFields.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QueryFields.FullRowSelect = true;
            this.QueryFields.GridLines = true;
            this.QueryFields.HideSelection = false;
            this.QueryFields.Location = new System.Drawing.Point(0, 33);
            this.QueryFields.Name = "QueryFields";
            this.QueryFields.Size = new System.Drawing.Size(1176, 519);
            this.QueryFields.TabIndex = 9;
            this.QueryFields.UseCompatibleStateImageBehavior = false;
            this.QueryFields.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(259, 9);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(106, 13);
            this.Status.TabIndex = 10;
            this.Status.Text = "Number of API Fields";
            // 
            // ExportData
            // 
            this.ExportData.Enabled = false;
            this.ExportData.Location = new System.Drawing.Point(1089, 4);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(75, 23);
            this.ExportData.TabIndex = 11;
            this.ExportData.Text = "Export";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewAllFieldDefinitionsWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 552);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.QueryFields);
            this.Controls.Add(this.Additions);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.NumberOfFields);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewAllFieldDefinitionsWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Standard Field Definitions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ValidateAPIFieldWIN_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NumberOfFields;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.Button Additions;
        protected System.Windows.Forms.ListView QueryFields;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button ExportData;
    }
}