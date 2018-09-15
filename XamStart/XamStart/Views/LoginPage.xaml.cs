using XamStart.Interfaces;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using XamStart.Views;
using XamStart.ViewModels;

namespace XamStart.Views
{
    public partial class LoginPage : ContentPageBase, ILoginPage
    {
        
        public LoginPage()
        {
            InitializeComponent();            
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Track("LoginPage Page");            
            MessagingCenter.Subscribe<ILoginPageViewModel, Tuple<string,string>>(this, "MessageSend", (sender, args) => {                
                CustomToastMessage(args.Item1, args.Item2);            
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            try {
                MessagingCenter.Unsubscribe<ILoginPageViewModel, Tuple<string,string>>(this, "MessageSend");
            }
            catch (Exception) { }
            
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}