using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonitor.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        private static readonly By CreateProjectButtonBy = By.XPath("//*[contains(@class, 'button is-primary')]");
        private static readonly By NameInput = By.Name("name");
        private static readonly By DescriptionInput = By.Name("description");
        private static readonly By FeaturesButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        private static readonly By TemplateButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        private static readonly By CreateButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        public IWebElement CreateProjectButton => Driver.FindElement(CreateProjectButtonBy);

        public AddProjectPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public AddProjectPage(IWebDriver? driver) : base(driver, false)
        {

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreateProjectButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public void EnterProjectName(string name)
        {
            Driver.FindElement(NameInput).SendKeys(name);
        }

        public void EnterProjectDescription(string description) 
        { 
            Driver.FindElement(DescriptionInput).SendKeys(description);
        }

        public void ClickFeaturesButton()
        {
            Driver.FindElement(FeaturesButton).Click();
        }

        public void ClickTemplateButton()
        {
            Driver.FindElement(TemplateButton).Click();
        }

        public void ClickCreateButton()
        {
            Driver.FindElement(CreateButton).Click();
        }
    }
}