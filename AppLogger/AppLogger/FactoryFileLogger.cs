using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogger
{
    public class FactoryFileLogger
    {
        private static FileLogger filelogger = new FileLogger();
        
        private FactoryFileLogger() { }

        public static void FactoryLoggerMethod(string message, LogLevel logLevel, string category) {
            filelogger.Log(message,logLevel,category);
        }

    }
}
