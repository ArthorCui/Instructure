using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.OTA
{
    public class CommunicationLog
    {
        private string defaultId = Guid.NewGuid().ToString();
        public virtual string Id
        {
            get
            {
                return defaultId;
            }
            set
            {
                defaultId = value;
            }
        }

        private DateTime createDateTime = DateTime.Now;
        public virtual DateTime CreateDateTime
        {
            get
            {
                return createDateTime;
            }
            set
            {
                createDateTime = value;
            }
        }

        public string SoftwareVersion { get; set; }
        public string IMEI { get; set; }
        public string IMSI { get; set; }
        public string SMSCode { get; set; }
        public string Batch { get; set; }
        public string DesignHouse { get; set; }
        public string Manufacturer { get; set; }
        public string BrandModel { get; set; }
        public string FirmwareMode { get; set; }
        public string LobbyVersion { get; set; }
        public string DateOfProduction { get; set; }
        public string Resolution { get; set; }
        public string MCode { get; set; }
        public string SIMNo { get; set; }
        public bool? HasTCard { get; set; }
        public bool? IsTouch { get; set; }
        public bool? HasKeyboard { get; set; }
        public bool? HasGravity { get; set; }
        public bool? HasCapacitive { get; set; }
        public string OS { get; set; }
        public string PhoneType { get; set; }
        public string NetworkType { get; set; }
        public string JavaInfo { get; set; }
        public string CInfo { get; set; }
        public string LuaInfo { get; set; }
        public string LBS { get; set; }
        public string BillingConfigVersion { get; set; }
        public string ClientReleaseVersion { get; set; }
        public string AppVersion { get; set; }
        public string FromAppNo { get; set; }
        public string ProductCode { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? ActionId { get; set; }
        public int? ResultCode { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? DaysOld { get; set; }
        public string Encoding { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string IPAddress { get; set; }
        public long? ChildID { get; set; }
    }
}
