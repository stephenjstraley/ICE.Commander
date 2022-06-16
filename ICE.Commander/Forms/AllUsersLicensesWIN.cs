using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllUsersLicensesWIN : AllUsersWIN
    {
        public AllUsersLicensesWIN() : base()
        {
            Text = "All User Licenses";
        }

        protected override void _listFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = _listFields.SelectedItems[0];

            var id = item.SubItems[0].Text;

            using (var win = new ViewUserLincesesWIN(_api, id))
            {
                win.ShowDialog();
            }

        }

    }
}
