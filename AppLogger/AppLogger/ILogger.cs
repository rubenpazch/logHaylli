using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogger
{
    public interface ILogger
    {
         LogEntry Log(string message, LogLevel logLevel = LogLevel.Verbose, string category = null);
    }
}
