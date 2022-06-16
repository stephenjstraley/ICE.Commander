using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class AddTermWIN : Form
    {
        protected List<string> _queryFields;
        protected ListView.ListViewItemCollection _items;
        protected List<string> _editValues = new List<string>();
        protected string _currentTermName = "";
        public AddTermWIN(List<string> queryFields, ListView.ListViewItemCollection items)
        {
            _queryFields = queryFields;
            _items = items;
            InitializeComponent();
        }
        public AddTermWIN(List<string> queryFields, ListView.ListViewItemCollection items, List<string> values) : this(queryFields, items)
        {

            _editValues = values;
        }

        public string TermName { get { return _TermName.Text; } }
        public string FieldID { get { return _FieldId.Text; } }
        public string Value { get { return _Value.Text; } }
        public bool Include { get { return _Include.Checked; } }
        public bool NumericValue { get { return _NumericValue.Checked; } }
        public string MatchType { get { return _MatchType.GetItemText(_MatchType.SelectedItem); } }
        public string OrdinalMatchType { get { return _OrdinalMatchType.Text; } }
        public string DateCriteria { get { return _DateCriteria.Text; } }
        public string DateMatchPrecision { get { return _DateMatchPrecision.Text; } }

        private void AddTermWIN_Load(object sender, EventArgs e)
        {
            var typeObj = Assembly.Load("STAR.Encompass.SDKtoAPI").GetTypes().First(t => t.Name == "StringFieldMatchType");
            FieldInfo[] fields = typeObj.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
            fields.ToList().ForEach(t => _MatchType.Items.Add(t.Name.ToLowerFirst()));

            //// Date Criteria
            typeObj = Assembly.Load("STAR.Encompass.SDKtoAPI").GetTypes().First(t => t.Name == "DateFieldCriterion");
            fields = typeObj.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
            fields.ToList().ForEach(t => _DateCriteria.Items.Add(t.Name.ToLowerFirst()));

            // Ordinal Match Criterion
            typeObj = Assembly.Load("STAR.Encompass.SDKtoAPI").GetTypes().First(t => t.Name == "OrdinalFieldMatchType");
            fields = typeObj.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
            fields.ToList().ForEach(t => _OrdinalMatchType.Items.Add(t.Name.ToLowerFirst()));

            // Date Match Precision
            typeObj = Assembly.Load("STAR.Encompass.SDKtoAPI").GetTypes().First(t => t.Name == "DateFieldMatchPrecision");
            fields = typeObj.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
            fields.ToList().ForEach(t => _DateMatchPrecision.Items.Add(t.Name.ToLowerFirst()));

            BindingSource bs = new BindingSource();
            bs.DataSource = _queryFields;
            _FieldId.DataSource = bs;

            if (_editValues.Count > 0) // Edit mode so select and fill controls
            {
                _TermName.Text = _editValues[(int)TermStruct.Name];
                _Include.Checked = !string.IsNullOrEmpty(_editValues[(int)TermStruct.Include]);
                _NumericValue.Checked = !string.IsNullOrEmpty(_editValues[(int)TermStruct.IsNumeric]);
                _Value.Text = _editValues[(int)TermStruct.Value];


                if (!string.IsNullOrEmpty(_editValues[(int)TermStruct.Field]))
                    _FieldId.SelectedItem = _editValues[(int)TermStruct.Field];

                if (!string.IsNullOrEmpty(_editValues[(int)TermStruct.MatchType]))
                    _MatchType.SelectedItem = _editValues[(int)TermStruct.MatchType];

                if (!string.IsNullOrEmpty(_editValues[(int)TermStruct.OrdinalType]))
                    _OrdinalMatchType.SelectedItem = _editValues[(int)TermStruct.OrdinalType];

                if (!string.IsNullOrEmpty(_editValues[(int)TermStruct.DateCriteria]))
                    _DateCriteria.SelectedItem = _editValues[(int)TermStruct.DateCriteria];

                if (!string.IsNullOrEmpty(_editValues[(int)TermStruct.Precision]))
                    _DateMatchPrecision.SelectedItem = _editValues[(int)TermStruct.Precision];
            }

        }

        private void Accept_Click(object sender, EventArgs e)
        {
            var count = 0;
            count += string.IsNullOrEmpty(MatchType) ? 0 : 1;
            count += string.IsNullOrEmpty(OrdinalMatchType) ? 0 : 1;
            count += string.IsNullOrEmpty(DateCriteria) ? 0 : 1;

            if (string.IsNullOrEmpty(_TermName.Text))
                MessageBox.Show("You must enter a name for this term");
            else if (string.IsNullOrEmpty(_FieldId.Text))
                MessageBox.Show("You must select a field (GUID is automatically selected");
            //            else if (string.IsNullOrEmpty(_Value.Text))
            //                MessageBox.Show("You must enter a VALUE");
            else if (count != 1)
                MessageBox.Show("You must select only 1 match/date/ordinal type");
            else
                DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _TermName_Leave(object sender, EventArgs e)
        {
            if (_editValues.Count() == 0) // add mode
            {
                // check term name if it exists
                foreach (ListViewItem item in _items)
                {
                    if (item.Text.ToUpper() == _TermName.Text.ToUpper())
                    {
                        MessageBox.Show("That term name already exists.  Please choose another one");
                        _TermName.Focus();
                        break;
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in _items)
                {
                    if (_currentTermName != _TermName.Text)
                    {
                        if (item.Text.ToUpper() == _TermName.Text.ToUpper())
                        {
                            MessageBox.Show("That term name already exists.  Please choose another one");
                            _TermName.Focus();
                            break;
                        }
                    }
                    else
                        break;
                }
            }
        }

        private void _TermName_Enter(object sender, EventArgs e)
        {
            _currentTermName = _TermName.Text;
        }
    }
}
