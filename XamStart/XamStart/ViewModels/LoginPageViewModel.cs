using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using XamStart.Interfaces;
using XamStart.Models;
using Xamarin.Forms;
using Unity;

namespace XamStart.ViewModels
{
    public class LoginPageViewModel : BaseViewModel, ILoginPageViewModel
    {
        ILoginService loginService;
        INavigationService navigationService;

        public LoginPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, ILoginService loginService, INavigationService navigationService) : base(currentlySelectedFactory)
        {
            this.loginService = loginService;
            this.navigationService = navigationService;
        }



        protected override async Task Init()
        {
            IsBusy = true;
            var wasLoginGood = await loginService.Login();
            IsBusy = false;
            if (wasLoginGood)
            {
                HandleGoodResult();
            }
            else
            {
                HandleBadResult();
            }
        }


        private void HandleGoodResult() {
            currentlySelectedFactory.DesiredMasterDetailDetailPage = typeof(IHomePage);
            navigationService.RootNavigate(typeof(IMDPage));
        }

        private void HandleBadResult()
        {
            var user = currentlySelectedFactory.SelectedUser;
            if (user.Error.isHTML)
            {
                RaiseHTMLError();
            }
            else
            {
                SendErrorToView(user.Error.issue);
            }
            
        }

        private void RaiseHTMLError() => navigationService.RootNavigate(typeof(IErrorPage));

        private void SendErrorToView(string issue) => MessagingCenter.Send<ILoginPageViewModel, Tuple<string, string>>(this, "MessageSend", new Tuple<string, string>("Authentication Failed", issue));

    }
}
