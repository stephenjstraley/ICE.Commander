namespace ICE.Commander
{
    partial class QuerySourceWIN
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
            this.SourceCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SourceCode
            // 
            this.SourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SourceCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceCode.Location = new System.Drawing.Point(0, 0);
            this.SourceCode.Multiline = true;
            this.SourceCode.Name = "SourceCode";
            this.SourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SourceCode.Size = new System.Drawing.Size(1251, 558);
            this.SourceCode.TabIndex = 0;
            this.SourceCode.WordWrap = false;
            // 
            // QuerySourceWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 558);
            this.Controls.Add(this.SourceCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuerySourceWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Source for Query";
            this.Load += new System.EventHandler(this.QuerySourceWINcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SourceCode;
    }
}