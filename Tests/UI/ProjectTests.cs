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
            var testProject = TestDataHelper.GetTestProject("Project1.json");

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(testProject);

            Assert.IsTrue(settingsProjectsPage.IsProjectDisplayed());
        }

        [Test]
        public void DeleteProjectTest()
        {
            var testProject = TestDataHelper.GetTestProject("Project1.json");

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(testProject);
            ProjectSteps.DeleteAProject();

            Assert.IsTrue(!settingsProjectsPage.IsProjectDisplayed());
        }

        [Test]
        public void CheckNameInputMaxLength()
        {
            var testProject = TestDataHelper.GetTestProject("Project1.json");

            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(testProject);
        }
    }
}