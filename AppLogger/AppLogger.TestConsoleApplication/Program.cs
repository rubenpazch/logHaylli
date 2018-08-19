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
            
            //test6();

            //test5();

            //test4();

            //test3();

            //test2();
            //FactoryFileLogger.FactoryLoggerMethod("test",LogLevel.Critical, "categoria");

            //test1();
            //FactoryFileLogger.FactoryLoggerMethod("test",LogLevel.Critical, "categoria");
        }

        public static void test1() {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";
            Console.WriteLine(le.ToString());
            Console.ReadLine();

            //[2/17/2018 4:00:12 PM][Critical][category] test
        }

        public static void test2()
        {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";

            LogFormatter lf = new LogFormatter();
            lf.FormatSpecification = null;
            lf.Format(le);
            Console.WriteLine(le.ToString(lf));
            Console.ReadLine();
            //[2/18/2018 4:00:12 AM][Critical][category] test
        }

        public static void test3() {
            LogEntry le = new LogEntry();
            le.Message = "test";
            le.LogLevel = LogLevel.Critical;
            le.Timestamp = Convert.ToDateTime("02/17/2018 22:00:12");
            le.Category = "category";

            LogFormatter lf = new LogFormatter();
            lf.FormatSpecification = null;

            System.Console.WriteLine(lf.Format(le));
            //[2/18/2018 4:00:12 AM][Critical][category] test
        }

        public static void test4() {
            LogEntry le = new LogEntry();
            Logger lg = new Logger();
            le = lg.Log("test", LogLevel.Critical, "category");
            System.Console.WriteLine(le.ToString());
            System.Console.ReadLine();

            //[8/18/2018 6:46:01 PM][Critical][category] test
        }

        public static void test5()
        {
            LogEntry le = new LogEntry();
            Logger lg = new Logger();
            le = lg.Log(null, LogLevel.Critical, "category");
            System.Console.WriteLine(le.ToString());
            System.Console.ReadLine();

            /*
            Excepción no controlada: System.ArgumentNullException: El valor no puede ser nulo.
            Nombre del parámetro: message
            en AppLogger.Logger.Log(String message, LogLevel logLevel, String category) en C:\Users\USER\Documents\repo2\HaylliApi\logHaylli\AppLogger\AppLogger\Logger.cs:línea 47
            en AppLogger.TestConsoleApplication.Program.test5() en C:\Users\USER\Documents\repo2\HaylliApi\logHaylli\AppLogger\AppLogger.TestConsoleApplication\Program.cs:línea 85
            en AppLogger.TestConsoleApplication.Program.Main(String[] args) en C:\Users\USER\Documents\repo2\HaylliApi\logHaylli\AppLogger\AppLogger.TestConsoleApplication\Program.cs:línea 16
            */
        }

        public static void test6()
        {
            LogEntry le = new LogEntry();
            Logger lg = new Logger();
            le = lg.Log("test", LogLevel.Critical, null);
            System.Console.WriteLine(le.ToString());
            System.Console.ReadLine();

            //[8/18/2018 7:13:05 PM][Critical][General] test
        }
    }
}
