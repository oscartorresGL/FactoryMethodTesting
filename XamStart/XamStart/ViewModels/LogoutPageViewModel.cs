using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamStart.Interfaces;

namespace XamStart.ViewModels
{
    public class LogoutPageViewModel : BaseViewModel, ILogoutPageViewModel
    {
        IPlatformLogout platformLogout;
        INavigationService navigationService;
        public LogoutPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, IPlatformLogout platformLogout, INavigationService navigationService) : base(currentlySelectedFactory)
        {
            this.navigationService = navigationService;
            this.platformLogout = platformLogout;
            LogoutCommand = new Command(Logout);
            CancelCommand = new Command(Cancel);
        }

        public ICommand LogoutCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }

        private void Cancel()
        {
            navigationService.MDDetailPageNavigate(typeof(IHomePage));
        }
        private void Logout()
        {
            platformLogout.Logout();
            navigationService.RootNavigate(typeof(ILoginPage));
        }
    }
}
