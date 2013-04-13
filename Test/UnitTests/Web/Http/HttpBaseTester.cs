using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Http;
using Xunit;

namespace UnitTests.Web.Http
{
    public class HttpBaseTester
    {
        [Fact]
        public void GetResponseTest()
        {
            //string url = "http://itest.kk570.com/ota/checkupdate";
            //string method = "POST";
            //string postData = "batch=koobee_i55_zh_null&pver=i55.KB.V2.03&os=Android&nt=2g&lbyver=4.0.4&imsi=460022308243966&imei=865771010248631";
            //HttpBase instance = new HttpBase(url, method, postData);
            //var ret = instance.GetResponse();
            //Console.WriteLine(ret);

            string url2 = "http://itest.kk570.com/ota/checkupdate?batch=koobee_i55_zh_null&pver=i55.KB.V2.03&os=Android&nt=2g&lbyver=4.0.4&imsi=460022308243966&imei=865771010248631";
            
            DateTime start = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                HttpBase instance2 = new HttpBase(url2);
                var ret2 = instance2.GetResponse();
            }
            DateTime end = DateTime.Now;

            Console.WriteLine(end-start);
        }
    }
}
