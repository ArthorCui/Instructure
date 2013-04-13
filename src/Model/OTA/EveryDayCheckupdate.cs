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
    [SubSonicTableNameOverride("EveryDayCheckupdate")]
    public class EveryDayCheckupdate : EntityBase<EveryDayCheckupdate>
    {
        public string Batch { get; set; }
        public string Pver { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }
    }
}
