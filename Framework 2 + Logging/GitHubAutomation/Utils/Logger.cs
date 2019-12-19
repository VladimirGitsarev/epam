using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System;
using System.IO;

namespace FlyuiaTestFramework.Utils
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            var separateIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
            var logConfigPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, separateIndex) +
                             "ConfigFiles/log4net.config";
            var logConfigFile = new FileInfo(logConfigPath);
            XmlConfigurator.Configure(logConfigFile);
        }
    }
}
