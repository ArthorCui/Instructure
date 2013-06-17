using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedisMapper;
using StructureMap;
using TYD.Mobile.Infrastructure.Domain.Services;

namespace ImageToolsApp
{
    public partial class ImageToolsForm : Form
    {
        public IRedisService RedisService
        {
            get
            {
                if (_redisService == null)
                    _redisService = ObjectFactory.GetInstance<IRedisService>();

                return _redisService;
            }
            set
            {
                _redisService = value;
            }
        }
        private IRedisService _redisService;

        public IFileService FileService
        {
            get
            {
                if (_fileService == null)
                    _fileService = ObjectFactory.GetInstance<IFileService>();

                return _fileService;
            }
            set
            {
                _fileService = value;
            }
        }
        private IFileService _fileService;

        public IAppStoreUIService AppStoreUIService { get; set; }


        public ImageToolsForm()
        {
            InitializeComponent();
            AppStoreUIService = new AppStoreUIService(FileService, RedisService);
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {

        }
    }
}
