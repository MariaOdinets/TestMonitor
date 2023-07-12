using TestMonitor.Models;
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
            projectSteps.DeleteProject(testProject);

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
        public void CheckNameInputOutOfMaxLengthTest()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("Project name max length + 1", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(!settingsProjectsPage.IsProjectDisplayed(testProject));
        }

        [Test(Description = "Checking alert message when project is created")]
        public void CheckCreateProjectAlertTest()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("standart project", "Projects.json");

            CreateProject(testProject);

            Assert.IsTrue(settingsProjectsPage.IsProjectCreatedAlertDisplayed());
            Assert.That(settingsProjectsPage.GetAlertMessageText(), Is.EqualTo($"Project {testProject.Name} created"));
        }

        [Test(Description = "Checking presence of dialog box")]
        public void CheckDialogBoxTest()
        {
            var testProject = TestDataHelper.GetProjectByProjectType("standart project", "Projects.json");

            CreateProject(testProject);
            settingsProjectsPage.OpenProjectDetails(testProject);
            settingsProjectsPage.ClickMeatballMenu();
            settingsProjectsPage.SelectArchiveFromDropdown();

            Assert.IsTrue(settingsProjectsPage.IsDialogBoxDisplayed());
        }

        private void CreateProject(Project? testProject)
        {
            navigationSteps.SuccessfulLogin(Configurator.Admin);
            projectSteps.NavigateToSettingsProjectsPage();
            projectSteps.CreateProject(testProject);
        }
    }
}