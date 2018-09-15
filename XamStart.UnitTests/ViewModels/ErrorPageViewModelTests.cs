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
    public class ErrorPageViewModelTests : BaseSetup
    {
        ErrorPageViewModel sut;
        Mock<IPlatformStuff> platformStuff;

        [TestInitialize()]
        public void Initialize() {
            SetupBaseMocks();
            currentlySelectedFactory.Setup(x => x.SelectedUser).Returns(new Models.User() { Error = new Models.ErrorItem() { issue = "<!DOCTYPE html>", isHTML = true } });
            platformStuff = new Mock<IPlatformStuff>();
            platformStuff.Setup(x => x.GetBaseUrl()).Returns("file:///android_asset/web/");
            sut = new ErrorPageViewModel(currentlySelectedFactory.Object, platformStuff.Object);
        }
        [TestCleanup()]
        public void Cleanup() {
        }

        [TestMethod]
        public void Constructor_ShouldSet_HTML()
        {
            // arrange            

            // act            

            // assert
            Assert.IsTrue(!String.IsNullOrEmpty(sut.HTMLSource.Html));
            
        }
    }
}
