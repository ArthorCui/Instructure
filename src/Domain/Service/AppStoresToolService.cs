using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Model.AppStores;
using RedisMapper;
using ServiceStack.Redis;
using StructureMap;
using TYD.Mobile.Infrastructure.AppStore.Models;
using TYD.Mobile.Infrastructure.Domain.Services;
using TYD.Mobile.Infrastructure.Domain.StaticData;

namespace Domain.Service
{
    public class AppStoreToolsService : IAppStoreToolsService
    {
        public IRedisService RedisService { get; set; }
        public IFileService FileService { get; set; }
        public IAppStoreUIService AppStoreUIService { get; set; }

        public AppStoreToolsService()
        {

        }

        public AppStoreToolsService(IRedisService redisService, IFileService fileService, IAppStoreUIService appstoreUIService)
        {
            this.RedisService = redisService;
            this.FileService = fileService;
            this.AppStoreUIService = appstoreUIService;
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

        public void UpdateTagForApp(string tagId, string origrinalTagId, string origrinalTagName)
        {
            try
            {
                AppStoreUIService.DeleteTag(tagId);

                var tags = AppStoreUIService.GetAllTags();

                var tag = new Tag()
                {
                    Id = tagId,
                    Name = origrinalTagName,
                    DisplayName = origrinalTagName,
                    NameLowCase = origrinalTagName
                };
                RedisService.Add<Tag>(tag);

                var appIdlist = AppStoreUIService.GetAppIdsByTag(origrinalTagId);
                var appList = AppStoreUIService.GetAppsByTag(origrinalTagId);
                if (appIdlist != null && appList != null)
                {
                    foreach (var item in appList)
                    {
                        var appProjectId = item.AppProjectId;
                        AppStoreUIService.AddTagForAppProject(origrinalTagName, appProjectId);
                        AppStoreUIService.AddTagForApp(origrinalTagName, item.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message);
            }
        }

        public void UpdateTag(string tagId, string origrinalTagId)
        {
            try
            {
                var targetTag = RedisService.Get<Tag>(tagId);
                var origrinalTag = RedisService.Get<Tag>(origrinalTagId);

                targetTag.Color = origrinalTag.Color;
                RedisService.UpdateWithRebuildIndex(targetTag, targetTag);
                Console.WriteLine(targetTag.Color);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message);
            }
        }


    }
}
