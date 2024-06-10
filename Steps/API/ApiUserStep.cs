using RestSharp;
using System.Net;
using TestRail.Helper;
using TestRail.Models;

namespace TestRail.Steps.API
{
    public class ApiUserStep : ApiAuthenticateStep
    {
        private const string ApiAddProjectEndpoint = "/index.php?/api/v2/add_project";
        private const string apiGetProjectEndpoint = "/index.php?/api/v2/get_project/420";
        private const string DeleteProjectEndpoint = "https://qac0405.testrail.io/index.php?/api/v2/delete_project/{project_id}";
        public readonly JsonHelper jsonHelper = new JsonHelper();
        private ProjectModel projectData;
        public ProjectModel ApiAddProject(ProjectModel projectData)
        {
            Authenticate();
            var request = new RestRequest(ApiAddProjectEndpoint);
            request.AddJsonBody(jsonHelper.ToJson(projectData));

            var response = client.ExecutePost<ProjectModel>(request);
            logger.Info(response.Content);

            if (response.StatusCode != HttpStatusCode.OK)
            {
               logger.Error("Failed to add a project");
            };

             return response.Data;
         }

        public bool ApiDeleteProject(int projectId)
        {
            Authenticate();
            var request =  new RestRequest(DeleteProjectEndpoint.Replace("{project_id}", projectId.ToString()), Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                logger.Info($"Project with ID {projectId} was successfully deleted.");
                return true;
            }
            else
            {
                logger.Error($"Failed to delete project with ID {projectId}. Status code: {response.StatusCode}");
                return false;
            }
        }

        public ProjectModel ApiGetProject()
        {
            Authenticate();
            var request = new RestRequest(Configurator.ReadConfiguration().BaseUrl + apiGetProjectEndpoint, Method.Get);
            var response = client.ExecuteGet<ProjectModel>(request);
            logger.Info("REsponse" + response.Content);
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            return response.Data;
        }
    }   
}

