using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.OTA
{
    [Serializable]
    [SubSonicTableNameOverride("EveryDayUpgradeSuccess")]
    public class EveryDayUpgradeSuccess : EveryDayCheckupdate
    {
        public string Uver { get; set; }
        public string OTAResult { get; set; }
    }
}
