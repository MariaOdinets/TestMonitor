using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestMonitor.Utilities.Helpers
{
    public class JsonHelper
    {
        public static JObject FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JObject>(json);
        }
    }
}