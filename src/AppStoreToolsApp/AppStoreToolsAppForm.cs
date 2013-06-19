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

            #region Update App OS Android
            //svc.UpdateAllAppProperty();
            #endregion
            //var appId = "77912";
            //svc.UpdateApp(appId);
            var startTime = DateTime.Now.AddHours(-14);
            var endTime = DateTime.Now.AddHours(-10);
            svc.UpdateAppByTime(startTime, endTime);

        }

    }
}
