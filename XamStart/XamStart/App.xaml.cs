using XamStart.Factories;
using XamStart.Interfaces;
using XamStart.Views;
using System;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamStart.ViewModels;
using XamStart.Helpers;
using System.Runtime.CompilerServices;

#if (DEBUG == false)
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
#endif
namespace XamStart
{
	public partial class App : Application
	{
        //public static Page Page;
        public App ()
		{
			InitializeComponent();
            var navigateService = ViewModelLocator.Container.Resolve<INavigationService>();
            navigateService.RootNavigate(typeof(ILoginPage));
        }
       
        protected override void OnStart ()
		{
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{

			// Handle when your app resumes
		}
	}
}
