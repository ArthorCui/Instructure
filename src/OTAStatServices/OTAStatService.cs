using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Common.Const;
using Domain.Service;
using Model.OTA;
using NCore;

namespace OTAStatService
{
    public partial class OTAStatService : ServiceBase
    {
        public OTAStatService()
        {
            InitializeComponent();
        }

        public void JobStart(DateTime logDate)
        {
            Console.WriteLine("OTA Stat Service start ... ");

            ReportService service = new ReportService();
            service.Write();
        }

        protected override void OnStart(string[] args)
        {
            JobStart(DateTime.Now);
        }

    }
}
