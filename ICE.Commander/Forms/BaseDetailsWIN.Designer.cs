namespace ICE.Commander
{
    partial class BaseDetailsWIN
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
            this.QueryFields = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // QueryFields
            // 
            this.QueryFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryFields.FullRowSelect = true;
            this.QueryFields.GridLines = true;
            this.QueryFields.HideSelection = false;
            this.QueryFields.Location = new System.Drawing.Point(0, 0);
            this.QueryFields.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.QueryFields.Name = "QueryFields";
            this.QueryFields.Size = new System.Drawing.Size(2595, 1240);
            this.QueryFields.TabIndex = 2;
            this.QueryFields.UseCompatibleStateImageBehavior = false;
            this.QueryFields.View = System.Windows.Forms.View.Details;
            this.QueryFields.DoubleClick += new System.EventHandler(this.QueryFields_DoubleClick);
            // 
            // BaseDetailsWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2595, 1240);
            this.Controls.Add(this.QueryFields);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseDetailsWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViewPipelineWINcs";
            this.Load += new System.EventHandler(this.BaseDetailsWIN_Load);
            this.Shown += new System.EventHandler(this.BaseDetailsWIN_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ListView QueryFields;
    }
}