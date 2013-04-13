using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;
using Xunit;

namespace UnitTests.Domain.Service
{
    public class ReportServiceTester
    {
        [Fact]
        public void DTTest()
        {
            ReportService reportService = new ReportService();
            var DTList = reportService.GetOTAInterfaceDTList();
            Console.WriteLine(DTList.Count);
        }

        [Fact]
        public void WriteTest()
        {
            ReportService reportService = new ReportService();
            reportService.Write();
        }

    }
}
