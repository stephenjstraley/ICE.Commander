using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace ICE.Commander
{
    public partial class AndOrTermWIN : Form
    {
        List<string> _availableTerms = new List<string>();
        List<string> _editValues = new List<string>();
        public AndOrTermWIN(List<string> passedTerms)
        {
            InitializeComponent();
            _availableTerms = passedTerms;
        }
        public AndOrTermWIN(List<string> passedTerms, List<string> values) : this(passedTerms)
        {
            _editValues = values;
        }

        public ListViewItemCollection SelectedTerms { get { return _selectedTerms.Items; } }
        public string TermName { get { return _termName.Text; } }
        public string AndOr { get { return _andCondition.Checked ? "AND" : "OR"; } }
        private void AndOrTermWIN_Load(object sender, EventArgs e)
        {
            _terms.Columns.Add("Terms", _terms.Width);
            _selectedTerms.Columns.Add("Terms", _terms.Width);

            foreach (var item in _availableTerms)
            {
                var temp = new ListViewItem(item);
                _terms.Items.Add(temp);
            }

            if (_editValues.Count > 0)
            {
                _termName.Text = _editValues[0];
                // now set the item to AND or OR, and remove the two items from the last and add the two items to the other list
                if (_editValues[1] == "AND")
                    _andCondition.Checked = true;
                else
                    _orCondition.Checked = true;

                for (int x = 2; x < 4; x++)
                {
                    string workingTerm = _editValues[x]; // term 1
                    ListViewItem foundItem = _terms.FindItemWithText(workingTerm);
                    if (foundItem != null)
                    {
                        ListViewItem clone = (ListViewItem)foundItem.Clone();
                        _terms.Items.Remove(foundItem);
                        _selectedTerms.Items.Add(clone);
                        _selectedTerms.Refresh();
                        _terms.Refresh();
                    }
                }


            }
        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _accept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_termName.Text))
                MessageBox.Show("You must give this a unique name");
            else if (_selectedTerms.Items.Count != 2)
                MessageBox.Show("You MUST have only 2 selected terms");
            else
                DialogResult = DialogResult.OK;
        }

        private void _selectTerm_Click(object sender, EventArgs e)
        {
            if (_terms.SelectedItems.Count > 0 && _terms.SelectedItems.Count < 3)
            {
                foreach (ListViewItem item in _terms.SelectedItems)
                {
                    ListViewItem clone = (ListViewItem)item.Clone();
                    _terms.Items.Remove(item);
                    _selectedTerms.Items.Add(clone);
                    _selectedTerms.Refresh();
                    _terms.Refresh();
                }
            }
            _selectTerm.Enabled = (_selectedTerms.Items.Count < 2);
        }

        private void _removeTerm_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in _selectedTerms.SelectedItems)
            {
                _selectedTerms.Items.Remove(item);
                _terms.Items.Add(item);
                _selectedTerms.Refresh();
                _terms.Refresh();
            }

            _selectTerm.Enabled = (_selectedTerms.Items.Count < 2);
        }

        private void _termName_Leave(object sender, EventArgs e)
        {
            if (_availableTerms.Contains(_termName.Text))
            {
                MessageBox.Show("The TERM NAME is already in use.  Please choose a new name");
                _termName.Focus();
            }

        }
    }
}
