
namespace ICE.Commander
{
    partial class FieldSchemaWIN
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
            this.CopyV3Meta = new System.Windows.Forms.Button();
            this.CopyV1Meta = new System.Windows.Forms.Button();
            this.V3Meta = new System.Windows.Forms.TextBox();
            this.V1Meta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.V3Schema = new System.Windows.Forms.TextBox();
            this.V1Schema = new System.Windows.Forms.TextBox();
            this.GO = new System.Windows.Forms.Button();
            this.SelectedField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CopyV3Meta
            // 
            this.CopyV3Meta.Location = new System.Drawing.Point(1246, 655);
            this.CopyV3Meta.Name = "CopyV3Meta";
            this.CopyV3Meta.Size = new System.Drawing.Size(23, 23);
            this.CopyV3Meta.TabIndex = 25;
            this.CopyV3Meta.Text = "..";
            this.CopyV3Meta.UseVisualStyleBackColor = true;
            // 
            // CopyV1Meta
            // 
            this.CopyV1Meta.Location = new System.Drawing.Point(1246, 625);
            this.CopyV1Meta.Name = "CopyV1Meta";
            this.CopyV1Meta.Size = new System.Drawing.Size(23, 23);
            this.CopyV1Meta.TabIndex = 24;
            this.CopyV1Meta.Text = "..";
            this.CopyV1Meta.UseVisualStyleBackColor = true;
            // 
            // V3Meta
            // 
            this.V3Meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V3Meta.Location = new System.Drawing.Point(38, 657);
            this.V3Meta.Name = "V3Meta";
            this.V3Meta.Size = new System.Drawing.Size(1202, 24);
            this.V3Meta.TabIndex = 23;
            // 
            // V1Meta
            // 
            this.V1Meta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V1Meta.Location = new System.Drawing.Point(38, 627);
            this.V1Meta.Name = "V1Meta";
            this.V1Meta.Size = new System.Drawing.Size(1202, 24);
            this.V1Meta.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 660);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "V3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 630);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "V1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "V3 Schema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "V1 Schema";
            // 
            // V3Schema
            // 
            this.V3Schema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V3Schema.Location = new System.Drawing.Point(680, 74);
            this.V3Schema.Multiline = true;
            this.V3Schema.Name = "V3Schema";
            this.V3Schema.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.V3Schema.Size = new System.Drawing.Size(589, 547);
            this.V3Schema.TabIndex = 17;
            // 
            // V1Schema
            // 
            this.V1Schema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V1Schema.Location = new System.Drawing.Point(21, 74);
            this.V1Schema.Multiline = true;
            this.V1Schema.Name = "V1Schema";
            this.V1Schema.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.V1Schema.Size = new System.Drawing.Size(640, 547);
            this.V1Schema.TabIndex = 16;
            // 
            // GO
            // 
            this.GO.Enabled = false;
            this.GO.Location = new System.Drawing.Point(362, 21);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(57, 23);
            this.GO.TabIndex = 15;
            this.GO.Text = "GO";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // SelectedField
            // 
            this.SelectedField.FormattingEnabled = true;
            this.SelectedField.Location = new System.Drawing.Point(82, 23);
            this.SelectedField.Name = "SelectedField";
            this.SelectedField.Size = new System.Drawing.Size(274, 21);
            this.SelectedField.TabIndex = 14;
            this.SelectedField.SelectedIndexChanged += new System.EventHandler(this.SelectedField_SelectedIndexChanged);
            this.SelectedField.Enter += new System.EventHandler(this.SelectedField_Enter);
            this.SelectedField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedField_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Field";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(1182, 26);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(31, 13);
            this.Message.TabIndex = 26;
            this.Message.Text = "MSG";
            this.Message.Visible = false;
            // 
            // FieldSchemaWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 710);
            this.Controls.Add(this.Message);
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
            this.Name = "FieldSchemaWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FieldSchemaWIN";
            this.Load += new System.EventHandler(this.FieldSchemaWIN_Load);
            this.Shown += new System.EventHandler(this.FieldSchemaWIN_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyV3Meta;
        private System.Windows.Forms.Button CopyV1Meta;
        private System.Windows.Forms.TextBox V3Meta;
        private System.Windows.Forms.TextBox V1Meta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox V3Schema;
        private System.Windows.Forms.TextBox V1Schema;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.ComboBox SelectedField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Message;
    }
}