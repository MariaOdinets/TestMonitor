using Newtonsoft.Json;
using System.Reflection;
using TestMonitor.Models;

namespace TestMonitor.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Project GetTestProject(string fileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(Path.Combine(basePath, "TestData", fileName));

            return JsonConvert.DeserializeObject<Project>(json);
        }

        public static List<Project> GetTestProjects(string fileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(Path.Combine(basePath, "TestData", fileName));

            return JsonConvert.DeserializeObject<List<Project>>(json);
        }

        public static Project? GetProjectByProjectType(string type, string fileName)
        {
            return GetTestProjects(fileName).Find(x => x?.Type == type);
        }
    } 
}