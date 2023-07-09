using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonitor.Clients;
using TestMonitor.Services;

namespace TestMonitor.Tests.API
{
    public class BaseApiTest
    {
        protected ApiClient apiClient;
        protected ProjectService projectService;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            this.apiClient = new ApiClient();
            this.projectService = new ProjectService(apiClient);
        }
    }
}