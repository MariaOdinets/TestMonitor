using RestSharp;
using TestMonitor.Clients;
using TestMonitor.Models;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Services
{
    public class ProjectService : BaseService
    {

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public RestResponse GetProject(string projectId)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("projectId", projectId);

            return apiClient.Execute(request);
        }

        public RestResponse PostProject(Project project)
        {
            var request = new RestRequest(Endpoints.POST_PROJECT, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(project);

            return apiClient.Execute(request);
        }
    }
}