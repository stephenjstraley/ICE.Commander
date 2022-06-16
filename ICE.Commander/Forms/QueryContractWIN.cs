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
    public partial class QueryContractWIN : Form
    {
        public QueryContractWIN()
        {
            InitializeComponent();
        }

        public QueryContractWIN(string contract)
        {
            InitializeComponent();
            _contract.Text = contract;
            _contract.SelectionLength = 0;
        }
    }
}
