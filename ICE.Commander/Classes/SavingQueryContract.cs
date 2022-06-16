using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Commander
{
    public class SavingQueryContract
    {
        public List<OutputFieldsContract> OutputFields { get; set; }
        public List<ContractContract> Contract { get; set; }
        public List<TermContract> Terms { get; set; }
        public List<SortOrderContract> Order { get; set; }

        public SavingQueryContract()
        {
            OutputFields = new List<OutputFieldsContract>();
            Contract = new List<ContractContract>();
            Terms = new List<TermContract>();
            Order = new List<SortOrderContract>();
        }
    }

    public class OutputFieldsContract
    {
        public string FieldName { get; set; }
    }
    public class SortOrderContract
    {
        public string FieldName { get; set; }
    }
    public class ContractContract
    {
        public string Name { get; set; }
    }
    public class TermContract
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Term1 { get; set; } = "";
        public string Term2 { get; set; } = "";
        public string FieldId { get; set; }
        public string Value { get; set; }
        public string MatchType { get; set; }
        public string OrdinalMatchType { get; set; }
        public string DateCriteria { get; set; }
        public string DateMatchPrecision { get; set; }
        public string Include { get; set; }
        public string NumericValue { get; set; }
    }

}
