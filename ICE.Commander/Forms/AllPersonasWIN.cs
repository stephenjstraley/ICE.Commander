using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllPersonasWIN : BaseTestFormWIN
    {
        public AllPersonasWIN() : base()
        {
            Text = "All Personas";
            ViewPipeline.Enabled = false;
            LoanNumber.Enabled = false;
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var personas = Task.Run(() => _api.GetPersonasAsync()).Result;

            if (_api.IsOkStatus)
            {
                _listFields.Columns.Add("ID", 0);
                _listFields.Columns.Add("Name", 150);
                _listFields.Columns.Add("Is External", 70);
                _listFields.Columns.Add("Is Internal", 70);
                _listFields.Columns.Add("Default Access", 290);

                foreach (var p in personas)
                {
                    var item = new ListViewItem(p.Id.ToString());
                    item.SubItems.Add(p.Name);
                    item.SubItems.Add(p.IsExternal.ToString());
                    item.SubItems.Add(p.IsInternal.ToString());
                    item.SubItems.Add(p.DefaultAccess);
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

            using (var win = new ViewPersonaUsersWIN(_api, item.SubItems[1].Text))
            {
                win.ShowDialog();
            }
        }


    }
}
