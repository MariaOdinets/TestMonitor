using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonitor.Core;
using TestMonitor.Steps;

namespace TestMonitor.Tests.UI
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected NavigationSteps NavigationSteps;

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;

            NavigationSteps = new NavigationSteps(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
