using OpenQA.Selenium;
using TestRail.Pages;

namespace TestRail.Steps
{
    public class BaseStep
    {
        protected IWebDriver _driver;
        protected LoginPage LoginPage;

        public BaseStep(IWebDriver driver)
        {
            _driver = driver;
            LoginPage = new LoginPage(driver);
        }
    }
}
