﻿using Allure.Commons;
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
        protected NavigationSteps NavigationSteps;
        protected ProjectSteps ProjectSteps;
        private AllureLifecycle allure;
        protected WaitService WaitService;
        protected SettingsProjectsPage settingsProjectsPage;

        [SetUp]
        public void SetUp()
        {
            logger.Trace("Trace message");
            logger.Debug("Debug message");
            logger.Info("Info message");
            logger.Warn("Warn message");
            logger.Error("Error message");
            logger.Fatal("Fatal message");

            Driver = new Browser().Driver;

            NavigationSteps = new NavigationSteps(Driver);
            ProjectSteps = new ProjectSteps(Driver);
            WaitService = new WaitService(Driver);
            settingsProjectsPage = new SettingsProjectsPage(Driver);

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