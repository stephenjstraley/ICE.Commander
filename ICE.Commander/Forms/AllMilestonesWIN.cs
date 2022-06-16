using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllMilestonesWIN : BaseTestFormWIN
    {
        public AllMilestonesWIN() : base()
        {
            Text = "All Milestones";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))  // "0550469290"
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var ms = Task.Run(() => _api.GetMilestonesAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Title", 190);
                        _listFields.Columns.Add("Comments", 250);
                        _listFields.Columns.Add("Expected Days", 100);
                        _listFields.Columns.Add("Actual Days", 100);
                        _listFields.Columns.Add("Done", 70);
                        _listFields.Columns.Add("Start Date", 160);

                        foreach (var m in ms)
                        {
                            var item = new ListViewItem(m.Id);
                            item.SubItems.Add(m.MilestoneName);
                            item.SubItems.Add(m.Comments);
                            item.SubItems.Add(m?.ExpectedDays.ToString());
                            item.SubItems.Add(m?.ActualDays.ToString());
                            item.SubItems.Add(m?.DoneIndicator.ToString());
                            item.SubItems.Add(m.StartDate);
                            _listFields.Items.Add(item);
                        }

                        if (ms.Count() == 0)
                            MessageBox.Show("No milestones found");
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
