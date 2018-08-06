using System;
using System.Text;

namespace AppLogger
{
    public class LogEntry
    {

        public const string DefaultCategory = "General";
        private string _category;

        public DateTime Timestamp { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }

        public string Category
        {
            get { return _category ?? DefaultCategory; }
            set { _category = value; }
        }

        public string ToString(ILogFormatter formatter)
        {
            if (formatter == null) return ToString();
            try
            {
                return formatter.Format(this);
            }
            catch
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[{0}][{1}][{2}] {3}",
                Timestamp.ToLocalTime(),
                LogLevel,
                Category,
                Message);
            return sb.ToString();
        }
    }
}
