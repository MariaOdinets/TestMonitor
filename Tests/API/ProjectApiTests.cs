using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using System.Net;
using TestMonitor.Models;
using TestMonitor.Services;
using TestMonitor.Utilities.Helpers;

namespace TestMonitor.Tests.API
{
    public class ProjectApiTests : BaseApiTest
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [Test(Description = "Get existing project")]
        public void GetProject()
        {
            var response = projectService.GetProject("33");

            var expectedStatusCode = HttpStatusCode.OK;
            var actualStatusCode = response.StatusCode;

            Assert.That(actualStatusCode, Is.EqualTo(expectedStatusCode));
        }

        [Test(Description = "Get nonexistent project")]
        public void GetFictionalProject()
        {
            var response = projectService.GetProject("333");

            var expectedStatusCode = HttpStatusCode.NotFound;
            var actualStatusCode = response.StatusCode;

            Assert.That(actualStatusCode, Is.EqualTo(expectedStatusCode));
        }

        [Test(Description = "Get project unauthorized")]        
        public void GetProjectUnauthorized()
        {
            var response = projectServiceUnauthorized.GetProject("33");

            var expectedStatusCode = HttpStatusCode.Unauthorized;
            var actualStatusCode = response.StatusCode;

            Assert.That(actualStatusCode, Is.EqualTo(expectedStatusCode));
        }

        [Test(Description = "Post a project")]
        public void PostProject()
        {
            var project = new Project();
            project.Name = "Post project";
            project.Description = "This project was created automatically using post method";
            project.symbol_id = 1;

            var actualProject = projectService.PostProject(project);

            var expectedStatusCode = HttpStatusCode.Created;
            var actualStatusCode = actualProject.StatusCode;

            Assert.That(actualStatusCode, Is.EqualTo(expectedStatusCode));
        }
    }
}