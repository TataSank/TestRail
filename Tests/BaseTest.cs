using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using System.Reflection;
using TestRail.Core;
using TestRail.Helper;

namespace TestRail.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver? Driver { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url);
        }
        [TearDown]
        public void CloseBrowser()
        {
            var logFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "logFile.txt");
            AllureApi.AddAttachment("logFile", "text/html", logFilePath);
            Driver.Quit();
        }
    }

}
