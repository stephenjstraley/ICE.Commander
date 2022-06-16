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
    public partial class AdditionalFieldDefsWIN : Form
    {
        protected List<string> _additionalFields;
        protected LenderAPI _api;

        public AdditionalFieldDefsWIN(LenderAPI api, List<string> adds)
        {
            InitializeComponent();
            _additionalFields = adds;
            _api = api;
            adds.ForEach(t => SelectedField.Items.Add(t));
        }

        private void SelectedField_SelectedIndexChanged(object sender, EventArgs e)
        {
            GO.Enabled = true;
        }

        private async void GO_Click(object sender, EventArgs e)
        {
            V1Schema.Clear();
            V3Schema.Clear();

            if (_api != null)
            {
                await Task.Run(() => _api.GetTokenAsync());

                if (_api.Token != null)  // (loan.HasAccessToken)
                {
                    string id = SelectedField.Text;
                    var v1 = Task.Run(() => _api.GetV1FieldSchemaAsync(id)).Result;
                    if (_api.IsOkStatus)
                    {
                        var v3 = Task.Run(() => _api.GetV3FieldSchemaAsync(id)).Result;
                        if (_api.IsOkStatus)
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

        private void CopyV1Meta_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(V1Meta.Text);
            MessageBox.Show("Copied to Clipboard");
        }

        private void CopyV3Meta_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(V3Meta.Text);
            MessageBox.Show("Copied to Clipboard");
        }
    }
}
