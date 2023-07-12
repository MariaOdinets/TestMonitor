using Allure.Commons;
using NUnit.Allure.Attributes;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test(Description = "Successful Login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Standard_user")]
        [AllureSuite("Passed_suite")]
        [AllureSubSuite("GUI")]
        [AllureTag("regression")]

        public void SuccessfulLoginTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.UserByEmail("mariaodinets+01@gmail.com"));

            Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
        }

        [Test(Description = "Invalid Credentials Login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Standard_user")]
        [AllureSuite("Passed_suite")]
        [AllureSubSuite("GUI")]
        [AllureTag("regression")]
        public void InvalidCredentialsLoginTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.InvalidCredentialsLogin(Configurator.UserByEmail("sybogo@afia.pro"));

            Assert.That(NavigationSteps.LoginPage.IsErrorMessageDisplayed());
            Assert.That(NavigationSteps.LoginPage.GetErrorMessageText(), Is.EqualTo("These credentials do not match our records."));
        }

        [Test(Description = "Login with no email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Standard_user")]
        [AllureSuite("Failed_suite")]
        [AllureSubSuite("GUI")]
        [AllureTag("regression")]
        public void NoEmailLoginTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.InvalidCredentialsLogin("", "123");

            Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
            //Assert.That(NavigationSteps.LoginPage.GetErrorMessageText(), Is.EqualTo("These credentials do not match our records."));
        }
    }
}