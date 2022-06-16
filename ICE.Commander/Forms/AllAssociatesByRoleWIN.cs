using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllAssociatesByRoleWIN : BaseTestFormWIN
    {
        protected string _guid;
        public AllAssociatesByRoleWIN() : base()
        {
            Text = "All Associates by Roles";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))  // "0550469290"
            {
                _guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(_guid))
                {
                    var roles = Task.Run(() => _api.GetRolesAsync()).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Role Name", 210);
                        _listFields.Columns.Add("Abbreviation", 150);
                        _listFields.Columns.Add("Protected", 150);
                        _listFields.Columns.Add("Person Count", 90);

                        foreach (var r in roles)
                        {
                            var item = new ListViewItem(r.RoleId.ToString());
                            item.SubItems.Add(r.RoleName);
                            item.SubItems.Add(r.RoleAbbr);
                            item.SubItems.Add(r.Protected.ToString());
                            item.SubItems.Add(r.Personas?.Count().ToString() ?? "0");
                            _listFields.Items.Add(item);
                        }
                    }
                }
            }
        }

        protected override void _listFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = _listFields.SelectedItems[0];

            using (var win = new ViewAssociatesInRoleWIN(_api, _guid, item.SubItems[1].Text))
            {
                win.ShowDialog();
            }
        }
    }
}
