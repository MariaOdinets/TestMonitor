using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Runtime;
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

        public SettingsProjectsPage CreateProject(string name, string description)
        {
            AddNewProject(name, description);
            return SettingsProjectsPage;
        }

        public SettingsProjectsPage CreateProject(Project project)
        {
            return CreateProject(project.Name, project.Description);
        }

        public SettingsProjectsPage DeleteAProject()
        {
            DeleteProject();
            return SettingsProjectsPage;
        }

        private void AddNewProject(string name, string description)
        {
            SettingsProjectsPage.CreateProjectButton.Click();
            SettingsProjectsPage.EnterProjectName(name);
            SettingsProjectsPage.EnterProjectDescription(description);
            SettingsProjectsPage.ClickFeaturesButton();
            SettingsProjectsPage.ClickTemplateButton();
            SettingsProjectsPage.ClickCreateButton();
        }

        private void DeleteProject()
        {
            SettingsProjectsPage.OpenProjectDetails();
            SettingsProjectsPage.ClickMeatballMenu();
            SettingsProjectsPage.SelectArchiveFromDropdown();
            SettingsProjectsPage.ClickArchiveButton();
        }        
    }
}