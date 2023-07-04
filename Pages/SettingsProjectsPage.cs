using OpenQA.Selenium;

namespace TestMonitor.Pages
{
    public class SettingsProjectsPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        private static readonly By CreateProjectButtonBy = By.XPath("//*[contains(@class, 'button is-primary')]");
        private static readonly By NameInput = By.Name("name");
        private static readonly By DescriptionInput = By.Name("description");
        private static readonly By FeaturesButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        private static readonly By TemplateButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        private static readonly By CreateButton = By.CssSelector(".modal-card [class = 'button is-primary']");
        private static readonly By ProjectTitleBy = By.XPath("//*[text()='Project_01']");
        private static readonly By MeatballMenuButton = By.CssSelector(".dropdown-component [class = 'button is-white']");
        private static readonly By DropdownArchive = By.XPath("//div[contains(text(), 'Archive...')]");
        private static readonly By ArchiveButton = By.CssSelector(".buttons.is-right.is-fullwidth [class = 'button is-danger']");
        public IWebElement CreateProjectButton => Driver.FindElement(CreateProjectButtonBy);

        public SettingsProjectsPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {

        }

        public SettingsProjectsPage(IWebDriver? driver) : base(driver, false)
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

        public void OpenProjectDetails()
        {
            Driver.FindElement(ProjectTitleBy).Click();
        }

        public void ClickMeatballMenu()
        {
            Driver.FindElement(MeatballMenuButton).Click();
        }

        public void SelectArchiveFromDropdown()
        {
            Driver.FindElement(DropdownArchive).Click();
        }

        public void ClickArchiveButton()
        {
            Driver.FindElement(ArchiveButton).Click();
        }
    }
}