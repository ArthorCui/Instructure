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
using SubSonic.DataProviders;
using SubSonic.Query;
using System.Data.Common;

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

                var saleList = GetSaleCollection(id, count);

                sb.Append(AppConfigKeys.SALE_SQL_PREFIX.ConfigValue());
                for (int i = 0; i < saleList.Count; i++)
                {
                    if (saleList[i].IMEI.Trim(' ').Length >= 16)
                    {
                        saleList[i].IMEI = saleList[i].IMEI.Replace("'", "");
                    }
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
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public List<State> GetSaleCollection(int id, int count)
        {
            var saleList = new List<State>();
            try
            {
                var conn = System.Configuration.ConfigurationManager.ConnectionStrings[AppConfigKeys.SALE_SQL_CONNECT_STRING].ConnectionString;

                var provider = ProviderFactory.GetProvider(conn, "System.Data.SqlClient");

                var command = string.Format("SELECT TOP {0} [Id],[Name],[PhoneNumber],[IMEI],[IMSI],[Model],[Date],[Address],[ProvinceId],[CityId],[BrandId],[HttpUrl],[PostData],[ModelCode],[CreateTime],[Status] FROM [MobileSaleStatMain].[dbo].[State]where id > {1}", count, id);

                var query = new QueryCommand(command, provider);
                var reader = provider.ExecuteReader(query);

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        saleList.Add(MapPost(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return saleList;
        }

        public State MapPost(DbDataReader reader)
        {
            State item = new State();
            item.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            item.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            item.IMEI = reader.GetString(reader.GetOrdinal("IMEI"));
            item.IMSI = reader.GetString(reader.GetOrdinal("IMSI"));
            item.Model = reader.GetString(reader.GetOrdinal("Model"));
            item.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            item.Address = reader.GetString(reader.GetOrdinal("Address"));
            item.ProvinceId = reader.GetInt32(reader.GetOrdinal("ProvinceId"));
            item.CityId = reader.GetInt32(reader.GetOrdinal("CityId"));
            item.BrandId = reader.GetInt32(reader.GetOrdinal("BrandId"));
            item.HttpUrl = reader.GetString(reader.GetOrdinal("HttpUrl"));
            item.PostData = reader.GetString(reader.GetOrdinal("PostData"));
            item.ModelCode = reader.GetString(reader.GetOrdinal("ModelCode"));
            item.CreateTime = reader.GetDateTime(reader.GetOrdinal("CreateTime"));
            item.Status = reader.GetInt32(reader.GetOrdinal("Status"));

            return item;
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
            return sb.ToString();
        }
    }
}
