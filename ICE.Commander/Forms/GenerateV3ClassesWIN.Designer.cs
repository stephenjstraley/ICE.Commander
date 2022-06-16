namespace ICE.Commander
{
    partial class GenerateV3ClassesWIN
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
            this.SelectOutputFolder = new System.Windows.Forms.Button();
            this.OutputFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Namespace = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Folder";
            // 
            // SelectOutputFolder
            // 
            this.SelectOutputFolder.Location = new System.Drawing.Point(90, 8);
            this.SelectOutputFolder.Name = "SelectOutputFolder";
            this.SelectOutputFolder.Size = new System.Drawing.Size(25, 23);
            this.SelectOutputFolder.TabIndex = 1;
            this.SelectOutputFolder.Text = "?";
            this.SelectOutputFolder.UseVisualStyleBackColor = true;
            this.SelectOutputFolder.Click += new System.EventHandler(this.SelectOutputFolder_Click);
            // 
            // OutputFolder
            // 
            this.OutputFolder.AutoSize = true;
            this.OutputFolder.Location = new System.Drawing.Point(122, 13);
            this.OutputFolder.Name = "OutputFolder";
            this.OutputFolder.Size = new System.Drawing.Size(427, 13);
            this.OutputFolder.TabIndex = 2;
            this.OutputFolder.Text = "______________________________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Class Namespace";
            // 
            // Namespace
            // 
            this.Namespace.Location = new System.Drawing.Point(125, 41);
            this.Namespace.Name = "Namespace";
            this.Namespace.Size = new System.Drawing.Size(328, 20);
            this.Namespace.TabIndex = 4;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(511, 38);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(38, 23);
            this.Generate.TabIndex = 5;
            this.Generate.Text = "GO";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(26, 81);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(523, 149);
            this.Output.TabIndex = 6;
            // 
            // GenerateV3ClassesWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 253);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.Namespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutputFolder);
            this.Controls.Add(this.SelectOutputFolder);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateV3ClassesWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate V3 Classes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerateV3ClassesWIN_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectOutputFolder;
        private System.Windows.Forms.Label OutputFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Namespace;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox Output;
    }
}