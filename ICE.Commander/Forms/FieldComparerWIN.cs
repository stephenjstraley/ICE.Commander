using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;
using EllieMae.Encompass.Collections;
using EllieMae.Encompass.Query;
using ICE.SDKtoAPI;
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
    /// TODO need to close the ellie mae loan object

    public partial class FieldComparerWIN : Form
    {
        public static ElieConnections _con;
        protected LenderAPI _api;

        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        protected string _object = string.Empty;
        List<string> _canonicalFields = new List<string>();

        public FieldComparerWIN()
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();

            InitializeComponent();
            LoadInstances();

            LoanNumber.Text = "0550466692";
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private void EllieInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var theSelection = EllieInstance.SelectedItem;
            try
            {
                if (theSelection != null)
                {
                    _con = _connetions.Where(t => t.Name == theSelection.ToString()).FirstOrDefault();

                    if (!string.IsNullOrEmpty(_con.sdkPath))
                    {
                        _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                        Task.Run(() => _api.GetTokenAsync()).Wait();

                        if (_api.Token == null)
                        {
                            MessageBox.Show("Unable to get access token for selected instance");
                            EllieInstance.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No SDK information available for environment selection");
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

        private void LoadLoanForCompare_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Load Field Values
            ListFieldAndValues.Columns.Add("ID", 150);
            ListFieldAndValues.Columns.Add("V1", 375);
            ListFieldAndValues.Columns.Add("V3", 375);
            ListFieldAndValues.Columns.Add("SDK", 375);

            GetLoanForCompare();

            Cursor.Current = Cursors.Default;
        }

        private void GetLoanForCompare()
        {
            StatusMsg("Starting...");

            try
            {
                if (EllieInstance.SelectedIndex >= 0)
                {
                    var _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();

                    if (!string.IsNullOrEmpty(LoanNumber.Text) && EllieInstance.SelectedIndex >= 0)
                    {
                        StatusMsg("SDK Session...");
                        //                        var temp = new   ManagedSession();
                        //                        temp.Start(_con.sdkPath, _con.sdkUser, _con.sdkPassword);
                        //                                                

                        Loan sdkLoan = null;

                        try
                        {
                            Session session = new Session();
                            session.Start(_con.sdkPath, _con.sdkUser, _con.sdkPassword);
                            var sdkGuid = GetGuidforLoan(session, LoanNumber.Text);
                            if (string.IsNullOrEmpty(sdkGuid))
                            {
                                MessageBox.Show("Unable to get GUID");
                            }
                            else
                            {
                                sdkLoan = session.Loans.Open(sdkGuid);
                                StatusMsg("Opening SDK Loan");
                            }
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                        }

                        StatusMsg("V1 Connection");

                        using (var _apiV1 = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                        {
                            StatusMsg("Get V1 Token");

                            var token = Task.Run(() => _apiV1.GetTokenAsync()).Result;

                            if (_apiV1.Token != null)
                            {
                                StatusMsg("Get V1 Loan Guid");

                                var guid = Task.Run(() => _apiV1.GetLoanGuidAsync(LoanNumber.Text)).Result;

                                if (_apiV1.HasLoanGuid)
                                {
                                    StatusMsg("Get V1 Loan... ");

                                    var gotIt = Task.Run(() => _apiV1.GetFullLoanAsync(true)).Result;
                                    if (gotIt)
                                    {
                                        StatusMsg("V3 Connection");

                                        using (var _apiV3 = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                                        {
                                            StatusMsg("Get V3 Token");

                                            token = Task.Run(() => _apiV3.GetTokenAsync()).Result;

                                            if (_apiV3.Token != null)
                                            {
                                                StatusMsg("Get V3 Loan... ");

                                                gotIt = Task.Run(() => _apiV3.GetFullLoanAsync(_apiV1.LoanGuid, true)).Result;

                                                if (gotIt)
                                                {
                                                    StatusMsg("Get Field IDS ");

                                                    var fieldIds = Task.Run(() => _apiV1.GetAllFieldIdsAsync()).Result; // _apiV1.GetAllFieldIdsAsync().Result;

                                                    StatusMsg("Processing... ");

                                                    foreach (var fieldId in fieldIds)
                                                    {
                                                        AddRow(ListFieldAndValues, fieldId, sdkLoan, _apiV1, _apiV3);
                                                    }

                                                    AddRow(ListFieldAndValues, "4000#1", sdkLoan, _apiV1, _apiV3);
                                                    AddRow(ListFieldAndValues, "4000#2", sdkLoan, _apiV1, _apiV3);

                                                    var customFields = Task.Run(() => _apiV1.GetCustomFieldsAsync()).Result; //_apiV1.GetCustomFieldsAsync().Result;
                                                    foreach (var fieldId in customFields)
                                                    {
                                                        AddRow(ListFieldAndValues, fieldId.Id, sdkLoan, _apiV1, _apiV3);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

            statusUpdate.Text = "";
        }

        private void AddRow(ListView con, string id, Loan sdk, LenderAPI v1, LenderAPI v3)
        {
            try
            {
                if (sdk == null)
                {
                    var v1Value = v1.Fields[id]?.ToString();
                    var v3Value = v3.Fields[id]?.ToString();
                    var item = new ListViewItem(id);

                    item.SubItems.Add(v1Value);
                    item.SubItems.Add(v3Value);
                    con.Items.Add(item);

                }
                else
                {
                    var sdkValue = sdk.Fields[id].ToString();
                    if (sdkValue.StartsWith("//"))
                        sdkValue = null;
                    var v1Value = v1.Fields[id]?.ToString();
                    var v3Value = v3.Fields[id]?.ToString();

                    var item = new ListViewItem(id);
                    item.SubItems.Add(v1Value);
                    item.SubItems.Add(v3Value);
                    item.SubItems.Add(sdkValue);
                    con.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + $" - {id}");
            }
        }

        private void StatusMsg(string text)
        {
            statusUpdate.Text = text.PadRight(60, ' ');
            statusUpdate.Refresh();

        }
        private void FieldComparerWIN_Load(object sender, EventArgs e)
        {
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));
        }
        static string GetGuidforLoan(Session session, string loanNumber)
        {
            StringList _fields = new StringList();
            _fields.Add("Loan.LoanNumber");
            string validloan = string.Empty;
            StringFieldCriterion c = new StringFieldCriterion("Loan.LoanNumber", loanNumber, StringFieldMatchType.Contains, true);
            QueryCriterion query = c;

            using (var lCursor = session.Reports.OpenReportCursor(_fields, query))
            {
                if (lCursor.Count > 0)
                {
                    validloan = lCursor.GetItem(0).Guid;
                }
            }

            return validloan;
        }

    }
}
