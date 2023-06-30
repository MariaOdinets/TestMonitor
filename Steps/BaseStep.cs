using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestMonitor.Pages;

namespace TestMonitor.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver;

        public LoginPage LoginPage => new LoginPage(Driver);
        public DashboardPage DashboardPage => new DashboardPage(Driver);
        //public ProjectsPage AddProjectPage => new ProjectsPage(Driver);

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}