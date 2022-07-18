using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using System.Reflection;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Web;

namespace ICE.Commander
{
    public partial class UpdateFieldWIN : Form
    {
        protected LenderAPI _loan;
        protected APISchema _schema;
        protected string _selectedKey;
        protected string _instanceLevel;

        protected string _changedValue = string.Empty;
        protected bool _changeMade = false;
        private bool _reloadLoan = false;

        static bool _stopListening = false;
        private Thread listenThread1;
        static HttpListener listener;

        public UpdateFieldWIN(LenderAPI loan, APISchema item, string instanceLevel)
        {
            InitializeComponent();
            _loan = loan;
            _schema = item;
            _selectedKey = item.Key;
            _instanceLevel = instanceLevel;

            Differences.Columns.Add("ID", 250, HorizontalAlignment.Left);
            Differences.Columns.Add("New Value", 250, HorizontalAlignment.Left);
            Differences.Columns.Add("Prior Value", 250, HorizontalAlignment.Left);
        }

        public UpdateFieldWIN(LenderAPI loan, string field)
        {
            InitializeComponent();
            _loan = loan;
            _schema = null;
            _selectedKey = field;
            _instanceLevel = "";

            Differences.Columns.Add("ID", 250, HorizontalAlignment.Left);
            Differences.Columns.Add("New Value", 250, HorizontalAlignment.Left);
            Differences.Columns.Add("Prior Value", 250, HorizontalAlignment.Left);
        }



        private void UpdateFieldWIN_Load(object sender, EventArgs e)
        {
            var useThisKey = _selectedKey;

            FieldID.Text = _selectedKey;

            FieldValue.Text = Task.Run(() => _loan.Fields[_selectedKey]?.ToString() ?? "").Result;

            Slot.Visible = false;

            if ((_schema?.ENum ?? "") != "")
            {
                var dropDown = new ComboBox
                {
                    Name = "DynamicControl",
                    Site = Slot.Site,
                    Location = Slot.Location,
                    Width = 700,
                    Visible = true,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                try
                {
                    var theObject = Activator.CreateInstance(@"ICE.SDKtoAPI", @"ICE.SDKtoAPI.Contracts." + _schema.ENum);
                    var iit = theObject.Unwrap();
                    var props = iit.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    List<string> values = new List<string>();
                    foreach (var p in props)
                        dropDown.Items.Add(p.GetValue(iit));
                    //                    values.Add(p.GetValue(iit).ToString());

                    dropDown.SelectedIndexChanged += new EventHandler(ControlComboBoxChanged);
                    Controls.Add(dropDown);
                }
                catch (Exception eee)
                {
                    MessageBox.Show($"Associated enum [{_schema.ENum}] not defined");
                    dropDown.Enabled = false;
                }
            }
            else
            {
                if (_schema == null || _schema.Type.ToUpper() == "STRING")
                {
                    var strTextbox = new TextBox
                    {
                        Name = "DynamicControl",
                        Size = Slot.Size,
                        Location = Slot.Location,
                        Width = 400,
                        Text = FieldValue.Text,
                        Visible = true
                    };

                    Controls.Add(strTextbox);
                    strTextbox.TextChanged += new EventHandler(ControlTextChanged);
                }
                else if (_schema.Type.ToUpper() == "DECIMAL")
                {
                    var strTextbox = new TextBox
                    {
                        Name = "DynamicControl",
                        Size = Slot.Size,
                        Location = Slot.Location,
                        Width = 250,
                        Text = FieldValue.Text,
                        Visible = true
                    };

                    Controls.Add(strTextbox);
                    strTextbox.TextChanged += new EventHandler(ControlTextChanged);
                    strTextbox.KeyPress += new KeyPressEventHandler(DecHandler);

                }

                else if (_schema.Type.ToUpper() == "INT")
                {
                    var strTextbox = new TextBox
                    {
                        Name = "DynamicControl",
                        Size = Slot.Size,
                        Location = Slot.Location,
                        Width = 150,
                        Text = FieldValue.Text,
                        Visible = true
                    };

                    Controls.Add(strTextbox);
                    strTextbox.TextChanged += new EventHandler(ControlTextChanged);
                    strTextbox.KeyPress += new KeyPressEventHandler(IntHandler);

                }
                else if (_schema.Type.ToUpper() == "BOOL")
                {
                    var boolBox = new CheckBox
                    {
                        Name = "DynamicControl",
                        Location = Slot.Location,
                        Visible = true  //,
                                        //                        ThreeState = true
                    };

                    if (FieldValue.Text == null)
                        boolBox.CheckState = CheckState.Unchecked;
                    else
                        boolBox.CheckState = FieldValue.Text == "True" ? CheckState.Checked : CheckState.Unchecked;

                    boolBox.CheckStateChanged += new EventHandler(ControlCheckBoxChanged);
                    //                    boolBox.CheckedChanged += new EventHandler(ControlCheckBoxChanged);
                    Controls.Add(boolBox);
                }
                else if (_schema.Type.ToUpper() == "DATE")
                {
                    var dt = new DateTimePicker
                    {
                        Name = "DynamicControlD",
                        Location = Slot.Location,
                        Visible = true,
                        Format = DateTimePickerFormat.Short
                    };

                    if (!string.IsNullOrEmpty(FieldValue.Text))
                        dt.Value = Convert.ToDateTime(FieldValue.Text);

                    dt.ValueChanged += new EventHandler(ControlDateTimeChanged);

                    Controls.Add(dt);
                }
                else if (_schema.Type.ToUpper() == "DATETIME")
                {
                    var dt = new DateTimePicker
                    {
                        Name = "DynamicControlDT",
                        Location = Slot.Location,
                        Visible = true,
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "MM/dd/yyyy hh:mm:ss tt"
                    };

                    if (!string.IsNullOrEmpty(FieldValue.Text))
                        dt.Value = Convert.ToDateTime(FieldValue.Text);

                    dt.ValueChanged += new EventHandler(ControlDateTimeChanged);

                    Controls.Add(dt);
                }

            }
        }

        public bool ReloadLoan => _reloadLoan;

        private void IntHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == 0))
                e.Handled = true;
        }

        private void DecHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            else // only allow one minus 
            {
                if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (_changeMade)
            {
                // Listener
                //listener = new HttpListener();
                //listener.Prefixes.Add("https://api.elliemae.com/encompass/v1/loans/");
                //listener.Start();

                //listenThread1 = new Thread(new ParameterizedThreadStart(Startlistener));
                //listenThread1.Start();

                Save.Enabled = false;
                // force main grid refresh
                Task.Run(() => _loan.Fields[FieldID.Text] = _changedValue).Wait();

                try
                {

                    ProcessLoan();

                }
                catch (Exception ex)
                {
                    Status.Text = ex.Message;
                    Status.Refresh();
                }
            }
        }

        private void Startlistener(object s)
        {

            while (true)
            {
                ////blocks until a client has connected to the server
                ProcessRequest();
            }
        }

        private void ProcessRequest()
        {
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();

        }

        private void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            Thread.Sleep(1000);
            var data_text = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();

            //functions used to decode json encoded data.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var data1 = Uri.UnescapeDataString(data_text);
            //string da = Regex.Unescape(data_text);
            // var unserialized = js.Deserialize(data_text, typeof(String));

            var cleaned_data = HttpUtility.UrlDecode(data_text);

            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";

            //use this line to get your custom header data in the request.
            //var headerText = context.Request.Headers["mycustomHeader"];

            //use this line to send your response in a custom header
            //context.Response.Headers["mycustomResponseHeader"] = "mycustomResponse";

            MessageBox.Show(cleaned_data);
            context.Response.Close();
        }

        private async Task ProcessLoan()
        {
            Status.Text = "Updating Loan";
            Status.Refresh();
            if (Task.Run(() => _loan.UpdateLoanAsync()).Result)
            {
                using (var newLoan = new LenderAPI(FieldUpdaterWIN._con.ApiInstance, FieldUpdaterWIN._con.ApiClientId, FieldUpdaterWIN._con.ApiUser, FieldUpdaterWIN._con.ApiPassword, FieldUpdaterWIN._con.ApiSecret))
                {
                    Status.Text = "Get New Token";
                    Status.Refresh();
                    if (Task.Run(() => newLoan.GetToken()).Result)
                    {
                        Status.Text = "Get Guid";
                        Status.Refresh();
                        Task.Run(() => newLoan.GetLoanGuidAsync(_loan.LoanNumber)).Wait();

                        Status.Text = "Get Updated Loan";
                        Status.Refresh();
                        if (Task.Run(() => newLoan.LoadLoanAsync()).Result)
                        {
                            var xx = newLoan.Serialize();
                            // compare update
                            #region Fields
                            Status.Text = "Evaluate Fields";
                            Status.Refresh();
                            foreach (var field in _loan.FieldSchema)
                            {
                                var oldValue = await Task.Run(() => _loan.Fields[field.Key]);
                                var newValue = await Task.Run(() => newLoan.Fields[field.Key]);

                                if (oldValue == null && newValue == null) { }
                                else if (oldValue == null && newValue != null) // exception
                                {
                                    ListViewItem lvi = new ListViewItem(field.Key);
                                    lvi.SubItems.Add("");
                                    lvi.SubItems.Add(newValue.ToString());
                                    Differences.Items.Add(lvi);
                                }
                                else if (oldValue != null && newValue == null)
                                {
                                    ListViewItem lvi = new ListViewItem(field.Key);
                                    lvi.SubItems.Add(oldValue.ToString());
                                    lvi.SubItems.Add("");
                                    Differences.Items.Add(lvi);
                                }
                                else
                                {
                                    if (oldValue.ToString() != newValue.ToString())
                                    {
                                        {
                                            ListViewItem lvi = new ListViewItem(field.Key);
                                            lvi.SubItems.Add(oldValue.ToString());
                                            lvi.SubItems.Add(newValue.ToString());
                                            Differences.Items.Add(lvi);
                                        }
                                    }
                                }

                                // Now see if the field is in the pairing list
                                if (FieldUpdaterWIN._pairIds.Contains(field.Key))
                                {
                                    for (int i = 1; i <= 4; i++)
                                    {
                                        var k = $"{field.Key}#{i}";

                                        oldValue = await Task.Run(() => _loan.Fields[k]);
                                        newValue = await Task.Run(() => newLoan.Fields[k]);

                                        if (oldValue == null && newValue == null) { }
                                        else if (oldValue == null && newValue != null) // exception
                                        {
                                            ListViewItem lvi = new ListViewItem(field.Key);
                                            lvi.SubItems.Add("");
                                            lvi.SubItems.Add(newValue.ToString());
                                            Differences.Items.Add(lvi);
                                        }
                                        else if (oldValue != null && newValue == null)
                                        {
                                            ListViewItem lvi = new ListViewItem(field.Key);
                                            lvi.SubItems.Add(oldValue.ToString());
                                            lvi.SubItems.Add("");
                                            Differences.Items.Add(lvi);
                                        }
                                        else
                                        {
                                            if (oldValue.ToString() != newValue.ToString())
                                            {
                                                {
                                                    ListViewItem lvi = new ListViewItem(field.Key);
                                                    lvi.SubItems.Add(oldValue.ToString());
                                                    lvi.SubItems.Add(newValue.ToString());
                                                    Differences.Items.Add(lvi);
                                                }
                                            }
                                        }

                                    }

                                }

                            }
                            #endregion

                            #region Dynamic Fields
                            Status.Text = "Evaluate Dynamic Fields";
                            Status.Refresh();
                            foreach (var field in _loan.DynamicSchema)
                            {
                                var groups = field.Key.Split(')');
                                var newKey = groups[0].Replace("^(", "");
                                newKey += "00";
                                newKey += groups[2].Replace("(", "").Replace("$", "");

                                var oldValue = await Task.Run(() => _loan.Fields[newKey]);
                                var newValue = await Task.Run(() => newLoan.Fields[newKey]);
                                if (oldValue == null && newValue == null) { }
                                else if (oldValue == null && newValue != null) // exception
                                {
                                    ListViewItem lvi = new ListViewItem(newKey);
                                    lvi.SubItems.Add("");
                                    lvi.SubItems.Add(newValue.ToString());
                                    Differences.Items.Add(lvi);
                                }

                                else if (oldValue != null && newValue == null)
                                {
                                    ListViewItem lvi = new ListViewItem(newKey);
                                    lvi.SubItems.Add(oldValue.ToString());
                                    lvi.SubItems.Add("");
                                    Differences.Items.Add(lvi);
                                }

                                else
                                {
                                    if (oldValue.ToString() != newValue.ToString())
                                    {
                                        {
                                            ListViewItem lvi = new ListViewItem(newKey);
                                            lvi.SubItems.Add(oldValue.ToString());
                                            lvi.SubItems.Add(newValue.ToString());
                                            Differences.Items.Add(lvi);
                                        }
                                    }
                                }


                            }

                            #endregion

                            Status.Text = "Evalue Custom Fields";
                            Status.Refresh();
                            #region Custom FIelds
                            foreach (var field in _loan.CustomFields)
                            {
                                var oldValue = await Task.Run(() => _loan.Fields[field]);
                                var newValue = await Task.Run(() => newLoan.Fields[field]);

                                if (oldValue == null && newValue == null) { }
                                else if (oldValue == null && newValue != null) // exception
                                {
                                    ListViewItem lvi = new ListViewItem(field);
                                    lvi.SubItems.Add("");
                                    lvi.SubItems.Add(newValue.ToString());
                                    Differences.Items.Add(lvi);
                                }

                                else if (oldValue != null && newValue == null)
                                {
                                    ListViewItem lvi = new ListViewItem(field);
                                    lvi.SubItems.Add(oldValue.ToString());
                                    lvi.SubItems.Add("");
                                    Differences.Items.Add(lvi);
                                }

                                else
                                {
                                    if (oldValue.ToString() != newValue.ToString())
                                    {
                                        {
                                            ListViewItem lvi = new ListViewItem(field);
                                            lvi.SubItems.Add(oldValue.ToString());
                                            lvi.SubItems.Add(newValue.ToString());
                                            Differences.Items.Add(lvi);
                                        }
                                    }
                                }
                            }

                            #endregion

                            Status.Text = "Done";
                            Status.Refresh();
                            ExportIt.Enabled = true;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show($"{_loan.LastMessage}/{_loan.LastStatus} [Unable to complete UPDATE of Loan]");
            }

        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)Controls.Find("DynamicControl", false)[0];
            _changedValue = tb.Text;
            _changeMade = true;
        }

        private void ControlCheckBoxChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)Controls.Find("DynamicControl", false)[0];
            if (cb.CheckState == CheckState.Checked)
                _changedValue = "Y";
            else if (cb.CheckState == CheckState.Indeterminate)
                _changedValue = null;
            else if (cb.CheckState == CheckState.Unchecked)
                _changedValue = "N";

            _changeMade = true;
        }

        private void ControlComboBoxChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)Controls.Find("DynamicControl", false)[0];
            _changeMade = !string.IsNullOrEmpty(cb.Text);
            _changedValue = cb.Text;
        }

        private void ControlDateTimeChanged(object sender, EventArgs e)
        {
            bool fullDateTime = true;
            DateTimePicker dt = (DateTimePicker)Controls.Find("DynamicControlDT", false)[0];
            if (dt == null)  // Not DT, only D
            {
                dt = (DateTimePicker)Controls.Find("DynamicControlD", false)[0];
                fullDateTime = false;
            }

            _changeMade = true;
            _changedValue = fullDateTime ? Convert.ToDateTime(dt.Value).ToLongDateString() : Convert.ToDateTime(dt.Value).ToShortDateString();
        }

        private void UpdateFieldWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_changeMade)
                _reloadLoan = true;
        }

        private void ExportIt_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Results");

                ws.TabColor = Color.Blue;

                #region Create Columns
                ListView.ColumnHeaderCollection cols = Differences.Columns;
                for (int i = 0; i < cols.Count; i++)
                {
                    var hdr = cols[i];
                    ws.Cells[1, i + 1].Value = hdr.Text;
                    ws.Cells[1, i + 1].Style.Numberformat.Format = "@";
                    ws.Cells[1, i + 1].AutoFitColumns();
                }
                #endregion

                int row = 2;
                int col = 1;
                foreach (ListViewItem lvi in Differences.Items)
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

                var info = new System.IO.FileInfo(@"C:\Temp\ModifiedResults.xls");
                package.SaveAs(info);
                MessageBox.Show(@"Results exported to C:\Temp\ModifiedResults.xls");
            }
        }
    }
}
