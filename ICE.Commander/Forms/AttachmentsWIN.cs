using ICE.SDKtoAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class AttachmentsWIN : Form
    {
        protected LenderAPI _loan;
        protected string _docId;
        public AttachmentsWIN(LenderAPI loan, string docId)
        {
            InitializeComponent();
            _loan = loan;
            _docId = docId;
        }

        private void AttachmentWin_Load(object sender, EventArgs e)
        {
            var attachments = _loan.GetAttachmentsAsync(_docId).Result;
            if (attachments != null || attachments.Count > 0)
            {
                ListAttachments.Columns.Add("ID", 0);
                ListAttachments.Columns.Add("Title", 500);
                ListAttachments.Columns.Add("Type", 100);

                foreach (var att in attachments)
                {
                    var item = new ListViewItem(att.Id);
                    item.SubItems.Add(att.Title);
                    item.SubItems.Add(att.Type);
                    ListAttachments.Items.Add(item);
                }

            }
        }

        private void ListAttachments_DoubleClick(object sender, EventArgs e)
        {
            var item = ((ListView)sender).SelectedItems[0];
            var fileName = item.SubItems[0].Text;
            var info = new System.IO.FileInfo(fileName);
            var ext = info.Extension.ToUpper();

            //            _loan.PullDocument(fileName);

            switch (ext)
            {
                case ".PDF":
                    break;
                case ".DOC":
                    break;
                case ".TXT":
                    break;
            }

        }
    }
}
