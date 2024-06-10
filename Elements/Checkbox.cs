using OpenQA.Selenium;


namespace TestRail.Elements
{
    public class Checkbox
    {
        private UiElement _uiElement;
        public Checkbox(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }

        public void Check()
        {
            if (!_uiElement.Selected)
            {
                _uiElement.Click();
            }
        }

        public void Uncheck()
        {
            if (_uiElement.Selected)
            {
                _uiElement.Click();
            }
        }

        public void Toggle()
        {
            _uiElement.Click();
        }

        public bool IsChecked => _uiElement.Selected;
        public bool Displayed => _uiElement.Displayed;
        public bool Enabled => _uiElement.Enabled;
    }
}

