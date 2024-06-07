using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using System.Reflection;
using TestRail.Core;
using TestRail.Helper;
using TestRail.Steps.UI;

namespace TestRail.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver? Driver { get; set; }
        public WaitsHelper WaitsHelper { get; set; }
        public UserStep UserStep { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            //Steps

            UserStep = new UserStep(Driver);

            WaitsHelper =new WaitsHelper(Driver);


            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url);
            

            //Pages
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
