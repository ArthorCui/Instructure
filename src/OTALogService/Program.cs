using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OTALogService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                ProcessCommandLine(args);
            }
            else
            {
                RunService();
            }
        }

        private static void RunService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new OTALogService() 
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void ProcessCommandLine(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("================================");
                Console.WriteLine("For help, please run : OTA.LogService -help");
                Console.WriteLine("Press Ctrl + C to exit!");
                Console.WriteLine("================================");
                RunInCommandLine(DateTime.Today);
                return;
            }

            foreach (var x in args)
            {
                switch (x)
                {
                    case "-i":
                    case "-install":
                        InstallService();
                        return;
                    case "-u":
                    case "-uninstall":
                        UninstallService();
                        return;
                    case "-h":
                    case "-help":
                        ShowCommandHelp();
                        return;
                    case "-d":
                        RunInCommandLine(DateTime.Parse(args[1]));
                        return;
                    default:
                        Console.WriteLine("Unknown argument: {0}", x);
                        return;
                }
            }
        }

        private static void ShowCommandHelp()
        {
            Console.WriteLine(@"
================================
Usage: OTA.LogService [-i | -install | -u | -uninstall | -h | -help]

-i
-install
    install windows service
-u
-uninstall
    uninstall windows service
-h
-help
    show usage information
-d [date]
================================
");
        }

        private static void UninstallService()
        {
            var installer = new System.Configuration.Install.AssemblyInstaller(typeof(OTALogServiceInstaller).Assembly, null);
            installer.UseNewContext = true;
            installer.Uninstall(null);
        }

        private static void InstallService()
        {
            var installer = new System.Configuration.Install.AssemblyInstaller(typeof(OTALogServiceInstaller).Assembly, null);
            installer.UseNewContext = true;
            installer.Install(null);
        }

        private static void RunInCommandLine(DateTime logDate)
        {
            OTALogService server = new OTALogService();
            server.JobStart(logDate);
            Console.ReadLine();
        }
    }
}
