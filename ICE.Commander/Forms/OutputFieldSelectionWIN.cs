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
    public partial class OutputFieldSelectionWIN : Form
    {
        protected List<string> _queryFields = new List<string>();
        public List<string> _selectedFields = new List<string>();

        public OutputFieldSelectionWIN(List<string> queryFields)
        {
            InitializeComponent();
            _queryFields = queryFields;
        }

        private void OutputFieldSelectionWIN_Load(object sender, EventArgs e)  // build the grid view
        {
            _outputFields.Columns.Add("Field", _outputFields.Width);
            _queryFields.ForEach(t => _outputFields.Items.Add(new ListViewItem(t)));
        }

        private void _accept_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in _outputFields.SelectedItems)
            {
                _selectedFields.Add(item.Text);
            }
            DialogResult = DialogResult.OK;
        }

        private void _searchFor_TextChanged(object sender, EventArgs e)
        {
            var text = _searchFor.Text;
            _outputFields.Items.Clear();
            var tempList = _queryFields.Where(t => t.Contains(text));
            tempList.ToList().ForEach(t => _outputFields.Items.Add(new ListViewItem(t)));
        }
    }
}
