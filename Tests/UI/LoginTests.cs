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
            navigationSteps.SuccessfulLogin(Configurator.Admin);

            Assert.IsTrue(navigationSteps.DashboardPage.IsPageOpened());
        }

        [Test(Description = "Invalid Credentials Login")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Standard_user")]
        [AllureSuite("Passed_suite")]
        [AllureSubSuite("GUI")]
        [AllureTag("regression")]
        public void InvalidCredentialsLoginTest()
        {
            navigationSteps.InvalidCredentialsLogin(Configurator.UserByEmail("sybogo@afia.pro"));

            Assert.That(navigationSteps.LoginPage.IsErrorMessageDisplayed());
            Assert.That(navigationSteps.LoginPage.GetErrorMessageText(), Is.EqualTo("These credentials do not match our records."));
        }

        [Test(Description = "Login with no email")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Standard_user")]
        [AllureSuite("Failed_suite")]
        [AllureSubSuite("GUI")]
        [AllureTag("regression")]
        public void NoEmailLoginTest()
        {
            navigationSteps.InvalidCredentialsLogin(Configurator.UserByEmail(""));

            Assert.IsTrue(navigationSteps.DashboardPage.IsPageOpened());
        }     
    }
}