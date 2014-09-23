using log4net;
using UAApp.Core.Interfaces;

namespace UAApp.Infrastructure.Services.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4NetLogger));

        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void SendMessage(string theMessage)
        {
            Log.Error(theMessage);
        }
    }
}
