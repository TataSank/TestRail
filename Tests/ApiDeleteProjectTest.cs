using NLog;
using TestRail.Helper;
using TestRail.Models;
using TestRail.Steps.API;

namespace TestRail.Tests
{
    public class ApiDeleteProjectTest: BaseTest
    {
        private ProjectModel createdProject;
        private int _projectId;
        public readonly JsonHelper jsonHelper = new JsonHelper();
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
       
        [SetUp]
        public void Setup()
        {
            createdProject = jsonHelper.FromJson<ProjectModel>(@"Resources/AddProjectFields.json");
            createdProject = ApiUserStep.ApiAddProject(createdProject);
            _projectId= createdProject.Id;   
        }
          
        [Test]
        public void ApiCheckDeleteProjectTest()
        {
            ApiUserStep.ApiDeleteProject(_projectId);
        }
    }
}
   

