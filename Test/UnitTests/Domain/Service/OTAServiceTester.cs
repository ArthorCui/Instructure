using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;
using Model.Base;
using Model.OTA;
using SubSonic.SqlGeneration.Schema;
using Xunit;

namespace UnitTests.Domain.Service
{
    public class OTAServiceTester
    {
        [Fact]
        public void OTAStatTest()
        {
            OTAService service = new OTAService();
            var path = @"E:\\IISLogFiles\OTA\\u_ex130204.log";
            List<IISLog> ret = service.IISLogStat(path);

            Console.WriteLine(ret.Count);
        }

        [Fact]
        public void DateTimeTest()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var date1 = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine(date);
            Console.WriteLine(date1);
            Console.WriteLine(DateTime.Today);
            var date2 = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
            var yesterDay = date2.Substring(2, date2.Length - 2);
            Console.WriteLine(date2);
            Console.WriteLine(yesterDay);
        }

        [Fact]
        public void MobileParamMatchTest()
        {
            OTAService service = new OTAService();
            var mobileParam = new MobileParam();
            var url = "batch=koobee_i50_zh_null&pver=i50.KB.V9.02&os=Android&nt=wifi&lbyver=2.3.6&imsi=0000&imei=864471010000097&otaResult=0&uver=i50.KB.V9.01";
            var ret = service.MobileParamMatch(url);
            Console.WriteLine(ret.Batch);
            var urlInComplete = "batch=koobee_i50_zh_null&pver=i50.KB.V9.02&os=Android&nt=wifi&lbyver=2.3.6&imsi=0000&imei=864471010000097&otaResult=0";
            var ret2 = service.MobileParamMatch(urlInComplete);
            Console.WriteLine(ret2.Uver);
        }

        [Fact]
        public void OTALogStatTest()
        {
            OTAService service = new OTAService();

            var array = new List<string>();
            array.Add("0218");
            for (int i = 0; i < array.Count; i++)
            {
                var path = string.Format("E:\\IISLogFiles\\OTA\\u_ex13{0}.log",array[i]);
                List<OTALog> ret = service.OTAStat(path);
                Console.WriteLine(ret.Count);
            }
        }
    }
}
