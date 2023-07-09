using Microsoft.Extensions.Configuration;
using System.Reflection;
using TestMonitor.Models;
using TestMonitor.Models.Enums;

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
                appSettings.Token = child["Token"];

                return appSettings;
            }
        }
        public static string? BrowserType => Configuration[nameof(BrowserType)];

        public static List<User?> Users
        {
            get
            {
                List<User?> users = new List<User?>();
                var child = Configuration.GetSection("Users");
                foreach (var section in child.GetChildren())
                {
                    var user = new User
                    {
                        Password = section["Password"],
                        Email = section["Email"],
                    };
                    user.UserType = section["UserType"]?.ToLower() switch
                    {
                        "admin" => UserType.Admin,
                        "user" => UserType.User,
                        _ => user.UserType
                    };
                    users.Add(user);
                }
                return users;
            }
        }
        public static User? Admin => Users.Find(x => x?.UserType == UserType.Admin);
        public static User? UserByEmail(string email) => Users.Find(x => x?.Email == email);
    }
}