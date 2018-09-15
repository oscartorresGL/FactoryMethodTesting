using XamStart.Interfaces;
using System;
using Unity;

using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace XamStart.Views
{
    public partial class LogoutPage : ContentPageBase, ILogoutPage
    {
        public LogoutPage()
        {
            InitializeComponent();           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Track("LogoutPage Page");
        }
    }
}