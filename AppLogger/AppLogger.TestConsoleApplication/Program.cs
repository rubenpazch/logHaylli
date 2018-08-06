using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogger;

namespace AppLogger.TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryFileLogger.FactoryLoggerMethod("test",LogLevel.Critical, "categoria");
        }
    }
}
