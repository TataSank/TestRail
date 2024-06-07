using OpenQA.Selenium;
using TestRail.Elements;


namespace TestRail.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By UserNameFieldBy = By.Id("name");
        private static readonly By UserPasswordBy = By.Id("password");
        private static readonly By SubmitButtonBy = By.Id("button_primary");
        private static readonly By EmailLoginRequiredMessageBy = By.XPath("//form/div[3][text()='Email/Login is required.']");
        private static readonly By PasswordRequiredMessageBy = By.XPath("//form//child::div[text()='Password is required.']");

        public LoginPage(IWebDriver driver,bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
           
        }
       
        public UiElement UserNameField() => new UiElement(Driver, UserNameFieldBy);      
        public UiElement UserPasswordField() => new UiElement(Driver,UserPasswordBy);
        public UiElement EmailLoginRequiredMessage() => new UiElement(Driver, EmailLoginRequiredMessageBy);
        public UiElement PasswordRequiredMessage() => new UiElement(Driver, PasswordRequiredMessageBy);
        public Button SubmitButton() => new Button(Driver,SubmitButtonBy);

        public void Login(string UserName = "", string Password = "")
        {
            UserNameField().SendKeys(UserName);
            UserPasswordField().SendKeys(Password);
            SubmitButton().Click();
        }

        public string GetUsernameEmptyErrorMessage()
        {
            return EmailLoginRequiredMessage().Text;
        }

        public string GetPasswordEmptyErrorMessage()
        { 
            return PasswordRequiredMessage().Text;  
        }
        public string[] GetLoginErrorMessage()
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrEmpty(UserNameField().GetAttribute("value")))
            {
                 errorMessages.Add(EmailLoginRequiredMessage().Text);
            }
            if (string.IsNullOrEmpty(UserPasswordField().GetAttribute("value")))
            {
                errorMessages.Add(PasswordRequiredMessage().Text);
            }
            {
                return errorMessages.ToArray();
            }
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

