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

namespace OTALogService
{
    public partial class OTALogService : ServiceBase
    {
        public OTALogService()
        {
            InitializeComponent();
        }

        public void JobStart(DateTime logDate)
        {
            Console.WriteLine("OTA Log Service start ... ");
            var pathPrefix = AppConfigKeys.LOG_SERVICE_IIS_LOG_FILES_PATH.ConfigValue();

            OTAService service = new OTAService();
            var daysAgo = AppConfigKeys.OTA_FILE_DAYS_AGO.ConfigValue().ToInt32();
            var date = logDate.AddDays(daysAgo).ToString("yyyyMMdd");
            var yesterDay = date.Substring(2, date.Length - 2);
            var path = string.Format("{0}u_ex{1}.log", pathPrefix, yesterDay);
            List<OTALog> ret = service.OTAStat(path);
            Console.WriteLine(yesterDay + "iis for OTA interface visit count: " + ret.Count);
        }

        protected override void OnStart(string[] args)
        {
            JobStart(DateTime.Now);
        }

    }
}
