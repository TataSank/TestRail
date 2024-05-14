using OpenQA.Selenium;
using TestRail.Helper;

namespace TestRail.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url);
        }
    }
}
