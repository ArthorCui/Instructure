using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Const;
using Model.Base;
using Model.OTA;
using SubSonic.Repository;

namespace Domain.Service
{
    public class OTAService
    {
        public IRepository Repository { get; set; }

        public OTAService()
        {
            this.Repository = new SimpleRepository(ConnectionStrings.Key_OTA_LOG_SUBSONIC_STRING, SimpleRepositoryOptions.None);
        }

        public List<OTALog> OTAStat(string path)
        {
            List<OTALog> ret = new List<OTALog>();

            string regexString = "(?<date>.*?)\\s+W3SVC1.*?\\s+/ota/(?<action>\\w+)\\s+(?<url>.*?)\\s(?<port>[\\w]+).*-\\s(?<host>\\w+.\\w+.\\w+)\\s(?<code>[\\w]+)";

            Regex regexGroup = new Regex(regexString);
            Match logMatch = RegexMatch(path, regexString, regexGroup);
            while (logMatch.Success)
            {
                var OTALog = new OTALog();
                var mobileParam = new MobileParam();

                Group group = logMatch.Groups[0];

                var match = regexGroup.Match(group.Value);

                #region Param Match

                OTALog.Date = match.Groups["date"].Value;
                OTALog.Action = match.Groups["action"].Value;
                OTALog.Port = match.Groups["port"].Value;
                OTALog.Host = match.Groups["host"].Value;
                OTALog.StatusCode = match.Groups["code"].Value;
                OTALog.CreateTime = DateTime.Now;

                string url = match.Groups["url"].Value;
                if (!string.IsNullOrEmpty(url) && url.Length >5)
                {
                    mobileParam = MobileParamMatch(url);

                    OTALog.IMSI = mobileParam.IMSI;
                    OTALog.IMEI = mobileParam.IMEI;
                    OTALog.Batch = mobileParam.Batch;
                    OTALog.Pver = mobileParam.Pver;
                    OTALog.OTAResult = mobileParam.OTAResult;
                    OTALog.Uver = mobileParam.Uver;
                    if (OTALog.IMSI != null)
                    {
                        Repository.Add<OTALog>(OTALog);
                        ret.Add(OTALog);
                    }
                }

                #endregion

                logMatch = logMatch.NextMatch();
            }

            return ret;
        }

        public List<IISLog> IISLogStat(string path)
        {
            List<IISLog> ret = new List<IISLog>();
            string regexString = "(?<date>.*?)\\s+W3SVC1.*?\\s+/ota/(?<action>\\w+)\\s+batch=(?<batch>\\w+)&pver=(?<pver>[^&]+).*?imsi=(?<imsi>[\\w]+).*?imei=(?<imei>[\\w]+).*?- - -\\s(?<host>\\w+.\\w+.\\w+)\\s(?<code>[\\w]+)";
            Regex regexGroup = new Regex(regexString);
            Match logMatch = RegexMatch(path, regexString, regexGroup);
            while (logMatch.Success)
            {
                Group group = logMatch.Groups[0];
                var m = regexGroup.Match(group.Value);

                var IIS_Log = new IISLog();

                IIS_Log.Date = m.Groups["date"].Value;
                IIS_Log.Action = m.Groups["action"].Value;
                IIS_Log.Batch = m.Groups["batch"].Value;
                IIS_Log.Pver = m.Groups["pver"].Value;
                IIS_Log.IMSI = m.Groups["imsi"].Value;
                IIS_Log.IMEI = m.Groups["imei"].Value;
                IIS_Log.Host = m.Groups["host"].Value;
                IIS_Log.StatusCode = m.Groups["code"].Value;
                Repository.Add<IISLog>(IIS_Log);
                ret.Add(IIS_Log);
                logMatch = logMatch.NextMatch();

            }
            return ret;
        }

        internal MobileParam MobileParamMatch(string url)
        {
            MobileParam mobileParam = new MobileParam();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            //To do encode url
            if (!url.StartsWith("batch"))
            {
                return mobileParam;
            }

            var array = url.Split('&');
            foreach (var item in array)
            {
                var splitParam = item.Split('=');
                dic.Add(splitParam[0], splitParam[1]);
            }
            mobileParam.Batch = GetValueByKey(dic, "batch");
            mobileParam.Pver = GetValueByKey(dic, "pver");
            mobileParam.IMSI = GetValueByKey(dic, "imsi");
            mobileParam.IMEI = GetValueByKey(dic, "imei");
            //mobileParam.Lbyver = GetValueByKey(dic, "lbyver");
            //mobileParam.Os = GetValueByKey(dic, "os");
            //mobileParam.Nt = GetValueByKey(dic, "nt");
            mobileParam.Uver = GetValueByKey(dic, "uver");
            mobileParam.OTAResult= GetValueByKey(dic, "otaResult");

            return mobileParam;
        }

        private string GetValueByKey(Dictionary<string, string> dic, string keyName)
        {
            string keyValue = string.Empty;
            if (dic.ContainsKey(keyName))
            {
                dic.TryGetValue(keyName, out keyValue);
                return keyValue;
            }
            return string.Empty;
        }

        private Match RegexMatch(string path, string regexString, Regex regexGroup)
        {
            var logStr = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                logStr = sr.ReadToEnd().ToString();
            }
            
            return regexGroup.Match(logStr);
        }

        /*
         (?<date>.*?)\s+W3SVC1.*?\s+/ota/(?<action>\w+)\s+batch=(?<batch>\w+)&pver=(?<pver>[^&]+).*?imsi=(?<imsi>[\w]+).*?imei=(?<imei>[\w]+).*?otaResult=(?<otaResult>[\w]+).*?&uver=(?<uver>[^&]+)\s+80.*- - -\s(?<host>\w+.\w+.\w+)\s(?<code>[\w]+)
         */

        /*
         (?<date>.*?)\s+W3SVC1.*?\s+/ota/(?<action>\w+)\s+(?<url>.*?)\s(?<port>[\w]+).*- - -\s(?<host>\w+.\w+.\w+)\s(?<code>[\w]+)
         */
    }
}
