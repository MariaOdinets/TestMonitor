using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Runtime;
using System.Xml.Linq;
using TestMonitor.Models;
using TestMonitor.Pages;

namespace TestMonitor.Steps
{
    public class ProjectSteps : BaseStep
    {
        public ProjectSteps(IWebDriver driver) : base(driver)
        {

        }

        public void NavigateToSettingsProjectsPage()
        {
            new SettingsProjectsPage(Driver, true);
        }

        public SettingsProjectsPage CreateProject(Project project)
        {
            SettingsProjectsPage.CreateProjectButton.Click();
            SettingsProjectsPage.EnterProjectName(project.Name);
            SettingsProjectsPage.EnterProjectDescription(project.Description);
            SettingsProjectsPage.ClickFeaturesButton();
            SettingsProjectsPage.ClickTemplateButton();
            SettingsProjectsPage.ClickCreateButton();

            return SettingsProjectsPage;
        }

        public SettingsProjectsPage DeleteProject(Project project)
        {
            SettingsProjectsPage.OpenProjectDetails(project);
            SettingsProjectsPage.ClickMeatballMenu();
            SettingsProjectsPage.SelectArchiveFromDropdown();
            SettingsProjectsPage.ClickArchiveButton();

            return SettingsProjectsPage;
        }
    }
}