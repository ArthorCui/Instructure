using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Const;
using SubSonic.Repository;
using NCore;

namespace OTALogService
{
    public class LoggerRepositoryBase
    {
        protected SimpleRepository sqlRepo = new SimpleRepository(ConnectionStrings.Key_OTA_LOG_SUBSONIC_STRING, SimpleRepositoryOptions.None);

        private static string _LogModelType;
        public static string LogModelType
        {
            get
            {
                _LogModelType = AppConfigKeys.LOG_SERVICE_PROCESS_MODEL_TYPE.ConfigValue();
                return _LogModelType;
            }
        }

        private static int _ProcessCount;
        public static int ProcessCount
        {
            get
            {
                _ProcessCount = AppConfigKeys.LOG_SERVICE_PROCESS_COUNT.ConfigValue().ToInt32();
                return _ProcessCount;
            }
        }
    }
}
