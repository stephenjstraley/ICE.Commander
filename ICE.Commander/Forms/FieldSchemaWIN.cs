using ICE.SDKtoAPI;
using Newtonsoft.Json;
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
    public partial class FieldSchemaWIN : Form
    {
        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        public static ElieConnections _con;
        protected LenderAPI _api;
        protected List<string> _ids = new List<string>();

        public FieldSchemaWIN()
        {
            InitializeComponent();
            LoadInstances();
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private void FieldSchemaWIN_Load(object sender, EventArgs e)
        {
            _con = _connetions.Where(t => t.Name == MainWindow.defaultEnvironment).FirstOrDefault();

            _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

            var token = Task.Run(() => _api.GetTokenAsync()).Result;

            if (token != null)
            {
                _ids = Task.Run(() => _api.GetAllFieldIdsAsync()).Result;

                if (_api.IsOkStatus)
                {
                    SelectedField.Items.AddRange(_ids.ToArray());
                }
                else // do something
                {
                    Message.Visible = true;
                    Message.Text = _api.LastMessage;
                }
            }
        }

        private void SelectedField_SelectedIndexChanged(object sender, EventArgs e)
        {
            GO.Enabled = true;
        }

        private void GO_Click(object sender, EventArgs e)
        {
            V1Schema.Clear();
            V3Schema.Clear();

            if (_api != null)
            {

                if (_api.Token != null)  // (loan.HasAccessToken)
                {
                    string id = SelectedField.Text;
                    var v1 = Task.Run(() => _api.GetV1FieldSchemaAsync(id)).Result;
                    if (_api.IsOkStatus)
                    {
                        var v3 = Task.Run(() => _api.GetV3FieldSchemaAsync(id)).Result;
                        if (_api.IsOkStatus)
                        {

                            if (v1 == null || v3 == null)
                            {
                                MessageBox.Show("V1 or V3 field schema is NULL");
                            }
                            else
                            {
                                var v1Text = JsonConvert.SerializeObject(v1, Formatting.Indented);
                                V1Schema.Text = v1Text;
                                V1Schema.Refresh();

                                var v3Text = JsonConvert.SerializeObject(v3, Formatting.Indented);
                                V3Schema.Text = v3Text;
                                V3Schema.Refresh();

                                v1Text = id + "~1~2~3~4~5~6~7~8";
                                v3Text = id + "~1~2~3~4~5~6~7~8";

                                var v3Item = v3[0];

                                var temp = v3Item.JsonPath.Replace("$.", string.Empty);
                                temp = temp.Replace("applications[0]", "Applications{current}");
                                var newTemp = temp.Split('.');
                                for (int x = 1; x < newTemp.Length; x++)
                                    newTemp[x] = StringExtensions.FirstUpper(newTemp[x]);

                                temp = string.Join(".", newTemp);

                                // TrueDECIMAL_2false~1~False~decimal~True~PACE Loan Payoff Amount~false~~DECIMAL_2
                                v3Text = v3Text.Replace("~1", "~" + temp);
                                v3Text = v3Text.Replace("~2", "~" + v3Item.ReadOnly.ToString().ToLower());
                                v3Text = v3Text.Replace("~3", "~" + v3Item.DataType.ToLower());
                                v3Text = v3Text.Replace("~4", "~" + v3Item.Nullable.ToString().ToLower());
                                v3Text = v3Text.Replace("~5", "~" + v3Item.Description);
                                v3Text = v3Text.Replace("~6", "~false");
                                v3Text = v3Text.Replace("~7", "~");
                                v3Text = v3Text.Replace("~8", "~" + v3Item.Format);

                                v1Text = v1Text.Replace("~2", "~" + v3Item.ReadOnly.ToString().ToLower());
                                v1Text = v1Text.Replace("~3", "~" + v3Item.DataType.ToLower());
                                v1Text = v1Text.Replace("~4", "~" + v3Item.Nullable.ToString().ToLower());
                                v1Text = v1Text.Replace("~5", "~" + v3Item.Description);
                                v1Text = v1Text.Replace("~6", "~false");
                                v1Text = v1Text.Replace("~7", "~");
                                v1Text = v1Text.Replace("~8", "~" + v3Item.Format);

                                V1Meta.Text = v1Text;
                                V3Meta.Text = v3Text;
                                V1Meta.Refresh();
                                V3Meta.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void SelectedField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (SelectedField.SelectedIndex == SelectedField.Items.Count - 1)
                {
                    SelectedField.SelectedIndex = 0;
                    return;
                }
                if (SelectedField.SelectedIndex >= 0 & SelectedField.SelectedIndex < SelectedField.Items.Count - 1)
                {

                    SelectedField.SelectedIndex = SelectedField.SelectedIndex + 0;
                    GO_Click(null, null);
                }
            }
            else
                SelectedField.DroppedDown = true;
        }

        private void FieldSchemaWIN_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void SelectedField_Enter(object sender, EventArgs e)
        {

        }
    }
}
