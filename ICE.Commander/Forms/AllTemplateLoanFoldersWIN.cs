using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllTemplateLoanFoldersWIN : BaseTestFormWIN
    {
        public AllTemplateLoanFoldersWIN() : base()
        {
            Text = "All Template Loan Folders";
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!string.IsNullOrEmpty(LoanNumber.Text))
            {
                var guid = Task.Run(() => _api.GetLoanGuidAsync(LoanNumber.Text)).Result;

                if (!string.IsNullOrEmpty(guid))
                {
                    var temps = Task.Run(() => _api.GetLoanTemplateFoldersAsync(guid)).Result;

                    if (_api.IsOkStatus)
                    {
                        _listFields.Columns.Add("ID", 0);
                        _listFields.Columns.Add("Name", 210);
                        _listFields.Columns.Add("Type", 150);

                        foreach (var t in temps)
                        {
                            var item = new ListViewItem(t.EntityId);
                            item.SubItems.Add(t.EntityName);
                            item.SubItems.Add(t.EntityType);
                            _listFields.Items.Add(item);
                        }

                        if (temps.Count() == 0)
                            MessageBox.Show("No Loan Template Folders found");

                    }
                    else
                        MessageBox.Show(_api.LastMessage);

                }
                else
                    MessageBox.Show("Unable to obtain loan guid");

            }
            else
                MessageBox.Show("You need to select a loan number");

            Cursor.Current = Cursors.Default;

        }
    }
}
