using OpenQA.Selenium;
using TestMonitor.Core;
using TestMonitor.Utilities.Configuration;

namespace TestMonitor.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WaitService WaitService;
        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPageByURL();
            }
        }

        public abstract bool IsPageOpened();
        protected abstract string GetEndpoint();
        protected void OpenPageByURL()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint()); 
        }
    }
}