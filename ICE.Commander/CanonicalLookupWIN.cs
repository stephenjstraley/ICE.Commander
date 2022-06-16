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
    public partial class CanonicalLookupWIN : Form
    {
        public string SelectedName = "";

        List<string> _canonicalNames = null;
        int _enterKeyStrike = 0;
        public CanonicalLookupWIN(List<string> names)
        {
            InitializeComponent();
            _canonicalNames = names;
        }

        private void CanonicalLookup_Load(object sender, EventArgs e)
        {
            CanonicalList.Items.Clear();
            CanonicalList.Items.AddRange(_canonicalNames.ToArray());
        }

        private void CanonicalList_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || !e.Alt)
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (_enterKeyStrike == 1)
                    {
                        SelectedName = CanonicalList.SelectedItem.ToString();
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void CanonicalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enterKeyStrike = 1;
        }
    }
}
