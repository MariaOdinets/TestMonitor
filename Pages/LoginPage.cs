using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestMonitor.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        private static readonly By emailInput = By.Id("email");
        private static readonly By passwordInput = By.Id("password");
        private static readonly By loginButton = By.CssSelector("button.is-primary.is-fullwidth");        
        private static readonly By errorMessage = By.CssSelector(".message.is-danger");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            OpenPageByURL();
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
            OpenPageByURL();
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(loginButton) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void EnterEmail(string email)
        {
            Driver.FindElement(emailInput).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(passwordInput).SendKeys(password);
        }

        public void ClickLogin()
        {
            Driver.FindElement(loginButton).Click();
        }

        public bool IsErrorMessageDisplayed()
        {
            return Driver.FindElement(errorMessage).Displayed;
        }

        public string GetErrorMessageText()
        {
            return Driver.FindElement(errorMessage).Text;
        }
    }
}