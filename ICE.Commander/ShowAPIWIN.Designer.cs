namespace ICE.Commander
{
    partial class ShowAPIWIN
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
            this.callingAPI = new System.Windows.Forms.TextBox();
            this.Retry = new System.Windows.Forms.Button();
            this.CloseWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // callingAPI
            // 
            this.callingAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.callingAPI.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callingAPI.Location = new System.Drawing.Point(0, 0);
            this.callingAPI.Multiline = true;
            this.callingAPI.Name = "callingAPI";
            this.callingAPI.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.callingAPI.Size = new System.Drawing.Size(800, 405);
            this.callingAPI.TabIndex = 0;
            // 
            // Retry
            // 
            this.Retry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Retry.Location = new System.Drawing.Point(12, 415);
            this.Retry.Name = "Retry";
            this.Retry.Size = new System.Drawing.Size(75, 23);
            this.Retry.TabIndex = 1;
            this.Retry.Text = "Retry";
            this.Retry.UseVisualStyleBackColor = true;
            this.Retry.Click += new System.EventHandler(this.Retry_Click);
            // 
            // CloseWindow
            // 
            this.CloseWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseWindow.Location = new System.Drawing.Point(713, 415);
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(75, 23);
            this.CloseWindow.TabIndex = 2;
            this.CloseWindow.Text = "Close";
            this.CloseWindow.UseVisualStyleBackColor = true;
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // ShowAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseWindow);
            this.Controls.Add(this.Retry);
            this.Controls.Add(this.callingAPI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowAPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show API Call";
            this.Load += new System.EventHandler(this.ShowAPI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox callingAPI;
        private System.Windows.Forms.Button Retry;
        private System.Windows.Forms.Button CloseWindow;
    }
}