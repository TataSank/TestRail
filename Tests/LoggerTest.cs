using NLog;

namespace TestRail.Tests
{
    internal class LoggerTest:BaseTest
    {
        public Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void Logger()

        {
            logger.Trace("Log Trace");
            logger.Debug("Log Debug");
            logger.Info("Log Info");
            logger.Error("Log Error");
            logger.Fatal("Log Fatal");

        }
    }
}
