using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Oracle.SqlGeneration.Schema;
using TYD.Logging.Models;

namespace Model.AppStores
{
    [Serializable]
    [SubSonicTableNameOverride("SECONDARY_ACTIVE_USER")]
    public class SecondaryActiveUser : PartitionedBase
    {
        [SubSonicColumnNameOverride("USER_ID")]
        public long UserId { get; set; }

        [SubSonicNullString]
        [SubSonicStringLength(32)]
        [SubSonicColumnNameOverride("IMEI")]
        public string IMEI { get; set; }

        [SubSonicNullString]
        [SubSonicStringLength(32)]
        [SubSonicColumnNameOverride("IMSI")]
        public string IMSI { get; set; }

        /// <summary>
        /// pf 渠道
        /// </summary>
        [SubSonicColumnNameOverride("CHANNEL_ID")]
        public long ChannelId { get; set; }
    }
}
