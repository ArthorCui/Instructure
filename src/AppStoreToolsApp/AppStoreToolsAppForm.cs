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

            var allVisiableAppProjects = RedisService.GetValuesByIds<AppProject>(appProjectIdList).Take(10);

            StringBuilder sb = new StringBuilder();

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
                    var setting = itemApp.CustomProperties;

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

                    #region Platform fro Android
                    var platformType = itemApp.PlatformType;

                    if (platformType != 8)
                    {
                        var orginalApp = CloneHelper.DeepClone<App>(itemApp);
                        itemApp.PlatformType = 8;
                        RedisService.UpdateWithRebuildIndex<App>(orginalApp, itemApp);
                        var outputText_4 = string.Format("PlatformType:Id:{0} Name:{1} Type:{2}", appId, appName, platformType);
                        sb.AppendLine(outputText_4);
                    }
                    #endregion
                }
            }
            this.textBox_Display.Text = sb.ToString();
            LogManager.GetLogger("InfoLogger").Info(sb.ToString());
        }

    }
}
