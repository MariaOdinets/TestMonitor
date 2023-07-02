using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestMonitor.Core
{
    public class DriverFactory
    {
        public IWebDriver GetChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--disable-extensions");
            //chromeOptions.AddArguments("--headless");

            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(chromeOptions);
        }

        public IWebDriver GetFirefoxDriver()
        {
            var ffOptions = new FirefoxOptions();
            var profile = new FirefoxProfile();

            ffOptions.Profile = profile;

            ffOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            ffOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(ffOptions);
        }
    }
}