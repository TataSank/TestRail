using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestRail.Helper
{
    public class WaitsHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IWebDriver Driver { get; set; }
        private WebDriverWait _wait;

        private TimeSpan _timeout { get; set; }
        public WaitsHelper(IWebDriver driver, TimeSpan timeout)
        {
             Driver = driver;
            _timeout = timeout;
            _wait = new WebDriverWait(driver, timeout);
        }

        public IWebElement WaitForExists(By locator )
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public bool WaitForElementVisible(IWebElement element)
        {
            try 

            {
                _wait.Until(d => element.Displayed);
                return true;
            }
            catch (NoSuchElementException ex)
            { 
                logger.Error(ex, "Element is not displayed");
                return true; 
            }
            catch(WebDriverTimeoutException ex)
            {
                logger.Error(ex, $"Element is not diaplyed after timeout {_timeout} seconds");
                throw new WebDriverTimeoutException($"Element is not diaplyed after timeout {_timeout} seconds");               
            }       
        }
    }
}
