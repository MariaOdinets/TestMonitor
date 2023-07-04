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

        public void NavigateToAddProjectPage()
        {
            new AddProjectPage(Driver, true);
        }

        public AddProjectPage CreateProject(string name, string description)
        {
            AddNewProject(name, description);
            return AddProjectPage;
        }

        public AddProjectPage CreateProject(Project project)
        {
            return CreateProject(project.Name, project.Description);
        }

        private void AddNewProject(string name, string description)
        {
            AddProjectPage.CreateProjectButton.Click();
            AddProjectPage.EnterProjectName(name);
            AddProjectPage.EnterProjectDescription(description);
            AddProjectPage.ClickFeaturesButton();
            AddProjectPage.ClickTemplateButton();
            AddProjectPage.ClickCreateButton();

            //Assert.That();
        }
    }
}