using ICE.SDKtoAPI;
using ICE.SDKtoAPI.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class GenerateV3ClassesWIN : Form
    {
        const string GETSET = "{ get; set; }";

        protected List<ElieConnections> _connetions = new List<ElieConnections>();
        public static ElieConnections _con;
        protected LenderAPI _api;

        public GenerateV3ClassesWIN()
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

                    // use QA to get schema
                    _con = _connetions.Where(t => t.Name == MainWindow.defaultEnvironment).FirstOrDefault();

                    _api = new LenderAPI(_con.ApiInstance, _con.ApiClientId, _con.ApiUser, _con.ApiPassword, _con.ApiSecret);

                    await Task.Run(() => _api.GetTokenAsync());

                    if (_api.Token != null)  // (loan.HasAccessToken)
                    {
                        V3LoanSchema schema = Task.Run(() => _api.GetV3LoanSchemaAsync()).Result;

                        dynamic items = schema.Definitions;
                        dynamic properties = schema.Properties;

                        foreach (dynamic item in items)
                        {
                            var className = item.Name;
                            using (StreamWriter wr = new StreamWriter(OutputFolder.Text + "\\" + className + ".cs"))
                            {
                                ClassHeader(wr, Namespace.Text, className);

                                UpdateDisplay(className);

                                #region properties
                                var world = JsonConvert.SerializeObject(item.Value);
                                world = world.Replace("$ref", "reference");
                                JToken props = (JToken)JsonConvert.DeserializeObject(world);

                                var i = props.Children();

                                foreach (JProperty classAttribute in i)
                                {
                                    if (classAttribute.Name == "properties")
                                    {
                                        try
                                        {
                                            foreach (var property in classAttribute.Value)
                                            {
                                                var newprop = property as JProperty;
                                                PropStruc tt = newprop.Value.ToObject<PropStruc>();

                                                wr.WriteLine($"        [DataMember(Name = \"{newprop.Name}\")]");

                                                if (tt.Type != null)
                                                {
                                                    var theType = tt.Type.ToString().ToUpper();

                                                    if (!theType.Contains("[") && !theType.Contains("]"))  /// array of type
                                                    {
                                                        switch (theType)
                                                        {
                                                            case "STRING":
                                                                wr.WriteLine($"        public string {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "NUMBER":
                                                                wr.WriteLine($"        public decimal {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "BOOLEAN":
                                                                wr.WriteLine($"        public bool {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "INTEGER":
                                                                wr.WriteLine($"        public int {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            default:
                                                                wr.WriteLine($"        public object {ToUL(newprop.Name)} {GETSET}");
                                                                break;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        JArray toCast = tt.Type as JArray;
                                                        theType = toCast[0].ToString().ToUpper();
                                                        var nullable = (toCast[1].ToString().Contains("null") ? "?" : "");
                                                        switch (theType)
                                                        {
                                                            case "STRING":
                                                                wr.WriteLine($"        public string {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "NUMBER":
                                                                wr.WriteLine($"        public decimal{nullable} {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "BOOLEAN":
                                                                wr.WriteLine($"        public bool{nullable} {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "INTEGER":
                                                                wr.WriteLine($"        public int{nullable} {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "OBJECT":
                                                                wr.WriteLine($"        public object {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                            case "ARRAY":
                                                                if (!string.IsNullOrEmpty(tt.ClassRefs.Reference))
                                                                {
                                                                    var getClass = GetClassNameFromRef(tt.ClassRefs.Reference);
                                                                    wr.WriteLine($"        public List<{ToUL(getClass)}> {ToUL(newprop.Name)} {GETSET}");
                                                                }
                                                                else
                                                                {
                                                                    wr.WriteLine($"        public List<object> {ToUL(newprop.Name)} {GETSET}");
                                                                }
                                                                break;
                                                            default:
                                                                wr.WriteLine($"        public object {ToUL(newprop.Name)} {GETSET}");
                                                                break;
                                                        }
                                                    }
                                                }
                                                else  // there is a reference
                                                {
                                                    wr.WriteLine($"        public string {ToUL(newprop.Name)} {GETSET}");
                                                }
                                                wr.WriteLine();
                                            }
                                        }
                                        catch (Exception exp)
                                        {
                                            System.Diagnostics.Debug.WriteLine(exp.Message);
                                        }
                                    }
                                }

                                #endregion

                                ClassFooter(wr);

                            }
                        }

                        #region LOAN CONTRACT
                        using (StreamWriter wr = new StreamWriter(OutputFolder.Text + "\\LoanContract.cs"))
                        {
                            UpdateDisplay("LoanContract");
                            ClassHeader(wr, Namespace.Text, "LoanContract");
                            var loanStr = JsonConvert.SerializeObject(properties);
                            loanStr = loanStr.Replace("$ref", "reference");
                            JToken loanProps = (JToken)JsonConvert.DeserializeObject(loanStr);
                            foreach (JProperty loanAttribute in loanProps.Children())
                            {
                                var newprop = loanAttribute as JProperty;
                                PropStruc tt = newprop.Value.ToObject<PropStruc>();
                                wr.WriteLine($"        [DataMember(Name = \"{newprop.Name}\")]");

                                if (tt.Type != null)
                                {
                                    JArray toCast = tt.Type as JArray;
                                    var theType = toCast[0].ToString().ToUpper();
                                    var nullable = (toCast[1].ToString().Contains("null") ? "?" : "");

                                    switch (theType)
                                    {
                                        case "STRING":
                                            wr.WriteLine($"        public string {ToUL(newprop.Name)} {GETSET}");
                                            break;
                                        case "NUMBER":
                                            wr.WriteLine($"        public decimal{nullable} {ToUL(newprop.Name)}  {GETSET}");
                                            break;
                                        case "ARRAY":
                                            if (!string.IsNullOrEmpty(tt.ClassRefs.Reference))
                                            {
                                                var getClass = GetClassNameFromRef(tt.ClassRefs.Reference);
                                                wr.WriteLine($"        public List<{ToUL(getClass)}> {ToUL(newprop.Name)} {GETSET}");
                                            }
                                            else
                                            {
                                                wr.WriteLine($"        public List<object> {ToUL(newprop.Name)} {GETSET}");
                                            }
                                            break;

                                        case "BOOLEAN":
                                            wr.WriteLine($"        public bool{nullable} {ToUL(newprop.Name)} {GETSET}");
                                            break;
                                        case "INTEGER":
                                            wr.WriteLine($"        public int{nullable} {ToUL(newprop.Name)}  {GETSET}");
                                            break;
                                        case "OBJECT":
                                            wr.WriteLine($"        public object {ToUL(newprop.Name)} {GETSET}");
                                            break;
                                    }
                                }
                                else
                                {
                                    if (tt.Type == null && tt.ClassRefs == null)
                                    {
                                        var getRef = GetClassName(newprop.Value);
                                        var getClass = GetClassNameFromRef(getRef.Item2);

                                        wr.WriteLine($"        public {ToUL(getClass)} {ToUL(newprop.Name)} {GETSET}");
                                    }
                                }
                                wr.WriteLine("");

                            }
                            ClassFooter(wr);
                        }
                        #endregion

                        MessageBox.Show("Completed!");
                    }
                    else
                        MessageBox.Show("Unqble to acquire API Token");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        static string ToUL(string item) => item.Substring(0, 1).ToUpper() + item.Substring(1);

        private void UpdateDisplay(string name)
        {
            Output.AppendText($@"Working on ... {name}");
            Output.AppendText(Environment.NewLine);
            Output.Refresh();
        }
        static void ClassHeader(StreamWriter wr, string ns, string name)
        {
            Console.WriteLine($"Working on class: {name}");

            wr.WriteLine("using System.Collections.Generic;");
            wr.WriteLine("using System.Runtime.Serialization;");
            wr.WriteLine("");
            wr.WriteLine($"namespace {ns}");
            wr.WriteLine("{");
            wr.WriteLine("    [DataContract]");
            wr.WriteLine($"    public class {name}");
            wr.WriteLine("    {");
        }
        static void ClassFooter(StreamWriter wr)
        {
            wr.WriteLine("    }");
            wr.WriteLine("}");
        }

        private static Tuple<string, string> GetClassName(JToken item)
        {
            var s = JsonConvert.SerializeObject(item);
            // Get name of class
            var ndx = s.IndexOf(":");
            var className = s.Substring(0, ndx).Replace("{", "").Trim().Replace("\"", "");
            var rest = s.Substring(ndx + 1).Trim();

            return new Tuple<string, string>(className, rest);
        }
        static string GetClassNameFromRef(string theRef)
        {
            var items = theRef.Split('/');
            var theOne = items[items.Length - 1];
            theOne = theOne.Replace("}", "").Replace("\"", "");
            return theOne;
        }

        private void GenerateV3ClassesWIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_api != null)
                _api.Dispose();
        }
    }

    [DataContract]
    public class PropStruc
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "type")]
        public object Type { get; set; }

        [DataMember(Name = "enum")]
        public object Enum { get; set; }

        [DataMember(Name = "additionalProperties")]
        public object AdditionalProperties { get; set; }

        [DataMember(Name = "maxLength")]
        public int MaxLength { get; set; } = 0;

        [DataMember(Name = "format")]
        public string Format { get; set; } = "";

        [DataMember(Name = "items")]
        public PropAdditional ClassRefs { get; set; }
    }
    public class PropAdditional
    {
        [DataMember(Name = "reference")]
        public string Reference { get; set; } = "";

        [DataMember(Name = "type")]
        public object Type { get; set; }
    }
}
