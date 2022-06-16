using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllRolesWIN : BaseTestFormWIN
    {
        public AllRolesWIN() : base()
        {
            Text = "All Roles";
            ViewPipeline.Enabled = false;
            LoanNumber.Enabled = false;
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

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
            else
                MessageBox.Show(_api.LastMessage);

            Cursor.Current = Cursors.Default;
        }

        protected override void _listFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = _listFields.SelectedItems[0];

            using (var win = new ViewPersonasInRoleWIN(_api, item.SubItems[1].Text))
            {
                win.ShowDialog();
            }
        }

    }
}
