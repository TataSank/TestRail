using OpenQA.Selenium;
using TestRail.Elements;


namespace TestRail.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By UserNameFieldBy = By.Id("name");
        private static readonly By UserPasswordBy = By.Id("password");
        private static readonly By SubmitButtonBy = By.Id("button_primary");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        protected IWebDriver? Driver { get; set; }

        public UiElement UserNameField() => new UiElement(Driver, UserNameFieldBy);      
        public UiElement UserPasswordField() => new UiElement(Driver,UserPasswordBy);
        public UiElement SubmitButton() => new UiElement(Driver,SubmitButtonBy);

        public void Login(string UserName = "", string Password = "")
        {
            UserNameField().SendKeys(UserName);
            UserPasswordField().SendKeys(Password);
            SubmitButton().Click();
        }

        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateLoadedStatus()
        {
            return SubmitButton().Displayed;
        }
    }
}

