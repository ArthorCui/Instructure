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
using NCore;

namespace AppStoreToolsApp
{
    public partial class AppStoreToolsAppForm : Form
    {
        public IRedisService RedisService { get; set; }
        public IFileService FileService { get; set; }
        public IAppStoreUIService AppStoreUIService { get; set; }
        public const string CONFIG_KEY_START_HOUR_INT = "Start_Hour_Int";
        public const string CONFIG_KEY_END_HOUR_INT = "End_Hour_Int";


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

            #region Update App OS Android
            //svc.UpdateAllAppProperty();
            #endregion
            //var appId = "77912";
            //svc.UpdateApp(appId);
            var startTime_Hour_Count = CONFIG_KEY_START_HOUR_INT.ConfigValue().ToInt32();
            var endTime_Hour_Count = CONFIG_KEY_END_HOUR_INT.ConfigValue().ToInt32();
            var startTime = DateTime.Now.AddHours(-startTime_Hour_Count);
            var endTime = DateTime.Now.AddHours(-endTime_Hour_Count);
            svc.UpdateAppByTime(startTime, endTime);

        }

    }
}
