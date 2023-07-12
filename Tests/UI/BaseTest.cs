using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestMonitor.Core;
using TestMonitor.Pages;
using TestMonitor.Steps;

namespace TestMonitor.Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected IWebDriver Driver;
        protected NavigationSteps navigationSteps;
        protected ProjectSteps projectSteps;
        private AllureLifecycle allure;
        protected WaitService waitService;
        protected SettingsProjectsPage settingsProjectsPage;
        protected AccountPage accountPage;
        protected AccountSteps accountSteps;

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            navigationSteps = new NavigationSteps(Driver);
            projectSteps = new ProjectSteps(Driver);
            waitService = new WaitService(Driver);
            settingsProjectsPage = new SettingsProjectsPage(Driver);
            accountPage = new AccountPage(Driver);
            accountSteps = new AccountSteps(Driver);
            allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}