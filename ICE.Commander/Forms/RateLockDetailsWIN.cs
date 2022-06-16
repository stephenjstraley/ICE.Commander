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
    public partial class RateLockDetailsWIN : Form
    {
        protected string _rateLockId;
        protected LenderAPI _loadedLoan;
        public RateLockDetailsWIN(LenderAPI loan, string id)
        {
            _rateLockId = id;
            _loadedLoan = loan;
            InitializeComponent();
        }

        private void RateLockDetailsWIN_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var req = _loadedLoan.GetRateLockRequestAsync(_rateLockId).Result;

            try
            {
                //                LoadDetails(req);
                //                LoadSnapshot(req.SnapShotFields);
            }
            catch
            {

            }

            Cursor.Current = Cursors.Default;
        }

        //protected void LoadDetails(STAR.Encompass.SDKtoAPI.Contracts.RateLockDetail req)
        //{
        //    ListDetails.Columns.Add("Item", 250);
        //    ListDetails.Columns.Add("Value", 200);

        //    var item = new ListViewItem("Time Requested");
        //    item.SubItems.Add(req.TimeRequested);
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Requested By");
        //    item.SubItems.Add(req.RequestedBy);
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Requested Name");
        //    item.SubItems.Add(req.RequestedName);
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Requested Status");
        //    item.SubItems.Add(req.RequestedStatus);
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Buy Side Expiration Date");
        //    item.SubItems.Add(req.BuySideExpirationDate?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Hide Log Indicator");
        //    item.SubItems.Add(req.HideLogIndicator?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Is Fake REquest Indicator");
        //    item.SubItems.Add(req.IsFakeRequestIndicator?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Is Lock Cancellation Indicator");
        //    item.SubItems.Add(req.IsLockCancellationIndicator?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Is ReLock Indicator");
        //    item.SubItems.Add(req.IsReLockIndicator?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Number of Days Locked");
        //    item.SubItems.Add(req.NumberOfDaysLocked?.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Buy Side Number of Days Extended");
        //    item.SubItems.Add(req.BuySideNumberOfDaysExtended.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Buy Side Number of Days Locked");
        //    item.SubItems.Add(req.BuySideNumberOfDaysLocked.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Sell Side Number of Days Extended");
        //    item.SubItems.Add(req.SellSideNumberOfDaysExtended.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //    item = new ListViewItem("Sell Side Number of Days Locked");
        //    item.SubItems.Add(req.SellSideNumberOfDaysLocked.ToString() ?? "");
        //    ListDetails.Items.Add(item);

        //}

        //protected void LoadSnapshot(List<STAR.Encompass.SDKtoAPI.Contracts.SnapShotField> fs)
        //{
        //    ListSnapShot.Columns.Add("Field", 100);
        //    ListSnapShot.Columns.Add("Value", 200);
        //    ListSnapShot.Columns.Add("Mapping", 500);

        //    foreach (var f in fs)
        //    {
        //        var i = new ListViewItem(f.FieldId);
        //        i.SubItems.Add(f.Value);
        //        i.SubItems.Add(f.ModalPath);
        //        ListSnapShot.Items.Add(i);
        //    }

        //}
    }
}
