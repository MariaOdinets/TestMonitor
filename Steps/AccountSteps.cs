using OpenQA.Selenium;
using TestMonitor.Pages;

namespace TestMonitor.Steps
{
    public class AccountSteps : BaseStep
    {
        public AccountSteps(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateToAccountPage()
        {
            new AccountPage(Driver, true);
        }
    }
}