using RestSharp;
using TestMonitor.Clients;
using TestMonitor.Models;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Services
{
    public class ProjectService : BaseService
    {
        public static readonly string GET_PROJECT = "/projects/{projectId}";

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

        public Task<RestResponse> GetProjectAsync(string projectId)
        {
            var request = new RestRequest("/projects/{projectId}")
                .AddUrlSegment("projectId", projectId);

            return apiClient.ExecuteAsync(request);
        }

        public Project GetAsProjectAsync(string projectId)
        {
            var request = new RestRequest("/projects/{projectId}")
                .AddUrlSegment("projectId", projectId);

            return apiClient.ExecuteAsync<Project>(request).Result;
        }

        public Task<Project> AddProjectAsync(Project project)
        {
            var request = new RestRequest("/projects", Method.Post)
            .AddHeader("Content-Type", "application/json")
                .AddBody(project);

            return apiClient.ExecuteAsync<Project>(request);
        }

        public RestResponse UpdateProject(string projectId, Project project)
        {
            return null;
        }

        public RestResponse DeleteProject(string projectId)
        {
            return null;
        }
    }
}