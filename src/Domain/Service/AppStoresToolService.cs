using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Model.AppStores;
using RedisMapper;
using ServiceStack.Redis;
using TYD.Mobile.Infrastructure.AppStore.Models;

namespace Domain.Service
{
    public class AppStoresToolService : IAppStoresToolService
    {
        public IRedisService RedisService { get; set; }

        public AppStoresToolService(IRedisService _redisService)
        {
            this.RedisService = _redisService;
        }

        private IRedisClientsManager GetInstance(string redisConfig)
        {
            var manager = default(IRedisClientsManager);
            var redisClientConfig = new RedisClientManagerConfig
            {
                MaxReadPoolSize = 50,
                MaxWritePoolSize = 50,
                AutoStart = true
            };

            string[] readWriteHosts = redisConfig.Split(',');

            manager = new PooledRedisClientManager(readWriteHosts, readWriteHosts, redisClientConfig);

            return manager;
        }

        public void Execute(string redisServerConfig)
        {
            var redisClient = GetInstance(redisServerConfig);

        }

        public AppProject GetAppProjectById(string appProjectId)
        {
            var appProject = RedisService.Get<AppProject>(appProjectId);

            return appProject;
        }

        public IList<App> GetAllAppByAppProject(AppProject appProject)
        {
            return null;
        }
    }
}
