using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMonitor.Pages
{
    public class DashboardPage : BasePage
    {
        private static readonly By manageProjectsButton = By.CssSelector(".button is-white");
       public DashboardPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public DashboardPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return Driver.FindElement(manageProjectsButton).Displayed;
        }
    }
}