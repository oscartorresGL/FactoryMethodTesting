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
    public class LogoutPageViewModelTests : BaseSetup
    {
        Mock<IPlatformLogout> logoutService;
        LogoutPageViewModel sut;
        string _AppMessage;

        #region Setup
        [TestInitialize()]
        public void Initialize()
        {
            _AppMessage = "";
            SetupBaseMocks();
            logoutService = new Mock<IPlatformLogout>();
            MessagingCenter.Subscribe<IForSendingMessageToAppStart, string>(this, "MessageSend", (sender, args) => {
                _AppMessage = args;
            });
        }
        #endregion

        [TestMethod]
        public async Task Logout_Should_SendMessage()
        {
            // arrange     
            logoutService.Setup(x => x.Logout());
            sut = new LogoutPageViewModel(currentlySelectedFactory.Object, logoutService.Object);

            // act
            sut.LogoutCommand.Execute(null);
            while (String.IsNullOrEmpty(_AppMessage))
            {
                await Task.Delay(0);
            }

            // assert
            Assert.AreEqual("Logout", _AppMessage);
            
        }

        #region Cleanup
        [TestCleanup]
        public void Cleanup()
        {
            MessagingCenter.Unsubscribe<IForSendingMessageToAppStart, string>(this, "MessageSend");
        }

        #endregion
    }
}
