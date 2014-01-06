using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Service;
using RedisMapper;
using NCore;
using TYD.Mobile.Infrastructure.Domain.Services;

namespace UpdateAppTool
{
    public class UpdateAppService
    {
        public IRedisService RedisService { get; set; }
        public IFileService FileService { get; set; }
        public IAppStoreUIService AppStoreUIService { get; set; }
        public const string CONFIG_KEY_START_HOUR_INT = "Start_Hour_Int";
        public const string CONFIG_KEY_END_HOUR_INT = "End_Hour_Int";

        public void RebuilAppIndex()
        {
            RedisService = new RedisService();
            FileService = new FileService();
            AppStoreUIService = new AppStoreUIService(FileService, RedisService);

            AppStoreToolsService svc = new AppStoreToolsService(RedisService, FileService, AppStoreUIService);

            var startTime_Hour_Count = CONFIG_KEY_START_HOUR_INT.ConfigValue().ToInt32();
            var endTime_Hour_Count = CONFIG_KEY_END_HOUR_INT.ConfigValue().ToInt32();
            var startTime = DateTime.Now.AddHours(-startTime_Hour_Count);
            var endTime = DateTime.Now.AddHours(-endTime_Hour_Count);
            //svc.UpdateAppByTime(startTime, endTime);
            svc.GetAllApp();
        }
    }
}
