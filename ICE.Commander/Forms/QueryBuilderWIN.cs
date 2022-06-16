using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ICE.SDKtoAPI.Helpers.PipelineHelper;
using static System.Windows.Forms.ListViewItem;

namespace ICE.Commander
{
    public enum TermStruct
    {
        Name = 0,
        TermBase,
        Term1,
        Term2,
        Field,
        Value,
        MatchType,
        OrdinalType,
        DateCriteria,
        Precision,
        Include,
        IsNumeric
    }

    public partial class QueryBuilderWIN : Form
    {
        public static ElieConnections _con;
        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        protected bool _foundInstance = false;
        protected List<string> _queryFields = new List<string>();
        protected LenderAPI _api;
        protected string _contractQuery;

        public QueryBuilderWIN()
        {
            InitializeComponent();
        }

        private void QueryBuilderWIN_Load(object sender, EventArgs e)
        {
            _connetions = EncompassConnections.GetConnections();
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));
            ButtonToggle(false);
        }

        private void EllieInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var theSelection = EllieInstance.SelectedItem;
            try
            {
                _con = _connetions.Where(t => t.Name == theSelection.ToString()).FirstOrDefault();

                _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                Task.Run(() => _api.GetTokenAsync()).Wait();
                if ((Task.Run(() => _api.HasAccessToken).Result))
                {
                    _foundInstance = true;
                    BuildReportableFields().Wait();
                }
                else
                {
                    _foundInstance = false;
                    MessageBox.Show("Unable to get access token for selected instance");
                    EllieInstance.SelectedIndex = -1;
                }

                ButtonToggle(_foundInstance);

                if (_terms.Columns.Count == 0)
                {
                    _terms.Columns.Add("Name", 80);
                    _terms.Columns.Add("Type");
                    _terms.Columns.Add("Term 1");
                    _terms.Columns.Add("Term 2");
                    _terms.Columns.Add("Field ID", 200);
                    _terms.Columns.Add("Value", 300);
                    _terms.Columns.Add("Match Type", 100);
                    _terms.Columns.Add("Ordinal Match", 150);
                    _terms.Columns.Add("Date Criteria", 100);
                    _terms.Columns.Add("Precision");
                    _terms.Columns.Add("Include");
                    _terms.Columns.Add("Numeric");
                }

                if (_contract.Columns.Count == 0)
                    _contract.Columns.Add("Name", _contract.Width);

                if (_outputFields.Columns.Count == 0)
                {
                    _outputFields.Columns.Add("Field", _outputFields.Width);
                    _outputFields.Items.Add(new ListViewItem("Loan.LoanNumber"));
                }

                if (_sortOrder.Columns.Count == 0)
                {
                    _sortOrder.Columns.Add("Field", _outputFields.Width);
                    _sortOrder.Items.Add(new ListViewItem("Loan.LoanNumber"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private async Task BuildReportableFields()
        {
            if (_foundInstance)
            {
                //Cursor.Current = Cursors.WaitCursor;

                var def = Task.Run(() => _api.GetPipelineCanonicalNamesAsync()).Result;
                foreach (var field in def.Fields)
                    _queryFields.Add(field.Name);

                _queryFields.Add("Loan.LoanNumber");
                _queryFields.Add("Loan.LoanFolder");
                _queryFields.Add("Loan.LoanPurpose");
                _queryFields.Sort();

                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("You must obtain a connection to an instance");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void AddTerm_Click(object sender, EventArgs e)
        {
            using (var win = new AddTermWIN(_queryFields, _terms.Items))
            {
                win.ShowDialog();
                if (win.DialogResult == DialogResult.OK)
                {
                    // add to the grid
                    var item = new ListViewItem(win.TermName); // 0
                    item.SubItems.Add("Term"); // 1
                    item.SubItems.Add(string.Empty); // 2
                    item.SubItems.Add(string.Empty); // 3
                    item.SubItems.Add(win.FieldID); // 4
                    item.SubItems.Add(win.Value); // 5
                    item.SubItems.Add(win.MatchType); // 6
                    item.SubItems.Add(win.OrdinalMatchType);  // 7
                    item.SubItems.Add(win.DateCriteria); // 8
                    item.SubItems.Add(win.DateMatchPrecision);  // 9
                    item.SubItems.Add(win.Include ? "Yes" : string.Empty); // 10
                    item.SubItems.Add(win.NumericValue ? "Yes" : string.Empty); // 11
                    _terms.Items.Add(item);
                }
            }
        }

        private void AddAndOrTerm_Click(object sender, EventArgs e)
        {
            List<string> terms = new List<string>();
            foreach (ListViewItem item in _terms.Items)
                terms.Add(item.Text);

            using (var win = new AndOrTermWIN(terms))
            {
                win.ShowDialog();
                if (win.DialogResult == DialogResult.OK && win.SelectedTerms.Count > 0)
                {
                    var item = new ListViewItem(win.TermName);
                    item.SubItems.Add(win.AndOr);  // 1
                    item.SubItems.Add(win.SelectedTerms[0].Text);
                    item.SubItems.Add(win.SelectedTerms[1].Text);
                    item.SubItems.Add(string.Empty); // 4
                    item.SubItems.Add(string.Empty); // 5
                    item.SubItems.Add(string.Empty); // 6
                    item.SubItems.Add(string.Empty); // 7
                    item.SubItems.Add(string.Empty); // 8
                    item.SubItems.Add(string.Empty); // 9
                    item.SubItems.Add(string.Empty); // 10
                    item.SubItems.Add(string.Empty); // 11
                    _terms.Items.Add(item);
                }
            }
        }

        private void _moveToContact_Click(object sender, EventArgs e)
        {
            // move selected terns to contract
            foreach (ListViewItem item in _terms.SelectedItems)
            {
                _contract.Items.Add(new ListViewItem(item.Text));
            }
            _contract.Refresh();
        }

        private void _removeFromContract_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in _contract.SelectedItems)
                _contract.Items.Remove(item);

            _contract.Refresh();
        }

        private class TermOrFilter
        {
            public object itemValue { get; set; }
        }
        private async void CreateQuery_Click(object sender, EventArgs e)
        {
            _contractQuery = string.Empty;

            // build fields
            var buildFields = new List<string>();
            foreach (ListViewItem x in _outputFields.Items)
                buildFields.Add(x.Text);

            // build sortOrder
            List<PipelineSortOrder> sortOrder = SortCriterionList();
            foreach (ListViewItem x in _sortOrder.Items)
                sortOrder.Add(SortCriterionList(x.Text));

            if (_contract.Items.Count > 0)
            {
                // Create Query
                // 1. Create KVP's of names and terms
                Dictionary<string, TermOrFilter> terms = new Dictionary<string, TermOrFilter>();

                try
                {
                    foreach (ListViewItem term in _terms.Items)
                    {
                        // go through and look for all TERM items before AND/OR
                        if (term.SubItems[(int)TermStruct.TermBase].Text == "Term")
                        {
                            object value;
                            if (term.SubItems[(int)TermStruct.IsNumeric].Text == "Yes")
                                value = Convert.ToDecimal(term.SubItems[(int)TermStruct.Value].Text);
                            else
                            {
                                value = term.SubItems[(int)TermStruct.Value].Text;
                                // now determine if it is a datetime
                                if (value.ToString().Length <= 11)
                                {
                                    int count = value.ToString().Count(f => f == '/');
                                    if (count == 2) // it's datetime
                                    {
                                        value = Convert.ToDateTime(value);
                                    }
                                }
                            }

                            string matchType = "";
                            if (!string.IsNullOrEmpty(term.SubItems[(int)TermStruct.MatchType].Text))
                                matchType = term.SubItems[(int)TermStruct.MatchType].Text;
                            else
                            {
                                if (!string.IsNullOrEmpty(term.SubItems[(int)TermStruct.OrdinalType].Text))
                                    matchType = term.SubItems[(int)TermStruct.OrdinalType].Text;
                            }

                            PipelineTerm qTerm;

                            if (!string.IsNullOrEmpty(term.SubItems[(int)TermStruct.DateCriteria].Text))  // create empty date term
                            {
                                matchType = term.SubItems[(int)TermStruct.DateCriteria].Text;
                                qTerm = GetPipelineTerm(term.SubItems[(int)TermStruct.Field].Text, matchType);
                            }
                            else
                            {
                                string precision = term.SubItems[(int)TermStruct.Precision].Text;
                                if (string.IsNullOrEmpty(precision))
                                    qTerm = GetPipelineTerm(term.SubItems[(int)TermStruct.Field].Text, value, matchType, (term.SubItems[(int)TermStruct.Include].Text == "Yes"));
                                else
                                    qTerm = GetPipelineTerm(term.SubItems[(int)TermStruct.Field].Text, value, matchType, (term.SubItems[(int)TermStruct.Include].Text == "Yes"), precision);
                            }
                            TermOrFilter termTerm = new TermOrFilter { itemValue = qTerm };

                            terms.Add(term.Text, termTerm);
                        }
                    }

                    // now go back through the list and create ADD's / OR's
                    foreach (ListViewItem term in _terms.Items)
                    {
                        if (term.SubItems[(int)TermStruct.TermBase].Text != "Term")  // will be then AND or OR
                        {
                            // grab the 2 terms in the condition
                            var term1Name = term.SubItems[(int)TermStruct.Term1].Text;
                            var term2Name = term.SubItems[(int)TermStruct.Term2].Text;

                            // look each up in the dictionary and grab the actual pipeline term
                            var term1 = terms[term1Name].itemValue;
                            var term2 = terms[term2Name].itemValue;

                            // grab name of this item
                            var newTermName = term.Text;
                            PipelineFilter qTerm;
                            if (term.SubItems[0].Text == "AND")
                                qTerm = GetFilterContractAnd(term1, term2);
                            else
                                qTerm = GetFilterContractOr(term1, term2);

                            TermOrFilter termTerm = new TermOrFilter { itemValue = qTerm };

                            terms.Add(newTermName, termTerm);
                        }
                    }

                    // pass the terms to new GetContract method
                    List<object> completeTerms = new List<object>();
                    foreach (var kvp in terms)
                    {
                        completeTerms.Add(kvp.Value.itemValue);
                    }

                    var contract = GetFilterContract(completeTerms);

                    var request = GetContract(sortOrder, contract, buildFields.ToArray());

                    _contractQuery = JsonConvert.SerializeObject(request, Formatting.Indented);

                    var toCount = Convert.ToInt32(ItemsToQuery.Text);

                    List<GuidCursor> response = Task.Run(() => _api.PipelineRequestAsync(request, toCount)).Result;

                    if (_api.IsOkStatus)
                    {
                        if (response == null || response.Count() == 0)
                            MessageBox.Show("No results found");
                        else
                        {
                            using (var win = new QueryResultsWIN(_con, response, buildFields))
                            {
                                win.ShowDialog();
                            }
                        }
                    }
                    else
                        MessageBox.Show($"{_api.LastStatus} - {_api.LastMessage}");

                }
                catch (Exception inter)
                {
                    MessageBox.Show("Internal Error: " + inter.Message);
                }
            }
            else
                MessageBox.Show("You must have at least 1 item in the contract");
        }

        private void _terms_DoubleClick(object sender, EventArgs e)
        {
            if (_terms.SelectedItems.Count > 0)
            {
                List<string> values = new List<string>();
                foreach (ListViewSubItem thing in _terms.SelectedItems[0].SubItems)
                {
                    values.Add(thing.Text);
                }

                // check to see which window to open
                var theType = _terms.SelectedItems[0].SubItems[(int)TermStruct.TermBase].Text;
                if (theType == "Term")
                {
                    using (var win = new AddTermWIN(_queryFields, _terms.Items, values))
                    {
                        win.ShowDialog();
                        if (win.DialogResult == DialogResult.OK)
                        {
                            var item = _terms.SelectedItems[0];
                            _terms.Name = win.TermName;
                            item.SubItems[0].Text = win.TermName; // 0
                            item.SubItems[4].Text = win.FieldID; // 4
                            item.SubItems[5].Text = win.Value;
                            item.SubItems[6].Text = win.MatchType;
                            item.SubItems[7].Text = win.OrdinalMatchType;
                            item.SubItems[8].Text = win.DateCriteria;
                            item.SubItems[9].Text = win.DateMatchPrecision;
                            item.SubItems[10].Text = win.Include ? "Yes" : ""; // 10
                            item.SubItems[11].Text = win.NumericValue ? "Yes" : ""; // 11
                        }

                    }
                }
                else
                {
                    List<string> terms = new List<string>();
                    foreach (ListViewItem item in _terms.Items)
                        terms.Add(item.Text);

                    using (var win = new AndOrTermWIN(terms, values))
                    {
                        win.ShowDialog();
                        if (win.DialogResult == DialogResult.OK)
                        {
                            var item = _terms.SelectedItems[0];
                            _terms.Name = win.TermName;
                            item.SubItems[(int)TermStruct.TermBase].Text = win.AndOr;
                            item.SubItems[(int)TermStruct.Term1].Text = win.SelectedTerms[0].Text;
                            item.SubItems[(int)TermStruct.Term2].Text = win.SelectedTerms[1].Text;
                        }
                    }
                }
            }
        }

        private void _viewAPI_Click(object sender, EventArgs e)
        {

        }

        private void _queryContract_Click(object sender, EventArgs e)
        {
            using (var win = new QueryContractWIN(_contractQuery))
            {
                win.ShowDialog();
            }
        }

        private void _addOutputFIeld_Click(object sender, EventArgs e)
        {
            using (var win = new OutputFieldSelectionWIN(_queryFields))
            {
                win.ShowDialog();
                if (win.DialogResult == DialogResult.OK)
                {
                    win._selectedFields.ForEach(t =>
                    {
                        var i = new ListViewItem(t);
                        _outputFields.Items.Add(i);
                    });
                }
            }
        }

        private void _removeOutputField_Click(object sender, EventArgs e)
        {
            var items = _outputFields.SelectedItems;
            foreach (ListViewItem thing in items)
                _outputFields.Items.Remove(thing);
        }

        private void SaveQuery_Click(object sender, EventArgs e)
        {
            var saveThis = new SavingQueryContract();
            foreach (ListViewItem item in _outputFields.Items)
            {
                saveThis.OutputFields.Add(new OutputFieldsContract { FieldName = item.Text });
            }
            foreach (ListViewItem item in _sortOrder.Items)
            {
                saveThis.Order.Add(new SortOrderContract { FieldName = item.Text });
            }
            foreach (ListViewItem item in _contract.Items)
            {
                saveThis.Contract.Add(new ContractContract { Name = item.Text });
            }
            foreach (ListViewItem item in _terms.Items)
            {
                saveThis.Terms.Add(new TermContract
                {
                    Name = item.Text,
                    Type = item.SubItems[(int)TermStruct.TermBase].Text,
                    Term1 = item.SubItems[(int)TermStruct.Term1].Text,
                    Term2 = item.SubItems[(int)TermStruct.Term2].Text,
                    FieldId = item.SubItems[(int)TermStruct.Field].Text,
                    Value = item.SubItems[(int)TermStruct.Value].Text,
                    MatchType = item.SubItems[(int)TermStruct.MatchType].Text,
                    OrdinalMatchType = item.SubItems[(int)TermStruct.OrdinalType].Text,
                    DateCriteria = item.SubItems[(int)TermStruct.DateCriteria].Text,
                    DateMatchPrecision = item.SubItems[(int)TermStruct.Precision].Text,
                    Include = item.SubItems[(int)TermStruct.Include].Text,
                    NumericValue = item.SubItems[(int)TermStruct.IsNumeric].Text
                });
            }

            // allow to pic and create folder and select name

            var saveThisString = JsonConvert.SerializeObject(saveThis);

            using (var win = new SaveFileDialog())
            {
                win.InitialDirectory = @"C:\";
                win.Title = "API Save Query";
                win.DefaultExt = "json";
                win.Filter = "Query Files (*.json)|*.json|All Filter (*.*)|*.*";
                win.FilterIndex = 1;
                if (win.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(win.FileName, saveThisString);
                }
            }
        }

        private void LoadSavedQuery_Click(object sender, EventArgs e)
        {
            using (var win = new OpenFileDialog())
            {
                win.InitialDirectory = @"C:\temp\";
                win.Title = "API Saved Queries";
                win.DefaultExt = ".json";
                win.Filter = "Query Files (*.json)|*.json|All Filter (*.*)|*.*";
                win.FilterIndex = 1;
                win.Multiselect = false;
                if (win.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var savedString = System.IO.File.ReadAllText(win.FileName);
                        SavingQueryContract contract = JsonConvert.DeserializeObject<SavingQueryContract>(savedString);
                        // first clear out this one - it may have default

                        ListViewItem foundItem = _outputFields.FindItemWithText("Loan.LoanNumber");
                        if (foundItem != null)
                            _outputFields.Items.Remove(foundItem);

                        foundItem = _outputFields.FindItemWithText("Loan.LoanPurpose");
                        if (foundItem != null)
                            _outputFields.Items.Remove(foundItem);

                        foundItem = _sortOrder.FindItemWithText("Loan.LoanNumber");
                        if (foundItem != null)
                            _sortOrder.Items.Remove(foundItem);


                        // now load the gui
                        contract.OutputFields.ForEach(t =>
                        {
                            var i = new ListViewItem(t.FieldName);
                            _outputFields.Items.Add(i);
                        });

                        contract.Order.ForEach(t =>
                        {
                            var i = new ListViewItem(t.FieldName);
                            _sortOrder.Items.Add(i);
                        });

                        contract.Contract.ForEach(t =>
                        {
                            var i = new ListViewItem(t.Name);
                            _contract.Items.Add(i);
                        });

                        foreach (TermContract term in contract.Terms)
                        {
                            var item = new ListViewItem(term.Name);
                            item.SubItems.Add(term.Type);
                            item.SubItems.Add(term.Term1);
                            item.SubItems.Add(term.Term2);
                            item.SubItems.Add(term.FieldId); // 4
                            item.SubItems.Add(term.Value); // 5
                            item.SubItems.Add(term.MatchType); // 6
                            item.SubItems.Add(term.OrdinalMatchType); // 7
                            item.SubItems.Add(term.DateCriteria); // 8
                            item.SubItems.Add(term.DateMatchPrecision); // 9
                            item.SubItems.Add(term.Include); // 10
                            item.SubItems.Add(term.NumericValue); // 11
                            _terms.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void RemoveTerm_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in _terms.SelectedItems)
                _terms.Items.Remove(item);

            _terms.Refresh();

        }

        private void ClearQuery_Click(object sender, EventArgs e)
        {
            // start over
            ButtonToggle(false);
            _terms.Items.Clear();
            _contract.Items.Clear();
            _outputFields.Items.Clear();
            _outputFields.Items.Add(new ListViewItem("Loan.LoanNumber"));
            _sortOrder.Items.Clear();
            _sortOrder.Items.Add(new ListViewItem("Loan.LoanNumber"));
            _contractQuery = string.Empty;
        }

        private void ButtonToggle(bool enabled)
        {
            _addTerm.Enabled = enabled;
            _addAndOrTerm.Enabled = enabled;
            _removeTerm.Enabled = enabled;
            _queryContract.Enabled = enabled;
            _createQuery.Enabled = enabled;
            _viewAPI.Enabled = enabled;
            _apiSource.Enabled = enabled;
            _saveQuery.Enabled = enabled;
            _loadSavedQuery.Enabled = enabled;
            _clearQuery.Enabled = enabled;
        }

        private void _addSortOrder_Click(object sender, EventArgs e)
        {
            using (var win = new OutputFieldSelectionWIN(_queryFields))
            {
                win.ShowDialog();
                if (win.DialogResult == DialogResult.OK)
                {
                    win._selectedFields.ForEach(t =>
                    {
                        var i = new ListViewItem(t);
                        _sortOrder.Items.Add(i);
                    });
                }
            }
        }

        private void _removeSortOrder_Click(object sender, EventArgs e)
        {
            var items = _sortOrder.SelectedItems;
            foreach (ListViewItem thing in items)
                _sortOrder.Items.Remove(thing);
        }

        private void _apiSource_Click(object sender, EventArgs e)
        {

            using (var win = new SaveFileDialog())
            {
                win.InitialDirectory = @"C:\";
                win.Title = "API Source Code";
                win.DefaultExt = "cs";
                win.Filter = "Query Files (*.cs)|*.cs|All Filter (*.*)|*.*";
                win.FilterIndex = 1;
                if (win.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(win.FileName, FileMode.OpenOrCreate))
                    {
                        var sWriter = new StreamWriter(stream, Encoding.ASCII);
                        // build the connection code
                        sWriter.WriteLine("using (_logger.BeginScope(\"<<YOUR PROCESS NAME\"))");
                        sWriter.WriteLine("{");
                        sWriter.WriteLine("    try");
                        sWriter.WriteLine("    {");
                        sWriter.WriteLine("        using (var api = new LenderAPI(<<INSTANCEID>>, <<CLIENTID>>, <<USERNAME>>, <<PASSWORD>>, <<SECRET>>))");
                        sWriter.WriteLine("        {");
                        sWriter.WriteLine("            await api.GetTokenAsync();");
                        sWriter.WriteLine("");
                        sWriter.WriteLine("            if (!api.HasAccessToken)");
                        sWriter.WriteLine("            {");
                        sWriter.WriteLine("                _logger.LogError(\"<<APPROPRIATE ERROR MESSAGE\");");
                        sWriter.WriteLine("                return;");
                        sWriter.WriteLine("            }");
                        sWriter.WriteLine("");
                        sWriter.WriteLine("            // query logic");
                        sWriter.WriteLine("");
                        sWriter.WriteLine("            // first sort order list");
                        sWriter.WriteLine("            List <PipelineSortOrder> sortOrder = SortCriterionList();");
                        // order fields
                        foreach (ListViewItem x in _sortOrder.Items)
                        {
                            var temp = x.Text;
                            sWriter.WriteLine("            sortOrder.Add(SortCriterionList(" + temp + "));");
                        }
                        // output fields
                        sWriter.WriteLine("");
                        sWriter.WriteLine("            // next, output fields");
                        sWriter.WriteLine("            List<string> outputFields = new List<string>();");
                        foreach (ListViewItem x in _outputFields.Items)
                        {
                            var temp = x.Text;
                            sWriter.WriteLine("            outputFields.Add(" + temp + ");");
                        }
                        // terms 
                        sWriter.WriteLine("");
                        sWriter.WriteLine("            // next, terms");


                        foreach (ListViewItem x in _terms.Items)
                        {
                            if (x.SubItems[(int)TermStruct.TermBase].Text == "Term")
                            {
                                List<string> values = new List<string>();
                                foreach (ListViewSubItem thing in x.SubItems)
                                {
                                    values.Add(thing.Text);
                                }

                                if (!string.IsNullOrEmpty(values[(int)TermStruct.MatchType])) // string match
                                {
                                    sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", \"{values[(int)TermStruct.Value]}\", StringFieldMatchType.{values[(int)TermStruct.MatchType].ToUpperFirst()} );");
                                }
                                else if (!string.IsNullOrEmpty(values[(int)TermStruct.OrdinalType])) // Ordinal match type
                                {
                                    if (!string.IsNullOrEmpty(values[(int)TermStruct.OrdinalType]))
                                    {
                                        if (values[(int)TermStruct.IsNumeric] == "Yes")
                                            sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", {values[(int)TermStruct.Value]}, OrdinalFieldMatchType.{values[(int)TermStruct.OrdinalType].ToUpperFirst()} );");
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(values[(int)TermStruct.DateCriteria])) // add precision
                                                if (!string.IsNullOrEmpty(values[(int)TermStruct.Precision]))
                                                    sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", \"{values[(int)TermStruct.Value]}\", OrdinalFieldMatchType.{values[(int)TermStruct.OrdinalType].ToUpperFirst()}, DateFieldCriterion.{values[(int)TermStruct.DateCriteria].ToUpperFirst()}, DateFieldMatchPrecision.{values[(int)TermStruct.Precision].ToUpperFirst()} );");
                                                else
                                                    sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", \"{values[(int)TermStruct.Value]}\", OrdinalFieldMatchType.{values[(int)TermStruct.OrdinalType].ToUpperFirst()}, DateFieldCriterion.{values[(int)TermStruct.DateCriteria].ToUpperFirst()} );");
                                            else
                                                sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", \"{values[(int)TermStruct.Value]}\", OrdinalFieldMatchType.{values[(int)TermStruct.OrdinalType].ToUpperFirst()} );");
                                        }
                                    }
                                    else
                                    {
                                        sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", \"{values[(int)TermStruct.Value]}\", OrdinalFieldMatchType.{values[(int)TermStruct.OrdinalType].ToUpperFirst()}, DateFieldMatchPrecision.{values[(int)TermStruct.Precision].ToUpperFirst()} );");
                                    }
                                }
                                else if (!string.IsNullOrEmpty(values[(int)TermStruct.DateCriteria])) // add precision
                                {
                                    if (!string.IsNullOrEmpty(values[(int)TermStruct.Precision]))
                                        sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", DateFieldCriterion.{values[(int)TermStruct.DateCriteria].ToUpperFirst()}, DateFieldMatchPrecision.{values[(int)TermStruct.Precision].ToUpperFirst()} );");
                                    else
                                        sWriter.WriteLine($"            var {values[0]} = GetPiprlineTerm(\"{values[(int)TermStruct.Field]}\", DateFieldCriterion.{values[(int)TermStruct.DateCriteria].ToUpperFirst()} );");
                                }
                                else
                                { //error
                                    sWriter.WriteLine($"   ERROR");
                                }
                            }
                        }

                        sWriter.WriteLine();

                        foreach (ListViewItem x in _terms.Items)
                        {
                            if (x.SubItems[(int)TermStruct.TermBase].Text != "Term")
                            {
                                List<string> values = new List<string>();
                                foreach (ListViewSubItem thing in x.SubItems)
                                {
                                    values.Add(thing.Text);
                                }

                                if (x.SubItems[(int)TermStruct.TermBase].Text == "AND")
                                    sWriter.WriteLine($"            var {values[0]} = GetFilterContractAnd({values[(int)TermStruct.Term1]}, {values[(int)TermStruct.Term2]});");
                                else if (x.SubItems[(int)TermStruct.TermBase].Text == "OR")
                                    sWriter.WriteLine($"            var {values[0]} = GetFilterContractOr({values[(int)TermStruct.Term1]}, {values[(int)TermStruct.Term2]});");
                                else
                                    sWriter.WriteLine($"   ERROR");
                            }
                        }

                        sWriter.WriteLine();

                        sWriter.WriteLine("            var request = GetContract(");
                        sWriter.WriteLine("                                sortOrder,");
                        sWriter.WriteLine("                                GetFilterContractAnd(");
                        // get the last item to prevent the comma
                        ListViewItem lastItem = _contract.Items[_contract.Items.Count - 1];
                        foreach (ListViewItem x in _contract.Items)
                        {
                            if (x.Text == lastItem.Text)
                                sWriter.WriteLine($"                                    {x.Text}");
                            else
                                sWriter.WriteLine($"                                    {x.Text},");
                        }

                        sWriter.WriteLine("                                    ),");
                        sWriter.WriteLine("                                    outputFields.ToArray()");
                        sWriter.WriteLine("                                  );");

                        sWriter.WriteLine();
                        sWriter.WriteLine("            var loans = api.PipellineRequestAsync(request).Result;");

                        sWriter.WriteLine("            if (api.LastStatus == HttpStatusCode.OK)");
                        sWriter.WriteLine("            {");
                        sWriter.WriteLine("            }");
                        sWriter.WriteLine("            else");
                        sWriter.WriteLine("            {");
                        sWriter.WriteLine("            }");

                        sWriter.WriteLine("        }");
                        sWriter.WriteLine("    }");
                        sWriter.WriteLine("    catch (Exception ex)");
                        sWriter.WriteLine("    {");
                        sWriter.WriteLine("        _logger.LogError(ex, \"<<YOUR EXCEPTION MESSAGE\");");
                        sWriter.WriteLine("    }");
                        sWriter.WriteLine("}");

                        sWriter.Flush();
                        MessageBox.Show("Code Generated");
                    }
                }
            }

        }

        private void QueryBuilderWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_api != null)
                _api.Dispose();
        }
    }
}
