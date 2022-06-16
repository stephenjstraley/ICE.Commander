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
    public class ViewPersonasInRoleWIN : BaseDetailsWIN
    {
        protected string _roleName;
        public ViewPersonasInRoleWIN(LenderAPI api, string role) : base(api)
        {
            Text = $"View Personas in Role {role}";
            _roleName = role;
        }

        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("ID", 0);
            QueryFields.Columns.Add("Type", 200);
        }

        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            RoleExtended profile = Task.Run(() => _baseConnection.GetRoleByNameAsync(_roleName)).Result;

            var personas = profile.Personas;

            if (personas != null)
            {
                foreach (var p in personas)
                {
                    ListViewItem item = new ListViewItem(p.Id.ToString());
                    item.SubItems.Add(p.Name);
                    QueryFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show("No available personas");
        }

    }
}
