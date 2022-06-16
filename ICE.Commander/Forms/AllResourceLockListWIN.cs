using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllResourceLockListWIN : BaseTestFormWIN
    {
        public AllResourceLockListWIN() : base()
        {
            Text = "All Resource Locks";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var rls = Task.Run(() => _api.GetResourceLockListAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Type", 110);
                        _listFields.Columns.Add("Resource", 150);
                        _listFields.Columns.Add("Lock Time", 150);

                        foreach (var r in rls)
                        {
                            var item = new ListViewItem(r.Id);
                            item.SubItems.Add(r.LockType);
                            item.SubItems.Add(r.Resource.EntityType);
                            item.SubItems.Add(r.LockTime);
                            _listFields.Items.Add(item);
                        }

                        if (rls.Count() == 0)
                            MessageBox.Show("Resource Locks found");

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
