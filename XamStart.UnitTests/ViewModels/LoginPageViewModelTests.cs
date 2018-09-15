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
    public class LoginPageViewModelTests : BaseSetup
    {
        Mock<ILoginService> loginService;
        LoginPageViewModel sut;
        string _AppMessage;
        string _LoginPageMessageKey;
        string _LoginPageMessageValue;

        #region Setup
        [TestInitialize()]
        public void Initialize()
        {
            _AppMessage = "";
            _LoginPageMessageKey = "";
            _LoginPageMessageValue = "";
            SetupBaseMocks();
            loginService = new Mock<ILoginService>();
            MessagingCenter.Subscribe<IForSendingMessageToAppStart, string>(this, "MessageSend", (sender, args) => {
                _AppMessage = args;
            });
            MessagingCenter.Subscribe<ILoginPageViewModel, Tuple<string, string>>(this, "MessageSend", (sender, args) => {
                _LoginPageMessageKey = args.Item1;
                _LoginPageMessageValue = args.Item2;
            });
        }
        #endregion

        [TestMethod]
        public async Task Constructor_ShouldGrab_AuthenticatedUser()
        {
            // arrange     
            currentlySelectedFactory.Setup(x => x.SelectedUser).Returns(new Models.User() { fullName = "Clay", email = "some@email.com" });
            loginService.Setup(x => x.Login()).Returns(Task.FromResult(true));
            sut = new LoginPageViewModel(currentlySelectedFactory.Object, loginService.Object);

            // act
            sut.LoadedCommand.Execute(null);
            while (String.IsNullOrEmpty(_AppMessage))
            {
                await Task.Delay(0);
            }

            // assert
            Assert.IsNotNull(currentlySelectedFactory.Object.SelectedUser);
            Assert.IsTrue(!String.IsNullOrEmpty(currentlySelectedFactory.Object.SelectedUser.fullName));
            Assert.AreEqual("Authenticated", _AppMessage);
            Assert.IsTrue(string.IsNullOrEmpty(_LoginPageMessageKey));
            Assert.IsTrue(string.IsNullOrEmpty(_LoginPageMessageValue));
            
        }

        [TestMethod]
        public async Task Constructor_Authentication_ShouldFail()
        {
            // arrange    
            //currentlySelectedFactory.Setup(x => x.LastError).Returns(new Models.ErrorItem() { issue = "Some Error"});
            currentlySelectedFactory.Setup(x => x.SelectedUser).Returns(new Models.User() { Error = new Models.ErrorItem() { issue = "Some Error"} });
            loginService.Setup(x => x.Login()).Returns(Task.FromResult(false));
            sut = new LoginPageViewModel(currentlySelectedFactory.Object, loginService.Object);

            // act
            sut.LoadedCommand.Execute(null);
            while (String.IsNullOrEmpty(_LoginPageMessageKey))
            {
                await Task.Delay(0);
            }

            // assert

            Assert.IsNull(currentlySelectedFactory.Object.SelectedUser.fullName);
            CollectionAssert.AreEqual(_LoginPageMessageKey.ToCharArray(), "Authentication Failed".ToCharArray());
            CollectionAssert.AreEqual(_LoginPageMessageValue.ToCharArray(), currentlySelectedFactory.Object.SelectedUser.Error.issue.ToCharArray());
            Assert.IsFalse(currentlySelectedFactory.Object.SelectedUser.Error.isHTML);


        }

        [TestMethod]
        public async Task Constructor_TryingToGrabUser_ShouldReturnHTMLErrorPage()
        {
            // arrange    
            currentlySelectedFactory.Setup(x => x.SelectedUser).Returns(new Models.User() { Error = new Models.ErrorItem() { issue = "<!DOCTYPE html>", isHTML = true } });
            //currentlySelectedFactory.Setup(x => x.LastError).Returns(new Models.ErrorItem() { issue = "<!DOCTYPE html>", isHTML = true});
            loginService.Setup(x => x.Login()).Returns(Task.FromResult(false));
            sut = new LoginPageViewModel(currentlySelectedFactory.Object, loginService.Object);

            // act
            sut.LoadedCommand.Execute(null);
            while (String.IsNullOrEmpty(_AppMessage))
            {
                await Task.Delay(0);
            }

            // assert
            Assert.IsNull(currentlySelectedFactory.Object.SelectedUser.fullName);
            CollectionAssert.AreEqual(_AppMessage.ToCharArray(), "HTML Error".ToCharArray());
            Assert.IsTrue(currentlySelectedFactory.Object.SelectedUser.Error.isHTML);
            CollectionAssert.AreEqual(currentlySelectedFactory.Object.SelectedUser.Error.issue.ToCharArray(), "<!DOCTYPE html>".ToCharArray());

        }

        #region Cleanup
        [TestCleanup]
        public void Cleanup()
        {
            MessagingCenter.Unsubscribe<IForSendingMessageToAppStart, string>(this, "MessageSend");
            MessagingCenter.Unsubscribe<ILoginPageViewModel, Tuple<string, string>>(this, "MessageSend");
        }

        #endregion
    }
}
