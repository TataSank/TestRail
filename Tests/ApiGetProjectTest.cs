using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NLog;
using TestRail.Helper;
using TestRail.Models;
using TestRail.Steps.API;


namespace TestRail.Tests
{
    public class ApiGetProjectTest : BaseTest
    {
        private ProjectModel projectData;
        private ProjectModel _projectData;
        public readonly JsonHelper jsonHelper = new JsonHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            projectData = new ProjectModel();
            _projectData = jsonHelper.FromJson<ProjectModel>(@"Resources/GetProject.json");
        }
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "API")]
        public void ApiGetProjects()
        {          
            ApiUserStep.ApiGetProject();
            logger.Info("Expected" + _projectData);
            
        Assert.That(projectData.Equals(_projectData));
          
        }
    }
}
