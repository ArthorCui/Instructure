using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Const;
using Model.AppStores;
using SubSonic.Oracle.Repository;
using TYD.Logging.Models;

namespace Domain.Service
{
    public class AppStoresDataService
    {
        public IRepository Repository { get; set; }

        public AppStoresDataService()
        {
            Repository = new SimpleRepository(ConnectionStrings.Key_APPSTORES_ORACLE_LOG_STRING, SimpleRepositoryOptions.None);
        }

        public void GetData(long startId, long endId)
        {
            var dataList = Repository.Find<CommunicationLog>(x => x.Id > startId && x.Id <= endId).ToList();
        }

        public void DataFactory()
        {
            var measure = 1000;

            for (int i = 0; i < 10; i++)
            {
                var data_K_list = Repository.Find<CommunicationLog>(x => x.Id > i * measure && x.Id <= (i + 1) * measure).ToList();
                if (data_K_list != null)
                {
                    HandleData(data_K_list);
                }

            }



        }


        public void HandleData(List<CommunicationLog> dataList)
        {
            foreach (var item in dataList)
            {
                var dig = new DigCommunicationLog();


            }


        }




    }
}
