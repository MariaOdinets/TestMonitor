using OpenQA.Selenium;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract bool IsPageOpened();
        protected void OpenPageByURL()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }
    }
}