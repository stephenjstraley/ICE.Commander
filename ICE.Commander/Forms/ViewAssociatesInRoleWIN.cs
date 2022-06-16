using ICE.SDKtoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class ViewAssociatesInRoleWIN : BaseDetailsWIN
    {
        protected string _roleName;
        protected string _guid;
        public ViewAssociatesInRoleWIN(LenderAPI api, string guid, string role) : base(api)
        {
            Text = $"View Associates in Role {role}";
            _roleName = role;
            _guid = guid;
        }
        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("ID", 0);
            QueryFields.Columns.Add("Name", 190);
            QueryFields.Columns.Add("Type", 250);
            QueryFields.Columns.Add("Role", 100);
            QueryFields.Columns.Add("Cell", 100);
            QueryFields.Columns.Add("Email", 70);
        }

        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            List<SDKtoAPI.LenderApiContractsV1.LoanContractLoanAssociate> assocs = Task.Run(() => _baseConnection.GetLoanAssociatesByRoleNameAsync(_guid, _roleName)).Result;

            if (assocs != null)
            {
                foreach (var a in assocs)
                {
                    ListViewItem item = new ListViewItem(a.Id);
                    item.SubItems.Add(a.Name);
                    item.SubItems.Add(a.LoanAssociateType);
                    item.SubItems.Add(a.RoleName);
                    item.SubItems.Add(a.CellPhone);
                    item.SubItems.Add(a.Email);
                    QueryFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show("No available personas");
        }
    }
}
