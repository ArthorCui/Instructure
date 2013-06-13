using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;
using Xunit;

namespace UnitTests.Domain.Service
{
    public class CodeAlgorithmTester
    {
        [Fact]
        public void GetShortUrlTest()
        {
            CodeAlgorithm service = new CodeAlgorithm();
            var url = "http://apk.oo523.com/appstores/apkdownload?imsi=0000&pkgname=com.zhuoyi.market&os=android";
            var ret = service.GetShortUrl(url);
            Console.WriteLine(ret);
        }
    }
}
