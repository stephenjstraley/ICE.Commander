using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ICE.SDKtoAPI.Helpers.PipelineHelper;

namespace ICE.Commander
{
    public partial class ShowAPIWIN : Form
    {
        protected string _api;
        protected FieldUpdaterWIN _parent;

        public List<PipelineTerm> withResults = null;
        public List<string> withFields = null;

        public ShowAPIWIN(FieldUpdaterWIN parent, string api)
        {
            InitializeComponent();
            _api = api;
            _parent = parent;
        }

        private void ShowAPI_Load(object sender, EventArgs e)
        {
            callingAPI.Text = _api;
        }

        private void Retry_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string _thisWasSent = "";

            try
            {

                //LoanPipelineApi pipeline = _parent.BuildQueryPipelineCursor();

                //var cursor = JsonConvert.DeserializeObject<LoanPipelineViewContract>(callingAPI.Text);

                //withFields = cursor.Fields;

                //_thisWasSent = JsonConvert.SerializeObject(cursor, Formatting.Indented);

                //List<LoanPipelineItemContract> results = pipeline.PipelineRequest("10000", "randomAccess", null, "0", cursor, "true");

                //withResults = results;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ScreenCapture.GrabIt(ex.Message, _thisWasSent);
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;

            Close();
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            withFields = null;
            withResults = null;
            Close();
        }
    }
}
