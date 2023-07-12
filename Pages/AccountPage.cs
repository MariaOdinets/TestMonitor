using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonitor.Pages
{
    public class AccountPage : BasePage
    {
        private static string END_POINT = "my-account";

        private static readonly By ProfileIconBy = By.ClassName("avatar-component");
        private static readonly By FileInputBy = By.CssSelector("input[type='file']");

        public AccountPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public AccountPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return Driver.FindElement(ProfileIconBy).Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void EditProfileIcon()
        {
            string filePath = @"C:\sam.jfif";
            Driver.FindElement(FileInputBy).SendKeys(filePath);           
        }
    }
}