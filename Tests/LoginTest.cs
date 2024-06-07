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
        private static LoginPage loginPage;
        [SetUp]
        public void SetUp()
        { 
           loginPage = new LoginPage(Driver);
        }
       
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "Login")]
        [AllureDescription("User can login")]
        [AllureStep("User has successfully logged in")]
        public void LoginPositiveTest()

        {                     
            UserStep.SuccessfullLogin(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "Login")]
        [AllureDescription("Check that user can't without password")]
        [AllureStep("User has not logged in without password")]
        public void LoginWithoutPasswordTest()
        {
           
            var expectedErrorMessage = "Password is required.";
            UserStep.UnsuccessfullLoginWithoutPassword(Configurator.ReadConfiguration().UserName);

            var actualErrorMessage = loginPage.GetPasswordEmptyErrorMessage();        
           
            Assert.That(actualErrorMessage, Does.Contain(expectedErrorMessage));
        }
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "Login")]
        [AllureDescription("Check that user can't login without User Name")]
        [AllureStep("User has not logged in without username")]
        public void LoginWithoutUserNameTest()
        {
            
            var expectedErrorMessage = "Email/Login is required.";
            UserStep.UnsuccessfullLoginWithoutUsername(Configurator.ReadConfiguration().Password);

            var actualErrorMessage = loginPage.GetUsernameEmptyErrorMessage();

            Assert.That(actualErrorMessage, Does.Contain(expectedErrorMessage));
        }
        [Test]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureTag("Smoke Test", "Login")]
        [AllureDescription("Check that user can't login without User Name")]
        [AllureStep("User has not logged in without username")]
        public void LoginWithoutUserNameAndPasswordTest()
        {

            var expectedUserNameErrorMessage = "Email/Login is required.";
            var expectedPasswordErrorMessage = "Password is required.";

            UserStep.UnsuccessfullLoginWithoutPasswordAndUserNmae();

            var actualErrorMessage = loginPage.GetLoginErrorMessage();

            Assert.Multiple(() =>
            {
                Assert.That(actualErrorMessage, Does.Contain(expectedUserNameErrorMessage));
                Assert.That(actualErrorMessage, Does.Contain(expectedPasswordErrorMessage));
            });
                
            
        }

    }

}
