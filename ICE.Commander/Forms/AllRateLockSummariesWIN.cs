using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllRateLockSummariesWIN : BaseTestFormWIN
    {
        public AllRateLockSummariesWIN() : base()
        {
            Text = "All Rate Lock Summaries";
        }
        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var sums = Task.Run(() => _api.GetRateLockSummaryRequestsAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Status", 110);
                        _listFields.Columns.Add("Req. By", 150);
                        _listFields.Columns.Add("Req Status", 150);
                        _listFields.Columns.Add("Req Type", 190);
                        _listFields.Columns.Add("Req Date", 130);
                        _listFields.Columns.Add("Lock # Days", 130);
                        _listFields.Columns.Add("Lock Exp Date", 130);

                        foreach (var s in sums)
                        {
                            var item = new ListViewItem(s.Id);
                            item.SubItems.Add(s.LockStatus);
                            item.SubItems.Add(s.RequestedBy.EntityName);
                            item.SubItems.Add(s.RequestStatus);
                            item.SubItems.Add(s.RequestType);
                            item.SubItems.Add(s.RequestedDate);
                            item.SubItems.Add(s.LockNumberOfDays.ToString());
                            item.SubItems.Add(s.LockExpirationDate);
                            _listFields.Items.Add(item);
                        }

                        if (sums.Count() == 0)
                            MessageBox.Show("No summaries found");

                    }
                    else
                        MessageBox.Show(_api.LastMessage);

                }
                else
                    MessageBox.Show("Unable to obtain loan guid");

            }
            else
                MessageBox.Show("You need to select a loan number");

            Cursor.Current = Cursors.Default;

        }
    }
}
