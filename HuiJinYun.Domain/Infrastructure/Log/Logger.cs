using log4net;
using System;
using System.Configuration;

namespace HuiJinYun.Domain.Log
{
    public class Logger
    {
        public static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        public static readonly ILog logerror = LogManager.GetLogger("logerror");
        public Logger()
        {
        }
        private static void SetConfig()
        {
            object o = ConfigurationManager.GetSection("log4net");
            log4net.Config.XmlConfigurator.Configure(o as System.Xml.XmlElement);
        }
        public static void LogInfo(string info)
        {
            if (!loginfo.IsInfoEnabled)
                SetConfig();
            loginfo.Info(info);
        }

        public static void LogInfo(string Message, Exception ex)
        {
            if (!loginfo.IsInfoEnabled)
                SetConfig();
            loginfo.Info(Message, ex);
        }

        public static void ErrorInfo    (string info, Exception ex)
        {
            if (!logerror.IsInfoEnabled)
                SetConfig();
            logerror.Error(info, ex);
        }

        public static void DebugInfo(string Message)
        {
            if (!logerror.IsInfoEnabled)
                SetConfig();
            logerror.Error(Message);
        }
    }
}