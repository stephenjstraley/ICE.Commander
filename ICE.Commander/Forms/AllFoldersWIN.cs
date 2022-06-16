using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public class AllFoldersWIN : BaseTestFormWIN
    {
        public AllFoldersWIN() : base()
        {
            Text = "All Folders";
            ViewPipeline.Enabled = false;
            LoanNumber.Enabled = false;
        }

        protected override void GoGetThem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var folders = Task.Run(() => _api.GetLoanFoldersAsync()).Result;

            if (_api.IsOkStatus)
            {
                _listFields.Columns.Add("ID", 150);
                _listFields.Columns.Add("Name", 210);
                _listFields.Columns.Add("Arch", 70);
                _listFields.Columns.Add("Dups From", 70);
                _listFields.Columns.Add("Dup From", 70);
                _listFields.Columns.Add("Imp Into", 70);
                _listFields.Columns.Add("Org Into", 70);

                foreach (var f in folders)
                {
                    var item = new ListViewItem(f.FolderName);
                    item.SubItems.Add(f.FolderType);
                    item.SubItems.Add(f.IsArchiveFolder.ToString());
                    item.SubItems.Add(f.CanLoansBeDumplicatedFrom.ToString());
                    item.SubItems.Add(f.CanLoansBeDuplicatedFrom.ToString());
                    item.SubItems.Add(f.CanLoansBeImportedInto.ToString());
                    item.SubItems.Add(f.CanLoansByOriginatedInto.ToString());
                    _listFields.Items.Add(item);
                }

                if (folders.Count() == 0)
                    MessageBox.Show("No Folders found");

            }
            else
                MessageBox.Show(_api.LastMessage);


            Cursor.Current = Cursors.Default;

        }

    }
}
