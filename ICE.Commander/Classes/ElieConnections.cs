using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Commander
{
    public class ElieConnections
    {
        public string ApiBaseUrl { get; set; }
        public string ApiClientId { get; set; }
        public string ApiHost { get; set; }
        public string ApiIdpHost { get; set; }
        public string ApiInstance { get; set; }
        public string ApiPassword { get; set; }
        public string ApiSecret { get; set; }
        public string ApiUser { get; set; }
        public string Name { get; set; }
        public string sdkPath { get; set; }
        public string sdkUser { get; set; }
        public string sdkPassword { get; set; }
        public bool noSDK { get; set; } = false;
        public string licenseKey { get; set; }
    }
}
