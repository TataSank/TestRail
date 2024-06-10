using OpenQA.Selenium;
using TestRail.Helper;
using TestRail.Pages;

namespace TestRail.Steps.UI
{
    public class NavigationStep:BaseStep
    {
        
        private IWebDriver _driver;
        private const string projectPageEndpoint = "/index.php?/admin/projects/overview";
        
        public NavigationStep(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            
        }

        public LoginPage NavigationLoginStep()
        {
            _driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url);

           return new LoginPage(_driver,true);    

        }  

        public ProjectsPage NavigationProjectPageStep()
        {
            _driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url+projectPageEndpoint);
            return new ProjectsPage(_driver,true);  
        }
    }
}
