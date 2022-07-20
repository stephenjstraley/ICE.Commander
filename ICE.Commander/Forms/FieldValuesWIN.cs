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
using ICE.SDKtoAPI.Contracts;

namespace ICE.Commander
{
    public partial class FieldValuesWIN : Form
    {
        public static ElieConnections _con;
        protected LenderAPI _api;

        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        protected string _object = string.Empty;
        List<string> _canonicalFields = new List<string>();

        protected bool _withSDK = true;
        public FieldValuesWIN()
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();

            InitializeComponent();
            LoadInstances();
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
                            //ExportLoanJson.Enabled = true;
                        }
                    }
                }
            }
        }

        private void LoadLoan_Click(object sender, EventArgs e)
        {
            ExportData.Enabled = false;
            ListFieldAndValues.Clear();
            Cursor.Current = Cursors.WaitCursor;
            // Load Field Values
            ListFieldAndValues.Columns.Add("ID", 150);
            ListFieldAndValues.Columns.Add("V1", 375);
            ListFieldAndValues.Columns.Add("V3", 375);
            ListFieldAndValues.Columns.Add("SDK", 375);

            GetLoanForCompare();

            Cursor.Current = Cursors.Default;
        }

        private void fieldList_TextChanged(object sender, EventArgs e)
        {
            LoadLoan.Enabled = (!string.IsNullOrEmpty(fieldList.Text));
        }

        private void FieldValuesWIN_Load(object sender, EventArgs e)
        {
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));
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
                                StatusMsg("Get Loan Guid");

                                var guid = Task.Run(() => _apiV1.GetLoanGuidAsync(LoanNumber.Text)).Result;

                                if (_apiV1.HasLoanGuid)
                                {
                                    using (var _apiV3 = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                                    {
                                        StatusMsg("Get V3 Token");

                                        token = Task.Run(() => _apiV3.GetTokenAsync()).Result;

                                        if (_apiV3.Token != null)
                                        {
                                            // Take fields and make array
                                            List<string> theFields = new List<string>();
                                            if (fieldList.Text.Contains(","))
                                            {
                                                theFields = fieldList.Text.Split(',').ToList().TrimAll();
                                            }
                                            else
                                            {
                                                for (int i = 0; i < fieldList.Lines.Length; i++)
                                                {
                                                    if (!string.IsNullOrEmpty(fieldList.Lines[i]))
                                                        theFields.Add(fieldList.Lines[i]);
                                                }
                                            }

                                            List<FieldsFromEncompass> v1Values = Task.Run(() =>_apiV1.GetFieldValuesAsync(guid, theFields, false)).Result;

                                            List<FieldsFromEncompass> v3Values = Task.Run(() => _apiV3.GetFieldValuesAsync(guid, theFields, true)).Result;

                                            foreach (var f1 in v1Values)
                                            {
                                                // find item in v3
                                                var f3 = v3Values.Where(t => t.fieldId == f1.fieldId).FirstOrDefault();

                                                var sdkValue = sdkLoan.Fields[f1.fieldId].ToString();
                                                string v1Value = f1.value.ToString();
                                                string v3Value = string.Empty;
                                                if (f3 != null)
                                                    v3Value = f3.value.ToString();

                                                AddRow(ListFieldAndValues, f1.fieldId, sdkValue, v1Value, v3Value);
                                            }

                                            ExportData.Enabled = true;
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

        private void StatusMsg(string text)
        {
            statusUpdate.Text = text.PadRight(60, ' ');
            statusUpdate.Refresh();
        }

        private void AddRow(ListView con, string id, string sdk, string v1, string v3)
        {
            try
            {
                if (sdk.StartsWith("//"))
                    sdk = null;

                var item = new ListViewItem(id);

                item.SubItems.Add(v1);
                item.SubItems.Add(v3);
                item.SubItems.Add(sdk);
                con.Items.Add(item);
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + $" - {id}");
            }
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

                var output = $@"C:\Temp\SpecificFieldDiffs_{LoanNumber.Text}.xlsx";
                var info = new System.IO.FileInfo(output);
                package.SaveAs(info);
                MessageBox.Show($@"Results exported to {output}");
            }
        }
    }
}
