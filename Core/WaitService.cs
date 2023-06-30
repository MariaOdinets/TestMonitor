using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestMonitor.Core
{
    public class WaitService
    {
        [ThreadStatic] protected static IWebDriver? _driver;

        private WebDriverWait wait;

        public WaitService(IWebDriver? driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public IWebElement? GetVisibleElement(By by)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IAlert GetAlertOnPage()
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public IWebElement CheckElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver?>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}