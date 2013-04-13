using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.OTA
{
    [Serializable]
    [SubSonicTableNameOverride("EveryDayUpgradeFailed")]
    public class EveryDayUpgradeFailed : EveryDayCheckupdate
    {
        public string OTAResult { get; set; }
    }
}
