using Allure.NUnit;
using Allure.NUnit.Attributes;
using RestSharp;
using System.Net;
using TestRail.Helper;
using TestRail.Models;
using TestRail.Steps.API;

namespace TestRail.Tests
{
    [AllureNUnit]
    public class ApiAddProjectTest : ApiAuthenticateStep
    {
        private const string ApiEndpoint = "index.php?/api/v2/add_project";
        
        [Test]
        [AllureTag("Smoke Test", "Login")]
        public void ApiAddProject()

        {
            Authenticate();
            var request = new RestRequest(ApiEndpoint);
            var jsonHelper = new JsonHelper();
            var projectData = jsonHelper.FromJson<ProjectModel>(@"Resources/AddProjectFields.json");

            request.AddJsonBody(jsonHelper.ToJson(projectData));

            var response = client.ExecutePost<ProjectModel>(request);
            logger.Info(response.Content);

            dynamic projectId = response.Data.Id;
            logger.Info(response.Data.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(projectData.Equals(response.Data));
            }
            );
        }
    }
}
