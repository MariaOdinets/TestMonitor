using RestSharp;
using TestMonitor.Clients;
using TestMonitor.Models;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Services
{
    public class ProjectService : BaseService
    {
        public static readonly string GET_PROJECT = "/projects/{projectId}";
        public static readonly string POST_PROJECT = "/projects";

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public RestResponse GetProject(string projectId)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("projectId", projectId);

            return apiClient.Execute(request);
        }

        public Project GetAsProject(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("projectId", projectId);

            return apiClient.Execute<Project>(request);
        }
    }
}