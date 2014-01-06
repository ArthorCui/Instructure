﻿using System;
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
using NLog;
using System.IO;

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

        public void UpdateAllAppProperty()
        {
            var appProjectIdList = RedisService.GetAllActiveModelIds<AppProject>();

            var allVisiableAppProjects = RedisService.GetValuesByIds<AppProject>(appProjectIdList);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(allVisiableAppProjects.Count.ToString());

            foreach (var itemProject in allVisiableAppProjects)
            {
                var appProjectId = itemProject.Id;

                var apps = AppStoreUIService.GetAppsFromAppList<AppProject>(appProjectId);

                foreach (var itemApp in apps)
                {
                    var appId = itemApp.Id;
                    var appName = itemApp.Name;

                    #region OS for Android
                    CustomProperty prop = new CustomProperty()
                    {
                        Id = "4",
                        Value = "Android"
                    };

                    CustomProperty prop_test = new CustomProperty()
                    {
                        Id = "0",
                        Value = "Android"
                    };

                    RedisService.DeleteCustomPropertyFor<App, CustomProperty>(appId, prop_test);

                    var existedOSSettings = RedisService.GetCustomPropertyFrom<App, CustomProperty>(appId, "4");

                    var settings = itemApp.CustomProperties;
                    if (existedOSSettings != null)
                    {
                        var osValue = existedOSSettings.Value.ToString();
                        if (osValue == "Android")
                        {
                            var outputText_1 = string.Format("{2} - AppProjectId:{3} AppId:{0} Name:{1}", appId, appName, osValue, appProjectId);
                            sb.AppendLine(outputText_1);
                        }
                        else
                        {
                            var outputText_2 = string.Format("{2} - AppProjectId:{3} AppId:{0} Name:{1}", appId, appName, osValue, appProjectId);
                            RedisService.AddCustomPropertyFor<App, CustomProperty>(appId, prop);
                            sb.AppendLine(outputText_2);
                        }
                    }
                    else
                    {
                        var outputText_3 = string.Format("None OS - AppProjectId:{2} AppId:{0} Name:{1}", appId, appName, appProjectId);
                        RedisService.AddCustomPropertyFor<App, CustomProperty>(appId, prop);
                        sb.AppendLine(outputText_3);
                    }

                    #endregion

                    #region Platform for Android
                    var platformType = itemApp.PlatformType;

                    if (platformType != 8)
                    {
                        //var orginalApp = CloneHelper.DeepClone<App>(itemApp);
                        var originalApp = itemApp;
                        itemApp.PlatformType = 8;
                        RedisService.UpdateWithRebuildIndex<App>(originalApp, itemApp);
                        var outputText_4 = string.Format("PlatformType:Id:{0} Name:{1} Type:{2}", appId, appName, platformType);
                        sb.AppendLine(outputText_4);
                    }
                    #endregion
                }
            }
            LogManager.GetLogger("InfoLogger").Info(sb.ToString());
        }

        public void UpdateApp(string appId)
        {
            var originApp = RedisService.Get<App>(appId);
            //var originApp2 = CloneHelper.DeepClone<App>(originApp);
            if (originApp != null)
            {
                var app = originApp;
                app.DownloadTimes = app.DownloadTimes + 100;
                RedisService.UpdateWithRebuildIndex<App>(originApp, app);
            }
        }

        public void UpdateAppByTime(DateTime startTime, DateTime endTime)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var appProjectIdList = RedisService.GetAllActiveModelIds<AppProject>();

                var allVisiableAppProjects = RedisService.GetValuesByIds<AppProject>(appProjectIdList);
                if (allVisiableAppProjects != null)
                {
                    foreach (var itemProject in allVisiableAppProjects)
                    {
                        var appProjectId = itemProject.Id;

                        var createTime = itemProject.CreateDateTime;
                        if (createTime > startTime && createTime < endTime)
                        {
                            var apps = AppStoreUIService.GetAppsFromAppList<AppProject>(appProjectId);
                            if (apps != null && apps.Count > 0)
                            {
                                foreach (var itemApp in apps)
                                {
                                    var originalApp = itemApp;
                                    itemApp.DownloadTimes = originalApp.DownloadTimes + 100;
                                    RedisService.UpdateWithRebuildIndex<App>(originalApp, itemApp);
                                    sb.AppendLine(string.Format("AppProjectName:{0} AppId:{1} AppProjectId:{2}", itemProject.Name, itemApp.Id, itemProject.Id));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("InfoLogger").Error(ex.ToString());
            }
            LogManager.GetLogger("InfoLogger").Info(sb.ToString());
        }

        public void GetAllApp()
        {
            var appIds = RedisService.GetAllActiveModelIds<App>().ToIdsWithNoPrefix<App>();
            if (appIds != null && appIds.Count > 0)
            {
                LogManager.GetLogger("InfoLogger").Info(appIds.Count);
                foreach (var id in appIds)
                {
                    var taglist = AppStoreUIService.GetTagsByApp(id);

                    var sb = new StringBuilder();
                    var sb_tag = new StringBuilder();

                    var destTaglist = new List<DestTag>();
                    var destApp = new DestApp();

                    var app = RedisService.Get<App>(id);

                    foreach (var item in taglist)
                    {

                        var destTag = new DestTag();
                        destTag.Id = item.Id;
                        destTag.TagName = item.Name;
                        destTaglist.Add(destTag);
                        sb_tag.Append(item.Name);
                        sb_tag.Append(";");
                    }
                    sb.AppendFormat("AppId:{0} ", id);
                    sb.AppendFormat("AppNo:{0} ", app.AppNo);
                    sb.AppendFormat("Tag:{0}", sb_tag.ToString());
                    sb.Append("\n");
                    Console.WriteLine(sb.ToString());

                    LogManager.GetLogger("InfoLogger").Info(sb.ToString());
                    destApp.AppId = id;
                    destApp.TagList = destTaglist;
                }
            }
        }
    }
}
