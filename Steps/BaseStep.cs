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

        public SettingsProjectsPage settingsProjectsPage;
        public SettingsProjectsPage SettingsProjectsPage
        {
            get
            {
                if (this.settingsProjectsPage == null)
                    this.settingsProjectsPage = new SettingsProjectsPage(Driver);

                return this.settingsProjectsPage;
            }
        }

        public AccountPage accountPage;
        public AccountPage AccountPage
        {
            get
            {
                if (this.accountPage == null)
                    this.accountPage = new AccountPage(Driver);

                return this.accountPage;
            }
        }

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}