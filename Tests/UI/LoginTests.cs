using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test]

        public void SuccessfulLoginTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.UserByEmail("mariaodinets@gmail.com"));

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
