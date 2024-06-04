using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using TestRail.Pages;

namespace TestRail.Tests
{
    public class ApiGetProjectTest : ApiAuthenticateTest
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Smoke Test", "Login")]
        public void ApiGetProjects()
        {
            const string endpoint = "/index.php?/api/v2/get_project/1";

            Authenticate();

            var request = new RestRequest(endpoint);
            var response = client.ExecuteGet(request);

            logger.Info(response.Content);
            Assert.That(response.StatusCode == HttpStatusCode.OK);

        }
    }
}
