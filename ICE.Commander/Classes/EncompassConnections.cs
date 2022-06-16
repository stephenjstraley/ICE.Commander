using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Commander
{
    public class EncompassConnections
    {
        public static List<ElieConnections> GetConnections(bool withProd = false)
        {
            var connetions = new List<ElieConnections>();

            connetions.Add(new ElieConnections()
            {
                Name = "test",
                ApiClientId = "",
                ApiInstance = "",
                ApiPassword = "",
                ApiSecret = "",
                ApiUser = "",
                sdkPath = "",
                sdkUser = "",
                sdkPassword = ""
            });

            return connetions;

        }
    }
}
