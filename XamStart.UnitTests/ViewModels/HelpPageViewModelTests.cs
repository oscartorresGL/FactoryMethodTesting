using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xamarin.Forms;
using XamStart.Factories;
using XamStart.Interfaces;
using XamStart.ViewModels;

namespace XamStart.UnitTests.ViewModels
{
    [TestClass]
    public class HelpPageViewModelTests : BaseSetup
    {
        Mock<ISendEmailService> sendEmailService;
        Mock<IPlatformStuff> platformStuff;
        HelpPageViewModel sut;
        
        [TestInitialize()]
        public void Initialize() {
            SetupBaseMocks();
            currentlySelectedFactory.Setup(x => x.SelectedUser).Returns(new Models.User() {fullName = "Me Myselft"});
            platformStuff = new Mock<IPlatformStuff>();
            platformStuff.Setup(x => x.GetAppName()).Returns("<app name>");
            platformStuff.Setup(x => x.GetVersion()).Returns("<some version>");
            sendEmailService = new Mock<ISendEmailService>();            
            sut = new HelpPageViewModel(currentlySelectedFactory.Object, sendEmailService.Object, platformStuff.Object);            
        }
        [TestCleanup()]
        public void Cleanup() {
        }

        [TestMethod]
        public void Constructor_ShouldSet_InitalValues()
        {
            // arrange            

            // act            

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(sut.Title));
            Assert.IsTrue(!String.IsNullOrEmpty(sut.AppName));
            Assert.IsTrue(!String.IsNullOrEmpty(sut.Version));
            Assert.IsNotNull(sut.SelectedUser);

        }
    }
}
