using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using ICE.SDKtoAPI.Helpers;
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
    public partial class ViewPipelineWINcs : BaseDetailsWIN
    {
        public ViewPipelineWINcs(LenderAPI api) : base (api)
        {
            Text = "View My Pipeline ";
        }

        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("GUID");
            QueryFields.Columns.Add("Loan Number");
            QueryFields.Columns.Add("Purpose");
            QueryFields.Columns.Add("Borrower");
            QueryFields.Columns.Add("Status");
            QueryFields.Columns.Add("Sub Status");
            QueryFields.Columns.Add("Address");
            QueryFields.Columns.Add("City");
            QueryFields.Columns.Add("State");
            //QueryFields.Columns.Add("Product");
            //QueryFields.Columns.Add("Next Milestone");
            //QueryFields.Columns.Add("Last Modfied");
            //QueryFields.Columns.Add("Lock Requested Date");

        }

        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            var token = Task.Run(() => _baseConnection.GetTokenAsync()).Result;

            if (token != null)
            {
                List<string> _fields = new List<string>();

                _fields.Add("GUID");
                _fields.Add("Loan.LoanNumber");
                _fields.Add("Loan.LoanPurpose");  // 299
                _fields.Add("Loan.BorrowerName");
                _fields.Add("Fields.CX.STATUS");
                _fields.Add("Fields.CX.SUBSTATUS");
                _fields.Add("Fields.11");
                _fields.Add("Fields.12");
                _fields.Add("Fields.14");
                //_fields.Add("Fields.CUST02FV");
                //_fields.Add("Loan.CurrentMilestoneName");
                //_fields.Add("Fields.LoanLastModified");
                //_fields.Add("Loan.LockRequestedDate");

                //var cur = _baseConnection.GetPipelineCursor();
                var filter = PipelineHelper.GetPipelineTerm("Loan.LoanFolder", "My Pipeline", "exact");
                var terms = PipelineHelper.GetFilterContract("and", filter);
                var contract = PipelineHelper.GetContract(terms, _fields.ToArray());

                List<GuidCursor> loans = Task.Run(() => _baseConnection.PipelineRequestAsync(contract)).Result;

                if ((loans?.Count ?? 0) > 0)
                {
                    Text += $"({loans.Count})";
                    foreach (var loan in loans)
                    {

                        ListViewItem item = new ListViewItem(loan.LoanGuid);
                        Dictionary<string, string> fields = loan.Fields;
                        foreach (var f in fields)
                        {
                            item.SubItems.Add(f.Value.ToString() ?? "");
                        }
                        QueryFields.Items.Add(item);
                    }

                    QueryFields.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    QueryFields.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                }
                else
                {
                    MessageBox.Show("No records found in 'My Pipeline' folder");
                }
            }

        }

        protected override void QueryFields_DoubleClick(object sender, EventArgs e)
        {
            SelectedLoan = QueryFields.SelectedItems[0].SubItems[1].Text;
            Close();
            DialogResult = DialogResult.OK;

        }
    }
}
