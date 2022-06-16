namespace ICE.Commander
{
    partial class UpdateFieldWIN
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
            this.FieldID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FieldValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Slot = new System.Windows.Forms.Label();
            this.CancelUpdateButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Differences = new System.Windows.Forms.ListView();
            this.Status = new System.Windows.Forms.Label();
            this.ExportIt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field ID";
            // 
            // FieldID
            // 
            this.FieldID.AutoSize = true;
            this.FieldID.Location = new System.Drawing.Point(111, 29);
            this.FieldID.Name = "FieldID";
            this.FieldID.Size = new System.Drawing.Size(35, 13);
            this.FieldID.TabIndex = 1;
            this.FieldID.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // FieldValue
            // 
            this.FieldValue.AutoSize = true;
            this.FieldValue.Location = new System.Drawing.Point(111, 57);
            this.FieldValue.Name = "FieldValue";
            this.FieldValue.Size = new System.Drawing.Size(35, 13);
            this.FieldValue.TabIndex = 3;
            this.FieldValue.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Value";
            // 
            // Slot
            // 
            this.Slot.AutoSize = true;
            this.Slot.Location = new System.Drawing.Point(111, 86);
            this.Slot.Name = "Slot";
            this.Slot.Size = new System.Drawing.Size(35, 13);
            this.Slot.TabIndex = 5;
            this.Slot.Text = "label4";
            // 
            // CancelUpdateButton
            // 
            this.CancelUpdateButton.Location = new System.Drawing.Point(12, 595);
            this.CancelUpdateButton.Name = "CancelUpdateButton";
            this.CancelUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.CancelUpdateButton.TabIndex = 6;
            this.CancelUpdateButton.Text = "Cancel";
            this.CancelUpdateButton.UseVisualStyleBackColor = true;
            this.CancelUpdateButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(749, 595);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Differences
            // 
            this.Differences.FullRowSelect = true;
            this.Differences.GridLines = true;
            this.Differences.Location = new System.Drawing.Point(12, 152);
            this.Differences.MultiSelect = false;
            this.Differences.Name = "Differences";
            this.Differences.Size = new System.Drawing.Size(812, 426);
            this.Differences.TabIndex = 8;
            this.Differences.UseCompatibleStateImageBehavior = false;
            this.Differences.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Status.Location = new System.Drawing.Point(12, 133);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 9;
            // 
            // ExportIt
            // 
            this.ExportIt.Enabled = false;
            this.ExportIt.Location = new System.Drawing.Point(749, 123);
            this.ExportIt.Name = "ExportIt";
            this.ExportIt.Size = new System.Drawing.Size(75, 23);
            this.ExportIt.TabIndex = 10;
            this.ExportIt.Text = "Export";
            this.ExportIt.UseVisualStyleBackColor = true;
            this.ExportIt.Click += new System.EventHandler(this.ExportIt_Click);
            // 
            // UpdateFieldWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 630);
            this.Controls.Add(this.ExportIt);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Differences);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.CancelUpdateButton);
            this.Controls.Add(this.Slot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FieldValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FieldID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateFieldWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Field";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateFieldWIN_FormClosed);
            this.Load += new System.EventHandler(this.UpdateFieldWIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FieldID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FieldValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Slot;
        private System.Windows.Forms.Button CancelUpdateButton;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ListView Differences;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button ExportIt;

    }
}