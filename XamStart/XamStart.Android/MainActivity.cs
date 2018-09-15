using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Android.Content;
using XamStart.Droid.DependencyServices;
using Xamarin.Forms;
using FFImageLoading;
using XamStart.Interfaces;
using System.Threading.Tasks;
using XamStart.Helpers;
using Unity;

namespace XamStart.Droid
{
    [Activity(Label = "XamStart", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Context Context;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            PlatformStuff.GetContext = () => this;
            ToastService.GetContext = () => this;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledException;

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //CrossCurrentActivity.Current.Init(this, bundle);
            //Context context = this.ApplicationContext;
            
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(false);
            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new CustomLogger(),
            };
            ImageService.Instance.Initialize(config);




            LoadApplication(new App());
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        private void AndroidEnvironmentOnUnhandledException(object sender, RaiseThrowableEventArgs e)
        {
            Console.WriteLine("");
            //GoogleAnalytics.Current.Tracker.SendException(e.Exception, false);
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("");

            // GoogleAnalytics.Current.Tracker.SendException(e.Exception, false);
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("");
            //GoogleAnalytics.Current.Tracker.SendException(JsonConvert.SerializeObject(e.ExceptionObject), false);
        }
        public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
        {
            public void Debug(string message)
            {
                Console.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                //GoogleAnalytics.Current.Tracker.SendException(errorMessage, false);
                Console.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                Error(errorMessage + System.Environment.NewLine + ex.ToString());
            }
        }

        public override void OnBackPressed()
        {
            //var x = DependencyService.Get<IMDPage>();
            var x = ViewModelLocator.Container.Resolve<IMDPage>();
            if (x.DoBack)
            {
                base.OnBackPressed();
            }
        }
    }
}

