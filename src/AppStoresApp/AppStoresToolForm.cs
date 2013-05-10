using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NCore;
using RedisMapper;
using TYD.Logging.Core;
using TYD.Mobile.Infrastructure.AppStore.Models;
using TYD.Mobile.Infrastructure.Domain.Services;

namespace AppStoresToolApp
{
    public partial class AppStoresToolForm : Form
    {
        private FileService _fileService;
        private RedisService _redisService;
        private AppStoreUIService _appStoreUIService;
        private RedisLogger _logger;

        public AppStoresToolForm()
        {
            InitializeComponent();
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            var redis_host = this.textBox_Host.Text.Trim();
            var redis_port = this.textBox_Port.Text.Trim();
            var redis_resoultion = this.textBox_Resoultion.Text;
            var redis_config = string.Format("{0}:{1}", redis_host, redis_port);

            this.InitializeAppStoresInstance();

            try
            {
                var app = _redisService.Get<App>("20583");
                
                MessageBox.Show(string.Format("应用分支名称：{0}<br />应用所属平台：{1}",app.ModuleName,app.CategoryName));
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void InitializeAppStoresInstance()
        {
            SingletonBase<ConfigurableSet>.Instance["redis_read_write_servers"] = string.Format("{0}:{1}", this.textBox_Host.Text.Trim(), this.textBox_Port.Text.Trim());
            SingletonBase<ConfigurableSet>.Instance["redis_readonly_servers"] = string.Format("{0}:{1}", this.textBox_Host.Text.Trim(), this.textBox_Port.Text.Trim());
            this._fileService = new FileService();
            this._redisService = new RedisService();
            this._appStoreUIService = new AppStoreUIService(this._fileService, this._redisService);
            this._logger = new RedisLogger();
            //ObjectFactory.Inject<IUiLog>(new UiLog(this.txtResult));
        }
    }
}
