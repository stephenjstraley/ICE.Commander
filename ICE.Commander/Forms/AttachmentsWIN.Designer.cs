namespace ICE.Commander
{
    partial class AttachmentsWIN
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
            this.ListAttachments = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListAttachments
            // 
            this.ListAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListAttachments.FullRowSelect = true;
            this.ListAttachments.GridLines = true;
            this.ListAttachments.Location = new System.Drawing.Point(0, 0);
            this.ListAttachments.Name = "ListAttachments";
            this.ListAttachments.Size = new System.Drawing.Size(1017, 488);
            this.ListAttachments.TabIndex = 3;
            this.ListAttachments.UseCompatibleStateImageBehavior = false;
            this.ListAttachments.View = System.Windows.Forms.View.Details;
            this.ListAttachments.DoubleClick += new System.EventHandler(this.ListAttachments_DoubleClick);
            // 
            // Attachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 488);
            this.Controls.Add(this.ListAttachments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Attachments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AttachmentWin";
            this.Load += new System.EventHandler(this.AttachmentWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListAttachments;
    }
}