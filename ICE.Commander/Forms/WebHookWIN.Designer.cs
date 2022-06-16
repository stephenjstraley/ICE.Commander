
namespace ICE.Commander
{
    partial class WebHookWIN
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            this.EllieInstance = new System.Windows.Forms.ComboBox();
            this.LoanNumber = new System.Windows.Forms.TextBox();
            this.GetGuid = new System.Windows.Forms.Button();
            this.LoanGuid = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.resourceTab = new System.Windows.Forms.TabPage();
            this.ListResources = new System.Windows.Forms.ListView();
            this.subscriptionTab = new System.Windows.Forms.TabPage();
            this.ListSubscriptions = new System.Windows.Forms.ListView();
            this.resourceEventsTab = new System.Windows.Forms.TabPage();
            this.ListResourceEvents = new System.Windows.Forms.ListView();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.Status = new System.Windows.Forms.ComboBox();
            this.GetEvents = new System.Windows.Forms.Button();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.DateRange = new System.Windows.Forms.RadioButton();
            this.Last24Hours = new System.Windows.Forms.RadioButton();
            this.ItemCount = new System.Windows.Forms.TextBox();
            this.EventType = new System.Windows.Forms.ComboBox();
            this.ResourceType = new System.Windows.Forms.ComboBox();
            this.ListEvents = new System.Windows.Forms.ListView();
            this.GoGetThem = new System.Windows.Forms.Button();
            this.SubscriptionId = new System.Windows.Forms.TextBox();
            this.FilterText = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.resourceTab.SuspendLayout();
            this.subscriptionTab.SuspendLayout();
            this.resourceEventsTab.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 13);
            label2.TabIndex = 15;
            label2.Text = "Ellie Instance";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(379, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 13);
            label1.TabIndex = 13;
            label1.Text = "Loan Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(629, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 13);
            label3.TabIndex = 18;
            label3.Text = "Loan GUID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 16);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 13);
            label4.TabIndex = 17;
            label4.Text = "Resource Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(235, 16);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 13);
            label5.TabIndex = 19;
            label5.Text = "Event Type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(30, 63);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(58, 13);
            label6.TabIndex = 21;
            label6.Text = "Item Count";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(936, 16);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 13);
            label7.TabIndex = 23;
            label7.Text = "Subscription Id";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(381, 65);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(55, 13);
            label8.TabIndex = 25;
            label8.Text = "Start Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(593, 67);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(52, 13);
            label9.TabIndex = 27;
            label9.Text = "End Date";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(447, 17);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(37, 13);
            label10.TabIndex = 30;
            label10.Text = "Status";
            // 
            // EllieInstance
            // 
            this.EllieInstance.FormattingEnabled = true;
            this.EllieInstance.Location = new System.Drawing.Point(87, 12);
            this.EllieInstance.Name = "EllieInstance";
            this.EllieInstance.Size = new System.Drawing.Size(138, 21);
            this.EllieInstance.TabIndex = 16;
            this.EllieInstance.SelectedIndexChanged += new System.EventHandler(this.EllieInstance_SelectedIndexChanged);
            // 
            // LoanNumber
            // 
            this.LoanNumber.Location = new System.Drawing.Point(456, 13);
            this.LoanNumber.Name = "LoanNumber";
            this.LoanNumber.Size = new System.Drawing.Size(113, 20);
            this.LoanNumber.TabIndex = 14;
            // 
            // GetGuid
            // 
            this.GetGuid.Location = new System.Drawing.Point(575, 10);
            this.GetGuid.Name = "GetGuid";
            this.GetGuid.Size = new System.Drawing.Size(41, 23);
            this.GetGuid.TabIndex = 17;
            this.GetGuid.Text = ">>>";
            this.GetGuid.UseVisualStyleBackColor = true;
            this.GetGuid.Click += new System.EventHandler(this.GetGuid_Click);
            // 
            // LoanGuid
            // 
            this.LoanGuid.Location = new System.Drawing.Point(706, 13);
            this.LoanGuid.Name = "LoanGuid";
            this.LoanGuid.Size = new System.Drawing.Size(224, 20);
            this.LoanGuid.TabIndex = 19;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.resourceTab);
            this.tabs.Controls.Add(this.subscriptionTab);
            this.tabs.Controls.Add(this.resourceEventsTab);
            this.tabs.Controls.Add(this.tabEvents);
            this.tabs.Location = new System.Drawing.Point(14, 39);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1368, 738);
            this.tabs.TabIndex = 20;
            // 
            // resourceTab
            // 
            this.resourceTab.Controls.Add(this.ListResources);
            this.resourceTab.Location = new System.Drawing.Point(4, 22);
            this.resourceTab.Name = "resourceTab";
            this.resourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.resourceTab.Size = new System.Drawing.Size(1360, 712);
            this.resourceTab.TabIndex = 0;
            this.resourceTab.Text = "Resources";
            this.resourceTab.UseVisualStyleBackColor = true;
            // 
            // ListResources
            // 
            this.ListResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListResources.FullRowSelect = true;
            this.ListResources.GridLines = true;
            this.ListResources.HideSelection = false;
            this.ListResources.Location = new System.Drawing.Point(3, 3);
            this.ListResources.Name = "ListResources";
            this.ListResources.Size = new System.Drawing.Size(1354, 706);
            this.ListResources.TabIndex = 1;
            this.ListResources.UseCompatibleStateImageBehavior = false;
            this.ListResources.View = System.Windows.Forms.View.Details;
            // 
            // subscriptionTab
            // 
            this.subscriptionTab.Controls.Add(this.ListSubscriptions);
            this.subscriptionTab.Location = new System.Drawing.Point(4, 22);
            this.subscriptionTab.Name = "subscriptionTab";
            this.subscriptionTab.Padding = new System.Windows.Forms.Padding(3);
            this.subscriptionTab.Size = new System.Drawing.Size(1360, 712);
            this.subscriptionTab.TabIndex = 1;
            this.subscriptionTab.Text = "Subscriptions";
            this.subscriptionTab.UseVisualStyleBackColor = true;
            // 
            // ListSubscriptions
            // 
            this.ListSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListSubscriptions.FullRowSelect = true;
            this.ListSubscriptions.GridLines = true;
            this.ListSubscriptions.HideSelection = false;
            this.ListSubscriptions.Location = new System.Drawing.Point(3, 3);
            this.ListSubscriptions.Name = "ListSubscriptions";
            this.ListSubscriptions.Size = new System.Drawing.Size(1354, 706);
            this.ListSubscriptions.TabIndex = 2;
            this.ListSubscriptions.UseCompatibleStateImageBehavior = false;
            this.ListSubscriptions.View = System.Windows.Forms.View.Details;
            this.ListSubscriptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListSubscriptions_MouseDoubleClick);
            // 
            // resourceEventsTab
            // 
            this.resourceEventsTab.Controls.Add(this.ListResourceEvents);
            this.resourceEventsTab.Location = new System.Drawing.Point(4, 22);
            this.resourceEventsTab.Name = "resourceEventsTab";
            this.resourceEventsTab.Size = new System.Drawing.Size(1360, 712);
            this.resourceEventsTab.TabIndex = 2;
            this.resourceEventsTab.Text = "Resource Events";
            this.resourceEventsTab.UseVisualStyleBackColor = true;
            // 
            // ListResourceEvents
            // 
            this.ListResourceEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListResourceEvents.FullRowSelect = true;
            this.ListResourceEvents.GridLines = true;
            this.ListResourceEvents.HideSelection = false;
            this.ListResourceEvents.Location = new System.Drawing.Point(0, 0);
            this.ListResourceEvents.Name = "ListResourceEvents";
            this.ListResourceEvents.Size = new System.Drawing.Size(1360, 712);
            this.ListResourceEvents.TabIndex = 2;
            this.ListResourceEvents.UseCompatibleStateImageBehavior = false;
            this.ListResourceEvents.View = System.Windows.Forms.View.Details;
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.FilterText);
            this.tabEvents.Controls.Add(label11);
            this.tabEvents.Controls.Add(this.Status);
            this.tabEvents.Controls.Add(label10);
            this.tabEvents.Controls.Add(this.GetEvents);
            this.tabEvents.Controls.Add(this.EndDate);
            this.tabEvents.Controls.Add(label9);
            this.tabEvents.Controls.Add(this.StartDate);
            this.tabEvents.Controls.Add(label8);
            this.tabEvents.Controls.Add(this.DateRange);
            this.tabEvents.Controls.Add(this.Last24Hours);
            this.tabEvents.Controls.Add(this.ItemCount);
            this.tabEvents.Controls.Add(label6);
            this.tabEvents.Controls.Add(this.EventType);
            this.tabEvents.Controls.Add(label5);
            this.tabEvents.Controls.Add(this.ResourceType);
            this.tabEvents.Controls.Add(label4);
            this.tabEvents.Controls.Add(this.ListEvents);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(1360, 712);
            this.tabEvents.TabIndex = 3;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "ALL",
            "EventReceived",
            "SubscriptionMatched",
            "DeliveryAttempted",
            "NotificationDelivered"});
            this.Status.Location = new System.Drawing.Point(490, 13);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(149, 21);
            this.Status.TabIndex = 31;
            // 
            // GetEvents
            // 
            this.GetEvents.Location = new System.Drawing.Point(804, 60);
            this.GetEvents.Name = "GetEvents";
            this.GetEvents.Size = new System.Drawing.Size(41, 23);
            this.GetEvents.TabIndex = 29;
            this.GetEvents.Text = "GO!";
            this.GetEvents.UseVisualStyleBackColor = true;
            this.GetEvents.Click += new System.EventHandler(this.GetEvents_Click);
            // 
            // EndDate
            // 
            this.EndDate.CustomFormat = "MM/dd/yyyy - HH:mm";
            this.EndDate.Enabled = false;
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(651, 63);
            this.EndDate.Name = "EndDate";
            this.EndDate.ShowUpDown = true;
            this.EndDate.Size = new System.Drawing.Size(130, 20);
            this.EndDate.TabIndex = 28;
            // 
            // StartDate
            // 
            this.StartDate.CustomFormat = "MM/dd/yyyy - HH:mm";
            this.StartDate.Enabled = false;
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate.Location = new System.Drawing.Point(442, 63);
            this.StartDate.Name = "StartDate";
            this.StartDate.ShowUpDown = true;
            this.StartDate.Size = new System.Drawing.Size(131, 20);
            this.StartDate.TabIndex = 26;
            // 
            // DateRange
            // 
            this.DateRange.AutoSize = true;
            this.DateRange.Location = new System.Drawing.Point(279, 61);
            this.DateRange.Name = "DateRange";
            this.DateRange.Size = new System.Drawing.Size(83, 17);
            this.DateRange.TabIndex = 24;
            this.DateRange.Text = "Date Range";
            this.DateRange.UseVisualStyleBackColor = true;
            this.DateRange.CheckedChanged += new System.EventHandler(this.DateRange_CheckedChanged);
            // 
            // Last24Hours
            // 
            this.Last24Hours.AutoSize = true;
            this.Last24Hours.Checked = true;
            this.Last24Hours.Location = new System.Drawing.Point(168, 61);
            this.Last24Hours.Name = "Last24Hours";
            this.Last24Hours.Size = new System.Drawing.Size(91, 17);
            this.Last24Hours.TabIndex = 23;
            this.Last24Hours.TabStop = true;
            this.Last24Hours.Text = "Last 24 Hours";
            this.Last24Hours.UseVisualStyleBackColor = true;
            this.Last24Hours.CheckedChanged += new System.EventHandler(this.Last24Hours_CheckedChanged);
            // 
            // ItemCount
            // 
            this.ItemCount.Location = new System.Drawing.Point(94, 60);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(39, 20);
            this.ItemCount.TabIndex = 22;
            this.ItemCount.Text = "100";
            // 
            // EventType
            // 
            this.EventType.FormattingEnabled = true;
            this.EventType.Items.AddRange(new object[] {
            "ALL",
            "create",
            "update",
            "submit",
            "change",
            "move",
            "delete",
            "milestone",
            "document",
            "fieldchange"});
            this.EventType.Location = new System.Drawing.Point(312, 13);
            this.EventType.Name = "EventType";
            this.EventType.Size = new System.Drawing.Size(129, 21);
            this.EventType.TabIndex = 20;
            // 
            // ResourceType
            // 
            this.ResourceType.FormattingEnabled = true;
            this.ResourceType.Items.AddRange(new object[] {
            "ALL",
            "Loan",
            "Transaction",
            "EnhancedConditionTemplate",
            "Task",
            "EnhancedConditionType",
            "DocumentOrder",
            "SubTask",
            "ExternalOrganization",
            "ServiceOrder",
            "Trade"});
            this.ResourceType.Location = new System.Drawing.Point(94, 13);
            this.ResourceType.Name = "ResourceType";
            this.ResourceType.Size = new System.Drawing.Size(127, 21);
            this.ResourceType.TabIndex = 18;
            // 
            // ListEvents
            // 
            this.ListEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListEvents.FullRowSelect = true;
            this.ListEvents.GridLines = true;
            this.ListEvents.HideSelection = false;
            this.ListEvents.Location = new System.Drawing.Point(0, 91);
            this.ListEvents.Name = "ListEvents";
            this.ListEvents.Size = new System.Drawing.Size(1360, 621);
            this.ListEvents.TabIndex = 16;
            this.ListEvents.UseCompatibleStateImageBehavior = false;
            this.ListEvents.View = System.Windows.Forms.View.Details;
            // 
            // GoGetThem
            // 
            this.GoGetThem.Location = new System.Drawing.Point(231, 10);
            this.GoGetThem.Name = "GoGetThem";
            this.GoGetThem.Size = new System.Drawing.Size(41, 23);
            this.GoGetThem.TabIndex = 21;
            this.GoGetThem.Text = "GET";
            this.GoGetThem.UseVisualStyleBackColor = true;
            this.GoGetThem.Click += new System.EventHandler(this.GoGetThem_Click);
            // 
            // SubscriptionId
            // 
            this.SubscriptionId.Location = new System.Drawing.Point(1019, 12);
            this.SubscriptionId.Name = "SubscriptionId";
            this.SubscriptionId.Size = new System.Drawing.Size(224, 20);
            this.SubscriptionId.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(660, 17);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(53, 13);
            label11.TabIndex = 32;
            label11.Text = "Filter Text";
            // 
            // FilterText
            // 
            this.FilterText.Location = new System.Drawing.Point(719, 13);
            this.FilterText.Name = "FilterText";
            this.FilterText.Size = new System.Drawing.Size(620, 20);
            this.FilterText.TabIndex = 33;
            // 
            // WebHookWIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 789);
            this.Controls.Add(label7);
            this.Controls.Add(this.SubscriptionId);
            this.Controls.Add(this.GoGetThem);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.LoanGuid);
            this.Controls.Add(label3);
            this.Controls.Add(this.GetGuid);
            this.Controls.Add(this.EllieInstance);
            this.Controls.Add(label2);
            this.Controls.Add(this.LoanNumber);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WebHookWIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Hook Events";
            this.Load += new System.EventHandler(this.WebHookWIN_Load);
            this.tabs.ResumeLayout(false);
            this.resourceTab.ResumeLayout(false);
            this.subscriptionTab.ResumeLayout(false);
            this.resourceEventsTab.ResumeLayout(false);
            this.tabEvents.ResumeLayout(false);
            this.tabEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EllieInstance;
        private System.Windows.Forms.TextBox LoanNumber;
        private System.Windows.Forms.Button GetGuid;
        private System.Windows.Forms.TextBox LoanGuid;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage resourceTab;
        private System.Windows.Forms.TabPage subscriptionTab;
        private System.Windows.Forms.TabPage resourceEventsTab;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.ListView ListResources;
        private System.Windows.Forms.ListView ListSubscriptions;
        private System.Windows.Forms.ListView ListResourceEvents;
        private System.Windows.Forms.Button GoGetThem;
        private System.Windows.Forms.ListView ListEvents;
        private System.Windows.Forms.ComboBox EventType;
        private System.Windows.Forms.ComboBox ResourceType;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.RadioButton DateRange;
        private System.Windows.Forms.RadioButton Last24Hours;
        private System.Windows.Forms.TextBox ItemCount;
        private System.Windows.Forms.TextBox SubscriptionId;
        private System.Windows.Forms.Button GetEvents;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.TextBox FilterText;
    }
}