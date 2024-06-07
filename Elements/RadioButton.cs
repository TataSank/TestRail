using OpenQA.Selenium;
using TestRail.Helper;

namespace TestRail.Elements
{
    public class RadioButton
    {
        private List<UiElement> _uiElements;
        private WaitsHelper _waitsHelper;

        public RadioButton(IWebDriver driver, By locator)
        {
            _uiElements = new List<UiElement>();
            _waitsHelper = new WaitsHelper(driver);

            foreach (var element in _waitsHelper.WaitForElementsPresence(locator))
            { 
                var uiElement = new UiElement(driver, element);
                _uiElements.Add(uiElement); 
            }
        }

        public void SelectByIndex(int index)
        {
            {
                _uiElements[index].Click();
                    
            }
        }
    }
    
}
