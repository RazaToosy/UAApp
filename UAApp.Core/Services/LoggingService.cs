using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAApp.Core.Interfaces;

namespace UAApp.Core.Services
{
    public class LoggingService : ILogger
    {
        private readonly ILogger _theMessageSender;

        public LoggingService(ILogger TheMessageSender)
        {
            _theMessageSender = TheMessageSender;
        }

        public void SendMessage(string theMessage)
        {
            _theMessageSender.SendMessage(theMessage);
        }
    }
}
