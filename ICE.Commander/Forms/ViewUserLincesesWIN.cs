using ICE.SDKtoAPI;
using ICE.SDKtoAPI.LenderApiContractsV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class ViewUserLincesesWIN : BaseDetailsWIN
    {
        protected string _userId;
        public ViewUserLincesesWIN(LenderAPI api, string userId) : base(api)
        {
            Text = $"View {userId} User Licenses";
            _userId = userId;
        }

        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("License");
            QueryFields.Columns.Add("State", 100);
            QueryFields.Columns.Add("Expiration", 100);
            QueryFields.Columns.Add("Enabled", 100);
        }
        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            List<UserLicenseContract> licenses = Task.Run(() => _baseConnection.GetUserLicensesAsync(_userId)).Result;

            if (licenses != null)
            {
                foreach (var l in licenses)
                {
                    ListViewItem item = new ListViewItem(l.License);
                    item.SubItems.Add(l.State ?? string.Empty);
                    item.SubItems.Add(l.ExpirationDate ?? string.Empty);
                    item.SubItems.Add(l.Enabled.ToString() ?? string.Empty);
                    QueryFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show("No available licenses");
        }
    }
}
