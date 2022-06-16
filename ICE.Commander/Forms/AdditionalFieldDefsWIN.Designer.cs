namespace ICE.Commander
{
    partial class AdditionalFieldDefsWIN
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
            this.SelectedField = new System.Windows.Forms.ComboBox();
            this.GO = new System.Windows.Forms.Button();
            this.V1Schema = new System.Windows.Forms.TextBox();
            this.V3Schema = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.V1Meta = new System.Windows.Forms.TextBox();
            this.V3Meta = new System.Windows.Forms.TextBox();
            this.CopyV1Meta = new System.Windows.Forms.Button();
            this.CopyV3Meta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field";
            // 
            // SelectedField
            // 
            this.SelectedField.FormattingEnabled = true;
            this.SelectedField.Location = new System.Drawing.Point(74, 13);
            this.SelectedField.Name = "SelectedField";
            this.SelectedField.Size = new System.Drawing.Size(203, 21);
            this.SelectedField.TabIndex = 1;
            this.SelectedField.SelectedIndexChanged += new System.EventHandler(this.SelectedField_SelectedIndexChanged);
            // 
            // GO
            // 
            this.GO.Enabled = false;
            this.GO.Location = new System.Drawing.Point(293, 11);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(57, 23);
            this.GO.TabIndex = 2;
            this.GO.Text = "GO";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // V1Schema
            // 
            this.V1Schema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V1Schema.Location = new System.Drawing.Point(13, 64);
            this.V1Schema.Multiline = true;
            this.V1Schema.Name = "V1Schema";
            this.V1Schema.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.V1Schema.Size = new System.Drawing.Size(640, 547);
            this.V1Schema.TabIndex = 3;
            // 
            // V3Schema
            // 
            this.V3Schema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V3Schema.Location = new System.Drawing.Point(672, 64);
            this.V3Schema.Multiline = true;
            this.V3Schema.Name = "V3Schema";
            this.V3Schema.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.V3Schema.Size = new System.Drawing.Size(589, 547);
            this.V3Schema.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "V1 Schema";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(669, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "V3 Schema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "V1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 650);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "V3";
            // 
            // V1Meta
            // 
            this.V1Meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V1Meta.Location = new System.Drawing.Point(30, 617);
            this.V1Meta.Name = "V1Meta";
            this.V1Meta.Size = new System.Drawing.Size(1202, 24);
            this.V1Meta.TabIndex = 9;
            // 
            // V3Meta
            // 
            this.V3Meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V3Meta.Location = new System.Drawing.Point(30, 647);
            this.V3Meta.Name = "V3Meta";
            this.V3Meta.Size = new System.Drawing.Size(1202, 24);
            this.V3Meta.TabIndex = 10;
            // 
            // CopyV1Meta
            // 
            this.CopyV1Meta.Location = new System.Drawing.Point(1238, 615);
            this.CopyV1Meta.Name = "CopyV1Meta";
            this.CopyV1Meta.Size = new System.Drawing.Size(23, 23);
            this.CopyV1Meta.TabIndex = 11;
            this.CopyV1Meta.Text = "..";
            this.CopyV1Meta.UseVisualStyleBackColor = true;
            this.CopyV1Meta.Click += new System.EventHandler(this.CopyV1Meta_Click);
            // 
            // CopyV3Meta
            // 
            this.CopyV3Meta.Location = new System.Drawing.Point(1238, 645);
            this.CopyV3Meta.Name = "CopyV3Meta";
            this.CopyV3Meta.Size = new System.Drawing.Size(23, 23);
            this.CopyV3Meta.TabIndex = 12;
            this.CopyV3Meta.Text = "..";
            this.CopyV3Meta.UseVisualStyleBackColor = true;
            this.CopyV3Meta.Click += new System.EventHandler(this.CopyV3Meta_Click);
            // 
            // AdditionalFieldDefsWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 679);
            this.Controls.Add(this.CopyV3Meta);
            this.Controls.Add(this.CopyV1Meta);
            this.Controls.Add(this.V3Meta);
            this.Controls.Add(this.V1Meta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.V3Schema);
            this.Controls.Add(this.V1Schema);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.SelectedField);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionalFieldDefsWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdditionalFIeldDefs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SelectedField;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.TextBox V1Schema;
        private System.Windows.Forms.TextBox V3Schema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox V1Meta;
        private System.Windows.Forms.TextBox V3Meta;
        private System.Windows.Forms.Button CopyV1Meta;
        private System.Windows.Forms.Button CopyV3Meta;
    }
}