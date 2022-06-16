using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using ICE.SDKtoAPI.LenderApiContractsV1;
using ICE.SDKtoAPI.LenderApiContractsV3;
using Newtonsoft.Json;
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
    public partial class FieldUpdaterWIN : Form
    {
        public static ElieConnections _con;
        public static List<string> _pairIds = new List<string>();

        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        protected string _object = string.Empty;
        List<string> _canonicalFields = new List<string>();

        protected int _lastFoundTab = -1;
        protected int[] _searchTabs = new int[] { -1, 0, 1, 2, 3, 9 };
        protected LenderAPI _api;

        public FieldUpdaterWIN()
        {
            InitializeComponent();
            LoadInstances();

            LoanLockStatus.Text = "";
        }

        private void FieldUpdaterWIN_Load(object sender, EventArgs e)
        {
            // load the combo boxes with instances
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));

        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private void LoadLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(LoanNumber.Text) && EllieInstance.SelectedIndex >= 0)
                {
                    // Set the tab to the first one
                    _loanDetails.SelectedIndex = 0;
                    GetDetails();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        protected async Task LoadingLoan()
        {
            _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();

            _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

            LoadLoan.Enabled = false;

            GetDetails();
        }

        protected async void GetDetails()
        {
            UpdateStatus("Clearning Grids");

            _object = "";
            JSonText.Text = "";
            _listFields.Clear();
            _listDynamicFields.Clear();
            ListCustomFields.Clear();
            ListVirtualFields.Clear();
            ListUsers.Clear();
            ListDocuments.Clear();
            ListMilestones.Clear();
            ListUWConditions.Clear();


            Cursor.Current = Cursors.WaitCursor;

            UpdateStatus("Acquiring Token");

            await Task.Run(() => _api.GetTokenAsync());

            if (_api.Token != null)  // (loan.HasAccessToken)
            {
                UpdateStatus("Getting Loan Guid");

                await Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text));

                UpdateStatus("Fully Loading Loan");

                var gotLoan = Task.Run(() => _api.GetFullLoanAsync()).Result;

                if (gotLoan)
                {
                    UpdateStatus("Building Canonical Fields");

                    BuildCanonicalFields();

                    Cursor.Current = Cursors.WaitCursor;
                    LoanLockStatus.Text = Task.Run(() => _api.IsLoanLocked).Result ? "LOCKED" : "Not Locked";

                    Parallel.Invoke(() =>
                    {
                        PopulateJson();
                        PopulateFields();
                        //PopulateReportableFields(loan);
                        //                        PopulateDynamicFields(loan);
                        //                        PopulateVirtualFields(loan);
                        //                        PopulateCustomFields(loan);
                        //                        PopulateUsers(loan);
                        //                        PopulateDocuments(loan);
                        //                        PopulateMilestones(loan);
                        //                        PopulateUWConditions(loan);
                        //                        PopulateRateLocks(loan);
                    });

                    FieldSearch.Enabled = true;
                    Search.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Unable to find specified loan in the selected environment");
                    LoadLoan.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Unable to obtain token for credentials");
                LoadLoan.Enabled = false;
            }

            UpdateStatus("");
            Cursor.Current = Cursors.Default;
        }

        private void EllieInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var theSelection = EllieInstance.SelectedItem;
            try
            {
                _con = _connetions.Where(t => t.Name == theSelection?.ToString()).FirstOrDefault();

                if (_con != null)
                {
                    _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                    Task.Run(() => _api.GetTokenAsync()).Wait();

                    if (_api.Token == null)
                    {
                        MessageBox.Show("Unable to get access token for selected instance");
                        EllieInstance.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        protected void PopulateJson()
        {
            // Text Box
            _object = _api.Serialize();
            var t = JsonConvert.DeserializeObject(_object);
            JSonText.Text = JsonConvert.SerializeObject(t, Formatting.Indented);
        }
        protected void PopulateFields()
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateStatus("Populating Fields");

            _listFields.Columns.Add("ID", 200);
            _listFields.Columns.Add("Value", 500);
            _listFields.Columns.Add("Type");
            _listFields.Columns.Add("Enum");
            _listFields.Columns.Add("Meta", 50);
            _listFields.Columns.Add("R/O");
            _listFields.Columns.Add("Desc", 300);

            var theFields = Task.Run(() => _api.FieldSchema).Result;

            foreach (var field in theFields)
            {
                try
                {
                    var item = new ListViewItem(field.Key);
                    var value = _api.Fields[field.Key];
                    if (value != null)
                        item.SubItems.Add(value.ToString());
                    else
                        item.SubItems.Add("");

                    item.SubItems.Add(field.Type);
                    item.SubItems.Add(!string.IsNullOrEmpty(field.ENum) ? "Yes" : "");
                    item.SubItems.Add(field.Meta);
                    item.SubItems.Add(field.ReadOnly.ToString());
                    item.SubItems.Add(field.Description);

                    _listFields.Items.Add(item);

                    // Now check to see if there are pairs
                    if (_pairIds.Contains(field.Key))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            var k = $"{field.Key}#{i}";
                            item = new ListViewItem(k);
                            item.BackColor = Color.LightBlue;
                            value = _api.Fields[k];
                            if (value != null)
                                item.SubItems.Add(value.ToString());
                            else
                                item.SubItems.Add("");

                            item.SubItems.Add(field.Type);
                            item.SubItems.Add(!string.IsNullOrEmpty(field.ENum) ? "Yes" : "");
                            item.SubItems.Add(field.Meta);
                            item.SubItems.Add(field.ReadOnly.ToString());
                            item.SubItems.Add(field.Description);

                            _listFields.Items.Add(item);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(field.Key);
                }
            }

            UpdateStatus(string.Empty);
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateDynamicFields()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listDynamicFields.Columns.Add("ID", 100, HorizontalAlignment.Left);
            _listDynamicFields.Columns.Add("Value", 400, HorizontalAlignment.Left);
            _listDynamicFields.Columns.Add("Type", 100, HorizontalAlignment.Left);
            _listDynamicFields.Columns.Add("Meta", 100, HorizontalAlignment.Left);
            _listDynamicFields.Columns.Add("R/O", 100, HorizontalAlignment.Left);
            _listDynamicFields.Columns.Add("Desc", 400, HorizontalAlignment.Left);

            var schema = Task.Run(() => _api.DynamicSchema).Result;

            foreach (var field in schema)
            {
                var groups = field.Key.Split(')');
                var newKey = groups[0].Replace("^(", "");
                newKey += "00";
                newKey += groups[2].Replace("(", "").Replace("$", string.Empty);

                //Console.WriteLine(newKey);

                var item = new ListViewItem(newKey);
                var value = Task.Run(() => _api.Fields[newKey]).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                else
                    item.SubItems.Add(string.Empty);

                item.SubItems.Add(field.Type);
                item.SubItems.Add(field.Meta);
                item.SubItems.Add(field.ReadOnly.ToString());
                item.SubItems.Add(field.Description);

                _listDynamicFields.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateCustomFields()
        {
            Cursor.Current = Cursors.WaitCursor;
            ListCustomFields.Columns.Add("ID", 250, HorizontalAlignment.Left);
            ListCustomFields.Columns.Add("Value", 400, HorizontalAlignment.Left);

            var custom = Task.Run(() => _api.CustomFields).Result;

            foreach (var field in custom)
            {
                var item = new ListViewItem(field);
                var value = Task.Run(() => _api.Fields[field]).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                ListCustomFields.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateVirtualFields()
        {
            Cursor.Current = Cursors.WaitCursor;
            ListVirtualFields.Columns.Add("ID", 250, HorizontalAlignment.Left);
            ListVirtualFields.Columns.Add("Value", 400, HorizontalAlignment.Left);
            foreach (var field in _api.VirtualFields)
            {
                var item = new ListViewItem(field);
                var value = Task.Run(() => _api.Fields.GetVirtualFieldValue(field)).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                ListVirtualFields.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateUsers()
        {
            if (_api.Token != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    ListUsers.Columns.Add("ID");
                    ListUsers.Columns.Add("First");
                    ListUsers.Columns.Add("Last", 150);
                    ListUsers.Columns.Add("Phone");
                    ListUsers.Columns.Add("Email");
                    ListUsers.Columns.Add("Personas", 1050);
                    var users = Task.Run(() => _api.GetUsersAsync()).Result;
                    foreach (var user in users)
                    {
                        var item = new ListViewItem(user.Id);
                        item.SubItems.Add(user.FirstName);
                        item.SubItems.Add(user.LastName);
                        item.SubItems.Add(user.Phone);
                        item.SubItems.Add(user.Email);
                        var per = string.Empty;
                        if (user.Personas != null)
                        {
                            foreach (var persona in user.Personas)
                            {
                                per += persona.EntityName + ", ";
                            }
                        }
                        if (per.EndsWith(", "))
                        {
                            per = per.Substring(0, per.Length - 2);
                        }
                        item.SubItems.Add(per);

                        ListUsers.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    var xx = ex.Message;
                }
                Cursor.Current = Cursors.Default;
            }
        }
        protected void PopulateDocuments()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ListDocuments.Columns.Add("ID", 0);
                ListDocuments.Columns.Add("Title", 300);
                ListDocuments.Columns.Add("Created On", 200);
                ListDocuments.Columns.Add("Created By", 125);
                ListDocuments.Columns.Add("Attch Count");
                ListDocuments.Columns.Add("MileStoneId", 140);
                ListDocuments.Columns.Add("Days Due");
                ListDocuments.Columns.Add("Till Expire");

                List<DocumentContract> docs = Task.Run(() => _api.GetDocumentsAsync()).Result;

                foreach (DocumentContract doc in docs)
                {
                    var item = new ListViewItem(doc.Id);
                    item.SubItems.Add(doc.Title);
                    item.SubItems.Add(doc.CreatedDate ?? string.Empty);

                    if (doc.CreatedBy == null)
                        item.SubItems.Add(string.Empty);
                    else
                        item.SubItems.Add(doc.CreatedBy?.EntityName ?? string.Empty);

                    item.SubItems.Add(doc.Attachments.Count().ToString());
                    item.SubItems.Add(doc.Milestone.EntityId);
                    item.SubItems.Add(doc.DaysDue.ToString());
                    item.SubItems.Add(doc.DaysTillExpire.ToString());
                    ListDocuments.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateMilestones()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ListMilestones.Columns.Add("ID", 0);
                ListMilestones.Columns.Add("Name", 200);
                ListMilestones.Columns.Add("Start Date", 160);
                ListMilestones.Columns.Add("Actual Days", 65);
                ListMilestones.Columns.Add("Role Req", 65);
                ListMilestones.Columns.Add("Assoc. Type", 80);
                ListMilestones.Columns.Add("Assoc. Name", 150);
                ListMilestones.Columns.Add("Assoc. Role Name", 150);
                ListMilestones.Columns.Add("Assoc. Email", 500);

                var ms = Task.Run(() => _api.GetMilestonesAsync()).Result;

                foreach (var m in ms)
                {
                    var item = new ListViewItem(m.Id);
                    item.SubItems.Add(m.MilestoneName);
                    item.SubItems.Add(m.StartDate);
                    item.SubItems.Add(m.ActualDays?.ToString() ?? string.Empty);
                    item.SubItems.Add(m.RoleRequired?.ToString() ?? string.Empty);
                    item.SubItems.Add(m.LoanAssociate.LoanAssociateType);
                    item.SubItems.Add(m.LoanAssociate.Name);
                    item.SubItems.Add(m.LoanAssociate.RoleName);
                    item.SubItems.Add(m.LoanAssociate.Email);
                    ListMilestones.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateUWConditions()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ListUWConditions.Columns.Add("ID", 0);
                ListUWConditions.Columns.Add("Allow to Clear", 100);
                ListUWConditions.Columns.Add("Entity Name", 120);
                ListUWConditions.Columns.Add("Category");
                ListUWConditions.Columns.Add("Condition Type", 100);
                ListUWConditions.Columns.Add("Created Date", 150);
                ListUWConditions.Columns.Add("Created By", 200);
                ListUWConditions.Columns.Add("Description", 300);
                ListUWConditions.Columns.Add("Prior To");
                ListUWConditions.Columns.Add("Source", 100);
                ListUWConditions.Columns.Add("Title", 300);

                var uws = Task.Run(() => _api.GetUnderwritingConditionsAsync()).Result;

                foreach (var uw in uws)
                {
                    var item = new ListViewItem(uw.Id);
                    item.SubItems.Add(uw.AllowToClear?.ToString() ?? string.Empty);
                    item.SubItems.Add(uw.Application.EntityName);
                    item.SubItems.Add(uw.Category);
                    item.SubItems.Add(uw.ConditionType);
                    item.SubItems.Add(uw.CreatedDate?.ToString());
                    item.SubItems.Add(uw.CreatedBy.EntityName);
                    item.SubItems.Add(uw.Description);
                    item.SubItems.Add(uw.PriorTo);
                    item.SubItems.Add(uw.Source);
                    item.SubItems.Add(uw.Title);
                    ListUWConditions.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        public void PopulateRateLocks()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ListRateLocks.Columns.Add("ID", 0);
                ListRateLocks.Columns.Add("Type");
                ListRateLocks.Columns.Add("Request Status", 90);
                ListRateLocks.Columns.Add("Lock Status", 90);
                ListRateLocks.Columns.Add("# Days");
                ListRateLocks.Columns.Add("Exp. Date", 120);
                ListRateLocks.Columns.Add("Requested By", 100);
                //                ListRateLocks.Columns.Add("Rate Sheet", 300);

                List<RateLockSummaryContract> rls = Task.Run(() => _api.GetRateLockSummaryRequestsAsync()).Result;

                foreach (RateLockSummaryContract rl in rls)
                {
                    var item = new ListViewItem(rl.Id);
                    item.SubItems.Add(rl.RequestType);
                    item.SubItems.Add(rl.RequestStatus);
                    item.SubItems.Add(rl.LockStatus);
                    item.SubItems.Add(rl.LockNumberOfDays.ToString() ?? string.Empty);
                    item.SubItems.Add(rl.LockExpirationDate);
                    item.SubItems.Add(rl.RequestedBy.EntityName);
                    ListRateLocks.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        public void PopulateEnhancedConditions()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var results = Task.Run(() => _api.GetEnhancedConditionsAsync(_api.LoanGuid)).Result;
                if (_api.IsOkStatus)
                {
                    ListEnhancedConditions.Columns.Add("ID", 0);
                    ListEnhancedConditions.Columns.Add("Type", 110);
                    ListEnhancedConditions.Columns.Add("Title", 250);
                    ListEnhancedConditions.Columns.Add("Category", 90);
                    ListEnhancedConditions.Columns.Add("Publish Date", 90);
                    ListEnhancedConditions.Columns.Add("Prior To");
                    ListEnhancedConditions.Columns.Add("Recipient");
                    ListEnhancedConditions.Columns.Add("Start Date");
                    ListEnhancedConditions.Columns.Add("End Date");
                    ListEnhancedConditions.Columns.Add("Status", 90);

                    foreach (EnhancedConditionContract r in results)
                    {
                        var item = new ListViewItem(r.Id);
                        item.SubItems.Add(r.ConditionType);
                        item.SubItems.Add(r.Title);
                        item.SubItems.Add(r.Category);
                        item.SubItems.Add(r.PublishedDate);
                        item.SubItems.Add(r.PriorTo);
                        item.SubItems.Add(r.Recipient);
                        item.SubItems.Add(r.StartDate);
                        item.SubItems.Add(r.EndDate);
                        item.SubItems.Add(r.Status);
                        ListEnhancedConditions.Items.Add(item);
                    }
                }
                else
                    MessageBox.Show($"Check to see if Enahnced Conditions is set for environments");
            }
            catch
            {
                MessageBox.Show($"Error: {_api.LastMessage}");
            }
            Cursor.Current = Cursors.Default;
        }

        private bool SetLVItem(ListView lv, string text)
        {
            foreach (ListViewItem item in lv.Items)
            {
                if (item.Text.ToUpper() == text)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    item.Focused = true;
                    return true;
                }
            }
            return false;
        }

        private void LoanNumber_TextChanged(object sender, EventArgs e)
        {
            LoadLoan.Enabled = true;
        }

        private void ListFields_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                if (EllieInstance.SelectedItem.ToString() == "Production")
                {
                    MessageBox.Show("Updating Production value not allowed");
                }
                else
                {
                    var item = ((ListView)sender).SelectedItems[0];
                    var searchItem = item.Text;
                    var instanceLevel = "0";

                    if (item.Text.Contains("#"))
                    {
                        instanceLevel = searchItem.Split('#')[1];
                        searchItem = searchItem.Split('#')[0];
                    }

                    APISchema selectedSchema = _api.FieldSchema.Where(t => t.Key == searchItem).FirstOrDefault();

                    using (var win = new UpdateFieldWIN(_api, selectedSchema, instanceLevel))
                    {
                        win.ShowDialog();
                        if (win.ReloadLoan)
                        {
                            GetDetails();
                        }
                    }
                }
            }
        }
        private void ListCustomFields_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                if (EllieInstance.SelectedItem.ToString() == "Production")
                {
                    MessageBox.Show("Updating Production value not allowed");
                }
                else
                {
                    var item = ((ListView)sender).SelectedItems[0];
                    var searchItem = item.Text;
                    var instanceLevel = "0";

                    if (item.Text.Contains("#"))
                    {
                        instanceLevel = searchItem.Split('#')[1];
                        searchItem = searchItem.Split('#')[0];
                    }

                    var selectedSchema = _api.FieldSchema.Where(t => t.Key == searchItem).FirstOrDefault();

                    using (var win = new UpdateFieldWIN(_api, item.Text))
                    {
                        win.ShowDialog();
                        if (win.ReloadLoan)
                        {
                            GetDetails();
                        }
                    }
                }
            }

        }


        private void Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FieldSearch.Text))
            {
                CheckGrids();

                if (_lastFoundTab == -1)
                {
                    _loanDetails.SelectedTab = _loanDetails.TabPages[0];
                    _listFields.Focus();
                    // search fields
                    if (SetLVItem(_listFields, FieldSearch.Text.ToUpper()))
                    {
                        _lastFoundTab = 0;
                        return;
                    }

                    // search dynamic fields
                    _loanDetails.SelectedTab = _loanDetails.TabPages[1];
                    _listDynamicFields.Focus();
                    if (SetLVItem(_listDynamicFields, FieldSearch.Text.ToUpper()))
                    {
                        _lastFoundTab = 1;
                        return;
                    }
                    // search custom fields
                    _loanDetails.SelectedTab = _loanDetails.TabPages[2];
                    _listDynamicFields.Focus();
                    if (SetLVItem(ListCustomFields, FieldSearch.Text.ToUpper()))
                    {
                        _lastFoundTab = 2;
                        return;
                    }

                    // search virtual fields
                    _loanDetails.SelectedTab = _loanDetails.TabPages[3];
                    _listDynamicFields.Focus();
                    if (SetLVItem(ListVirtualFields, FieldSearch.Text.ToUpper()))
                    {
                        _lastFoundTab = 3;
                        return;
                    }

                }

                _lastFoundTab = -1;
                _loanDetails.SelectedTab = _loanDetails.TabPages[0];

            }
        }

        private void ListDocuments_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                var item = ((ListView)sender).SelectedItems[0];
                var docId = item.Text;
                var attachmentCount = item.SubItems[4].Text;

                if (Convert.ToInt32(attachmentCount) > 0)
                {
                    using (var win = new AttachmentsWIN(_api, docId))
                    {
                        win.ShowDialog();
                    }
                }
            }

        }

        private void BuildCanonicalFields()
        {
            var def = Task.Run(() => _api.GetPipelineCanonicalNamesAsync()).Result;
            foreach (var field in def.Fields)
                _canonicalFields.Add(field.Name);

            if (_canonicalFields.Count > 0)
                _canonicalFields.Sort();
        }

        public void BuildQueryPipelineCursor()
        {
            //LoanPipelineApi pipeline = null;

            _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();
            using (var loan = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
            {
                if (Task.Run(() => loan.GetToken()).Result)
                {
                    BuildCanonicalFields();
                    //                    pipeline = loan.GetPipelineCursor();
                }
            }

            //            return pipeline;
        }


        //* var loanCreatedAfter = PipelineHelper.GetAtomicFilterTerms("Fields.2025", createdAfter, OrdinalFieldMatchType.GreaterThanOrEquals, DateFieldMatchPrecision.Day);
        //* var matchStatus = PipelineHelper.GetAtomicFilterTerms("Fields.CX.STATUS", "001", StringFieldMatchType.Exact, true);
        //* var matchSubstatus = PipelineHelper.GetAtomicFilterTerms("Fields.CX.SUBSTATUS", "C", StringFieldMatchType.Exact, true);
        //* var matchPurpose = PipelineHelper.GetAtomicFilterTerms("Fields.19", LOAN_TYPE_PURCHASE, StringFieldMatchType.Exact, true);
        //* var creditCheckDateBefore = PipelineHelper.GetAtomicFilterTerms("Fields.Document.DateReceived.Credit Report", epoch, OrdinalFieldMatchType.LessThanOrEquals, DateFieldMatchPrecision.Day);
        //* var preQualLetterRecvd = PipelineHelper.GetAtomicFilterTerms("Fields.Document.DateReceived.Pre-Qual Letter", StringFieldMatchType.IsNotEmpty, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Day);
        //* var preQualOrderRecvd = PipelineHelper.GetAtomicFilterTerms("Fields.Document.DateReceived.Purchase Prequalification Order", StringFieldMatchType.IsNotEmpty, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Day);
        //* var matchPropertyAddress = PipelineHelper.GetAtomicFilterTerms("Fields.11", "TBD", StringFieldMatchType.Exact, true);
        //* var atLeast620FicoScore = PipelineHelper.GetAtomicFilterTerms("Loan.CreditScore", 620, OrdinalFieldMatchType.GreaterThanOrEquals);
        //* var status006 = PipelineHelper.GetAtomicFilterTerms("Fields.CX.STATUS", "006", null, true);  // Case insensative
        //* var excludeAlreadyShipped = PipelineHelper.GetAtomicFilterTerms($"Fields.2013", DateFieldCriterion.EmptyDate, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Exact);
        //* var shippingDateNotBlank = PipelineHelper.GetAtomicFilterTerms($"Fields.2014", DateFieldCriterion.NonEmptyDate, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Exact);
        //* var shippingDateIsInScope = PipelineHelper.GetAtomicFilterTerms($"Fields.2014", GetDateLowerBound(), OrdinalFieldMatchType.GreaterThanOrEquals, DateFieldMatchPrecision.Exact);
        //* var fundingDateNotNull = PipelineHelper.GetAtomicFilterTerms($"Fields.MS.FUN", DateFieldCriterion.NonEmptyDate, OrdinalFieldMatchType.Equals, DateFieldMatchPrecision.Exact);
        //* var fundingDateInScope = PipelineHelper.GetAtomicFilterTerms($"Fields.MS.FUN", GetDateLowerBound(), OrdinalFieldMatchType.GreaterThanOrEquals, DateFieldMatchPrecision.Exact);
        //* var fundingDateNotInFuture = PipelineHelper.GetAtomicFilterTerms($"Fields.MS.FUN", GetDateUpperBound(), OrdinalFieldMatchType.LessThan, DateFieldMatchPrecision.Exact);
        //* var matchStatus = PipelineHelper.GetAtomicFilterTerms("Fields.CX.STATUS", "001", StringFieldMatchType.Exact, true);
        //* var excludeHCM = PipelineHelper.GetAtomicFilterTerms($"Fields.CX.BRANCH.ID", "HCM", StringFieldMatchType.Exact, false);



        protected class WriteOut
        {
            public string Field { get; set; }
            public string Value { get; set; }
            public string StringMatch { get; set; }
            public string OrdinalMatch { get; set; }
            public string DateCriteria { get; set; }
            public string DateFieldMatch { get; set; }
            public bool Include { get; set; }
            public bool Numeric { get; set; }
        }
        protected class QueryFieldsOut
        {
            public WriteOut And { get; set; }
            public WriteOut Or { get; set; }
        }
        protected class QueryWriteOut
        {
            public List<QueryFieldsOut> fields { get; set; }
            public string AdditionalField { get; set; }
        }

        private void ViewPipeline_Click(object sender, EventArgs e)
        {
            if (EllieInstance.SelectedIndex >= 0)
            {
                _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();
                using (var eb = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                {
                    using (var win = new ViewPipelineWINcs(eb))
                    {
                        if (win.ShowDialog() == DialogResult.OK)
                        {
                            LoanNumber.Text = win.SelectedLoan;
                        }
                    }
                }
            }
        }
        private void ListRateLocks_DoubleClick(object sender, EventArgs e)
        {
            var item = ((ListView)sender).SelectedItems[0];
            var searchItem = item.Text;  // This is the ratelock ID

            using (var win = new RateLockDetailsWIN(_api, searchItem))
            {
                win.ShowDialog();
            }

        }
        private void LoanDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loanDetails.SelectedTab == _loanDetails.TabPages["_documents"])
            {
                if (ListDocuments.Columns.Count == 0 && _api != null)
                    PopulateDocuments();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_milestones"])
            {
                if (ListMilestones.Columns.Count == 0 && _api != null)
                    PopulateMilestones();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_UWConditions"])
            {
                if (ListUWConditions.Columns.Count == 0 && _api != null)
                    PopulateUWConditions();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_rateLocks"])
            {
                if (ListRateLocks.Columns.Count == 0 && _api != null)
                    PopulateRateLocks();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_users"])
            {
                if (ListUsers.Columns.Count == 0 && _api != null)
                    PopulateUsers();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_enhConditions"])
            {
                if (ListEnhancedConditions.Columns.Count == 0 && _api != null)
                    PopulateEnhancedConditions();
            }


            else
                CheckGrids();
        }
        private void CheckGrids()
        {
            if (_loanDetails.SelectedTab == _loanDetails.TabPages["_dynamicFields"])
            {
                if (_listDynamicFields.Columns.Count == 0 && _api != null)
                    PopulateDynamicFields();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_customFields"])
            {
                if (ListCustomFields.Columns.Count == 0 && _api != null)
                    PopulateCustomFields();
            }
            else if (_loanDetails.SelectedTab == _loanDetails.TabPages["_virtualFields"])
            {
                if (ListVirtualFields.Columns.Count == 0 && _api != null)
                    PopulateVirtualFields();
            }

        }
        private void LoanDetails_DrawItem(object sender, DrawItemEventArgs e)
        {

            TabPage page = _loanDetails.TabPages[e.Index];
            if (e.Index == 9 || e.Index == 10)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
            }
            else if (e.Index == 11)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
                page.ForeColor = Color.White;
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
            }

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }
        private void CanonicalNameReport_Click(object sender, EventArgs e)
        {
            using (var win = new ReportingFieldDifferencescsWIN())
            {
                win.ShowDialog();
            }

        }

        private void FieldUpdaterWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_api != null)
                _api.Dispose();
        }

        private void ListEnhancedConditions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(this.Location.X + ListEnhancedConditions.Location.X + e.X + 20,
                    this.Location.Y + ListEnhancedConditions.Location.Y + e.Y);
                enhancedConditionMenu.Show(point);
            }
        }

        private void EHDetails(object sender, EventArgs e)
        {
            MessageBox.Show("Here");
        }

        private void EHAdd(object sender, EventArgs e)
        {

        }

        private void EHEdit(object sender, EventArgs e)
        {

        }

        private void EHDelete(object sender, EventArgs e)
        {

        }

        private void UpdateStatus(string text)
        {
            RunninStatus.Visible = true;
            RunninStatus.Text = text;
            RunninStatus.Refresh();
        }
    }
}
