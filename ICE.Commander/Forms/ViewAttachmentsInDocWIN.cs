using ICE.SDKtoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class ViewAttachmentsInDocWIN : BaseDetailsWIN
    {
        protected string _docId;
        protected string _guid;
        public ViewAttachmentsInDocWIN(LenderAPI api, string guid, string docId) : base(api)
        {
            Text = $"View Associates in Document";
            _docId = docId;
            _guid = guid;
        }
        protected override void BaseDetailsWIN_Load(object sender, EventArgs e)
        {
            QueryFields.Columns.Add("ID", 0);
            QueryFields.Columns.Add("Title", 190);
            QueryFields.Columns.Add("Type", 250);
            QueryFields.Columns.Add("Size", 100);
            QueryFields.Columns.Add("Is Action", 70);
            QueryFields.Columns.Add("Created by", 120);
            QueryFields.Columns.Add("Assign To", 120);
        }
        protected override void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {
            //_baseConnection.SaveResponseContect = true;

            List<SDKtoAPI.LenderApiContractsV3.FileAttachmentContract> attachs = Task.Run(() => _baseConnection.GetAttachmentsForDocIdAsync(_docId)).Result;

            if (attachs != null)
            {
                foreach (var a in attachs)
                {
                    ListViewItem item = new ListViewItem(a.Id);
                    item.SubItems.Add(a.Title);
                    item.SubItems.Add(a.Type);
                    item.SubItems.Add(a.FileSize.ToString());
                    item.SubItems.Add(a.IsActive.ToString());
                    item.SubItems.Add(a.CreatedBy.EntityName);
                    item.SubItems.Add(a?.AssignedTo?.EntityName ?? string.Empty);
                    QueryFields.Items.Add(item);
                }
            }
            else
                MessageBox.Show("No available attachments");
        }
    }
}
