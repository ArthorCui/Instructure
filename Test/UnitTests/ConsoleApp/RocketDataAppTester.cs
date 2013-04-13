using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;
using Xunit;

namespace UnitTests.ConsoleApp
{
    public class RocketDataAppTester
    {
        [Fact]
        public void GetSaleaDataTest()
        {
            var count = 3686991;
            var s = 100000;
            Console.WriteLine(count/s);
        }

        [Fact]
        public void GetSaleDataTest()
        {
            RocketDataService service = new RocketDataService();
            service.GetSaleData();
        }

        [Fact]
        public void GetSaleDataByIdTest()
        {
            var id = 6702031;
            RocketDataService service = new RocketDataService();

            var ret = service.GetSaleData(id,20);
            Console.WriteLine(ret);
        }

    }
}
