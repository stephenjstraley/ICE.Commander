using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllAssociatesWIN : BaseTestFormWIN
    {
        public AllAssociatesWIN() : base()
        {
            Text = "All Associates";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))  // "0550469290"
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var assocs = Task.Run(() => _api.GetLoanAssociatesAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Name", 190);
                        _listFields.Columns.Add("Type", 250);
                        _listFields.Columns.Add("Role", 100);
                        _listFields.Columns.Add("Cell", 100);
                        _listFields.Columns.Add("Email", 70);

                        foreach (var a in assocs)
                        {
                            var item = new ListViewItem(a.Id);
                            item.SubItems.Add(a.Name);
                            item.SubItems.Add(a.LoanAssociateType);
                            item.SubItems.Add(a.RoleName);
                            item.SubItems.Add(a.CellPhone);
                            item.SubItems.Add(a.Email);
                            _listFields.Items.Add(item);
                        }

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
