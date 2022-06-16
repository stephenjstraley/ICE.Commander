using ICE.SDKtoAPI;
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
    public partial class BaseTestFormWIN : Form
    {
        public static ElieConnections _con;
        protected LenderAPI _api;
        protected List<ElieConnections> _connetions = new List<ElieConnections>();

        public BaseTestFormWIN()
        {
            InitializeComponent();
            LoadInstances();
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections(true);

        private void BaseTestFormWIN_Load(object sender, EventArgs e)
        {
            _connetions.ForEach(t => EllieInstance.Items.Add(t.Name));
        }

        private void EllieInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var theSelection = EllieInstance.SelectedItem;
            LoanNumber.Text = "";
            try
            {
                if (theSelection != null)
                {
                    _con = _connetions.Where(t => t.Name == theSelection?.ToString()).FirstOrDefault();

                    if (_con != null)
                    {
                        _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                        //var ttt = _api.GetTokenAsync().Result;

                        var token = Task.Run(() => _api.GetTokenAsync()).Result;

                        if (token == null)
                        {
                            MessageBox.Show("Unable to get access token for selected instance");
                            EllieInstance.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        protected virtual void GoGetThem_Click(object sender, EventArgs e)
        {

        }

        private void ViewPipeline_Click(object sender, EventArgs e)
        {
            if (EllieInstance.SelectedIndex >= 0)
            {
                _con = _connetions.Where(t => t.Name == EllieInstance.SelectedItem.ToString()).FirstOrDefault();
                using (var eb = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
                {
                    using (var win = new ViewPipelineWINcs(eb))
                    {
                        if (win.ShowDialog() == DialogResult.OK)
                        {
                            LoanNumber.Text = win.SelectedLoan;
                            _listFields.Clear();
                        }
                    }
                }
            }
        }

        protected virtual void _listFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
