using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestMonitor.Core;
using TestMonitor.Steps;
namespace TestMonitor.Tests.UI
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected NavigationSteps NavigationSteps;
        private AllureLifecycle allure;

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;

            NavigationSteps = new NavigationSteps(Driver);
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
        }
    }
}
