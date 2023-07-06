using System.Reflection;
using TestMonitor.Models;

namespace TestMonitor.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Project GetTestProject(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            return JsonHelper.FromJson(json).ToObject<Project>();
        }

        public static List<Project?> Projects
        {
            get
            {
                List<Project?> projects = new List<Project?>();

                foreach (var  in )
                {
                    var project = new Project
                    {
                        Name = section["Name"],
                        Type = section["Type"],
                        Description = section["Description"]
                    };
                    projects.Add(project);
                }
                return projects;
            }
        }
        public static Project? ProjectByProjectType(string type) => Projects.Find(x => x?.Type == type);
    }
}