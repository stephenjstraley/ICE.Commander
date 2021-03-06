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
using ICE.SDKtoAPI.Helpers;
using ICE.SDKtoAPI.Contracts;

namespace ICE.Commander
{
    public partial class ValidateAPIFieldWIN : Form
    {
        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        public static ElieConnections _con;
        protected LenderAPI _api;
        protected List<string> _notFound = new List<string>();

        public ValidateAPIFieldWIN()
        {
            InitializeComponent();
            LoadInstances();
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private async void GO_Click(object sender, EventArgs e)
        {
            GO.Enabled = false;
            Output.Clear();

            _con = _connetions.Where(t => t.Name == MainWindow.defaultEnvironment).FirstOrDefault();

            _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);


            UpdateDisplay("Obtaining Token");

            await Task.Run(() => _api.GetTokenAsync());

            if (_api.Token != null)  // (loan.HasAccessToken)
            {
                UpdateDisplay("Obtaining Loan Guid");

                // get guids and take first one
                List<string> _fields = new List<string>();

                _fields.Add("GUID");
                _fields.Add("Loan.LoanNumber");
                _fields.Add("Loan.LoanPurpose");  // 299
                _fields.Add("Loan.BorrowerName");

                var filter = PipelineHelper.GetPipelineTerm("Loan.LoanFolder", "My Pipeline", "exact");
                var terms = PipelineHelper.GetFilterContract("and", filter);
                var contract = PipelineHelper.GetContract(terms, _fields.ToArray());

                List<GuidCursor> loans = Task.Run(() => _api.PipelineRequestAsync(contract)).Result;

                if (loans.Count > 0)
                {
                    var guid = loans[0].LoanGuid;

//                    var guid = Task.Run(() => _api.GetLoanGuidAsync(loan)).Result;

                    if (!string.IsNullOrEmpty(guid))
                    {
                        UpdateDisplay("Obtaining Loan");

                        var hasLoan = Task.Run(() => _api.LoadLoanAsync(guid)).Result;

                        if (hasLoan)
                        {
                            UpdateDisplay("Getting Fields");

                            var fieldIds = Task.Run(() => _api.GetAllFieldIdsAsync()).Result;
                            NumberOfFields.Text = _api.LastResponse.GetHeaderValue("X-Total-Count");
                            NumberOfFields.Refresh();

                            foreach (var id in fieldIds)
                            {
                                try
                                {
                                    var xx = _api.Fields[id];
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    _notFound.Add(id);
                                    UpdateDisplay($"[{id}] -> Not found in dictionary = [{ex.Message}]");
                                }
                                catch (FormatException ex)
                                {
                                    UpdateDisplay($"[{id}] -> {ex.Message}");
                                }
                            }
                        }
                        else
                            UpdateDisplay("Unable to load loan...");
                    }
                    else
                        UpdateDisplay("Unable to obtain loan guid");
                }
                else
                    UpdateDisplay("Unable to query for loan GUID");
            }

            Additions.Enabled = _notFound.Count > 0;

            MessageBox.Show("Operation Finished");
            GO.Enabled = true;
        }

        private void UpdateDisplay(string name)
        {
            Output.AppendText($@"Working on ... {name}");
            Output.AppendText(Environment.NewLine);
            Output.Refresh();
        }

        private void ValidateAPIFieldWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_api != null)
                _api.Dispose();
        }

        private void Additions_Click(object sender, EventArgs e)
        {
            using (var win = new AdditionalFieldDefsWIN(_api, _notFound))
            {
                win.ShowDialog();
            }
        }
    }
}
