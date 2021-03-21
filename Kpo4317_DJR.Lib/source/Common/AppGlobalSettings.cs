using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kpo4317_DJR.Utility;

namespace Kpo4317_DJR.Lib
{
    public static class AppGlobalSettings
    {
        private static string _logPath;
        private static string _dataFileName;
        private static ISemiconductorFactory _semiconductorFactory;

        public static void Initialize()
        {
            AppConfigUtility appConfig = new AppConfigUtility();
            _logPath = appConfig.AppSettings("logPath");
            _dataFileName = appConfig.AppSettings("dataFileName");
            if (_dataFileName == "test")
            {
                _semiconductorFactory = new SemiconductorTestFactory();
            }
            else
            {
                _semiconductorFactory = new SemiconductorSplitFileFactory();
            }
        }

        public static string LogPath { get { return _logPath; } }
        public static string DataFileName { get { return _dataFileName; } }
        public static ISemiconductorFactory SemiconductorFactory { get { return _semiconductorFactory; } }
    }
}
