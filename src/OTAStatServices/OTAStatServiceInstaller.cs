using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace OTAStatService
{
    [RunInstaller(true)]
    public partial class OTAStatServiceInstaller : System.Configuration.Install.Installer
    {
        public OTAStatServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
