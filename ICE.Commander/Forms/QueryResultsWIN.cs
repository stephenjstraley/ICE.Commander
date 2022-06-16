using ICE.SDKtoAPI.Contracts;
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
    public partial class QueryResultsWIN : Form
    {
        protected List<GuidCursor> _loans;
        protected List<string> _fields;
        protected ElieConnections _con;
        public QueryResultsWIN(ElieConnections con, List<GuidCursor> loans, List<string> fields)
        {
            InitializeComponent();
            _loans = loans;
            _fields = fields;
            _con = con;
        }

        private void QueryResultsWIN_Load(object sender, EventArgs e)
        {
            Text += $" - Results of {_loans.Count} records";
            _queryFields.Columns.Add("GUID", 250);

            foreach (var field in _fields)
                _queryFields.Columns.Add(field);


            foreach (var loan in _loans)
            {
                ListViewItem item = new ListViewItem(loan.LoanGuid);

                foreach (string theField in _fields)
                    item.SubItems.Add(loan.Fields[theField]);

                _queryFields.Items.Add(item);
            }
        }

        private void Exports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
            //    using (var package = new ExcelPackage())
            //    {
            //        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Results");

            //        ws.TabColor = Color.Blue;

            //        #region Create Columns
            //        ListView.ColumnHeaderCollection cols = QueryFields.Columns;
            //        for (int i = 0; i < cols.Count; i++)
            //        {
            //            var hdr = cols[i];
            //            ws.Cells[1, i + 1].Value = hdr.Text;
            //            ws.Cells[1, i + 1].Style.Numberformat.Format = "@";
            //            ws.Cells[1, i + 1].AutoFitColumns();
            //        }
            //        #endregion

            //        int row = 2;
            //        int col = 1;
            //        foreach (ListViewItem lvi in QueryFields.Items)
            //        {
            //            foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
            //            {
            //                ws.Cells[row, col].Value = lvs.Text;
            //                ws.Cells[row, col].Style.Numberformat.Format = "@";
            //                ws.Cells[row, col].AutoFitColumns();

            //                col += 1;
            //            }
            //            col = 1;
            //            row += 1;
            //        }

            //        if (!System.IO.Directory.Exists(@"C:\Temp"))
            //            System.IO.Directory.CreateDirectory(@"C:\Temp");

            //        var info = new System.IO.FileInfo(@"C:\Temp\QueryResults.xls");
            //        package.SaveAs(info);
            //        MessageBox.Show(@"Results exported to C:\Temp\QueryResults.xls");
            //    }
        }

        private void QueryFields_DoubleClick(object sender, EventArgs e)
        {
            using (var win = new QueryResultSelectionWIN(_con, _queryFields.SelectedItems[0].Text))
            {
                win.ShowDialog();
            }
        }
    }
}
