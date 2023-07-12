using Allure.Commons;
using NUnit.Allure.Attributes;
using TestMonitor.Models;
using TestMonitor.Pages;
using TestMonitor.Steps;
using TestMonitor.Utilities.Configuration;
using TestMonitor.Utilities.Helpers;

namespace TestMonitor.Tests.UI
{
    public class ProjectTests : BaseTest
    {
        [Test(Description = "Successful Project creation")]
        public void CreateProjectTest()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("standart project", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(settingsProjectsPage.IsProjectDisplayed(testProject));
        }        

        [Test(Description = "Successful Project deletion")]
        public void DeleteProjectTest()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("create-delete project", "Projects.json");

            CreateProject(testProject);
            ProjectSteps.DeleteProject(testProject);

            Assert.IsTrue(!settingsProjectsPage.IsProjectDisplayed(testProject));
        }

        [Test(Description = "Project name input max length")]
        public void CheckNameInputMaxLength()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("Project name max length", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(settingsProjectsPage.IsProjectDisplayed(testProject));
        }

        [Test(Description = "Project name input max length - 1")]
        public void CheckNameInputMaxLengthMinusOne()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("Project name max length - 1", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(settingsProjectsPage.IsProjectDisplayed(testProject));
        }

        [Test(Description = "Project name input max length out of boundary value")]
        public void CheckNameInputOutOfMaxLength()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("Project name max length + 1", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(!settingsProjectsPage.IsProjectDisplayed(testProject));
        }

        private void CreateProject(Project? testProject)
        {
            NavigationSteps.NavigateToLoginPage();
            NavigationSteps.SuccessfulLogin(Configurator.Admin);
            ProjectSteps.NavigateToSettingsProjectsPage();
            ProjectSteps.CreateProject(testProject);
        }
    }
}