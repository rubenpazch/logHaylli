using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppLogger.UnitTest
{
    [TestClass]
    public class UnitTestLogEntry
    {
        [TestMethod]
        public void ToString_logentryformatiscorrect_returnstring()
        {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";
            string result = "[2/17/2018 4:00:12 PM][Critical][category] test";
            Assert.AreEqual(result, le.ToString());

        }

        [TestMethod]
        public void ToString_logentryformatiscorrect_returnstring_formatter()
        {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";

            LogFormatter lf = new LogFormatter();
            lf.FormatSpecification = null;
            lf.Format(le);
            string result = "[2/18/2018 4:00:12 AM][Critical][category] test";
            Assert.AreEqual(result, le.ToString(lf));
        }

        [TestMethod]
        public void Format_logFormatter_FormatSpecification_isNull()
        {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";

            LogFormatter lf = new LogFormatter();
            lf.FormatSpecification = null;

            string result = "[2/18/2018 4:00:12 AM][Critical][category] test";
            Assert.AreEqual(result, lf.Format(le));
            
        }

        [TestMethod]
        public void Log_Logger_Parameters_are_different_of_null_toString()
        {
            LogFormatter lf = new LogFormatter();
            LogEntry le = new LogEntry();
            Logger lg = new Logger();

            le = lg.Log("test", LogLevel.Critical, "category");

            String result =le.ToString();
            
            string expected = "[" + DateTime.UtcNow.ToLocalTime() + "][Critical][category] test";
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Log_Logger_Parameters_are_different_of_null_toString_formatted()
        {
            LogFormatter lf = new LogFormatter();
            LogEntry le = new LogEntry();
            Logger lg = new Logger();

            le = lg.Log("test", LogLevel.Critical, "category");

            String result = le.ToString(lf);

            string expected = "[" + DateTime.UtcNow + "][Critical][category] test";
            Assert.AreEqual(expected, result);

        }

     

    }
}
