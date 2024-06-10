using OpenQA.Selenium;
using TestRail.Pages;

namespace TestRail.Steps.UI
{
    public class UserStep : BaseStep

    {
        private IWebDriver _driver;  
        private LoginPage loginPage;
        private ProjectsPage projectsPage;

        public UserStep(IWebDriver driver):base(driver)
        { 
            _driver = driver;
            loginPage = new LoginPage(driver);
            projectsPage = new ProjectsPage(driver);
        }
       
            public void Login(string UserName = "", string Password = "")
            {
                loginPage.UserNameField().SendKeys(UserName);
                loginPage.UserPasswordField().SendKeys(Password);
                loginPage.SubmitButton().Click();
            }

        public LoginPage SuccessfullLogin(string UserName, string Password)
        {
            Login(UserName, Password);
            return loginPage;
        }   
        
        public LoginPage UnsuccessfullLoginWithoutUsername( string Password)
        { 
            Login("",Password);
            return loginPage;
        }
        public LoginPage UnsuccessfullLoginWithoutPassword(string Username)
        {
            Login(Username, "");
            return loginPage;
        }

        public LoginPage UnsuccessfullLoginWithoutPasswordAndUserNmae()
        {
            Login("", "");
            return loginPage;
        }

        public ProjectsPage DeleteProject() 
        {
            projectsPage.ClickDeleteButton();    
            projectsPage.EnableDeleteCheckbox();
            projectsPage.ClickConfirmButton();
            return projectsPage;
        }
    }
    
}
