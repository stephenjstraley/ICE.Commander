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
    public class ViewUserPersonasWIN : BaseDetailsWIN
    {
        protected string _userId;
        public ViewUserPersonasWIN(LenderAPI api, string userId) : base(api)
        {
            Text = $"View {userId} User Personas";
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
            UserProfileContract profile = Task.Run(() => _baseConnection.GetUserProfileAsync(_userId)).Result;

            var personas = profile.Personas;

            if (personas != null)
            {
                foreach (var p in personas)
                {
                    ListViewItem item = new ListViewItem(p.EntityId);
                    item.SubItems.Add(p.EntityType ?? string.Empty);
                    item.SubItems.Add(p.EntityName.ToString() ?? string.Empty);
                    QueryFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show("No available personas");
        }
    }
}
