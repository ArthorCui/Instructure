using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Oracle.SqlGeneration.Schema;
using TYD.Logging.Models;

namespace Model.AppStores
{
    [Serializable]
    [DailyPartitionSetting("CREATE_TIME", "PT_", "DIGCOMMU_")]
    [SubSonicTableNameOverride("DIG_COMMUNICATION_LOG")]
    public class DigCommunicationLog : CommunicationLog
    {
        [SubSonicColumnNameOverride("TIMES")]
        public int Times { get; set; }

        [SubSonicColumnNameOverride("YEAR")]
        public int Year { get; set; }

        [SubSonicColumnNameOverride("MONTH")]
        public int Month { get; set; }

        [SubSonicColumnNameOverride("DAY")]
        public int Day { get; set; }

    }
}
