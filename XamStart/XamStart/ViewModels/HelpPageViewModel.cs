using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.Models;
using Xamarin.Forms;
using System.Windows.Input;
using CommonServiceLocator;
using Unity;

namespace XamStart.ViewModels
{
    public class HelpPageViewModel : BaseViewModel, IHelpPageViewModel
    {
        ISendEmailService sendEmailService;

        string appName;
        public string AppName
        {
            get { return appName; }
            set { SetProperty(ref appName, value); }
        }

        User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); }
        }

        string version;
        public string Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }
        


        public HelpPageViewModel(ICurrentlySelectedFactory currentlySelectedFactory, ISendEmailService sendEmailService, IPlatformStuff platformStuff) : base(currentlySelectedFactory)
        {
            Title = "Help";
            IsBusy = false;
            Version = platformStuff.GetVersion();
            AppName = platformStuff.GetAppName();
            this.sendEmailService = sendEmailService;
            EmailCommand = new Command(Email);
            AppDetailsCommand = new Command(LaunchWebsite);
            SelectedUser = currentlySelectedFactory.SelectedUser;
            

        }
        private void LaunchWebsite()
        {
            var urlstring = $"https://www.google.com";     // put some website here that shows versioning data about your app       
            Device.OpenUri(new Uri(urlstring));

        }
        private void Email()
        {
                if (sendEmailService == null)
                    return;
                sendEmailService.ComposeMail(new[] { "foo@example.com" }, "Test", "Hello, World");
        }
        public ICommand AppDetailsCommand { protected set; get; }
        public ICommand EmailCommand { protected set; get; }
       
    }
}
