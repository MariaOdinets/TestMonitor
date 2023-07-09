using Newtonsoft.Json.Linq;
using NLog;
using System.Net;
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

            var json = response.Content;

            var expectedStatusCode = HttpStatusCode.OK;
            var actualStatusCode = response.StatusCode;

            JToken? value = DeserialiseAndExtractFromJson(json);

            logger.Info("jsonObject -> name: " + value);

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

        private static JToken? DeserialiseAndExtractFromJson(string? json)
        {
            var jsonObject = JsonHelper.FromJson(json);
            var value = jsonObject.SelectToken("$.name");

            return value;
        }
    }
}