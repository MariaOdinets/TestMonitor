using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace TestMonitor.Utilities.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> configuration;
        public static IConfiguration Configuration => configuration.Value;

        static Configurator()
        {
            configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json"); ;

            return builder.Build();
        }

        public static AppSettings AppSettings
        {
            get
            {
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");

                appSettings.URL = child["URL"];

                return appSettings;
            }
        }
        public static string? BrowserType => Configuration[nameof(BrowserType)];
    }
}