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
    [SubSonicTableNameOverride("IIS_Logs")]
    public class IISLog : EntityBase<IISLog>
    {
        public string Action { get; set; }
        public string Host { get; set; }
        public string StatusCode { get; set; }
        public string Batch { get; set; }
        public string Pver { get; set; }
        public string IMSI { get; set; }
        public string IMEI { get; set; }
        public string Date { get; set; }

    }
}
