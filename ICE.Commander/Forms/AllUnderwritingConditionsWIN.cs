using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllUnderwritingConditionsWIN : BaseTestFormWIN
    {
        public AllUnderwritingConditionsWIN() : base()
        {
            Text = "All Unrderwriting Conditions";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))  // "0550469290"
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var conds = Task.Run(() => _api.GetUnderwritingConditionsAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Title", 210);
                        _listFields.Columns.Add("Status", 150);
                        _listFields.Columns.Add("Source", 150);
                        _listFields.Columns.Add("Description", 190);
                        _listFields.Columns.Add("Created Date", 130);
                        _listFields.Columns.Add("Type", 130);

                        foreach (var c in conds)
                        {
                            var item = new ListViewItem(c.Id);
                            item.SubItems.Add(c.Title);
                            item.SubItems.Add(c.Status);
                            item.SubItems.Add(c.Source);
                            item.SubItems.Add(c.Description);
                            item.SubItems.Add(c.CreatedDate?.ToShortDateString());
                            item.SubItems.Add(c.ConditionType);
                            _listFields.Items.Add(item);
                        }

                        if (conds.Count() == 0)
                            MessageBox.Show("No conditions found");
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
