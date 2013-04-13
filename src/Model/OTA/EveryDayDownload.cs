using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace Model.OTA
{
    [Serializable]
    [SubSonicTableNameOverride("EveryDayDownload")]
    public class EveryDayDownload :EveryDayCheckupdate
    {
        
    }
}
