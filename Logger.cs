using Serilog;

namespace VinxTech.API
{
    public class Logger
    {
        private static readonly Serilog.ILogger _errorLogger;
        private static readonly Serilog.ILogger _eventLogger;

        private readonly IConfiguration _config;

        public Logger(IConfiguration config)
        {
            _config = config;
        }

        static Logger()
        {
            _errorLogger = new LoggerConfiguration()
                   .WriteTo.File(@"C:\AppLogs\VinxTech\UAT\Logs.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 30)
                   .CreateLogger();

            _eventLogger = new LoggerConfiguration()
               .WriteTo.File(@"C:\AppLogs\VinxTech\UAT\SuccessLogs.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 30)
               .CreateLogger();
        }


        public static void LogError(string error)
        {
            _errorLogger.Error(error);
        }

        public static void LogEvent(string Message)
        {
            _eventLogger.Information(Message);
        }

    }
}
