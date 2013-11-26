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

        public DigCommunicationLog()
        {

        }

        public DigCommunicationLog(CommunicationLog commu)
        {
            this.ActionId = commu.ActionId;
            this.AndroidVersionId = commu.AndroidVersionId;
            this.AppVersionId = commu.AppVersionId;
            this.BatchId = commu.BatchId;
            this.BrandModelId = commu.BrandModelId;
            this.ChannelId = commu.ChannelId;
            this.CityId = commu.CityId;
            this.CreateDateTime = commu.CreateDateTime;
            this.DesignHouseId = commu.DesignHouseId;
            this.DistrictInfo = commu.DistrictInfo;
            this.DomainNameId = commu.DomainNameId;
            this.FromAppId = commu.FromAppId;
            this.IMEI = commu.IMEI;
            this.IMSI = commu.IMSI;
            this.IPAddress = commu.IPAddress;
            this.LBS = commu.LBS;
            this.MachineTypeId = commu.MachineTypeId;
            this.NetworkTypeId = commu.NetworkTypeId;
            this.ProvinceId = commu.ProvinceId;
            this.RequestBody = commu.RequestBody;

        }

    }
}
