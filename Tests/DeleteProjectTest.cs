using TestRail.Helper;
using TestRail.Models;
using TestRail.Pages;


namespace TestRail.Tests
{
    public class DeleteProjectTest : BaseTest
    {
        private ProjectModel createdProject;
        public readonly JsonHelper jsonHelper = new JsonHelper();
      
        [SetUp]

        public void Setup()
        {
            createdProject = jsonHelper.FromJson<ProjectModel>(@"Resources/AddProjectFields.json");
            createdProject = ApiUserStep.ApiAddProject(createdProject);
            ProjectsPage._projectId = createdProject.Id;  
        }

        [Test]
        public void DeleteProject()
        {
           // projectId = createdProject.Id;  
            UserStep.SuccessfullLogin(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);
            Navigation.NavigationProjectPageStep();
        
            UserStep.DeleteProject();
        }
    }
}
