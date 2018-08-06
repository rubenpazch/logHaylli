using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogger
{
    public interface ILogFormatter
    {
        string Format(LogEntry logEntry);
    }
}
