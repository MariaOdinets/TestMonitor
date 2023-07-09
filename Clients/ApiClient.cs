using NLog;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Clients
{
    public class ApiClient
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly RestClient restClient;

        public ApiClient(string accessToken)
        {
            var options = new RestClientOptions(baseUrl: Configurator.AppSettings.URL)
            {
                Authenticator = new JwtAuthenticator(accessToken: accessToken),
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };

            restClient = new RestClient(options);
        }

        public RestResponse Execute(RestRequest request)
        {
            logger.Info("Request: " + request.Resource);
            var response = restClient.Execute(request);

            logger.Info("Response Status: " + response.ResponseStatus);
            logger.Info("Response Body: " + response.Content);

            return response;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            logger.Info("Request: " + request.Resource);
            var response = restClient.Execute<T>(request);

            logger.Info("Response Status: " + response.ResponseStatus);
            logger.Info("Response Body: " + response.Content);

            return response.Data;
        }
    }
}