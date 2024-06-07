using OpenQA.Selenium;
using TestRail.Pages;

namespace TestRail.Steps.UI
{
    public class NavigationStep:BaseStep
    {
        
        private IWebDriver _driver;

        public NavigationStep(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            
        }

        public LoginPage NavigationLoginStep()
        {
           return new LoginPage(_driver,true);    

        }  
    }
}
