using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NLog;
using OpenQA.Selenium;
using TestRail.Helper;
using TestRail.Pages;


namespace TestRail.Tests
{
    public class LoginTest : BaseTest

    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "Login")]
        [AllureDescription("This test checks positive and negative cases for logining")]
        [AllureStep]
        public void LoginPositiveTest()

        {
            var loginPage = new LoginPage(Driver);
           

            loginPage.Login(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);

           // Assert.That(dashboard.ShoppingCart().Displayed, Is.True, "User is not login in ");
        }
        [Test]
        public void LoginWithoutPasswordTest()
        {
            var loginPage = new LoginPage(Driver);
            var expectedErrorMessage = "Password is required.";
            loginPage.UserNameField().SendKeys(Configurator.ReadConfiguration().UserName);
            loginPage.SubmitButton().Click();
            var actualErrorMessage = Driver.FindElement(By.ClassName("loginpage-message-image")).Text;

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }
        [Test]
        public void LoginWithoutUserNameTest()
        {
            var loginPage = new LoginPage(Driver);
            var expectedErrorMessage = "Email/Login is required.";
            loginPage.UserPasswordField().SendKeys(Configurator.ReadConfiguration().Password);
            loginPage.SubmitButton().Click();
            var actualErrorMessage = Driver.FindElement(By.ClassName("loginpage-message-image")).Text;
            Thread.Sleep(3000);
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }
    }
}
