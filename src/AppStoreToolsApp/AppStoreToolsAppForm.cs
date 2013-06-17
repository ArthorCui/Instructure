using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain.Service;
using RedisMapper;
using TYD.Mobile.Core.Helpers;
using TYD.Mobile.Infrastructure.AppStore.Models;
using TYD.Mobile.Infrastructure.Domain.Services;
using NLog;
using Cronus.Framework.Utilities;

namespace AppStoreToolsApp
{
    public partial class AppStoreToolsAppForm : Form
    {
        public IRedisService RedisService { get; set; }
        public IFileService FileService { get; set; }
        public IAppStoreUIService AppStoreUIService { get; set; }


        public AppStoreToolsAppForm()
        {
            InitializeComponent();
            RedisService = new RedisService();
            FileService = new FileService();
            AppStoreUIService = new AppStoreUIService(FileService, RedisService);
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            AppStoreToolsService svc = new AppStoreToolsService(RedisService, FileService, AppStoreUIService);

            #region Handle tag Missed for 经营策略
            //var tagId = "7";
            //var origrinalTagId = "183";
            //var origrinalTagName = "经营策略";
            //svc.UpdateTagForApp(tagId, origrinalTagId, origrinalTagName);

            //var tagId = "7";
            //var origrinalTagId = "4";
            //svc.UpdateTag(tagId,origrinalTagId);
            //MessageBox.Show("Done");
            #endregion

            var appProjectIdList = RedisService.GetAllActiveModelIds<AppProject>();

            var allVisiableAppProjects = RedisService.GetValuesByIds<AppProject>(appProjectIdList);

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

                    var existedOSSettings = RedisService.GetCustomPropertyFrom<App, CustomProperty>(appId, "4");
                    if (existedOSSettings != null)
                    {
                        var osValue = existedOSSettings.Value;
                        if (osValue == "Android")
                        {
                            LogHelper.Info(string.Format("{2}:Id:{0} Name:{1}", appId, appName, osValue));
                        }
                        else
                        {
                            RedisService.AddCustomPropertyFor<App, CustomProperty>(appId, prop);
                            LogHelper.Info(string.Format("{2}:Id:{0} Name:{1}", appId, appName, osValue));
                        }
                    }
                    else
                    {
                        RedisService.AddCustomPropertyFor<App, CustomProperty>(appId, prop);
                        LogHelper.Info(string.Format("None OS:Id:{0} Name:{1}", appId, appName));
                    }
                    #endregion

                    #region Platform fro Android
                    var platformType = itemApp.PlatformType;

                    if (platformType != 8)
                    {
                        itemApp.PlatformType = 8;
                        LogHelper.Info(string.Format("PlatformType:Id:{0} Name{1} Type{2}", appId, appName, platformType));
                    }
                    #endregion

                }
            }
        }

    }
}
