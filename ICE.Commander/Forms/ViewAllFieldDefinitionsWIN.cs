using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ICE.Commander
{
    public partial class ViewAllFieldDefinitionsWIN : Form
    {
        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        public static ElieConnections _con;
        protected LenderAPI _api;
        protected List<string> _notFound = new List<string>();

        public ViewAllFieldDefinitionsWIN()
        {
            InitializeComponent();
            LoadInstances();
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private async void GO_Click(object sender, EventArgs e)
        {
            GO.Enabled = false;
            UpdateDisplay("");

            _con = _connetions.Where(t => t.Name == MainWindow.defaultEnvironment).FirstOrDefault();

            _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

            int getFieldCount = 50;
            string source = "Standard";

            UpdateDisplay("Obtaining Token");

            await Task.Run(() => _api.GetTokenAsync());

            if (_api.Token != null)  // (loan.HasAccessToken)
            {
                UpdateDisplay("Obtaining Loan Guid");

                UpdateDisplay("Getting Fields");
                var count = 1;

                var fieldIds = Task.Run(() => _api.GetAllFieldIdsAsync()).Result;
                NumberOfFields.Text = _api.LastResponse.GetHeaderValue("X-Total-Count");
                NumberOfFields.Refresh();

                QueryFields.Columns.Add("Id", 100);
                QueryFields.Columns.Add("Description", 400);
                QueryFields.Columns.Add("Type", 70);
                QueryFields.Columns.Add("Format", 120);
                QueryFields.Columns.Add("Nullable", 70);
                QueryFields.Columns.Add("ReadOnly", 70);
                QueryFields.Columns.Add("Source", 70);

                List<string> theIds = new List<string>();
                foreach (var id in fieldIds)
                {
                    UpdateDisplay((count++).ToString());

                    theIds.Add(id);
                    if (theIds.Count() == getFieldCount)
                    {
                        List<SDKtoAPI.LenderApiContractsV3.FieldSchemaContract> v3 = Task.Run(() => _api.GetV3FieldSchemaAsync(theIds)).Result;

                        foreach (var f in v3)
                        {
                            ListViewItem field = new ListViewItem(f.Id);
                            field.SubItems.Add(f.Description);
                            field.SubItems.Add(f.DataType);
                            field.SubItems.Add(f.Format);
                            field.SubItems.Add(f.Nullable.ToString());
                            field.SubItems.Add(f.ReadOnly.ToString());
                            field.SubItems.Add(source);
                            QueryFields.Items.Add(field);
                        }
                        theIds.Clear();
                    }
                }

                // if there are remaining ones
                if (theIds.Count() > 0)
                {
                    List<SDKtoAPI.LenderApiContractsV3.FieldSchemaContract> v3 = Task.Run(() => _api.GetV3FieldSchemaAsync(theIds)).Result;

                    foreach (var f in v3)
                    {
                        ListViewItem field = new ListViewItem(f.Id);
                        field.SubItems.Add(f.Description);
                        field.SubItems.Add(f.DataType);
                        field.SubItems.Add(f.Format);
                        field.SubItems.Add(f.Nullable.ToString());
                        field.SubItems.Add(f.ReadOnly.ToString());
                        field.SubItems.Add(source);
                        QueryFields.Items.Add(field);
                    }
                    theIds.Clear();
                }

                QueryFields.Refresh();

                if (QueryFields.Items.Count > 0)
                    ExportData.Enabled = true;

                // now work on custom fields
                UpdateDisplay("Getting Custom Fields");
                source = "Custom";
                List<CustomFieldMeta> cfs = Task.Run(() => _api.GetCustomFieldsAsync(true)).Result;
                foreach (var c in cfs)
                {
                    ListViewItem field = new ListViewItem(c.Id);
                    field.SubItems.Add(c.Description);
                    field.SubItems.Add("");
                    field.SubItems.Add(c.Format);
                    field.SubItems.Add("");
                    field.SubItems.Add("");
                    field.SubItems.Add(source);
                    QueryFields.Items.Add(field);
                }

                UpdateDisplay("Getting Virtual Fields");
                source = "Virtual";
                List<VirtualFieldMeta> vrs = Task.Run(() => _api.GetVirtualFieldsAsync()).Result;
                foreach (var v in vrs)
                {
                    ListViewItem field = new ListViewItem(v.Id);
                    field.SubItems.Add(v.Description);
                    field.SubItems.Add("");
                    field.SubItems.Add(v.Format);
                    field.SubItems.Add("");
                    field.SubItems.Add("");
                    field.SubItems.Add(source);
                    QueryFields.Items.Add(field);
                }

                UpdateDisplay("Done");

                QueryFields.Refresh();

                // now work on virtual fields
            }

            Additions.Enabled = _notFound.Count > 0;

            MessageBox.Show("Operation Finished");
            GO.Enabled = true;
            ExportData.Enabled = true;
        }

        private void UpdateDisplay(string name)
        {
            Status.Text = $@"Working on ... {name}";
            Status.Refresh();
        }

        private void ValidateAPIFieldWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_api != null)
                _api.Dispose();
        }

        private void Additions_Click(object sender, EventArgs e)
        {
            using (var win = new AdditionalFieldDefsWIN(_api, _notFound))
            {
                win.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Fields");

                ws.TabColor = Color.Blue;

                ListView.ColumnHeaderCollection cols = QueryFields.Columns;
                for (int i = 0; i < cols.Count; i++)
                {
                    var hdr = cols[i];
                    ws.Cells[1, i + 1].Value = hdr.Text;
                    ws.Cells[1, i + 1].Style.Numberformat.Format = "@";
                    ws.Cells[1, i + 1].AutoFitColumns();
                }

                int row = 2;
                int col = 1;
                foreach (ListViewItem lvi in QueryFields.Items)
                {
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        ws.Cells[row, col].Value = lvs.Text;
                        ws.Cells[row, col].Style.Numberformat.Format = "@";
                        ws.Cells[row, col].AutoFitColumns();

                        col += 1;
                    }
                    col = 1;
                    row += 1;
                }

                if (!System.IO.Directory.Exists(@"C:\Temp"))
                    System.IO.Directory.CreateDirectory(@"C:\Temp");

                var info = new System.IO.FileInfo(@"C:\Temp\FieldDefinitions.xls");
                package.SaveAs(info);
                MessageBox.Show(@"Results exported to C:\Temp\FieldDefinitions.xls");
            }

        }
    }
}
