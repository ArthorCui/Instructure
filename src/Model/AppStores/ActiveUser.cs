using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Oracle.SqlGeneration.Schema;
using TYD.Logging.Models;

namespace Model.AppStores
{
    [Serializable]
    [DailyPartitionSetting("CREATE_TIME", "PT_", "TYDACTIVE_")]
    [SubSonicTableNameOverride("ACTIVE_USER")]
    public class ActiveUser : CommunicationLog
    {
        [SubSonicColumnNameOverride("TIMES")]
        public int Times { get; set; }
    }
}
