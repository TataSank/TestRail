using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestRail.Helper;

namespace TestRail.Pages
{
    public abstract class BasePage:LoadableComponent<BasePage>
    {
        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver,bool openPageByUrl = false)
        {
            Driver = driver;
            if (openPageByUrl) Load();
        }

        protected override void ExecuteLoad()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().Url);
        }
    }
}
