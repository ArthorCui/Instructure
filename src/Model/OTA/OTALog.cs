using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Base;
using SubSonic.SqlGeneration.Schema;

namespace Model.OTA
{
    [Serializable]
    [SubSonicTableNameOverride("OTALogs")]
    public class OTALog : MobileParam
    {
        public string Action { get; set; }
        public string Host { get; set; }
        public string StatusCode { get; set; }
        public string Port { get; set; }
        public string Date { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
