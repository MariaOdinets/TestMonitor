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

        private LoginPage loginPage;
        public LoginPage LoginPage
        {
            get
            {
                if (this.loginPage == null)
                    this.loginPage = new LoginPage(Driver);

                return this.loginPage;
            }
        }

        public DashboardPage dashboardPage;
        public DashboardPage DashboardPage
        {
            get
            {
                if (this.dashboardPage == null)
                    this.dashboardPage = new DashboardPage(Driver);

                return this.dashboardPage;
            }
        }

        public AddProjectPage addProjectPage;
        public AddProjectPage AddProjectPage
        {
            get
            {
                if (this.addProjectPage == null)
                    this.addProjectPage = new AddProjectPage(Driver);

                return this.addProjectPage;
            }
        }

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}