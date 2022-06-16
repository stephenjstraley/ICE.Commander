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
    public partial class QuerySourceWIN : Form
    {
        protected List<string> _lines;
        public QuerySourceWIN(List<string> lines)
        {
            InitializeComponent();
            _lines = lines;
        }

        private void QuerySourceWINcs_Load(object sender, EventArgs e)
        {
            foreach (string line in _lines)
            {
                SourceCode.Text += line + "\r\n";
            }
        }
    }
}
