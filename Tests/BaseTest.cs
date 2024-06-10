using OpenQA.Selenium;
using Allure.NUnit;
using Allure.Net.Commons;
using System.Reflection;
using TestRail.Core;
using TestRail.Helper;
using TestRail.Steps.UI;
using TestRail.Steps.API;
using TestRail.Pages;

namespace TestRail.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver? Driver { get; set; }
        public ApiUserStep ApiUserStep { get; private set; }
        public WaitsHelper WaitsHelper { get; set; }
        public UserStep UserStep { get; set; }
        public ProjectsPage ProjectPage { get; set; }
        public NavigationStep Navigation { get; set; }
        public ApiAuthenticateStep ApiAuthenticate { get; set; }

        [SetUp]
        public void SetUp()
        {
          Driver = new Browser().Driver;
            //Steps
            ApiAuthenticate = new ApiAuthenticateStep();    
            ApiUserStep = new ApiUserStep();
            UserStep = new UserStep(Driver);
            Navigation = new NavigationStep(Driver);
            WaitsHelper =new WaitsHelper(Driver);
            
                          
            //Pages
            ProjectPage =  new ProjectsPage(Driver);
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
