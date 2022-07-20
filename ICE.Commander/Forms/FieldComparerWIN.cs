using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.Client;
using EllieMae.Encompass.Collections;
using em = EllieMae.Encompass.Licensing;
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
using OfficeOpenXml;

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

        protected bool _withSDK = true;

        public FieldComparerWIN()
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();

            InitializeComponent();
            LoadInstances();

            //LoanNumber.Text = "0550466692";
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
                        else // Load loan folders
                        {
                            var folders = Task.Run(() => _api.GetLoanFoldersAsync()).Result;
                            if (folders != null)
                            {
                                folders.ForEach(t => encompassFolders.Items.Add(t.FolderName));
                            }
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
                    using (var win = new ViewPipelineWINcs(eb, string.IsNullOrEmpty(encompassFolders.Text) ? "Prospects" : encompassFolders.Text))
                    {
                        if (win.ShowDialog() == DialogResult.OK)
                        {
                            LoanNumber.Text = win.SelectedLoan;
                            ExportLoanJson.Enabled = true;
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

                        Loan sdkLoan = null;
                        var sdkGuid = string.Empty;

                        Session session = null;

                        try
                        {
                            if (_con.noSDK)
                            {
                                session = RemoteSession.Connect(_con);
                            }
                            else
                            {
                                session = new Session();
                                session.Start(_con.sdkPath, _con.sdkUser, _con.sdkPassword);
                            }

                            if (session != null)
                            {
                                sdkGuid = GetGuidforLoan(session, LoanNumber.Text);
                            }

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
                            _withSDK = false;
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

                                    var gotIt = Task.Run(() => _apiV1.SetV1Loan().LoadLoanAsync(true)).Result;
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

                                                gotIt = Task.Run(() => _apiV3.SetV3Loan().LoadLoanAsync(_apiV1.LoanGuid, true)).Result;

                                                if (gotIt)
                                                {
                                                    StatusMsg("Get Field IDS ");

                                                    var fieldIds = Task.Run(() => _apiV1.GetAllFieldIdsAsync()).Result; // _apiV1.GetAllFieldIdsAsync().Result;

                                                    StatusMsg("Processing... ");

                                                    foreach (var fieldId in fieldIds)
                                                    {
                                                        StatusMsg($"Processing... {fieldId}");

                                                        AddRow(ListFieldAndValues, fieldId, sdkLoan, _apiV1, _apiV3);
                                                    }

                                                    //AddRow(ListFieldAndValues, "4000#1", sdkLoan, _apiV1, _apiV3);
                                                    //AddRow(ListFieldAndValues, "4000#2", sdkLoan, _apiV1, _apiV3);

                                                    var customFields = Task.Run(() => _apiV1.GetCustomFieldsAsync()).Result; //_apiV1.GetCustomFieldsAsync().Result;
                                                    foreach (var fieldId in customFields)
                                                    {
                                                        AddRow(ListFieldAndValues, fieldId.Id, sdkLoan, _apiV1, _apiV3);
                                                    }

                                                    ExportData.Enabled = true;
                                                }
                                                else
                                                    MessageBox.Show("Unable to get field IDS");
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show("Unable to get V1 Loan");
                                }
                                else
                                    MessageBox.Show("Unable to get V1 Guid");
                            }
                            else
                                MessageBox.Show("Unable to get V1 Token");
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

                    if (excludeEmptyData.Checked)
                    {
                        if (string.IsNullOrEmpty(v1Value) && string.IsNullOrEmpty(v3Value)) { }
                        else
                        {
                            if (InOneNotOther.Checked)
                            {
                                if (string.IsNullOrEmpty(v1Value) && !string.IsNullOrEmpty(v3Value) ||
                                    !string.IsNullOrEmpty(v1Value) && string.IsNullOrEmpty(v3Value))
                                {
                                    item.SubItems.Add(v1Value);
                                    item.SubItems.Add(v3Value);
                                    con.Items.Add(item);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(v1Value) || string.IsNullOrEmpty(v3Value))
                                {
                                    item.BackColor = Color.LightGray;
                                }
                                else if (v1Value != v3Value)
                                {
                                    item.BackColor = Color.LightYellow;
                                }

                                item.SubItems.Add(v1Value);
                                item.SubItems.Add(v3Value);
                                con.Items.Add(item);
                            }
                        }
                    }
                    else 
                    {
                        item.SubItems.Add(v1Value);
                        item.SubItems.Add(v3Value);
                        con.Items.Add(item);
                    }
                }
                else
                {
                    var sdkValue = sdk.Fields[id].ToString();
                    if (sdkValue.StartsWith("//"))
                        sdkValue = null;
                    var v1Value = v1.Fields[id]?.ToString();
                    var v3Value = v3.Fields[id]?.ToString();

                    var item = new ListViewItem(id);

                    if (ignorIfBlankSDK.Checked)
                    {
                        if (string.IsNullOrEmpty(sdkValue) || string.IsNullOrWhiteSpace(sdkValue))
                        { }
                        else
                        {
                            if (InOneNotOther.Checked)
                            {
                                if (CheckThreeEmpty(v1Value, v3Value, sdkValue))
                                {
                                    item.BackColor = Color.LightGray;

                                    item.SubItems.Add(v1Value);
                                    item.SubItems.Add(v3Value);
                                    item.SubItems.Add(sdkValue);
                                    con.Items.Add(item);
                                }
                            }
                            else
                            {
                                item.SubItems.Add(v1Value);
                                item.SubItems.Add(v3Value);
                                item.SubItems.Add(sdkValue);
                                con.Items.Add(item);
                            }
                        }
                    }
                    else if (excludeEmptyData.Checked)
                    {
                        if (string.IsNullOrEmpty(v1Value) && string.IsNullOrEmpty(v3Value) && string.IsNullOrEmpty(sdkValue)) { }
                        else
                        {
                            if (InOneNotOther.Checked)
                            {
                                if (CheckThreeEmpty(v1Value, v3Value, sdkValue))
                                {
                                    item.BackColor = Color.LightGray;

                                    item.SubItems.Add(v1Value);
                                    item.SubItems.Add(v3Value);
                                    item.SubItems.Add(sdkValue);
                                    con.Items.Add(item);
                                }
                            }
                            else
                            {
                                item.SubItems.Add(v1Value);
                                item.SubItems.Add(v3Value);
                                item.SubItems.Add(sdkValue);
                                con.Items.Add(item);
                            }
                        }
                    }
                    else
                    {
                        item.SubItems.Add(v1Value);
                        item.SubItems.Add(v3Value);
                        item.SubItems.Add(sdkValue);
                        con.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + $" - {id}");
            }
        }

        private bool CheckThreeEmpty(string s1, string s2, string s3)
        {
            List<string> list = new List<string>() { s1, s2, s3 };
            return !list.All(s => !string.IsNullOrEmpty(s));
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

        private void ExportData_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Fields");

                ws.TabColor = Color.Blue;

                ListView.ColumnHeaderCollection cols = ListFieldAndValues.Columns;
                for (int i = 0; i < cols.Count; i++)
                {
                    var hdr = cols[i];
                    ws.Cells[1, i + 1].Value = hdr.Text;
                    ws.Cells[1, i + 1].Style.Numberformat.Format = "@";
                    ws.Cells[1, i + 1].AutoFitColumns();
                }

                int row = 2;
                int col = 1;
                foreach (ListViewItem lvi in ListFieldAndValues.Items)
                {
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[row, col].Value = lvs.Text;
                        ws.Cells[row, col].Style.Numberformat.Format = "@";
                        ws.Cells[row, col].AutoFitColumns();

                        col += 1;
                    }
                    col = 1;
                    row += 1;
                }

                if (!System.IO.Directory.Exists(@"C:\Temp"))
                    System.IO.Directory.CreateDirectory(@"C:\Temp");

                var output = $@"C:\Temp\FieldDiffs_{LoanNumber.Text}.xlsx";
                var info = new System.IO.FileInfo(output);
                package.SaveAs(info);
                MessageBox.Show($@"Results exported to {output}");
            }

        }

        private void ExportLoanJson_Click(object sender, EventArgs e)
        {
            var _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();

            
            if (!string.IsNullOrEmpty(LoanNumber.Text) && EllieInstance.SelectedIndex >= 0)
            {
                StatusMsg("Getting connections...");

                using (var _apiV1 = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                {
                    StatusMsg("Getting V1 Token...");

                    var token = Task.Run(() => _apiV1.GetTokenAsync()).Result;

                    if (_apiV1.Token != null)
                    {
                        StatusMsg("Getting V1 Loan...");

                        var guid = Task.Run(() => _apiV1.GetLoanGuidAsync(LoanNumber.Text)).Result;

                        if (_apiV1.HasLoanGuid)
                        {
                            var v1Loan = Newtonsoft.Json.JsonConvert.SerializeObject(Task.Run(() => _apiV1.SetV1Loan().GetLoanAsync(guid)).Result);

                            using (var _apiV3 = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                            {
                                StatusMsg("Getting V3 Token...");

                                token = Task.Run(() => _apiV3.GetTokenAsync()).Result;

                                if (_apiV3.Token != null)
                                {
                                    StatusMsg("Getting V3 Loan...");

                                    var v3Loan = Newtonsoft.Json.JsonConvert.SerializeObject(Task.Run(() => _apiV3.SetV3Loan().GetLoanAsync(guid)).Result);

                                    StatusMsg("Saving...");

                                    System.IO.File.WriteAllText($@"C:\Temp\V1_{LoanNumber.Text}.json", v1Loan);
                                    System.IO.File.WriteAllText($@"C:\Temp\V3_{LoanNumber.Text}.json", v3Loan);

                                    MessageBox.Show("Files Saved!");
                                    
                                }
                                else
                                    MessageBox.Show("Unable to get V3 token");
                            }
                        }
                        else
                            MessageBox.Show("Unable to getl loan guid V1");
                    }
                    else
                        MessageBox.Show("Unable to get V1 token");
                }
            }
            else
                MessageBox.Show("No Connection selected");

            StatusMsg("STATUS...");
        }
    }
}
