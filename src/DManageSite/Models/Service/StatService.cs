using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using DManageSite.Models.Entry;
using DManageSite.Models.Service.Interface;
using SubSonic.Repository;
using NCore;

namespace DManageSite.Models.Service
{
    public class StatService : IStatService
    {
        public IRepository Repository { get; set; }

        public StatService()
        {
            this.Repository = new SimpleRepository(AppConfigKeys.SALE_SQL_CONNECT_STRING, SimpleRepositoryOptions.None);
        }

        public string GetSaleData(int id, int count)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(id.ToString())) id = 0;

                var startId = id;
                var saleList = this.Repository.Find<State>(x => x.Id > startId).Take(count).ToList();

                sb.Append(AppConfigKeys.SALE_SQL_PREFIX.ConfigValue());
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
                //retData = retData.Insert(retData.Length, AppConfigKeys.SALE_END_SEPARATE_CHAR.ConfigValue());
                return retData;
            }
            catch (Exception)
            {
                return string.Empty;
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
            where T : State
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'),\n", state.Id, state.PhoneNumber, state.IMEI, state.IMSI, state.Model, state.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), state.Address, state.ModelCode, state.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //sb.Append(AppConfigKeys.SALE_BREAK_LINE.ConfigValue());
            return sb.ToString();
        }
    }
}