using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    }
}