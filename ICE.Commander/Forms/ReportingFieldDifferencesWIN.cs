using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
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
    public partial class ReportingFieldDifferencescsWIN : Form
    {
        protected List<ElieConnections> _connections = new List<ElieConnections>();
        protected List<string> prodFields = new List<string>();
        //protected List<string> devFields = new List<string>();
        protected List<string> qaFields = new List<string>();
        protected List<string> uatFields = new List<string>();
        //protected List<string> tpoDevFields = new List<string>();
        protected List<string> tpoQaFields = new List<string>();
        protected List<string> tpoUatFields = new List<string>();
        protected List<string> tpoProdFields = new List<string>();
        public ReportingFieldDifferencescsWIN()
        {
            InitializeComponent();
            _connections = EncompassConnections.GetConnections();
        }

        private List<string> GetCanonicalFieldsByInstance(string instanceName)
        {
            List<string> fields = new List<string>();
            // go through each environment and pull canonical names / production DTC is base line
            var _con = _connections.Where(t => t.Name == instanceName).FirstOrDefault();
            using (var prodCon = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret))
            {
                if (Task.Run(() => prodCon.GetToken()).Result)
                {
                    // get canonical names for production
                    PipelineCanonicalFieldList def = Task.Run(() => prodCon.GetPipelineCanonicalNamesAsync()).Result;
                    foreach (var field in def.Fields)
                        fields.Add(field.Name);
                    fields.Add("Loan.LoanNumber");
                    fields.Sort();
                }
            }
            return fields;
        }

        private void ReportingFieldDifferencescs_Load(object sender, EventArgs e)
        {
        }

        private void ReportingFieldDifferencescs_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            prodFields = GetCanonicalFieldsByInstance("Production");
            //devFields = GetCanonicalFieldsByInstance("Development");
            qaFields = GetCanonicalFieldsByInstance(MainWindow.defaultEnvironment);
            //uatFields = GetCanonicalFieldsByInstance("UAT");
            //tpoQaFields = GetCanonicalFieldsByInstance("TPO-QA");

            //PopulateDevDifferences();
            PopulateQaDiffernces();
            PopulateUatDifferences();
            //PopulateTpoDevDifferences();
            PopulateTpoQaDifferences();
            PopulateTpoUatDifferences();
            PopulateTpoProdDifferences();

            Cursor.Current = Cursors.Default;
        }
        private void PopulateDevDifferences()
        {
            //Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    var notInDev = prodFields.Where(a => !devFields.Any(a.SequenceEqual)).ToList();

            //    ListMissingDev.Columns.Add($"Missing In Dev ({notInDev.Count})", 300);

            //    foreach (var n in notInDev)
            //    {
            //        var item = new ListViewItem(n);
            //        ListMissingDev.Items.Add(item);
            //    }

            //}
            //catch
            //{

            //}
            //Cursor.Current = Cursors.Default;
        }
        private void PopulateQaDiffernces()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var notInQa = prodFields.Where(a => !qaFields.Any(a.SequenceEqual)).ToList();

                ListMissingQa.Columns.Add($"Missing In QA ({notInQa.Count})", 300);

                foreach (var n in notInQa)
                {
                    var item = new ListViewItem(n);
                    ListMissingQa.Items.Add(item);
                }

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        private void PopulateUatDifferences()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var notInUat = prodFields.Where(a => !uatFields.Any(a.SequenceEqual)).ToList();

                ListMissingUat.Columns.Add($"Missing In UAT ({notInUat.Count})", 300);

                foreach (var n in notInUat)
                {
                    var item = new ListViewItem(n);
                    ListMissingUat.Items.Add(item);
                }

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        private void PopulateTpoDevDifferences()
        {
            //Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    var notInTpoDev = prodFields.Where(a => !tpoDevFields.Any(a.SequenceEqual)).ToList();

            //    ListMissingTPODev.Columns.Add($"Missing In TPO Dev ({notInTpoDev.Count})", 300);

            //    foreach (var n in notInTpoDev)
            //    {
            //        var item = new ListViewItem(n);
            //        ListMissingTPODev.Items.Add(item);
            //    }

            //}
            //catch
            //{

            //}
            //Cursor.Current = Cursors.Default;
        }
        private void PopulateTpoQaDifferences()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //var notInTpoDev = prodFields.Where(a => !tpoDevFields.Any(a.SequenceEqual)).ToList();

                ListMissingTPOQa.Columns.Add($"Missing In TPO QA (-)", 300);

                //foreach (var n in notInTpoDev)
                //{
                //    var item = new ListViewItem(n);
                //    ListMissingTPODev.Items.Add(item);
                //}

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        private void PopulateTpoUatDifferences()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //var notInTpoDev = prodFields.Where(a => !tpoDevFields.Any(a.SequenceEqual)).ToList();

                ListMissingTPOUat.Columns.Add($"Missing In TPO Uat (-)", 300);

                //foreach (var n in notInTpoDev)
                //{
                //    var item = new ListViewItem(n);
                //    ListMissingTPODev.Items.Add(item);
                //}

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }
        private void PopulateTpoProdDifferences()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //var notInTpoDev = prodFields.Where(a => !tpoDevFields.Any(a.SequenceEqual)).ToList();

                ListMissingTPOProd.Columns.Add($"Missing In TPO Prod (-)", 300);

                //foreach (var n in notInTpoDev)
                //{
                //    var item = new ListViewItem(n);
                //    ListMissingTPODev.Items.Add(item);
                //}

            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }

    }
}
