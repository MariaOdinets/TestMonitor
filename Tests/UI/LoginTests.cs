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
            NavigationSteps.SuccessfulLogin(Configurator.UserByEmail("mariaodinets@gmail.co"));

            Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
        }

        //[Test]
        //public void IncorrectLogin()
        //{
        //    NavigationSteps.NavigateToLoginPage();
        //    NavigationSteps.LockedLogin(Configurator.UserByUsername("locked_out_user"));

        //    Assert.IsTrue(NavigationSteps.LoginPage.IsErrorButtonDisplayed());
        //}
    }
}