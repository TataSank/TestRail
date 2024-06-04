using RestSharp.Authenticators;
using RestSharp;
using TestRail.Helper;
using NLog;

namespace TestRail.Pages
{
    public class ApiAuthenticateTest
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        protected RestClient client;
        
        public void Authenticate()
        {
            try
            {
                var restOptions = new RestClientOptions(Configurator.ReadConfiguration().BaseUrl);
                {
                    restOptions.Authenticator = new HttpBasicAuthenticator(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);
                };
                client = new RestClient(restOptions);

                var endpoint = "index.php?/api/v2/get_projects";
                var request = new RestRequest(endpoint);
                var response = client.ExecutePost(request);
                logger.Info(response);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "User is not authenticate");
            }
        }
    }
}
