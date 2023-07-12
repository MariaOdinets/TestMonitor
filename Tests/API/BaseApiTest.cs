using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonitor.Clients;
using TestMonitor.Services;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Tests.API
{
    public class BaseApiTest
    {
        protected ProjectService projectService;
        protected ProjectService projectServiceUnauthorized;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            var apiClient = new ApiClient(Configurator.AppSettings.Token);
            var apiClientUnauthorized = new ApiClient("123");

            this.projectService = new ProjectService(apiClient);
            this.projectServiceUnauthorized = new ProjectService(apiClientUnauthorized);
        }
    }
}