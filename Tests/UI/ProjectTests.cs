using TestMonitor.Models;
using TestMonitor.Pages;
using TestMonitor.Steps;
using TestMonitor.Utilities.Configuration;
using TestMonitor.Utilities.Helpers;

namespace TestMonitor.Tests.UI
{
    public class ProjectTests : BaseTest
    {
        [Test]
        public void CreateProjectTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(TestDataHelper.GetProjectByProjectType("standart project", "Project1.json"));

            Assert.IsTrue(settingsProjectsPage.IsProjectDisplayed());
        }

        [Test]
        public void DeleteProjectTest()
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(TestDataHelper.GetProjectByProjectType("create-delete project", "Project1.json"));
            ProjectSteps.DeleteAProject();

            Assert.IsTrue(!settingsProjectsPage.IsProjectDisplayed());
        }

        [Test]
        public void CheckNameInputMaxLength()
        {            
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(TestDataHelper.GetProjectByProjectType("Project name max lenght", "Project1.json"));

            //Assert.IsTrue(settingsProjectsPage.);
        }
    }
}