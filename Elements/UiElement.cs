using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Drawing;
using TestRail.Helper;


namespace TestRail.Elements
{
    public class UiElement : IWebElement
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _element;
        private readonly Actions _actions;
        private readonly WaitsHelper waitsHelper;
        private UiElement(IWebDriver driver)
        { 
            _driver = driver;
            _actions = new Actions(driver);
            waitsHelper = new WaitsHelper(driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));  
        } 
        public UiElement(IWebDriver driver, By locator) : this(driver)
        { 
              
            _element = waitsHelper.WaitForExists(locator);
        }

        public UiElement(IWebDriver driver, IWebElement element) : this(driver)
        {
            
            _element = element;            
        }
    
        public string TagName => _element.TagName;

        public string Text { get; }

        public bool Enabled => _element.Enabled;

        public bool Selected => _element.Selected;

        public Point Location => _element.Location;

        public Size Size => _element.Size;

        public bool Displayed => _element.Displayed;

        public void Clear()
        {
           _element.Clear();
        }

        public void Click()
        {
            try
            {
                _element.Click();
            }
            catch (ElementNotInteractableException)
            {
                try
                {
                    _actions
                        .MoveToElement(_element)
                        .Click()
                        .Build()
                        .Perform();
                }
                catch (ElementNotInteractableException)
                {
                    MoveToElement();
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].Click();", _element);
                }
            }
        }

        public void MoveToElement()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].acrollIntoView(true);", _element);
        }
        public IWebElement FindElement(By by)
        {
            return _element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            return _element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _element.GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return _element.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return _element.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return _element.GetShadowRoot();
        }

        public void SendKeys(string text)
        {
            _element.SendKeys(text);
            if (text != _element.GetAttribute("value"))
                _actions
                    .MoveToElement(_element)
                    .Click()
                    .SendKeys("")
                    .SendKeys(text)
                    .Build()
                    .Perform();
        }

        public void Submit()
        {
            try
            {
                _element.Submit();
            }
            catch 
            {
                _element.SendKeys(Keys.Enter);
            }

        }
    }
}
