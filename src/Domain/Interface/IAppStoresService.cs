using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYD.Mobile.Infrastructure.AppStore.Models;

namespace Domain.Interface
{
    public interface IAppStoresToolService
    {
        AppProject GetAppProjectById(string appProjectId);
        IList<App> GetAllAppByAppProject(AppProject appProject);
        void Execute(string redisServerConfig);
    }
}
