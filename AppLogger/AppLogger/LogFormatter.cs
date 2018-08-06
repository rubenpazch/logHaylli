using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogger
{
    public class LogFormatter : ILogFormatter
    {
        private static readonly string DefaultTemplate = @"[{timestamp}][{loglevel}][{category}] {message}";

        public FormatSpecification FormatSpecification { get; set; }

        #region ILogFormatter Members

        public string Format(LogEntry logEntry)
        {
            if (FormatSpecification == null)
            {
                FormatSpecification = new FormatSpecification
                {
                    Template = DefaultTemplate,
                };
            }

            // TODO add real support for using the template
            var sb = new StringBuilder();

            sb.AppendFormat("[{0}][{1}][{2}] {3}",
                logEntry.Timestamp.ToUniversalTime(),
                logEntry.LogLevel,
                logEntry.Category,
                logEntry.Message);

            return sb.ToString();
        }

        #endregion
    }
}
