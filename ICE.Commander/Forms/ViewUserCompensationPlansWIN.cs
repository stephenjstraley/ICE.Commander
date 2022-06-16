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
    public class ViewUserCompensationPlansWIN : BaseDetailsWIN
    {
        protected string _userId;
        public ViewUserCompensationPlansWIN(LenderAPI api, string userId) : base(api)
        {
            Text = $"View {userId} User Compensation Plans";
            _userId = userId;
        }
        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("Parent", 200);
            QueryFields.Columns.Add("Plan Name", 200);
            QueryFields.Columns.Add("Start Date", 300);
        }
        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            List<UserCompensationPlanContract> plans = Task.Run(() => _baseConnection.GetUserCompensationPlansAsync(_userId)).Result;

            if (plans != null)
            {
                foreach (var p in plans)
                {
                    foreach (var thePlan in p.Plans)
                    {
                        ListViewItem item = new ListViewItem(p.UserParentInformation);
                        item.SubItems.Add(thePlan.Plan.EntityName ?? string.Empty);
                        item.SubItems.Add(thePlan.StartDate?.ToString() ?? string.Empty);
                        QueryFields.Items.Add(item);
                    }
                }
            }
            else
                MessageBox.Show("No plans set");
        }

    }
}
