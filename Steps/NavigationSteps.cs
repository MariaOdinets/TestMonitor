﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestMonitor.Models;
using TestMonitor.Pages;

namespace TestMonitor.Steps
{
    public class NavigationSteps : BaseStep
    {
        public NavigationSteps(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage NavigateToLoginPage()
        {
            return new LoginPage(Driver);
        }

        public DashboardPage SuccessfulLogin(string email, string password)
        {
            Login(email, password);
            return DashboardPage;
        }

        public DashboardPage SuccessfulLogin(User user)
        {
            return SuccessfulLogin(user.Email, user.Password);
        }

        private void Login(string email, string password)
        {
            LoginPage.EnterEmail(email);
            LoginPage.EnterPassword(password);
            LoginPage.ClickLogin();
            Thread.Sleep(1000);
        }
    }
}