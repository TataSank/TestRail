using OpenQA.Selenium;
using TestRail.Elements;

namespace TestRail.Pages
{
    public class ProjectsPage:BasePage

    {
       public static int _projectId;

        
        private static By DeleteButtonBy(int projectId) => By.XPath($"//a[contains(@href,'index.php?/admin/projects/edit/{projectId}')]/ancestor::tr//div[@data-testid='projectDeleteButton']");

        private static readonly By DeleteCheckboxBy = By.XPath("//*[@id='deleteDialog']//*[@name='deleteCheckbox']");
        private static readonly By ConfirmButtonBy = By.XPath("//*[@id='deleteDialog']//*[contains(@class, 'button-ok')]");
        
        public ProjectsPage(IWebDriver driver, int projectId, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            _projectId = projectId;
        }
        public ProjectsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
            
        }
        public UiElement DeleteCheckbox() => new UiElement(Driver, DeleteCheckboxBy);
        public Button DeleteButton() => new Button(Driver, DeleteButtonBy(_projectId));
        public Button ConfirmButton() => new Button(Driver, ConfirmButtonBy);
        public void ClickDeleteButton()
        {
            DeleteButton().Click();   
        }
        public void ClickConfirmButton()
        { 
            ConfirmButton().Click();    
        }
        public void EnableDeleteCheckbox()
        {
            var deleteCheckbox = DeleteCheckbox();
            if (!deleteCheckbox.Selected)
            {
                deleteCheckbox.Click();
            }
        }

        protected override bool EvaluateLoadedStatus()
        {
            return true;
        }
    }
}
