using TestMonitor.Steps;
using TestMonitor.Utilities.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace TestMonitor.Tests.UI
{
    public class AccountTests : BaseTest
    {
        [Test(Description = "Successful profile image upload")]
        public void CheckUploadImage()
        {                       
            navigationSteps.SuccessfulLogin(Configurator.Admin);
            accountSteps.NavigateToAccountPage();
            accountPage.EditProfileIcon();
            bool isWebEqualToLocal = accountPage.CompareWebImageWithLocal();  
            
            Assert.IsTrue(isWebEqualToLocal);
        }
    }
}