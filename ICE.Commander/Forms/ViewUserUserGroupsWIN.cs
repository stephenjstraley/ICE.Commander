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
    public class ViewUserUserGroupsWIN : BaseDetailsWIN
    {
        protected string _userId;
        public ViewUserUserGroupsWIN(LenderAPI api, string userId) : base(api)
        {
            Text = $"View {userId} User Groups";
            _userId = userId;
        }

        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("ID");
            QueryFields.Columns.Add("Type", 200);
            QueryFields.Columns.Add("Name", 300);
        }

        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            List<UserGroupsContract> userGroups = Task.Run(() => _baseConnection.GetUserGroupsAsync(_userId)).Result;

            foreach (var ug in userGroups)
            {
                ListViewItem item = new ListViewItem(ug.EntityId);
                item.SubItems.Add(ug.EntityType.ToString() ?? string.Empty);
                item.SubItems.Add(ug.EntityName.ToString() ?? string.Empty);
                QueryFields.Items.Add(item);
            }
            

        }

    }
}
