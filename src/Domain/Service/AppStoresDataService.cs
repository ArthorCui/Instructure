using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Const;
using SubSonic.Oracle.Repository;

namespace Domain.Service
{
    public class AppStoresDataService
    {
        public IRepository Repository { get; set; }

        public AppStoresDataService()
        {
            Repository = new SimpleRepository(ConnectionStrings.Key_APPSTORES_ORACLE_LOG_STRING, SimpleRepositoryOptions.None);
        }




    }
}
