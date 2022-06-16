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
    public class ViewPersonaUsersWIN : BaseDetailsWIN
    {
        protected string _id;

        public ViewPersonaUsersWIN(LenderAPI api, string id) : base(api)
        {
            Text = $"View Users in Person";
            _id = id;
        }
        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("ID");
            QueryFields.Columns.Add("Full Name", 200);
            QueryFields.Columns.Add("Employee ID", 200);
            QueryFields.Columns.Add("Working Folder", 200);
            QueryFields.Columns.Add("Title", 200);
        }

        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            PersonaContract profile = Task.Run(() => _baseConnection.GetPersonaAsync(_id)).Result;

            if (profile != null)
            {
                var users = Task.Run(() => _baseConnection.GetUsersWithPersonaAsync(profile)).Result;

                if (users != null)
                {
                    foreach (var u in users)
                    {
                        ListViewItem item = new ListViewItem(u.Id);
                        item.SubItems.Add(u.FullName);
                        item.SubItems.Add(u.EmployeeID);
                        item.SubItems.Add(u.WorkingFolder);
                        item.SubItems.Add(u.Title);
                        QueryFields.Items.Add(item);
                    }
                }
                else
                    MessageBox.Show("No available users");
            }
            else
                MessageBox.Show("Cannot find persona");
        }

    }
}
