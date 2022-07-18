using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using ICE.SDKtoAPI.SupportingClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class ENumGenerationWIN : Form
    {
        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        public static ElieConnections _con;
        protected LenderAPI _api;
        protected string _resourcePath = @"C:\Users\Steve.Straley\source\repos\stephenjstraley\ICE.SDKtoAPI\ICE.SDKtoAPI\Resources";

        public ENumGenerationWIN()
        {
            InitializeComponent();
            LoadInstances();
        }

        protected void LoadInstances() => _connetions = EncompassConnections.GetConnections();

        private void SelectOutputFolder_Click(object sender, EventArgs e)
        {
            using (var f = new FolderBrowserDialog())
            {
                f.ShowNewFolderButton = true;

                var result = f.ShowDialog(this.Owner);

                if (result == DialogResult.OK && !string.IsNullOrEmpty(f.SelectedPath))
                {
                    OutputFolder.Text = f.SelectedPath;
                }
            }
        }

        private async void Generate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(OutputFolder.Text) && !string.IsNullOrEmpty(Namespace.Text))
            {
                try
                {
                    Output.Clear();

                    // Load the dictionaries
                    var v1File = File.ReadAllText($@"{_resourcePath}\DictionaryFieldsV1.txt");
                    var v3File = File.ReadAllText($@"{_resourcePath}\DictionaryFieldsV3.txt");

                    Dictionary<string, APISchema> _fieldsV1 = new Dictionary<string, APISchema>(StringComparer.InvariantCultureIgnoreCase);
                    Dictionary<string, APISchema> _dynamicFieldsV1 = new Dictionary<string, APISchema>(StringComparer.InvariantCultureIgnoreCase);

                    Dictionary<string, APISchema> _fieldsV3 = new Dictionary<string, APISchema>(StringComparer.InvariantCultureIgnoreCase);
                    Dictionary<string, APISchema> _dynamicFieldsV3 = new Dictionary<string, APISchema>(StringComparer.InvariantCultureIgnoreCase);

                    var v1Passed = SDKAPIFieldSupport.ParseDictionary(v1File, _fieldsV1, _dynamicFieldsV1);
                    var v3Passed = SDKAPIFieldSupport.ParseDictionary(v3File, _fieldsV3, _dynamicFieldsV3);

                    // use QA to get schema
                    _con = _connetions.Where(t => t.Name == MainWindow.defaultEnvironment).FirstOrDefault();

                    _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                    await Task.Run(() => _api.GetTokenAsync());

                    if (_api.Token != null)  // (loan.HasAccessToken)
                    {
                        var fields = Task.Run(() => _api.GetAllFieldIdsAsync()).Result;

                        using (StreamWriter wr = new StreamWriter(OutputFolder.Text + "\\SDKAPIBaseEnums.cs"))
                        {
                            wr.WriteLine($"namespace {Namespace.Text}");
                            wr.WriteLine("{");

                            foreach (var field in fields)
                            {
                                List<string> savedList = new List<string>();

                                var schema = Task.Run(() => _api.GetV3FieldSchemaAsync(field)).Result;

//                                if (field == "8")
//                                {
//                                    var ttt = 1;
//                                    schema = Task.Run(() => _api.GetV3FieldSchemaAsync(field)).Result;
//                                }

                                if (schema.Count == 1 && (schema[0]?.Options != null && schema[0]?.Options.Count > 0))
                                {
                                    UpdateDisplay($"Field:...  {field}");

                                    var className = schema[0].Id;
                                    className = className.Replace(".", "_");

                                    var enumName = $"e{className}";

                                    // find in dictionaries
                                    var v1Schema = _fieldsV1.FirstOrDefault(t => t.Value.Key.ToUpper() == field.ToUpper());
                                    if (v1Schema.Key != null)
                                        v1Schema.Value.ENum = enumName;
                                    else
                                        UpdateDisplay($"   MISSING in file (V1):  {field}");

                                    var v3Schema = _fieldsV3.FirstOrDefault(t => t.Value.Key.ToUpper() == field.ToUpper());
                                    if (v3Schema.Key != null)
                                        v3Schema.Value.ENum = enumName;
                                    else
                                        UpdateDisplay($"   MISSING in file (V3):  {field}");


                                    wr.WriteLine($"    public class {enumName}");   // Enums
                                    wr.WriteLine("    {");
                                    foreach (var opt in schema[0].Options)
                                    {
                                        var val = opt.Value;
                                        var output = opt.Value;

                                        if (string.IsNullOrEmpty(val))
                                        {
                                            wr.WriteLine($"        public static readonly string Empty = \"\";");
                                        }
                                        else if (val == "+")
                                            val = "Plus";
                                        else if (val == "-")
                                            val = "Minus";
                                        else if (val == "is")
                                            val = "_Is";
                                        else if (val == "isnot")
                                            val = "_IsNot";
                                        else if (val == "true")
                                            val = "_TRUE";
                                        else if (val == "false")
                                            val = "_FALSE";

                                        else
                                        {
                                            // some need replication due to order
                                            string[] charsToRemove = new string[] { "/", "=", "'", "-", " ", ".", "%", ">", "<", ")", "(", "[", "]", "\"", ",", "=", "&" };

                                            foreach (var c in charsToRemove)
                                                val = val.Replace(c, string.Empty);

                                            // if var starts with a number
                                            if (char.IsDigit(val[0]))
                                                val = "_" + val;
                                        }

                                        if (!string.IsNullOrEmpty(val))
                                        {
                                            if (savedList.Contains(val)) // dup enum names
                                                val += "2";

                                            savedList.Add(val);

                                            output = output.Replace("\"", "\\\"");
                                            wr.WriteLine($"        public static readonly string {val} = \"{output}\";");
                                        }
                                    }
                                    wr.WriteLine("    }");
                                }
                            }

                            wr.WriteLine("}");
                        }

                        UpdateDisplay($"   Writing out DictionarV1");

                        if (v1Passed)
                        {
                            WriteDictionary(_fieldsV1, "DictionaryFieldsV1.txt");
                        }

                        UpdateDisplay($"   Writing out DictionarV3");

                        if (v3Passed)
                        {
                            WriteDictionary(_fieldsV3, "DictionaryFieldsV3.txt");
                        }

                        MessageBox.Show("Completed!");
                    }
                    else
                        MessageBox.Show("Unqble to acquire API Token");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                void WriteDictionary(Dictionary<string, APISchema> fields, string path)
                {
                    using (StreamWriter wr = new StreamWriter(OutputFolder.Text + "\\" + path))
                    {
                        foreach (var f in fields)
                        {
                            APISchema s = f.Value;

                            var leng = s.Key.Length - 2;

                            try
                            {
                                if (!s.Key.Contains("#"))
                                {
                                    var lastPart = "~" + s.Meta + "~" + s.ReadOnly.ToString() + "~" + s.Type + "~" +
                                                    s.Nullable.ToString() + "~" + s.Description + "~" + s.LockedField + "~" + s.ENum + "~" + s.Format;

                                    var output = s.Key + lastPart;

                                    var suffix = string.Empty;

                                    if (s.Key.StartsWith("AB0"))
                                    {
                                        if (s.Key.StartsWith("AB00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(AB)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("AEA0"))
                                    {
                                        if (s.Key.StartsWith("AEA00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(AEA)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("AR0"))
                                    {
                                        if (s.Key.StartsWith("AR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(AR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("BE0"))
                                    {
                                        if (s.Key.StartsWith("BE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(BE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("BCRED0"))
                                    {
                                        if (s.Key.StartsWith("BCRED00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(BCRED)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("BR0"))
                                    {
                                        if (s.Key.StartsWith("BR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(BR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("CCRED0"))
                                    {
                                        if (s.Key.StartsWith("CCRED00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(CCRED)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("CE0"))
                                    {
                                        if (s.Key.StartsWith("CE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(CE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("CORROI0"))
                                    {
                                        if (s.Key.StartsWith("CORROI00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(CORROI)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("CR0"))
                                    {
                                        if (s.Key.StartsWith("CR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(CR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("DISC0"))
                                    {
                                        if (s.Key.StartsWith("DISC00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(DISC)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("DD0"))
                                    {
                                        if (s.Key.StartsWith("DD00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(DD)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("DOCPROV0"))
                                    {
                                        if (s.Key.StartsWith("DOCPROV00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(DOCPROV)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("EC0"))
                                    {
                                        if (s.Key.StartsWith("EC00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(EC)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("FBE0"))
                                    {
                                        if (s.Key.StartsWith("FBE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(FBE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("FCE0"))
                                    {
                                        if (s.Key.StartsWith("FCE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(FCE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("FL0"))
                                    {
                                        if (s.Key.StartsWith("FL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(FL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("FM0"))
                                    {
                                        if (s.Key.StartsWith("FM00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(FM)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("HC0"))
                                    {
                                        if (s.Key.StartsWith("HC00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(HC)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("HHI0"))
                                    {
                                        if (s.Key.StartsWith("HHI00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(HHI)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("HTD0"))
                                    {
                                        if (s.Key.StartsWith("HTD00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(HTD)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("HTR0"))
                                    {
                                        if (s.Key.StartsWith("HTR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(HTR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("HUD0"))
                                    {
                                        if (s.Key.StartsWith("HUD00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(HUD)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("IR0"))
                                    {
                                        if (s.Key.StartsWith("IR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(IR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("INVESTORCONN0"))
                                    {
                                        if (s.Key.StartsWith("INVESTORCONN00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(INVESTORCONN)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("LP0"))
                                    {
                                        if (s.Key.StartsWith("LP00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(LP)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("NBOC0"))
                                    {
                                        if (s.Key.StartsWith("NBOC00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(NBOC)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("NYFEES0"))
                                    {
                                        if (s.Key.StartsWith("NYFEES00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(NYFEES)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("PVAL0"))
                                    {
                                        if (s.Key.StartsWith("PVAL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(PVAL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("RIDER0"))
                                    {
                                        if (s.Key.StartsWith("RIDER00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(RIDER)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("SCEN0"))
                                    {
                                        if (s.Key.StartsWith("SCEN00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(SCEN)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("SP0"))
                                    {
                                        if (s.Key.StartsWith("SP00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(SP)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TA0"))
                                    {
                                        if (s.Key.StartsWith("TA00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TA)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TQL4506T0"))
                                    {
                                        if (s.Key.StartsWith("TQL4506T00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TQL4506T)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TQLCOMPLIANCEALERT0"))
                                    {
                                        if (s.Key.StartsWith("TQLCOMPLIANCEALERT00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TQLCOMPLIANCEALERT)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TQLDOCDATE0"))
                                    {
                                        if (s.Key.StartsWith("TQLDOCDATE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TQLDOCDATE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TQLFRAUDALERT0"))
                                    {
                                        if (s.Key.StartsWith("TQLFRAUDALERT00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TQLFRAUDALERT)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TQLGSE0"))
                                    {
                                        if (s.Key.StartsWith("TQLGSE00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TQLGSE)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("TR0"))
                                    {
                                        if (s.Key.StartsWith("TR00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(TR)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("UNFL0"))
                                    {
                                        if (s.Key.StartsWith("UNFL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(UNFL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLABAKA0"))
                                    {
                                        if (s.Key.StartsWith("URLABAKA00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLABAKA)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLACAKA0"))
                                    {
                                        if (s.Key.StartsWith("URLACAKA00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLACAKA)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLARAL0"))
                                    {
                                        if (s.Key.StartsWith("URLARAL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLARAL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLARGG0"))
                                    {
                                        if (s.Key.StartsWith("URLARGG00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLARGG)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLAROA0"))
                                    {
                                        if (s.Key.StartsWith("URLAROA00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLAROA)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLAROIS0"))
                                    {
                                        if (s.Key.StartsWith("URLAROIS00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLAROIS)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("URLAROL0"))
                                    {
                                        if (s.Key.StartsWith("URLAROL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(URLAROL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("VAL0"))
                                    {
                                        if (s.Key.StartsWith("VAL00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(VAL)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else if (s.Key.StartsWith("XCOC0"))
                                    {
                                        if (s.Key.StartsWith("XCOC00"))
                                        {
                                            suffix = s.Key.Substring(leng);
                                            wr.WriteLine($@"^(XCOC)(\d{2})({suffix}$)" + lastPart);
                                        }
                                    }
                                    else
                                        wr.WriteLine(output);
                                }
                            }
                            catch
                            {
                                UpdateDisplay(s.Key);
                                UpdateDisplay(leng.ToString());
                                var x = 1;
                            }
                        }
                    }
                }

            }
        }

        private void UpdateDisplay(string name)
        {
            Output.AppendText($@"Working on ... {name}");
            Output.AppendText(Environment.NewLine);
            Output.Refresh();
        }
    }
}
