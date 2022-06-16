namespace ICE.Commander
{
    partial class RateLockDetailsWIN
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
            this.RateLockTab = new System.Windows.Forms.TabControl();
            this.DetailsPage = new System.Windows.Forms.TabPage();
            this.SnapShotPage = new System.Windows.Forms.TabPage();
            this.ListDetails = new System.Windows.Forms.ListView();
            this.ListSnapShot = new System.Windows.Forms.ListView();
            this.RateLockTab.SuspendLayout();
            this.DetailsPage.SuspendLayout();
            this.SnapShotPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // RateLockTab
            // 
            this.RateLockTab.Controls.Add(this.DetailsPage);
            this.RateLockTab.Controls.Add(this.SnapShotPage);
            this.RateLockTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateLockTab.Location = new System.Drawing.Point(0, 0);
            this.RateLockTab.Name = "RateLockTab";
            this.RateLockTab.SelectedIndex = 0;
            this.RateLockTab.Size = new System.Drawing.Size(800, 450);
            this.RateLockTab.TabIndex = 0;
            // 
            // DetailsPage
            // 
            this.DetailsPage.Controls.Add(this.ListDetails);
            this.DetailsPage.Location = new System.Drawing.Point(4, 22);
            this.DetailsPage.Name = "DetailsPage";
            this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsPage.Size = new System.Drawing.Size(792, 424);
            this.DetailsPage.TabIndex = 0;
            this.DetailsPage.Text = "Details";
            this.DetailsPage.UseVisualStyleBackColor = true;
            // 
            // SnapShotPage
            // 
            this.SnapShotPage.Controls.Add(this.ListSnapShot);
            this.SnapShotPage.Location = new System.Drawing.Point(4, 22);
            this.SnapShotPage.Name = "SnapShotPage";
            this.SnapShotPage.Padding = new System.Windows.Forms.Padding(3);
            this.SnapShotPage.Size = new System.Drawing.Size(792, 424);
            this.SnapShotPage.TabIndex = 1;
            this.SnapShotPage.Text = "Snap Shot";
            this.SnapShotPage.UseVisualStyleBackColor = true;
            // 
            // ListDetails
            // 
            this.ListDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDetails.FullRowSelect = true;
            this.ListDetails.GridLines = true;
            this.ListDetails.Location = new System.Drawing.Point(3, 3);
            this.ListDetails.Name = "ListDetails";
            this.ListDetails.Size = new System.Drawing.Size(786, 418);
            this.ListDetails.TabIndex = 1;
            this.ListDetails.UseCompatibleStateImageBehavior = false;
            this.ListDetails.View = System.Windows.Forms.View.Details;
            // 
            // ListSnapShot
            // 
            this.ListSnapShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListSnapShot.FullRowSelect = true;
            this.ListSnapShot.GridLines = true;
            this.ListSnapShot.Location = new System.Drawing.Point(3, 3);
            this.ListSnapShot.Name = "ListSnapShot";
            this.ListSnapShot.Size = new System.Drawing.Size(786, 418);
            this.ListSnapShot.TabIndex = 1;
            this.ListSnapShot.UseCompatibleStateImageBehavior = false;
            this.ListSnapShot.View = System.Windows.Forms.View.Details;
            // 
            // RateLockDetailsWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RateLockTab);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RateLockDetailsWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rate Lock Details";
            this.Load += new System.EventHandler(this.RateLockDetailsWIN_Load);
            this.RateLockTab.ResumeLayout(false);
            this.DetailsPage.ResumeLayout(false);
            this.SnapShotPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl RateLockTab;
        private System.Windows.Forms.TabPage DetailsPage;
        private System.Windows.Forms.TabPage SnapShotPage;
        private System.Windows.Forms.ListView ListDetails;
        private System.Windows.Forms.ListView ListSnapShot;
    }
}