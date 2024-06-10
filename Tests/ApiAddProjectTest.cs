using Allure.NUnit;
using Allure.NUnit.Attributes;
using TestRail.Helper;
using TestRail.Models;
using TestRail.Steps.API;

namespace TestRail.Tests
{
    [AllureNUnit]
    public class ApiAddProjectTest : ApiUserStep
    {
        private ProjectModel _projectData;
        private readonly JsonHelper jsonHelper = new JsonHelper();

        [Test]
        [AllureTag("API")]
        public void ApiAddProject()

        {
            _projectData = jsonHelper.FromJson<ProjectModel>(@"Resources/AddProjectFields.json");

            ProjectModel responseData = ApiAddProject(_projectData);

            Assert.Multiple(() =>
            {
                Assert.That(responseData.Id, Is.Not.EqualTo(0));
                Assert.That(_projectData.Equals(responseData));
            });
        }
    }
}
