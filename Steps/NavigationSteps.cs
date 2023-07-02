using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestMonitor.Models;
using TestMonitor.Pages;

namespace TestMonitor.Steps
{
    public class NavigationSteps : BaseStep
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public NavigationSteps(IWebDriver driver) : base(driver)
        {

        }

        [AllureStep("Navigate to Login Page")]
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
        }
    }
}