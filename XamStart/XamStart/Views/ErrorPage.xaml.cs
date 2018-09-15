using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamStart.Interfaces;
using XamStart.ViewModels;
using XamStart.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XamStart.Views
{
    public partial class ErrorPage : ContentPageBase, IErrorPage
    {
        public ErrorPage()
        {
            InitializeComponent();  
        }
        private async void Close(object sender, EventArgs e)
        {
           await Navigation.PopToRootAsync();
        }
        protected override void OnAppearing()
        {
            // Cannot be depended on in Android when navigating back to page
            base.OnAppearing();
            Track("ErrorPage Page");            
        }
    }
}