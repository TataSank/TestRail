using OpenQA.Selenium;


namespace TestRail.Elements
{
    public class Button
    {
        private UiElement _uiElement;
        public Button(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }

        public void Submit()
        { 
            _uiElement.Submit();
        }

        public void Click() { _uiElement.Click(); }

        public bool Displayed => _uiElement.Displayed;
        public string Text => _uiElement.Text;
        public bool Enabled => _uiElement.Enabled;

    }
}
