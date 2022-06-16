namespace ICE.Commander
{
    partial class QueryContractWIN
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
            this._contract = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _contract
            // 
            this._contract.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contract.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._contract.Location = new System.Drawing.Point(0, 0);
            this._contract.Multiline = true;
            this._contract.Name = "_contract";
            this._contract.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._contract.Size = new System.Drawing.Size(1005, 611);
            this._contract.TabIndex = 0;
            // 
            // QueryContractWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 611);
            this.Controls.Add(this._contract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryContractWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pipeline Contract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _contract;
    }
}