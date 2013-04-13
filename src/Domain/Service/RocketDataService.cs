using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Const;
using Domain.Interface;
using Model.MobileSale;
using SubSonic.Repository;
using NCore;

namespace Domain.Service
{
    public class RocketDataService : IRocketDataService
    {
        public IRepository Repository { get; set; }

        public RocketDataService()
        {
            this.Repository = new SimpleRepository(ConnectionStrings.Key_MOBILE_SALE_STAT_MAIN_STRING, SimpleRepositoryOptions.None);
        }

        public string GetSaleData(string startDate, string endDate)
        {
            return string.Empty;
        }

        public string GetSaleData(int id, int count)
        {
            StringBuilder sb = new StringBuilder();
            var startId = id;
            var endId = id + count;
            var saleList = this.Repository.Find<State>(x => x.Id > startId && x.Id <= endId && x.Status == 1).ToList();
            sb.Append(RocketDataConfigKeys.SALE_SQL_PREFIX.ConfigValue());
            for (int i = 0; i < saleList.Count; i++)
            {
                if (saleList[i].PhoneNumber == "" && saleList[i].ProvinceId != 0 && saleList[i].CityId != 0)
                {
                    saleList[i].PhoneNumber = RegexHttpUrl(saleList[i].HttpUrl);
                }
                sb.Append(GetLongCode(saleList[i]));
            }
            var retData = sb.ToString().TrimEnd('\n').TrimEnd(',');
            retData = retData.Insert(retData.Length, ";");
            return retData;

        }

        public void GetSaleData()
        {
            var sum = RocketDataConfigKeys.SALE_SUM.ConfigValue().ToInt32();
            var dataSpace = RocketDataConfigKeys.SALE_DATA_SPACE.ConfigValue().ToInt32();
            int loopCount = sum / dataSpace;
            for (int p = 0; p <= loopCount; p++)
            {
                int startId = p * dataSpace;
                int endId = (p + 1) * dataSpace;
                var stateList = Repository.Find<StateTemp>(x => x.T_Id > startId && x.T_Id <= endId).ToList();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < stateList.Count; i++)
                {
                    if (stateList[i].PhoneNumber == "" && stateList[i].ProvinceId != 0 && stateList[i].CityId != 0)
                    {
                        stateList[i].PhoneNumber = RegexHttpUrl(stateList[i].HttpUrl);
                    }
                    if (stateList[i].IMSI.ToLower() == "null")
                    {
                        stateList[i].IMSI = "";
                    }
                    if (stateList[i].IMEI.ToLower() == "null")
                    {
                        stateList[i].IMEI = "";
                    }
                    if (stateList[i].Model.ToLower() == "null")
                    {
                        stateList[i].Model = "";
                    }
                    sb.Append(GetLongCode(stateList[i]));
                }
                var writeData = sb.ToString();

                //writeData = writeData.TrimEnd('\n').TrimEnd(',');
                //writeData = writeData.Insert(writeData.Length, ";");
                var filePath = RocketDataConfigKeys.SALE_FILE_PATH.ConfigValue();
                var radomDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filename = string.Format("{0}saleData_{1}.txt", filePath, radomDate);
                FileInfo file = new FileInfo(filename);

                using (StreamWriter sw = new StreamWriter(file.AppendText().BaseStream, Encoding.UTF8))
                {
                    //sw.Write(writeData);
                }
            }
        }

        private string RegexHttpUrl(string httpUrl)
        {
            Regex reg = new Regex(".*&smsc=(?<smsc>\\w+)");
            Match match = reg.Match(httpUrl);
            if (match.Success)
            {
                return match.Groups["smsc"].Value;
            }
            return string.Empty;
        }

        private string GetLongCode<T>(T state)
            where T: State
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'),\n", state.Id, state.PhoneNumber, state.IMEI, state.IMSI, state.Model, state.Date.ToString("yyyy-MM-dd HH:mm:ss"), state.Address, state.ModelCode, state.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return sb.ToString();
        }
    }
}
