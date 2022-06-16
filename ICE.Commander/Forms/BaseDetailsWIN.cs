using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using ICE.SDKtoAPI.Helpers;
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
    public partial class BaseDetailsWIN : Form
    {
        protected LenderAPI _baseConnection = null;
        public string SelectedLoan = string.Empty;
        public BaseDetailsWIN(LenderAPI api)
        {
            _baseConnection = api;
            InitializeComponent();
        }

        private void ViewPipelineWINcs_Shown(object sender, EventArgs e)
        {

        }

        protected virtual void QueryFields_DoubleClick(object sender, EventArgs e)
        {
        }

        protected virtual void BaseDetailsWIN_Load(object sender, EventArgs e)
        {

        }

        protected virtual void BaseDetailsWIN_Shown(object sender, EventArgs e)
        {

        }
    }
}
