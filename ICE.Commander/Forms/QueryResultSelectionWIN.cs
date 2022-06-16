using ICE.SDKtoAPI;
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
    public partial class QueryResultSelectionWIN : Form
    {
        protected ElieConnections _con;
        protected string _guid;
        public static List<string> _pairIds = new List<string>();
        protected LenderAPI _loan;
        protected string _serializedLoan = string.Empty;
        public QueryResultSelectionWIN(ElieConnections con, string guid)
        {
            InitializeComponent();
            _guid = guid;
            _con = con;
        }

        private void QueryResultSelectionWIN_Load(object sender, EventArgs e)
        {
        }
        private void _loadLoan_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (LoadLoan().Result)
            {
                LoadPairs();
                this.Text += Task.Run(() => _loan.IsLoanLocked).Result ? " LOCKED" : " Not Locked";
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
            }

        }

        private async Task<bool> LoadLoan()
        {
            bool defReturn = false;

            using (var loan = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
            {
                var temp = Task.Run(() => loan.GetTokenAsync()).Result;

                if (loan.HasAccessToken)
                {
                    //loan._guid = _guid;

                    defReturn = Task.Run(() => loan.GetFullLoanAsync(_guid)).Result;

                    if (defReturn)
                        _loan = loan;
                    else
                        MessageBox.Show("Unable to load selected loan");
                }
                else
                    MessageBox.Show("Unable to get access token");
            }

            return defReturn;
        }
        private void _loanDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_documentsTab"])
            {
                if (_listDocuments.Columns.Count == 0 && _loan != null)
                    PopulateDocuments();
            }
            else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_milestonesTab"])
            {
                if (_listMilestones.Columns.Count == 0 && _loan != null)
                    PopulateMilestones();
            }
            else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_uwConditionsTab"])
            {
                if (_listUWConditions.Columns.Count == 0 && _loan != null)
                    PopulateUWConditions();
            }
            //else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["RateLocks"])
            //{
            //    if (_listRateLocks.Columns.Count == 0 && _loan != null)
            //        PopulateRateLocks();
            //}
            else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_dynamicFieldsTab"])
            {
                if (_listDynamicFields.Columns.Count == 0 && _loan != null)
                    PopulateDynamicFields();
            }
            else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_customFieldsTab"])
            {
                if (_listCustomFields.Columns.Count == 0 && _loan != null)
                    PopulateCustomFields();
            }
            else if (_loanDetailsTabControl.SelectedTab == _loanDetailsTabControl.TabPages["_virtualFieldsTab"])
            {
                if (_listVirtualFields.Columns.Count == 0 && _loan != null)
                    PopulateVirtualFields();
            }
            else
            {
                //                var ttt = _loanDetailsTabControl.SelectedTab;
                //                var twwe = _loanDetailsTabControl.TabPages["_dynamicFieldsTab"];
                //                var asd = ttt == twwe;
            }
        }

        protected void LoadPairs()
        {
            _pairIds.Add("35");
            _pairIds.Add("36");
            _pairIds.Add("37");
            _pairIds.Add("38");
            _pairIds.Add("39");
            _pairIds.Add("52");
            _pairIds.Add("53");
            _pairIds.Add("54");
            _pairIds.Add("60");
            _pairIds.Add("65");
            _pairIds.Add("66");
            _pairIds.Add("67");
            _pairIds.Add("68");
            _pairIds.Add("69");
            _pairIds.Add("70");
            _pairIds.Add("97");
            _pairIds.Add("98");
            _pairIds.Add("120");
            _pairIds.Add("144");
            _pairIds.Add("145");
            _pairIds.Add("146");
            _pairIds.Add("147");
            _pairIds.Add("148");
            _pairIds.Add("149");
            _pairIds.Add("150");
            _pairIds.Add("151");
            _pairIds.Add("152");
            _pairIds.Add("169");
            _pairIds.Add("170");
            _pairIds.Add("175");
            _pairIds.Add("188");
            _pairIds.Add("189");
            _pairIds.Add("265");
            _pairIds.Add("266");
            _pairIds.Add("300");
            _pairIds.Add("307");
            _pairIds.Add("403");
            _pairIds.Add("466");
            _pairIds.Add("467");
            _pairIds.Add("471");
            _pairIds.Add("732");
            _pairIds.Add("737");
            _pairIds.Add("740");
            _pairIds.Add("742");
            _pairIds.Add("910");
            _pairIds.Add("911");
            _pairIds.Add("915");
            _pairIds.Add("965");
            _pairIds.Add("985");
            _pairIds.Add("1108");
            _pairIds.Add("1240");
            _pairIds.Add("1268");
            _pairIds.Add("1389");
            _pairIds.Add("1403");
            _pairIds.Add("1402");
            _pairIds.Add("1414");
            _pairIds.Add("1415");
            _pairIds.Add("1416");
            _pairIds.Add("1417");
            _pairIds.Add("1418");
            _pairIds.Add("1419");
            _pairIds.Add("1450");
            _pairIds.Add("1452");
            _pairIds.Add("1480");
            _pairIds.Add("1490");
            _pairIds.Add("1519");
            _pairIds.Add("1520");
            _pairIds.Add("1521");
            _pairIds.Add("1522");
            _pairIds.Add("1524");
            _pairIds.Add("1525");
            _pairIds.Add("1526");
            _pairIds.Add("1527");
            _pairIds.Add("1528");
            _pairIds.Add("1530");
            _pairIds.Add("1532");
            _pairIds.Add("1535");
            _pairIds.Add("1536");
            _pairIds.Add("1742");
            _pairIds.Add("1811");
            _pairIds.Add("1868");
            _pairIds.Add("3249");
            _pairIds.Add("3251");
            _pairIds.Add("4000");
            _pairIds.Add("4001");
            _pairIds.Add("4002");
            _pairIds.Add("4003");
            _pairIds.Add("4004");
            _pairIds.Add("4005");
            _pairIds.Add("4006");
            _pairIds.Add("4007");
            _pairIds.Add("4008");
            _pairIds.Add("4009");
            _pairIds.Add("4016");
            _pairIds.Add("4017");
            _pairIds.Add("4019");
            _pairIds.Add("4131");
            _pairIds.Add("4143");
            _pairIds.Add("4144");
            _pairIds.Add("4147");
            _pairIds.Add("4177");
            _pairIds.Add("4178");
            _pairIds.Add("4179");
            _pairIds.Add("4252");
            _pairIds.Add("AUSF.X2");
            _pairIds.Add("AUSF.X3");
            _pairIds.Add("AUSF.X4");
            _pairIds.Add("AUSF.X5");
            _pairIds.Add("AUSF.X6");
            _pairIds.Add("AUSF.X7");
            _pairIds.Add("AUSF.X8");
            _pairIds.Add("AUSF.X9");
            _pairIds.Add("AUSF.X11");
            _pairIds.Add("AUSF.X12");
            _pairIds.Add("AUSF.X13");
            _pairIds.Add("AUSF.X14");
            _pairIds.Add("AUSF.X15");
            _pairIds.Add("AUSF.X16");
            _pairIds.Add("AUSF.X17");
            _pairIds.Add("AUSF.X18");
            _pairIds.Add("FE0112");
            _pairIds.Add("FE0113");
            _pairIds.Add("FE0115");
            _pairIds.Add("FE0117");
            _pairIds.Add("FE0213");
            _pairIds.Add("FE0215");
            _pairIds.Add("FE0217");
            _pairIds.Add("FE0233");
            _pairIds.Add("FR0124");
            _pairIds.Add("FR0212");
            _pairIds.Add("FR0224");
        }
        protected void PopulateJson()
        {
            // Text Box
            _serializedLoan = _loan.Serialize();
            var t = JsonConvert.DeserializeObject(_serializedLoan);
            _jsonText.Text = JsonConvert.SerializeObject(t, Formatting.Indented);
        }
        protected void PopulateFields()
        {
            Cursor.Current = Cursors.WaitCursor;

            _listLoanFields.Columns.Add("ID");
            _listLoanFields.Columns.Add("Value", 500);
            _listLoanFields.Columns.Add("Type");
            _listLoanFields.Columns.Add("Enum");
            _listLoanFields.Columns.Add("Meta", 300);
            _listLoanFields.Columns.Add("R/O");
            _listLoanFields.Columns.Add("Desc", 400);

            var theFields = Task.Run(() => _loan.FieldSchema).Result;

            foreach (var field in theFields)
            {
                var item = new ListViewItem(field.Key);
                var value = _loan.Fields[field.Key];
                if (value != null)
                    item.SubItems.Add(value.ToString());
                else
                    item.SubItems.Add("");

                item.SubItems.Add(field.Type);
                item.SubItems.Add(!string.IsNullOrEmpty(field.ENum) ? "Yes" : "");
                item.SubItems.Add(field.Meta);
                item.SubItems.Add(field.ReadOnly.ToString());
                item.SubItems.Add(field.Description);

                _listLoanFields.Items.Add(item);

                // Now check to see if there are pairs
                if (_pairIds.Contains(field.Key))
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        var k = $"{field.Key}#{i}";
                        item = new ListViewItem(k);
                        item.BackColor = Color.LightBlue;
                        value = _loan.Fields[k];
                        if (value != null)
                            item.SubItems.Add(value.ToString());
                        else
                            item.SubItems.Add("");

                        item.SubItems.Add(field.Type);
                        item.SubItems.Add(!string.IsNullOrEmpty(field.ENum) ? "Yes" : "");
                        item.SubItems.Add(field.Meta);
                        item.SubItems.Add(field.ReadOnly.ToString());
                        item.SubItems.Add(field.Description);

                        _listLoanFields.Items.Add(item);
                    }
                }
            }

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

            var schema = Task.Run(() => _loan.DynamicSchema).Result;

            foreach (var field in schema)
            {
                var groups = field.Key.Split(')');
                var newKey = groups[0].Replace("^(", "");
                newKey += "00";
                newKey += groups[2].Replace("(", "").Replace("$", "");

                //Console.WriteLine(newKey);

                var item = new ListViewItem(newKey);
                var value = Task.Run(() => _loan.Fields[newKey]).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                else
                    item.SubItems.Add("");

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
            _listCustomFields.Columns.Add("ID", 250, HorizontalAlignment.Left);
            _listCustomFields.Columns.Add("Value", 400, HorizontalAlignment.Left);

            var custom = Task.Run(() => _loan.CustomFields).Result;

            foreach (var field in custom)
            {
                var item = new ListViewItem(field);
                var value = Task.Run(() => _loan.Fields[field]).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                _listCustomFields.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateVirtualFields()
        {
            Cursor.Current = Cursors.WaitCursor;
            _listVirtualFields.Columns.Add("ID", 250, HorizontalAlignment.Left);
            _listVirtualFields.Columns.Add("Value", 400, HorizontalAlignment.Left);
            foreach (var field in _loan.VirtualFields)
            {
                var item = new ListViewItem(field);
                var value = Task.Run(() => _loan.Fields.GetVirtualFieldValue(field)).Result;
                if (value != null)
                    item.SubItems.Add(value.ToString());
                _listVirtualFields.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateDocuments()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _listDocuments.Columns.Add("ID", 0);
                _listDocuments.Columns.Add("Title", 300);
                _listDocuments.Columns.Add("Created On", 200);
                _listDocuments.Columns.Add("Created By", 125);
                _listDocuments.Columns.Add("Attch Count");
                _listDocuments.Columns.Add("MileStoneId", 140);
                _listDocuments.Columns.Add("Days Due");
                _listDocuments.Columns.Add("Till Expire");

                List<DocumentContract> docs = Task.Run(() => _loan.GetDocumentsAsync()).Result;

                foreach (DocumentContract doc in docs)
                {
                    var item = new ListViewItem(doc.Id);
                    item.SubItems.Add(doc.Title);
                    item.SubItems.Add(doc.CreatedDate ?? "");

                    if (doc.CreatedBy == null)
                        item.SubItems.Add(string.Empty);
                    else
                        item.SubItems.Add(doc.CreatedBy?.EntityName ?? "");

                    item.SubItems.Add(doc.Attachments.Count().ToString());
                    item.SubItems.Add(doc.Milestone.EntityId);
                    item.SubItems.Add(doc.DaysDue.ToString());
                    item.SubItems.Add(doc.DaysTillExpire.ToString());
                    _listDocuments.Items.Add(item);
                }
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateMilestones()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _listMilestones.Columns.Add("ID", 0);
                _listMilestones.Columns.Add("Name", 200);
                _listMilestones.Columns.Add("Start Date", 160);
                _listMilestones.Columns.Add("Actual Days", 65);
                _listMilestones.Columns.Add("Role Req", 65);
                _listMilestones.Columns.Add("Assoc. Type", 80);
                _listMilestones.Columns.Add("Assoc. Name", 150);
                _listMilestones.Columns.Add("Assoc. Role Name", 150);
                _listMilestones.Columns.Add("Assoc. Email", 500);

                var ms = Task.Run(() => _loan.GetMilestonesAsync()).Result;

                foreach (var m in ms)
                {
                    var item = new ListViewItem(m.Id);
                    item.SubItems.Add(m.MilestoneName);
                    item.SubItems.Add(m.StartDate);
                    item.SubItems.Add(m.ActualDays?.ToString() ?? "");
                    item.SubItems.Add(m.RoleRequired?.ToString() ?? "");
                    item.SubItems.Add(m.LoanAssociate.LoanAssociateType);
                    item.SubItems.Add(m.LoanAssociate.Name);
                    item.SubItems.Add(m.LoanAssociate.RoleName);
                    item.SubItems.Add(m.LoanAssociate.Email);
                    _listMilestones.Items.Add(item);
                }
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        protected void PopulateUWConditions()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _listUWConditions.Columns.Add("ID", 0);
                _listUWConditions.Columns.Add("Allow to Clear", 100);
                _listUWConditions.Columns.Add("Entity Name", 120);
                _listUWConditions.Columns.Add("Category");
                _listUWConditions.Columns.Add("Condition Type", 100);
                _listUWConditions.Columns.Add("Created Date", 150);
                _listUWConditions.Columns.Add("Created By", 200);
                _listUWConditions.Columns.Add("Description", 300);
                _listUWConditions.Columns.Add("Prior To");
                _listUWConditions.Columns.Add("Source", 100);
                _listUWConditions.Columns.Add("Title", 300);

                var uws = Task.Run(() => _loan.GetUnderwritingConditionsAsync()).Result;

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
                    _listUWConditions.Items.Add(item);
                }

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        public void PopulateRateLocks()
        {
            MessageBox.Show("Feature Temporairly Unavailable");
        }


    }
}
