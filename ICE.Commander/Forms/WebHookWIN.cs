using ICE.SDKtoAPI;
using ICE.SDKtoAPI.LenderApiContractsV1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class WebHookWIN : Form
    {
        public static ElieConnections _con;
        protected LenderAPI _api;

        protected List<ElieConnections> _connetions = new List<ElieConnections>();

        public WebHookWIN()
        {
            InitializeComponent();
            LoadInstances();
            ResourceType.SelectedIndex = 0;
            EventType.SelectedIndex = 0;
            Status.SelectedIndex = 0;
        }
        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections(true);

        private void WebHookWIN_Load(object sender, EventArgs e)
        {
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));
        }

        private void EllieInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var theSelection = EllieInstance.SelectedItem;
            LoanGuid.Text = "";
            LoanNumber.Text = "";
            try
            {
                if (theSelection != null)
                {
                    _con = _connetions.Where(t => t.Name == theSelection?.ToString()).FirstOrDefault();

                    if (_con != null)
                    {
                        _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                        //var ttt = _api.GetTokenAsync().Result;

                        var token = Task.Run(() => _api.GetTokenAsync()).Result;

                        if (token == null)
                        {
                            MessageBox.Show("Unable to get access token for selected instance");
                            EllieInstance.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void GetGuid_Click(object sender, EventArgs e)
        {
            if (_api != null && _api.Token != null)
            {
                if (!string.IsNullOrEmpty(LoanNumber.Text))
                {
                    var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;
                    if (!string.IsNullOrEmpty(guid))
                    {
                        LoanGuid.Text = guid;
                    }
                    else
                        MessageBox.Show("Unable to find GUID for loan in selected environment");
                }
            }
            else
                MessageBox.Show("API not connected or token not available");
        }

        private void GoGetThem_Click(object sender, EventArgs e)
        {
            if (_api != null && _api.Token != null)
            {
                Parallel.Invoke(() =>
                {
                    FillResources();
                    FillSubscriptions();
                    FillResourceEvents();
                });
            }
            else
                MessageBox.Show("No API or TOKEN available");
        }

        private void FillResources()
        {
            var resources = Task.Run(() => _api.GetWebHookResourcesAsync()).Result;
            ListResources.Columns.Add("Name", 150);
            ListResources.Columns.Add("Description", 400);
            ListResources.Columns.Add("Status", 50);
            ListResources.Columns.Add("# of Events", 100);
            if (resources != null)
            {
                foreach (var r in resources)
                {
                    var item = new ListViewItem(r.Name);
                    item.SubItems.Add(r.Description);
                    item.SubItems.Add(r.Status);
                    item.SubItems.Add((r.Events == null ? 0 : r.Events.Count).ToString());
                    ListResources.Items.Add(item);
                }
            }
        }
        private void FillSubscriptions()
        {
            var subs = Task.Run(() => _api.GetWebHookSubscriptionsAsync()).Result;
            ListSubscriptions.Columns.Add("ID", 250);
            ListSubscriptions.Columns.Add("EndPoint", 400);
            ListSubscriptions.Columns.Add("SigningKey", 150);
            ListSubscriptions.Columns.Add("ClientId", 100);
            ListSubscriptions.Columns.Add("ObjectUrn", 150);
            ListSubscriptions.Columns.Add("Resource", 100);
            ListSubscriptions.Columns.Add("Instance ID", 100);
            ListSubscriptions.Columns.Add("Events");
            if (subs != null)
            {
                foreach (var s in subs)
                {
                    var item = new ListViewItem(s.SubscriptionId);
                    item.SubItems.Add(s.Endpoint);
                    item.SubItems.Add(s.Signingkey);
                    item.SubItems.Add(s.ClientId);
                    item.SubItems.Add(s.ObjectUrn);
                    item.SubItems.Add(s.Resource);
                    item.SubItems.Add(s.InstanceId);
                    // subs
                    //                    var newSub = new 
                    foreach (var ev in s.Events)
                    {

                    }

                    ListSubscriptions.Items.Add(item);
                }
            }
        }
        private void FillResourceEvents()
        {
            var res = Task.Run(() => _api.GetWebHookResourceEventsAsync()).Result;
            ListResourceEvents.Columns.Add("Name", 100);
            ListResourceEvents.Columns.Add("Extra Payload", 150);
            if (res != null)
            {
                foreach (var r in res)
                {
                    var item = new ListViewItem(r.Name);
                    item.SubItems.Add(r.ExtraPayload ? "Yes" : "No");

                    ListResourceEvents.Items.Add(item);
                }
            }

        }

        private void DateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (DateRange.Checked)
            {
                StartDate.Enabled = true;
                EndDate.Enabled = true;
            }
        }

        private void Last24Hours_CheckedChanged(object sender, EventArgs e)
        {
            if (Last24Hours.Checked)
            {
                StartDate.Enabled = false;
                EndDate.Enabled = false;
            }
        }

        private void GetEvents_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ListEvents.Refresh();
            string showMessage = "";

            ListEvents.Clear();

            var realCount = 100;
            if (!Int32.TryParse(ItemCount.Text, out realCount))
                realCount = 100;
            if (realCount < 1 || realCount > 1000)
                MessageBox.Show("Item Count too small or too large.   Resetting to 100");

            if (DateRange.Checked && StartDate.Value > EndDate.Value)
            {
                showMessage = "Starting date is greating that Ending Date - please adjust";
            }
            else
            {
                var parms = new WebHookEventParameters();
                var typeVal = EventType.SelectedItem.ToString();
                if (string.IsNullOrEmpty(typeVal) || typeVal == "ALL") { }
                else
                    parms.EventType = typeVal;

                var resourceVal = ResourceType.SelectedItem.ToString();
                if (string.IsNullOrEmpty(resourceVal) || resourceVal == "ALL") { }
                else
                    parms.ResourceType = resourceVal;

                var statusVal = Status.SelectedItem.ToString();
                if (string.IsNullOrEmpty(statusVal) || resourceVal == "ALL") { }
                else
                    parms.Status = statusVal;

                if (!string.IsNullOrEmpty(LoanGuid.Text))
                    parms.ResourceId = LoanGuid.Text;

                if (!string.IsNullOrEmpty(SubscriptionId.Text))
                    parms.SubscriptionId = SubscriptionId.Text;

                if (!string.IsNullOrEmpty(FilterText.Text))
                    parms.FilterText = FilterText.Text;

                if (DateRange.Checked)
                {
                    parms.StartTime = StartDate.Value;
                    parms.EndTime = EndDate.Value;
                }

                if (realCount < parms.Limit)
                    parms.Limit = realCount;

                ListEvents.Columns.Add("Id", 0);
                ListEvents.Columns.Add("Client ID", 75);
                ListEvents.Columns.Add("Event Type", 60);
                ListEvents.Columns.Add("Resource Type", 100);
                ListEvents.Columns.Add("Status", 150);
                ListEvents.Columns.Add("Details", 200);
                ListEvents.Columns.Add("Event Time", 150);
                ListEvents.Columns.Add("Instance Id", 75);
                ListEvents.Columns.Add("Resource Id", 250);
                ListEvents.Columns.Add("Subscription Id", 250);

                var events = Task.Run(() => _api.GetWebHookEventsAsync(realCount, parms)).Result;
                if (events != null)
                {
                    foreach (var ev in events)
                    {
                        var item = new ListViewItem(ev.Id);
                        item.SubItems.Add(ev.Event.ClientId);
                        item.SubItems.Add(ev.Event.EventType);
                        item.SubItems.Add(ev.Event.ResourceType);
                        item.SubItems.Add(ev.Event.Status);
                        item.SubItems.Add(ev.Event.StatusDetails);
                        item.SubItems.Add(ev.Event.EventTime.ToString());
                        item.SubItems.Add(ev.Event.InstanceId);
                        item.SubItems.Add(ev.Event.ResourceId);
                        item.SubItems.Add(ev.Event.SubscriptionId);

                        ListEvents.Items.Add(item);

                    }

                    if (_api.IsOkStatus)
                        showMessage = $"Scan complete - {events.Count} Results Returned";
                    else
                        showMessage = _api.LastMessage;
                }
                else
                    showMessage = $"Error: {_api.LastMessage}";
            }

            Cursor.Current = Cursors.Default;
            ListEvents.Refresh();
            MessageBox.Show(showMessage);
        }

        private void ListSubscriptions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SubscriptionId.Text = ListSubscriptions.FocusedItem.Text;
        }
    }
}
