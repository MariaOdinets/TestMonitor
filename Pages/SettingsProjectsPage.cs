using OpenQA.Selenium;
using TestMonitor.Models;

namespace TestMonitor.Pages
{
    public class SettingsProjectsPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        private static readonly By CreateProjectButtonBy = By.CssSelector("button.is-primary");
        private static readonly By NameInput = By.Name("name");
        private static readonly By DescriptionInput = By.Name("description");
        private static readonly By FeaturesButton = By.CssSelector(".modal-card .button.is-primary");
        private static readonly By TemplateButton = By.CssSelector(".modal-card .button.is-primary");
        private static readonly By CreateButton = By.CssSelector(".modal-card .button.is-primary");
        private static readonly By MeatballMenuButton = By.CssSelector(".dropdown-component .button.is-white");
        private static readonly By DropdownArchive = By.XPath("//div[contains(text(), 'Archive...')]");
        private static readonly By DialogBox = By.CssSelector(".modal-card");
        private static readonly By ArchiveButton = By.CssSelector(".buttons.is-right.is-fullwidth button.is-danger");
        private static readonly By CreatedAlert = By.CssSelector(".notices.is-top .toast.is-success.is-top");
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

        public bool IsProjectDisplayed(Project project)
        {
            By projectTitleBy = GetProjectNameXPath(project);
            return WaitService.GetVisibleElement(projectTitleBy) != null;
        }

        private static By GetProjectNameXPath(Project project)
        {
            return By.XPath($"//*[text()='{project.Name}']");
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

        public void OpenProjectDetails(Project project)
        {
            By projectTitleBy = GetProjectNameXPath(project);
            Driver.FindElement(projectTitleBy).Click();
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

        public bool IsProjectCreatedAlertDisplayed()
        {
            return WaitService.GetVisibleElement(CreatedAlert) != null;
        }

        public string GetAlertMessageText()
        {
            return Driver.FindElement(CreatedAlert).Text;
        }

        public bool IsDialogBoxDisplayed()
        {
            return WaitService.GetVisibleElement(DialogBox) != null;
        }
    }
}