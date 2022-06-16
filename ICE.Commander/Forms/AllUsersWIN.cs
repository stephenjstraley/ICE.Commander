using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllUsersWIN : BaseTestFormWIN
    {
        public AllUsersWIN() : base()
        {
            ViewPipeline.Visible = false;
            LoanNumber.Visible = false;
            LoanNumberLabel.Visible = false;
            Text = "All Users";
        }
        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var users = Task.Run(() => _api.GetUsersAsync(10000)).Result;

            if (_api.IsOkStatus)
            {
                _listFields.Columns.Add("ID", 0);
                _listFields.Columns.Add("Full Name", 210);
                _listFields.Columns.Add("Title", 250);
                _listFields.Columns.Add("Email", 150);
                _listFields.Columns.Add("Employee ID", 90);
                _listFields.Columns.Add("Last Login", 130);
                _listFields.Columns.Add("Phone", 130);

                foreach (var u in users)
                {
                    var item = new ListViewItem(u.Id);
                    item.SubItems.Add(u.FullName);
                    item.SubItems.Add(u.Title);
                    item.SubItems.Add(u.Email);
                    item.SubItems.Add(u.EmployeeID);
                    item.SubItems.Add(u.LastLogin?.ToShortDateString());
                    item.SubItems.Add(u.Phone);
                    _listFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show(_api.LastMessage);

            Cursor.Current = Cursors.Default;
        }
    }
}
