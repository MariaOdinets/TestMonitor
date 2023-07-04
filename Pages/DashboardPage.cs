using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestMonitor.Pages
{
    public class DashboardPage : BasePage
    {
       private static string END_POINT = "my-projects";

       private static readonly By manageProjectsButton = By.XPath("//*[contains(@class, 'button is-white')]");
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

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void ClickManageProjectsButton()
        {
           Driver.FindElement(manageProjectsButton).Click();
        }
    }
}