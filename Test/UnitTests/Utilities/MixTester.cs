using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.OTA;
using Xunit;

namespace UnitTests.Utilities
{
    public class MixTester
    {
        public string SPLIT = ("\x00").ToString();

        [Fact]
        public void CommunicationLogRebuildStringTest()
        {
            CommunicationLog log = new CommunicationLog 
            {
                SoftwareVersion = "i55.KB.V2.03",
                IMEI = "865771010248631",
                IMSI = "460022308243966",
                SMSCode="",
            };
        }
        /*
         * i55.KB.V2.03 865771010248631 460022308243966  koobee_i55_zh_null    4.0.4          Android  2g          itest.kk570.com  OTA checkupdate 11010 0    a9110a5c-8fd5-45e2-a951-bf99222a05be 2013-56-11 0324:56i:21    192.168.3.53 343039101 2013-56-11 /ota/checkupdate?batch=koobee_i55_zh_null&pver=i55.KB.V2.03&os=Android&nt=2g&lbyver=4.0.4&imsi=460022308243966&imei=865771010248631
         */
        private string CommunicationLogRebuildString(CommunicationLog log)
        {
            StringBuilder sb = new StringBuilder();
            string lineData = string.Empty;

            sb.Append(log.SoftwareVersion + SPLIT + log.IMEI + SPLIT + log.IMSI + SPLIT + log.SMSCode + SPLIT + log.Batch + SPLIT);
            sb.Append(log.DesignHouse + SPLIT + log.Manufacturer + SPLIT + log.FirmwareMode + SPLIT + log.LobbyVersion + SPLIT);
            sb.Append(log.DateOfProduction + SPLIT + log.Resolution + SPLIT + log.MCode + SPLIT + log.SIMNo + SPLIT);
            sb.Append(log.HasTCard.ToString() + SPLIT + log.IsTouch.ToString() + SPLIT + log.HasKeyboard.ToString() + SPLIT);
            sb.Append(log.HasGravity.ToString() + SPLIT + log.HasCapacitive.ToString() + SPLIT);
            sb.Append(log.OS + SPLIT + log.PhoneType + SPLIT + log.NetworkType + SPLIT + log.JavaInfo + SPLIT + log.CInfo + SPLIT);
            sb.Append(log.LuaInfo + SPLIT + log.LBS + SPLIT + log.BillingConfigVersion + SPLIT + log.ClientReleaseVersion + SPLIT);
            sb.Append(log.AppVersion + SPLIT + log.FromAppNo + SPLIT + log.ProductCode + SPLIT + log.Host + SPLIT + log.RequestBody + SPLIT);
            sb.Append(log.ControllerName + SPLIT + log.ActionName + SPLIT + log.ActionId.ToString() + SPLIT + log.ResultCode.ToString() + SPLIT);
            sb.Append(log.ProvinceId.ToString() + SPLIT + log.CityId.ToString() + SPLIT + log.DaysOld.ToString() + SPLIT + log.Id + SPLIT);
            sb.Append(log.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss") + SPLIT + log.Encoding + SPLIT + log.RAM + SPLIT + log.ROM + SPLIT + log.IPAddress + SPLIT);
            sb.Append(log.ChildID.ToString() + SPLIT + log.CreateDateTime.ToString("yyyy-MM-dd") + SPLIT + log.Url);

            return sb.ToString();
        }
    }
}
