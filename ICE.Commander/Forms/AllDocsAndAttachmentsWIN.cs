using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllDocsAndAttachmentsWIN : BaseTestFormWIN
    {
        protected string _guid;
        public AllDocsAndAttachmentsWIN() : base()
        {
            Text = "All Docs and Attachments";
        }
        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            LoanNumber.Text = "0550469290";

            if (!string.IsNullOrEmpty(LoanNumber.Text))  // "0550469290"
            {
                _guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(_guid))
                {
                    _api.SaveResponseContect = true;

                    var docs = Task.Run(() => _api.GetDocumentsAsync()).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Title", 210);
                        _listFields.Columns.Add("Desc", 150);
                        _listFields.Columns.Add("Days Due", 50);
                        _listFields.Columns.Add("Created By", 190);
                        _listFields.Columns.Add("Attch Count", 90);
                        _listFields.Columns.Add("Condit Count", 90);
                        _listFields.Columns.Add("Group Count", 90);
                        _listFields.Columns.Add("Type Count", 90);


                        foreach (var d in docs)
                        {
                            var item = new ListViewItem(d.Id);
                            item.SubItems.Add(d.Title);
                            item.SubItems.Add(d.Description);
                            item.SubItems.Add(d.DaysDue?.ToString() ?? "0");
                            item.SubItems.Add(d.CreatedBy.EntityName);
                            item.SubItems.Add(d.Attachments?.Count().ToString() ?? "0");
                            item.SubItems.Add(d.Conditions?.Count().ToString() ?? "0");
                            item.SubItems.Add(d.DocumentGroups?.Count().ToString() ?? "0");
                            item.SubItems.Add(d.DocumentTypes?.Count().ToString() ?? "0");
                            _listFields.Items.Add(item);
                        }
                    }
                    else
                    {
                        var tt = _api.LastResponse.ResponseContext;
                        MessageBox.Show(_api.LastMessage);

                    }
                }
            }
        }

        protected override void _listFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = _listFields.SelectedItems[0];

            using (var win = new ViewAttachmentsInDocWIN(_api, _guid, item.SubItems[1].Text))
            {
                win.ShowDialog();
            }
        }
    }
}
