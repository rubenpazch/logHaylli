using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogger
{
    public class Logger:ILogger
    {

        public const LogLevel DefaultLogLevel = LogLevel.Verbose;

        public Logger(LogLevel logLevel = LogLevel.Verbose)
        {
            LogLevel = logLevel;
        }


        /// <summary>
		///   Gets or sets the log action to use to write the formatted output
		///   after the Log method is invoked.
		/// </summary>
		public Action<string> LogAction { get; set; }
        /// <summary>
		///   Gets or sets the formatter for formatting the log entry.
		///   If not null, the formatter is invoked by the Log method.
		/// </summary>
		public ILogFormatter Formatter { get; set; }
        /// <summary>
		///   Gets or sets the current log level.
		///   This is used to determine which log entries are written to the log destination.
		/// </summary>
		public LogLevel LogLevel { get; set; }

        #region ILogger Members

        /// <summary>
        ///   Write the log entry to the output destination.
        /// </summary>
        /// <param name="message"> Must not be null or empty </param>
        /// <param name="logLevel"> </param>
        /// <param name="category"> </param>
        /// <returns> </returns>
        public virtual LogEntry Log(string message, LogLevel logLevel = LogLevel.Verbose, string category = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message is null");
            }
            var logEntry = new LogEntry
            {
                Timestamp = DateTime.UtcNow,
                Message = message,
                LogLevel = logLevel,
                Category = category,
            };
            if (LogAction != null && logLevel != LogLevel.None && logLevel >= LogLevel)
            {
                // if Formatter is null, generates a default formatted string
                var output = logEntry.ToString(Formatter);
                LogAction(output);
            }
            return logEntry;
        }
        #endregion
    }
}
